package info.msacco.actionbar.model;

public class MledgerDepWithdByTimeYearDataModel {
	
	// private variables
	String _year;
	double deposits;
	double withdrawals;

	public MledgerDepWithdByTimeYearDataModel() {}
	
	public String get_year() {
		return _year;
	}
	public void set_year(String _year) {
		this._year = _year;
	}
	public double getDeposits() {
		return deposits;
	}
	public void setDeposits(double deposits) {
		this.deposits = deposits;
	}
	public double getWithdrawals() {
		return withdrawals;
	}
	public void setWithdrawals(double withdrawals) {
		this.withdrawals = withdrawals;
	}
	
	
}