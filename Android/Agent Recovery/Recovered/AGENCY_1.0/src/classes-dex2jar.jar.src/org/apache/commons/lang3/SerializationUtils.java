package org.apache.commons.lang3;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.ObjectInputStream;
import java.io.ObjectStreamClass;
import java.io.Serializable;
import java.util.HashMap;
import java.util.Map;

public class SerializationUtils
{
  /* Error */
  public static <T extends Serializable> T clone(T paramT)
  {
    // Byte code:
    //   0: aload_0
    //   1: ifnonnull +7 -> 8
    //   4: aconst_null
    //   5: astore_1
    //   6: aload_1
    //   7: areturn
    //   8: new 20	java/io/ByteArrayInputStream
    //   11: dup
    //   12: aload_0
    //   13: invokestatic 24	org/apache/commons/lang3/SerializationUtils:serialize	(Ljava/io/Serializable;)[B
    //   16: invokespecial 27	java/io/ByteArrayInputStream:<init>	([B)V
    //   19: astore 4
    //   21: aconst_null
    //   22: astore_1
    //   23: aconst_null
    //   24: astore_3
    //   25: aconst_null
    //   26: astore_2
    //   27: new 6	org/apache/commons/lang3/SerializationUtils$ClassLoaderAwareObjectInputStream
    //   30: dup
    //   31: aload 4
    //   33: aload_0
    //   34: invokevirtual 31	java/lang/Object:getClass	()Ljava/lang/Class;
    //   37: invokevirtual 37	java/lang/Class:getClassLoader	()Ljava/lang/ClassLoader;
    //   40: invokespecial 40	org/apache/commons/lang3/SerializationUtils$ClassLoaderAwareObjectInputStream:<init>	(Ljava/io/InputStream;Ljava/lang/ClassLoader;)V
    //   43: astore_0
    //   44: aload_0
    //   45: invokevirtual 44	org/apache/commons/lang3/SerializationUtils$ClassLoaderAwareObjectInputStream:readObject	()Ljava/lang/Object;
    //   48: checkcast 46	java/io/Serializable
    //   51: astore_2
    //   52: aload_2
    //   53: astore_1
    //   54: aload_0
    //   55: ifnull -49 -> 6
    //   58: aload_0
    //   59: invokevirtual 49	org/apache/commons/lang3/SerializationUtils$ClassLoaderAwareObjectInputStream:close	()V
    //   62: aload_2
    //   63: areturn
    //   64: astore_0
    //   65: new 51	org/apache/commons/lang3/SerializationException
    //   68: dup
    //   69: ldc 53
    //   71: aload_0
    //   72: invokespecial 56	org/apache/commons/lang3/SerializationException:<init>	(Ljava/lang/String;Ljava/lang/Throwable;)V
    //   75: athrow
    //   76: astore_0
    //   77: aload_2
    //   78: astore_1
    //   79: new 51	org/apache/commons/lang3/SerializationException
    //   82: dup
    //   83: ldc 58
    //   85: aload_0
    //   86: invokespecial 56	org/apache/commons/lang3/SerializationException:<init>	(Ljava/lang/String;Ljava/lang/Throwable;)V
    //   89: athrow
    //   90: astore_0
    //   91: aload_1
    //   92: ifnull +7 -> 99
    //   95: aload_1
    //   96: invokevirtual 49	org/apache/commons/lang3/SerializationUtils$ClassLoaderAwareObjectInputStream:close	()V
    //   99: aload_0
    //   100: athrow
    //   101: astore_0
    //   102: aload_3
    //   103: astore_1
    //   104: new 51	org/apache/commons/lang3/SerializationException
    //   107: dup
    //   108: ldc 60
    //   110: aload_0
    //   111: invokespecial 56	org/apache/commons/lang3/SerializationException:<init>	(Ljava/lang/String;Ljava/lang/Throwable;)V
    //   114: athrow
    //   115: astore_0
    //   116: new 51	org/apache/commons/lang3/SerializationException
    //   119: dup
    //   120: ldc 53
    //   122: aload_0
    //   123: invokespecial 56	org/apache/commons/lang3/SerializationException:<init>	(Ljava/lang/String;Ljava/lang/Throwable;)V
    //   126: athrow
    //   127: astore_2
    //   128: aload_0
    //   129: astore_1
    //   130: aload_2
    //   131: astore_0
    //   132: goto -41 -> 91
    //   135: astore_2
    //   136: aload_0
    //   137: astore_1
    //   138: aload_2
    //   139: astore_0
    //   140: goto -36 -> 104
    //   143: astore_2
    //   144: aload_0
    //   145: astore_1
    //   146: aload_2
    //   147: astore_0
    //   148: goto -69 -> 79
    // Local variable table:
    //   start	length	slot	name	signature
    //   0	151	0	paramT	T
    //   5	141	1	localObject1	Object
    //   26	52	2	localSerializable	Serializable
    //   127	4	2	localObject2	Object
    //   135	4	2	localIOException	IOException
    //   143	4	2	localClassNotFoundException	ClassNotFoundException
    //   24	79	3	localObject3	Object
    //   19	13	4	localByteArrayInputStream	ByteArrayInputStream
    // Exception table:
    //   from	to	target	type
    //   58	62	64	java/io/IOException
    //   27	44	76	java/lang/ClassNotFoundException
    //   27	44	90	finally
    //   79	90	90	finally
    //   104	115	90	finally
    //   27	44	101	java/io/IOException
    //   95	99	115	java/io/IOException
    //   44	52	127	finally
    //   44	52	135	java/io/IOException
    //   44	52	143	java/lang/ClassNotFoundException
  }
  
