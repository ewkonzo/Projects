
package com.errorcodetools;

/**
 * This method is used to get the return value into hardware and software error code
 */

public class ErrorCodeTransfer {
    //Hardware error code conversion
    public static int transfer2SoftwareErrorCode(int errorCode) {
        int a = -errorCode;
        int b = a & 0x0000FF;
        return b;
    }

    //Software error code conversion
    public static int transfer2HardwareErrorCode(int errorCode) {
        return ((-errorCode) >> 8) & 0x00FF00;
    }
}



