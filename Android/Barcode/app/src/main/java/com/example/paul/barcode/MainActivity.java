package com.example.paul.barcode;

import android.content.Intent;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.support.v7.app.ActionBarActivity;
import android.util.Log;
import android.view.ContextMenu;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.GridView;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.TextView;
import android.widget.Toast;

import com.google.zxing.BarcodeFormat;
import com.google.zxing.EncodeHintType;
import com.google.zxing.MultiFormatWriter;
import com.google.zxing.WriterException;
import com.google.zxing.common.BitMatrix;

import java.sql.Date;
import java.util.ArrayList;
import java.util.EnumMap;
import java.util.List;
import java.util.Map;

public class MainActivity extends ActionBarActivity {
    GridView grid;
    Database db;
    private ArrayList<String> list;
    private ArrayAdapter<String> adapter;
    public  static Products currentProduct;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        db = new Database(this);
        Products p = new Products();
        p.ProductCode = "001";
        p.ProductName = "Product1";
        p.source = "Man1";
        p.size = "10ml";
        p.Manufacturer = "Man1";

        //Products.Addproducts(db, p);
        listclick();
        loadlistview();
    }
    public void listclick()
    {
        ListView l = (ListView)findViewById(R.id.productlist);
        registerForContextMenu(l);
        l.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Log.e("Paul", String.valueOf(id));
                view.setSelected(true);
                Cursor c = Products.getProduct(db, (int) id);
                if (c.moveToFirst()) {
                    currentProduct = (Products.getProductobject(db, (int) id));
                    Toast.makeText(getApplicationContext(), "Long press for Menu", Toast.LENGTH_LONG).show();
                }
            }
        });
        l.setOnItemLongClickListener(new AdapterView.OnItemLongClickListener() {
            @Override
            public boolean onItemLongClick(AdapterView<?> parent, View view, int position, long id) {
                Log.e("long", String.valueOf(id));
                view.setSelected(true);
                Cursor c = Products.getProduct(db, (int) id);
                if (c.moveToFirst()) {
                    currentProduct = (Products.getProductobject(db, (int) id));
                }
                return false;
            }
        });

    }
public  void loadlistview()
{
    Cursor c = Products.allProducts(db);
    startManagingCursor(c);

    String[] s= new String[]{Products.colProductCode,Products.colProductName, Products.colsize, Products.colsource};
    int[] p = new int[]{R.id.txtcode,R.id.txtproductname,R.id.txtsize,R.id.txtsource};
    SimpleCursorAdapter simpleCursorAdapter = new SimpleCursorAdapter(
this,
     R.layout.productlist,
            c,
            s,
            p
    );
    ListView l = (ListView)findViewById(R.id.productlist);
    l.setAdapter(simpleCursorAdapter);




}
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }
    @Override
    public void onCreateContextMenu(ContextMenu menu, View v,
                                    ContextMenu.ContextMenuInfo menuInfo) {
        if (v.getId()==R.id.productlist) {
            AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo)menuInfo;
            menu.setHeaderTitle("Menu");
            String[] menuItems = getResources().getStringArray(R.array.menu);
            for (int i = 0; i<menuItems.length; i++) {
                menu.add(Menu.NONE, i, i, menuItems[i]);
            }
        }
    }

    @Override
    public boolean onContextItemSelected(MenuItem item) {
        AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo)item.getMenuInfo();
        int menuItemIndex = item.getItemId();
        String[] menuItems = getResources().getStringArray(R.array.menu);
        String menuItemName = menuItems[menuItemIndex];
//        <item>add</item>
//        <item>edit</item>
//        <item>view barcode</item>
        if (menuItemName.equals("view barcode")){
            Intent i = new Intent(this,barcodeview.class);
            startActivity(i);
        }
        if (menuItemName.equals("edit")) {
            Intent i = new Intent(this, newproduct.class);
            startActivity(i);
        }
        if (menuItemName.equals("add")) {
            currentProduct=null ;
            Intent i = new Intent(this, newproduct.class);
            startActivity(i);
        }
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
            currentProduct=null ;
            Intent intent = new Intent(getApplicationContext(),newproduct.class);
            startActivity(intent);
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
    void barcode(){
        String barcode_data = "123456";
        Bitmap bitmap = null;
        ImageView iv = new ImageView(this);
        try {
            bitmap = encodeAsBitmap(barcode_data, BarcodeFormat.EAN_13, 600, 300);
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
