.class public Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;
.super Landroid/os/AsyncTask;
.source "AgencyListActivity.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/example/paul/a_sacco/AgencyListActivity;
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

.field final synthetic this$0:Lcom/example/paul/a_sacco/AgencyListActivity;


# direct methods
.method constructor <init>(Lcom/example/paul/a_sacco/AgencyListActivity;Lcom/example/paul/a_sacco/Agent;)V
    .locals 5

    .prologue
    .line 135
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;
    move-object v1, p1

    move-object v2, p2

    .local v2, "agent":Lcom/example/paul/a_sacco/Agent;
    move-object v3, v0

    move-object v4, v1

    iput-object v4, v3, Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;->this$0:Lcom/example/paul/a_sacco/AgencyListActivity;

    move-object v3, v0

    invoke-direct {v3}, Landroid/os/AsyncTask;-><init>()V

    .line 136
    move-object v3, v0

    move-object v4, v2

    iput-object v4, v3, Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;->magent:Lcom/example/paul/a_sacco/Agent;

    .line 137
    return-void
.end method


# virtual methods
.method protected varargs doInBackground([Ljava/lang/Void;)Lcom/example/paul/a_sacco/Agent;
    .locals 11

    .prologue
    .line 147
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;
    move-object v1, p1

    .local v1, "params":[Ljava/lang/Void;
    :try_start_0
    new-instance v6, Lcom/google/gson/Gson;

    move-object v10, v6

    move-object v6, v10

    move-object v7, v10

    invoke-direct {v7}, Lcom/google/gson/Gson;-><init>()V

    move-object v2, v6

    .line 149
    .local v2, "gson":Lcom/google/gson/Gson;
    move-object v6, v2

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;->magent:Lcom/example/paul/a_sacco/Agent;

    invoke-virtual {v6, v7}, Lcom/google/gson/Gson;->toJson(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v6

    move-object v3, v6

    .line 151
    .local v3, "jsondata":Ljava/lang/String;
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;->this$0:Lcom/example/paul/a_sacco/AgencyListActivity;

    const-string v7, "Changepass"

    move-object v8, v3

    const-string v9, "login"

    invoke-static {v6, v7, v8, v9}, Lcom/example/paul/a_sacco/JsonParser;->SendHttpPost(Landroid/app/Activity;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    move-object v4, v6

    .line 153
    .local v4, "json":Ljava/lang/String;
    new-instance v6, Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask$1;

    move-object v10, v6

    move-object v6, v10

    move-object v7, v10

    move-object v8, v0

    invoke-direct {v7, v8}, Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask$1;-><init>(Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;)V

    invoke-virtual {v6}, Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask$1;->getType()Ljava/lang/reflect/Type;

    move-result-object v6

    move-object v5, v6

    .line 156
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

    iput-object v7, v6, Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;->magent:Lcom/example/paul/a_sacco/Agent;

    .line 158
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;->magent:Lcom/example/paul/a_sacco/Agent;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-object v0, v6

    .line 166
    .end local v0    # "this":Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;
    .end local v2    # "gson":Lcom/google/gson/Gson;
    .end local v3    # "jsondata":Ljava/lang/String;
    .end local v4    # "json":Ljava/lang/String;
    .end local v5    # "collectionType":Ljava/lang/reflect/Type;
    :goto_0
    return-object v0

    .line 159
    .restart local v0    # "this":Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;
    :catch_0
    move-exception v6

    move-object v2, v6

    .line 160
    .local v2, "e":Ljava/lang/Exception;
    move-object v6, v2

    invoke-virtual {v6}, Ljava/lang/Exception;->printStackTrace()V

    .line 162
    move-object v6, v2

    invoke-virtual {v6}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v6

    const-string v7, "Connection to"

    invoke-virtual {v6, v7}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v6

    if-eqz v6, :cond_0

    .line 163
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;->magent:Lcom/example/paul/a_sacco/Agent;

    const-string v7, "No Connection, make sure that your mobile data is enabled, or you are on a wifi."

    iput-object v7, v6, Lcom/example/paul/a_sacco/Agent;->message:Ljava/lang/String;

    .line 166
    :goto_1
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;->magent:Lcom/example/paul/a_sacco/Agent;

    move-object v0, v6

    goto :goto_0

    .line 165
    :cond_0
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;->magent:Lcom/example/paul/a_sacco/Agent;

    move-object v7, v2

    invoke-virtual {v7}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v7

    iput-object v7, v6, Lcom/example/paul/a_sacco/Agent;->message:Ljava/lang/String;

    goto :goto_1
.end method

.method protected bridge synthetic doInBackground([Ljava/lang/Object;)Ljava/lang/Object;
    .locals 4

    .prologue
    .line 131
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;
    move-object v1, p1

    .local v1, "x0":[Ljava/lang/Object;
    move-object v2, v0

    move-object v3, v1

    check-cast v3, [Ljava/lang/Void;

    invoke-virtual {v2, v3}, Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;->doInBackground([Ljava/lang/Void;)Lcom/example/paul/a_sacco/Agent;

    move-result-object v2

    move-object v0, v2

    .end local v0    # "this":Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;
    return-object v0
.end method

.method protected onCancelled()V
    .locals 0

    .prologue
    .line 178
    return-void
.end method

.method protected onPostExecute(Lcom/example/paul/a_sacco/Agent;)V
    .locals 5

    .prologue
    .line 171
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;
    move-object v1, p1

    .local v1, "success":Lcom/example/paul/a_sacco/Agent;
    move-object v2, v1

    iget-object v2, v2, Lcom/example/paul/a_sacco/Agent;->new_pin:Ljava/lang/String;

    if-nez v2, :cond_0

    .line 172
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;->this$0:Lcom/example/paul/a_sacco/AgencyListActivity;

    invoke-virtual {v2}, Lcom/example/paul/a_sacco/AgencyListActivity;->getApplicationContext()Landroid/content/Context;

    move-result-object v2

    const-string v3, "Password successfully changed."

    const/4 v4, 0x1

    invoke-static {v2, v3, v4}, Landroid/widget/Toast;->makeText(Landroid/content/Context;Ljava/lang/CharSequence;I)Landroid/widget/Toast;

    move-result-object v2

    invoke-virtual {v2}, Landroid/widget/Toast;->show()V

    .line 173
    :cond_0
    return-void
.end method

.method protected bridge synthetic onPostExecute(Ljava/lang/Object;)V
    .locals 4

    .prologue
    .line 131
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;
    move-object v1, p1

    .local v1, "x0":Ljava/lang/Object;
    move-object v2, v0

    move-object v3, v1

    check-cast v3, Lcom/example/paul/a_sacco/Agent;

    invoke-virtual {v2, v3}, Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;->onPostExecute(Lcom/example/paul/a_sacco/Agent;)V

    return-void
.end method

.method protected onPreExecute()V
    .locals 0

    .prologue
    .line 141
    return-void
.end method
