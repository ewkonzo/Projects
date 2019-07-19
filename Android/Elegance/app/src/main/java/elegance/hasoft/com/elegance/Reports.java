package elegance.hasoft.com.elegance;

import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Resources;
import android.graphics.Color;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.widget.SwipeRefreshLayout;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarActivity;
import android.support.v7.widget.Toolbar;
import android.text.Html;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.EditText;
import android.widget.GridView;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;

import org.achartengine.ChartFactory;
import org.achartengine.GraphicalView;
import org.achartengine.model.CategorySeries;
import org.achartengine.renderer.DefaultRenderer;
import org.achartengine.renderer.SimpleSeriesRenderer;
import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;

import java.net.URLEncoder;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;


public class Reports extends ActionBarActivity {
    Toolbar toolbar;
    GridView grid;
    ActionBar ab;
    String userid,usertoken,usercategory,itemm,query,title,message;
    String [] menu,items;
    AppBasics basic;
    NetDetector cd;
    Boolean netpresent=false;
    ServerCalls sc;
    SharedPreferences app;
    ServiceHandler mServiceHandler;
    Constants con;
    EditText name;
    ListView list;
    Bundle extras;
    String item,subitem;
    DataManager dm;
    TextView cartstatus;
    TextView carttotal;
    ArrayList<HashMap<String,String>> trendlist;
    String type,token,url,mServiceCallResponse;
    JSONHandler jh;
    com.gc.materialdesign.widgets.ProgressDialog pd2;
    final String userid_con="user_id";
    final String token_con="token";
    AsyncTask<String, String, String> task;
    private SwipeRefreshLayout swipeContainer;
    LinearLayout r;
    ArrayList<String> months;
    String [] months_list;
    Resources res;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_reports);
        toolbar=(Toolbar)findViewById(R.id.toolbar);
        toolbar.setBackgroundResource(R.color.orange);
        setSupportActionBar(toolbar);
        ab=getSupportActionBar();
        jh=new JSONHandler(this);
        con=new Constants();
        app=getSharedPreferences("settings", MODE_PRIVATE);
        if(app.contains("userid")){
            userid=app.getString("userid",null);
            token=app.getString("userkey",null);
        }else{
            userid="jnvfnv";
            token="gvhb";
        }
        ab.setDisplayHomeAsUpEnabled(true);
        r=(LinearLayout)findViewById(R.id.r);
        usercategory=app.getString("usercategory",null);
        basic=new AppBasics(this);
        cd=new NetDetector(this);
        sc=new ServerCalls(this);
        list=(ListView)findViewById(R.id.listSearch);
        extras=getIntent().getExtras();
        type=extras.getString("type");
        trendlist=new ArrayList<>();
        dm=new DataManager(this,1);
        swipeContainer = (SwipeRefreshLayout) findViewById(R.id.swipeContainer);
        swipeContainer.setOnRefreshListener(new SwipeRefreshLayout.OnRefreshListener() {

            @Override

            public void onRefresh() {
                setup();
                // Your code to refresh the list here.

                // Make sure you call swipeContainer.setRefreshing(false)

                // once the network request has completed successfully.

            }

        });
        res=getResources();
        months=new ArrayList<>();
        months_list=res.getStringArray(R.array.months);
        for (String aMonths_list : months_list) {
            months.add(aMonths_list);
        }
        setup();
    }

    public void setup(){
        if(type.equalsIgnoreCase("reports")){
            swipeContainer.setRefreshing(false);
            String type=extras.getString("reporttype");
            if(type!=null){
                ab.setTitle(Html.fromHtml("<font color='white'>Reports > "+type+"</font>"));
                r.setVisibility(View.GONE);
                ab.setDisplayHomeAsUpEnabled(false);
                if(type.equalsIgnoreCase("Expenses")){
                    sc.getreportexpenses(list);
                }
                if(type.equalsIgnoreCase("Sales")){
                    sc.getreportsales(list);
                }
                if(type.equalsIgnoreCase("Purchases")){
                    sc.getreportpurchases(list);
                }

            }else{
                ab.setTitle(Html.fromHtml("<font color='white'>Reports</font>"));
                loadreports("all", "");


            }
        }

        if(type.equalsIgnoreCase("users")){
            ab.setTitle(Html.fromHtml("<font color='white'>Users</font>"));
            loadusers();
            swipeContainer.setRefreshing(false);
        }
        if(type.equalsIgnoreCase("assign")){
            ab.setTitle(Html.fromHtml("<font color='white'>Assign A Note</font>"));
            title=extras.getString("title");
            message=extras.getString("des");
            assignnote();
            swipeContainer.setRefreshing(false);
        }

    }

    public void loadreports(String type,String period){
        netpresent=cd.isConnectingToInternet();
        if(netpresent) {
            loadreports(type, period, list);

        }else{
            basic.showToast("Check your internet connection");
        }
    }


    public void loadusers(){
        netpresent=cd.isConnectingToInternet();
        if(netpresent) {
            getusers();
        }else{
            basic.showToast("Check your internet connection");
        }
    }


    public void assignnote(){
        netpresent=cd.isConnectingToInternet();
        if(netpresent) {
            getusers();
        }else{
            basic.showToast("Check your internet connection");
        }
    }



    public void loadmonths(){

    }





    public void loadcustomers(){
        netpresent=cd.isConnectingToInternet();
        if(netpresent) {
            sc.gettransactions(list);
        }else{
            basic.showToast("Check your internet connection");
        }
    }





    public void getusers(

    ){


        task = new AsyncTask<String, String,String>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                pd2=new com.gc.materialdesign.widgets.ProgressDialog(Reports.this,"Loading...");
                pd2.setCancelable(false);
                pd2.show();
            }

            @Override
            protected String doInBackground(String... params) {
                url = con.URL+"usr/fetch";
                mServiceHandler = new ServiceHandler();
                List<NameValuePair> pairs = new ArrayList<NameValuePair>();
                pairs.add(new BasicNameValuePair(userid_con, URLEncoder.encode(userid)));
                pairs.add(new BasicNameValuePair(token_con, URLEncoder.encode(token)));
                mServiceCallResponse = mServiceHandler.makeServiceCall(url,ServiceHandler.POST,pairs);
                return mServiceCallResponse;
            }

            @Override
            protected void onPostExecute(String s) {
                pd2.dismiss();
                if(type.equalsIgnoreCase("users")) {
                    process(s);
                }

                if(type.equalsIgnoreCase("assign")) {
                    assignuser(s);
                }


            }
        };
        task.execute();
    }


    public void process(String s){
        trendlist=jh.handleUsers(s);
        UserAdapter ua=new UserAdapter(Reports.this,trendlist);
        list.setAdapter(ua);
        list.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Intent c=new Intent(Reports.this,Browse.class);
                c.putExtra("type","user");
                c.putExtra("id",trendlist.get(+position).get("id"));
                c.putExtra("name",trendlist.get(+position).get("name"));
                c.putExtra("email",trendlist.get(+position).get("email"));
                c.putExtra("phonenumber",trendlist.get(+position).get("phonenumber"));
                c.putExtra("category",trendlist.get(+position).get("category"));
                startActivity(c);
            }
        });

    }

    public void assignuser(String s){
        trendlist=jh.handleUsers(s);
        UserAdapter ua=new UserAdapter(Reports.this,trendlist);
        list.setAdapter(ua);
        list.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                String userid= trendlist.get(+position).get("id");
                String name= trendlist.get(+position).get("name");
                sc.assignnotes(userid, title, message);
                long time=System.currentTimeMillis();
                long s=dm.insertNotes(title,message,time+"",name,"pending",time+"");

            }
        });

    }



    public void setupchart(ArrayList<HashMap<String,String>> list) {
        CategorySeries mSeries = new CategorySeries("");
        GraphicalView mChartView=null;
        DefaultRenderer mRenderer = new DefaultRenderer();
        int size=list.size();
        if(size>0) {
            int[] COLORS = new int[]{Color.GREEN, Color.BLUE, Color.MAGENTA, Color.WHITE};


            mRenderer.setStartAngle(90);
            mRenderer.setChartTitleTextSize(20);
            mRenderer.setZoomButtonsVisible(false);
            if (mChartView == null) {
                mChartView = ChartFactory.getPieChartView(this, mSeries, mRenderer);
                mRenderer.setClickEnabled(true);
                mRenderer.setSelectableBuffer(10);
                r.addView(mChartView, new LinearLayout.LayoutParams(LinearLayout.LayoutParams.FILL_PARENT,
                        LinearLayout.LayoutParams.FILL_PARENT));
            } else {
                mChartView.repaint();
            }

            for (int i = 0; i < 4; i++) {
                String value = trendlist.get(i).get("name");
                double val = Double.parseDouble(value);
                String name = null;
                if (i == 0) {
                    name = "Sales";
                }
                if (i == 1) {
                    name = "Purchases";
                }
                if (i == 2) {
                    name = "Expenses";
                }
                if (i == 3) {
                    name = "Profit";
                }


                mSeries.add(name, val);
                SimpleSeriesRenderer renderer = new SimpleSeriesRenderer();
                renderer.setColor(COLORS[(mSeries.getItemCount() - 1) % COLORS.length]);
                mRenderer.addSeriesRenderer(renderer);
                if (mChartView != null)
                    mChartView.repaint();
            }
        }else{
            basic.showToast("Nothing to show in pie chart");
        }
    }

    public void fillPieChart(ArrayList<HashMap<String,String>> list){



        CategorySeries mSeries = new CategorySeries("");


    }



    public void loadreports(final String type,final String month,final ListView list){
        task = new AsyncTask<String, String, String>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                pd2=new com.gc.materialdesign.widgets.ProgressDialog(Reports.this,"Loading...");
                pd2.setCancelable(false);
                pd2.show();
            }

            @Override
            protected String doInBackground(String... params) {
                url = con.URL+"general/reports";
                mServiceHandler = new ServiceHandler();
                List<NameValuePair> pairs = new ArrayList<NameValuePair>();
                pairs.add(new BasicNameValuePair(userid_con, URLEncoder.encode(userid)));
                pairs.add(new BasicNameValuePair(token_con, URLEncoder.encode(token)));
                pairs.add(new BasicNameValuePair("type", URLEncoder.encode(type)));
                pairs.add(new BasicNameValuePair("period", URLEncoder.encode(month)));
                mServiceCallResponse = mServiceHandler.makeServiceCall(url,ServiceHandler.POST,pairs);
                return mServiceCallResponse;
            }

            @Override
            protected void onPostExecute(String s) {
                pd2.dismiss();
                trendlist=new ArrayList<HashMap<String,String>>();
                trendlist=jh.handleReports(s);
                setupchart(trendlist);
                ReportAdapt ra=new ReportAdapt(Reports.this,trendlist);
                list.setAdapter(ra);
                list.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                    @Override
                    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                        if(position==0){
                            Intent c=new Intent(Reports.this,Reports.class);
                            c.putExtra("type","reports");
                            c.putExtra("reporttype","Sales");
                            startActivity(c);
                        }

                        if(position==1){
                            Intent c=new Intent(Reports.this,Reports.class);
                            c.putExtra("type","reports");
                            c.putExtra("reporttype","Purchases");
                            startActivity(c);

                        }

                        if(position==2){
                            Intent c=new Intent(Reports.this,Reports.class);
                            c.putExtra("type","reports");
                            c.putExtra("reporttype","Expenses");
                            startActivity(c);

                        }

                        if(position==3){
                            Intent c=new Intent(Reports.this,Reports.class);
                            c.putExtra("type","reports");
                            c.putExtra("reporttype","Profit");
                            startActivity(c);

                        }
                    }
                });

            }
        };
        task.execute();
    }




    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        if(type.equalsIgnoreCase("reports")) {
            String type=extras.getString("reporttype");
            if(type==null) {
                getMenuInflater().inflate(R.menu.menu_reports, menu);
            }
        }
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_today) {
            loadreports("today","");
            return true;
        }

        if (id == R.id.action_thisweek) {
            loadreports("thisweek","");
            return true;
        }

        if (id == R.id.action_month) {
            loadreports("month","");
            return true;
        }

        if (id == R.id.action_year) {
            loadreports("year","");
            return true;
        }

        if (id == R.id.action_all) {
            loadreports("all","");
            return true;
        }


        return super.onOptionsItemSelected(item);
    }
}
