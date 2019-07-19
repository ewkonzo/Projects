package org.apache.commons.lang3.concurrent;

import java.util.concurrent.ConcurrentMap;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.Future;
import java.util.concurrent.TimeUnit;

public class ConcurrentUtils
{
  static Throwable checkedException(Throwable paramThrowable)
  {
    if ((paramThrowable != null) && (!(paramThrowable instanceof RuntimeException)) && (!(paramThrowable instanceof Error))) {
      return paramThrowable;
    }
    throw new IllegalArgumentException("Not a checked exception: " + paramThrowable);
  }
  
  public static <T> Future<T> constantFuture(T paramT)
  {
    return new ConstantFuture(paramT);
  }
  
  public static <K, V> V createIfAbsent(ConcurrentMap<K, V> paramConcurrentMap, K paramK, ConcurrentInitializer<V> paramConcurrentInitializer)
    throws ConcurrentException
  {
    Object localObject1;
    if ((paramConcurrentMap == null) || (paramConcurrentInitializer == null)) {
      localObject1 = null;
    }
    Object localObject2;
    do
    {
      return (V)localObject1;
      localObject2 = paramConcurrentMap.get(paramK);
      localObject1 = localObject2;
    } while (localObject2 != null);
    return (V)putIfAbsent(paramConcurrentMap, paramK, paramConcurrentInitializer.get());
  }
  
  public static <K, V> V createIfAbsentUnchecked(ConcurrentMap<K, V> paramConcurrentMap, K paramK, ConcurrentInitializer<V> paramConcurrentInitializer)
  {
    try
    {
      paramConcurrentMap = createIfAbsent(paramConcurrentMap, paramK, paramConcurrentInitializer);
      return paramConcurrentMap;
    }
    catch (ConcurrentException paramConcurrentMap)
    {
      throw new ConcurrentRuntimeException(paramConcurrentMap.getCause());
    }
  }
  
  public static ConcurrentException extractCause(ExecutionException paramExecutionException)
  {
    if ((paramExecutionException == null) || (paramExecutionException.getCause() == null)) {
      return null;
    }
    throwCause(paramExecutionException);
    return new ConcurrentException(paramExecutionException.getMessage(), paramExecutionException.getCause());
  }
  
  public static ConcurrentRuntimeException extractCauseUnchecked(ExecutionException paramExecutionException)
  {
    if ((paramExecutionException == null) || (paramExecutionException.getCause() == null)) {
      return null;
    }
    throwCause(paramExecutionException);
    return new ConcurrentRuntimeException(paramExecutionException.getMessage(), paramExecutionException.getCause());
  }
  
  public static void handleCause(ExecutionException paramExecutionException)
    throws ConcurrentException
  {
    paramExecutionException = extractCause(paramExecutionException);
    if (paramExecutionException != null) {
      throw paramExecutionException;
    }
  }
  
  public static void handleCauseUnchecked(ExecutionException paramExecutionException)
  {
    paramExecutionException = extractCauseUnchecked(paramExecutionException);
    if (paramExecutionException != null) {
      throw paramExecutionException;
    }
  }
  
  public static <T> T initialize(ConcurrentInitializer<T> paramConcurrentInitializer)
    throws ConcurrentException
  {
    if (paramConcurrentInitializer != null) {
      return (T)paramConcurrentInitializer.get();
    }
    return null;
  }
  
  public static <T> T initializeUnchecked(ConcurrentInitializer<T> paramConcurrentInitializer)
  {
    try
    {
      paramConcurrentInitializer = initialize(paramConcurrentInitializer);
      return paramConcurrentInitializer;
    }
    catch (ConcurrentException paramConcurrentInitializer)
    {
      throw new ConcurrentRuntimeException(paramConcurrentInitializer.getCause());
    }
  }
  
  public static <K, V> V putIfAbsent(ConcurrentMap<K, V> paramConcurrentMap, K paramK, V paramV)
  {
    if (paramConcurrentMap == null) {
      paramConcurrentMap = null;
    }
    do
    {
      return paramConcurrentMap;
      paramK = paramConcurrentMap.putIfAbsent(paramK, paramV);
      paramConcurrentMap = paramK;
    } while (paramK != null);
    return paramV;
  }
  
  private static void throwCause(ExecutionException paramExecutionException)
  {
    if ((paramExecutionException.getCause() instanceof RuntimeException)) {
      throw ((RuntimeException)paramExecutionException.getCause());
    }
    if ((paramExecutionException.getCause() instanceof Error)) {
      throw ((Error)paramExecutionException.getCause());
    }
  }
  
  static final class ConstantFuture<T>
    implements Future<T>
  {
    private final T value;
    
    ConstantFuture(T paramT)
    {
      this.value = paramT;
    }
    
    public boolean cancel(boolean paramBoolean)
    {
      return false;
    }
    
    public T get()
    {
      return (T)this.value;
    }
    
    public T get(long paramLong, TimeUnit paramTimeUnit)
    {
      return (T)this.value;
    }
    
    public boolean isCancelled()
    {
      return false;
    }
    
    public boolean isDone()
    {
      return true;
    }
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\org\apache\commons\lang3\concurrent\ConcurrentUtils.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */