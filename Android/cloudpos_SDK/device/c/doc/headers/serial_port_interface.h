/*
 * serial_port_interface.h
 *
 *  Created on: 2012-7-19
 *      Author: yaomaobiao
 */
#ifndef SERIAL_PORT_INTERFACE_H_
#define SERIAL_PORT_INTERFACE_H_

#ifdef __cplusplus
extern "C"
{
#endif

/*
 * open the serial port
 * @param[in] : char* pDeviceName : device name
 * return value : < 0 : error code
 * 				  >= 0 : file description
 */
int serial_port_open(char* pDeviceName);

/*
 * close the serial port
 * @param[in] : int pHandle : file description
 * return value : < 0 : error code
 * 				  >=0 : success
 */
int serial_port_close(int pHandle);

/*
 * read data from the serial port
 * @param[in] : int pHandle : file description
 * @param[in] : unsigned char* pDataBuffer : data buffer
 * @param[in] : int ExpectedDataLength : data length of reading
 * @param[in] : int nTimeout_MS : time out in milliseconds
 * 								  nTimeout_MS : 0 : read and return immediately
 * 								  				< 0 : read until we have received data
 * return value : < 0 : error code
 * 				  >= 0 : data length
 */
int serial_port_read(int pHandle, unsigned char* pDataBuffer, int nExpectedDataLength, int nTimeout_MS);

/*
 * write data to the serial port
 * @param[in] : int pHandle : file description
 * @param[in] : unsigned char* pDataBuffer : data buffer
 * @param[in] : int nDataLength : data length
 * return value : < 0 : error code
 * 				  >= 0 : written data length
 */
int serial_port_write(int pHandle, unsigned char* pDataBuffer, int nDataLength);

/*
 * set the bard rate
 * @param[in] : int pHandle : file description
 * return value : < 0 : error code
 * 				  >= 0 :
 */
int serial_port_set_baudrate(int pHandle, unsigned int nBaudrate);

/*
 * flush io buffer
 * @param[in] : int pHandle : file description
 * return value : < 0 : error code
 * 				  >= 0 :
 */
int serial_port_flush_io(int pHandle);


#ifdef __cplusplus
}
#endif

#endif /* SERIAL_PORT_INTERFACE_H_ */
