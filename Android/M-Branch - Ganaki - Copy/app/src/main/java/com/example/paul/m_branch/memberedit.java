package com.example.paul.m_branch;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import com.google.gson.Gson;

public class memberedit extends AppCompatActivity {
    TextView no, name;
    EditText phone, id;
    Button update, cancel;
    member f = null;
    DB db ;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_memberedit);
        String jsonMyObject = "";
        db = new DB(this);
        Bundle extras = getIntent().getExtras();
        if (extras != null) {
            jsonMyObject = extras.getString("member");
            f = new Gson().fromJson(jsonMyObject, member.class);
        }
        no = (TextView) findViewById(R.id.mno);
        name = (TextView) findViewById(R.id.mname);

        if (f != null) {
            no.setText(f.No);
            name.setText(f.Name);
        }

        phone = (EditText) findViewById(R.id.phone);
        id = (EditText) findViewById(R.id.idno);
        phone.setError(null);
        id.setError(null);

        update = (Button) findViewById(R.id.updatemember);
        cancel = (Button) findViewById(R.id.cancel);

        update.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (phone.getText().toString().equals("")) {
                    phone.setError("Phone should have a value");
                    phone.requestFocus();
                    return;
                }
                if (id.getText().toString().equals("")) {
                    id.setError("Id should have a value");
                    id.requestFocus();
                    return;
                }
                if (f != null) {
                    f.Phone_No = phone.getText().toString();
                    f.ID_No = id.getText().toString();
                    f.updated = true;
                    db.updatemember(f);
                    finish();
                }


            }
        });
cancel.setOnClickListener(new View.OnClickListener() {
    @Override
    public void onClick(View v) {
        finish();
    }
});
    }
}
