package com.wizarpos.signature.demo;

import android.app.Activity;
import android.content.Context;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.util.Log;

import com.cloudpos.DeviceException;
import com.cloudpos.OperationListener;
import com.cloudpos.OperationResult;
import com.cloudpos.POSTerminal;
import com.cloudpos.TimeConstants;
import com.cloudpos.printer.PrinterDevice;
import com.cloudpos.signature.SignatureDevice;
import com.cloudpos.signature.SignatureOperationResult;

public class MainActivity extends Activity {
    Context context = this;
    private SignatureDevice signatureDevice;
    private PrinterDevice printerDevice;

    @Override
    protected void onCreate(final Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        signatureDevice =
                (SignatureDevice) POSTerminal.getInstance(context).getDevice("cloudpos.device.signature");
        printerDevice =
                (PrinterDevice) POSTerminal.getInstance(context).getDevice("cloudpos.device.printer");

        new Thread(OpenDevice).start();
    }

    private void signatureAndPrint() {
        try {
            OperationListener operationListener = new OperationListener() {

                @Override
                public void handleResult(OperationResult operationResult) {
                    if (operationResult.getResultCode() == OperationResult.SUCCESS) {

                        SignatureOperationResult signatureOperationResult = (SignatureOperationResult) operationResult;

                        int leg = signatureOperationResult.getSignatureLength();//get SignatureLength

                        byte[] Data = signatureOperationResult.getSignatureCompressData();//get SignatureCompressData

                        Bitmap bitmap = signatureOperationResult.getSignature();//get Signature bitmap
                        // Start Printing
                        try {
                            printerDevice.printText("\n--------Signature Image--------\n");
                            printerDevice.printBitmap(bitmap);
                            printerDevice.printText("-------------------------------\n\n\n");
                        } catch (DeviceException e) {
                            e.printStackTrace();
                        }
                        //Close Devices
                        try {
                            signatureDevice.close();
                            printerDevice.close();
                        } catch (DeviceException e) {
                            e.printStackTrace();
                        }
                        //Finish Activity
                        finish();
                    } else {
                        Log.d("TAG", "sign failed or user cancel");
                        try {
                            signatureDevice.close();
                            printerDevice.close();
                        } catch (DeviceException e) {
                            e.printStackTrace();
                        }
                        finish();
                    }
                }
            };
            signatureDevice.listenSignature("sign", operationListener, TimeConstants.FOREVER);
        } catch (DeviceException e) {
            e.printStackTrace();
            Log.d("TAG", "Open failed");
        }
    }

    private Runnable OpenDevice = new Runnable() {
        @Override
        public void run() {
            try {
                //Open Devices
                printerDevice.open();
                signatureDevice.open();
            } catch (DeviceException e) {
                e.printStackTrace();
            }
            //Execution method
            signatureAndPrint();
        }
    };


}
