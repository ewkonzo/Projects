package info.msacco.actionbar.model;

public class MledgerDepWithdByAccTypeDataModel {
	
	// private variables
	String acc_type;
	double deposits;
	double withdrawals;
	
    public MledgerDepWithdByAccTypeDataModel(){}
    public MledgerDepWithdByAccTypeDataModel(String acc_type, double deposits,
			double withdrawals) {
		super();
		this.acc_type = acc_type;
		this.deposits = deposits;
		this.withdrawals = withdrawals;
	}


	public String getAcc_type() {
		return acc_type;
	}


	public void setAcc_type(String acc_type) {
		this.acc_type = acc_type;
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


	@Override
    public String toString() {
        return "Account Type=:" +acc_type + ", Deposits=:" + deposits+ ", Withdrawals=:" + withdrawals
                + "]";
    }

}
