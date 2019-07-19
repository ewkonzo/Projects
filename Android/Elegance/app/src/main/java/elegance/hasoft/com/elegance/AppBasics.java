package elegance.hasoft.com.elegance;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.provider.MediaStore;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.gc.materialdesign.views.ButtonFlat;
import com.gc.materialdesign.widgets.Dialog;

import java.io.ByteArrayOutputStream;
import java.net.HttpURLConnection;

/**
 * Created by User on Mar-09. GeekBoy did this
 */
class AppBasics {
    Context c;
    Activity act;
    DataManager dm;
    SharedPreferences app;
    Bitmap bm;
    HttpURLConnection con;
    private String delimiter = "--";
    private String boundary =  "SwA"+Long.toString(System.currentTimeMillis())+"SwA";
    ByteArrayOutputStream os;
    Uri imageuri;
    String image_str,temp=null;
    RoundedImage rimg;
    ImageView img;
    public AppBasics(Activity a){
        c=a;
        act=a;
        app=a.getSharedPreferences("settings",a.MODE_PRIVATE);
    }

    public void showToast(String message){
        Toast.makeText(c,message,Toast.LENGTH_LONG).show();
    }

    public void displayPurchase(){
        dm=new DataManager(act,1);
        if(dm.checkPurchaseCartNumber()>0) {
            int total=dm.getPurchaseTotal();
            showAlert("Your cart has "+dm.checkPurchaseCartNumber()+" items.Current Total is USD "+total);
        }else{
            showAlert("You have not added any item to your cart");
        }

    }

    public void updateCart(TextView cartstatus,TextView carttotal){
        dm=new DataManager(act,1);
        int rate=app.getInt("rate",100);
        if(dm.checkCartNumber()>0){
            double total=dm.getCartTotal()*rate;
            cartstatus.setText("Current cart has "+dm.checkCartNumber()+" items");
            carttotal.setText("KES "+total);
        }else{
            cartstatus.setText("Nothing in cart currently");
            carttotal.setText("KES 0");
        }

    }

    public void showAlert(String message){
        final Dialog dialog = new Dialog(act,null, message,null);
        dialog.show();
// Set accept click listenner
        dialog.setOnAcceptButtonClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                dialog.dismiss();
            }
        });
        ButtonFlat acceptButton = dialog.getButtonAccept();
        acceptButton.setText("OK");
    }


    public void showDetailedAlert(String title,String message,String rightbtntext,View.OnClickListener rightClick,String leftbtntext,View.OnClickListener leftClick){
try {
    Dialog dialog = new Dialog(act, title, message,leftbtntext);
    dialog.show();


    ButtonFlat acceptButton = dialog.getButtonAccept();
    acceptButton.setText(rightbtntext);


     if(leftbtntext!=null) {
         ButtonFlat cancelButton = dialog.getButtonCancel();
         cancelButton.setText(leftbtntext);
         dialog.setOnCancelButtonClickListener(leftClick);
     }

    dialog.setOnAcceptButtonClickListener(rightClick);




    }catch(NullPointerException e){
            showAlert("d");
        }

    }


    public void handlePhotos(RoundedImage img){
        this.rimg=img;
        final View.OnClickListener camera=new View.OnClickListener(){

            @Override
            public void onClick(View v) {
             takephoto(v);
            }
        };

        View.OnClickListener gallery=new View.OnClickListener(){

            @Override
            public void onClick(View v) {
              pickphoto(v);
            }
        };
        showDetailedAlert("CHOOSE METHOD", "", "CAMERA", camera, "OPEN GALLERY", gallery);
    }



    public void handlePhotos(ImageView img){
        this.img=img;
        final View.OnClickListener camera=new View.OnClickListener(){

            @Override
            public void onClick(View v) {
                takephoto(v);
            }
        };

        View.OnClickListener gallery=new View.OnClickListener(){

            @Override
            public void onClick(View v) {
                pickphoto(v);
            }
        };
        showDetailedAlert("CHOOSE METHOD","","CAMERA",camera,"OPEN GALLERY",gallery);
    }

    public void takephoto(View v){
        Intent takepicc=new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
        act.startActivityForResult(takepicc, 1);
    }

    public void pickphoto(View v){
        Intent takepicc=new Intent(Intent.ACTION_PICK, MediaStore.Images.Media.EXTERNAL_CONTENT_URI);
        act.startActivityForResult(Intent.createChooser(takepicc, "Choose a photo"), 0);
    }



    protected void onActivityResult(int requestCode,int resultCode,Intent data){
        if(resultCode==act.RESULT_OK){
            if(requestCode==1){
                //super.onActivityResult(requestCode, resultCode, data);
                bm=(Bitmap)data.getExtras().get("data");
                if(img!=null) {
                    img.setImageBitmap(bm);
                }
                if(rimg!=null) {
                    rimg.setImageBitmap(bm);
                }
                ByteArrayOutputStream stream = new ByteArrayOutputStream();
                bm.compress(Bitmap.CompressFormat.JPEG, 100, stream);
                byte [] byte_arr = stream.toByteArray();
                image_str = Base64.encodeBytes(byte_arr);
            }else{
                Uri selected=data.getData();
                temp=getPath(selected,act);
                BitmapFactory.Options boptions=new BitmapFactory.Options();
                bm=BitmapFactory.decodeFile(temp,boptions);
                if(img!=null) {
                    img.setImageBitmap(bm);
                }
                if(rimg!=null) {
                    rimg.setImageBitmap(bm);
                }
                ByteArrayOutputStream stream = new ByteArrayOutputStream();
                bm.compress(Bitmap.CompressFormat.JPEG, 100, stream);
                byte [] byte_arr = stream.toByteArray();
                image_str = Base64.encodeBytes(byte_arr);
            }
        }else{
           showToast("Could not get a photo to use");
        }
    }

    public String getImageString(){
        if(image_str!=null){
            return image_str;
        }
            return null;
    }

    public String getPath(Uri uri,Activity activity){
        String[] projection={MediaStore.MediaColumns.DATA};
        Cursor cursor=activity.managedQuery(uri, projection, null, null, null);
        int column_index=cursor.getColumnIndexOrThrow(MediaStore.MediaColumns.DATA);
        cursor.moveToFirst();
        return cursor.getString(column_index);
    }


}
