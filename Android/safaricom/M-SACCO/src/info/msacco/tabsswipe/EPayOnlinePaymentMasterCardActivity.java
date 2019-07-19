package info.msacco.tabsswipe;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.ArrayAdapter;
import android.widget.Spinner;

import com.msacco.safaricom_sacco.R;

public class EPayOnlinePaymentMasterCardActivity extends Activity implements OnItemSelectedListener{

	@Override
	public void onCreate(Bundle savedInstanceState) {
		   super.onCreate(savedInstanceState);
		setContentView(R.layout.e_pay_online_mastercard_fragment);
		Spinner spinner = (Spinner)findViewById(R.id.epayOnlinePaypalSpinner);
		
		// Create an ArrayAdapter using the string array and a default spinner layout
		ArrayAdapter<CharSequence> adapter = ArrayAdapter.createFromResource(this,
		        R.array.online_paypal_account_selector_array, R.layout.spinner_selected_item_template);
		
		// Specify the layout to use when the list of choices appears
		adapter.setDropDownViewResource(R.layout.spinner_items_template_white);
		
		// Apply the adapter to the spinner
		spinner.setAdapter(adapter);

		spinner.setOnItemSelectedListener(this);	
	}
	
	public void onItemSelected(AdapterView<?> parent, View view, 
            int pos, long id) {
        // An item was selected. You can retrieve the selected item using
        // parent.getItemAtPosition(pos)
    }

    public void onNothingSelected(AdapterView<?> parent) {
        // Another interface callback
    }

}
