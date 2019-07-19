package com.AmountKeyboardAdapter;

import android.content.Context;
import android.util.AttributeSet;
import android.view.View;
import android.widget.GridView;
import android.widget.RelativeLayout;

import com.example.demo.simplepaymentdemo.R;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

/**
 * Virtual amount keyboard
 */
public class VirtualKeyboardView extends RelativeLayout {
    public static final int KEY_POINT = 10;
    public static final int KEY_NUM0 = 11;
    public static final int KEY_OK = 12;
    public static final int KEY_NUM1 = 1;
    public static final int KEY_NUM2 = 2;
    public static final int KEY_NUM3 = 3;
    public static final int KEY_NUM4 = 4;
    public static final int KEY_NUM5 = 5;
    public static final int KEY_NUM6 = 6;
    public static final int KEY_NUM7 = 7;
    public static final int KEY_NUM8 = 8;
    public static final int KEY_NUM9 = 9;


    Context context;

    private GridView gridView;    //The layout of keyboard with GrideView is not really a keyboard, but the function of simulating keyboard

    private ArrayList<Map<String, String>> valueList;

    private RelativeLayout layoutBack;

    public VirtualKeyboardView(Context context) {
        this(context, null);
    }

    public VirtualKeyboardView(Context context, AttributeSet attrs) {
        super(context, attrs);

        this.context = context;

        View view = View.inflate(context, R.layout.layout_virtual_keyboard, null);

        valueList = new ArrayList<>();

        layoutBack = (RelativeLayout) view.findViewById(R.id.layoutBack);

        gridView = (GridView) view.findViewById(R.id.gv_keybord);

        initValueList();

        setupView();

        addView(view);      //Must be, or do not display controls
    }

    public RelativeLayout getLayoutBack() {
        return layoutBack;
    }

    public ArrayList<Map<String, String>> getValueList() {
        return valueList;
    }

    private void initValueList() {

        // The number that should be displayed on the initialization button
        for (int i = 1; i < 13; i++) {
            Map<String, String> map = new HashMap<>();
            if (i < 10) {
                map.put("name", String.valueOf(i));
            } else if (i == KEY_POINT) {
                map.put("name", ".");
            } else if (i == KEY_NUM0) {
                map.put("name", String.valueOf(0));
            } else if (i == KEY_OK) {
                map.put("name", "OK");
            }
            valueList.add(map);
        }
    }

    public static boolean isNumKey(int position) {
        switch (position) {
            case KEY_NUM0:
            case KEY_NUM1:
            case KEY_NUM2:
            case KEY_NUM3:
            case KEY_NUM4:
            case KEY_NUM5:
            case KEY_NUM6:
            case KEY_NUM7:
            case KEY_NUM8:
            case KEY_NUM9:
                return true;
            default:
                return false;
        }
    }

    public static int getNum(int position) {
        switch (position) {
            case KEY_NUM0:
                return 0;
            case KEY_NUM1:
                return 1;
            case KEY_NUM2:
                return 2;
            case KEY_NUM3:
                return 3;
            case KEY_NUM4:
                return 4;
            case KEY_NUM5:
                return 5;
            case KEY_NUM6:
                return 6;
            case KEY_NUM7:
                return 7;
            case KEY_NUM8:
                return 8;
            case KEY_NUM9:
                return 9;
            default:
                return 0;
        }
    }

    public GridView getGridView() {
        return gridView;
    }

    private void setupView() {

        KeyBoardAdapter keyBoardAdapter = new KeyBoardAdapter(context, valueList);
        gridView.setAdapter(keyBoardAdapter);
    }
}
