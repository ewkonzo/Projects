package com.google.gson;

import com.google.gson.stream.JsonReader;
import com.google.gson.stream.JsonToken;
import com.google.gson.stream.MalformedJsonException;
import java.io.IOException;
import java.io.Reader;
import java.io.StringReader;

public final class JsonParser
{
  /* Error */
  public JsonElement parse(JsonReader paramJsonReader)
    throws JsonIOException, JsonSyntaxException
  {
    // Byte code:
    //   0: aload_1
    //   1: invokevirtual 25	com/google/gson/stream/JsonReader:isLenient	()Z
    //   4: istore_3
    //   5: aload_1
    //   6: iconst_1
    //   7: invokevirtual 29	com/google/gson/stream/JsonReader:setLenient	(Z)V
    //   10: aload_1
    //   11: invokestatic 33	com/google/gson/internal/Streams:parse	(Lcom/google/gson/stream/JsonReader;)Lcom/google/gson/JsonElement;
    //   14: astore_2
    //   15: aload_1
    //   16: iload_3
    //   17: invokevirtual 29	com/google/gson/stream/JsonReader:setLenient	(Z)V
    //   20: aload_2
    //   21: areturn
    //   22: astore_2
    //   23: new 35	com/google/gson/JsonParseException
    //   26: dup
    //   27: new 37	java/lang/StringBuilder
    //   30: dup
    //   31: invokespecial 38	java/lang/StringBuilder:<init>	()V
    //   34: ldc 40
    //   36: invokevirtual 44	java/lang/StringBuilder:append	(Ljava/lang/String;)Ljava/lang/StringBuilder;
    //   39: aload_1
    //   40: invokevirtual 47	java/lang/StringBuilder:append	(Ljava/lang/Object;)Ljava/lang/StringBuilder;
    //   43: ldc 49
    //   45: invokevirtual 44	java/lang/StringBuilder:append	(Ljava/lang/String;)Ljava/lang/StringBuilder;
    //   48: invokevirtual 53	java/lang/StringBuilder:toString	()Ljava/lang/String;
    //   51: aload_2
    //   52: invokespecial 56	com/google/gson/JsonParseException:<init>	(Ljava/lang/String;Ljava/lang/Throwable;)V
    //   55: athrow
    //   56: astore_2
    //   57: aload_1
    //   58: iload_3
    //   59: invokevirtual 29	com/google/gson/stream/JsonReader:setLenient	(Z)V
    //   62: aload_2
    //   63: athrow
    //   64: astore_2
    //   65: new 35	com/google/gson/JsonParseException
    //   68: dup
    //   69: new 37	java/lang/StringBuilder
    //   72: dup
    //   73: invokespecial 38	java/lang/StringBuilder:<init>	()V
    //   76: ldc 40
    //   78: invokevirtual 44	java/lang/StringBuilder:append	(Ljava/lang/String;)Ljava/lang/StringBuilder;
    //   81: aload_1
    //   82: invokevirtual 47	java/lang/StringBuilder:append	(Ljava/lang/Object;)Ljava/lang/StringBuilder;
    //   85: ldc 49
    //   87: invokevirtual 44	java/lang/StringBuilder:append	(Ljava/lang/String;)Ljava/lang/StringBuilder;
    //   90: invokevirtual 53	java/lang/StringBuilder:toString	()Ljava/lang/String;
    //   93: aload_2
    //   94: invokespecial 56	com/google/gson/JsonParseException:<init>	(Ljava/lang/String;Ljava/lang/Throwable;)V
    //   97: athrow
    // Local variable table:
    //   start	length	slot	name	signature
    //   0	98	0	this	JsonParser
    //   0	98	1	paramJsonReader	JsonReader
    //   14	7	2	localJsonElement	JsonElement
    //   22	30	2	localStackOverflowError	StackOverflowError
    //   56	7	2	localObject	Object
    //   64	30	2	localOutOfMemoryError	OutOfMemoryError
    //   4	55	3	bool	boolean
    // Exception table:
    //   from	to	target	type
    //   10	15	22	java/lang/StackOverflowError
    //   10	15	56	finally
    //   23	56	56	finally
    //   65	98	56	finally
    //   10	15	64	java/lang/OutOfMemoryError
  }
  
  public JsonElement parse(Reader paramReader)
    throws JsonIOException, JsonSyntaxException
  {
    JsonElement localJsonElement;
    try
    {
      paramReader = new JsonReader(paramReader);
      localJsonElement = parse(paramReader);
      if ((!localJsonElement.isJsonNull()) && (paramReader.peek() != JsonToken.END_DOCUMENT)) {
        throw new JsonSyntaxException("Did not consume the entire document.");
      }
    }
    catch (MalformedJsonException paramReader)
    {
      throw new JsonSyntaxException(paramReader);
    }
    catch (IOException paramReader)
    {
      throw new JsonIOException(paramReader);
    }
    catch (NumberFormatException paramReader)
    {
      throw new JsonSyntaxException(paramReader);
    }
    return localJsonElement;
  }
  
  public JsonElement parse(String paramString)
    throws JsonSyntaxException
  {
    return parse(new StringReader(paramString));
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\com\google\gson\JsonParser.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */