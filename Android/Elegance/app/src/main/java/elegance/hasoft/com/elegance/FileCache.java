package elegance.hasoft.com.elegance;

import android.content.Context;
import android.os.Environment;

import java.io.File;

/**
 * Geekboy did this
 */
public class FileCache {
    private File cacheDir;

    public FileCache(Context context) {
        //find dir to save cached images
        if(Environment.getExternalStorageState().equals(Environment.MEDIA_MOUNTED))
            cacheDir = new File(Environment.getExternalStorageDirectory(),"TempImages");
        else
            cacheDir = context.getCacheDir();
        if(!cacheDir.exists())
            cacheDir.mkdirs();
    }

    public File getFile(String url){
        String filename = String.valueOf(url.hashCode());
        File f = new File(cacheDir,filename);
        return f;
    }
    public void clear(){
        File[] files = cacheDir.listFiles();
        if (files == null)
            return;
        for(File f:files)
            f.delete();
    }

}