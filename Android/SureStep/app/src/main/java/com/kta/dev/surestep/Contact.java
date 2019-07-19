package com.kta.dev.surestep;

/**
 * Created by G on 4/19/2016.
 */
public class Contact {

    private String mName;
    private String mTelephoneNumber;
    private String mNationalId;

    public Contact() {

    }

    public Contact(String name, String telephoneNumber, String nationalId) {
        mName = name;
        mTelephoneNumber = telephoneNumber;
        mNationalId = nationalId;
    }

    public String getName() {
        return mName;
    }

    public void setName(String name) {
        mName = name;
    }

    public String getTelephoneNumber() {
        return mTelephoneNumber;
    }

    public void setTelephoneNumber(String telephoneNumber) {
        mTelephoneNumber = telephoneNumber;
    }

    public String getNationalId() {
        return mNationalId;
    }

    public void setNationalId(String nationalId) {
        mNationalId = nationalId;
    }
}
