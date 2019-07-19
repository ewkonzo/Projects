
package com.wizarpos.paymenttransdemo;

import android.app.Activity;
import android.content.Context;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.TextView;

import com.cloudpos.DeviceException;
import com.cloudpos.POSTerminal;
import com.cloudpos.printer.Format;
import com.cloudpos.printer.PrinterDevice;
import com.wizarpos.paymenttransdemo.printer.PrintTag;
import com.wizarpos.paymenttransdemo.printer.PurchaseBillEntity;

public class PayResultPrintActivity extends Activity {
    TextView txtPayType;
    Button btnPrint;
    Button btnBack;
    int payType = -1;
    boolean isRun = false;
    private Context context = PayResultPrintActivity.this;
    PrinterDevice device = null;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_print);
        initParameters();
        initViews();
    }

    private void initParameters() {
        payType = getIntent().getIntExtra(MainActivity.PAY_TYPE, -1);
        device = (PrinterDevice)POSTerminal.getInstance(PayResultPrintActivity.this).getDevice("cloudpos.device.printer");
    }

    private void initViews() {
        txtPayType = (TextView) findViewById(R.id.txt_0);
        btnPrint = (Button) findViewById(R.id.btn_0);
        switch (payType) {
            case MainActivity.TYPE_CONTACTLESS: {
                txtPayType.append(context.getString(R.string.RFCard));
                break;
            }
            case MainActivity.TYPE_MSR: {
                txtPayType.append(context.getString(R.string.MSR));
                break;
            }
            case MainActivity.TYPE_IC: {
                txtPayType.append(context.getString(R.string.ICCard));
                break;
            }

            default:
                break;
        }
        btnPrint.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View v) {
                if (isRun) {
                    return;
                }
                WaitThread thread = new WaitThread();
                thread.start();
            }
        });
        btnBack = (Button) findViewById(R.id.btn_1);
        btnBack.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View v) {
                finish();
            }
        });
    }

    private class WaitThread extends Thread {

        @Override
        public void run() {
            try {
                device.open();
                // queryStatus
                int status = device.queryStatus();
                if (status == PrinterDevice.STATUS_OUT_OF_PAPER) {
                    Log.e("TAG", context.getString(R.string.NoPaper));
                    throw new DeviceException(DeviceException.GENERAL_EXCEPTION);
                }

                PurchaseBillEntity purchaseBill = new PurchaseBillEntity();
                setPurchaseBillEntity(purchaseBill);
                printBill(purchaseBill);
            } catch (DeviceException e) {
                e.printStackTrace();
            } finally {
                try {
                    device.close();
                } catch (DeviceException e) {
                    e.printStackTrace();
                }
            }
            isRun = false;
        }
    }
    
    private void setPurchaseBillEntity(PurchaseBillEntity purchaseBill) {
        purchaseBill.setMerchantName("REN MIN STORE");
        purchaseBill.setMerchantNo("800201020800201");
        purchaseBill.setTerminalNo("20063201");
        purchaseBill.setOperator("01");
        purchaseBill.setCardNumber("5359 18** **** 8888   MCC");
        purchaseBill.setIssNo("01021000");
        purchaseBill.setAcqNo("01031000");
        purchaseBill.setTxnType("SALE");
        purchaseBill.setExpDate("2006/12");
        purchaseBill.setBatchNo("000122");
        purchaseBill.setVoucherNo("105233");
        purchaseBill.setAuthNo("384928");
        purchaseBill.setDataTime("2005/01/31 19:20:18");
        purchaseBill.setRefNo("123456123456");
        purchaseBill.setAmout("RMB 1234.56");
        // purchaseBill.setTips("RMB 123.56");
        // purchaseBill.setTotal("RMB 1358.12");
        purchaseBill.setReference("DUPLICATD");
    }
    
    private void printBill(PurchaseBillEntity purchaseBill) throws DeviceException {
        Format format = new Format();
        format.setParameter("bold", "true");
        format.setParameter("size", "large");
        format.setParameter("align", "center");
        device.printlnText(format, PrintTag.PurchaseBillTag.PURCHASE_BILL_TITLE);
        format.clear();
        format = device.getDefaultParameters();
        device.printlnText(format, PrintTag.PurchaseBillTag.MERCHANT_NAME_TAG
                + purchaseBill.getMerchantName());
        device.printlnText(PrintTag.PurchaseBillTag.MERCHANT_NO_TAG
                + purchaseBill.getMerchantNo());
        device.printlnText(PrintTag.PurchaseBillTag.TERMINAL_NO_TAG
                + purchaseBill.getTerminalNo());
        device.printlnText(PrintTag.PurchaseBillTag.OPERATOR_TAG + purchaseBill.getOperator());
        device.printlnText(PrintTag.PurchaseBillTag.ISS_NO_TAG + purchaseBill.getIssNo());
        device.printlnText(PrintTag.PurchaseBillTag.ACQ_NO_TAG + purchaseBill.getAcqNo());
        device.printlnText(PrintTag.PurchaseBillTag.CARD_NUMBER_TAG
                + purchaseBill.getCardNumber());
        device.printlnText(PrintTag.PurchaseBillTag.TXN_TYPE_TAG + purchaseBill.getTxnType());
        device.printlnText(PrintTag.PurchaseBillTag.EXP_DATE_TAG + purchaseBill.getExpDate());
        device.printlnText(PrintTag.PurchaseBillTag.BATCH_NO_TAG + purchaseBill.getBatchNo());
        device.printlnText(PrintTag.PurchaseBillTag.VOUCHER_NO_TAG + purchaseBill.getVoucherNo());
        device.printlnText(PrintTag.PurchaseBillTag.AUTH_NO_TAG + purchaseBill.getAuthNo());
        device.printlnText(PrintTag.PurchaseBillTag.REF_NO_TAG + purchaseBill.getRefNo());
        device.printlnText(PrintTag.PurchaseBillTag.DATE_TIME_TAG + purchaseBill.getDataTime());
        device.printlnText(PrintTag.PurchaseBillTag.AMOUT_TAG + purchaseBill.getAmout());
        device.sendESCCommand("\n".getBytes());
        device.printlnText(PrintTag.PurchaseBillTag.REFERENCE_TAG + purchaseBill.getReference());
        device.sendESCCommand("\n".getBytes());
        device.printlnText(PrintTag.PurchaseBillTag.C_CARD_HOLDER_SIGNATURE_TAG);
        device.printlnText(PrintTag.PurchaseBillTag.E_CARD_HOLDER_SIGNATURE_TAG);
        device.sendESCCommand("\n\n".getBytes());
        device.printlnText(PrintTag.PurchaseBillTag.C_AGREE_TRADE_TAG);
        device.printlnText(PrintTag.PurchaseBillTag.E_AGREE_TRADE_TAG);
        device.sendESCCommand("\n\n".getBytes());
    }
}
