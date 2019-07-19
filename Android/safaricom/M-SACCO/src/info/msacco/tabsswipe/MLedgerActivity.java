package info.msacco.tabsswipe;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;

import com.msacco.safaricom_sacco.R;

public class MLedgerActivity extends Activity implements OnClickListener {
	Button onByAccTypeButtonClicked, onByTransactionTypeButtonClicked,
			onByTimeButtonClicked;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.mledger);

		onByAccTypeButtonClicked = (Button) findViewById(R.id.mLedgerDepositByAccTypeBtn);
		onByTransactionTypeButtonClicked = (Button) findViewById(R.id.mLedgerDepositByTransactionTypeBtn);
		onByTimeButtonClicked = (Button) findViewById(R.id.mLedgerDepositByTimeBtn);

		onByAccTypeButtonClicked.setOnClickListener(this);
		onByTransactionTypeButtonClicked.setOnClickListener(this);
		onByTimeButtonClicked.setOnClickListener(this);
	}

	@Override
	public void onClick(View view) {
		if (view == onByAccTypeButtonClicked) {
			Intent i = new Intent(getApplicationContext(),
					MLedgerReportsByAccType.class);
			i.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
			startActivity(i);

		} else if (view == onByTransactionTypeButtonClicked) {

			Intent i = new Intent(getApplicationContext(),
					MLedgerReportsByTransType.class);
			i.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);

			startActivity(i);

		} else if (view == onByTimeButtonClicked) {

			Intent i = new Intent(getApplicationContext(),
					MLedgerReportsByTime.class);
			i.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);

			startActivity(i);
		}
	}
}
