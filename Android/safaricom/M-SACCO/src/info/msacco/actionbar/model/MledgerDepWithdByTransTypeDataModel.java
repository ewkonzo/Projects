package info.msacco.actionbar.model;

public class MledgerDepWithdByTransTypeDataModel {
	
	// private variables
	String _trans_type;
	double _deposits;
	double _withdrawals;
	
    public MledgerDepWithdByTransTypeDataModel(){}

	public MledgerDepWithdByTransTypeDataModel(String _trans_type,
			double _deposits, double _withdrawals) {
		super();
		this._trans_type = _trans_type;
		this._deposits = _deposits;
		this._withdrawals = _withdrawals;
	}

	public String get_trans_type() {
		return _trans_type;
	}

	public void set_trans_type(String _trans_type) {
		this._trans_type = _trans_type;
	}

	public double get_deposits() {
		return _deposits;
	}

	public void set_deposits(double _deposits) {
		this._deposits = _deposits;
	}

	public double get_withdrawals() {
		return _withdrawals;
	}

	public void set_withdrawals(double _withdrawals) {
		this._withdrawals = _withdrawals;
	}
    
}
