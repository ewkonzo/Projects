package com.example.paul.a_sacco;

import android.app.Activity;
import android.widget.Toast;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;

public class JsonParser
{
  private static final String TAG = "HttpClient";
  static InputStream iStream = null;
  static String jarray = null;
  static String json = "";
  
  /* Error */
  public static String SendHttpPost(Activity paramActivity, String paramString1, String paramString2, String paramString3)
    throws IOException
  {
    // Byte code:
    //   0: new 40	java/lang/StringBuilder
    //   3: dup
    //   4: invokespecial 41	java/lang/StringBuilder:<init>	()V
    //   7: astore 5
    //   9: aconst_null
    //   10: astore 4
    //   12: aload_0
    //   13: ifnull +241 -> 254
    //   16: aload_0
    //   17: invokestatic 47	android/preference/PreferenceManager:getDefaultSharedPreferences	(Landroid/content/Context;)Landroid/content/SharedPreferences;
    //   20: ldc 49
    //   22: ldc 24
    //   24: invokeinterface 55 3 0
    //   29: astore_0
    //   30: new 40	java/lang/StringBuilder
    //   33: dup
    //   34: invokespecial 41	java/lang/StringBuilder:<init>	()V
    //   37: ldc 57
    //   39: invokevirtual 61	java/lang/StringBuilder:append	(Ljava/lang/String;)Ljava/lang/StringBuilder;
    //   42: aload_0
    //   43: invokevirtual 61	java/lang/StringBuilder:append	(Ljava/lang/String;)Ljava/lang/StringBuilder;
    //   46: ldc 63
    //   48: invokevirtual 61	java/lang/StringBuilder:append	(Ljava/lang/String;)Ljava/lang/StringBuilder;
    //   51: aload_1
    //   52: invokevirtual 61	java/lang/StringBuilder:append	(Ljava/lang/String;)Ljava/lang/StringBuilder;
    //   55: invokevirtual 67	java/lang/StringBuilder:toString	()Ljava/lang/String;
    //   58: astore_1
    //   59: new 69	org/apache/http/impl/client/DefaultHttpClient
    //   62: dup
    //   63: invokespecial 70	org/apache/http/impl/client/DefaultHttpClient:<init>	()V
    //   66: astore_0
    //   67: new 72	org/apache/http/client/methods/HttpPost
    //   70: dup
    //   71: aload_1
    //   72: invokespecial 75	org/apache/http/client/methods/HttpPost:<init>	(Ljava/lang/String;)V
    //   75: astore_1
    //   76: new 77	org/apache/http/entity/StringEntity
    //   79: dup
    //   80: aload_2
    //   81: invokevirtual 80	java/lang/String:toString	()Ljava/lang/String;
    //   84: invokespecial 81	org/apache/http/entity/StringEntity:<init>	(Ljava/lang/String;)V
    //   87: pop
    //   88: ldc 83
    //   90: aload_2
    //   91: invokevirtual 80	java/lang/String:toString	()Ljava/lang/String;
    //   94: invokestatic 89	android/util/Log:i	(Ljava/lang/String;Ljava/lang/String;)I
    //   97: pop
    //   98: new 91	java/util/ArrayList
    //   101: dup
    //   102: iconst_2
    //   103: invokespecial 94	java/util/ArrayList:<init>	(I)V
    //   106: astore 6
    //   108: aload 6
    //   110: new 96	org/apache/http/message/BasicNameValuePair
    //   113: dup
    //   114: aload_3
    //   115: aload_2
    //   116: invokespecial 99	org/apache/http/message/BasicNameValuePair:<init>	(Ljava/lang/String;Ljava/lang/String;)V
    //   119: invokeinterface 105 2 0
    //   124: pop
    //   125: aload_1
    //   126: new 107	org/apache/http/client/entity/UrlEncodedFormEntity
    //   129: dup
    //   130: aload 6
    //   132: invokespecial 110	org/apache/http/client/entity/UrlEncodedFormEntity:<init>	(Ljava/util/List;)V
    //   135: invokevirtual 114	org/apache/http/client/methods/HttpPost:setEntity	(Lorg/apache/http/HttpEntity;)V
    //   138: aload_1
    //   139: ldc 116
    //   141: ldc 118
    //   143: invokevirtual 121	org/apache/http/client/methods/HttpPost:setHeader	(Ljava/lang/String;Ljava/lang/String;)V
    //   146: invokestatic 127	java/lang/System:currentTimeMillis	()J
    //   149: lstore 7
    //   151: aload_0
    //   152: aload_1
    //   153: invokevirtual 131	org/apache/http/impl/client/DefaultHttpClient:execute	(Lorg/apache/http/client/methods/HttpUriRequest;)Lorg/apache/http/HttpResponse;
    //   156: astore_0
    //   157: ldc 12
    //   159: new 40	java/lang/StringBuilder
    //   162: dup
    //   163: invokespecial 41	java/lang/StringBuilder:<init>	()V
    //   166: ldc -123
    //   168: invokevirtual 61	java/lang/StringBuilder:append	(Ljava/lang/String;)Ljava/lang/StringBuilder;
    //   171: invokestatic 127	java/lang/System:currentTimeMillis	()J
    //   174: lload 7
    //   176: lsub
    //   177: invokevirtual 136	java/lang/StringBuilder:append	(J)Ljava/lang/StringBuilder;
    //   180: ldc -118
    //   182: invokevirtual 61	java/lang/StringBuilder:append	(Ljava/lang/String;)Ljava/lang/StringBuilder;
    //   185: invokevirtual 67	java/lang/StringBuilder:toString	()Ljava/lang/String;
    //   188: invokestatic 89	android/util/Log:i	(Ljava/lang/String;Ljava/lang/String;)I
    //   191: pop
    //   192: aload_0
    //   193: invokeinterface 144 1 0
    //   198: invokeinterface 150 1 0
    //   203: sipush 200
    //   206: if_icmpne +67 -> 273
    //   209: new 152	java/io/BufferedReader
    //   212: dup
    //   213: new 154	java/io/InputStreamReader
    //   216: dup
    //   217: aload_0
    //   218: invokeinterface 158 1 0
    //   223: invokeinterface 164 1 0
    //   228: invokespecial 167	java/io/InputStreamReader:<init>	(Ljava/io/InputStream;)V
    //   231: invokespecial 170	java/io/BufferedReader:<init>	(Ljava/io/Reader;)V
    //   234: astore_0
    //   235: aload_0
    //   236: invokevirtual 173	java/io/BufferedReader:readLine	()Ljava/lang/String;
    //   239: astore_1
    //   240: aload_1
    //   241: ifnull +13 -> 254
    //   244: aload 5
    //   246: aload_1
    //   247: invokevirtual 61	java/lang/StringBuilder:append	(Ljava/lang/String;)Ljava/lang/StringBuilder;
    //   250: pop
    //   251: goto -16 -> 235
    //   254: ldc -81
    //   256: aload 5
    //   258: invokevirtual 67	java/lang/StringBuilder:toString	()Ljava/lang/String;
    //   261: invokestatic 89	android/util/Log:i	(Ljava/lang/String;Ljava/lang/String;)I
    //   264: pop
    //   265: aload 5
    //   267: invokevirtual 67	java/lang/StringBuilder:toString	()Ljava/lang/String;
    //   270: astore_0
    //   271: aload_0
    //   272: areturn
    //   273: new 152	java/io/BufferedReader
    //   276: dup
    //   277: new 154	java/io/InputStreamReader
    //   280: dup
    //   281: aload_0
    //   282: invokeinterface 158 1 0
    //   287: invokeinterface 164 1 0
    //   292: invokespecial 167	java/io/InputStreamReader:<init>	(Ljava/io/InputStream;)V
    //   295: invokespecial 170	java/io/BufferedReader:<init>	(Ljava/io/Reader;)V
    //   298: astore_0
    //   299: aload_0
    //   300: invokevirtual 173	java/io/BufferedReader:readLine	()Ljava/lang/String;
    //   303: astore_1
    //   304: aload_1
    //   305: ifnull +13 -> 318
    //   308: aload 5
    //   310: aload_1
    //   311: invokevirtual 61	java/lang/StringBuilder:append	(Ljava/lang/String;)Ljava/lang/StringBuilder;
    //   314: pop
    //   315: goto -16 -> 299
    //   318: ldc -79
    //   320: new 40	java/lang/StringBuilder
    //   323: dup
    //   324: invokespecial 41	java/lang/StringBuilder:<init>	()V
    //   327: ldc -77
    //   329: invokevirtual 61	java/lang/StringBuilder:append	(Ljava/lang/String;)Ljava/lang/StringBuilder;
    //   332: aload 5
    //   334: invokevirtual 67	java/lang/StringBuilder:toString	()Ljava/lang/String;
    //   337: invokevirtual 61	java/lang/StringBuilder:append	(Ljava/lang/String;)Ljava/lang/StringBuilder;
    //   340: invokevirtual 67	java/lang/StringBuilder:toString	()Ljava/lang/String;
    //   343: invokestatic 182	android/util/Log:e	(Ljava/lang/String;Ljava/lang/String;)I
    //   346: pop
    //   347: goto -93 -> 254
    //   350: astore_0
    //   351: aload_0
    //   352: invokevirtual 185	org/apache/http/client/ClientProtocolException:printStackTrace	()V
    //   355: aload_0
    //   356: athrow
    //   357: astore_0
    //   358: aload_0
    //   359: invokevirtual 186	java/io/IOException:printStackTrace	()V
    //   362: aload_0
    //   363: athrow
    //   364: astore_0
    //   365: aload_0
    //   366: invokevirtual 187	java/lang/Exception:printStackTrace	()V
    //   369: aload 4
    //   371: astore_0
    //   372: goto -101 -> 271
    // Local variable table:
    //   start	length	slot	name	signature
    //   0	375	0	paramActivity	Activity
    //   0	375	1	paramString1	String
    //   0	375	2	paramString2	String
    //   0	375	3	paramString3	String
    //   10	360	4	localObject	Object
    //   7	326	5	localStringBuilder	StringBuilder
    //   106	25	6	localArrayList	java.util.ArrayList
    //   149	26	7	l	long
    // Exception table:
    //   from	to	target	type
    //   16	235	350	org/apache/http/client/ClientProtocolException
    //   235	240	350	org/apache/http/client/ClientProtocolException
    //   244	251	350	org/apache/http/client/ClientProtocolException
    //   273	299	350	org/apache/http/client/ClientProtocolException
    //   299	304	350	org/apache/http/client/ClientProtocolException
    //   308	315	350	org/apache/http/client/ClientProtocolException
    //   318	347	350	org/apache/http/client/ClientProtocolException
    //   16	235	357	java/io/IOException
    //   235	240	357	java/io/IOException
    //   244	251	357	java/io/IOException
    //   273	299	357	java/io/IOException
    //   299	304	357	java/io/IOException
    //   308	315	357	java/io/IOException
    //   318	347	357	java/io/IOException
    //   254	271	364	java/lang/Exception
  }
  
