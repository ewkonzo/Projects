package elegance.hasoft.com.elegance;

import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Resources;
import android.graphics.Color;
import android.graphics.Typeface;
import android.os.Bundle;
import android.support.v4.widget.SwipeRefreshLayout;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarActivity;
import android.support.v7.widget.Toolbar;
import android.text.Html;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.BaseAdapter;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.ScrollView;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.HashMap;

import floatt.FloatingActionButton;


public class Notes extends ActionBarActivity {
    Toolbar toolbar;
    ListView listView;
    ActionBar ab;
    String userid,usertoken,usercategory,type,itemm;
    String [] menu,items;
    Resources res;
    AppBasics basic;
    NetDetector cd;
    Boolean netpresent=false;
    ServerCalls sc;
    SharedPreferences app;
    ArrayList<HashMap<String,String>> trendlist;
    ServiceHandler mServiceHandler;
    Constants con;
    DataManager dm;
    private SwipeRefreshLayout swipeContainer;
    ScrollView scrollView;
    FloatingActionButton done,addnew;
    Bundle extras;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_notes);
        toolbar=(Toolbar)findViewById(R.id.toolbar);
        toolbar.setBackgroundResource(R.color.orange);
        setSupportActionBar(toolbar);
        ab=getSupportActionBar();
        ab.setTitle(Html.fromHtml("<font color='white'>Notes</font>"));
        ab.setDisplayHomeAsUpEnabled(true);
        basic=new AppBasics(this);
        dm=new DataManager(this,1);
        extras=getIntent().getExtras();
        listView=(ListView)findViewById(R.id.listnotes);
        scrollView=(ScrollView)findViewById(R.id.scrollView1);
        listView.setVisibility(View.GONE);
        trendlist=new ArrayList<HashMap<String,String>>();
        swipeContainer = (SwipeRefreshLayout) findViewById(R.id.swipeContainer);
        swipeContainer.setOnRefreshListener(new SwipeRefreshLayout.OnRefreshListener() {

            @Override

            public void onRefresh() {
                mynotes();
                // Your code to refresh the list here.

                // Make sure you call swipeContainer.setRefreshing(false)

                // once the network request has completed successfully.

            }

        });


        addnew=(FloatingActionButton)findViewById(R.id.addnote);
        addnew.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
              newnote();

            }
        });
        addnew.setVisibility(View.VISIBLE);
        addnew.setBackgroundResource(R.color.orange);

        done=(FloatingActionButton)findViewById(R.id.save);
        done.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                addnote();

            }
        });
        done.setBackgroundResource(R.color.orange);

        if(extras==null) {
            mynotes();
        }else{

        }

    }

    public void addnote(){
        EditText title=(EditText)findViewById(R.id.notetitle);
        EditText des=(EditText)findViewById(R.id.notdes);

        String nott=title.getText().toString();
        String notdes=des.getText().toString();
        if(nott.trim().isEmpty()||notdes.trim().isEmpty()){
            basic.showAlert("Please add a full note");
        }else{
            long time=System.currentTimeMillis();
            long s=dm.insertNotes(nott,notdes,time+"","1","pending",time+"");
                title.setText("");
                des.setText("");
                basic.showToast("Note successfully added");
        }

    }

    public void assignnote(){
        EditText title=(EditText)findViewById(R.id.notetitle);
        EditText des=(EditText)findViewById(R.id.notdes);

        String nott=title.getText().toString();
        String notdes=des.getText().toString();
        if(nott.trim().isEmpty()||notdes.trim().isEmpty()){
            basic.showAlert("Please add a full note");
        }else {
            Intent c = new Intent(Notes.this, Reports.class);
            c.putExtra("type", "assign");
            c.putExtra("title", nott);
            c.putExtra("des", notdes);
            startActivity(c);
        }

    }

    public void mynotes(){
        listView.setVisibility(View.VISIBLE);
        scrollView.setVisibility(View.GONE);
        swipeContainer.setRefreshing(false);
        addnew.setVisibility(View.VISIBLE);
        done.setVisibility(View.GONE);
        if(dm.checkNotes()>0) {
            trendlist = dm.getNotes();
            listView.setAdapter(gridadapter);
            listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                @Override
                public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                    Intent v=new Intent(Notes.this,Browse.class);
                    v.putExtra("title",trendlist.get(+position).get("title"));
                    v.putExtra("notdes",trendlist.get(+position).get("des"));
                    v.putExtra("id",trendlist.get(+position).get("noteid"));
                    v.putExtra("status",trendlist.get(+position).get("status"));
                    v.putExtra("time",trendlist.get(+position).get("time"));
                    v.putExtra("type","notes");
                    startActivity(v);
                }
            });
        }else{
            basic.showAlert("No notes at the moment.Click + to add one");
        }
    }







    public void newnote(){
        listView.setVisibility(View.GONE);
        scrollView.setVisibility(View.VISIBLE);
        addnew.setVisibility(View.GONE);
        done.setVisibility(View.VISIBLE);
        EditText title=(EditText)findViewById(R.id.notetitle);
        EditText des=(EditText)findViewById(R.id.notdes);
        title.setText("");
        des.setText("");
    }


    BaseAdapter gridadapter=new BaseAdapter() {
        @Override
        public int getCount() {
            return trendlist.size();
        }

        @Override
        public Object getItem(int position) {
            return null;
        }

        @Override
        public long getItemId(int position) {
            return 0;
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            LayoutInflater li=Notes.this.getLayoutInflater();
            convertView= li.inflate(R.layout.notes_layout,null);

            String name=trendlist.get(+position).get("title");
            TextView t=(TextView)convertView.findViewById(R.id.itemname);
            t.setTypeface(Typeface.DEFAULT_BOLD);
            TextView tdes=(TextView)convertView.findViewById(R.id.itemdes);
            RoundedLetterView s=(RoundedLetterView)convertView.findViewById(R.id.imageView);
            s.setTitleText((trendlist.get(+position).get("title").substring(0, 1).toUpperCase()));
            t.setText(name);
            if(trendlist.get(+position).get("status").equalsIgnoreCase("notdone")){
                t.setTextColor(getResources().getColor(R.color.blue));
            }else {
                t.setTextColor(Color.BLACK);
            }
            tdes.setText(trendlist.get(+position).get("des"));
            return convertView;
        }
    };

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_notes, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_save) {
            addnote();
            return true;
        }

        if (id == R.id.action_newnotes) {
            newnote();
            return true;
        }
        if (id == R.id.action_mynotes) {
            mynotes();
            return true;
        }
        if (id == R.id.action_assign) {
            assignnote();
            return true;
        }
        if (id == R.id.action_save) {
            addnote();
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