  /* Error */
  public static <T> T deserialize(InputStream paramInputStream)
  {
    // Byte code:
    //   0: aload_0
    //   1: ifnonnull +13 -> 14
    //   4: new 68	java/lang/IllegalArgumentException
    //   7: dup
    //   8: ldc 70
    //   10: invokespecial 73	java/lang/IllegalArgumentException:<init>	(Ljava/lang/String;)V
    //   13: athrow
    //   14: aconst_null
    //   15: astore_1
    //   16: aconst_null
    //   17: astore 4
    //   19: aconst_null
    //   20: astore_2
    //   21: aconst_null
    //   22: astore_3
    //   23: new 75	java/io/ObjectInputStream
    //   26: dup
    //   27: aload_0
    //   28: invokespecial 78	java/io/ObjectInputStream:<init>	(Ljava/io/InputStream;)V
    //   31: astore_0
    //   32: aload_0
    //   33: invokevirtual 79	java/io/ObjectInputStream:readObject	()Ljava/lang/Object;
    //   36: astore_1
    //   37: aload_0
    //   38: ifnull +7 -> 45
    //   41: aload_0
    //   42: invokevirtual 80	java/io/ObjectInputStream:close	()V
    //   45: aload_1
    //   46: areturn
    //   47: astore_0
    //   48: aload_3
    //   49: astore_1
    //   50: new 51	org/apache/commons/lang3/SerializationException
    //   53: dup
    //   54: aload_0
    //   55: invokespecial 83	org/apache/commons/lang3/SerializationException:<init>	(Ljava/lang/Throwable;)V
    //   58: athrow
    //   59: astore_0
    //   60: aload_1
    //   61: ifnull +7 -> 68
    //   64: aload_1
    //   65: invokevirtual 80	java/io/ObjectInputStream:close	()V
    //   68: aload_0
    //   69: athrow
    //   70: astore_0
    //   71: aload 4
    //   73: astore_1
    //   74: new 51	org/apache/commons/lang3/SerializationException
    //   77: dup
    //   78: aload_0
    //   79: invokespecial 83	org/apache/commons/lang3/SerializationException:<init>	(Ljava/lang/Throwable;)V
    //   82: athrow
    //   83: new 51	org/apache/commons/lang3/SerializationException
    //   86: dup
    //   87: aload_0
    //   88: invokespecial 83	org/apache/commons/lang3/SerializationException:<init>	(Ljava/lang/Throwable;)V
    //   91: athrow
    //   92: astore_0
    //   93: aload_1
    //   94: areturn
    //   95: astore_1
    //   96: goto -28 -> 68
    //   99: astore_2
    //   100: aload_0
    //   101: astore_1
    //   102: aload_2
    //   103: astore_0
    //   104: goto -44 -> 60
    //   107: astore_2
    //   108: aload_0
    //   109: astore_1
    //   110: aload_2
    //   111: astore_0
    //   112: goto -29 -> 83
    //   115: astore_2
    //   116: aload_0
    //   117: astore_1
    //   118: aload_2
    //   119: astore_0
    //   120: goto -46 -> 74
    //   123: astore_2
    //   124: aload_0
    //   125: astore_1
    //   126: aload_2
    //   127: astore_0
    //   128: goto -78 -> 50
    //   131: astore_0
    //   132: aload_2
    //   133: astore_1
    //   134: goto -51 -> 83
    // Local variable table:
    //   start	length	slot	name	signature
    //   0	137	0	paramInputStream	InputStream
    //   15	79	1	localObject1	Object
    //   95	1	1	localIOException1	IOException
    //   101	33	1	localObject2	Object
    //   20	1	2	localObject3	Object
    //   99	4	2	localObject4	Object
    //   107	4	2	localIOException2	IOException
    //   115	4	2	localClassNotFoundException	ClassNotFoundException
    //   123	10	2	localClassCastException	ClassCastException
    //   22	27	3	localObject5	Object
    //   17	55	4	localObject6	Object
    // Exception table:
    //   from	to	target	type
    //   23	32	47	java/lang/ClassCastException
    //   23	32	59	finally
    //   50	59	59	finally
    //   74	83	59	finally
    //   83	92	59	finally
    //   23	32	70	java/lang/ClassNotFoundException
    //   41	45	92	java/io/IOException
    //   64	68	95	java/io/IOException
    //   32	37	99	finally
    //   32	37	107	java/io/IOException
    //   32	37	115	java/lang/ClassNotFoundException
    //   32	37	123	java/lang/ClassCastException
    //   23	32	131	java/io/IOException
  }
  
  public static <T> T deserialize(byte[] paramArrayOfByte)
  {
    if (paramArrayOfByte == null) {
      throw new IllegalArgumentException("The byte[] must not be null");
    }
    return (T)deserialize(new ByteArrayInputStream(paramArrayOfByte));
  }
  
  public static <T extends Serializable> T roundtrip(T paramT)
  {
    return (Serializable)deserialize(serialize(paramT));
  }
  
  /* Error */
  public static void serialize(Serializable paramSerializable, java.io.OutputStream paramOutputStream)
  {
    // Byte code:
    //   0: aload_1
    //   1: ifnonnull +13 -> 14
    //   4: new 68	java/lang/IllegalArgumentException
    //   7: dup
    //   8: ldc 96
    //   10: invokespecial 73	java/lang/IllegalArgumentException:<init>	(Ljava/lang/String;)V
    //   13: athrow
    //   14: aconst_null
    //   15: astore_2
    //   16: aconst_null
    //   17: astore_3
    //   18: new 98	java/io/ObjectOutputStream
    //   21: dup
    //   22: aload_1
    //   23: invokespecial 101	java/io/ObjectOutputStream:<init>	(Ljava/io/OutputStream;)V
    //   26: astore_1
    //   27: aload_1
    //   28: aload_0
    //   29: invokevirtual 105	java/io/ObjectOutputStream:writeObject	(Ljava/lang/Object;)V
    //   32: aload_1
    //   33: ifnull +7 -> 40
    //   36: aload_1
    //   37: invokevirtual 106	java/io/ObjectOutputStream:close	()V
    //   40: return
    //   41: astore_0
    //   42: aload_3
    //   43: astore_2
    //   44: new 51	org/apache/commons/lang3/SerializationException
    //   47: dup
    //   48: aload_0
    //   49: invokespecial 83	org/apache/commons/lang3/SerializationException:<init>	(Ljava/lang/Throwable;)V
    //   52: athrow
    //   53: astore_0
    //   54: aload_2
    //   55: ifnull +7 -> 62
    //   58: aload_2
    //   59: invokevirtual 106	java/io/ObjectOutputStream:close	()V
    //   62: aload_0
    //   63: athrow
    //   64: astore_0
    //   65: return
    //   66: astore_1
    //   67: goto -5 -> 62
    //   70: astore_0
    //   71: aload_1
    //   72: astore_2
    //   73: goto -19 -> 54
    //   76: astore_0
    //   77: aload_1
    //   78: astore_2
    //   79: goto -35 -> 44
    // Local variable table:
    //   start	length	slot	name	signature
    //   0	82	0	paramSerializable	Serializable
    //   0	82	1	paramOutputStream	java.io.OutputStream
    //   15	64	2	localObject1	Object
    //   17	26	3	localObject2	Object
    // Exception table:
    //   from	to	target	type
    //   18	27	41	java/io/IOException
    //   18	27	53	finally
    //   44	53	53	finally
    //   36	40	64	java/io/IOException
    //   58	62	66	java/io/IOException
    //   27	32	70	finally
    //   27	32	76	java/io/IOException
  }
  
