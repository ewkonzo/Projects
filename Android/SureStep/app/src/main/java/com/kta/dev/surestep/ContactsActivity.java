package com.kta.dev.surestep;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by G on 4/19/2016.
 */
public class ContactsActivity extends AppCompatActivity {
    EditText mName, mTelephoneNumber, mNationalId;
    String mContactName, mContactTelephoneNumber, mContactIdNumber;
    List<Contact> mList;
    ListView mContactsListView;
    ContactsAdapter mAdapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_contacts);

        mName = (EditText) findViewById(R.id.name);
        mTelephoneNumber = (EditText) findViewById(R.id.telephoneNumber);
        mNationalId = (EditText) findViewById(R.id.nationalIdNumber);
        Button saveBtn = (Button) findViewById(R.id.saveBtn);

        mList = new ArrayList<>();
        mContactsListView = (ListView) findViewById(R.id.contactsList);



        if (saveBtn != null) {

            saveBtn.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {

                    if (mName != null || mTelephoneNumber != null || mNationalId != null) {
                        assert mName != null;
                        mContactName = mName.getText().toString();
                        assert mTelephoneNumber != null;
                        mContactTelephoneNumber = mTelephoneNumber.getText().toString();
                        assert mNationalId != null;
                        mContactIdNumber = mNationalId.getText().toString();
                    }

                    Contact contact = new Contact();

                    contact.setName(mContactName);
                    contact.setTelephoneNumber(mContactTelephoneNumber);
                    contact.setNationalId(mContactIdNumber);

                    mList.add(contact);

                    mAdapter = new ContactsAdapter(ContactsActivity.this, mList);
                    mAdapter.notifyDataSetChanged();
                    mContactsListView.setAdapter(mAdapter);

                }
            });
        }

    }
}
