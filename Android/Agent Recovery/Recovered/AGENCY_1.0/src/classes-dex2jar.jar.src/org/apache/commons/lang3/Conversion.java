package org.apache.commons.lang3;

import java.util.UUID;

public class Conversion
{
  static
  {
    if (!Conversion.class.desiredAssertionStatus()) {}
    for (boolean bool = true;; bool = false)
    {
      $assertionsDisabled = bool;
      return;
    }
  }
  
  public static char binaryBeMsb0ToHexDigit(boolean[] paramArrayOfBoolean)
  {
    return binaryBeMsb0ToHexDigit(paramArrayOfBoolean, 0);
  }
  
  public static char binaryBeMsb0ToHexDigit(boolean[] paramArrayOfBoolean, int paramInt)
  {
    if (paramArrayOfBoolean.length == 0) {
      throw new IllegalArgumentException("Cannot convert an empty array.");
    }
    paramInt = paramArrayOfBoolean.length - 1 - paramInt;
    int i = Math.min(4, paramInt + 1);
    boolean[] arrayOfBoolean = new boolean[4];
    System.arraycopy(paramArrayOfBoolean, paramInt + 1 - i, arrayOfBoolean, 4 - i, i);
    if (arrayOfBoolean[0] != 0)
    {
      if ((arrayOfBoolean.length > 1) && (arrayOfBoolean[1] != 0))
      {
        if ((arrayOfBoolean.length > 2) && (arrayOfBoolean[2] != 0))
        {
          if ((arrayOfBoolean.length > 3) && (arrayOfBoolean[3] != 0)) {
            return 'f';
          }
          return 'e';
        }
        if ((arrayOfBoolean.length > 3) && (arrayOfBoolean[3] != 0)) {
          return 'd';
        }
        return 'c';
      }
      if ((arrayOfBoolean.length > 2) && (arrayOfBoolean[2] != 0))
      {
        if ((arrayOfBoolean.length > 3) && (arrayOfBoolean[3] != 0)) {
          return 'b';
        }
        return 'a';
      }
      if ((arrayOfBoolean.length > 3) && (arrayOfBoolean[3] != 0)) {
        return '9';
      }
      return '8';
    }
    if ((arrayOfBoolean.length > 1) && (arrayOfBoolean[1] != 0))
    {
      if ((arrayOfBoolean.length > 2) && (arrayOfBoolean[2] != 0))
      {
        if ((arrayOfBoolean.length > 3) && (arrayOfBoolean[3] != 0)) {
          return '7';
        }
        return '6';
      }
      if ((arrayOfBoolean.length > 3) && (arrayOfBoolean[3] != 0)) {
        return '5';
      }
      return '4';
    }
    if ((arrayOfBoolean.length > 2) && (arrayOfBoolean[2] != 0))
    {
      if ((arrayOfBoolean.length > 3) && (arrayOfBoolean[3] != 0)) {
        return '3';
      }
      return '2';
    }
    if ((arrayOfBoolean.length > 3) && (arrayOfBoolean[3] != 0)) {
      return '1';
    }
    return '0';
  }
  
  public static byte binaryToByte(boolean[] paramArrayOfBoolean, int paramInt1, byte paramByte, int paramInt2, int paramInt3)
  {
    if (((paramArrayOfBoolean.length == 0) && (paramInt1 == 0)) || (paramInt3 == 0)) {
      return paramByte;
    }
    if (paramInt3 - 1 + paramInt2 >= 8) {
      throw new IllegalArgumentException("nBools-1+dstPos is greather or equal to than 8");
    }
    int i = 0;
    if (i < paramInt3)
    {
      int k = i * 1 + paramInt2;
      if (paramArrayOfBoolean[(i + paramInt1)] != 0) {}
      for (int j = 1;; j = 0)
      {
        paramByte = (byte)((1 << k ^ 0xFFFFFFFF) & paramByte | j << k);
        i += 1;
        break;
      }
    }
    return paramByte;
  }
  
  public static char binaryToHexDigit(boolean[] paramArrayOfBoolean)
  {
    return binaryToHexDigit(paramArrayOfBoolean, 0);
  }
  
