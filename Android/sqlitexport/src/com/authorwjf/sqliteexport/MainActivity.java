package com.authorwjf.sqliteexport;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.nio.channels.FileChannel;

import android.os.Bundle;
import android.os.Environment;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Toast;
import android.app.Activity;
import android.database.sqlite.SQLiteDatabase;

public class MainActivity extends Activity implements OnClickListener {

	private static final String SAMPLE_DB_NAME = "TrekBook";
	private static final String SAMPLE_TABLE_NAME = "Info";
	
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        findViewById(R.id.button1).setOnClickListener(this);
        findViewById(R.id.button2).setOnClickListener(this);
        findViewById(R.id.button3).setOnClickListener(this);
    }
	@Override
	public void onClick(View v) {
		switch(v.getId()) {
		case R.id.button1:
			deleteDB();
			break;
		case R.id.button2:
			exportDB();
			break;
		case R.id.button3:
			createDB();
			break;
		}
	}
	
	private void deleteDB(){
		boolean result = this.deleteDatabase(SAMPLE_DB_NAME);
		if (result==true) {
			 Toast.makeText(this, "DB Deleted!", Toast.LENGTH_LONG).show();
		} 
	}
	
	private void exportDB(){
		File sd = Environment.getExternalStorageDirectory();
        File data = Environment.getDataDirectory();
        FileChannel source=null;
        FileChannel destination=null;
        String currentDBPath = "/data/"+ "com.authorwjf.sqliteexport" +"/databases/"+SAMPLE_DB_NAME;
        String backupDBPath = SAMPLE_DB_NAME;
        File currentDB = new File(data, currentDBPath);
        File backupDB = new File(sd, backupDBPath);
        try {
            source = new FileInputStream(currentDB).getChannel();
            destination = new FileOutputStream(backupDB).getChannel();
            destination.transferFrom(source, 0, source.size());
            source.close();
            destination.close();
            Toast.makeText(this, "DB Exported!", Toast.LENGTH_LONG).show();
        } catch(IOException e) {
        	e.printStackTrace();
        }
	}
	
	private void createDB() {
		SQLiteDatabase sampleDB =  this.openOrCreateDatabase(SAMPLE_DB_NAME, MODE_PRIVATE, null);
		sampleDB.execSQL("CREATE TABLE IF NOT EXISTS " +
                SAMPLE_TABLE_NAME +
                " (LastName VARCHAR, FirstName VARCHAR," +
                " Rank VARCHAR);");
        sampleDB.execSQL("INSERT INTO " +
                SAMPLE_TABLE_NAME +
                " Values ('Kirk','James, T','Captain');");
        sampleDB.close();
        sampleDB.getPath();
        Toast.makeText(this, "DB Created @ "+sampleDB.getPath(), Toast.LENGTH_LONG).show(); 
	}

}
