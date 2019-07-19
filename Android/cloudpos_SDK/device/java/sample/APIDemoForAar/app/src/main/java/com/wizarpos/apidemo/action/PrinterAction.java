
package com.wizarpos.apidemo.action;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;

import com.cloudpos.DeviceException;
import com.cloudpos.POSTerminal;
import com.cloudpos.printer.Format;
import com.cloudpos.printer.PrinterDevice;
import com.wizarpos.apidemoforunionpaycloudpossdk.R;
import com.wizarpos.mvc.base.ActionCallback;

import java.util.Map;

public class PrinterAction extends ActionModel {

    private PrinterDevice device = null;

    @Override
    protected void doBefore(Map<String, Object> param, ActionCallback callback) {
        super.doBefore(param, callback);
        if (device == null) {
            device = (PrinterDevice) POSTerminal.getInstance(mContext)
                    .getDevice("cloudpos.device.printer");
        }
    }

    public void open(Map<String, Object> param, ActionCallback callback) {
        try {
            device.open();
            sendSuccessLog(mContext.getString(R.string.operation_succeed));
        } catch (DeviceException e) {
            e.printStackTrace();
            sendFailedLog(mContext.getString(R.string.operation_failed));
        }
    }

    public void printText(Map<String, Object> param, ActionCallback callback) {
        try {
//            device.printText("This is a test\n");
            Format format = new Format();
            format.setParameter(Format.FORMAT_FONT_SIZE,Format.FORMAT_FONT_SIZE_SMALL );
            device.printText(format, "This is a test\n");
            device.printText(format, "This is a test\n");
            sendSuccessLog(mContext.getString(R.string.operation_succeed));
        } catch (DeviceException e) {
            e.printStackTrace();
            sendFailedLog(mContext.getString(R.string.operation_failed));
        }
    }

    public void sendESCCommand(Map<String, Object> param, ActionCallback callback) {
        byte[] command = new byte[] {
                (byte) 0x12, (byte) 0x54
        };
        try {
            device.sendESCCommand(command);
            sendSuccessLog(mContext.getString(R.string.operation_succeed));
        } catch (DeviceException e) {
            e.printStackTrace();
            sendFailedLog(mContext.getString(R.string.operation_failed));
        }
    }

    public void queryStatus(Map<String, Object> param, ActionCallback callback) {
        try {
            int status = device.queryStatus();
            sendSuccessLog(mContext.getString(R.string.operation_succeed)
                    + " Status: "
                    + (status == PrinterDevice.STATUS_OUT_OF_PAPER ? "out of paper"
                            : "paper exists"));
        } catch (DeviceException e) {
            e.printStackTrace();
            sendFailedLog(mContext.getString(R.string.operation_failed));
        }
    }
    
    public void cutPaper(Map<String, Object> param, ActionCallback callback) {
        try {
            device.cutPaper();
            sendSuccessLog(mContext.getString(R.string.operation_succeed));
        } catch (DeviceException e) {
            e.printStackTrace();
            sendFailedLog(mContext.getString(R.string.operation_failed));
        }
    }
    
    public void printBitmap(Map<String, Object> param, ActionCallback callback) {
        Bitmap bitmap = BitmapFactory.decodeResource(mContext.getResources(),
                R.drawable.printer_barcode_low);
        try {
            device.printBitmap(bitmap);
            sendSuccessLog(mContext.getString(R.string.operation_succeed));
        } catch (DeviceException e) {
            e.printStackTrace();
            sendFailedLog(mContext.getString(R.string.operation_failed));
        }
    }
    
    public void printBarcode(Map<String, Object> param, ActionCallback callback) {
        try {
            Format format = new Format();
            format.setParameter("HRI-location", "DOWN");
            //0, 01234567896
            //1, "04310000526"
            //
            device.printBarcode(format, PrinterDevice.BARCODE_CODE128, "01234567896");
            device.printText("\n\n\n");
            sendSuccessLog(mContext.getString(R.string.operation_succeed));
        } catch (DeviceException e) {
            e.printStackTrace();
            sendFailedLog(mContext.getString(R.string.operation_failed));
        }
    }

    public void cancelRequest(Map<String, Object> param, ActionCallback callback) {
        try {
            device.cancelRequest();
            sendSuccessLog(mContext.getString(R.string.operation_succeed));
        } catch (DeviceException e) {
            e.printStackTrace();
            sendFailedLog(mContext.getString(R.string.operation_failed));
        }
    }

    public void close(Map<String, Object> param, ActionCallback callback) {
        try {
            device.close();
            sendSuccessLog(mContext.getString(R.string.operation_succeed));
        } catch (DeviceException e) {
            e.printStackTrace();
            sendFailedLog(mContext.getString(R.string.operation_failed));
        }
    }
}
