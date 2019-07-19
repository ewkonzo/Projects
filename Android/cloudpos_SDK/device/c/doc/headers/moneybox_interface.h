/*
 * moneybox_service_interface.h
 *
 *  Created on: 2012-7-19
 *      Author: yaomaobiao
 */
#ifndef MONEY_SERVICE_INTERFACE_H_
#define MONEY_SERVICE_INTERFACE_H_

#ifdef __cplusplus
extern "C"
{
#endif

/**
 * open the money box device
 * @return value : < 0 : error code
 * 				   >= 0 : success;	
 */

int moneybox_open();
/*
 * close the money box device
 * @return value : < 0 : error code
 * 				   >= 0 : success;
 */

int moneybox_close();

/*
 * open money box
 * @return value : < 0 : error code;
 *                 >= 0 : success
 */

int moneybox_ctrl();

/*
 * enable or disable hardware
 * @param[in] : unsigned typedef int (* nEable : 1 : enable, 0 : disable
 * return value : >= 0 : success
 *                < 0 : error code
 */

int moneybox_setEnable(unsigned int nEnable);
#ifdef __cplusplus
}
#endif

#endif /* MONEY_SERVICE_INTERFACE_H_ */
