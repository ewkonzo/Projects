package org.apache.commons.lang3.reflect;

import java.lang.reflect.Field;
import java.lang.reflect.Modifier;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import org.apache.commons.lang3.ClassUtils;
import org.apache.commons.lang3.StringUtils;
import org.apache.commons.lang3.Validate;

public class FieldUtils
{
  public static Field[] getAllFields(Class<?> paramClass)
  {
    paramClass = getAllFieldsList(paramClass);
    return (Field[])paramClass.toArray(new Field[paramClass.size()]);
  }
  
  public static List<Field> getAllFieldsList(Class<?> paramClass)
  {
    boolean bool;
    ArrayList localArrayList;
    if (paramClass != null)
    {
      bool = true;
      Validate.isTrue(bool, "The class must not be null", new Object[0]);
      localArrayList = new ArrayList();
    }
    for (;;)
    {
      if (paramClass == null) {
        return localArrayList;
      }
      Field[] arrayOfField = paramClass.getDeclaredFields();
      int j = arrayOfField.length;
      int i = 0;
      for (;;)
      {
        if (i < j)
        {
          localArrayList.add(arrayOfField[i]);
          i += 1;
          continue;
          bool = false;
          break;
        }
      }
      paramClass = paramClass.getSuperclass();
    }
    return localArrayList;
  }
  
  public static Field getDeclaredField(Class<?> paramClass, String paramString)
  {
    return getDeclaredField(paramClass, paramString, false);
  }
  
  public static Field getDeclaredField(Class<?> paramClass, String paramString, boolean paramBoolean)
  {
    boolean bool = true;
    if (paramClass != null) {}
    for (;;)
    {
      Validate.isTrue(bool, "The class must not be null", new Object[0]);
      Validate.isTrue(StringUtils.isNotBlank(paramString), "The field name must not be blank/empty", new Object[0]);
      try
      {
        paramClass = paramClass.getDeclaredField(paramString);
        if (!MemberUtils.isAccessible(paramClass))
        {
          if (paramBoolean) {
            paramClass.setAccessible(true);
          }
        }
        else
        {
          return paramClass;
          bool = false;
          continue;
        }
        return null;
      }
      catch (NoSuchFieldException paramClass) {}
    }
    return null;
  }
  
  public static Field getField(Class<?> paramClass, String paramString)
  {
    paramClass = getField(paramClass, paramString, false);
    MemberUtils.setAccessibleWorkaround(paramClass);
    return paramClass;
  }
  
  public static Field getField(Class<?> paramClass, String paramString, boolean paramBoolean)
  {
    boolean bool;
    if (paramClass != null)
    {
      bool = true;
      Validate.isTrue(bool, "The class must not be null", new Object[0]);
      Validate.isTrue(StringUtils.isNotBlank(paramString), "The field name must not be blank/empty", new Object[0]);
      localObject1 = paramClass;
    }
    label76:
    for (;;)
    {
      if (localObject1 == null) {
        break label84;
      }
      try
      {
        Field localField = ((Class)localObject1).getDeclaredField(paramString);
        if (!Modifier.isPublic(localField.getModifiers()))
        {
          if (!paramBoolean) {
            break label76;
          }
          localField.setAccessible(true);
        }
        return localField;
      }
      catch (NoSuchFieldException localNoSuchFieldException1)
      {
        localObject1 = ((Class)localObject1).getSuperclass();
      }
      bool = false;
      break;
    }
    label84:
    Object localObject1 = null;
    Iterator localIterator = ClassUtils.getAllInterfaces(paramClass).iterator();
    for (;;)
    {
      Object localObject2;
      if (localIterator.hasNext()) {
        localObject2 = (Class)localIterator.next();
      }
      try
      {
        localObject2 = ((Class)localObject2).getField(paramString);
        if (localObject1 == null) {}
        for (paramBoolean = true;; paramBoolean = false)
        {
          Validate.isTrue(paramBoolean, "Reference to field %s is ambiguous relative to %s; a matching field exists on two or more implemented interfaces.", new Object[] { paramString, paramClass });
          localObject1 = localObject2;
          break;
        }
        return (Field)localObject1;
      }
      catch (NoSuchFieldException localNoSuchFieldException2) {}
    }
  }
  
  public static Object readDeclaredField(Object paramObject, String paramString)
    throws IllegalAccessException
  {
    return readDeclaredField(paramObject, paramString, false);
  }
  
  public static Object readDeclaredField(Object paramObject, String paramString, boolean paramBoolean)
    throws IllegalAccessException
  {
    boolean bool;
    Class localClass;
    Field localField;
    if (paramObject != null)
    {
      bool = true;
      Validate.isTrue(bool, "target object must not be null", new Object[0]);
      localClass = paramObject.getClass();
      localField = getDeclaredField(localClass, paramString, paramBoolean);
      if (localField == null) {
        break label70;
      }
    }
    label70:
    for (paramBoolean = true;; paramBoolean = false)
    {
      Validate.isTrue(paramBoolean, "Cannot locate declared field %s.%s", new Object[] { localClass, paramString });
      return readField(localField, paramObject, false);
      bool = false;
      break;
    }
  }
  
  public static Object readDeclaredStaticField(Class<?> paramClass, String paramString)
    throws IllegalAccessException
  {
    return readDeclaredStaticField(paramClass, paramString, false);
  }
  
  public static Object readDeclaredStaticField(Class<?> paramClass, String paramString, boolean paramBoolean)
    throws IllegalAccessException
  {
    Field localField = getDeclaredField(paramClass, paramString, paramBoolean);
    if (localField != null) {}
    for (paramBoolean = true;; paramBoolean = false)
    {
      Validate.isTrue(paramBoolean, "Cannot locate declared field %s.%s", new Object[] { paramClass.getName(), paramString });
      return readStaticField(localField, false);
    }
  }
  
  public static Object readField(Object paramObject, String paramString)
    throws IllegalAccessException
  {
    return readField(paramObject, paramString, false);
  }
  
  public static Object readField(Object paramObject, String paramString, boolean paramBoolean)
    throws IllegalAccessException
  {
    boolean bool;
    Class localClass;
    Field localField;
    if (paramObject != null)
    {
      bool = true;
      Validate.isTrue(bool, "target object must not be null", new Object[0]);
      localClass = paramObject.getClass();
      localField = getField(localClass, paramString, paramBoolean);
      if (localField == null) {
        break label70;
      }
    }
    label70:
    for (paramBoolean = true;; paramBoolean = false)
    {
      Validate.isTrue(paramBoolean, "Cannot locate field %s on %s", new Object[] { paramString, localClass });
      return readField(localField, paramObject, false);
      bool = false;
      break;
    }
  }
  
  public static Object readField(Field paramField, Object paramObject)
    throws IllegalAccessException
  {
    return readField(paramField, paramObject, false);
  }
  
  public static Object readField(Field paramField, Object paramObject, boolean paramBoolean)
    throws IllegalAccessException
  {
    boolean bool;
    if (paramField != null)
    {
      bool = true;
      Validate.isTrue(bool, "The field must not be null", new Object[0]);
      if ((!paramBoolean) || (paramField.isAccessible())) {
        break label43;
      }
      paramField.setAccessible(true);
    }
    for (;;)
    {
      return paramField.get(paramObject);
      bool = false;
      break;
      label43:
      MemberUtils.setAccessibleWorkaround(paramField);
    }
  }
  
  public static Object readStaticField(Class<?> paramClass, String paramString)
    throws IllegalAccessException
  {
    return readStaticField(paramClass, paramString, false);
  }
  
  public static Object readStaticField(Class<?> paramClass, String paramString, boolean paramBoolean)
    throws IllegalAccessException
  {
    Field localField = getField(paramClass, paramString, paramBoolean);
    if (localField != null) {}
    for (paramBoolean = true;; paramBoolean = false)
    {
      Validate.isTrue(paramBoolean, "Cannot locate field '%s' on %s", new Object[] { paramString, paramClass });
      return readStaticField(localField, false);
    }
  }
  
  public static Object readStaticField(Field paramField)
    throws IllegalAccessException
  {
    return readStaticField(paramField, false);
  }
  
  public static Object readStaticField(Field paramField, boolean paramBoolean)
    throws IllegalAccessException
  {
    if (paramField != null) {}
    for (boolean bool = true;; bool = false)
    {
      Validate.isTrue(bool, "The field must not be null", new Object[0]);
      Validate.isTrue(Modifier.isStatic(paramField.getModifiers()), "The field '%s' is not static", new Object[] { paramField.getName() });
      return readField(paramField, (Object)null, paramBoolean);
    }
  }
  
  public static void removeFinalModifier(Field paramField)
  {
    removeFinalModifier(paramField, true);
  }
  
  public static void removeFinalModifier(Field paramField, boolean paramBoolean)
  {
    boolean bool;
    if (paramField != null)
    {
      bool = true;
      Validate.isTrue(bool, "The field must not be null", new Object[0]);
    }
    for (;;)
    {
      try
      {
        if (Modifier.isFinal(paramField.getModifiers()))
        {
          Field localField = Field.class.getDeclaredField("modifiers");
          if ((!paramBoolean) || (localField.isAccessible())) {
            break label102;
          }
          i = 1;
          if (i != 0) {
            localField.setAccessible(true);
          }
          try
          {
            localField.setInt(paramField, paramField.getModifiers() & 0xFFFFFFEF);
            return;
          }
          finally
          {
            if (i != 0) {
              localField.setAccessible(false);
            }
          }
        }
        return;
      }
      catch (NoSuchFieldException paramField)
      {
        return;
      }
      catch (IllegalAccessException paramField) {}
      bool = false;
      break;
      label102:
      int i = 0;
    }
  }
  
  public static void writeDeclaredField(Object paramObject1, String paramString, Object paramObject2)
    throws IllegalAccessException
  {
    writeDeclaredField(paramObject1, paramString, paramObject2, false);
  }
  
  public static void writeDeclaredField(Object paramObject1, String paramString, Object paramObject2, boolean paramBoolean)
    throws IllegalAccessException
  {
    boolean bool;
    Class localClass;
    Field localField;
    if (paramObject1 != null)
    {
      bool = true;
      Validate.isTrue(bool, "target object must not be null", new Object[0]);
      localClass = paramObject1.getClass();
      localField = getDeclaredField(localClass, paramString, paramBoolean);
      if (localField == null) {
        break label77;
      }
    }
    label77:
    for (paramBoolean = true;; paramBoolean = false)
    {
      Validate.isTrue(paramBoolean, "Cannot locate declared field %s.%s", new Object[] { localClass.getName(), paramString });
      writeField(localField, paramObject1, paramObject2, false);
      return;
      bool = false;
      break;
    }
  }
  
  public static void writeDeclaredStaticField(Class<?> paramClass, String paramString, Object paramObject)
    throws IllegalAccessException
  {
    writeDeclaredStaticField(paramClass, paramString, paramObject, false);
  }
  
  public static void writeDeclaredStaticField(Class<?> paramClass, String paramString, Object paramObject, boolean paramBoolean)
    throws IllegalAccessException
  {
    Field localField = getDeclaredField(paramClass, paramString, paramBoolean);
    if (localField != null) {}
    for (paramBoolean = true;; paramBoolean = false)
    {
      Validate.isTrue(paramBoolean, "Cannot locate declared field %s.%s", new Object[] { paramClass.getName(), paramString });
      writeField(localField, (Object)null, paramObject, false);
      return;
    }
  }
  
  public static void writeField(Object paramObject1, String paramString, Object paramObject2)
    throws IllegalAccessException
  {
    writeField(paramObject1, paramString, paramObject2, false);
  }
  
  public static void writeField(Object paramObject1, String paramString, Object paramObject2, boolean paramBoolean)
    throws IllegalAccessException
  {
    boolean bool;
    Class localClass;
    Field localField;
    if (paramObject1 != null)
    {
      bool = true;
      Validate.isTrue(bool, "target object must not be null", new Object[0]);
      localClass = paramObject1.getClass();
      localField = getField(localClass, paramString, paramBoolean);
      if (localField == null) {
        break label77;
      }
    }
    label77:
    for (paramBoolean = true;; paramBoolean = false)
    {
      Validate.isTrue(paramBoolean, "Cannot locate declared field %s.%s", new Object[] { localClass.getName(), paramString });
      writeField(localField, paramObject1, paramObject2, false);
      return;
      bool = false;
      break;
    }
  }
  
  public static void writeField(Field paramField, Object paramObject1, Object paramObject2)
    throws IllegalAccessException
  {
    writeField(paramField, paramObject1, paramObject2, false);
  }
  
  public static void writeField(Field paramField, Object paramObject1, Object paramObject2, boolean paramBoolean)
    throws IllegalAccessException
  {
    boolean bool;
    if (paramField != null)
    {
      bool = true;
      Validate.isTrue(bool, "The field must not be null", new Object[0]);
      if ((!paramBoolean) || (paramField.isAccessible())) {
        break label47;
      }
      paramField.setAccessible(true);
    }
    for (;;)
    {
      paramField.set(paramObject1, paramObject2);
      return;
      bool = false;
      break;
      label47:
      MemberUtils.setAccessibleWorkaround(paramField);
    }
  }
  
  public static void writeStaticField(Class<?> paramClass, String paramString, Object paramObject)
    throws IllegalAccessException
  {
    writeStaticField(paramClass, paramString, paramObject, false);
  }
  
  public static void writeStaticField(Class<?> paramClass, String paramString, Object paramObject, boolean paramBoolean)
    throws IllegalAccessException
  {
    Field localField = getField(paramClass, paramString, paramBoolean);
    if (localField != null) {}
    for (paramBoolean = true;; paramBoolean = false)
    {
      Validate.isTrue(paramBoolean, "Cannot locate field %s on %s", new Object[] { paramString, paramClass });
      writeStaticField(localField, paramObject, false);
      return;
    }
  }
  
  public static void writeStaticField(Field paramField, Object paramObject)
    throws IllegalAccessException
  {
    writeStaticField(paramField, paramObject, false);
  }
  
  public static void writeStaticField(Field paramField, Object paramObject, boolean paramBoolean)
    throws IllegalAccessException
  {
    if (paramField != null) {}
    for (boolean bool = true;; bool = false)
    {
      Validate.isTrue(bool, "The field must not be null", new Object[0]);
      Validate.isTrue(Modifier.isStatic(paramField.getModifiers()), "The field %s.%s is not static", new Object[] { paramField.getDeclaringClass().getName(), paramField.getName() });
      writeField(paramField, (Object)null, paramObject, paramBoolean);
      return;
    }
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\org\apache\commons\lang3\reflect\FieldUtils.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */