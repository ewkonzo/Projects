/*
 * customer_display_interface.h
 *
 *  Created on: 2014-06-26
 *      Author: yue.zhong
 */

#ifndef CUSTOMER_DISPLAY_INTERFACE_H_
#define CUSTOMER_DISPLAY_INTERFACE_H_

#ifdef __cplusplus
extern "C"
{
#endif

/*
* open device
* return value : NULL : faled in opening device.
* 				  else : handle of device
*/
void* customer_display_open();

#if 0
/*
 * set display coordinate and width
 * @param[in] : int nHandle : handle of this device
 * @param[in] int nXcoordinate	: x coordinate.
 * @param[in] int nYcoordinate	: y coordinate.
 * @param[in] int nWidth(Horizontal screen)		: 0:	full screen.
 *								  				  else: width(vertical screen is height ).
 * return value : 0 : success
 * 				  < 0 : error code
 */
int customer_display_set_coordinate(int nHandle,unsigned int nXcoordinate,unsigned int nYcoordinate,unsigned int nWidth);
#endif

/*
 * write picture point data (one point 4 bytes ARGB8888)
 * @param[in] : int nHandle		: handle of this device.
 * @param[in] unsigned int nXcoordinate	: x coordinate.
 * @param[in] unsigned int nYcoordinate	: y coordinate.
 * @param[in] unsigned int nWidth		: 0:	full screen.
 *								  		  else: width.
 * @param[in] unsigned int nHeight      : 0:	full screen.
 *								  		  else: height.
 * @param[in] unsigned char* pData		: all point data.
 * @param[in] unsigned int nDataLength	: point data length.
 * return value : 0 : success
 * 				  < 0 : error code
 */
int customer_display_write_picture_data(int nHandle, unsigned int nXcoordinate, unsigned int nYcoordinate,unsigned int nWidth, unsigned int nHeight ,unsigned char* pData, unsigned int nDataLength);

/*
 * set background, display default screen , open or close led, buzzer beep and so on.
 * @param[in] : int nHandle		: handle of this device.
 * @param[in] : int nCmd		: contral command. 0x04:set background.
 *												   0x05:display default screen.
 *												   0x06:led.
 *												   0x07:buzzer.
 * @param[in] int nValue		: set background  			RED :0x001F   BLACK:0X0000   YELLOW:0X07FF    BLUE:0XF800    GRAY0:0XCE9A
 *								  display default screen    0
 *								  led 						1:open led.
 *								  	  						0:close led.
 *								  buzzer  					0
 * return value : 0 : success
 * 				  < 0 : error code
 */
int customer_display_ctrl_devs(int nHandle, int nCmd, int nValue);

/*
 * close the device
 * @param[in] : int nHandle : handle of this device
 * return value : 0 : success
 * 				  < 0 : error code
 */
int customer_display_close(int nHandle);


#ifdef __cplusplus
}
#endif


#endif 
