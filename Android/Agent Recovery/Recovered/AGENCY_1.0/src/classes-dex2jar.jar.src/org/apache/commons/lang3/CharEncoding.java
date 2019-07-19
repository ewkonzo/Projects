package org.apache.commons.lang3;

import java.nio.charset.Charset;
import java.nio.charset.IllegalCharsetNameException;

public class CharEncoding
{
  public static final String ISO_8859_1 = "ISO-8859-1";
  public static final String US_ASCII = "US-ASCII";
  public static final String UTF_16 = "UTF-16";
  public static final String UTF_16BE = "UTF-16BE";
  public static final String UTF_16LE = "UTF-16LE";
  public static final String UTF_8 = "UTF-8";
  
  public static boolean isSupported(String paramString)
  {
    if (paramString == null) {
      return false;
    }
    try
    {
      boolean bool = Charset.isSupported(paramString);
      return bool;
    }
    catch (IllegalCharsetNameException paramString) {}
    return false;
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\org\apache\commons\lang3\CharEncoding.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */