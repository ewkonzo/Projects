package com.example.pawdep;


import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProviders;
import android.content.Intent;
import androidx.databinding.DataBindingUtil;
import androidx.appcompat.app.AppCompatActivity;

import android.os.AsyncTask;
import android.os.Bundle;

import androidx.recyclerview.widget.ItemTouchHelper;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;
import androidx.work.ExistingPeriodicWorkPolicy;
import androidx.work.ExistingWorkPolicy;
import androidx.work.PeriodicWorkRequest;
import androidx.work.WorkManager;


import android.os.Parcelable;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.widget.Toast;

import com.example.pawdep.databinding.Grouplist;
import com.facebook.stetho.Stetho;
import com.google.gson.Gson;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.concurrent.TimeUnit;

import static androidx.work.PeriodicWorkRequest.MIN_PERIODIC_INTERVAL_MILLIS;


public class GroupTrans extends AppCompatActivity {
    public static final int ADD_TRANS = 1;
    public static final int Edit_TRANS = 1;

    transModel tmodel;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Stetho.initializeWithDefaults(this);
        tmodel = ViewModelProviders.of(this)
                .get(transModel.class);
        startwork();
        Grouplist b = DataBindingUtil.setContentView(this, R.layout.activity_main);
        RecyclerView recyclerView = findViewById(R.id.recycler_view);
        recyclerView.setLayoutManager(new LinearLayoutManager(this));
        recyclerView.setHasFixedSize(true);
        final Trans.adapter adapter = new Trans.adapter();
        recyclerView.setAdapter(adapter);
        tmodel.getAll().observe(this, new Observer<List<Trans>>() {
            @Override
            public void onChanged(@Nullable List<Trans> notes) {
                adapter.setTrans(notes);
            }
        });

        adapter.setOnItemClickListener(new com.example.pawdep.Trans.adapter.OnItemClickListener() {
            @Override
            public void onItemClick(Trans note) {
                Intent intent = new Intent(GroupTrans.this, addedittrans.class);
                intent.putExtra("Trans", note);
                startActivityForResult(intent, Edit_TRANS);
            }
        });
        new ItemTouchHelper(new ItemTouchHelper.SimpleCallback(0, ItemTouchHelper.LEFT | ItemTouchHelper.RIGHT) {

            @Override
            public boolean onMove(@NonNull RecyclerView recyclerView, @NonNull RecyclerView.ViewHolder viewHolder, @NonNull RecyclerView.ViewHolder target) {
                return false;
            }
            @Override
            public void onSwiped(@NonNull RecyclerView.ViewHolder viewHolder, int direction) {
                switch (direction) {
                    case ItemTouchHelper.RIGHT: {

                        Intent intent = new Intent(GroupTrans.this, transline.class);
                        intent.putExtra("list", adapter.getTransAt(viewHolder.getAdapterPosition()));
                        startActivityForResult(intent, Edit_TRANS);
                        adapter.notifyDataSetChanged();
                        break;
                    }
                    case ItemTouchHelper.LEFT: {
                        break;
                    }
                }
            }
        }).attachToRecyclerView(recyclerView);
    }
    void startwork() {

        PeriodicWorkRequest.Builder b = new PeriodicWorkRequest.Builder(worker.class, 15, TimeUnit.MINUTES);
        PeriodicWorkRequest myWork = b.build();

        WorkManager.getInstance().enqueueUniquePeriodicWork("updates", ExistingPeriodicWorkPolicy.REPLACE, myWork);

    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater menuInflater = getMenuInflater();
        menuInflater.inflate(R.menu.trans, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.newrans:
                add();
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

    private void add() {
        Date c = Calendar.getInstance().getTime();
        SimpleDateFormat df = new SimpleDateFormat("dd/MM/yy");
        String tDate = df.format(c);
        df = new SimpleDateFormat("ddMMyyHHmmss");
        String no = df.format(c);
        Intent intent = new Intent(GroupTrans.this, addedittrans.class);
        Trans t = new Trans();
        t.Date = tDate;
        t.Transaction_No = no;
        intent.putExtra("Trans", t);
        startActivityForResult(intent, ADD_TRANS);
    }

    private class opentranslines extends AsyncTask<String, Void, List<T_line>> {
        @Override
        protected List<T_line> doInBackground(String... notes) {
            return tmodel.tdao.Transctionline(notes[0]);
        }

        @Override
        protected void onPostExecute(List<T_line> res) {
            if (res.size() > 0) {
                String tlines = new Gson().toJson(res);
                Intent intent = new Intent(GroupTrans.this, transline.class);
                intent.putExtra("list", tlines);
                startActivityForResult(intent, Edit_TRANS);
            }


        }
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (requestCode == ADD_TRANS && resultCode == RESULT_OK) {
            Trans t = (Trans) data.getSerializableExtra("Trans");
            Toast.makeText(this, t.Group_Code, Toast.LENGTH_SHORT).show();
            tmodel.insert(t);


        }
    }
}
