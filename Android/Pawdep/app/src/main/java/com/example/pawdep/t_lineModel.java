package com.example.pawdep;

import android.app.Application;
import android.os.AsyncTask;
import android.util.Log;

import java.util.List;

import androidx.annotation.NonNull;
import androidx.lifecycle.AndroidViewModel;
import androidx.lifecycle.LiveData;

public class t_lineModel extends AndroidViewModel {
    T_line.dao Dao;
    private List<T_line> all;

    public t_lineModel(@NonNull Application application) {
        super(application);
        DB db = DB.getInstance(application);
        Dao = db.t_linedao();

    }

    public List<T_line> getAll() {
        return Dao.getAll();
    }

    public void insert(T_line t) {
        new InsertAsyncTask(Dao).execute(t);

    }

    private class InsertAsyncTask extends AsyncTask<T_line, Void, Void> {
        private T_line.dao Dao;

        private InsertAsyncTask(T_line.dao Dao) {
            this.Dao = Dao;
        }

        @Override
        protected Void doInBackground(T_line... notes) {
            long l = Dao.Insert(notes[0]);
            Log.i("insert", String.valueOf(l));
            return null;
        }
    }
}
