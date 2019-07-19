package info.msacco.tabsswipe.adapter;


import info.msacco.tabsswipe.MyAccTransactAirTimeTopUpMyPhoneFragment;
import info.msacco.tabsswipe.MyAccTransactAirTimeTopUpOtherPhoneFragment;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;

public class MyAccTransactAirtimeTopUpTabsPagerAdapter extends FragmentPagerAdapter {
	
	private static final int NO_OF_TABS = 2;
	public boolean FLAG=false;

    public MyAccTransactAirtimeTopUpTabsPagerAdapter(FragmentManager fm) {
        super(fm);
    }
 
    @Override
    public Fragment getItem(int index) {
 
        switch (index) 
        {
        case 0:
            // Deposit Fragment
            return new MyAccTransactAirTimeTopUpMyPhoneFragment();
        case 1:
            // Account balance Fragment
            return new MyAccTransactAirTimeTopUpOtherPhoneFragment();
        }
 
        return null;
    }

	@Override
	public int getCount() {
		// TODO Auto-generated method stub
		return NO_OF_TABS;
	}
	
}
