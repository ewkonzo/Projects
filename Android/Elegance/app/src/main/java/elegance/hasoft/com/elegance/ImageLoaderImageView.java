package elegance.hasoft.com.elegance;

import android.app.Activity;
import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.drawable.BitmapDrawable;
import android.graphics.drawable.Drawable;
import android.widget.ImageView;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.Collections;
import java.util.Map;
import java.util.WeakHashMap;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

/**
 * Created by Erick Genius on 7/2/2014.
 */
public class ImageLoaderImageView {
    MemoryCache memoryCache = new MemoryCache();
    FileCache fileCache;
    private Map<ImageView,String> imageViews = Collections.synchronizedMap(new WeakHashMap<ImageView,String>());
    ExecutorService executorService;

    public ImageLoaderImageView(Context context) {
        fileCache = new FileCache(context);
        executorService = Executors.newFixedThreadPool(5);
    }
    int stub_id = R.mipmap.ic_launcher;
    public  void DisplayImage(String url,int loader, ImageView imageView){
        stub_id = loader;
        imageViews.put(imageView,url);
        Bitmap bitmap = memoryCache.get(url);
        if (bitmap !=null){
            Drawable drawable = new BitmapDrawable(bitmap);
            imageView.setImageDrawable(drawable);
        }else{
            queryPhoto(url,imageView);
            imageView.setImageResource(loader);
        }
    }

    private void queryPhoto(String url, ImageView imageView){
        PhotoToLoad p = new PhotoToLoad(url,imageView);
        executorService.submit(new PhotosLoader(p));

    }
    private Bitmap getBitmap(String url){
        File f = fileCache.getFile(url);
        //from sdcard
        Bitmap b = decodeFile(f);
        if (b!=null)
            return b;
        try {
            Bitmap bitmap = null;
            URL imageUrl = new URL(url);
            HttpURLConnection conn = (HttpURLConnection)imageUrl.openConnection();
            conn.setConnectTimeout(30000);
            conn.setReadTimeout(30000);
            conn.setInstanceFollowRedirects(true);
            InputStream is = conn.getInputStream();
            OutputStream os = new FileOutputStream(f);
            Utils.CopyStream(is,os);
            os.close();
            bitmap = decodeFile(f);
            return bitmap;
        }catch (Exception e){
            e.printStackTrace();
            return null;
        }

    }

    private  Bitmap decodeFile(File f){
        try {
            //decode image size
            BitmapFactory.Options o = new BitmapFactory.Options();
            o.inJustDecodeBounds = true;
            o.inScaled=false;
            BitmapFactory.decodeStream(new FileInputStream(f),null,o);

            //find the correct file size. It should be the power of 2
            final int REQUIRED_SIZE = 200;
            int width_temp = o.outWidth, height_temp = o.outHeight;
            int scale = 1;
            while (true){
                if(width_temp/2<REQUIRED_SIZE || height_temp/2<REQUIRED_SIZE)
                    break;
                width_temp/=2;
                height_temp/=2;
                scale*=2;
            }
            //decode with inSampleSize
            BitmapFactory.Options o2 = new BitmapFactory.Options();
            o2.inSampleSize = scale;
            o2.inScaled=false;
            return BitmapFactory.decodeStream(new FileInputStream(f),null,o2);


        }catch (FileNotFoundException e){
            return null;
        }
    }

    private class PhotoToLoad{
        public String url;
        public ImageView imageView;

        private PhotoToLoad(String url, ImageView imageView) {
            this.url = url;
            this.imageView = imageView;
        }

    }
    class PhotosLoader implements Runnable{
        PhotoToLoad photoToLoad;
        PhotosLoader(PhotoToLoad photoToLoad) {
            this.photoToLoad = photoToLoad;
        }



        @Override
        public void run() {
            if(imageViewReused(photoToLoad))
                return;
            Bitmap bmp = getBitmap(photoToLoad.url);
            memoryCache.put(photoToLoad.url,bmp);
            if (imageViewReused(photoToLoad))
                return;;
            BitmapDisplayer bd = new BitmapDisplayer(bmp,photoToLoad);
            Activity a = (Activity) photoToLoad.imageView.getContext();
            a.runOnUiThread(bd);
           }
    }
    boolean imageViewReused(PhotoToLoad photoToLoad){
        String tag = imageViews.get(photoToLoad.imageView);
        if (tag==null || !tag.equals(photoToLoad.url))
        return true;
        return false;
    }
    class BitmapDisplayer implements Runnable{
        Bitmap bitmap;
        PhotoToLoad photoToLoad;

        BitmapDisplayer(Bitmap bitmap, PhotoToLoad photoToLoad) {
            this.bitmap = bitmap;
            this.photoToLoad = photoToLoad;
        }

        @Override
        public void run() {
        if(imageViewReused(photoToLoad))
            return;
            if(bitmap!=null){
                Drawable bitMap = new BitmapDrawable(bitmap);
                photoToLoad.imageView.setImageDrawable(bitMap);}
                else{
                photoToLoad.imageView.setImageResource(stub_id);}
        }

    }
    public void clearCache(){
        memoryCache.clear();
        fileCache.clear();
      }
}
