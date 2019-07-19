package org.apache.commons.lang3.tuple;

public class MutableTriple<L, M, R>
  extends Triple<L, M, R>
{
  private static final long serialVersionUID = 1L;
  public L left;
  public M middle;
  public R right;
  
  public MutableTriple() {}
  
  public MutableTriple(L paramL, M paramM, R paramR)
  {
    this.left = paramL;
    this.middle = paramM;
    this.right = paramR;
  }
  
  public static <L, M, R> MutableTriple<L, M, R> of(L paramL, M paramM, R paramR)
  {
    return new MutableTriple(paramL, paramM, paramR);
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
  
  public void setLeft(L paramL)
  {
    this.left = paramL;
  }
  
  public void setMiddle(M paramM)
  {
    this.middle = paramM;
  }
  
  public void setRight(R paramR)
  {
    this.right = paramR;
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\org\apache\commons\lang3\tuple\MutableTriple.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */