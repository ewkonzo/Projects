package com.example.pawdep;

import androidx.room.Database;
import androidx.room.Room;
import androidx.room.RoomDatabase;
import androidx.room.TypeConverters;
import androidx.room.migration.Migration;
import androidx.sqlite.db.SupportSQLiteDatabase;

import android.content.Context;

@Database(entities = {Member.class,
        Agent.class,
        Trans.class,
        T_line.class,
        Group.class,
        Loan.class,
        Advance.class,
        Advance_issue.class,
        PW_Transactions.class
},
        version = 5,
        exportSchema = false)
@TypeConverters(TypesConverter.class)
public abstract class DB extends RoomDatabase {
    public abstract Member.dao memberDao();

    public abstract Group.dao groupDao();

    public abstract Agent.dao agentdao();

    public abstract Trans.dao transactiondao();

    public abstract T_line.dao t_linedao();

    public abstract Loan.dao loandao();

    public abstract Advance.dao adao();

    public abstract PW_Transactions.dao ptadao();

    public  abstract  Advance_issue.dao advissuedao();

    private static DB instance;


    public static synchronized DB getInstance(Context context) {
        if (instance == null) {
            instance = Room.databaseBuilder(context.getApplicationContext(),
                    DB.class, "Pawdep")
                    .fallbackToDestructiveMigration()
                    //.addMigrations(MIGRATION_2_3)
                    .build();
        }
        return instance;
    }


    static final Migration MIGRATION_2_3 = new Migration(3, 4) {
        @Override
        public void migrate(SupportSQLiteDatabase database) {
            //  database.execSQL("Drop Table `t_line line` ");
        }
    };
}
