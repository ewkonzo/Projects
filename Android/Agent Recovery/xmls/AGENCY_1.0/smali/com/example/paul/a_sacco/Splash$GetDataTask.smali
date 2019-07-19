.class public Lcom/example/paul/a_sacco/Splash$GetDataTask;
.super Landroid/os/AsyncTask;
.source "Splash.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/example/paul/a_sacco/Splash;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1
    name = "GetDataTask"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Landroid/os/AsyncTask",
        "<",
        "Ljava/lang/Void;",
        "Ljava/lang/Void;",
        "Ljava/lang/Boolean;",
        ">;"
    }
.end annotation


# instance fields
.field final synthetic this$0:Lcom/example/paul/a_sacco/Splash;


# direct methods
.method public constructor <init>(Lcom/example/paul/a_sacco/Splash;)V
    .locals 4

    .prologue
    .line 44
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Splash$GetDataTask;
    move-object v1, p1

    move-object v2, v0

    move-object v3, v1

    iput-object v3, v2, Lcom/example/paul/a_sacco/Splash$GetDataTask;->this$0:Lcom/example/paul/a_sacco/Splash;

    move-object v2, v0

    invoke-direct {v2}, Landroid/os/AsyncTask;-><init>()V

    return-void
.end method


# virtual methods
.method protected varargs doInBackground([Ljava/lang/Void;)Ljava/lang/Boolean;
    .locals 11

    .prologue
    .line 52
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Splash$GetDataTask;
    move-object v1, p1

    .local v1, "params":[Ljava/lang/Void;
    move-object v7, v0

    :try_start_0
    iget-object v7, v7, Lcom/example/paul/a_sacco/Splash$GetDataTask;->this$0:Lcom/example/paul/a_sacco/Splash;

    const-string v8, "Getsocieties"

    invoke-static {v7, v8}, Lcom/example/paul/a_sacco/JsonParser;->getJSONFromUrl(Landroid/app/Activity;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v7

    move-object v2, v7

    .line 54
    .local v2, "json":Ljava/lang/String;
    new-instance v7, Lcom/example/paul/a_sacco/Splash$GetDataTask$1;

    move-object v10, v7

    move-object v7, v10

    move-object v8, v10

    move-object v9, v0

    invoke-direct {v8, v9}, Lcom/example/paul/a_sacco/Splash$GetDataTask$1;-><init>(Lcom/example/paul/a_sacco/Splash$GetDataTask;)V

    invoke-virtual {v7}, Lcom/example/paul/a_sacco/Splash$GetDataTask$1;->getType()Ljava/lang/reflect/Type;

    move-result-object v7

    move-object v3, v7

    .line 56
    .local v3, "collectionType":Ljava/lang/reflect/Type;
    new-instance v7, Ljava/util/ArrayList;

    move-object v10, v7

    move-object v7, v10

    move-object v8, v10

    invoke-direct {v8}, Ljava/util/ArrayList;-><init>()V

    move-object v4, v7

    .line 57
    .local v4, "soc":Ljava/util/List;, "Ljava/util/List<Lcom/example/paul/a_sacco/Societies;>;"
    new-instance v7, Lcom/google/gson/Gson;

    move-object v10, v7

    move-object v7, v10

    move-object v8, v10

    invoke-direct {v8}, Lcom/google/gson/Gson;-><init>()V

    move-object v8, v2

    move-object v9, v3

    invoke-virtual {v7, v8, v9}, Lcom/google/gson/Gson;->fromJson(Ljava/lang/String;Ljava/lang/reflect/Type;)Ljava/lang/Object;

    move-result-object v7

    check-cast v7, Ljava/util/List;

    move-object v4, v7

    .line 58
    move-object v7, v4

    invoke-interface {v7}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v7

    move-object v5, v7

    .local v5, "i$":Ljava/util/Iterator;
    :goto_0
    move-object v7, v5

    invoke-interface {v7}, Ljava/util/Iterator;->hasNext()Z

    move-result v7

    if-eqz v7, :cond_0

    move-object v7, v5

    invoke-interface {v7}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v7

    check-cast v7, Lcom/example/paul/a_sacco/Societies;

    move-object v6, v7

    .line 59
    .local v6, "b":Lcom/example/paul/a_sacco/Societies;
    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/Splash$GetDataTask;->this$0:Lcom/example/paul/a_sacco/Splash;

    iget-object v7, v7, Lcom/example/paul/a_sacco/Splash;->db:Lcom/example/paul/a_sacco/Database;

    move-object v8, v6

    invoke-static {v7, v8}, Lcom/example/paul/a_sacco/Societies;->AddSociety(Lcom/example/paul/a_sacco/Database;Lcom/example/paul/a_sacco/Societies;)Lcom/example/paul/a_sacco/Societies;

    move-result-object v7

    .line 60
    goto :goto_0

    .line 61
    .end local v6    # "b":Lcom/example/paul/a_sacco/Societies;
    :cond_0
    const/4 v7, 0x1

    invoke-static {v7}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v7

    move-object v0, v7

    .line 73
    .end local v0    # "this":Lcom/example/paul/a_sacco/Splash$GetDataTask;
    .end local v2    # "json":Ljava/lang/String;
    .end local v3    # "collectionType":Ljava/lang/reflect/Type;
    .end local v4    # "soc":Ljava/util/List;, "Ljava/util/List<Lcom/example/paul/a_sacco/Societies;>;"
    .end local v5    # "i$":Ljava/util/Iterator;
    :goto_1
    return-object v0

    .line 63
    .restart local v0    # "this":Lcom/example/paul/a_sacco/Splash$GetDataTask;
    :catch_0
    move-exception v7

    move-object v3, v7

    .line 65
    .local v3, "ex":Ljava/lang/Exception;
    move-object v7, v3

    :try_start_1
    invoke-virtual {v7}, Ljava/lang/Exception;->printStackTrace()V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_1

    .line 71
    .line 73
    const/4 v7, 0x1

    invoke-static {v7}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object v7

    move-object v0, v7

    goto :goto_1

    .line 68
    :catch_1
    move-exception v7

    move-object v2, v7

    .line 69
    .local v2, "e":Ljava/lang/Exception;
    move-object v7, v2

    invoke-virtual {v7}, Ljava/lang/Exception;->printStackTrace()V

    .line 70
    const/4 v7, 0x0

    invoke-static {v7}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object v7

    move-object v0, v7

    goto :goto_1
.end method

.method protected bridge synthetic doInBackground([Ljava/lang/Object;)Ljava/lang/Object;
    .locals 4

    .prologue
    .line 44
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Splash$GetDataTask;
    move-object v1, p1

    .local v1, "x0":[Ljava/lang/Object;
    move-object v2, v0

    move-object v3, v1

    check-cast v3, [Ljava/lang/Void;

    invoke-virtual {v2, v3}, Lcom/example/paul/a_sacco/Splash$GetDataTask;->doInBackground([Ljava/lang/Void;)Ljava/lang/Boolean;

    move-result-object v2

    move-object v0, v2

    .end local v0    # "this":Lcom/example/paul/a_sacco/Splash$GetDataTask;
    return-object v0
.end method

.method protected onCancelled()V
    .locals 0

    .prologue
    .line 85
    return-void
.end method

.method protected onPostExecute(Ljava/lang/Boolean;)V
    .locals 8

    .prologue
    .line 78
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Splash$GetDataTask;
    move-object v1, p1

    .local v1, "success":Ljava/lang/Boolean;
    new-instance v3, Landroid/content/Intent;

    move-object v7, v3

    move-object v3, v7

    move-object v4, v7

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/Splash$GetDataTask;->this$0:Lcom/example/paul/a_sacco/Splash;

    const-class v6, Lcom/example/paul/a_sacco/Login;

    invoke-direct {v4, v5, v6}, Landroid/content/Intent;-><init>(Landroid/content/Context;Ljava/lang/Class;)V

    move-object v2, v3

    .line 79
    .local v2, "intent":Landroid/content/Intent;
    move-object v3, v0

    iget-object v3, v3, Lcom/example/paul/a_sacco/Splash$GetDataTask;->this$0:Lcom/example/paul/a_sacco/Splash;

    move-object v4, v2

    invoke-virtual {v3, v4}, Lcom/example/paul/a_sacco/Splash;->startActivity(Landroid/content/Intent;)V

    .line 80
    return-void
.end method

.method protected bridge synthetic onPostExecute(Ljava/lang/Object;)V
    .locals 4

    .prologue
    .line 44
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Splash$GetDataTask;
    move-object v1, p1

    .local v1, "x0":Ljava/lang/Object;
    move-object v2, v0

    move-object v3, v1

    check-cast v3, Ljava/lang/Boolean;

    invoke-virtual {v2, v3}, Lcom/example/paul/a_sacco/Splash$GetDataTask;->onPostExecute(Ljava/lang/Boolean;)V

    return-void
.end method
