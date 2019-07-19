package info.msacco.tabsswipe.adapter;

import info.msacco.actionbar.model.CustomerServiceInboxMessageModel;

import java.util.ArrayList;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.msacco.safaricom_sacco.R;

public class CustomerServiceInboxMsgListAdapter extends
		ArrayAdapter<CustomerServiceInboxMessageModel> {
	private ArrayList<CustomerServiceInboxMessageModel> data;
	private Context mContext;

	public CustomerServiceInboxMsgListAdapter(Context ctx,
			ArrayList<CustomerServiceInboxMessageModel> items) {
		super(ctx, android.R.layout.simple_list_item_1, items);
		data = items;
		mContext = ctx;
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {

		View row = convertView;
		if (row == null) {
			LayoutInflater inflater = (LayoutInflater) mContext
					.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			row = inflater.inflate(R.layout.customer_service_inbox_list_items,
					null);
		}
		TextView txtHeading = (TextView) row
				.findViewById(R.id.customerServiceInboxHeading);
		TextView txtMessage = (TextView) row
				.findViewById(R.id.customerServiceInboxMessage);
		TextView txtDate = (TextView) row
				.findViewById(R.id.customerServiceInboxDate);

		CustomerServiceInboxMessageModel inboxDataModel = data.get(position);

		txtHeading.setText(inboxDataModel.get_messageHeading());
		txtMessage.setText(inboxDataModel.get_message());
		txtDate.setText(inboxDataModel.get_entryDate());
		return row;

	}
}
