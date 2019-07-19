.class public Lcom/example/paul/a_sacco/JsonParser;
.super Ljava/lang/Object;
.source "JsonParser.java"


# static fields
.field private static final TAG:Ljava/lang/String; = "HttpClient"

.field static iStream:Ljava/io/InputStream;

.field static jarray:Ljava/lang/String;

.field static json:Ljava/lang/String;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 33
    const/4 v0, 0x0

    sput-object v0, Lcom/example/paul/a_sacco/JsonParser;->iStream:Ljava/io/InputStream;

    .line 34
    const/4 v0, 0x0

    sput-object v0, Lcom/example/paul/a_sacco/JsonParser;->jarray:Ljava/lang/String;

    .line 35
    const-string v0, ""

    sput-object v0, Lcom/example/paul/a_sacco/JsonParser;->json:Ljava/lang/String;

    return-void
.end method

.method public constructor <init>()V
    .locals 2

    .prologue
    .line 37
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/JsonParser;
    move-object v1, v0

    invoke-direct {v1}, Ljava/lang/Object;-><init>()V

    .line 38
    return-void
.end method

.method public static SendHttpPost(Landroid/app/Activity;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
    .locals 31
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/io/IOException;
        }
    .end annotation

    .prologue
    .line 100
    move-object/from16 v2, p0

    .local v2, "activity":Landroid/app/Activity;
    move-object/from16 v3, p1

    .local v3, "method":Ljava/lang/String;
    move-object/from16 v4, p2

    .local v4, "jsonObjSend":Ljava/lang/String;
    move-object/from16 v5, p3

    .local v5, "param":Ljava/lang/String;
    new-instance v24, Ljava/lang/StringBuilder;

    move-object/from16 v30, v24

    move-object/from16 v24, v30

    move-object/from16 v25, v30

    invoke-direct/range {v25 .. v25}, Ljava/lang/StringBuilder;-><init>()V

    move-object/from16 v6, v24

    .line 101
    .local v6, "builder":Ljava/lang/StringBuilder;
    const/16 v24, 0x0

    move-object/from16 v7, v24

    .line 103
    .local v7, "json":Ljava/lang/String;
    move-object/from16 v24, v2

    if-eqz v24, :cond_0

    .line 104
    move-object/from16 v24, v2

    :try_start_0
    invoke-static/range {v24 .. v24}, Landroid/preference/PreferenceManager;->getDefaultSharedPreferences(Landroid/content/Context;)Landroid/content/SharedPreferences;

    move-result-object v24

    move-object/from16 v8, v24

    .line 105
    .local v8, "prefs":Landroid/content/SharedPreferences;
    move-object/from16 v24, v8

    const-string v25, "Host"

    const-string v26, ""

    invoke-interface/range {v24 .. v26}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v24

    move-object/from16 v9, v24

    .line 106
    .local v9, "st":Ljava/lang/String;
    new-instance v24, Ljava/lang/StringBuilder;

    move-object/from16 v30, v24

    move-object/from16 v24, v30

    move-object/from16 v25, v30

    invoke-direct/range {v25 .. v25}, Ljava/lang/StringBuilder;-><init>()V

    const-string v25, "http://"

    invoke-virtual/range {v24 .. v25}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v24

    move-object/from16 v25, v9

    invoke-virtual/range {v24 .. v25}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v24

    const-string v25, ":35051/Agency.asmx/"

    invoke-virtual/range {v24 .. v25}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v24

    move-object/from16 v25, v3

    invoke-virtual/range {v24 .. v25}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v24

    invoke-virtual/range {v24 .. v24}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v24

    move-object/from16 v10, v24

    .line 107
    .local v10, "host":Ljava/lang/String;
    new-instance v24, Lorg/apache/http/impl/client/DefaultHttpClient;

    move-object/from16 v30, v24

    move-object/from16 v24, v30

    move-object/from16 v25, v30

    invoke-direct/range {v25 .. v25}, Lorg/apache/http/impl/client/DefaultHttpClient;-><init>()V

    move-object/from16 v11, v24

    .line 108
    .local v11, "httpclient":Lorg/apache/http/impl/client/DefaultHttpClient;
    new-instance v24, Lorg/apache/http/client/methods/HttpPost;

    move-object/from16 v30, v24

    move-object/from16 v24, v30

    move-object/from16 v25, v30

    move-object/from16 v26, v10

    invoke-direct/range {v25 .. v26}, Lorg/apache/http/client/methods/HttpPost;-><init>(Ljava/lang/String;)V

    move-object/from16 v12, v24

    .line 111
    .local v12, "httpPostRequest":Lorg/apache/http/client/methods/HttpPost;
    new-instance v24, Lorg/apache/http/entity/StringEntity;

    move-object/from16 v30, v24

    move-object/from16 v24, v30

    move-object/from16 v25, v30

    move-object/from16 v26, v4

    invoke-virtual/range {v26 .. v26}, Ljava/lang/String;->toString()Ljava/lang/String;

    move-result-object v26

    invoke-direct/range {v25 .. v26}, Lorg/apache/http/entity/StringEntity;-><init>(Ljava/lang/String;)V

    move-object/from16 v13, v24

    .line 112
    .local v13, "se":Lorg/apache/http/entity/StringEntity;
    const-string v24, "output"

    move-object/from16 v25, v4

    invoke-virtual/range {v25 .. v25}, Ljava/lang/String;->toString()Ljava/lang/String;

    move-result-object v25

    invoke-static/range {v24 .. v25}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    move-result v24

    .line 115
    new-instance v24, Ljava/util/ArrayList;

    move-object/from16 v30, v24

    move-object/from16 v24, v30

    move-object/from16 v25, v30

    const/16 v26, 0x2

    invoke-direct/range {v25 .. v26}, Ljava/util/ArrayList;-><init>(I)V

    move-object/from16 v14, v24

    .line 117
    .local v14, "nameValuePairs":Ljava/util/List;, "Ljava/util/List<Lorg/apache/http/NameValuePair;>;"
    move-object/from16 v24, v14

    new-instance v25, Lorg/apache/http/message/BasicNameValuePair;

    move-object/from16 v30, v25

    move-object/from16 v25, v30

    move-object/from16 v26, v30

    move-object/from16 v27, v5

    move-object/from16 v28, v4

    invoke-direct/range {v26 .. v28}, Lorg/apache/http/message/BasicNameValuePair;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    invoke-interface/range {v24 .. v25}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    move-result v24

    .line 119
    move-object/from16 v24, v12

    new-instance v25, Lorg/apache/http/client/entity/UrlEncodedFormEntity;

    move-object/from16 v30, v25

    move-object/from16 v25, v30

    move-object/from16 v26, v30

    move-object/from16 v27, v14

    invoke-direct/range {v26 .. v27}, Lorg/apache/http/client/entity/UrlEncodedFormEntity;-><init>(Ljava/util/List;)V

    invoke-virtual/range {v24 .. v25}, Lorg/apache/http/client/methods/HttpPost;->setEntity(Lorg/apache/http/HttpEntity;)V

    .line 120
    move-object/from16 v24, v12

    const-string v25, "Content-type"

    const-string v26, "application/x-www-form-urlencoded"

    invoke-virtual/range {v24 .. v26}, Lorg/apache/http/client/methods/HttpPost;->setHeader(Ljava/lang/String;Ljava/lang/String;)V

    .line 121
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v24

    move-wide/from16 v15, v24

    .line 122
    .local v15, "t":J
    move-object/from16 v24, v11

    move-object/from16 v25, v12

    invoke-virtual/range {v24 .. v25}, Lorg/apache/http/impl/client/DefaultHttpClient;->execute(Lorg/apache/http/client/methods/HttpUriRequest;)Lorg/apache/http/HttpResponse;

    move-result-object v24

    move-object/from16 v17, v24

    .line 123
    .local v17, "response":Lorg/apache/http/HttpResponse;
    const-string v24, "HttpClient"

    new-instance v25, Ljava/lang/StringBuilder;

    move-object/from16 v30, v25

    move-object/from16 v25, v30

    move-object/from16 v26, v30

    invoke-direct/range {v26 .. v26}, Ljava/lang/StringBuilder;-><init>()V

    const-string v26, "HTTPResponse received in ["

    invoke-virtual/range {v25 .. v26}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v26

    move-wide/from16 v28, v15

    sub-long v26, v26, v28

    invoke-virtual/range {v25 .. v27}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    move-result-object v25

    const-string v26, "ms]"

    invoke-virtual/range {v25 .. v26}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    invoke-virtual/range {v25 .. v25}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v25

    invoke-static/range {v24 .. v25}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    move-result v24

    .line 124
    move-object/from16 v24, v17

    invoke-interface/range {v24 .. v24}, Lorg/apache/http/HttpResponse;->getStatusLine()Lorg/apache/http/StatusLine;

    move-result-object v24

    move-object/from16 v18, v24

    .line 126
    .local v18, "statusLine":Lorg/apache/http/StatusLine;
    move-object/from16 v24, v18

    invoke-interface/range {v24 .. v24}, Lorg/apache/http/StatusLine;->getStatusCode()I

    move-result v24

    move/from16 v19, v24

    .line 127
    .local v19, "statusCode":I
    move/from16 v24, v19

    const/16 v25, 0xc8

    move/from16 v0, v24

    move/from16 v1, v25

    if-ne v0, v1, :cond_1

    .line 128
    move-object/from16 v24, v17

    invoke-interface/range {v24 .. v24}, Lorg/apache/http/HttpResponse;->getEntity()Lorg/apache/http/HttpEntity;

    move-result-object v24

    move-object/from16 v20, v24

    .line 129
    .local v20, "entity":Lorg/apache/http/HttpEntity;
    move-object/from16 v24, v20

    invoke-interface/range {v24 .. v24}, Lorg/apache/http/HttpEntity;->getContent()Ljava/io/InputStream;

    move-result-object v24

    move-object/from16 v21, v24

    .line 130
    .local v21, "content":Ljava/io/InputStream;
    new-instance v24, Ljava/io/BufferedReader;

    move-object/from16 v30, v24

    move-object/from16 v24, v30

    move-object/from16 v25, v30

    new-instance v26, Ljava/io/InputStreamReader;

    move-object/from16 v30, v26

    move-object/from16 v26, v30

    move-object/from16 v27, v30

    move-object/from16 v28, v21

    invoke-direct/range {v27 .. v28}, Ljava/io/InputStreamReader;-><init>(Ljava/io/InputStream;)V

    invoke-direct/range {v25 .. v26}, Ljava/io/BufferedReader;-><init>(Ljava/io/Reader;)V

    move-object/from16 v22, v24

    .line 132
    .local v22, "reader":Ljava/io/BufferedReader;
    :goto_0
    move-object/from16 v24, v22

    invoke-virtual/range {v24 .. v24}, Ljava/io/BufferedReader;->readLine()Ljava/lang/String;

    move-result-object v24

    move-object/from16 v30, v24

    move-object/from16 v24, v30

    move-object/from16 v25, v30

    move-object/from16 v23, v25

    .local v23, "line":Ljava/lang/String;
    if-eqz v24, :cond_0

    .line 133
    move-object/from16 v24, v6

    move-object/from16 v25, v23

    invoke-virtual/range {v24 .. v25}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;
    :try_end_0
    .catch Lorg/apache/http/client/ClientProtocolException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Ljava/io/IOException; {:try_start_0 .. :try_end_0} :catch_1

    move-result-object v24

    goto :goto_0

    .line 135
    .line 152
    .line 155
    .end local v8    # "prefs":Landroid/content/SharedPreferences;
    .end local v9    # "st":Ljava/lang/String;
    .end local v10    # "host":Ljava/lang/String;
    .end local v11    # "httpclient":Lorg/apache/http/impl/client/DefaultHttpClient;
    .end local v12    # "httpPostRequest":Lorg/apache/http/client/methods/HttpPost;
    .end local v13    # "se":Lorg/apache/http/entity/StringEntity;
    .end local v14    # "nameValuePairs":Ljava/util/List;, "Ljava/util/List<Lorg/apache/http/NameValuePair;>;"
    .end local v15    # "t":J
    .end local v17    # "response":Lorg/apache/http/HttpResponse;
    .end local v18    # "statusLine":Lorg/apache/http/StatusLine;
    .end local v19    # "statusCode":I
    .end local v20    # "entity":Lorg/apache/http/HttpEntity;
    .end local v21    # "content":Ljava/io/InputStream;
    .end local v22    # "reader":Ljava/io/BufferedReader;
    .end local v23    # "line":Ljava/lang/String;
    :cond_0
    :goto_1
    :try_start_1
    const-string v24, "Response"

    move-object/from16 v25, v6

    invoke-virtual/range {v25 .. v25}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v25

    invoke-static/range {v24 .. v25}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    move-result v24

    .line 156
    move-object/from16 v24, v6

    invoke-virtual/range {v24 .. v24}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_2

    move-result-object v24

    move-object/from16 v7, v24

    .line 162
    .line 163
    :goto_2
    move-object/from16 v24, v7

    move-object/from16 v2, v24

    .end local v2    # "activity":Landroid/app/Activity;
    return-object v2

    .line 136
    .restart local v2    # "activity":Landroid/app/Activity;
    .restart local v8    # "prefs":Landroid/content/SharedPreferences;
    .restart local v9    # "st":Ljava/lang/String;
    .restart local v10    # "host":Ljava/lang/String;
    .restart local v11    # "httpclient":Lorg/apache/http/impl/client/DefaultHttpClient;
    .restart local v12    # "httpPostRequest":Lorg/apache/http/client/methods/HttpPost;
    .restart local v13    # "se":Lorg/apache/http/entity/StringEntity;
    .restart local v14    # "nameValuePairs":Ljava/util/List;, "Ljava/util/List<Lorg/apache/http/NameValuePair;>;"
    .restart local v15    # "t":J
    .restart local v17    # "response":Lorg/apache/http/HttpResponse;
    .restart local v18    # "statusLine":Lorg/apache/http/StatusLine;
    .restart local v19    # "statusCode":I
    :cond_1
    move-object/from16 v24, v17

    :try_start_2
    invoke-interface/range {v24 .. v24}, Lorg/apache/http/HttpResponse;->getEntity()Lorg/apache/http/HttpEntity;

    move-result-object v24

    move-object/from16 v20, v24

    .line 137
    .restart local v20    # "entity":Lorg/apache/http/HttpEntity;
    move-object/from16 v24, v20

    invoke-interface/range {v24 .. v24}, Lorg/apache/http/HttpEntity;->getContent()Ljava/io/InputStream;

    move-result-object v24

    move-object/from16 v21, v24

    .line 138
    .restart local v21    # "content":Ljava/io/InputStream;
    new-instance v24, Ljava/io/BufferedReader;

    move-object/from16 v30, v24

    move-object/from16 v24, v30

    move-object/from16 v25, v30

    new-instance v26, Ljava/io/InputStreamReader;

    move-object/from16 v30, v26

    move-object/from16 v26, v30

    move-object/from16 v27, v30

    move-object/from16 v28, v21

    invoke-direct/range {v27 .. v28}, Ljava/io/InputStreamReader;-><init>(Ljava/io/InputStream;)V

    invoke-direct/range {v25 .. v26}, Ljava/io/BufferedReader;-><init>(Ljava/io/Reader;)V

    move-object/from16 v22, v24

    .line 140
    .restart local v22    # "reader":Ljava/io/BufferedReader;
    :goto_3
    move-object/from16 v24, v22

    invoke-virtual/range {v24 .. v24}, Ljava/io/BufferedReader;->readLine()Ljava/lang/String;

    move-result-object v24

    move-object/from16 v30, v24

    move-object/from16 v24, v30

    move-object/from16 v25, v30

    move-object/from16 v23, v25

    .restart local v23    # "line":Ljava/lang/String;
    if-eqz v24, :cond_2

    .line 141
    move-object/from16 v24, v6

    move-object/from16 v25, v23

    invoke-virtual/range {v24 .. v25}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v24

    goto :goto_3

    .line 143
    :cond_2
    const-string v24, "==>"

    new-instance v25, Ljava/lang/StringBuilder;

    move-object/from16 v30, v25

    move-object/from16 v25, v30

    move-object/from16 v26, v30

    invoke-direct/range {v26 .. v26}, Ljava/lang/StringBuilder;-><init>()V

    const-string v26, "Failed to download file "

    invoke-virtual/range {v25 .. v26}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    move-object/from16 v26, v6

    invoke-virtual/range {v26 .. v26}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v26

    invoke-virtual/range {v25 .. v26}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    invoke-virtual/range {v25 .. v25}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v25

    invoke-static/range {v24 .. v25}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_2
    .catch Lorg/apache/http/client/ClientProtocolException; {:try_start_2 .. :try_end_2} :catch_0
    .catch Ljava/io/IOException; {:try_start_2 .. :try_end_2} :catch_1

    move-result v24

    goto/16 :goto_1

    .line 146
    .end local v8    # "prefs":Landroid/content/SharedPreferences;
    .end local v9    # "st":Ljava/lang/String;
    .end local v10    # "host":Ljava/lang/String;
    .end local v11    # "httpclient":Lorg/apache/http/impl/client/DefaultHttpClient;
    .end local v12    # "httpPostRequest":Lorg/apache/http/client/methods/HttpPost;
    .end local v13    # "se":Lorg/apache/http/entity/StringEntity;
    .end local v14    # "nameValuePairs":Ljava/util/List;, "Ljava/util/List<Lorg/apache/http/NameValuePair;>;"
    .end local v15    # "t":J
    .end local v17    # "response":Lorg/apache/http/HttpResponse;
    .end local v18    # "statusLine":Lorg/apache/http/StatusLine;
    .end local v19    # "statusCode":I
    .end local v20    # "entity":Lorg/apache/http/HttpEntity;
    .end local v21    # "content":Ljava/io/InputStream;
    .end local v22    # "reader":Ljava/io/BufferedReader;
    .end local v23    # "line":Ljava/lang/String;
    :catch_0
    move-exception v24

    move-object/from16 v8, v24

    .line 147
    .local v8, "e":Lorg/apache/http/client/ClientProtocolException;
    move-object/from16 v24, v8

    invoke-virtual/range {v24 .. v24}, Lorg/apache/http/client/ClientProtocolException;->printStackTrace()V

    .line 148
    move-object/from16 v24, v8

    throw v24

    .line 149
    .end local v8    # "e":Lorg/apache/http/client/ClientProtocolException;
    :catch_1
    move-exception v24

    move-object/from16 v8, v24

    .line 150
    .local v8, "e":Ljava/io/IOException;
    move-object/from16 v24, v8

    invoke-virtual/range {v24 .. v24}, Ljava/io/IOException;->printStackTrace()V

    .line 151
    move-object/from16 v24, v8

    throw v24

    .line 158
    .end local v8    # "e":Ljava/io/IOException;
    :catch_2
    move-exception v24

    move-object/from16 v8, v24

    .line 161
    .local v8, "e":Ljava/lang/Exception;
    move-object/from16 v24, v8

    invoke-virtual/range {v24 .. v24}, Ljava/lang/Exception;->printStackTrace()V

    goto/16 :goto_2
