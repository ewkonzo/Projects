package com.example.pawdep;

import android.app.Application;


import java.util.ArrayList;
import java.util.List;

import androidx.annotation.NonNull;
import androidx.databinding.DataBindingUtil;
import androidx.lifecycle.AndroidViewModel;
import androidx.lifecycle.LiveData;

public class groupModel extends AndroidViewModel {
    Group.dao Dao;
    private LiveData<List<Group>> all;

    public groupModel(@NonNull Application application) {
        super(application);
        DB db = DB.getInstance(application);
        Dao = db.groupDao();
        all = Dao.getAll();
    }

    public LiveData<List<Group>> getAll() {
        return all;
    }




}
