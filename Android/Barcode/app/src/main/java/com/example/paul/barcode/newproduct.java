package com.example.paul.barcode;

import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.DialogFragment;
import android.app.TimePickerDialog;
import android.content.DialogInterface;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.text.InputType;
import android.text.format.DateFormat;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TimePicker;
import android.widget.Toast;

import com.google.zxing.BarcodeFormat;
import com.google.zxing.EncodeHintType;
import com.google.zxing.MultiFormatWriter;
import com.google.zxing.WriterException;
import com.google.zxing.common.BitMatrix;

import java.sql.Date;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.EnumMap;
import java.util.Locale;
import java.util.Map;


public class newproduct extends ActionBarActivity implements View.OnClickListener {
   Database db;
    EditText ProductCode;
    EditText ProductName;
    EditText size;
    EditText Manufacturer;
    EditText source;
    EditText ManufactureDateTime;
    EditText ExpiryDateTime;
    private DatePickerDialog mandialog;
    private DatePickerDialog expirydialog;
    private SimpleDateFormat dateFormatter;
Button save;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_newproduct);
        findViewsById();
        dateFormatter = new SimpleDateFormat("dd-MM-yyyy", Locale.US);
db = new Database(this);
        setDateTimeField();
if (MainActivity.currentProduct!=null)
{
    ProductCode.setText(MainActivity.currentProduct.ProductCode);
    ProductName.setText(MainActivity.currentProduct.ProductName);
    size.setText(MainActivity.currentProduct.size);
    source.setText(MainActivity.currentProduct.source);
    Manufacturer.setText(MainActivity.currentProduct.Manufacturer);
    ManufactureDateTime.setText(String.valueOf(MainActivity.currentProduct.ManufactureDateTime));
    ExpiryDateTime.setText(String.valueOf( MainActivity.currentProduct.ExpiryDateTime));

}
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_newproduct, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    private void findViewsById() {

        ProductCode = (EditText) findViewById(R.id.txtcode);
        ProductName = (EditText) findViewById(R.id.txtproductname);
        size = (EditText) findViewById(R.id.txtproductsize);
        Manufacturer = (EditText) findViewById(R.id.txtmanufacturer);
        source = (EditText) findViewById(R.id.txtsource);
        ManufactureDateTime = (EditText) findViewById(R.id.mandate);
        ManufactureDateTime.setInputType(InputType.TYPE_NULL);
        ExpiryDateTime = (EditText) findViewById(R.id.Expirydate);
        ExpiryDateTime.setInputType(InputType.TYPE_NULL);
        save = (Button)findViewById(R.id.save);
        save.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                    Saveitems();
            }
        });
    }

    private void setDateTimeField() {
        ManufactureDateTime.setOnClickListener(this);
        ExpiryDateTime.setOnClickListener(this);
        Calendar newCalendar = Calendar.getInstance();
        mandialog = new DatePickerDialog(this, new DatePickerDialog.OnDateSetListener() {
            public void onDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth) {
                Calendar newDate = Calendar.getInstance();
                newDate.set(year, monthOfYear, dayOfMonth);
                ManufactureDateTime.setText(dateFormatter.format(newDate.getTime()));
            }

        }, newCalendar.get(Calendar.YEAR), newCalendar.get(Calendar.MONTH), newCalendar.get(Calendar.DAY_OF_MONTH));
        expirydialog = new DatePickerDialog(this, new DatePickerDialog.OnDateSetListener() {

            public void onDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth) {
                Calendar newDate = Calendar.getInstance();
                newDate.set(year, monthOfYear, dayOfMonth);
                ExpiryDateTime.setText(dateFormatter.format(newDate.getTime()));
            }
        }, newCalendar.get(Calendar.YEAR), newCalendar.get(Calendar.MONTH), newCalendar.get(Calendar.DAY_OF_MONTH));
    }

    @Override
    public void onClick(View v) {
        if (v == ManufactureDateTime) {
            mandialog.show();
        } else if (v == ExpiryDateTime) {
            expirydialog.show();
        }
    }
    void Saveitems(){
        ProductName.setError(null);
        ProductCode.setError(null);
        size.setError(null);
        source.setError(null);


        if (ProductCode.getText().toString().equals("")){
            ProductCode.setError("Product code is required");
            ProductCode.requestFocus();
            return;
        }
        if (ProductName.getText().toString().equals("")) {
            ProductName.setError("Product name is required");
            ProductName.requestFocus();
            return   ;
        }
        Cursor c = Products.getProductbycode(db,ProductCode.getText().toString());
        if (c.getCount()>0){
            ProductCode.setError("Product with this code already exist");
            ProductCode.requestFocus();
            return;}

         c = Products.getProductbyname(db, ProductName.getText().toString());
        if (c.getCount()>0){
            ProductName.setError("Product with this Name already exist");
           ProductName.requestFocus();
            return;
        }
        Products p = new Products();
        p.ProductCode= ProductCode.getText().toString();
        p.ProductName= ProductName.getText().toString();
        p.size= size.getText().toString();
        p.source = source.getText().toString();
        //p.ManufactureDateTime=(long)(Date)ManufactureDateTime.getText().toString();
        Products.Addproducts(db,p);
        Toast.makeText(getApplicationContext(),"Record successfully saved",Toast.LENGTH_LONG).show();


    }
    void barcode(){


        String barcode_data = "123456";

        // barcode image
        Bitmap bitmap = null;
        ImageView iv = (ImageView)findViewById(R.id.testbarcode);

        try {

            bitmap = encodeAsBitmap(barcode_data, BarcodeFormat.CODE_128, 600, 300);
            iv.setImageBitmap(bitmap);

        } catch (WriterException e) {
            e.printStackTrace();
        }


    }

    /**************************************************************
     * getting from com.google.zxing.client.android.encode.QRCodeEncoder
     *
     * See the sites below
     * http://code.google.com/p/zxing/
     * http://code.google.com/p/zxing/source/browse/trunk/android/src/com/google/zxing/client/android/encode/EncodeActivity.java
     * http://code.google.com/p/zxing/source/browse/trunk/android/src/com/google/zxing/client/android/encode/QRCodeEncoder.java
     */

    private static final int WHITE = 0xFFFFFFFF;
    private static final int BLACK = 0xFF000000;

    Bitmap encodeAsBitmap(String contents, BarcodeFormat format, int img_width, int img_height) throws WriterException {
        String contentsToEncode = contents;
        if (contentsToEncode == null) {
            return null;
        }
        Map<EncodeHintType, Object> hints = null;
        String encoding = guessAppropriateEncoding(contentsToEncode);
        if (encoding != null) {
            hints = new EnumMap<EncodeHintType, Object>(EncodeHintType.class);
            hints.put(EncodeHintType.CHARACTER_SET, encoding);
        }
        MultiFormatWriter writer = new MultiFormatWriter();
        BitMatrix result;
        try {
            result = writer.encode(contentsToEncode, format, img_width, img_height, hints);
        } catch (IllegalArgumentException iae) {
            // Unsupported format
            return null;
        }
        int width = result.getWidth();
        int height = result.getHeight();
        int[] pixels = new int[width * height];
        for (int y = 0; y < height; y++) {
            int offset = y * width;
            for (int x = 0; x < width; x++) {
                pixels[offset + x] = result.get(x, y) ? BLACK : WHITE;
            }
        }

        Bitmap bitmap = Bitmap.createBitmap(width, height,
                Bitmap.Config.ARGB_8888);
        bitmap.setPixels(pixels, 0, width, 0, 0, width, height);
        return bitmap;
    }

    private static String guessAppropriateEncoding(CharSequence contents) {
        // Very crude at the moment
        for (int i = 0; i < contents.length(); i++) {
            if (contents.charAt(i) > 0xFF) {
                return "UTF-8";
            }
        }
        return null;
    }

}