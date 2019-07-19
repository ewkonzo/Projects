

package com.example.demo.simplepaymentdemo;

import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.support.v7.app.AlertDialog;
import android.text.Editable;
import android.text.InputType;
import android.view.Gravity;
import android.view.View;
import android.view.WindowManager;
import android.widget.AdapterView;
import android.widget.EditText;
import android.widget.GridView;
import android.widget.Toast;

import com.AmountKeyboardAdapter.VirtualKeyboardView;
import com.cloudpos.jniinterface.PINPadInterface;
import com.errorcodetools.ErrorCodeTransfer;
import com.errorcodetools.HardwareErrorCode;
import com.errorcodetools.SoftwareErrorCode;

import java.lang.reflect.Method;
import java.util.ArrayList;
import java.util.Map;

import static com.util.StringUtility.ByteArrayToString;

public class AmountKeyBoardActivity extends BaseActivity {

    private VirtualKeyboardView virtualKeyboardView;

    private GridView gridView;

    private ArrayList<Map<String, String>> valueList;

    private EditText textAmount;

    private static final int MSGID_SHOW_MESSAGE = 0;

    private static final int USERCANCEL_SHOW_MESSAGE = 1;

    private static final int TIMEOUT_SHOW_MESSAGE = -1;

    private Handler handler;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_keybord);

        initView();

        valueList = virtualKeyboardView.getValueList();

        handler = new Handler(new Handler.Callback() {

            @Override
            public boolean handleMessage(Message msg) {

                switch (msg.what) {
                    case MSGID_SHOW_MESSAGE:

                        Toast.makeText(AmountKeyBoardActivity.this, "PINPad open failed！ Please Try Again", Toast.LENGTH_LONG).show();

                        break;
                    case USERCANCEL_SHOW_MESSAGE:

                        Toast.makeText(AmountKeyBoardActivity.this, "User Cancelled! Please Try Again", Toast.LENGTH_LONG).show();

                        break;
                    case TIMEOUT_SHOW_MESSAGE:

                        Toast.makeText(AmountKeyBoardActivity.this, "Timeout! Please Try Again", Toast.LENGTH_LONG).show();

                    default:
                        break;
                }
                return false;
            }
        });

    }

    /**
     * Digital keyboard display animation
     */
    private void initView() {
        int position = 0;
        textAmount = (EditText) findViewById(R.id.textAmount);
        textAmount.setGravity(Gravity.RIGHT);
        textAmount.setSelection(position);
        // Setting does not call the system keyboard
        if (android.os.Build.VERSION.SDK_INT <= 10) {
            textAmount.setInputType(InputType.TYPE_NULL);
        } else {
            this.getWindow().setSoftInputMode(
                    WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_HIDDEN);
            try {
                Class<EditText> cls = EditText.class;
                Method setShowSoftInputOnFocus;
                setShowSoftInputOnFocus = cls.getMethod("setShowSoftInputOnFocus",
                        boolean.class);
                setShowSoftInputOnFocus.setAccessible(true);
                setShowSoftInputOnFocus.invoke(textAmount, false);
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
        virtualKeyboardView = (VirtualKeyboardView) findViewById(R.id.virtualKeyboardView);
        virtualKeyboardView.getLayoutBack().setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                virtualKeyboardView.setVisibility(View.GONE);
            }
        });
        gridView = virtualKeyboardView.getGridView();
        gridView.setOnItemClickListener(onItemClickListener);
    }

    private AdapterView.OnItemClickListener onItemClickListener = new AdapterView.OnItemClickListener() {
        /**
         * Click amount keyboard monitor event
         */
        @Override
        public void onItemClick(AdapterView<?> adapterView, View view, int position, long l) {
            if (VirtualKeyboardView.isNumKey(position + 1)) {    //click 0~9

                String amount = textAmount.getText().toString().trim();
                amount = amount + valueList.get(position).get("name");

                textAmount.setText(amount);
                Editable ea = textAmount.getText();
                textAmount.setSelection(ea.length());
            } else {

                if (position == (VirtualKeyboardView.KEY_POINT - 1)) {      //click point(.)
                    String amount = textAmount.getText().toString().trim();
                    if (!amount.contains(".")) {
                        amount = amount + valueList.get(position).get("name");
                        textAmount.setText(amount);
                        Editable ea = textAmount.getText();
                        textAmount.setSelection(ea.length());
                    }
                }
                if (position == (VirtualKeyboardView.KEY_OK - 1)) {//click OK

                    showDialogAndCalculatePinpadBlock();
                }
            }
        }

    };

    /**
     * Select a group of master key and session key encryption operations before
     *
     * @param masterKeyID
     * @param userKeyID
     */
    private void selectKey(final int masterKeyID, final int userKeyID) {

        PINPadInterface.selectKey(PINPadInterface.KEY_TYPE_MASTER, masterKeyID, userKeyID, 0);

    }

    /**
     * Show the amount of confirmation Dialog and CalculatePinpadBlock
     */
    private void showDialogAndCalculatePinpadBlock() {
        final AlertDialog.Builder normalDialog =
                new AlertDialog.Builder(AmountKeyBoardActivity.this);
        String amount = textAmount.getText().toString();
        double AMOUNT = Double.valueOf(amount).doubleValue();//Get the amount of data in EditText
        normalDialog.setMessage("Please confirm! " + "Amount:  " + AMOUNT);//The information displayed on dialog
        normalDialog.setCancelable(false);//Settings cannot be cancel
        normalDialog.setPositiveButton("Yes",
                new DialogInterface.OnClickListener() {
                    //The click event of the YES button
                    @Override
                    public void onClick(final DialogInterface dialog, final int which) {
                        //You can't do PINPAD operations directly in the UI thread, so you need to operate in another thread
                        new Thread() {
                            @Override
                            public void run() {
                                int masterKeyID = 0;
                                int userKeyID;
                                int calculatePINBlockResult = 0;
                                int hardWareErrorCode = 0;
                                int softWareErrorCode = 0;
                                byte[] arryPINblock = new byte[18];
                                String PINBlockResult = null;
                                int result = PINPadInterface.open();//open PINPad
                                if (result >= 0) {
                                    userKeyID = 0;
                                    selectKey(masterKeyID, userKeyID);// selectkey before calculatetePINBlock
                                    String pan = "1234567890123456789";//19 bit card number
                                    calculatePINBlockResult = PINPadInterface.calculatePINBlock(pan.getBytes(), pan.length(),
                                            arryPINblock, -1, 0);
                                    PINBlockResult = ByteArrayToString(arryPINblock, calculatePINBlockResult); //get PINBlockData

                                    hardWareErrorCode = ErrorCodeTransfer.transfer2HardwareErrorCode(calculatePINBlockResult);//get hardware error code

                                    softWareErrorCode = ErrorCodeTransfer.transfer2SoftwareErrorCode(calculatePINBlockResult);// get software error code
                                } else {
                                    handler.obtainMessage(MSGID_SHOW_MESSAGE).sendToTarget();//Open failed pass message
                                }
                                if (calculatePINBlockResult >= 0) {
                                    PINPadInterface.close();
                                    Intent intent = new Intent(AmountKeyBoardActivity.this, Communication_Activity.class);// Communication_activity jumping
                                    startActivity(intent);
                                } else if (hardWareErrorCode == HardwareErrorCode.USER_CANCEL) { //PINPad "User_Cancel" is belong HardwareErrorCode(0x01)
                                    PINPadInterface.close();//close device
                                    handler.obtainMessage(USERCANCEL_SHOW_MESSAGE).sendToTarget();
                                } else if (softWareErrorCode == SoftwareErrorCode.ETIMEDOUT) { //PINPad "Timeout" is belong SoftwareError(110)
                                    PINPadInterface.close();//close device
                                    handler.obtainMessage(TIMEOUT_SHOW_MESSAGE).sendToTarget();
                                }
                                // For details, please refer to the document,SoftwareError please refer to app/errorcodetools/SoftwareErrorCode
                            }
                        }.start();
                    }
                });
        normalDialog.setNegativeButton("Cancel",
                new DialogInterface.OnClickListener() {
                    //The click event of the Cancel button
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        return;
                    }
                });
        normalDialog.show();//show amount confirm dialog
    }

    @Override
    public void onBackPressed() {
        //Rewrite backspace key method
        Intent intent = new Intent(AmountKeyBoardActivity.this, SwipeCardActivity.class);
        startActivity(intent);
    }

}

