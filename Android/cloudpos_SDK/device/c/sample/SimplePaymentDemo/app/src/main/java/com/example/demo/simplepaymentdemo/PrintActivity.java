package com.example.demo.simplepaymentdemo;

import android.content.Context;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

import com.PrintUtil.PrinterBitmapUtil;
import com.PrintUtil.PrinterCommand;
import com.cloudpos.jniinterface.PrinterInterface;

import java.io.UnsupportedEncodingException;

import static com.cloudpos.jniinterface.PrinterInterface.begin;
import static com.cloudpos.jniinterface.PrinterInterface.end;

/**
 * Pay successful interface and print transaction credentials
 */
public class PrintActivity extends BaseActivity {

    Context mContext = this;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_paysuccessful);

        new Thread(print).start();//start Thread to Print operations

        Button btn = (Button) findViewById(R.id.Ok);
        btn.setOnClickListener(new View.OnClickListener() {// Button OK's Click Listener event
            //Click OK to jump to the first interface
            @Override
            public void onClick(View view) {
                PrinterInterface.close(); // close device
                Intent intent = new Intent(PrintActivity.this, SwipeCardActivity.class);
                startActivity(intent);//Jump to the first interface
            }
        });
    }

    private void writeLineBreak(int lineNumber) {
        // Execute print instructions
        write(PrinterCommand.getCmdEscDN(lineNumber));
    }

    private void write(final byte[] arryData) {
        //Print data manipulation. Data can be a string or an image.
        if (arryData == null) {
            PrinterInterface.write(null, 0);
        } else {
            PrinterInterface.write(arryData, arryData.length);
        }
    }

    @Override
    public void onBackPressed() {
        //Rewrite backspace key method
        PrinterInterface.close();//close device
        Intent intent = new Intent(PrintActivity.this, SwipeCardActivity.class);
        startActivity(intent);// start activity intent，Jump to the first interface
    }

    /**
     * Performing a printing operation, print transaction credentials content
     */
    private Runnable print = new Runnable() {
        @Override
        public void run() {
            int print = PrinterInterface.open();// open printer device
            if (print >= 0) {
                /* This is print bitmap*/
                //Logo (.bmp) can be chosen according to need
                Bitmap bitmap = BitmapFactory.decodeResource(mContext.getResources(),
                        R.drawable.titlelogo);//select print logo

                /*ThIs is print text ticket*/
                byte[] arryone = null;
                byte[] arrytwo = null;
                byte[] arrythree = null;
                byte[] arryfour = null;

                try {
                    

                    arryone = ("MERCHANT COPY:\n" +
                            "--------------------------------").getBytes("UTF-8");// print text firstline Ecodeing UTF-8
                    arrytwo = ("MERCHANT NAME:\n" +
                            "XXX XXXX XXXX CO.LTO\n" +
                            "MER:10237135411994\n" +
                            "TER:52878059\n" +
                            "--------------------------------").getBytes("UTF-8");//print text secondline
                    arrythree = ("ISSUER:XXXXBank\n" +
                            "CARD NO.:\n" +
                            "6228 45** **** ***0614/S\n" +
                            "EXP DATE:XXXX/XX\n" +
                            "TXN TYPE:\n" +
                            "SALE:\n" +
                            "BATCH NO: 100687\n" +
                            "INVOICE NO :002500\n" +
                            "TRACE NO :009404\n" +
                            "DATE:xxxx/xx/xx\n" +
                            "TIME:xx:xx:xx\n" +
                            "REFER NO :648965012342\n" +
                            "AMOUNT: \n" +
                            "\t$ 0.00\n" +
                            "OPERATOR NO :001\n" +
                            "Taxpayer code:371326198402097610\n" +
                            "Tax certificate number:320160607000243893\n" +
                            "Accounting organization code:13713260000\n\n" +
                            "REFERENCE:\n" +
                            "CARDHOLDER\n" +
                            "SIGNATURE:\n\n" +
                            "Please do not sign this test operation!\n").getBytes("UTF-8");//print text thirdline
                    arryfour = ("--------------------------------\n" +
                            "I CONFIRM THAT THE ABOVE TRANSACTION AGREED TO BE CREDITED TO THE CREDIT CARD ACCOUNT.\n" +
                            "--------------------------------").getBytes("UTF-8");// print text forthline

                } catch (UnsupportedEncodingException e) {
                    e.printStackTrace();
                }
                begin();//begin
                PrinterBitmapUtil.printBitmap(bitmap, 0, 0, true);// print logo(.bmp)
                // print line break
                writeLineBreak(2);
                write(arryone);
                // print line break
                writeLineBreak(2);
                write(arrytwo);
                // print line break
                writeLineBreak(2);
                // print text
                write(arrythree);
                // print line break
                writeLineBreak(2);
                write(arryfour);
                writeLineBreak(2);
                end();
            } else {
                Toast.makeText(PrintActivity.this, "Print failed please try again!", Toast.LENGTH_SHORT).show();// if print device open failed,show falied message
            }

            PrinterInterface.close();//close device
        }
    };
}

