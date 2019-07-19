package com.example.pawdep;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.databinding.DataBindingUtil;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProviders;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;


import com.example.pawdep.databinding.Tline;

import java.util.List;

public class transline extends AppCompatActivity {
t_lineModel tmodel;
RecyclerView recyclerView;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_transline);
        tmodel = ViewModelProviders.of(this)
                .get(t_lineModel.class);
        Intent i = getIntent();
        Trans t = (Trans) i.getSerializableExtra("list");


        Tline b = DataBindingUtil.setContentView(this, R.layout.activity_transline);

        recyclerView = findViewById(R.id.transline);
        recyclerView.setLayoutManager(new LinearLayoutManager(this));
       recyclerView.setHasFixedSize(false);
Log.i("Passed",t.Transaction_No);
        new getadapterdata().execute(t.Transaction_No);


    }

    private class getadapterdata extends AsyncTask<String, Void, List<T_line>> {

        @Override
        protected List<T_line> doInBackground(String... notes) {

            return   tmodel.Dao.Transctionline(notes[0]);
        }

        @Override
        protected void onPostExecute(List<T_line> res) {
            if(res.size()>0) {
                final T_line.adapter adapter = new T_line.adapter();
                adapter.sett_line(res);
                recyclerView.setAdapter(adapter);
            }



        }
    }
}