.end method

.method private static convertStreamToString(Ljava/io/InputStream;)Ljava/lang/String;
    .locals 13

    .prologue
    .line 175
    move-object v0, p0

    .local v0, "is":Ljava/io/InputStream;
    new-instance v7, Ljava/io/BufferedReader;

    move-object v12, v7

    move-object v7, v12

    move-object v8, v12

    new-instance v9, Ljava/io/InputStreamReader;

    move-object v12, v9

    move-object v9, v12

    move-object v10, v12

    move-object v11, v0

    invoke-direct {v10, v11}, Ljava/io/InputStreamReader;-><init>(Ljava/io/InputStream;)V

    invoke-direct {v8, v9}, Ljava/io/BufferedReader;-><init>(Ljava/io/Reader;)V

    move-object v1, v7

    .line 176
    .local v1, "reader":Ljava/io/BufferedReader;
    new-instance v7, Ljava/lang/StringBuilder;

    move-object v12, v7

    move-object v7, v12

    move-object v8, v12

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    move-object v2, v7

    .line 178
    .local v2, "sb":Ljava/lang/StringBuilder;
    const/4 v7, 0x0

    move-object v3, v7

    .line 180
    .local v3, "line":Ljava/lang/String;
    :goto_0
    move-object v7, v1

    :try_start_0
    invoke-virtual {v7}, Ljava/io/BufferedReader;->readLine()Ljava/lang/String;

    move-result-object v7

    move-object v12, v7

    move-object v7, v12

    move-object v8, v12

    move-object v3, v8

    if-eqz v7, :cond_0

    .line 181
    move-object v7, v2

    new-instance v8, Ljava/lang/StringBuilder;

    move-object v12, v8

    move-object v8, v12

    move-object v9, v12

    invoke-direct {v9}, Ljava/lang/StringBuilder;-><init>()V

    move-object v9, v3

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    const-string v9, "\n"

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;
    :try_end_0
    .catch Ljava/io/IOException; {:try_start_0 .. :try_end_0} :catch_1
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    move-result-object v7

    goto :goto_0

    .line 187
    :cond_0
    move-object v7, v0

    :try_start_1
    invoke-virtual {v7}, Ljava/io/InputStream;->close()V
    :try_end_1
    .catch Ljava/io/IOException; {:try_start_1 .. :try_end_1} :catch_0

    .line 190
    .line 192
    :goto_1
    move-object v7, v2

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    move-object v0, v7

    .end local v0    # "is":Ljava/io/InputStream;
    return-object v0

    .line 188
    .restart local v0    # "is":Ljava/io/InputStream;
    :catch_0
    move-exception v7

    move-object v4, v7

    .line 189
    .local v4, "e":Ljava/io/IOException;
    move-object v7, v4

    invoke-virtual {v7}, Ljava/io/IOException;->printStackTrace()V

    .line 191
    goto :goto_1

    .line 183
    .end local v4    # "e":Ljava/io/IOException;
    :catch_1
    move-exception v7

    move-object v4, v7

    .line 184
    .restart local v4    # "e":Ljava/io/IOException;
    move-object v7, v4

    :try_start_2
    invoke-virtual {v7}, Ljava/io/IOException;->printStackTrace()V
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    .line 187
    move-object v7, v0

    :try_start_3
    invoke-virtual {v7}, Ljava/io/InputStream;->close()V
    :try_end_3
    .catch Ljava/io/IOException; {:try_start_3 .. :try_end_3} :catch_2

    .line 190
    goto :goto_1

    .line 188
    :catch_2
    move-exception v7

    move-object v4, v7

    .line 189
    move-object v7, v4

    invoke-virtual {v7}, Ljava/io/IOException;->printStackTrace()V

    .line 191
    goto :goto_1

    .line 186
    .end local v4    # "e":Ljava/io/IOException;
    :catchall_0
    move-exception v7

    move-object v5, v7

    .line 187
    move-object v7, v0

    :try_start_4
    invoke-virtual {v7}, Ljava/io/InputStream;->close()V
    :try_end_4
    .catch Ljava/io/IOException; {:try_start_4 .. :try_end_4} :catch_3

    .line 190
    :goto_2
    move-object v7, v5

    throw v7

    .line 188
    :catch_3
    move-exception v7

    move-object v6, v7

    .line 189
    .local v6, "e":Ljava/io/IOException;
    move-object v7, v6

    invoke-virtual {v7}, Ljava/io/IOException;->printStackTrace()V

    goto :goto_2
.end method

.method public static getJSONFromUrl(Landroid/app/Activity;Ljava/lang/String;)Ljava/lang/String;
    .locals 23

    .prologue
    .line 41
    move-object/from16 v2, p0

    .local v2, "activity":Landroid/app/Activity;
    move-object/from16 v3, p1

    .local v3, "method":Ljava/lang/String;
    move-object/from16 v17, v2

    invoke-static/range {v17 .. v17}, Landroid/preference/PreferenceManager;->getDefaultSharedPreferences(Landroid/content/Context;)Landroid/content/SharedPreferences;

    move-result-object v17

    move-object/from16 v4, v17

    .line 42
    .local v4, "prefs":Landroid/content/SharedPreferences;
    move-object/from16 v17, v4

    const-string v18, "Host"

    const-string v19, ""

    invoke-interface/range {v17 .. v19}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v17

    move-object/from16 v5, v17

    .line 43
    .local v5, "st":Ljava/lang/String;
    new-instance v17, Ljava/lang/StringBuilder;

    move-object/from16 v22, v17

    move-object/from16 v17, v22

    move-object/from16 v18, v22

    invoke-direct/range {v18 .. v18}, Ljava/lang/StringBuilder;-><init>()V

    const-string v18, "http://"

    invoke-virtual/range {v17 .. v18}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v17

    move-object/from16 v18, v5

    invoke-virtual/range {v17 .. v18}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v17

    const-string v18, ":35051/Agency.asmx/"

    invoke-virtual/range {v17 .. v18}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v17

    move-object/from16 v18, v3

    invoke-virtual/range {v17 .. v18}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v17

    invoke-virtual/range {v17 .. v17}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v17

    move-object/from16 v6, v17

    .line 44
    .local v6, "host":Ljava/lang/String;
    new-instance v17, Ljava/lang/StringBuilder;

    move-object/from16 v22, v17

    move-object/from16 v17, v22

    move-object/from16 v18, v22

    invoke-direct/range {v18 .. v18}, Ljava/lang/StringBuilder;-><init>()V

    move-object/from16 v7, v17

    .line 45
    .local v7, "builder":Ljava/lang/StringBuilder;
    new-instance v17, Lorg/apache/http/impl/client/DefaultHttpClient;

    move-object/from16 v22, v17

    move-object/from16 v17, v22

    move-object/from16 v18, v22

    invoke-direct/range {v18 .. v18}, Lorg/apache/http/impl/client/DefaultHttpClient;-><init>()V

    move-object/from16 v8, v17

    .line 47
    .local v8, "client":Lorg/apache/http/client/HttpClient;
    new-instance v17, Lorg/apache/http/client/methods/HttpGet;

    move-object/from16 v22, v17

    move-object/from16 v17, v22

    move-object/from16 v18, v22

    move-object/from16 v19, v6

    invoke-direct/range {v18 .. v19}, Lorg/apache/http/client/methods/HttpGet;-><init>(Ljava/lang/String;)V

    move-object/from16 v9, v17

    .line 49
    .local v9, "httpGet":Lorg/apache/http/client/methods/HttpGet;
    move-object/from16 v17, v8

    move-object/from16 v18, v9

    :try_start_0
    invoke-interface/range {v17 .. v18}, Lorg/apache/http/client/HttpClient;->execute(Lorg/apache/http/client/methods/HttpUriRequest;)Lorg/apache/http/HttpResponse;

    move-result-object v17

    move-object/from16 v10, v17

    .line 50
    .local v10, "response":Lorg/apache/http/HttpResponse;
    move-object/from16 v17, v10

    invoke-interface/range {v17 .. v17}, Lorg/apache/http/HttpResponse;->getStatusLine()Lorg/apache/http/StatusLine;

    move-result-object v17

    move-object/from16 v11, v17

    .line 51
    .local v11, "statusLine":Lorg/apache/http/StatusLine;
    move-object/from16 v17, v11

    invoke-interface/range {v17 .. v17}, Lorg/apache/http/StatusLine;->getStatusCode()I

    move-result v17

    move/from16 v12, v17

    .line 52
    .local v12, "statusCode":I
    move/from16 v17, v12

    const/16 v18, 0xc8

    move/from16 v0, v17

    move/from16 v1, v18

    if-ne v0, v1, :cond_1

    .line 53
    move-object/from16 v17, v10

    invoke-interface/range {v17 .. v17}, Lorg/apache/http/HttpResponse;->getEntity()Lorg/apache/http/HttpEntity;

    move-result-object v17

    move-object/from16 v13, v17

    .line 54
    .local v13, "entity":Lorg/apache/http/HttpEntity;
    move-object/from16 v17, v13

    invoke-interface/range {v17 .. v17}, Lorg/apache/http/HttpEntity;->getContent()Ljava/io/InputStream;

    move-result-object v17

    move-object/from16 v14, v17

    .line 55
    .local v14, "content":Ljava/io/InputStream;
    new-instance v17, Ljava/io/BufferedReader;

    move-object/from16 v22, v17

    move-object/from16 v17, v22

    move-object/from16 v18, v22

    new-instance v19, Ljava/io/InputStreamReader;

    move-object/from16 v22, v19

    move-object/from16 v19, v22

    move-object/from16 v20, v22

    move-object/from16 v21, v14

    invoke-direct/range {v20 .. v21}, Ljava/io/InputStreamReader;-><init>(Ljava/io/InputStream;)V

    invoke-direct/range {v18 .. v19}, Ljava/io/BufferedReader;-><init>(Ljava/io/Reader;)V

    move-object/from16 v15, v17

    .line 57
    .local v15, "reader":Ljava/io/BufferedReader;
    :goto_0
    move-object/from16 v17, v15

    invoke-virtual/range {v17 .. v17}, Ljava/io/BufferedReader;->readLine()Ljava/lang/String;

    move-result-object v17

    move-object/from16 v22, v17

    move-object/from16 v17, v22

    move-object/from16 v18, v22

    move-object/from16 v16, v18

    .local v16, "line":Ljava/lang/String;
    if-eqz v17, :cond_0

    .line 58
    move-object/from16 v17, v7

    move-object/from16 v18, v16

    invoke-virtual/range {v17 .. v18}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;
    :try_end_0
    .catch Lorg/apache/http/client/ClientProtocolException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Ljava/io/IOException; {:try_start_0 .. :try_end_0} :catch_1

    move-result-object v17

    goto :goto_0

    .line 60
    .line 81
    .line 85
    .end local v10    # "response":Lorg/apache/http/HttpResponse;
    .end local v11    # "statusLine":Lorg/apache/http/StatusLine;
    .end local v12    # "statusCode":I
    .end local v13    # "entity":Lorg/apache/http/HttpEntity;
    .end local v14    # "content":Ljava/io/InputStream;
    .end local v15    # "reader":Ljava/io/BufferedReader;
    .end local v16    # "line":Ljava/lang/String;
    :cond_0
    :goto_1
    :try_start_1
    sget-object v17, Ljava/lang/System;->out:Ljava/io/PrintStream;

    new-instance v18, Ljava/lang/StringBuilder;

    move-object/from16 v22, v18

    move-object/from16 v18, v22

    move-object/from16 v19, v22

    invoke-direct/range {v19 .. v19}, Ljava/lang/StringBuilder;-><init>()V

    const-string v19, "finalResult "

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    move-object/from16 v19, v7

    invoke-virtual/range {v19 .. v19}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v19

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    invoke-virtual/range {v18 .. v18}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v18

    invoke-virtual/range {v17 .. v18}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    .line 87
    move-object/from16 v17, v7

    invoke-virtual/range {v17 .. v17}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v17

    sput-object v17, Lcom/example/paul/a_sacco/JsonParser;->jarray:Ljava/lang/String;
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_2

    .line 90
    .line 93
    :goto_2
    sget-object v17, Lcom/example/paul/a_sacco/JsonParser;->jarray:Ljava/lang/String;

    move-object/from16 v2, v17

    .end local v2    # "activity":Landroid/app/Activity;
    return-object v2

    .line 61
    .restart local v2    # "activity":Landroid/app/Activity;
    .restart local v10    # "response":Lorg/apache/http/HttpResponse;
    .restart local v11    # "statusLine":Lorg/apache/http/StatusLine;
    .restart local v12    # "statusCode":I
    :cond_1
    :try_start_2
    const-string v17, "==>"

    move/from16 v18, v12

    invoke-static/range {v18 .. v18}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v18

    invoke-static/range {v17 .. v18}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    move-result v17

    .line 62
    const-string v17, "==>"

    move-object/from16 v18, v11

    invoke-interface/range {v18 .. v18}, Lorg/apache/http/StatusLine;->getReasonPhrase()Ljava/lang/String;

    move-result-object v18

    invoke-static/range {v18 .. v18}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v18

    invoke-static/range {v17 .. v18}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    move-result v17

    .line 63
    const-string v17, "==>"

    const-string v18, "Failed to download file"

    invoke-static/range {v17 .. v18}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_2
    .catch Lorg/apache/http/client/ClientProtocolException; {:try_start_2 .. :try_end_2} :catch_0
    .catch Ljava/io/IOException; {:try_start_2 .. :try_end_2} :catch_1

    move-result v17

    goto :goto_1

    .line 65
    .end local v10    # "response":Lorg/apache/http/HttpResponse;
    .end local v11    # "statusLine":Lorg/apache/http/StatusLine;
    .end local v12    # "statusCode":I
    :catch_0
    move-exception v17

    move-object/from16 v10, v17

    .line 66
    .local v10, "e":Lorg/apache/http/client/ClientProtocolException;
    move-object/from16 v17, v2

    new-instance v18, Lcom/example/paul/a_sacco/JsonParser$1;

    move-object/from16 v22, v18

    move-object/from16 v18, v22

    move-object/from16 v19, v22

    move-object/from16 v20, v2

    invoke-direct/range {v19 .. v20}, Lcom/example/paul/a_sacco/JsonParser$1;-><init>(Landroid/app/Activity;)V

    invoke-virtual/range {v17 .. v18}, Landroid/app/Activity;->runOnUiThread(Ljava/lang/Runnable;)V

    .line 72
    move-object/from16 v17, v10

    invoke-virtual/range {v17 .. v17}, Lorg/apache/http/client/ClientProtocolException;->printStackTrace()V

    .line 81
    goto :goto_1

    .line 73
    .end local v10    # "e":Lorg/apache/http/client/ClientProtocolException;
    :catch_1
    move-exception v17

    move-object/from16 v10, v17

    .line 74
    .local v10, "e":Ljava/io/IOException;
    move-object/from16 v17, v2

    new-instance v18, Lcom/example/paul/a_sacco/JsonParser$2;

    move-object/from16 v22, v18

    move-object/from16 v18, v22

    move-object/from16 v19, v22

    move-object/from16 v20, v2

    invoke-direct/range {v19 .. v20}, Lcom/example/paul/a_sacco/JsonParser$2;-><init>(Landroid/app/Activity;)V

    invoke-virtual/range {v17 .. v18}, Landroid/app/Activity;->runOnUiThread(Ljava/lang/Runnable;)V

    .line 80
    move-object/from16 v17, v10

    invoke-virtual/range {v17 .. v17}, Ljava/io/IOException;->printStackTrace()V

    goto/16 :goto_1

    .line 88
    .end local v10    # "e":Ljava/io/IOException;
    :catch_2
    move-exception v17

    move-object/from16 v10, v17

    .line 89
    .local v10, "e":Ljava/lang/Exception;
    const-string v17, "JSON Parser"

    new-instance v18, Ljava/lang/StringBuilder;

    move-object/from16 v22, v18

    move-object/from16 v18, v22

    move-object/from16 v19, v22

    invoke-direct/range {v19 .. v19}, Ljava/lang/StringBuilder;-><init>()V

    const-string v19, "Error parsing data "

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    move-object/from16 v19, v10

    invoke-virtual/range {v19 .. v19}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v19

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    invoke-virtual/range {v18 .. v18}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v18

    invoke-static/range {v17 .. v18}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    move-result v17

    goto/16 :goto_2
.end method
