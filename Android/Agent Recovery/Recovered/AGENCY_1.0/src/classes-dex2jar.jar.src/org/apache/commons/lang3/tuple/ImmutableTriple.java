package org.apache.commons.lang3.tuple;

public final class ImmutableTriple<L, M, R>
  extends Triple<L, M, R>
{
  private static final long serialVersionUID = 1L;
  public final L left;
  public final M middle;
  public final R right;
  
  public ImmutableTriple(L paramL, M paramM, R paramR)
  {
    this.left = paramL;
    this.middle = paramM;
    this.right = paramR;
  }
  
  public static <L, M, R> ImmutableTriple<L, M, R> of(L paramL, M paramM, R paramR)
  {
    return new ImmutableTriple(paramL, paramM, paramR);
  }
  
  public L getLeft()
  {
    return (L)this.left;
  }
  
  public M getMiddle()
  {
    return (M)this.middle;
  }
  
  public R getRight()
  {
    return (R)this.right;
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\org\apache\commons\lang3\tuple\ImmutableTriple.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */