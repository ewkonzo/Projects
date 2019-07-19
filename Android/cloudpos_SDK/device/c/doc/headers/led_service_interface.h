/*
 * led_service_interface.h
 *
 *  Created on: 2012-7-19
 *      Author: yaomaobiao
 */

#ifndef LED_SERVICE_INTERFACE_H
#define LED_SERVICE_INTERFACE_H

#ifdef __cplusplus
extern "C"
{
#endif

/*
 * open the led device
 * @return value : < 0 : error code
 * 				   >= 0 : success;	
 */
int led_open();
/*
 * close the led device
 * @return value : < 0 : error code
 * 				   >= 0 : success;
 */
int led_close();

/*
 * turn on the led
 * @param[in] : unsigned int nLedIndex : index of led, >= 0 && < MAX_LED_COUNT
 * @return value : < 0 : error code;
 *                 >= 0 : success
 */
int led_on(unsigned int nLedIndex);
/*
 * turn off the led
 * @param[in] : unsigned int nLedIndex : index of led, >= 0 && < MAX_LED_COUNT
 * @return value : < 0 : error code;
 *                 >= 0 : success
 */

int led_off(unsigned int nLendIndex);
/*
 * get the status of led
 * @param[in] : unsigned int nLedIndex : index of led, >= 0 && < MAX_LED_COUNT
 * @return value : == 0 : turn off
 *                 > 0 : turn on
 *                 < 0 : error code
 */
int led_get_status(unsigned int nLedIndex);

#ifdef __cplusplus
}
#endif


#endif
