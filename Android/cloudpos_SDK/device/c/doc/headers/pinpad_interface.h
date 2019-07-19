/*
 * pinpad_interface.h
 *
 *  Created on: 2012-8-2
 *      Author: yaomaobiao
 */

#ifndef PINPAD_INTERFACE_H_
#define PINPAD_INTERFACE_H_

#define KEY_TYPE_DUKPT		0
#define KEY_TYPE_TDUKPT		1
#define KEY_TYPE_MASTER		2
#define KEY_TYPE_PUBLIC		3
#define KEY_TYPE_FIX		5

#ifdef __cplusplus
extern "C"
{
#endif

/*
 * open the device
 * return value : 0 : success
 * 				  < 0 : error code
 */
int pinpad_open();
/*
 * close the device
 * return value : 0 : success
 * 				  < 0 : error code
 */
int pinpad_close();
/*
 * show text in the first line
 * param[in] : int nLineIndex : line index, from top to down
 * param[in] : char* strText : encoded string
 * param[in] : int nLength : length of string
 * param[in] : int nFlagSound : 0 : no voice prompt, 1 : voice prompt
 * return value : < 0 : error code, maybe, your display string is too long!
 * 				  >= 0 : success
 *
 */
int pinpad_show_text(int nLineIndex, char* strText, int nLength, int nFlagSound);
/*
 * select master key and user key
 * @param[in] : int nKeyType : 0 : dukpt, 1: Tdukpt, 2 : master key, 3 : public key, 5 : fix key
 * @param[in] : int nMasterKeyID : master key ID , [0x00, ..., 0x09], make sense only when nKeyType is master-session pair,
 * @param[in] : int nUserkeyID : user key ID, [0x00, 0x01], 		  make sense only when nKeyType is master-session pair,
 * @param[in] : int nAlgorith : 1 : 3DES
 * 							   0 : DES
 * return value : < 0 : error code
 * 				  >= 0 : success
 */
int pinpad_select_key(int nKeyType, int nMasterKeyID, int nUserKeyID, int nAlgorith);

/*
 * encrypt string using user key
 * @param[in] : unsigned char* pPlainText : plain text
 * @param[in] : int nTextLength : length of plain text
 * @param[out] : unsigned char* pCipherTextBuffer : buffer for saving cipher text
 * @param[in] : int CipherTextBufferLength : length of cipher text buffer
 * return value : < 0 : error code
 * 				  >= 0 : success, length of cipher text length
 */
int pinpad_encrypt_string(unsigned char* pPlainText, int nTextLength, unsigned char* pCipherTextBuffer, int nCipherTextBufferLength);

/*
 * calculate pin block
 * @param[in] : unsigned char* pASCIICardNumber : card number in ASCII format
 * @param[in] : int nCardNumberLength : length of card number
 * @param[out] : unsigned char* pPinBlockBuffer : buffer for saving pin block
 * @param[in] : int nPinBlockBufferLength : buffer length of pin block
 * @param[in] : int nTimeout_MS : timeout waiting for user input in milliseconds, if it is less than zero, then wait forever
 * param[in]   : int nFlagSound : 0 : no voice prompt, 1 : voice prompt
 * return value : < 0 : error code
 * 			      >= 0 : success, length of pin block
 */
int pinpad_calculate_pin_block(unsigned char* pASCIICardNumber, int nCardNumberLength, unsigned char* pPinBlockBuffer, int nPinBlockBufferLength, int nTimeout_MS, int nFlagSound);

/*
 * calculate the MAC using current user key
 * @param[in] : unsigned char* pData : data
 * @param[in] : int nDataLength : data length
 * @param[in] : int nMACFlag : 0: X99, 1 : ECB
 * @param[out] : unsigned char* pMACOut : MAC data buffer
 * @param[in] : int nMACOutBufferLength : length of MAC data buffer
 * return value : < 0 : error code
 * 				  >= 0 : success
 *
 */
int pinpad_calculate_mac(unsigned char* pData, int nDataLength, int nMACFlag, unsigned char* pMACOutBuffer, int nMACOutBufferLength);


/*
 * update the user key
 * @param[in] : int nMasterKeyID : master key id
 * @param[in] : int nUserKeyID : user key id
 * @param[in] : unsigned char* pCipherNewUserkey : new user key in cipher text
 * @param[in] : int nCipherNewUserKeyLength : length of new user key in cipher text
 * return value : < 0 : error code
 * 				  >= 0 : success
 */
int pinpad_update_user_key(int nMasterKeyID, int nUserKeyID, unsigned char* pCipherNewUserKey, int nCipherNewUserKeyLength);

/*
 * set the max length of pin
 * @param[in] : int nLength : length >= 0 && length <= 0x0D
 * @param[in] : int nFlag : 1, max length
 * 							0, min length
 * return value : < 0 : error code
 * 				  >= 0 : success
 */
int pinpad_set_pin_length(int nLength, int nFlag);

/*
 * update the master key
 * @param[in] : int nMasterKeyID : master key ID
 * @param[in] : unsigned char* pOldKey, old key
 * @param[in] : int nOldKeyLength : length of old key, 8 or 16
 * @param[in] : unsigned char* pNewLey : new key
 * @param[in] : int nNewLeyLength : length of new key, 8 or 16
 * return value : < 0 : error code
 * 				  >= 0 : success
 */
int pinpad_update_master_key(int nMasterKeyID, unsigned char* pOldKey, int nOldKeyLength, unsigned char* pNewKey, int nNewKeyLength);



#ifdef __cplusplus
}
#endif

#endif /* PINPAD_INTERFACE_H_ */