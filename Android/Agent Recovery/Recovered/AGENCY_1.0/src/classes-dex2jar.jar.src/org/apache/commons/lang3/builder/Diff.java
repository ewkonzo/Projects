package org.apache.commons.lang3.builder;

import java.lang.reflect.Type;
import java.util.Map;
import org.apache.commons.lang3.ObjectUtils;
import org.apache.commons.lang3.reflect.TypeUtils;
import org.apache.commons.lang3.tuple.Pair;

public abstract class Diff<T>
  extends Pair<T, T>
{
  private static final long serialVersionUID = 1L;
  private final String fieldName;
  private final Type type = (Type)ObjectUtils.defaultIfNull(TypeUtils.getTypeArguments(getClass(), Diff.class).get(Diff.class.getTypeParameters()[0]), Object.class);
  
  protected Diff(String paramString)
  {
    this.fieldName = paramString;
  }
  
  public final String getFieldName()
  {
    return this.fieldName;
  }
  
  public final Type getType()
  {
    return this.type;
  }
  
  public final T setValue(T paramT)
  {
    throw new UnsupportedOperationException("Cannot alter Diff object.");
  }
  
  public final String toString()
  {
    return String.format("[%s: %s, %s]", new Object[] { this.fieldName, getLeft(), getRight() });
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\org\apache\commons\lang3\builder\Diff.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */