/*
 * identity_card_interface.h
 *
 *  Created on: 2012-7-19
 *      Author: yaomaobiao
 */

#ifndef IDENTITY_CARD_INTERFACE_H
#define IDENTITY_CARD_INTERFACE_H

#ifdef __cplusplus
extern "C"
{
#endif
/*
 * IDCard data: the struction include IDCard information with UTF-16LE coding.
 * {
 *    strName[30];		//user name.
 *	  strSex[2];		//user sex. 01:	male.
 * 									02:	female.
 *	  strNation[4];		//01汉族		02蒙古族		03回族		04藏族		05维吾尔族		06苗族	07彝族		08壮族		09布依族		10朝鲜族		11满族		12侗族
 *						  13瑶族		14白族		15土家族		16哈尼族		17哈萨克族		18傣族	19黎族		20傈僳族		21佤族		22畲族		23高山族		24拉祜族
 *						  25水族		26东乡族		27纳西族		28景颇族		29柯尔克孜族		30土族	31达斡尔族	32仫佬族		33羌族		34布朗族		35撒拉族		36毛难族
 *						  37仡佬族	38锡伯族		39阿昌族		40普米族		41塔吉克族		42怒族	43乌孜别克族	44俄罗斯族	45鄂温克族	46崩龙族		47保安族		48裕固族
 *						  49京族		50塔塔尔族	51独龙族		52鄂伦春族	53赫哲族			54门巴族	55珞巴族		56基诺族		57其他		58外国血统中国人士
 *	  ...
 *	  strPicture[1024]; //encrypt picture data,the max length is 1024.
 * }
 */
typedef struct tagIDCardData
{
	unsigned char strName[30];
	unsigned char strSex[2];
	unsigned char strNation[4];
	unsigned char strBorn[16];
	unsigned char strAddress[70];
	unsigned char strIDCardNo[36];
	unsigned char strGrantDept[30];
	unsigned char strUserLifeBegin[16];
	unsigned char strUserLifeEnd[16];
	unsigned char strReserved[36];
	unsigned char strPicture[1024];
}IDCARD_PROPERTY;

/*
 * open the device
 * return value : >=0 : success
 * 				  < 0 : error 
 */
int identity_card_open();

/*
 * close the device
 * return value : 0 : success
 * 				  < 0 : error 
 */
int identity_card_close(int nHandle);
/*
*nHandle
*/
int identity_card_search_target(int nHandle);

/*
 * get fixed information 
 * @param[in][out]:struct tagIDCardData *pIDCardData :IDCard data.
 * return value : >= 0 	: 	success,return picture data length.
 * 				  < 0 	: 	error 
 */
int identity_card_get_fixed_information(int nHandle, struct tagIDCardData *pIDCardData);

#ifdef __cplusplus
}
#endif


#endif
