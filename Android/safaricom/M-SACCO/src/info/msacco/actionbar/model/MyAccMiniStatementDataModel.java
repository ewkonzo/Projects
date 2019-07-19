package info.msacco.actionbar.model;

public class MyAccMiniStatementDataModel {

	private String date;
	private String description;
	private String amount;
	public MyAccMiniStatementDataModel(String date, String description,
			String amount) {
		super();
		this.date = date;
		this.description = description;
		this.amount = amount;
	}
	public String getDate() {
		return date;
	}
	public void setDate(String date) {
		this.date = date;
	}
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	public String getAmount() {
		return amount;
	}
	public void setAmount(String amount) {
		this.amount = amount;
	}
	
}