  private static String convertStreamToString(InputStream paramInputStream)
  {
    BufferedReader localBufferedReader = new BufferedReader(new InputStreamReader(paramInputStream));
    StringBuilder localStringBuilder = new StringBuilder();
    for (;;)
    {
      try
      {
        String str = localBufferedReader.readLine();
        if (str != null)
        {
          localStringBuilder.append(str + "\n");
          continue;
        }
      }
      catch (IOException localIOException)
      {
        localIOException = localIOException;
        localIOException.printStackTrace();
        try
        {
          paramInputStream.close();
        }
        catch (IOException paramInputStream)
        {
          paramInputStream.printStackTrace();
        }
        continue;
      }
      finally {}
      try
      {
        paramInputStream.close();
        return localStringBuilder.toString();
      }
      catch (IOException paramInputStream)
      {
        paramInputStream.printStackTrace();
      }
    }
    try
    {
      paramInputStream.close();
      throw ((Throwable)localObject);
    }
    catch (IOException paramInputStream)
    {
      for (;;)
      {
        paramInputStream.printStackTrace();
      }
    }
  }
  
  /* Error */
  public static String getJSONFromUrl(Activity paramActivity, String paramString)
  {
    // Byte code:
    //   0: aload_0
    //   1: invokestatic 47	android/preference/PreferenceManager:getDefaultSharedPreferences	(Landroid/content/Context;)Landroid/content/SharedPreferences;
    //   4: ldc 49
    //   6: ldc 24
    //   8: invokeinterface 55 3 0
    //   13: astore_2
    //   14: new 40	java/lang/StringBuilder
    //   17: dup
    //   18: invokespecial 41	java/lang/StringBuilder:<init>	()V
    //   21: ldc 57
    //   23: invokevirtual 61	java/lang/StringBuilder:append	(Ljava/lang/String;)Ljava/lang/StringBuilder;
    //   26: aload_2
    //   27: invokevirtual 61	java/lang/StringBuilder:append	(Ljava/lang/String;)Ljava/lang/StringBuilder;
    //   30: ldc 63
    //   32: invokevirtual 61	java/lang/StringBuilder:append	(Ljava/lang/String;)Ljava/lang/StringBuilder;
    //   35: aload_1
    //   36: invokevirtual 61	java/lang/StringBuilder:append	(Ljava/lang/String;)Ljava/lang/StringBuilder;
    //   39: invokevirtual 67	java/lang/StringBuilder:toString	()Ljava/lang/String;
    //   42: astore_3
    //   43: new 40	java/lang/StringBuilder
    //   46: dup
    //   47: invokespecial 41	java/lang/StringBuilder:<init>	()V
    //   50: astore_1
    //   51: new 69	org/apache/http/impl/client/DefaultHttpClient
    //   54: dup
    //   55: invokespecial 70	org/apache/http/impl/client/DefaultHttpClient:<init>	()V
    //   58: astore_2
    //   59: new 201	org/apache/http/client/methods/HttpGet
    //   62: dup
    //   63: aload_3
    //   64: invokespecial 202	org/apache/http/client/methods/HttpGet:<init>	(Ljava/lang/String;)V
    //   67: astore_3
    //   68: aload_2
    //   69: aload_3
    //   70: invokeinterface 205 2 0
    //   75: astore_2
    //   76: aload_2
    //   77: invokeinterface 144 1 0
    //   82: astore_3
    //   83: aload_3
    //   84: invokeinterface 150 1 0
    //   89: istore 4
    //   91: iload 4
    //   93: sipush 200
    //   96: if_icmpne +86 -> 182
    //   99: new 152	java/io/BufferedReader
    //   102: dup
    //   103: new 154	java/io/InputStreamReader
    //   106: dup
    //   107: aload_2
    //   108: invokeinterface 158 1 0
    //   113: invokeinterface 164 1 0
    //   118: invokespecial 167	java/io/InputStreamReader:<init>	(Ljava/io/InputStream;)V
    //   121: invokespecial 170	java/io/BufferedReader:<init>	(Ljava/io/Reader;)V
    //   124: astore_2
    //   125: aload_2
    //   126: invokevirtual 173	java/io/BufferedReader:readLine	()Ljava/lang/String;
    //   129: astore_3
    //   130: aload_3
    //   131: ifnull +12 -> 143
    //   134: aload_1
    //   135: aload_3
    //   136: invokevirtual 61	java/lang/StringBuilder:append	(Ljava/lang/String;)Ljava/lang/StringBuilder;
    //   139: pop
    //   140: goto -15 -> 125
    //   143: getstatic 209	java/lang/System:out	Ljava/io/PrintStream;
    //   146: new 40	java/lang/StringBuilder
    //   149: dup
    //   150: invokespecial 41	java/lang/StringBuilder:<init>	()V
    //   153: ldc -45
    //   155: invokevirtual 61	java/lang/StringBuilder:append	(Ljava/lang/String;)Ljava/lang/StringBuilder;
    //   158: aload_1
    //   159: invokevirtual 67	java/lang/StringBuilder:toString	()Ljava/lang/String;
    //   162: invokevirtual 61	java/lang/StringBuilder:append	(Ljava/lang/String;)Ljava/lang/StringBuilder;
    //   165: invokevirtual 67	java/lang/StringBuilder:toString	()Ljava/lang/String;
    //   168: invokevirtual 216	java/io/PrintStream:println	(Ljava/lang/String;)V
    //   171: aload_1
    //   172: invokevirtual 67	java/lang/StringBuilder:toString	()Ljava/lang/String;
    //   175: putstatic 22	com/example/paul/a_sacco/JsonParser:jarray	Ljava/lang/String;
    //   178: getstatic 22	com/example/paul/a_sacco/JsonParser:jarray	Ljava/lang/String;
    //   181: areturn
    //   182: ldc -79
    //   184: iload 4
    //   186: invokestatic 220	java/lang/String:valueOf	(I)Ljava/lang/String;
    //   189: invokestatic 182	android/util/Log:e	(Ljava/lang/String;Ljava/lang/String;)I
    //   192: pop
    //   193: ldc -79
    //   195: aload_3
    //   196: invokeinterface 223 1 0
    //   201: invokestatic 226	java/lang/String:valueOf	(Ljava/lang/Object;)Ljava/lang/String;
    //   204: invokestatic 182	android/util/Log:e	(Ljava/lang/String;Ljava/lang/String;)I
    //   207: pop
    //   208: ldc -79
    //   210: ldc -28
    //   212: invokestatic 182	android/util/Log:e	(Ljava/lang/String;Ljava/lang/String;)I
    //   215: pop
    //   216: goto -73 -> 143
    //   219: astore_2
    //   220: aload_0
    //   221: new 6	com/example/paul/a_sacco/JsonParser$1
    //   224: dup
    //   225: aload_0
    //   226: invokespecial 231	com/example/paul/a_sacco/JsonParser$1:<init>	(Landroid/app/Activity;)V
    //   229: invokevirtual 237	android/app/Activity:runOnUiThread	(Ljava/lang/Runnable;)V
    //   232: aload_2
    //   233: invokevirtual 185	org/apache/http/client/ClientProtocolException:printStackTrace	()V
    //   236: goto -93 -> 143
    //   239: astore_2
    //   240: aload_0
    //   241: new 8	com/example/paul/a_sacco/JsonParser$2
    //   244: dup
    //   245: aload_0
    //   246: invokespecial 238	com/example/paul/a_sacco/JsonParser$2:<init>	(Landroid/app/Activity;)V
    //   249: invokevirtual 237	android/app/Activity:runOnUiThread	(Ljava/lang/Runnable;)V
    //   252: aload_2
    //   253: invokevirtual 186	java/io/IOException:printStackTrace	()V
    //   256: goto -113 -> 143
    //   259: astore_0
    //   260: ldc -16
    //   262: new 40	java/lang/StringBuilder
    //   265: dup
    //   266: invokespecial 41	java/lang/StringBuilder:<init>	()V
    //   269: ldc -14
    //   271: invokevirtual 61	java/lang/StringBuilder:append	(Ljava/lang/String;)Ljava/lang/StringBuilder;
    //   274: aload_0
    //   275: invokevirtual 243	java/lang/Exception:toString	()Ljava/lang/String;
    //   278: invokevirtual 61	java/lang/StringBuilder:append	(Ljava/lang/String;)Ljava/lang/StringBuilder;
    //   281: invokevirtual 67	java/lang/StringBuilder:toString	()Ljava/lang/String;
    //   284: invokestatic 182	android/util/Log:e	(Ljava/lang/String;Ljava/lang/String;)I
    //   287: pop
    //   288: goto -110 -> 178
    // Local variable table:
    //   start	length	slot	name	signature
    //   0	291	0	paramActivity	Activity
    //   0	291	1	paramString	String
    //   13	113	2	localObject1	Object
    //   219	14	2	localClientProtocolException	org.apache.http.client.ClientProtocolException
    //   239	14	2	localIOException	IOException
    //   42	154	3	localObject2	Object
    //   89	96	4	i	int
    // Exception table:
    //   from	to	target	type
    //   68	91	219	org/apache/http/client/ClientProtocolException
    //   99	125	219	org/apache/http/client/ClientProtocolException
    //   125	130	219	org/apache/http/client/ClientProtocolException
    //   134	140	219	org/apache/http/client/ClientProtocolException
    //   182	216	219	org/apache/http/client/ClientProtocolException
    //   68	91	239	java/io/IOException
    //   99	125	239	java/io/IOException
    //   125	130	239	java/io/IOException
    //   134	140	239	java/io/IOException
    //   182	216	239	java/io/IOException
    //   143	178	259	java/lang/Exception
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\com\example\paul\a_sacco\JsonParser.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */