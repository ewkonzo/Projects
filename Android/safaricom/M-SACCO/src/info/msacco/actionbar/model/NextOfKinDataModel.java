package info.msacco.actionbar.model;

public class NextOfKinDataModel {

	private String nkin_name;
	private String nkin_rship;
	private String nkin_allocation;
	public NextOfKinDataModel(String nkin_name, String nkin_rship,
			String nkin_allocation) {
		super();
		this.nkin_name = nkin_name;
		this.nkin_rship = nkin_rship;
		this.nkin_allocation = nkin_allocation;
	}
	public String getNkin_name() {
		return nkin_name;
	}
	public void setNkin_name(String nkin_name) {
		this.nkin_name = nkin_name;
	}
	public String getNkin_rship() {
		return nkin_rship;
	}
	public void setNkin_rship(String nkin_rship) {
		this.nkin_rship = nkin_rship;
	}
	public String getNkin_allocation() {
		return nkin_allocation;
	}
	public void setNkin_allocation(String nkin_allocation) {
		this.nkin_allocation = nkin_allocation;
	}
}