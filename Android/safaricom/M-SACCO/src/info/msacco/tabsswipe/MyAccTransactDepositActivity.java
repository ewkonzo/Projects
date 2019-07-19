package info.msacco.tabsswipe;

import info.msacco.utils.Configuration;
import android.app.Activity;
import android.os.Bundle;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import com.msacco.safaricom_sacco.R;

public class MyAccTransactDepositActivity extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.transact_deposit_fragment);
		String corporate_no = "";
		Configuration config = new Configuration();
		corporate_no = config.getCorporateNo();
		getActionBar().setTitle("How to Deposit");

		String[] infoLabels = { "1. Go to Mpesa menu.",
				"2. Select 'Lipa Na Mpesa.'", "3. Select PayBill.",
				"4. Enter Business No.(" + corporate_no + ")",
				"5. Enter Acc No.:", "6. Enter amount.", "7. Enter Mpesa PIN.",
				"8. Click Send." };
		ListView memInfoListV = (ListView) findViewById(R.id.myAccTransactDepositList);
		
		ArrayAdapter<String> adapter = new ArrayAdapter<String>(this,
				R.layout.list_item_custom_template,infoLabels);

		memInfoListV.setAdapter(adapter);
	}
}
