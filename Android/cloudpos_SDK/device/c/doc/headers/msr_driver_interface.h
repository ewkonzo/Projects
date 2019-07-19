/*
 * msr_driver_interface.h
 *
 *  Created on: 2012-6-28
 *      Author: yaomaobiao
 */

#ifndef MSR_DRIVER_INTERFACE_H_
#define MSR_DRIVER_INTERFACE_H_

#ifdef __cplusplus
extern "C" {
#endif

#define MAX_TRACK_DATA_LENGTH	128

typedef void (*MSR_NOTIFIER)(void* pUserData);
/*
 * initialize the msr device
 * @param :
 * return value : 0 : success
 */
int msr_open(void);

/*
 * close the msr device
 */
int msr_close(void);

/*
 * register a notifier. as soon as data is ready, this notifier will be called.
 * then you can query data information.
 */
int msr_register_notifier(MSR_NOTIFIER notifier, void* pUserData);
/*
 * unregister a notifier.
 */
int msr_unregister_notifier();
/*
 * get error information
 * @param : int nTrackIndex :   0 : first track
 * 								1 : second track
 * 								2 : third track
 * return value : 0 : no error
 * 				  < 0 : error code
 */
int msr_get_track_error(int nTrackIndex);
/*
 * get the length information
 * @param : int nTrackIndex :	0 : first track
 * 								1 : second track
 * 								3 : third track
 * return value : > 0 : length of track data
 * 				  < 0 : error code
 */
int msr_get_track_data_length(int nTrackIndex);
/*
 * get the data information
 * @param[in] : int nTrackIndex, 0, 1, 2
 * @param[out]: unsigned char* pTrackData: buffer for saving data
 * @param[in]:	int nLength: buffer length
 * return value : >= 0, success
 * 				  < 0, error code
 */
int msr_get_track_data(int nTrackIndex, unsigned char* pTrackData, int nLength);

#ifdef __cplusplus
}
#endif


#endif /* MSR_DRIVER_INTERFACE_H_ */