  public static char binaryToHexDigit(boolean[] paramArrayOfBoolean, int paramInt)
  {
    if (paramArrayOfBoolean.length == 0) {
      throw new IllegalArgumentException("Cannot convert an empty array.");
    }
    if ((paramArrayOfBoolean.length > paramInt + 3) && (paramArrayOfBoolean[(paramInt + 3)] != 0))
    {
      if ((paramArrayOfBoolean.length > paramInt + 2) && (paramArrayOfBoolean[(paramInt + 2)] != 0))
      {
        if ((paramArrayOfBoolean.length > paramInt + 1) && (paramArrayOfBoolean[(paramInt + 1)] != 0))
        {
          if (paramArrayOfBoolean[paramInt] != 0) {
            return 'f';
          }
          return 'e';
        }
        if (paramArrayOfBoolean[paramInt] != 0) {
          return 'd';
        }
        return 'c';
      }
      if ((paramArrayOfBoolean.length > paramInt + 1) && (paramArrayOfBoolean[(paramInt + 1)] != 0))
      {
        if (paramArrayOfBoolean[paramInt] != 0) {
          return 'b';
        }
        return 'a';
      }
      if (paramArrayOfBoolean[paramInt] != 0) {
        return '9';
      }
      return '8';
    }
    if ((paramArrayOfBoolean.length > paramInt + 2) && (paramArrayOfBoolean[(paramInt + 2)] != 0))
    {
      if ((paramArrayOfBoolean.length > paramInt + 1) && (paramArrayOfBoolean[(paramInt + 1)] != 0))
      {
        if (paramArrayOfBoolean[paramInt] != 0) {
          return '7';
        }
        return '6';
      }
      if (paramArrayOfBoolean[paramInt] != 0) {
        return '5';
      }
      return '4';
    }
    if ((paramArrayOfBoolean.length > paramInt + 1) && (paramArrayOfBoolean[(paramInt + 1)] != 0))
    {
      if (paramArrayOfBoolean[paramInt] != 0) {
        return '3';
      }
      return '2';
    }
    if (paramArrayOfBoolean[paramInt] != 0) {
      return '1';
    }
    return '0';
  }
  
  public static char binaryToHexDigitMsb0_4bits(boolean[] paramArrayOfBoolean)
  {
    return binaryToHexDigitMsb0_4bits(paramArrayOfBoolean, 0);
  }
  
  public static char binaryToHexDigitMsb0_4bits(boolean[] paramArrayOfBoolean, int paramInt)
  {
    if (paramArrayOfBoolean.length > 8) {
      throw new IllegalArgumentException("src.length>8: src.length=" + paramArrayOfBoolean.length);
    }
    if (paramArrayOfBoolean.length - paramInt < 4) {
      throw new IllegalArgumentException("src.length-srcPos<4: src.length=" + paramArrayOfBoolean.length + ", srcPos=" + paramInt);
    }
    if (paramArrayOfBoolean[(paramInt + 3)] != 0)
    {
      if (paramArrayOfBoolean[(paramInt + 2)] != 0)
      {
        if (paramArrayOfBoolean[(paramInt + 1)] != 0)
        {
          if (paramArrayOfBoolean[paramInt] != 0) {
            return 'f';
          }
          return '7';
        }
        if (paramArrayOfBoolean[paramInt] != 0) {
          return 'b';
        }
        return '3';
      }
      if (paramArrayOfBoolean[(paramInt + 1)] != 0)
      {
        if (paramArrayOfBoolean[paramInt] != 0) {
          return 'd';
        }
        return '5';
      }
      if (paramArrayOfBoolean[paramInt] != 0) {
        return '9';
      }
      return '1';
    }
    if (paramArrayOfBoolean[(paramInt + 2)] != 0)
    {
      if (paramArrayOfBoolean[(paramInt + 1)] != 0)
      {
        if (paramArrayOfBoolean[paramInt] != 0) {
          return 'e';
        }
        return '6';
      }
      if (paramArrayOfBoolean[paramInt] != 0) {
        return 'a';
      }
      return '2';
    }
    if (paramArrayOfBoolean[(paramInt + 1)] != 0)
    {
      if (paramArrayOfBoolean[paramInt] != 0) {
        return 'c';
      }
      return '4';
    }
    if (paramArrayOfBoolean[paramInt] != 0) {
      return '8';
    }
    return '0';
  }
  
  public static int binaryToInt(boolean[] paramArrayOfBoolean, int paramInt1, int paramInt2, int paramInt3, int paramInt4)
  {
    if (((paramArrayOfBoolean.length == 0) && (paramInt1 == 0)) || (paramInt4 == 0)) {
      return paramInt2;
    }
    if (paramInt4 - 1 + paramInt3 >= 32) {
      throw new IllegalArgumentException("nBools-1+dstPos is greather or equal to than 32");
    }
    int j = 0;
    int i = paramInt2;
    paramInt2 = j;
    if (paramInt2 < paramInt4)
    {
      int k = paramInt2 * 1 + paramInt3;
      if (paramArrayOfBoolean[(paramInt2 + paramInt1)] != 0) {}
      for (j = 1;; j = 0)
      {
        i = (1 << k ^ 0xFFFFFFFF) & i | j << k;
        paramInt2 += 1;
        break;
      }
    }
    return i;
  }
  
  public static long binaryToLong(boolean[] paramArrayOfBoolean, int paramInt1, long paramLong, int paramInt2, int paramInt3)
  {
    if (((paramArrayOfBoolean.length == 0) && (paramInt1 == 0)) || (paramInt3 == 0)) {
      return paramLong;
    }
    if (paramInt3 - 1 + paramInt2 >= 64) {
      throw new IllegalArgumentException("nBools-1+dstPos is greather or equal to than 64");
    }
    int i = 0;
    if (i < paramInt3)
    {
      int j = i * 1 + paramInt2;
      if (paramArrayOfBoolean[(i + paramInt1)] != 0) {}
      for (long l = 1L;; l = 0L)
      {
        paramLong = (0xFFFFFFFFFFFFFFFF ^ 1L << j) & paramLong | l << j;
        i += 1;
        break;
      }
    }
    return paramLong;
  }
  
  public static short binaryToShort(boolean[] paramArrayOfBoolean, int paramInt1, short paramShort, int paramInt2, int paramInt3)
  {
    if (((paramArrayOfBoolean.length == 0) && (paramInt1 == 0)) || (paramInt3 == 0)) {
      return paramShort;
    }
    if (paramInt3 - 1 + paramInt2 >= 16) {
      throw new IllegalArgumentException("nBools-1+dstPos is greather or equal to than 16");
    }
    int i = 0;
    if (i < paramInt3)
    {
      int k = i * 1 + paramInt2;
      if (paramArrayOfBoolean[(i + paramInt1)] != 0) {}
      for (int j = 1;; j = 0)
      {
        paramShort = (short)((1 << k ^ 0xFFFFFFFF) & paramShort | j << k);
        i += 1;
        break;
      }
    }
    return paramShort;
  }
  
  public static int byteArrayToInt(byte[] paramArrayOfByte, int paramInt1, int paramInt2, int paramInt3, int paramInt4)
  {
    if (((paramArrayOfByte.length == 0) && (paramInt1 == 0)) || (paramInt4 == 0)) {
      return paramInt2;
    }
    if ((paramInt4 - 1) * 8 + paramInt3 >= 32) {
      throw new IllegalArgumentException("(nBytes-1)*8+dstPos is greather or equal to than 32");
    }
    int j = 0;
    int i = paramInt2;
    paramInt2 = j;
    while (paramInt2 < paramInt4)
    {
      j = paramInt2 * 8 + paramInt3;
      i = (255 << j ^ 0xFFFFFFFF) & i | (paramArrayOfByte[(paramInt2 + paramInt1)] & 0xFF) << j;
      paramInt2 += 1;
    }
    return i;
  }
  
  public static long byteArrayToLong(byte[] paramArrayOfByte, int paramInt1, long paramLong, int paramInt2, int paramInt3)
  {
    if (((paramArrayOfByte.length == 0) && (paramInt1 == 0)) || (paramInt3 == 0)) {
      return paramLong;
    }
    if ((paramInt3 - 1) * 8 + paramInt2 >= 64) {
      throw new IllegalArgumentException("(nBytes-1)*8+dstPos is greather or equal to than 64");
    }
    int i = 0;
    while (i < paramInt3)
    {
      int j = i * 8 + paramInt2;
      paramLong = (0xFFFFFFFFFFFFFFFF ^ 255L << j) & paramLong | (0xFF & paramArrayOfByte[(i + paramInt1)]) << j;
      i += 1;
    }
    return paramLong;
  }
  
  public static short byteArrayToShort(byte[] paramArrayOfByte, int paramInt1, short paramShort, int paramInt2, int paramInt3)
  {
    if (((paramArrayOfByte.length == 0) && (paramInt1 == 0)) || (paramInt3 == 0)) {
      return paramShort;
    }
    if ((paramInt3 - 1) * 8 + paramInt2 >= 16) {
      throw new IllegalArgumentException("(nBytes-1)*8+dstPos is greather or equal to than 16");
    }
    int i = 0;
    while (i < paramInt3)
    {
      int j = i * 8 + paramInt2;
      paramShort = (short)((255 << j ^ 0xFFFFFFFF) & paramShort | (paramArrayOfByte[(i + paramInt1)] & 0xFF) << j);
      i += 1;
    }
    return paramShort;
  }
  
