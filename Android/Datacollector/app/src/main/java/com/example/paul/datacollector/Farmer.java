package com.example.paul.datacollector;

/**
 * Created by Paul on 26-Aug-16.
 */
public class Farmer {
    public String Key;

    /// <remarks/>
    public String No;
    public String Name;
    public String Phone_No;
    public  int Creditor_Type ;
    public  String routes ;
    public double Cummulative=0.0;
    public String Transpoter;
    public double Cummulative_Collected ;
    @Override
    public String toString() {
        return this.Name;
    }
public enum Creditor_Type {

    /// <remarks/>
    Farmer,

    /// <remarks/>
    Supplier,

    /// <remarks/>
    Transporter,

    /// <remarks/>
    Others,
}

}
