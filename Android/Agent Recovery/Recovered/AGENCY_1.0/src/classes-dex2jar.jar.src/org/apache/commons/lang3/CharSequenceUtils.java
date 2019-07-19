package org.apache.commons.lang3;

public class CharSequenceUtils
{
  static int indexOf(CharSequence paramCharSequence, int paramInt1, int paramInt2)
  {
    if ((paramCharSequence instanceof String))
    {
      i = ((String)paramCharSequence).indexOf(paramInt1, paramInt2);
      return i;
    }
    int j = paramCharSequence.length();
    int i = paramInt2;
    if (paramInt2 < 0) {
      i = 0;
    }
    paramInt2 = i;
    for (;;)
    {
      if (paramInt2 >= j) {
        break label63;
      }
      i = paramInt2;
      if (paramCharSequence.charAt(paramInt2) == paramInt1) {
        break;
      }
      paramInt2 += 1;
    }
    label63:
    return -1;
  }
  
  static int indexOf(CharSequence paramCharSequence1, CharSequence paramCharSequence2, int paramInt)
  {
    return paramCharSequence1.toString().indexOf(paramCharSequence2.toString(), paramInt);
  }
  
  static int lastIndexOf(CharSequence paramCharSequence, int paramInt1, int paramInt2)
  {
    if ((paramCharSequence instanceof String))
    {
      i = ((String)paramCharSequence).lastIndexOf(paramInt1, paramInt2);
      return i;
    }
    int j = paramCharSequence.length();
    if (paramInt2 < 0) {
      return -1;
    }
    int i = paramInt2;
    if (paramInt2 >= j) {
      i = j - 1;
    }
    paramInt2 = i;
    for (;;)
    {
      if (paramInt2 < 0) {
        break label72;
      }
      i = paramInt2;
      if (paramCharSequence.charAt(paramInt2) == paramInt1) {
        break;
      }
      paramInt2 -= 1;
    }
    label72:
    return -1;
  }
  
  static int lastIndexOf(CharSequence paramCharSequence1, CharSequence paramCharSequence2, int paramInt)
  {
    return paramCharSequence1.toString().lastIndexOf(paramCharSequence2.toString(), paramInt);
  }
  
  static boolean regionMatches(CharSequence paramCharSequence1, boolean paramBoolean, int paramInt1, CharSequence paramCharSequence2, int paramInt2, int paramInt3)
  {
    if (((paramCharSequence1 instanceof String)) && ((paramCharSequence2 instanceof String))) {
      return ((String)paramCharSequence1).regionMatches(paramBoolean, paramInt1, (String)paramCharSequence2, paramInt2, paramInt3);
    }
    for (;;)
    {
      int i = paramInt3 - 1;
      if (paramInt3 <= 0) {
        break;
      }
      paramInt3 = paramInt1 + 1;
      char c1 = paramCharSequence1.charAt(paramInt1);
      paramInt1 = paramInt2 + 1;
      char c2 = paramCharSequence2.charAt(paramInt2);
      if (c1 == c2)
      {
        paramInt2 = paramInt1;
        paramInt1 = paramInt3;
        paramInt3 = i;
      }
      else
      {
        if (!paramBoolean) {
          return false;
        }
        if ((Character.toUpperCase(c1) != Character.toUpperCase(c2)) && (Character.toLowerCase(c1) != Character.toLowerCase(c2))) {
          return false;
        }
        paramInt2 = paramInt1;
        paramInt1 = paramInt3;
        paramInt3 = i;
      }
    }
    return true;
  }
  
  public static CharSequence subSequence(CharSequence paramCharSequence, int paramInt)
  {
    if (paramCharSequence == null) {
      return null;
    }
    return paramCharSequence.subSequence(paramInt, paramCharSequence.length());
  }
  
  static char[] toCharArray(CharSequence paramCharSequence)
  {
    Object localObject;
    if ((paramCharSequence instanceof String))
    {
      localObject = ((String)paramCharSequence).toCharArray();
      return (char[])localObject;
    }
    int j = paramCharSequence.length();
    char[] arrayOfChar = new char[paramCharSequence.length()];
    int i = 0;
    for (;;)
    {
      localObject = arrayOfChar;
      if (i >= j) {
        break;
      }
      arrayOfChar[i] = paramCharSequence.charAt(i);
      i += 1;
    }
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\org\apache\commons\lang3\CharSequenceUtils.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */