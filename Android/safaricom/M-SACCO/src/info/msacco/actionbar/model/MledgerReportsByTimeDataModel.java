package info.msacco.actionbar.model;

public class MledgerReportsByTimeDataModel {
	private String _month;
	private Double _deposits;
	private Double _withdrawals;

	public MledgerReportsByTimeDataModel() {
	}

	public MledgerReportsByTimeDataModel(String _month, Double _deposits, Double _withdrawals) {
		super();
		this._month = _month;
		this._deposits = _deposits;
		this._withdrawals = _withdrawals;
	}

	public String get_month() {
		return _month;
	}

	public void set_month(String _month) {
		this._month = _month;
	}

	public Double get_deposits() {
		return _deposits;
	}

	public void set_deposits(Double _deposits) {
		this._deposits = _deposits;
	}

	public Double get_withdrawals() {
		return _withdrawals;
	}

	public void set_withdrawals(Double _withdrawals) {
		this._withdrawals = _withdrawals;
	}

	}