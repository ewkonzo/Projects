package org.apache.commons.lang3;

public class NotImplementedException
  extends UnsupportedOperationException
{
  private static final long serialVersionUID = 20131021L;
  private final String code;
  
  public NotImplementedException(String paramString)
  {
    this(paramString, (String)null);
  }
  
  public NotImplementedException(String paramString1, String paramString2)
  {
    super(paramString1);
    this.code = paramString2;
  }
  
  public NotImplementedException(String paramString, Throwable paramThrowable)
  {
    this(paramString, paramThrowable, null);
  }
  
  public NotImplementedException(String paramString1, Throwable paramThrowable, String paramString2)
  {
    super(paramString1, paramThrowable);
    this.code = paramString2;
  }
  
  public NotImplementedException(Throwable paramThrowable)
  {
    this(paramThrowable, null);
  }
  
  public NotImplementedException(Throwable paramThrowable, String paramString)
  {
    super(paramThrowable);
    this.code = paramString;
  }
  
  public String getCode()
  {
    return this.code;
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\org\apache\commons\lang3\NotImplementedException.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */