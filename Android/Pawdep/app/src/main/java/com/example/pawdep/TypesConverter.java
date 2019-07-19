package com.example.pawdep;

import androidx.room.TypeConverter;


import java.sql.Date;

public class TypesConverter {

    @TypeConverter
    public static int fromstatus(Member.status s) {
        if (s!=null)
        return s.ordinal();
        else
            return 0;
    }

    @TypeConverter
    public static Member.status tostatus(int s) {
        return Member.status.values()[s];
    }

    @TypeConverter
    public static int fromstatus(PW_Transactions.Transaction_Type s) {
        if (s!=null)
            return s.ordinal();
        else
            return 0;
    }

    @TypeConverter
    public static PW_Transactions.Transaction_Type totransstatus(int s) {
        return PW_Transactions.Transaction_Type.values()[s];
    }
    @TypeConverter
    public static int fromcategory(Member.account_Category s) {
        if (s!=null)
        return s.ordinal();
        else
            return 0;
    }

    @TypeConverter
    public static Member.account_Category tocategory(int s) {
        return Member.account_Category.values()[s];
    }

    @TypeConverter
    public static int fromagentstatus(Agent.Status s) {
        if (s!=null)
        return s.ordinal();
        else
            return 0;
    }

    @TypeConverter
    public static Agent.Status toagentstatus(int s) {
        return Agent.Status.values()[s];
    }
//Date
    @TypeConverter
    public Date fromTimestamp(Long value) {
        return value == null ? null : new Date(value);
    }

    @TypeConverter
    public Long dateToTimestamp(Date date) {
        if (date == null) {
            return null;
        } else {
            return date.getTime();
        }
    }

}
