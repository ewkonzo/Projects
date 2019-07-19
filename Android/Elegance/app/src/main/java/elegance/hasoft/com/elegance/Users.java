package elegance.hasoft.com.elegance;

import android.os.Bundle;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import com.nineoldandroids.animation.ObjectAnimator;

import floatt.FloatingActionButton;

public class Users extends ActionBarActivity {
    Toolbar toolbar;
    ListView listView;
    ActionBar ab;
    View mContainerHeader;
    FloatingActionButton mFab;
    AppBasics basic;
    ObjectAnimator fade;
    final static String[] DUMMY_DATA = {
            "France",
            "Sweden",
            "Germany",
            "USA",
            "Portugal",
            "The Netherlands",
            "Belgium",
            "Spain",
            "United Kingdom",
            "Mexico",
            "Finland",
            "Norway",
            "Italy",
            "Ireland",
            "Brazil",
            "Japan"
    };
    G_extendedTB g_extendedTB;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_users);
        mFab = (FloatingActionButton)findViewById(R.id.proceed);
        toolbar=(Toolbar)findViewById(R.id.toolbar);
        listView=(ListView)findViewById(R.id.listview);
        setSupportActionBar(toolbar);
        basic=new AppBasics(this);
        g_extendedTB=new G_extendedTB(this,toolbar,listView,mFab,true);
        g_extendedTB.addTitle("Elegance");
        g_extendedTB.addSubTitle("Laughing my ass out....crazy");
        listView.setAdapter(new ArrayAdapter<>(this,
                android.R.layout.simple_list_item_1,
                DUMMY_DATA));

    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_users, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
