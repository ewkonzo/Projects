package info.msacco.actionbar.model;

public class AccBalEnquiryDataModel {

	private String account_name;
	private String account_balance_label;
	private String account_balance_value;
	public AccBalEnquiryDataModel(String account_name,
			String account_balance_label, String account_balance_value) {
		super();
		this.account_name = account_name;
		this.account_balance_label = account_balance_label;
		this.account_balance_value = account_balance_value;
	}
	public String getAccount_name() {
		return account_name;
	}
	public void setAccount_name(String account_name) {
		this.account_name = account_name;
	}
	public String getAccount_balance_label() {
		return account_balance_label;
	}
	public void setAccount_balance_label(String account_balance_label) {
		this.account_balance_label = account_balance_label;
	}
	public String getAccount_balance_value() {
		return account_balance_value;
	}
	public void setAccount_balance_value(String account_balance_value) {
		this.account_balance_value = account_balance_value;
	}
	
}