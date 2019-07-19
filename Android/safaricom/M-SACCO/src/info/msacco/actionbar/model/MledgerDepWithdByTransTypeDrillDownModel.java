package info.msacco.actionbar.model;

public class MledgerDepWithdByTransTypeDrillDownModel {

	// private variables
	String _posting_date;
	double _deposit;
	double _withdrawal;
	String _description;

	public MledgerDepWithdByTransTypeDrillDownModel() {}

	

	public MledgerDepWithdByTransTypeDrillDownModel(String _posting_date,
			double _deposit, double _withdrawal, String _description) {
		super();
		this._posting_date = _posting_date;
		this._deposit = _deposit;
		this._withdrawal = _withdrawal;
		this._description = _description;
	}



	public String get_posting_date() {
		return _posting_date;
	}


	public void set_posting_date(String _posting_date) {
		this._posting_date = _posting_date;
	}


	public double get_deposit() {
		return _deposit;
	}


	public void set_deposit(double _deposit) {
		this._deposit = _deposit;
	}


	public double get_withdrawal() {
		return _withdrawal;
	}


	public void set_withdrawal(double _withdrawal) {
		this._withdrawal = _withdrawal;
	}


	public String get_description() {
		return _description;
	}


	public void set_description(String _description) {
		this._description = _description;
	}


	@Override
    public String toString() {
        return "Posting date" + _posting_date + ",Deposit=" + _deposit+ ", Withdrawale=" + _withdrawal
                + "]";
    }
}
