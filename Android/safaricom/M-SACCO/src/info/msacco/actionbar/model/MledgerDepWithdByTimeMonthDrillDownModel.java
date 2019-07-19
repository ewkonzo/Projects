package info.msacco.actionbar.model;

public class MledgerDepWithdByTimeMonthDrillDownModel {

	// private variables
	String _month;
	double _deposit;
	double _withdrawal;

	public MledgerDepWithdByTimeMonthDrillDownModel(String _month, double _deposit,
			double _withdrawal) {
		super();
		this._month = _month;
		this._deposit = _deposit;
		this._withdrawal = _withdrawal;
	}

	
	public MledgerDepWithdByTimeMonthDrillDownModel() {
		// TODO Auto-generated constructor stub
	}


	public String get_month() {
		return _month;
	}


	public void set_month(String _month) {
		this._month = _month;
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

	@Override
    public String toString() {
        return _month;
    }
}