  public static UUID byteArrayToUuid(byte[] paramArrayOfByte, int paramInt)
  {
    if (paramArrayOfByte.length - paramInt < 16) {
      throw new IllegalArgumentException("Need at least 16 bytes for UUID");
    }
    return new UUID(byteArrayToLong(paramArrayOfByte, paramInt, 0L, 0, 8), byteArrayToLong(paramArrayOfByte, paramInt + 8, 0L, 0, 8));
  }
  
  public static boolean[] byteToBinary(byte paramByte, int paramInt1, boolean[] paramArrayOfBoolean, int paramInt2, int paramInt3)
  {
    if (paramInt3 == 0) {
      return paramArrayOfBoolean;
    }
    if (paramInt3 - 1 + paramInt1 >= 8) {
      throw new IllegalArgumentException("nBools-1+srcPos is greather or equal to than 8");
    }
    int i = 0;
    label31:
    if (i < paramInt3) {
      if ((paramByte >> i * 1 + paramInt1 & 0x1) == 0) {
        break label71;
      }
    }
    label71:
    for (int j = 1;; j = 0)
    {
      paramArrayOfBoolean[(paramInt2 + i)] = j;
      i += 1;
      break label31;
      break;
    }
  }
  
  public static String byteToHex(byte paramByte, int paramInt1, String paramString, int paramInt2, int paramInt3)
  {
    if (paramInt3 == 0) {
      return paramString;
    }
    if ((paramInt3 - 1) * 4 + paramInt1 >= 8) {
      throw new IllegalArgumentException("(nHexs-1)*4+srcPos is greather or equal to than 8");
    }
    paramString = new StringBuilder(paramString);
    int j = paramString.length();
    int i = 0;
    if (i < paramInt3)
    {
      int k = paramByte >> i * 4 + paramInt1 & 0xF;
      if (paramInt2 + i == j)
      {
        j += 1;
        paramString.append(intToHexDigit(k));
      }
      for (;;)
      {
        i += 1;
        break;
        paramString.setCharAt(paramInt2 + i, intToHexDigit(k));
      }
    }
    return paramString.toString();
  }
  
  public static boolean[] hexDigitMsb0ToBinary(char paramChar)
  {
    switch (paramChar)
    {
    default: 
      throw new IllegalArgumentException("Cannot interpret '" + paramChar + "' as a hexadecimal digit");
    case '0': 
      return new boolean[] { 0, 0, 0, 0 };
    case '1': 
      return new boolean[] { 0, 0, 0, 1 };
    case '2': 
      return new boolean[] { 0, 0, 1, 0 };
    case '3': 
      return new boolean[] { 0, 0, 1, 1 };
    case '4': 
      return new boolean[] { 0, 1, 0, 0 };
    case '5': 
      return new boolean[] { 0, 1, 0, 1 };
    case '6': 
      return new boolean[] { 0, 1, 1, 0 };
    case '7': 
      return new boolean[] { 0, 1, 1, 1 };
    case '8': 
      return new boolean[] { 1, 0, 0, 0 };
    case '9': 
      return new boolean[] { 1, 0, 0, 1 };
    case 'A': 
    case 'a': 
      return new boolean[] { 1, 0, 1, 0 };
    case 'B': 
    case 'b': 
      return new boolean[] { 1, 0, 1, 1 };
    case 'C': 
    case 'c': 
      return new boolean[] { 1, 1, 0, 0 };
    case 'D': 
    case 'd': 
      return new boolean[] { 1, 1, 0, 1 };
    case 'E': 
    case 'e': 
      return new boolean[] { 1, 1, 1, 0 };
    }
    return new boolean[] { 1, 1, 1, 1 };
  }
  
  public static int hexDigitMsb0ToInt(char paramChar)
  {
    switch (paramChar)
    {
    default: 
      throw new IllegalArgumentException("Cannot interpret '" + paramChar + "' as a hexadecimal digit");
    case '0': 
      return 0;
    case '1': 
      return 8;
    case '2': 
      return 4;
    case '3': 
      return 12;
    case '4': 
      return 2;
    case '5': 
      return 10;
    case '6': 
      return 6;
    case '7': 
      return 14;
    case '8': 
      return 1;
    case '9': 
      return 9;
    case 'A': 
    case 'a': 
      return 5;
    case 'B': 
    case 'b': 
      return 13;
    case 'C': 
    case 'c': 
      return 3;
    case 'D': 
    case 'd': 
      return 11;
    case 'E': 
    case 'e': 
      return 7;
    }
    return 15;
  }
  
