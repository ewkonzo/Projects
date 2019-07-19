package info.msacco.tabsswipe;

import java.text.DecimalFormat;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.msacco.safaricom_sacco.R;

public class LoanCalActivity extends Activity implements OnClickListener {
	private EditText mLoanAmount, mInterestRate, mLoanPeriod;
	private TextView mMontlyPaymentResult, mTotalPaymentsResult;
	Button calculate;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.loan_calc);
		mLoanAmount = (EditText) findViewById(R.id.loan_calc_amtEdtxt);
		mInterestRate = (EditText) findViewById(R.id.loan_calc_interestEdtxt);
		mLoanPeriod = (EditText) findViewById(R.id.loan_calc_period_AmtEdtxt);
		mMontlyPaymentResult = (TextView) findViewById(R.id.monthly_repayment);
		mTotalPaymentsResult = (TextView) findViewById(R.id.total_repayment);
		calculate = (Button) findViewById(R.id.loan_calc_calculateBtn);
		calculate.setOnClickListener(this);
	}

	@Override
	public void onClick(View arg0) {
		if (mLoanAmount.getText().toString().equals("")
				|| mLoanAmount.getText() == null) {
			Toast.makeText(getApplicationContext(),
					"Please enter the loan amount", Toast.LENGTH_LONG).show();
		} else if (mInterestRate.getText().toString().equals("")
				|| mInterestRate.getText() == null) {
			Toast.makeText(getApplicationContext(),
					"Please enter the loan interest rate", Toast.LENGTH_LONG)
					.show();
		} else if (mLoanPeriod.getText().toString().equals("")
				|| mLoanPeriod.getText() == null) {
			Toast.makeText(getApplicationContext(),
					"Please enter repayment period", Toast.LENGTH_LONG).show();
		} else {
			double loanAmount = Double.parseDouble(mLoanAmount.getText()
					.toString());
			double interestRate = (Double.parseDouble(mInterestRate.getText()
					.toString()));
			double loanPeriod = Integer.parseInt(mLoanPeriod.getText()
					.toString());
			double r = interestRate / 1200;
			double r1 = Math.pow(r + 1, loanPeriod);

			double monthlyPayment = (double) ((r + (r / (r1 - 1))) * loanAmount);
			double totalPayment = monthlyPayment * loanPeriod;

			mMontlyPaymentResult.setText("Monthly payment :"
					+ (new DecimalFormat("##.##").format(monthlyPayment)));
			mTotalPaymentsResult.setText("Total" + " payment :"
					+ (new DecimalFormat("##.##").format(totalPayment)));
		}
	}
}