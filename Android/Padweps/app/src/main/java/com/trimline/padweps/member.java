package com.trimline.padweps;


import android.arch.persistence.room.Entity;
import android.arch.persistence.room.Ignore;
import android.arch.persistence.room.PrimaryKey;
import android.support.annotation.NonNull;

/**
 * Created by Paul on 11-Dec-16.
 */

@Entity(tableName = "Members")
public class member {
    @Ignore
    public String Key;
    @PrimaryKey
   @NonNull
    public String No;
    public String Name ;
    public String Phone_No;
    public String Group_No;
    public String DOB;
    public String ID_No;
    public static Status Status;
    public static Account_Category Account_Category ;

    public enum Status {

        /// <remarks/>
        Active,

        /// <remarks/>
        Non_Active,

        /// <remarks/>
        Blocked,

        /// <remarks/>
        Dormant,

        /// <remarks/>
        Re_instated,

        /// <remarks/>
        Deceased,

        /// <remarks/>
        Withdrawal,

        /// <remarks/>
        Retired,

        /// <remarks/>
        Termination,

        /// <remarks/>
        Resigned,

        /// <remarks/>
        Ex_Company,

        /// <remarks/>
        Casuals,

        /// <remarks/>
        Family_Member,

        /// <remarks/>
        Defaulter,

        /// <remarks/>
        Closed,

        /// <remarks/>
        Suspended,
    }
    public enum Account_Category {

        /// <remarks/>
        Group,

        /// <remarks/>
        Individual,

        /// <remarks/>
        Non_Member,
    }
}
