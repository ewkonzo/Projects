package info.msacco.tabsswipe;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.msacco.safaricom_sacco.R;

public class MyAccTransactAirTimeTopUpMyPhoneFragment extends Fragment{

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {
		View rootView = inflater.inflate(R.layout.transact_airtime_top_up_my_phone, container, false);
		return rootView;
		}
}
