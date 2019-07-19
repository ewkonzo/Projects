package elegance.hasoft.com.elegance;

import android.app.Dialog;
import android.content.Context;
import android.content.Intent;
import android.graphics.Typeface;
import android.net.Uri;
import android.os.Bundle;
import android.view.MotionEvent;
import android.view.View;
import android.view.Window;
import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.widget.RelativeLayout;
import android.widget.TextView;

import floatt.FloatingActionButton;

/**
 * Created by User on Jun-30.
 */
public class VendorDialog extends Dialog {
    Context context;
    View view;
    View backView;
    String title,vendor;
    FloatingActionButton pick,call;
    TextView vname,vdetails,vproducts,vna;
    RoundedImage vimage;
    boolean selected=false;

    public VendorDialog(Context context,String vendor) {
        super(context, android.R.style.Theme_Translucent);
        this.context = context;// init Context
        this.vendor=vendor;
    }


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        super.onCreate(savedInstanceState);
        setContentView(R.layout.dialog);

        view = (RelativeLayout)findViewById(R.id.contentDialog);
        backView = (RelativeLayout)findViewById(R.id.dialog_rootView);
        backView.setOnTouchListener(new View.OnTouchListener() {

            @Override
            public boolean onTouch(View v, MotionEvent event) {
                if (event.getX() < view.getLeft()
                        || event.getX() >view.getRight()
                        || event.getY() > view.getBottom()
                        || event.getY() < view.getTop()) {
                    dismiss();
                }
                return false;
            }
        });
        pick=(FloatingActionButton)findViewById(R.id.pick);
        call=(FloatingActionButton)findViewById(R.id.call);
        vimage=(RoundedImage)findViewById(R.id.vimage);
        vname=(TextView)findViewById(R.id.vname);
        vna=(TextView)findViewById(R.id.vna);
        vdetails=(TextView)findViewById(R.id.vdetails);
        vproducts=(TextView)findViewById(R.id.vproducts);
        setAdapter();

    }


    public void setAdapter(){
        ImageLoaderImageView loader=new ImageLoaderImageView(null);
        vname.setText(vendor);
        vname.setTypeface(Typeface.DEFAULT_BOLD);
        vna.setTypeface(Typeface.DEFAULT_BOLD);
        vproducts.setText("Sells clothes");
        vdetails.setText("Phone Number: 0718353279 | Email:dnatkeezy@gmail.com | Country :Turkey | Market : Electronic Market");

        pick.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
               dismiss();
            }
        });

        call.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent c=new Intent(Intent.ACTION_CALL);
                c.setData(Uri.parse("tel:0718353279"));
                context.startActivity(c);
            }
        });


    }



    @Override
    public void show() {
        // TODO 自动生成的方法存根
        super.show();
        // set dialog enter animations
        view.startAnimation(AnimationUtils.loadAnimation(context, R.anim.dialog_main_show_amination));
        backView.startAnimation(AnimationUtils.loadAnimation(context, R.anim.dialog_root_show_amin));
    }



    @Override
    public void dismiss() {
        Animation anim = AnimationUtils.loadAnimation(context, R.anim.dialog_main_hide_amination);
        anim.setAnimationListener(new Animation.AnimationListener() {

            @Override
            public void onAnimationStart(Animation animation) {
            }

            @Override
            public void onAnimationRepeat(Animation animation) {
            }

            @Override
            public void onAnimationEnd(Animation animation) {
                view.post(new Runnable() {
                    @Override
                    public void run() {
                        VendorDialog.super.dismiss();
                    }
                });

            }
        });
        Animation backAnim = AnimationUtils.loadAnimation(context, R.anim.dialog_root_hide_amin);

        view.startAnimation(anim);
        backView.startAnimation(backAnim);
    }

}
