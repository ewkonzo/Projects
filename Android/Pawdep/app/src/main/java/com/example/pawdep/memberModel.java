package com.example.pawdep;

import android.app.Application;
import android.os.AsyncTask;
import android.util.Log;

import java.util.List;

import androidx.annotation.NonNull;
import androidx.lifecycle.AndroidViewModel;
import androidx.lifecycle.LiveData;

public class memberModel extends AndroidViewModel {
    Member.dao Dao;
    private LiveData<List<Member>> all;

    public memberModel(@NonNull Application application) {
        super(application);
        DB db = DB.getInstance(application);

        Dao = db.memberDao();
        all = Dao.getAll();
    }

    public LiveData<List<Member>> getAll() {
        return all;
    }

    public void insert(Member t) {


    }
}
