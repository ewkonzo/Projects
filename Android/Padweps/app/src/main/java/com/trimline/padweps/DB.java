package com.trimline.padweps;


import android.arch.persistence.room.Database;
import android.arch.persistence.room.Room;
import android.arch.persistence.room.RoomDatabase;
import android.arch.persistence.room.TypeConverters;
import android.content.Context;

@Database(entities = {member.class,
        agent.class,
        Trans.class,
        t_line.class},
        version = 1,
        exportSchema = false)
@TypeConverters(TypesConverter.class)
public abstract class DB extends RoomDatabase {
    public abstract memberdao memberDao();
    public abstract agentdao agentdao();
    public  abstract transDao transactiondao();
    public  abstract t_lineDao t_linedao();
    private static DB instance;


    public static synchronized DB getInstance(Context context) {
        if (instance == null) {
            instance = Room.databaseBuilder(context.getApplicationContext(),
                    DB.class, "Pawdep")
                    .fallbackToDestructiveMigration()
                    .build();
        }
        return instance;
    }

}
