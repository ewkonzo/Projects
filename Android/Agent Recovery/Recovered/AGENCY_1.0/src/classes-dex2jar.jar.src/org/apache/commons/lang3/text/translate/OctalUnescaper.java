package org.apache.commons.lang3.text.translate;

import java.io.IOException;
import java.io.Writer;

public class OctalUnescaper
  extends CharSequenceTranslator
{
  private boolean isOctalDigit(char paramChar)
  {
    return (paramChar >= '0') && (paramChar <= '7');
  }
  
  private boolean isZeroToThree(char paramChar)
  {
    return (paramChar >= '0') && (paramChar <= '3');
  }
  
  public int translate(CharSequence paramCharSequence, int paramInt, Writer paramWriter)
    throws IOException
  {
    int i = paramCharSequence.length() - paramInt - 1;
    StringBuilder localStringBuilder = new StringBuilder();
    if ((paramCharSequence.charAt(paramInt) == '\\') && (i > 0) && (isOctalDigit(paramCharSequence.charAt(paramInt + 1))))
    {
      int j = paramInt + 1;
      int k = paramInt + 2;
      paramInt += 3;
      localStringBuilder.append(paramCharSequence.charAt(j));
      if ((i > 1) && (isOctalDigit(paramCharSequence.charAt(k))))
      {
        localStringBuilder.append(paramCharSequence.charAt(k));
        if ((i > 2) && (isZeroToThree(paramCharSequence.charAt(j))) && (isOctalDigit(paramCharSequence.charAt(paramInt)))) {
          localStringBuilder.append(paramCharSequence.charAt(paramInt));
        }
      }
      paramWriter.write(Integer.parseInt(localStringBuilder.toString(), 8));
      return localStringBuilder.length() + 1;
    }
    return 0;
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\org\apache\commons\lang3\text\translate\OctalUnescaper.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */