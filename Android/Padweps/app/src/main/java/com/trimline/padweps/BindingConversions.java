package com.trimline.padweps;

import android.databinding.BindingAdapter;
import android.databinding.BindingConversion;
import android.databinding.InverseMethod;
import android.view.View;

import io.reactivex.annotations.Nullable;


public class BindingConversions {
    private static final String EMPTY_STRING = "";




    // XX to String
    @BindingConversion
    @InverseMethod("convertToInteger")
    public static String convertToString(@Nullable Integer d) {
        return  d != null ? d.toString() : EMPTY_STRING;
    }

    @BindingConversion
    @InverseMethod("convertToIntegerZeroIsEmpty")
    public static String convertToStringZeroIsEmpty(@Nullable Integer d) {
        return  d != null && d > 0 ? d.toString() : EMPTY_STRING;
    }


    @BindingConversion
    public static String convertToString(@Nullable Long d) {
        return  d != null? d.toString() : EMPTY_STRING;
    }


    @BindingConversion
    public static String convertToString(boolean d) {
        return  String.valueOf(d);
    }

    @BindingConversion
    @InverseMethod("convertToDouble")
    public static String convertToString(@Nullable Double d) {
        return  d != null? d.toString() : EMPTY_STRING;
    }

    @BindingConversion
    public static String convertToString(String s) {
        return  s != null ? s : EMPTY_STRING;
    }


    // XX to Integer
    @BindingConversion
    public static Integer convertToInteger(String d) {
        try {
            return Integer.parseInt(d);
        } catch (NumberFormatException e) {
            return 0;
        }
    }

    @BindingConversion
    public static Integer convertToIntegerZeroIsEmpty(String d) {
        return convertToInteger(d);
    }


    // XX to Double
    @BindingConversion
    @Nullable
    public static Double convertToDouble(@Nullable String d) {
        return d != null ? Double.parseDouble(d) : null;
    }




    @BindingAdapter("android:visibility")
    public static void setVisibility(View view, boolean visible) {
        view.setVisibility(visible ? View.VISIBLE : View.GONE);
    }


}