  public static byte[] serialize(Serializable paramSerializable)
  {
    ByteArrayOutputStream localByteArrayOutputStream = new ByteArrayOutputStream(512);
    serialize(paramSerializable, localByteArrayOutputStream);
    return localByteArrayOutputStream.toByteArray();
  }
  
  static class ClassLoaderAwareObjectInputStream
    extends ObjectInputStream
  {
    private static final Map<String, Class<?>> primitiveTypes = new HashMap();
    private final ClassLoader classLoader;
    
    public ClassLoaderAwareObjectInputStream(InputStream paramInputStream, ClassLoader paramClassLoader)
      throws IOException
    {
      super();
      this.classLoader = paramClassLoader;
      primitiveTypes.put("byte", Byte.TYPE);
      primitiveTypes.put("short", Short.TYPE);
      primitiveTypes.put("int", Integer.TYPE);
      primitiveTypes.put("long", Long.TYPE);
      primitiveTypes.put("float", Float.TYPE);
      primitiveTypes.put("double", Double.TYPE);
      primitiveTypes.put("boolean", Boolean.TYPE);
      primitiveTypes.put("char", Character.TYPE);
      primitiveTypes.put("void", Void.TYPE);
    }
    
    protected Class<?> resolveClass(ObjectStreamClass paramObjectStreamClass)
      throws IOException, ClassNotFoundException
    {
      Object localObject = paramObjectStreamClass.getName();
      try
      {
        paramObjectStreamClass = Class.forName((String)localObject, false, this.classLoader);
        return paramObjectStreamClass;
      }
      catch (ClassNotFoundException paramObjectStreamClass)
      {
        do
        {
          try
          {
            paramObjectStreamClass = Class.forName((String)localObject, false, Thread.currentThread().getContextClassLoader());
            return paramObjectStreamClass;
          }
          catch (ClassNotFoundException localClassNotFoundException)
          {
            localObject = (Class)primitiveTypes.get(localObject);
            paramObjectStreamClass = (ObjectStreamClass)localObject;
          }
        } while (localObject != null);
        throw localClassNotFoundException;
      }
    }
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\org\apache\commons\lang3\SerializationUtils.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */