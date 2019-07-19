package com.example.pawdep;

import android.app.DatePickerDialog;
import android.content.Intent;
import androidx.databinding.DataBindingUtil;
import androidx.appcompat.app.AppCompatActivity;
import androidx.lifecycle.ViewModel;
import androidx.lifecycle.ViewModelProviders;

import android.os.AsyncTask;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.Toast;


import com.example.pawdep.databinding.Additem;


import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;
import java.util.Locale;

public class addedittrans extends AppCompatActivity {
    Trans t;
    Additem b;
    EditText edittext;
    Calendar myCalendar;
    transModel tModel;
    private Group.dao Dao;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        // setContentView(R.layout.activity_addedittrans);
        b = DataBindingUtil.setContentView(this, R.layout.addedittran);

        groupModel gmodel = ViewModelProviders.of(this)
                .get(groupModel.class);
        tModel = ViewModelProviders.of(this).get(transModel.class);
        DB db = DB.getInstance(getApplicationContext());
        Dao = db.groupDao();
        new GetgroupsTask().execute();
        Intent i = getIntent();
        t = (Trans) i.getSerializableExtra("Trans");
        b.setTransaction(t);


        b.GroupCode.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void afterTextChanged(Editable editable) {
                if (!b.GroupCode.getText().toString().equals(""))
new GetnamesTask().execute(b.GroupCode.getText().toString());
            }
        });

        myCalendar = Calendar.getInstance();

        final DatePickerDialog.OnDateSetListener date = new DatePickerDialog.OnDateSetListener() {

            @Override
            public void onDateSet(DatePicker view, int year, int monthOfYear,
                                  int dayOfMonth) {
                // TODO Auto-generated method stub
                myCalendar.set(Calendar.YEAR, year);
                myCalendar.set(Calendar.MONTH, monthOfYear);
                myCalendar.set(Calendar.DAY_OF_MONTH, dayOfMonth);
                updateLabel();
            }

        };

        b.date.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                // TODO Auto-generated method stub
                new DatePickerDialog(addedittrans.this, date, myCalendar
                        .get(Calendar.YEAR), myCalendar.get(Calendar.MONTH),
                        myCalendar.get(Calendar.DAY_OF_MONTH)).show();
            }
        });
    }

    private void updateLabel() {
        String myFormat = "dd/MM/yy"; //In which you need put here
        SimpleDateFormat sdf = new SimpleDateFormat(myFormat, Locale.US);
        b.date.setText(sdf.format(myCalendar.getTime()));
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater menuInflater = getMenuInflater();
        menuInflater.inflate(R.menu.save, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.save:
                Trans d = b.getTransaction();
                Intent data = new Intent();
                data.putExtra("Trans", d);
                setResult(RESULT_OK, data);
                finish();
                return true;
            case R.id.List:
                Trans dd = b.getTransaction();
                tModel.insert(dd);
                Intent intent = new Intent(addedittrans.this, transline.class);
                intent.putExtra("list",  dd);
                startActivityForResult(intent,0);

                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

    private class GetgroupsTask extends AsyncTask<Void, Void, List<Group>> {
        @Override
        protected List<Group> doInBackground(Void... notes) {
            List<Group> l = Dao.Groups();

            return l;
        }

        @Override
        protected void onPostExecute(List<Group> res) {

            if (res.size() != 0) {
                Group.Groupsadapter adapter = new Group.Groupsadapter(addedittrans.this, R.layout.groupnames, res);
                b.GroupCode.setAdapter(adapter);

            }
        }
    }
    private class GetnamesTask extends AsyncTask<String, Void, String> {

       @Override
        protected String doInBackground(String... notes) {
         Log.i("gn",notes[0]);
            String l = Dao.groupname(notes[0]);

            return l;
        }

        @Override
        protected void onPostExecute(String res) {

            if (res != null) {
                b.groupname.setText(res);

            }
        }
    }
}
