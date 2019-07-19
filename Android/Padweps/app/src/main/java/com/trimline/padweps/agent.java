package com.trimline.padweps;


import android.arch.persistence.room.Entity;
import android.arch.persistence.room.PrimaryKey;
import android.support.annotation.NonNull;


/**
 * Created by Paul on 11-Dec-16.
 */

@Entity
public class agent {
    @PrimaryKey
    @NonNull
    public String Agent_Code;
    public String Name;
    public String Mobile_No;
    public static Status Status;
    public String Password;

    public enum Status {
        /// <remarks/>
        Pending,
        /// <remarks/>
        first_Approval,
        /// <remarks/>
        Approved,
        /// <remarks/>
        Rejected,
    }
}

