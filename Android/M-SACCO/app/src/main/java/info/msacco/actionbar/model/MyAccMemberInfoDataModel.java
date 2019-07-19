package info.msacco.actionbar.model;

public class MyAccMemberInfoDataModel {

	private String label;
	private String name;
	
	public MyAccMemberInfoDataModel(String label, String name) {
		super();
		this.label = label;
		this.name = name;
	}

	public String getLabel() {
		return label;
	}

	public void setLabel(String label) {
		this.label = label;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}
	

}