package org.apache.commons.lang3.tuple;

import java.io.Serializable;
import org.apache.commons.lang3.ObjectUtils;
import org.apache.commons.lang3.builder.CompareToBuilder;

public abstract class Triple<L, M, R>
  implements Comparable<Triple<L, M, R>>, Serializable
{
  private static final long serialVersionUID = 1L;
  
  public static <L, M, R> Triple<L, M, R> of(L paramL, M paramM, R paramR)
  {
    return new ImmutableTriple(paramL, paramM, paramR);
  }
  
  public int compareTo(Triple<L, M, R> paramTriple)
  {
    return new CompareToBuilder().append(getLeft(), paramTriple.getLeft()).append(getMiddle(), paramTriple.getMiddle()).append(getRight(), paramTriple.getRight()).toComparison();
  }
  
  public boolean equals(Object paramObject)
  {
    if (paramObject == this) {}
    do
    {
      return true;
      if (!(paramObject instanceof Triple)) {
        break;
      }
      paramObject = (Triple)paramObject;
    } while ((ObjectUtils.equals(getLeft(), ((Triple)paramObject).getLeft())) && (ObjectUtils.equals(getMiddle(), ((Triple)paramObject).getMiddle())) && (ObjectUtils.equals(getRight(), ((Triple)paramObject).getRight())));
    return false;
    return false;
  }
  
  public abstract L getLeft();
  
  public abstract M getMiddle();
  
  public abstract R getRight();
  
  public int hashCode()
  {
    int k = 0;
    int i;
    int j;
    if (getLeft() == null)
    {
      i = 0;
      if (getMiddle() != null) {
        break label44;
      }
      j = 0;
      label20:
      if (getRight() != null) {
        break label55;
      }
    }
    for (;;)
    {
      return i ^ j ^ k;
      i = getLeft().hashCode();
      break;
      label44:
      j = getMiddle().hashCode();
      break label20;
      label55:
      k = getRight().hashCode();
    }
  }
  
  public String toString()
  {
    return '(' + getLeft() + ',' + getMiddle() + ',' + getRight() + ')';
  }
  
  public String toString(String paramString)
  {
    return String.format(paramString, new Object[] { getLeft(), getMiddle(), getRight() });
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\org\apache\commons\lang3\tuple\Triple.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */