package elegance.hasoft.com.elegance;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.PorterDuff;
import android.graphics.PorterDuffXfermode;
import android.graphics.Rect;
import android.graphics.drawable.BitmapDrawable;
import android.graphics.drawable.Drawable;
import android.util.AttributeSet;
import android.widget.ImageView;

/**
 * Created by User on May-12.
 */
public class RoundedImage extends ImageView {


    public RoundedImage (Context c,AttributeSet attrs){
        super(c,attrs);
    }


    protected void onDraw(Canvas canvas){
        Drawable drawable=getDrawable();
        if(drawable==null){
            return;
        }
        if(getWidth()==0||getHeight()==0){
            return;
        }
        Bitmap b=((BitmapDrawable)drawable).getBitmap();
        Bitmap bitmap=b.copy(Bitmap.Config.ARGB_8888,true);
        int w=getWidth(),h=getHeight();
        Bitmap roundB=getRound(bitmap,w);
        canvas.drawBitmap(roundB,0,0,null);
    }

    public static Bitmap getRound(Bitmap bm,int radius){
        Bitmap finalBm;
        if(bm.getWidth()!=radius||bm.getHeight()!=radius)
            finalBm=Bitmap.createScaledBitmap(bm,radius,radius,false);
        else
            finalBm=bm;
        Bitmap output=Bitmap.createBitmap(finalBm.getWidth(),finalBm.getHeight(), Bitmap.Config.ARGB_8888);
        Canvas canvas=new Canvas(output);
        final Paint paint=new Paint();
        final Rect rect=new Rect(0,0,finalBm.getWidth(),finalBm.getHeight());
        paint.setAntiAlias(true);
        paint.setFilterBitmap(true);
        paint.setDither(true);
        canvas.drawARGB(0,0,0,0);
        paint.setColor(Color.parseColor("#BAB399"));
        canvas.drawCircle(finalBm.getWidth()/2+0.7f,finalBm.getHeight()/2+0.7f,finalBm.getWidth()/2+0.1f,paint);
        paint.setXfermode(new PorterDuffXfermode(PorterDuff.Mode.SRC_IN));
       canvas.drawBitmap(finalBm,rect,rect,paint);
       return output;
    }
}
