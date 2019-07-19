package org.apache.commons.lang3.builder;

import java.util.Collection;
import org.apache.commons.lang3.ClassUtils;

public class RecursiveToStringStyle
  extends ToStringStyle
{
  private static final long serialVersionUID = 1L;
  
  protected boolean accept(Class<?> paramClass)
  {
    return true;
  }
  
  public void appendDetail(StringBuffer paramStringBuffer, String paramString, Object paramObject)
  {
    if ((!ClassUtils.isPrimitiveWrapper(paramObject.getClass())) && (!String.class.equals(paramObject.getClass())) && (accept(paramObject.getClass())))
    {
      paramStringBuffer.append(ReflectionToStringBuilder.toString(paramObject, this));
      return;
    }
    super.appendDetail(paramStringBuffer, paramString, paramObject);
  }
  
  protected void appendDetail(StringBuffer paramStringBuffer, String paramString, Collection<?> paramCollection)
  {
    appendClassName(paramStringBuffer, paramCollection);
    appendIdentityHashCode(paramStringBuffer, paramCollection);
    appendDetail(paramStringBuffer, paramString, paramCollection.toArray());
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\org\apache\commons\lang3\builder\RecursiveToStringStyle.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */