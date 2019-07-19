package com.trimline.padweps;

import android.arch.persistence.room.TypeConverter;

import java.sql.Date;



public class TypesConverter {

    @TypeConverter
    public static Date toDate(Long value) {
        return value == null ? null : new Date(value);
    }

    @TypeConverter
    public static Long toLong(Date value) {
        return value == null ? null : value.getTime();
    }

    @TypeConverter
    public static int fromstatus(member.Status s) {
        return s.ordinal();
    }

    @TypeConverter
    public static member.Status tostatus(int s) {
        return member.Status.values()[s];
    }

    @TypeConverter
    public static int fromacccategory(member.Account_Category s) {
        return s.ordinal();
    }

    @TypeConverter
    public static member.Account_Category toacccategory(int s) {
        return member.Account_Category.values()[s];
    }@TypeConverter
    public static int fromstatus(agent.Status s) {
        return s.ordinal();
    }

    @TypeConverter
    public static agent.Status toagentstatus(int s) {
        return agent.Status.values()[s];
    }
    public static int fromstatus(Trans.Status s) {
        return s.ordinal();
    }

    @TypeConverter
    public static Trans.Status totransstatus(int s) {
        return Trans.Status.values()[s];
    }



}
