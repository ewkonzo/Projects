package info.msacco.actionbar.model;

public class MledgerDepWithdByTimeDateDrillDownModel {

	// private variables
	String _date;
	double _deposit;
	double _withdrawal;

	public MledgerDepWithdByTimeDateDrillDownModel() {}

	public MledgerDepWithdByTimeDateDrillDownModel(String _date,
			double _deposit, double _withdrawal) {
		super();
		this._date = _date;
		this._deposit = _deposit;
		this._withdrawal = _withdrawal;
	}

	public String get_date() {
		return _date;
	}

	public void set_date(String _date) {
		this._date = _date;
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
	

}