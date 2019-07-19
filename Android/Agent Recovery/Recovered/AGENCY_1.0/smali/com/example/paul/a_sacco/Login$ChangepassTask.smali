.class public Lcom/example/paul/a_sacco/Login$ChangepassTask;
.super Landroid/os/AsyncTask;
.source "Login.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/example/paul/a_sacco/Login;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1
    name = "ChangepassTask"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Landroid/os/AsyncTask",
        "<",
        "Ljava/lang/Void;",
        "Ljava/lang/Void;",
        "Lcom/example/paul/a_sacco/Agent;",
        ">;"
    }
.end annotation


# instance fields
.field private magent:Lcom/example/paul/a_sacco/Agent;

.field final synthetic this$0:Lcom/example/paul/a_sacco/Login;


# direct methods
.method constructor <init>(Lcom/example/paul/a_sacco/Login;Lcom/example/paul/a_sacco/Agent;)V
    .locals 5

    .prologue
    .line 202
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Login$ChangepassTask;
    move-object v1, p1

    move-object v2, p2

    .local v2, "agent":Lcom/example/paul/a_sacco/Agent;
    move-object v3, v0

    move-object v4, v1

    iput-object v4, v3, Lcom/example/paul/a_sacco/Login$ChangepassTask;->this$0:Lcom/example/paul/a_sacco/Login;

    move-object v3, v0

    invoke-direct {v3}, Landroid/os/AsyncTask;-><init>()V

    .line 203
    move-object v3, v0

    move-object v4, v2

    iput-object v4, v3, Lcom/example/paul/a_sacco/Login$ChangepassTask;->magent:Lcom/example/paul/a_sacco/Agent;

    .line 204
    return-void
.end method


# virtual methods
.method protected varargs doInBackground([Ljava/lang/Void;)Lcom/example/paul/a_sacco/Agent;
    .locals 11

    .prologue
    .line 215
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Login$ChangepassTask;
    move-object v1, p1

    .local v1, "params":[Ljava/lang/Void;
    :try_start_0
    new-instance v6, Lcom/google/gson/Gson;

    move-object v10, v6

    move-object v6, v10

    move-object v7, v10

    invoke-direct {v7}, Lcom/google/gson/Gson;-><init>()V

    move-object v2, v6

    .line 216
    .local v2, "gson":Lcom/google/gson/Gson;
    sget-object v6, Lcom/example/paul/a_sacco/Login;->agent:Lcom/example/paul/a_sacco/Agent;

    const/4 v7, 0x0

    iput-object v7, v6, Lcom/example/paul/a_sacco/Agent;->message:Ljava/lang/String;

    .line 217
    move-object v6, v2

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/Login$ChangepassTask;->magent:Lcom/example/paul/a_sacco/Agent;

    invoke-virtual {v6, v7}, Lcom/google/gson/Gson;->toJson(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v6

    move-object v3, v6

    .line 219
    .local v3, "jsondata":Ljava/lang/String;
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/Login$ChangepassTask;->this$0:Lcom/example/paul/a_sacco/Login;

    const-string v7, "Changepass"

    move-object v8, v3

    const-string v9, "login"

    invoke-static {v6, v7, v8, v9}, Lcom/example/paul/a_sacco/JsonParser;->SendHttpPost(Landroid/app/Activity;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    move-object v4, v6

    .line 221
    .local v4, "json":Ljava/lang/String;
    new-instance v6, Lcom/example/paul/a_sacco/Login$ChangepassTask$1;

    move-object v10, v6

    move-object v6, v10

    move-object v7, v10

    move-object v8, v0

    invoke-direct {v7, v8}, Lcom/example/paul/a_sacco/Login$ChangepassTask$1;-><init>(Lcom/example/paul/a_sacco/Login$ChangepassTask;)V

    invoke-virtual {v6}, Lcom/example/paul/a_sacco/Login$ChangepassTask$1;->getType()Ljava/lang/reflect/Type;

    move-result-object v6

    move-object v5, v6

    .line 224
    .local v5, "collectionType":Ljava/lang/reflect/Type;
    move-object v6, v0

    new-instance v7, Lcom/google/gson/Gson;

    move-object v10, v7

    move-object v7, v10

    move-object v8, v10

    invoke-direct {v8}, Lcom/google/gson/Gson;-><init>()V

    move-object v8, v4

    move-object v9, v5

    invoke-virtual {v7, v8, v9}, Lcom/google/gson/Gson;->fromJson(Ljava/lang/String;Ljava/lang/reflect/Type;)Ljava/lang/Object;

    move-result-object v7

    check-cast v7, Lcom/example/paul/a_sacco/Agent;

    iput-object v7, v6, Lcom/example/paul/a_sacco/Login$ChangepassTask;->magent:Lcom/example/paul/a_sacco/Agent;

    .line 226
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/Login$ChangepassTask;->magent:Lcom/example/paul/a_sacco/Agent;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-object v0, v6

    .line 234
    .end local v0    # "this":Lcom/example/paul/a_sacco/Login$ChangepassTask;
    .end local v2    # "gson":Lcom/google/gson/Gson;
    .end local v3    # "jsondata":Ljava/lang/String;
    .end local v4    # "json":Ljava/lang/String;
    .end local v5    # "collectionType":Ljava/lang/reflect/Type;
    :goto_0
    return-object v0

    .line 227
    .restart local v0    # "this":Lcom/example/paul/a_sacco/Login$ChangepassTask;
    :catch_0
    move-exception v6

    move-object v2, v6

    .line 228
    .local v2, "e":Ljava/lang/Exception;
    move-object v6, v2

    invoke-virtual {v6}, Ljava/lang/Exception;->printStackTrace()V

    .line 230
    move-object v6, v2

    invoke-virtual {v6}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v6

    const-string v7, "Connection to"

    invoke-virtual {v6, v7}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v6

    if-eqz v6, :cond_0

    .line 231
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/Login$ChangepassTask;->magent:Lcom/example/paul/a_sacco/Agent;

    const-string v7, "No Connection, make sure that your mobile data is enabled, or you are on a wifi."

    iput-object v7, v6, Lcom/example/paul/a_sacco/Agent;->message:Ljava/lang/String;

    .line 234
    :goto_1
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/Login$ChangepassTask;->magent:Lcom/example/paul/a_sacco/Agent;

    move-object v0, v6

    goto :goto_0

    .line 233
    :cond_0
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/Login$ChangepassTask;->magent:Lcom/example/paul/a_sacco/Agent;

    move-object v7, v2

    invoke-virtual {v7}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v7

    iput-object v7, v6, Lcom/example/paul/a_sacco/Agent;->message:Ljava/lang/String;

    goto :goto_1
.end method

.method protected bridge synthetic doInBackground([Ljava/lang/Object;)Ljava/lang/Object;
    .locals 4

    .prologue
    .line 198
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Login$ChangepassTask;
    move-object v1, p1

    .local v1, "x0":[Ljava/lang/Object;
    move-object v2, v0

    move-object v3, v1

    check-cast v3, [Ljava/lang/Void;

    invoke-virtual {v2, v3}, Lcom/example/paul/a_sacco/Login$ChangepassTask;->doInBackground([Ljava/lang/Void;)Lcom/example/paul/a_sacco/Agent;

    move-result-object v2

    move-object v0, v2

    .end local v0    # "this":Lcom/example/paul/a_sacco/Login$ChangepassTask;
    return-object v0
.end method

.method protected onCancelled()V
    .locals 0

    .prologue
    .line 247
    return-void
.end method

.method protected onPostExecute(Lcom/example/paul/a_sacco/Agent;)V
    .locals 0
    .param p1, "success"    # Lcom/example/paul/a_sacco/Agent;

    .prologue
    .line 242
    return-void
.end method

.method protected bridge synthetic onPostExecute(Ljava/lang/Object;)V
    .locals 4

    .prologue
    .line 198
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Login$ChangepassTask;
    move-object v1, p1

    .local v1, "x0":Ljava/lang/Object;
    move-object v2, v0

    move-object v3, v1

    check-cast v3, Lcom/example/paul/a_sacco/Agent;

    invoke-virtual {v2, v3}, Lcom/example/paul/a_sacco/Login$ChangepassTask;->onPostExecute(Lcom/example/paul/a_sacco/Agent;)V

    return-void
.end method

.method protected onPreExecute()V
    .locals 0

    .prologue
    .line 208
    return-void
.end method
