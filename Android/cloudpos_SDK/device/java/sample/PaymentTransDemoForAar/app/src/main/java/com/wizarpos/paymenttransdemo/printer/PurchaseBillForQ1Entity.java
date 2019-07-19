package com.wizarpos.paymenttransdemo.printer;

import java.io.Serializable;

import com.wizarpos.util.StringUtility;

public class PurchaseBillForQ1Entity implements Serializable {
	private static final long serialVersionUID = 1L;

//	private String merchantCopy;

	private String merchantName;

	private String merchantNo;

	private String terminalNoAndOperator;

//	private String operator;

	private String cardNo;

	private String issuerAndAcquirer;

//	private String acquirer;

	private String transType;
	
	public String getIssuerAndAcquirer() {
		return issuerAndAcquirer;
	}

	public void setIssuerAndAcquirer(String issuerAndAcquirer) {
		this.issuerAndAcquirer = issuerAndAcquirer;
	}

	public String getDataTimeAndExpDate() {
		return dataTimeAndExpDate;
	}

	public void setDataTimeAndExpDate(String dataTimeAndExpDate) {
		this.dataTimeAndExpDate = dataTimeAndExpDate;
	}

	public String getRefNoAndBatchNo() {
		return refNoAndBatchNo;
	}

	public void setRefNoAndBatchNo(String refNoAndBatchNo) {
		this.refNoAndBatchNo = refNoAndBatchNo;
	}

	public String getVoucherAndAuthNo() {
		return voucherAndAuthNo;
	}

	public void setVoucherAndAuthNo(String voucherAndAuthNo) {
		this.voucherAndAuthNo = voucherAndAuthNo;
	}

	private String dataTimeAndExpDate;

//	private String expDate;
	
	private String refNoAndBatchNo;

//	private String batchNo;
 
	private String voucherAndAuthNo;

//	private String authNo;

	private String amout;
	
	private String reference;

	public boolean checkValidity() {

		if (StringUtility.isEmpty(merchantName)
				|| StringUtility.isEmpty(merchantNo)
				|| StringUtility.isEmpty(terminalNoAndOperator)
				|| StringUtility.isEmpty(cardNo)
				|| StringUtility.isEmpty(transType)
				|| StringUtility.isEmpty(dataTimeAndExpDate)
				|| StringUtility.isEmpty(refNoAndBatchNo) 
				|| StringUtility.isEmpty(voucherAndAuthNo)
				|| StringUtility.isEmpty(amout)) {
			return false;
		} else
			return true;
	}

//	public String getMerchantCopy() {
//		return merchantCopy;
//	}
//
//	public void setMerchantCopy(String merchantCopy) {
//		this.merchantCopy = merchantCopy;
//	}

	public String getCardNo() {
		return cardNo;
	}

	public void setCardNo(String cardNo) {
		this.cardNo = cardNo;
	}
	
	public String getTransType() {
		return transType;
	}

	public void setTransType(String transType) {
		this.transType = transType;
	}

	public static long getSerialversionuid() {
		return serialVersionUID;
	}

	public String getMerchantName() {
		return merchantName;
	}

	public void setMerchantName(String merchantName) {
		this.merchantName = merchantName;
	}

	public String getMerchantNo() {
		return merchantNo;
	}

	public void setMerchantNo(String merchantNo) {
		this.merchantNo = merchantNo;
	}

	public String getTerminalNoAndOperator() {
		return terminalNoAndOperator;
	}

	public void setTerminalNoAndOperator(String terminalNoAndOperator) {
		this.terminalNoAndOperator = terminalNoAndOperator;
	}

	public String getAmout() {
		return amout;
	}

	public void setAmout(String amout) {
		this.amout = amout;
	}

	public String getReference() {
		return reference;
	}

	public void setReference(String reference) {
		this.reference = reference;
	}
}
