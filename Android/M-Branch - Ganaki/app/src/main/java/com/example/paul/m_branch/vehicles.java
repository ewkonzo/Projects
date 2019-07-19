package com.example.paul.m_branch;

/**
 * Created by Paulo on 3/27/2017.
 */
import java.text.DecimalFormat;
import java.util.Date;
public class vehicles {
    public String Vehicle_Number;
    public int vehicle_type;
    public Double Daily_Contribution;
    public String Start_Date;
    public String Code;
    public String Id_Number;
    public double Arrears;
    public double Penalty;
    public double Daily_Welfare;
    public double Daily_Shares;
    public double Daily_Court_Bond;
    @Override
    public String toString() {
        return this.Code;
    }

    public static enum Vehicle_Type {


        _x0031_4_Seater("14 Seater"),


        _x0033_3_Seater("33 Seater"),


        _x0032_5_Seater("25 Seater"),


        _x0032_9_Seater("29 Seater"),


        _x0034_1_Seater("41 Seater"),


        _x0032_6_Seater("26 Seater"),


        _x0033_7_Seater("37 Seater");

        private String type;

        Vehicle_Type(String aState) {
            type = aState;
        }

        @Override
        public String toString() {
            return type;
        }
    }

}