  public static boolean[] hexDigitToBinary(char paramChar)
  {
    switch (paramChar)
    {
    default: 
      throw new IllegalArgumentException("Cannot interpret '" + paramChar + "' as a hexadecimal digit");
    case '0': 
      return new boolean[] { 0, 0, 0, 0 };
    case '1': 
      return new boolean[] { 1, 0, 0, 0 };
    case '2': 
      return new boolean[] { 0, 1, 0, 0 };
    case '3': 
      return new boolean[] { 1, 1, 0, 0 };
    case '4': 
      return new boolean[] { 0, 0, 1, 0 };
    case '5': 
      return new boolean[] { 1, 0, 1, 0 };
    case '6': 
      return new boolean[] { 0, 1, 1, 0 };
    case '7': 
      return new boolean[] { 1, 1, 1, 0 };
    case '8': 
      return new boolean[] { 0, 0, 0, 1 };
    case '9': 
      return new boolean[] { 1, 0, 0, 1 };
    case 'A': 
    case 'a': 
      return new boolean[] { 0, 1, 0, 1 };
    case 'B': 
    case 'b': 
      return new boolean[] { 1, 1, 0, 1 };
    case 'C': 
    case 'c': 
      return new boolean[] { 0, 0, 1, 1 };
    case 'D': 
    case 'd': 
      return new boolean[] { 1, 0, 1, 1 };
    case 'E': 
    case 'e': 
      return new boolean[] { 0, 1, 1, 1 };
    }
    return new boolean[] { 1, 1, 1, 1 };
  }
  
  public static int hexDigitToInt(char paramChar)
  {
    int i = Character.digit(paramChar, 16);
    if (i < 0) {
      throw new IllegalArgumentException("Cannot interpret '" + paramChar + "' as a hexadecimal digit");
    }
    return i;
  }
  
  public static byte hexToByte(String paramString, int paramInt1, byte paramByte, int paramInt2, int paramInt3)
  {
    if (paramInt3 == 0) {
      return paramByte;
    }
    if ((paramInt3 - 1) * 4 + paramInt2 >= 8) {
      throw new IllegalArgumentException("(nHexs-1)*4+dstPos is greather or equal to than 8");
    }
    int i = 0;
    while (i < paramInt3)
    {
      int j = i * 4 + paramInt2;
      paramByte = (byte)((15 << j ^ 0xFFFFFFFF) & paramByte | (hexDigitToInt(paramString.charAt(i + paramInt1)) & 0xF) << j);
      i += 1;
    }
    return paramByte;
  }
  
  public static int hexToInt(String paramString, int paramInt1, int paramInt2, int paramInt3, int paramInt4)
  {
    if (paramInt4 == 0) {
      return paramInt2;
    }
    if ((paramInt4 - 1) * 4 + paramInt3 >= 32) {
      throw new IllegalArgumentException("(nHexs-1)*4+dstPos is greather or equal to than 32");
    }
    int j = 0;
    int i = paramInt2;
    paramInt2 = j;
    while (paramInt2 < paramInt4)
    {
      j = paramInt2 * 4 + paramInt3;
      i = (15 << j ^ 0xFFFFFFFF) & i | (hexDigitToInt(paramString.charAt(paramInt2 + paramInt1)) & 0xF) << j;
      paramInt2 += 1;
    }
    return i;
  }
  
  public static long hexToLong(String paramString, int paramInt1, long paramLong, int paramInt2, int paramInt3)
  {
    if (paramInt3 == 0) {
      return paramLong;
    }
    if ((paramInt3 - 1) * 4 + paramInt2 >= 64) {
      throw new IllegalArgumentException("(nHexs-1)*4+dstPos is greather or equal to than 64");
    }
    int i = 0;
    while (i < paramInt3)
    {
      int j = i * 4 + paramInt2;
      paramLong = (0xFFFFFFFFFFFFFFFF ^ 15L << j) & paramLong | (0xF & hexDigitToInt(paramString.charAt(i + paramInt1))) << j;
      i += 1;
    }
    return paramLong;
  }
  
  public static short hexToShort(String paramString, int paramInt1, short paramShort, int paramInt2, int paramInt3)
  {
    if (paramInt3 == 0) {
      return paramShort;
    }
    if ((paramInt3 - 1) * 4 + paramInt2 >= 16) {
      throw new IllegalArgumentException("(nHexs-1)*4+dstPos is greather or equal to than 16");
    }
    int i = 0;
    while (i < paramInt3)
    {
      int j = i * 4 + paramInt2;
      paramShort = (short)((15 << j ^ 0xFFFFFFFF) & paramShort | (hexDigitToInt(paramString.charAt(i + paramInt1)) & 0xF) << j);
      i += 1;
    }
    return paramShort;
  }
  
