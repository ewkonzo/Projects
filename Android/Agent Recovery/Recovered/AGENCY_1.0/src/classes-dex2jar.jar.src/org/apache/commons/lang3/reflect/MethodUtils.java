package org.apache.commons.lang3.reflect;

import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.lang.reflect.Modifier;
import java.util.Arrays;
import java.util.Iterator;
import java.util.LinkedHashSet;
import java.util.Map;
import java.util.Set;
import org.apache.commons.lang3.ArrayUtils;
import org.apache.commons.lang3.ClassUtils;
import org.apache.commons.lang3.ClassUtils.Interfaces;
import org.apache.commons.lang3.Validate;

public class MethodUtils
{
  public static Method getAccessibleMethod(Class<?> paramClass, String paramString, Class<?>... paramVarArgs)
  {
    try
    {
      paramClass = getAccessibleMethod(paramClass.getMethod(paramString, paramVarArgs));
      return paramClass;
    }
    catch (NoSuchMethodException paramClass) {}
    return null;
  }
  
  public static Method getAccessibleMethod(Method paramMethod)
  {
    Method localMethod;
    if (!MemberUtils.isAccessible(paramMethod)) {
      localMethod = null;
    }
    Class localClass;
    String str;
    Class[] arrayOfClass;
    do
    {
      do
      {
        return localMethod;
        localClass = paramMethod.getDeclaringClass();
        localMethod = paramMethod;
      } while (Modifier.isPublic(localClass.getModifiers()));
      str = paramMethod.getName();
      arrayOfClass = paramMethod.getParameterTypes();
      paramMethod = getAccessibleMethodFromInterfaceNest(localClass, str, arrayOfClass);
      localMethod = paramMethod;
    } while (paramMethod != null);
    return getAccessibleMethodFromSuperclass(localClass, str, arrayOfClass);
  }
  
  private static Method getAccessibleMethodFromInterfaceNest(Class<?> paramClass, String paramString, Class<?>... paramVarArgs)
  {
    while (paramClass != null)
    {
      Class[] arrayOfClass = paramClass.getInterfaces();
      int i = 0;
      if (i < arrayOfClass.length)
      {
        if (!Modifier.isPublic(arrayOfClass[i].getModifiers())) {}
        Method localMethod2;
        do
        {
          i += 1;
          break;
          try
          {
            Method localMethod1 = arrayOfClass[i].getDeclaredMethod(paramString, paramVarArgs);
            return localMethod1;
          }
          catch (NoSuchMethodException localNoSuchMethodException)
          {
            localMethod2 = getAccessibleMethodFromInterfaceNest(arrayOfClass[i], paramString, paramVarArgs);
          }
        } while (localMethod2 == null);
        return localMethod2;
      }
      paramClass = paramClass.getSuperclass();
    }
    return null;
  }
  
  private static Method getAccessibleMethodFromSuperclass(Class<?> paramClass, String paramString, Class<?>... paramVarArgs)
  {
    Object localObject2 = null;
    for (paramClass = paramClass.getSuperclass();; paramClass = paramClass.getSuperclass())
    {
      Object localObject1 = localObject2;
      if ((paramClass == null) || (Modifier.isPublic(paramClass.getModifiers()))) {
        try
        {
          localObject1 = paramClass.getMethod(paramString, paramVarArgs);
          return (Method)localObject1;
        }
        catch (NoSuchMethodException paramClass)
        {
          return null;
        }
      }
    }
  }
  
  public static Method getMatchingAccessibleMethod(Class<?> paramClass, String paramString, Class<?>... paramVarArgs)
  {
    try
    {
      Method localMethod1 = paramClass.getMethod(paramString, paramVarArgs);
      MemberUtils.setAccessibleWorkaround(localMethod1);
      return localMethod1;
    }
    catch (NoSuchMethodException localNoSuchMethodException)
    {
      Object localObject = null;
      Method[] arrayOfMethod = paramClass.getMethods();
      int j = arrayOfMethod.length;
      int i = 0;
      for (paramClass = (Class<?>)localObject; i < j; paramClass = (Class<?>)localObject)
      {
        Method localMethod2 = arrayOfMethod[i];
        localObject = paramClass;
        if (localMethod2.getName().equals(paramString))
        {
          localObject = paramClass;
          if (ClassUtils.isAssignable(paramVarArgs, localMethod2.getParameterTypes(), true))
          {
            localMethod2 = getAccessibleMethod(localMethod2);
            localObject = paramClass;
            if (localMethod2 != null) {
              if (paramClass != null)
              {
                localObject = paramClass;
                if (MemberUtils.compareParameterTypes(localMethod2.getParameterTypes(), paramClass.getParameterTypes(), paramVarArgs) >= 0) {}
              }
              else
              {
                localObject = localMethod2;
              }
            }
          }
        }
        i += 1;
      }
      if (paramClass != null) {
        MemberUtils.setAccessibleWorkaround(paramClass);
      }
    }
    return paramClass;
  }
  
  public static Set<Method> getOverrideHierarchy(Method paramMethod, ClassUtils.Interfaces paramInterfaces)
  {
    Validate.notNull(paramMethod);
    LinkedHashSet localLinkedHashSet = new LinkedHashSet();
    localLinkedHashSet.add(paramMethod);
    Class[] arrayOfClass = paramMethod.getParameterTypes();
    Class localClass = paramMethod.getDeclaringClass();
    paramInterfaces = ClassUtils.hierarchy(localClass, paramInterfaces).iterator();
    paramInterfaces.next();
    while (paramInterfaces.hasNext())
    {
      Method localMethod = getMatchingAccessibleMethod((Class)paramInterfaces.next(), paramMethod.getName(), arrayOfClass);
      if (localMethod != null) {
        if (Arrays.equals(localMethod.getParameterTypes(), arrayOfClass))
        {
          localLinkedHashSet.add(localMethod);
        }
        else
        {
          Map localMap = TypeUtils.getTypeArguments(localClass, localMethod.getDeclaringClass());
          int i = 0;
          for (;;)
          {
            if (i >= arrayOfClass.length) {
              break label170;
            }
            if (!TypeUtils.equals(TypeUtils.unrollVariables(localMap, paramMethod.getGenericParameterTypes()[i]), TypeUtils.unrollVariables(localMap, localMethod.getGenericParameterTypes()[i]))) {
              break;
            }
            i += 1;
          }
          label170:
          localLinkedHashSet.add(localMethod);
        }
      }
    }
    return localLinkedHashSet;
  }
  
  public static Object invokeExactMethod(Object paramObject, String paramString, Object... paramVarArgs)
    throws NoSuchMethodException, IllegalAccessException, InvocationTargetException
  {
    paramVarArgs = ArrayUtils.nullToEmpty(paramVarArgs);
    return invokeExactMethod(paramObject, paramString, paramVarArgs, ClassUtils.toClass(paramVarArgs));
  }
  
  public static Object invokeExactMethod(Object paramObject, String paramString, Object[] paramArrayOfObject, Class<?>[] paramArrayOfClass)
    throws NoSuchMethodException, IllegalAccessException, InvocationTargetException
  {
    paramArrayOfObject = ArrayUtils.nullToEmpty(paramArrayOfObject);
    paramArrayOfClass = ArrayUtils.nullToEmpty(paramArrayOfClass);
    paramArrayOfClass = getAccessibleMethod(paramObject.getClass(), paramString, paramArrayOfClass);
    if (paramArrayOfClass == null) {
      throw new NoSuchMethodException("No such accessible method: " + paramString + "() on object: " + paramObject.getClass().getName());
    }
    return paramArrayOfClass.invoke(paramObject, paramArrayOfObject);
  }
  
  public static Object invokeExactStaticMethod(Class<?> paramClass, String paramString, Object... paramVarArgs)
    throws NoSuchMethodException, IllegalAccessException, InvocationTargetException
  {
    paramVarArgs = ArrayUtils.nullToEmpty(paramVarArgs);
    return invokeExactStaticMethod(paramClass, paramString, paramVarArgs, ClassUtils.toClass(paramVarArgs));
  }
  
  public static Object invokeExactStaticMethod(Class<?> paramClass, String paramString, Object[] paramArrayOfObject, Class<?>[] paramArrayOfClass)
    throws NoSuchMethodException, IllegalAccessException, InvocationTargetException
  {
    paramArrayOfObject = ArrayUtils.nullToEmpty(paramArrayOfObject);
    paramArrayOfClass = getAccessibleMethod(paramClass, paramString, ArrayUtils.nullToEmpty(paramArrayOfClass));
    if (paramArrayOfClass == null) {
      throw new NoSuchMethodException("No such accessible method: " + paramString + "() on class: " + paramClass.getName());
    }
    return paramArrayOfClass.invoke(null, paramArrayOfObject);
  }
  
  public static Object invokeMethod(Object paramObject, String paramString, Object... paramVarArgs)
    throws NoSuchMethodException, IllegalAccessException, InvocationTargetException
  {
    paramVarArgs = ArrayUtils.nullToEmpty(paramVarArgs);
    return invokeMethod(paramObject, paramString, paramVarArgs, ClassUtils.toClass(paramVarArgs));
  }
  
  public static Object invokeMethod(Object paramObject, String paramString, Object[] paramArrayOfObject, Class<?>[] paramArrayOfClass)
    throws NoSuchMethodException, IllegalAccessException, InvocationTargetException
  {
    paramArrayOfClass = ArrayUtils.nullToEmpty(paramArrayOfClass);
    paramArrayOfObject = ArrayUtils.nullToEmpty(paramArrayOfObject);
    paramArrayOfClass = getMatchingAccessibleMethod(paramObject.getClass(), paramString, paramArrayOfClass);
    if (paramArrayOfClass == null) {
      throw new NoSuchMethodException("No such accessible method: " + paramString + "() on object: " + paramObject.getClass().getName());
    }
    return paramArrayOfClass.invoke(paramObject, paramArrayOfObject);
  }
  
  public static Object invokeStaticMethod(Class<?> paramClass, String paramString, Object... paramVarArgs)
    throws NoSuchMethodException, IllegalAccessException, InvocationTargetException
  {
    paramVarArgs = ArrayUtils.nullToEmpty(paramVarArgs);
    return invokeStaticMethod(paramClass, paramString, paramVarArgs, ClassUtils.toClass(paramVarArgs));
  }
  
  public static Object invokeStaticMethod(Class<?> paramClass, String paramString, Object[] paramArrayOfObject, Class<?>[] paramArrayOfClass)
    throws NoSuchMethodException, IllegalAccessException, InvocationTargetException
  {
    paramArrayOfObject = ArrayUtils.nullToEmpty(paramArrayOfObject);
    paramArrayOfClass = getMatchingAccessibleMethod(paramClass, paramString, ArrayUtils.nullToEmpty(paramArrayOfClass));
    if (paramArrayOfClass == null) {
      throw new NoSuchMethodException("No such accessible method: " + paramString + "() on class: " + paramClass.getName());
    }
    return paramArrayOfClass.invoke(null, paramArrayOfObject);
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\org\apache\commons\lang3\reflect\MethodUtils.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */