package org.apache.commons.lang3.time;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;
import java.util.TimeZone;
import org.apache.commons.lang3.StringUtils;

public class DurationFormatUtils
{
  static final Object H;
  public static final String ISO_EXTENDED_FORMAT_PATTERN = "'P'yyyy'Y'M'M'd'DT'H'H'm'M's.S'S'";
  static final Object M;
  static final Object S = "S";
  static final Object d;
  static final Object m;
  static final Object s;
  static final Object y = "y";
  
  static
  {
    M = "M";
    d = "d";
    H = "H";
    m = "m";
    s = "s";
  }
  
  static String format(Token[] paramArrayOfToken, long paramLong1, long paramLong2, long paramLong3, long paramLong4, long paramLong5, long paramLong6, long paramLong7, boolean paramBoolean)
  {
    StringBuilder localStringBuilder = new StringBuilder();
    int k = 0;
    int n = paramArrayOfToken.length;
    int j = 0;
    if (j < n)
    {
      Token localToken = paramArrayOfToken[j];
      Object localObject = localToken.getValue();
      int i1 = localToken.getCount();
      int i;
      if ((localObject instanceof StringBuilder))
      {
        localStringBuilder.append(localObject.toString());
        i = k;
      }
      label254:
      do
      {
        for (;;)
        {
          j += 1;
          k = i;
          break;
          if (localObject == y)
          {
            localStringBuilder.append(paddedValue(paramLong1, paramBoolean, i1));
            i = 0;
          }
          else if (localObject == M)
          {
            localStringBuilder.append(paddedValue(paramLong2, paramBoolean, i1));
            i = 0;
          }
          else if (localObject == d)
          {
            localStringBuilder.append(paddedValue(paramLong3, paramBoolean, i1));
            i = 0;
          }
          else if (localObject == H)
          {
            localStringBuilder.append(paddedValue(paramLong4, paramBoolean, i1));
            i = 0;
          }
          else if (localObject == m)
          {
            localStringBuilder.append(paddedValue(paramLong5, paramBoolean, i1));
            i = 0;
          }
          else
          {
            if (localObject != s) {
              break label254;
            }
            localStringBuilder.append(paddedValue(paramLong6, paramBoolean, i1));
            i = 1;
          }
        }
        i = k;
      } while (localObject != S);
      if (k != 0) {
        if (paramBoolean)
        {
          i = Math.max(3, i1);
          label284:
          localStringBuilder.append(paddedValue(paramLong7, true, i));
        }
      }
      for (;;)
      {
        i = 0;
        break;
        i = 3;
        break label284;
        localStringBuilder.append(paddedValue(paramLong7, paramBoolean, i1));
      }
    }
    return localStringBuilder.toString();
  }
  
  public static String formatDuration(long paramLong, String paramString)
  {
    return formatDuration(paramLong, paramString, true);
  }
  
  public static String formatDuration(long paramLong, String paramString, boolean paramBoolean)
  {
    paramString = lexx(paramString);
    long l2 = 0L;
    long l3 = 0L;
    long l4 = 0L;
    long l5 = 0L;
    long l1 = paramLong;
    paramLong = l1;
    if (Token.containsTokenWithValue(paramString, d))
    {
      l2 = l1 / 86400000L;
      paramLong = l1 - 86400000L * l2;
    }
    l1 = paramLong;
    if (Token.containsTokenWithValue(paramString, H))
    {
      l3 = paramLong / 3600000L;
      l1 = paramLong - 3600000L * l3;
    }
    paramLong = l1;
    if (Token.containsTokenWithValue(paramString, m))
    {
      l4 = l1 / 60000L;
      paramLong = l1 - 60000L * l4;
    }
    l1 = paramLong;
    if (Token.containsTokenWithValue(paramString, s))
    {
      l5 = paramLong / 1000L;
      l1 = paramLong - 1000L * l5;
    }
    return format(paramString, 0L, 0L, l2, l3, l4, l5, l1, paramBoolean);
  }
  
  public static String formatDurationHMS(long paramLong)
  {
    return formatDuration(paramLong, "H:mm:ss.SSS");
  }
  
  public static String formatDurationISO(long paramLong)
  {
    return formatDuration(paramLong, "'P'yyyy'Y'M'M'd'DT'H'H'm'M's.S'S'", false);
  }
  
  public static String formatDurationWords(long paramLong, boolean paramBoolean1, boolean paramBoolean2)
  {
    Object localObject1 = formatDuration(paramLong, "d' days 'H' hours 'm' minutes 's' seconds'");
    Object localObject2 = localObject1;
    String str;
    if (paramBoolean1)
    {
      localObject2 = " " + (String)localObject1;
      str = StringUtils.replaceOnce((String)localObject2, " 0 days", "");
      localObject1 = localObject2;
      if (str.length() != ((String)localObject2).length())
      {
        localObject2 = str;
        str = StringUtils.replaceOnce((String)localObject2, " 0 hours", "");
        localObject1 = localObject2;
        if (str.length() != ((String)localObject2).length())
        {
          str = StringUtils.replaceOnce(str, " 0 minutes", "");
          localObject2 = str;
          localObject1 = localObject2;
          if (str.length() != ((String)localObject2).length()) {
            localObject1 = StringUtils.replaceOnce(str, " 0 seconds", "");
          }
        }
      }
      localObject2 = localObject1;
      if (((String)localObject1).length() != 0) {
        localObject2 = ((String)localObject1).substring(1);
      }
    }
    localObject1 = localObject2;
    if (paramBoolean2)
    {
      str = StringUtils.replaceOnce((String)localObject2, " 0 seconds", "");
      localObject1 = localObject2;
      if (str.length() != ((String)localObject2).length())
      {
        localObject2 = str;
        str = StringUtils.replaceOnce((String)localObject2, " 0 minutes", "");
        localObject1 = localObject2;
        if (str.length() != ((String)localObject2).length())
        {
          localObject2 = str;
          str = StringUtils.replaceOnce((String)localObject2, " 0 hours", "");
          localObject1 = localObject2;
          if (str.length() != ((String)localObject2).length()) {
            localObject1 = StringUtils.replaceOnce(str, " 0 days", "");
          }
        }
      }
    }
    return StringUtils.replaceOnce(StringUtils.replaceOnce(StringUtils.replaceOnce(StringUtils.replaceOnce(" " + (String)localObject1, " 1 seconds", " 1 second"), " 1 minutes", " 1 minute"), " 1 hours", " 1 hour"), " 1 days", " 1 day").trim();
  }
  
  public static String formatPeriod(long paramLong1, long paramLong2, String paramString)
  {
    return formatPeriod(paramLong1, paramLong2, paramString, true, TimeZone.getDefault());
  }
  
  public static String formatPeriod(long paramLong1, long paramLong2, String paramString, boolean paramBoolean, TimeZone paramTimeZone)
  {
    paramString = lexx(paramString);
    Calendar localCalendar = Calendar.getInstance(paramTimeZone);
    localCalendar.setTime(new Date(paramLong1));
    paramTimeZone = Calendar.getInstance(paramTimeZone);
    paramTimeZone.setTime(new Date(paramLong2));
    int k = paramTimeZone.get(14) - localCalendar.get(14);
    int j = paramTimeZone.get(13) - localCalendar.get(13);
    int i1 = paramTimeZone.get(12) - localCalendar.get(12);
    int i2 = paramTimeZone.get(11) - localCalendar.get(11);
    int i3 = paramTimeZone.get(5) - localCalendar.get(5);
    int i6 = paramTimeZone.get(2) - localCalendar.get(2);
    int i4 = paramTimeZone.get(1) - localCalendar.get(1);
    for (;;)
    {
      i = i1;
      n = j;
      if (k >= 0) {
        break;
      }
      k += 1000;
      j -= 1;
    }
    for (;;)
    {
      j = i2;
      i1 = i;
      if (n >= 0) {
        break;
      }
      n += 60;
      i -= 1;
    }
    for (;;)
    {
      i = i3;
      i2 = j;
      if (i1 >= 0) {
        break;
      }
      i1 += 60;
      j -= 1;
    }
    while (i2 < 0)
    {
      i2 += 24;
      i -= 1;
    }
    if (Token.containsTokenWithValue(paramString, M))
    {
      i3 = i6;
      i5 = i;
      for (;;)
      {
        i = i3;
        j = i4;
        if (i5 >= 0) {
          break;
        }
        i5 += localCalendar.getActualMaximum(5);
        i3 -= 1;
        localCalendar.add(2, 1);
      }
      while (i < 0)
      {
        i += 12;
        j -= 1;
      }
      i6 = i5;
      i3 = i;
      i4 = j;
      if (!Token.containsTokenWithValue(paramString, y))
      {
        i6 = i5;
        i3 = i;
        i4 = j;
        if (j != 0) {
          for (;;)
          {
            i6 = i5;
            i3 = i;
            i4 = j;
            if (j == 0) {
              break;
            }
            i += j * 12;
            j = 0;
          }
        }
      }
    }
    else
    {
      j = i;
      i5 = i4;
      if (!Token.containsTokenWithValue(paramString, y))
      {
        i4 = paramTimeZone.get(1);
        j = i;
        i3 = i4;
        if (i6 < 0) {
          i3 = i4 - 1;
        }
        for (j = i; localCalendar.get(1) != i3; j = i + localCalendar.get(6))
        {
          j += localCalendar.getActualMaximum(6) - localCalendar.get(6);
          i = j;
          if ((localCalendar instanceof GregorianCalendar))
          {
            i = j;
            if (localCalendar.get(2) == 1)
            {
              i = j;
              if (localCalendar.get(5) == 29) {
                i = j + 1;
              }
            }
          }
          localCalendar.add(1, 1);
        }
        i5 = 0;
      }
      while (localCalendar.get(2) != paramTimeZone.get(2))
      {
        j += localCalendar.getActualMaximum(5);
        localCalendar.add(2, 1);
      }
      i = 0;
      for (;;)
      {
        i6 = j;
        i3 = i;
        i4 = i5;
        if (j >= 0) {
          break;
        }
        j += localCalendar.getActualMaximum(5);
        i -= 1;
        localCalendar.add(2, 1);
      }
    }
    int i5 = i6;
    int i = i2;
    if (!Token.containsTokenWithValue(paramString, d))
    {
      i = i2 + i6 * 24;
      i5 = 0;
    }
    i2 = i;
    j = i1;
    if (!Token.containsTokenWithValue(paramString, H))
    {
      j = i1 + i * 60;
      i2 = 0;
    }
    i1 = j;
    i = n;
    if (!Token.containsTokenWithValue(paramString, m))
    {
      i = n + j * 60;
      i1 = 0;
    }
    int n = k;
    j = i;
    if (!Token.containsTokenWithValue(paramString, s))
    {
      n = k + i * 1000;
      j = 0;
    }
    return format(paramString, i4, i3, i5, i2, i1, j, n, paramBoolean);
  }
  
  public static String formatPeriodISO(long paramLong1, long paramLong2)
  {
    return formatPeriod(paramLong1, paramLong2, "'P'yyyy'Y'M'M'd'DT'H'H'm'M's.S'S'", false, TimeZone.getDefault());
  }
  
  static Token[] lexx(String paramString)
  {
    ArrayList localArrayList = new ArrayList(paramString.length());
    int i = 0;
    Object localObject2 = null;
    Object localObject3 = null;
    int j = 0;
    if (j < paramString.length())
    {
      char c = paramString.charAt(j);
      Object localObject4;
      int k;
      if ((i != 0) && (c != '\''))
      {
        ((StringBuilder)localObject2).append(c);
        localObject4 = localObject3;
        k = i;
      }
      Object localObject1;
      label201:
      do
      {
        j += 1;
        i = k;
        localObject3 = localObject4;
        break;
        localObject1 = null;
        switch (c)
        {
        default: 
          localObject4 = localObject2;
          if (localObject2 == null)
          {
            localObject4 = new StringBuilder();
            localArrayList.add(new Token(localObject4));
          }
          ((StringBuilder)localObject4).append(c);
          localObject2 = localObject4;
          k = i;
          localObject4 = localObject3;
        }
      } while (localObject1 == null);
      if ((localObject3 != null) && (((Token)localObject3).getValue() == localObject1)) {
        ((Token)localObject3).increment();
      }
      for (;;)
      {
        localObject2 = null;
        k = i;
        localObject4 = localObject3;
        break;
        if (i != 0)
        {
          localObject2 = null;
          i = 0;
          break label201;
        }
        localObject2 = new StringBuilder();
        localArrayList.add(new Token(localObject2));
        i = 1;
        break label201;
        localObject1 = y;
        break label201;
        localObject1 = M;
        break label201;
        localObject1 = d;
        break label201;
        localObject1 = H;
        break label201;
        localObject1 = m;
        break label201;
        localObject1 = s;
        break label201;
        localObject1 = S;
        break label201;
        localObject3 = new Token(localObject1);
        localArrayList.add(localObject3);
      }
    }
    if (i != 0) {
      throw new IllegalArgumentException("Unmatched quote in format: " + paramString);
    }
    return (Token[])localArrayList.toArray(new Token[localArrayList.size()]);
  }
  
  private static String paddedValue(long paramLong, boolean paramBoolean, int paramInt)
  {
    String str2 = Long.toString(paramLong);
    String str1 = str2;
    if (paramBoolean) {
      str1 = StringUtils.leftPad(str2, paramInt, '0');
    }
    return str1;
  }
  
  static class Token
  {
    private int count;
    private final Object value;
    
    Token(Object paramObject)
    {
      this.value = paramObject;
      this.count = 1;
    }
    
    Token(Object paramObject, int paramInt)
    {
      this.value = paramObject;
      this.count = paramInt;
    }
    
    static boolean containsTokenWithValue(Token[] paramArrayOfToken, Object paramObject)
    {
      int j = paramArrayOfToken.length;
      int i = 0;
      while (i < j)
      {
        if (paramArrayOfToken[i].getValue() == paramObject) {
          return true;
        }
        i += 1;
      }
      return false;
    }
    
    public boolean equals(Object paramObject)
    {
      if ((paramObject instanceof Token))
      {
        paramObject = (Token)paramObject;
        if (this.value.getClass() == ((Token)paramObject).value.getClass()) {
          break label31;
        }
      }
      label31:
      do
      {
        do
        {
          return false;
        } while (this.count != ((Token)paramObject).count);
        if ((this.value instanceof StringBuilder)) {
          return this.value.toString().equals(((Token)paramObject).value.toString());
        }
        if ((this.value instanceof Number)) {
          return this.value.equals(((Token)paramObject).value);
        }
      } while (this.value != ((Token)paramObject).value);
      return true;
    }
    
    int getCount()
    {
      return this.count;
    }
    
    Object getValue()
    {
      return this.value;
    }
    
    public int hashCode()
    {
      return this.value.hashCode();
    }
    
    void increment()
    {
      this.count += 1;
    }
    
    public String toString()
    {
      return StringUtils.repeat(this.value.toString(), this.count);
    }
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\org\apache\commons\lang3\time\DurationFormatUtils.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */