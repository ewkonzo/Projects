
package com.PrintUtil;

public class PrinterCommand
{
    /*--------------------------Print command-----------------------------*/

    /**
     *
     * Print the data in the printer buffer, then feed paper for one line according to the current line space settings. 
     * After printing, the print position moves to the beginning of the line.
     * 
     * @return
     */
    static public byte[] getCmdLf()
    {
        return new byte[] {
                (byte) 0x0A
        };
    }

    /**
     *
     * Move the print position to the next tab position.
     * 
     * @return
     */
    static public byte[] getCmdHt()
    {
        return new byte[] {
                (byte) 0x09
        };
    }

    /**
     *
     * Print the data in the printer buffer. If it has black label function, feed paper for next black label position after print.
     * 
     * @return
     */
    static public byte[] getCmdFf()
    {
        return new byte[] {
                (byte) 0x0c
        };
    }

    /**
     *
     * Print the data in the printer buffer and feed paper for n dots.
     * The commend is only effective at this line. Not change the setting of 'ESC 2' 'ESC 3' commend.
     * 
     * @param n 0-255
     * @return
     */
    static public byte[] getCmdEscJN(int n)
    {
        return new byte[] {
                (byte) 0x1B, (byte) 0x4A, (byte) n
        };
    }

    /**
     * 打印缓冲区里的数据,如果有黑标功能,打印后进纸到下一个黑标位置
     * 
     * Print the data in the printer buffer. If it has black label function, feed paper for next black label position after print.
     * 
     * @return
     */
    static public byte[] getCmdEscFf()
    {
        return new byte[] {
                (byte) 0x1b, (byte) 0x0c
        };
    }

    /**
     *
     * Print the data in the printer buffer and feed paper for n lines.
     * 
     * @param n 0-255
     * @return
     */
    static public byte[] getCmdEscDN(int n)
    {
        return new byte[] {
                (byte) 0x1B, (byte) 0x64, (byte) n
        };
    }

    /**
     *
     * Set Chinese small font.
     * 	
     */
    static public byte[] getCmdSetSmallFont_CN()
    {
        return new byte[] {
                (byte) 0x1C, (byte) 0x21, (byte) 0x01
        };
    }

    /**
     *
     * Cancel Chinese small font.
     * 
     */
    static public byte[] getCmdCancelSmallFont_CN()
    {
        return new byte[] {
                (byte) 0x1C, (byte) 0x21, (byte) 0x00
        };
    }

    /**
     *
     * Set English small font.
     * 
     */
    static public byte[] getCmdSetSmallFont_EN()
    {
        return new byte[] {
                (byte) 0x1B, (byte) 0x21, (byte) 0x01
        };
    }

    /**
     *
     * Cancel English small font.
     * 
     */
    static public byte[] getCmdCancelSmallFont_EN()
    {
        return new byte[] {
                (byte) 0x1B, (byte) 0x21, (byte) 0x00
        };
    }

    /**
     *
     *  1:printer is online, accept data and print.
	 *	0:printer is offline, don’t accept data.
     * 
     * @param n :0,1
     * @return
     */
    static public byte[] getCmdEscN(int n)
    {
        return new byte[] {
                (byte) 0x1B, (byte) 0x3d, (byte) n
        };
    }

    /*--------------------------行间距设置命令-----------------------------*/

    /**
     *
     * Set the line spacing to 4 mm, 32 dots.
     * 
     * @return
     */
    static public byte[] getCmdEsc2()
    {
        return new byte[] {
                (byte) 0x1B, (byte) 0x32
        };
    }

    /**
     *
     * Set the line spacing to n dots.
	 * Default value is 32 dots.
     * 
     * @param n :0-255
     * @return
     */
    static public byte[] getCmdEsc3N(int n)
    {
        return new byte[] {
                (byte) 0x1B, (byte) 0x33, (byte) n
        };
    }

    /**
     * n=2,50
     * 
     * Align all data in a line, the meanings of n value are as follows:
	 *	0 ≤ n ≤ 2 or 48 ≤ n ≤ 50
	 *	Left: n=0,48
	 *	Center: n=1,49
	 *	Right: n=2,50
	 *	Default value is 0.
     * 
     * @param n :0 ≤ n ≤ 2 or 48 ≤ n ≤ 50
     * @return
     */
    static public byte[] getCmdEscAN(int n)
    {
        return new byte[] {
                (byte) 0x1B, (byte) 0x61, (byte) n
        };
    }

    /**
     *
     * Left margin can be set by nL and nH.
	 *	Sets the left margin to (nL+nH*256)*0.125mm from the left edge of
	 *	the printable area.
	 *	0 ≤ nL ≤ 255, 0 ≤ nH ≤ 255,and 0 ≤ nL+nH*256 ≤ 65535.
	 *	Default value is nL=0, nH=0.
     * 
     * @param nL
     * @param nH
     * @return
     */
    static public byte[] getCmdGsLNlNh(int nL, int nH)
    {
        return new byte[] {
                (byte) 0x1D, (byte) 0x4c, (byte) nL, (byte) nH
        };
    }

    /**
     *
     * Left margin can be set by nL and nH.
	 *	Sets the left margin to (nL+nH*256)*0.125mm from the left edge of
	 *	the printable area.
	 *	0 ≤ nL ≤ 255, 0 ≤ nH ≤ 255,and 0 ≤ nL+nH*256 ≤ 65535.
	 *	Default value is nL=0, nH=0.
     * 
     * @param nL
     * @param nH
     * @return
     */
    static public byte[] getCmdEsc$NlNh(int nL, int nH)
    {
        return new byte[] {
                (byte) 0x1B, (byte) 0x24, (byte) nL, (byte) nH
        };
    }

    /*--------------------------字符设置命令-----------------------------*/

    /**
     *
     * Set the font type(black white inverse, upside-down ,bold, double width,
		double height or underline). And the bit definitions of parameter n are shown as follows:
		Bit 0: reserved
		Bit 1: 1: black white inverse
		Bit 2:1: upside-down
		Bit 3:1: bold
		Bit 4:1: double height
		Bit 5:1: double width
		Bit 6:1: underline
     * 
     * @return
     */
    static public byte[] getCmdEsc_N(int n)
    {
        return new byte[] {
                (byte) 0x1B, (byte) 0x21, (byte) n
        };
    }

    /**
     *
     * Character width is set is set by the bit0-bit3 of n, and character height
		 is set by bit4-bit7 of n.
		Hexadecimal 00(Decimal 0):width(normal),height(normal)
		Hexadecimal 01(Decimal 1):width(normal),height(double)
		Hexadecimal 10(Decimal 16):width(double),height(normal)
		Hexadecimal 11(Decimal 17):width(double),height(double)
     * @param n
     * @return
     */
    static public byte[] getCmdGs_N(int n)
    {
        return new byte[] {
                (byte) 0x1D, (byte) 0x21, (byte) n
        };
    }

    /**
     *
     * Turns bold mode on or off using n as follows:
		0: Turns off
		1: Turns on
     * 	
     * @param n
     * @return
     */
    static public byte[] getCmdEscEN(int n)
    {
        return new byte[] {
                (byte) 0x1B, (byte) 0x45, (byte) n
        };
    }

    /**
     *
     * Set character space to n. Default is 0.
     * 
     * @param n
     * @return
     */
    static public byte[] getCmdEscSpN(int n)
    {
        return new byte[] {
                (byte) 0x1B, (byte) 0x20, (byte) n
        };
    }

    /**
     *
     * Set the character printing double width.
     * 
     * @return
     */
    static public byte[] getCmdEscSo()
    {
        return new byte[] {
                (byte) 0x1B, (byte) 0x0E
        };
    }

    /**
     *
     * After execute the command, the character restore normal width.
     * 
     * @return
     */
    static public byte[] getCmdEscDc4()
    {
        return new byte[] {
                (byte) 0x1B, (byte) 0x14
        };
    }

    /**
     *
     * n=1:Turn on.
		n=0:Turn off.
		Default is 0.
     * 
     * @return
     */
    static public byte[] getCmdEsc__N(int n)
    {
        return new byte[] {
                (byte) 0x1B, (byte) 0x7B, (byte) n
        };
    }

    /**
     *
     * n=1:Turn on.
		n=0:Turn off.
		Default is 0.
     * 
     * @return
     */
    static public byte[] getCmdGsBN(int n)
    {
        return new byte[] {
                (byte) 0x1D, (byte) 0x42, (byte) n
        };
    }

    /**
     *
     * n=0-2,Turn underline mode on or off using n as follows:
		0: Turns off underline mode
		1: Turns on underline mode(1-dot thick)
		2: Turns on underline mode(2-dot thick)
		Default value is 0.
		
     * @return
     */
    static public byte[] getCmdEsc___N(int n)
    {
        return new byte[] {
                (byte) 0x1B, (byte) 0x2D, (byte) n
        };
    }

    /**
     * 
     * n=1:use the custom character set
		n=0:use the default character set	
		
     * @return
     */
    static public byte[] getCmdEsc____N(int n)
    {
        return new byte[] {
                (byte) 0x1B, (byte) 0x25, (byte) n
        };
    }

    /**
     *
     * @return
     */
    static public byte[] getCmdEsc_SNMW()
    {
        // 占位
        return null;
    }

    /**
     *
     * Cancel custom character mode, use system character.
     * 
     * @param n
     * @return
     */
    static public byte[] getCmdEsc_____N(int n)
    {
        return new byte[] {
                (byte) 0x1B, (byte) 0x25, (byte) n
        };
    }

    /**
     *
     * Selects an international character set n as follows:
		0:USA		5:Sweden	10:Denmark II
		1:France	6:Italy		11:Spain II
		2:Germany	7:Spain1	12:Latin America
		3:U.K.		8:Japan		13:Korea
		4:Denmark 1	9:Norway
     * 
     * @param n 0:USA 1:France 2:Germany 3:U.K. 4:Denmark 1 5:Sweden
     *            6:Italy 7:Spain1 8:Japan 9:Norway 10:Denmark II 11:Spain II
     *            12:Latin America 13:Korea
     * @return
     */
    static public byte[] getCmdEscRN(int n)
    {
        return new byte[] {
                (byte) 0x1B, (byte) 0x52, (byte) n
        };
    }

    /**
     *
     * Selects an page n from the character code page as follows:
			0:437		1:850
     * 
     * @return
     */
    static public byte[] getCmdEscTN(int n)
    {
        return new byte[] {
                (byte) 0x1B, (byte) 0x74, (byte) n
        };
    }

    /*--------------------------图形打印命令 略 -----------------------------*/

    /*--------------------------按键控制命令-----------------------------*/

    /**
     *
     * Key switch commend. Not support for the moment.
     * 
     * @return
     */
    static public byte[] getCmdEscC5N(int n)
    {
        return new byte[] {
                (byte) 0x1B, (byte) 0x63, (byte) 0x35, (byte) n
        };
    }

    /*--------------------------初始化命令-----------------------------*/

    /**
     *
     * Initializes the printer:
		Clear the data in the print buffer;
		Resets the printer mode to the modes that were in effect.
     * 
     * @return
     */
    static public byte[] getCmdEsc_()
    {
        return new byte[] {
                (byte) 0x1B, (byte) 0x40
        };
    }

    /*--------------------------状态传输命令-----------------------------*/

    /**
     *
     * Send the state of control panel to host.
     * 
     * @param n
     * @return
     */
    static public byte[] getCmdEscVN(int n)
    {
        return new byte[] {
                (byte) 0x1B, (byte) 0x76, (byte) n
        };
    }

    /**
     *
     * Set /cancel the printer states back automatically. Refer to ESC/POS instruction set for further information.
     * 
     * @param n
     * @return
     */
    static public byte[] getCmdGsAN(int n)
    {
        return new byte[] {
                (byte) 1D, (byte) 61, (byte) n
        };
    }

    /**
     *
     * Not support.
     * 
     * @param n
     * @return
     */
    static public byte[] getCmdEscUN(int n)
    {
        return new byte[] {
                (byte) 0x1B, (byte) 0x75, (byte) n
        };
    }

    /*--------------------------条码打印命令 略 -----------------------------*/

    /*--------------------------控制板参数命令 略 -----------------------------*/

    /**
     *
     * Custom tab stop. (Two spacing)
     * 
     * @return
     */
    static public byte[] getCustomTabs()
    {
        return "  ".getBytes();
    }

    static public byte[] aaa()
    {
        return new byte[] {
                (byte) 0x1B, (byte) 0x69
        };
    }
}