  public static long intArrayToLong(int[] paramArrayOfInt, int paramInt1, long paramLong, int paramInt2, int paramInt3)
  {
    if (((paramArrayOfInt.length == 0) && (paramInt1 == 0)) || (paramInt3 == 0)) {
      return paramLong;
    }
    if ((paramInt3 - 1) * 32 + paramInt2 >= 64) {
      throw new IllegalArgumentException("(nInts-1)*32+dstPos is greather or equal to than 64");
    }
    int i = 0;
    while (i < paramInt3)
    {
      int j = i * 32 + paramInt2;
      paramLong = (0xFFFFFFFFFFFFFFFF ^ 4294967295L << j) & paramLong | (0xFFFFFFFF & paramArrayOfInt[(i + paramInt1)]) << j;
      i += 1;
    }
    return paramLong;
  }
  
  public static boolean[] intToBinary(int paramInt1, int paramInt2, boolean[] paramArrayOfBoolean, int paramInt3, int paramInt4)
  {
    if (paramInt4 == 0) {
      return paramArrayOfBoolean;
    }
    if (paramInt4 - 1 + paramInt2 >= 32) {
      throw new IllegalArgumentException("nBools-1+srcPos is greather or equal to than 32");
    }
    int i = 0;
    label31:
    if (i < paramInt4) {
      if ((paramInt1 >> i * 1 + paramInt2 & 0x1) == 0) {
        break label71;
      }
    }
    label71:
    for (int j = 1;; j = 0)
    {
      paramArrayOfBoolean[(paramInt3 + i)] = j;
      i += 1;
      break label31;
      break;
    }
  }
  
  public static byte[] intToByteArray(int paramInt1, int paramInt2, byte[] paramArrayOfByte, int paramInt3, int paramInt4)
  {
    if (paramInt4 == 0) {}
    for (;;)
    {
      return paramArrayOfByte;
      if ((paramInt4 - 1) * 8 + paramInt2 >= 32) {
        throw new IllegalArgumentException("(nBytes-1)*8+srcPos is greather or equal to than 32");
      }
      int i = 0;
      while (i < paramInt4)
      {
        paramArrayOfByte[(paramInt3 + i)] = ((byte)(paramInt1 >> i * 8 + paramInt2 & 0xFF));
        i += 1;
      }
    }
  }
  
  public static String intToHex(int paramInt1, int paramInt2, String paramString, int paramInt3, int paramInt4)
  {
    if (paramInt4 == 0) {
      return paramString;
    }
    if ((paramInt4 - 1) * 4 + paramInt2 >= 32) {
      throw new IllegalArgumentException("(nHexs-1)*4+srcPos is greather or equal to than 32");
    }
    paramString = new StringBuilder(paramString);
    int j = paramString.length();
    int i = 0;
    if (i < paramInt4)
    {
      int k = paramInt1 >> i * 4 + paramInt2 & 0xF;
      if (paramInt3 + i == j)
      {
        j += 1;
        paramString.append(intToHexDigit(k));
      }
      for (;;)
      {
        i += 1;
        break;
        paramString.setCharAt(paramInt3 + i, intToHexDigit(k));
      }
    }
    return paramString.toString();
  }
  
  public static char intToHexDigit(int paramInt)
  {
    char c = Character.forDigit(paramInt, 16);
    if (c == 0) {
      throw new IllegalArgumentException("nibble value not between 0 and 15: " + paramInt);
    }
    return c;
  }
  
  public static char intToHexDigitMsb0(int paramInt)
  {
    switch (paramInt)
    {
    default: 
      throw new IllegalArgumentException("nibble value not between 0 and 15: " + paramInt);
    case 0: 
      return '0';
    case 1: 
      return '8';
    case 2: 
      return '4';
    case 3: 
      return 'c';
    case 4: 
      return '2';
    case 5: 
      return 'a';
    case 6: 
      return '6';
    case 7: 
      return 'e';
    case 8: 
      return '1';
    case 9: 
      return '9';
    case 10: 
      return '5';
    case 11: 
      return 'd';
    case 12: 
      return '3';
    case 13: 
      return 'b';
    case 14: 
      return '7';
    }
    return 'f';
  }
  
  public static short[] intToShortArray(int paramInt1, int paramInt2, short[] paramArrayOfShort, int paramInt3, int paramInt4)
  {
    if (paramInt4 == 0) {}
    for (;;)
    {
      return paramArrayOfShort;
      if ((paramInt4 - 1) * 16 + paramInt2 >= 32) {
        throw new IllegalArgumentException("(nShorts-1)*16+srcPos is greather or equal to than 32");
      }
      int i = 0;
      while (i < paramInt4)
      {
        paramArrayOfShort[(paramInt3 + i)] = ((short)(0xFFFF & paramInt1 >> i * 16 + paramInt2));
        i += 1;
      }
    }
  }
  
  public static boolean[] longToBinary(long paramLong, int paramInt1, boolean[] paramArrayOfBoolean, int paramInt2, int paramInt3)
  {
    if (paramInt3 == 0) {
      return paramArrayOfBoolean;
    }
    if (paramInt3 - 1 + paramInt1 >= 64) {
      throw new IllegalArgumentException("nBools-1+srcPos is greather or equal to than 64");
    }
    int i = 0;
    label31:
    if (i < paramInt3) {
      if ((1L & paramLong >> i * 1 + paramInt1) == 0L) {
        break label74;
      }
    }
    label74:
    for (int j = 1;; j = 0)
    {
      paramArrayOfBoolean[(paramInt2 + i)] = j;
      i += 1;
      break label31;
      break;
    }
  }
  
  public static byte[] longToByteArray(long paramLong, int paramInt1, byte[] paramArrayOfByte, int paramInt2, int paramInt3)
  {
    if (paramInt3 == 0) {}
    for (;;)
    {
      return paramArrayOfByte;
      if ((paramInt3 - 1) * 8 + paramInt1 >= 64) {
        throw new IllegalArgumentException("(nBytes-1)*8+srcPos is greather or equal to than 64");
      }
      int i = 0;
      while (i < paramInt3)
      {
        paramArrayOfByte[(paramInt2 + i)] = ((byte)(int)(0xFF & paramLong >> i * 8 + paramInt1));
        i += 1;
      }
    }
  }
  
  public static String longToHex(long paramLong, int paramInt1, String paramString, int paramInt2, int paramInt3)
  {
    if (paramInt3 == 0) {
      return paramString;
    }
    if ((paramInt3 - 1) * 4 + paramInt1 >= 64) {
      throw new IllegalArgumentException("(nHexs-1)*4+srcPos is greather or equal to than 64");
    }
    paramString = new StringBuilder(paramString);
    int j = paramString.length();
    int i = 0;
    if (i < paramInt3)
    {
      int k = (int)(0xF & paramLong >> i * 4 + paramInt1);
      if (paramInt2 + i == j)
      {
        j += 1;
        paramString.append(intToHexDigit(k));
      }
      for (;;)
      {
        i += 1;
        break;
        paramString.setCharAt(paramInt2 + i, intToHexDigit(k));
      }
    }
    return paramString.toString();
  }
  
  public static int[] longToIntArray(long paramLong, int paramInt1, int[] paramArrayOfInt, int paramInt2, int paramInt3)
  {
    if (paramInt3 == 0) {}
    for (;;)
    {
      return paramArrayOfInt;
      if ((paramInt3 - 1) * 32 + paramInt1 >= 64) {
        throw new IllegalArgumentException("(nInts-1)*32+srcPos is greather or equal to than 64");
      }
      int i = 0;
      while (i < paramInt3)
      {
        paramArrayOfInt[(paramInt2 + i)] = ((int)(0xFFFFFFFFFFFFFFFF & paramLong >> i * 32 + paramInt1));
        i += 1;
      }
    }
  }
  
  public static short[] longToShortArray(long paramLong, int paramInt1, short[] paramArrayOfShort, int paramInt2, int paramInt3)
  {
    if (paramInt3 == 0) {}
    for (;;)
    {
      return paramArrayOfShort;
      if ((paramInt3 - 1) * 16 + paramInt1 >= 64) {
        throw new IllegalArgumentException("(nShorts-1)*16+srcPos is greather or equal to than 64");
      }
      int i = 0;
      while (i < paramInt3)
      {
        paramArrayOfShort[(paramInt2 + i)] = ((short)(int)(0xFFFF & paramLong >> i * 16 + paramInt1));
        i += 1;
      }
    }
  }
  
  public static int shortArrayToInt(short[] paramArrayOfShort, int paramInt1, int paramInt2, int paramInt3, int paramInt4)
  {
    if (((paramArrayOfShort.length == 0) && (paramInt1 == 0)) || (paramInt4 == 0)) {
      return paramInt2;
    }
    if ((paramInt4 - 1) * 16 + paramInt3 >= 32) {
      throw new IllegalArgumentException("(nShorts-1)*16+dstPos is greather or equal to than 32");
    }
    int j = 0;
    int i = paramInt2;
    paramInt2 = j;
    while (paramInt2 < paramInt4)
    {
      j = paramInt2 * 16 + paramInt3;
      i = (65535 << j ^ 0xFFFFFFFF) & i | (paramArrayOfShort[(paramInt2 + paramInt1)] & 0xFFFF) << j;
      paramInt2 += 1;
    }
    return i;
  }
  
  public static long shortArrayToLong(short[] paramArrayOfShort, int paramInt1, long paramLong, int paramInt2, int paramInt3)
  {
    if (((paramArrayOfShort.length == 0) && (paramInt1 == 0)) || (paramInt3 == 0)) {
      return paramLong;
    }
    if ((paramInt3 - 1) * 16 + paramInt2 >= 64) {
      throw new IllegalArgumentException("(nShorts-1)*16+dstPos is greather or equal to than 64");
    }
    int i = 0;
    while (i < paramInt3)
    {
      int j = i * 16 + paramInt2;
      paramLong = (0xFFFFFFFFFFFFFFFF ^ 65535L << j) & paramLong | (0xFFFF & paramArrayOfShort[(i + paramInt1)]) << j;
      i += 1;
    }
    return paramLong;
  }
  
  public static boolean[] shortToBinary(short paramShort, int paramInt1, boolean[] paramArrayOfBoolean, int paramInt2, int paramInt3)
  {
    if (paramInt3 == 0) {
      return paramArrayOfBoolean;
    }
    if (paramInt3 - 1 + paramInt1 >= 16) {
      throw new IllegalArgumentException("nBools-1+srcPos is greather or equal to than 16");
    }
    assert ((paramInt3 - 1) * 1 < 16 - paramInt1);
    int i = 0;
    label58:
    if (i < paramInt3) {
      if ((paramShort >> i * 1 + paramInt1 & 0x1) == 0) {
        break label98;
      }
    }
    label98:
    for (int j = 1;; j = 0)
    {
      paramArrayOfBoolean[(paramInt2 + i)] = j;
      i += 1;
      break label58;
      break;
    }
  }
  
  public static byte[] shortToByteArray(short paramShort, int paramInt1, byte[] paramArrayOfByte, int paramInt2, int paramInt3)
  {
    if (paramInt3 == 0) {}
    for (;;)
    {
      return paramArrayOfByte;
      if ((paramInt3 - 1) * 8 + paramInt1 >= 16) {
        throw new IllegalArgumentException("(nBytes-1)*8+srcPos is greather or equal to than 16");
      }
      int i = 0;
      while (i < paramInt3)
      {
        paramArrayOfByte[(paramInt2 + i)] = ((byte)(paramShort >> i * 8 + paramInt1 & 0xFF));
        i += 1;
      }
    }
  }
  
  public static String shortToHex(short paramShort, int paramInt1, String paramString, int paramInt2, int paramInt3)
  {
    if (paramInt3 == 0) {
      return paramString;
    }
    if ((paramInt3 - 1) * 4 + paramInt1 >= 16) {
      throw new IllegalArgumentException("(nHexs-1)*4+srcPos is greather or equal to than 16");
    }
    paramString = new StringBuilder(paramString);
    int j = paramString.length();
    int i = 0;
    if (i < paramInt3)
    {
      int k = paramShort >> i * 4 + paramInt1 & 0xF;
      if (paramInt2 + i == j)
      {
        j += 1;
        paramString.append(intToHexDigit(k));
      }
      for (;;)
      {
        i += 1;
        break;
        paramString.setCharAt(paramInt2 + i, intToHexDigit(k));
      }
    }
    return paramString.toString();
  }
  
  public static byte[] uuidToByteArray(UUID paramUUID, byte[] paramArrayOfByte, int paramInt1, int paramInt2)
  {
    if (paramInt2 == 0) {
      return paramArrayOfByte;
    }
    if (paramInt2 > 16) {
      throw new IllegalArgumentException("nBytes is greather than 16");
    }
    long l = paramUUID.getMostSignificantBits();
    if (paramInt2 > 8) {}
    for (int i = 8;; i = paramInt2)
    {
      longToByteArray(l, 0, paramArrayOfByte, paramInt1, i);
      if (paramInt2 < 8) {
        break;
      }
      longToByteArray(paramUUID.getLeastSignificantBits(), 0, paramArrayOfByte, paramInt1 + 8, paramInt2 - 8);
      return paramArrayOfByte;
    }
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\org\apache\commons\lang3\Conversion.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */