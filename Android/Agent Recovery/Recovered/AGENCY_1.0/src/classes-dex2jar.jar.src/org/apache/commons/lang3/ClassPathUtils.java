package org.apache.commons.lang3;

public class ClassPathUtils
{
  public static String toFullyQualifiedName(Class<?> paramClass, String paramString)
  {
    Validate.notNull(paramClass, "Parameter '%s' must not be null!", new Object[] { "context" });
    Validate.notNull(paramString, "Parameter '%s' must not be null!", new Object[] { "resourceName" });
    return toFullyQualifiedName(paramClass.getPackage(), paramString);
  }
  
  public static String toFullyQualifiedName(Package paramPackage, String paramString)
  {
    Validate.notNull(paramPackage, "Parameter '%s' must not be null!", new Object[] { "context" });
    Validate.notNull(paramString, "Parameter '%s' must not be null!", new Object[] { "resourceName" });
    StringBuilder localStringBuilder = new StringBuilder();
    localStringBuilder.append(paramPackage.getName());
    localStringBuilder.append(".");
    localStringBuilder.append(paramString);
    return localStringBuilder.toString();
  }
  
  public static String toFullyQualifiedPath(Class<?> paramClass, String paramString)
  {
    Validate.notNull(paramClass, "Parameter '%s' must not be null!", new Object[] { "context" });
    Validate.notNull(paramString, "Parameter '%s' must not be null!", new Object[] { "resourceName" });
    return toFullyQualifiedPath(paramClass.getPackage(), paramString);
  }
  
  public static String toFullyQualifiedPath(Package paramPackage, String paramString)
  {
    Validate.notNull(paramPackage, "Parameter '%s' must not be null!", new Object[] { "context" });
    Validate.notNull(paramString, "Parameter '%s' must not be null!", new Object[] { "resourceName" });
    StringBuilder localStringBuilder = new StringBuilder();
    localStringBuilder.append(paramPackage.getName().replace('.', '/'));
    localStringBuilder.append("/");
    localStringBuilder.append(paramString);
    return localStringBuilder.toString();
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\org\apache\commons\lang3\ClassPathUtils.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */