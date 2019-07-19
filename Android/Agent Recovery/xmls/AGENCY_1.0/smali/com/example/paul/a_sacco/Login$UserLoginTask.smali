.class public Lcom/example/paul/a_sacco/Login$UserLoginTask;
.super Landroid/os/AsyncTask;
.source "Login.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/example/paul/a_sacco/Login;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1
    name = "UserLoginTask"
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
.field private final dialog:Landroid/app/ProgressDialog;

.field private magent:Lcom/example/paul/a_sacco/Agent;

.field final synthetic this$0:Lcom/example/paul/a_sacco/Login;


# direct methods
.method constructor <init>(Lcom/example/paul/a_sacco/Login;Lcom/example/paul/a_sacco/Agent;)V
    .locals 8

    .prologue
    .line 125
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Login$UserLoginTask;
    move-object v1, p1

    move-object v2, p2

    .local v2, "agent":Lcom/example/paul/a_sacco/Agent;
    move-object v3, v0

    move-object v4, v1

    iput-object v4, v3, Lcom/example/paul/a_sacco/Login$UserLoginTask;->this$0:Lcom/example/paul/a_sacco/Login;

    move-object v3, v0

    invoke-direct {v3}, Landroid/os/AsyncTask;-><init>()V

    .line 122
    move-object v3, v0

    new-instance v4, Landroid/app/ProgressDialog;

    move-object v7, v4

    move-object v4, v7

    move-object v5, v7

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/Login$UserLoginTask;->this$0:Lcom/example/paul/a_sacco/Login;

    invoke-direct {v5, v6}, Landroid/app/ProgressDialog;-><init>(Landroid/content/Context;)V

    iput-object v4, v3, Lcom/example/paul/a_sacco/Login$UserLoginTask;->dialog:Landroid/app/ProgressDialog;

    .line 126
    move-object v3, v0

    move-object v4, v2

    iput-object v4, v3, Lcom/example/paul/a_sacco/Login$UserLoginTask;->magent:Lcom/example/paul/a_sacco/Agent;

    .line 127
    return-void
.end method


# virtual methods
.method protected varargs doInBackground([Ljava/lang/Void;)Lcom/example/paul/a_sacco/Agent;
    .locals 11

    .prologue
    .line 139
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Login$UserLoginTask;
    move-object v1, p1

    .local v1, "params":[Ljava/lang/Void;
    :try_start_0
    new-instance v6, Lcom/google/gson/Gson;

    move-object v10, v6

    move-object v6, v10

    move-object v7, v10

    invoke-direct {v7}, Lcom/google/gson/Gson;-><init>()V

    move-object v2, v6

    .line 140
    .local v2, "gson":Lcom/google/gson/Gson;
    sget-object v6, Lcom/example/paul/a_sacco/Login;->agent:Lcom/example/paul/a_sacco/Agent;

    const/4 v7, 0x0

    iput-object v7, v6, Lcom/example/paul/a_sacco/Agent;->message:Ljava/lang/String;

    .line 141
    move-object v6, v2

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/Login$UserLoginTask;->magent:Lcom/example/paul/a_sacco/Agent;

    invoke-virtual {v6, v7}, Lcom/google/gson/Gson;->toJson(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v6

    move-object v3, v6

    .line 144
    .local v3, "jsondata":Ljava/lang/String;
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/Login$UserLoginTask;->this$0:Lcom/example/paul/a_sacco/Login;

    const-string v7, "Login"

    move-object v8, v3

    const-string v9, "Login"

    invoke-static {v6, v7, v8, v9}, Lcom/example/paul/a_sacco/JsonParser;->SendHttpPost(Landroid/app/Activity;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    move-object v4, v6

    .line 146
    .local v4, "json":Ljava/lang/String;
    new-instance v6, Lcom/example/paul/a_sacco/Login$UserLoginTask$1;

    move-object v10, v6

    move-object v6, v10

    move-object v7, v10

    move-object v8, v0

    invoke-direct {v7, v8}, Lcom/example/paul/a_sacco/Login$UserLoginTask$1;-><init>(Lcom/example/paul/a_sacco/Login$UserLoginTask;)V

    invoke-virtual {v6}, Lcom/example/paul/a_sacco/Login$UserLoginTask$1;->getType()Ljava/lang/reflect/Type;

    move-result-object v6

    move-object v5, v6

    .line 149
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

    iput-object v7, v6, Lcom/example/paul/a_sacco/Login$UserLoginTask;->magent:Lcom/example/paul/a_sacco/Agent;

    .line 151
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/Login$UserLoginTask;->magent:Lcom/example/paul/a_sacco/Agent;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-object v0, v6

    .line 159
    .end local v0    # "this":Lcom/example/paul/a_sacco/Login$UserLoginTask;
    .end local v2    # "gson":Lcom/google/gson/Gson;
    .end local v3    # "jsondata":Ljava/lang/String;
    .end local v4    # "json":Ljava/lang/String;
    .end local v5    # "collectionType":Ljava/lang/reflect/Type;
    :goto_0
    return-object v0

    .line 152
    .restart local v0    # "this":Lcom/example/paul/a_sacco/Login$UserLoginTask;
    :catch_0
    move-exception v6

    move-object v2, v6

    .line 153
    .local v2, "e":Ljava/lang/Exception;
    move-object v6, v2

    invoke-virtual {v6}, Ljava/lang/Exception;->printStackTrace()V

    .line 155
    move-object v6, v2

    invoke-virtual {v6}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v6

    const-string v7, "Connection to"

    invoke-virtual {v6, v7}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v6

    if-eqz v6, :cond_0

    .line 156
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/Login$UserLoginTask;->magent:Lcom/example/paul/a_sacco/Agent;

    const-string v7, "No Connection, make sure that your mobile data is enabled, or you are on a wifi."

    iput-object v7, v6, Lcom/example/paul/a_sacco/Agent;->message:Ljava/lang/String;

    .line 159
    :goto_1
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/Login$UserLoginTask;->magent:Lcom/example/paul/a_sacco/Agent;

    move-object v0, v6

    goto :goto_0

    .line 158
    :cond_0
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/Login$UserLoginTask;->magent:Lcom/example/paul/a_sacco/Agent;

    move-object v7, v2

    invoke-virtual {v7}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v7

    iput-object v7, v6, Lcom/example/paul/a_sacco/Agent;->message:Ljava/lang/String;

    goto :goto_1
.end method

.method protected bridge synthetic doInBackground([Ljava/lang/Object;)Ljava/lang/Object;
    .locals 4

    .prologue
    .line 121
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Login$UserLoginTask;
    move-object v1, p1

    .local v1, "x0":[Ljava/lang/Object;
    move-object v2, v0

    move-object v3, v1

    check-cast v3, [Ljava/lang/Void;

    invoke-virtual {v2, v3}, Lcom/example/paul/a_sacco/Login$UserLoginTask;->doInBackground([Ljava/lang/Void;)Lcom/example/paul/a_sacco/Agent;

    move-result-object v2

    move-object v0, v2

    .end local v0    # "this":Lcom/example/paul/a_sacco/Login$UserLoginTask;
    return-object v0
.end method

.method protected onCancelled()V
    .locals 0

    .prologue
    .line 194
    return-void
.end method

.method protected onPostExecute(Lcom/example/paul/a_sacco/Agent;)V
    .locals 9

    .prologue
    .line 165
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Login$UserLoginTask;
    move-object v1, p1

    .local v1, "success":Lcom/example/paul/a_sacco/Agent;
    move-object v3, v0

    iget-object v3, v3, Lcom/example/paul/a_sacco/Login$UserLoginTask;->dialog:Landroid/app/ProgressDialog;

    invoke-virtual {v3}, Landroid/app/ProgressDialog;->isShowing()Z

    move-result v3

    if-eqz v3, :cond_0

    .line 166
    move-object v3, v0

    iget-object v3, v3, Lcom/example/paul/a_sacco/Login$UserLoginTask;->dialog:Landroid/app/ProgressDialog;

    invoke-virtual {v3}, Landroid/app/ProgressDialog;->dismiss()V

    .line 168
    :cond_0
    move-object v3, v1

    iget-boolean v3, v3, Lcom/example/paul/a_sacco/Agent;->logged_in:Z

    if-eqz v3, :cond_3

    .line 169
    move-object v3, v1

    sput-object v3, Lcom/example/paul/a_sacco/Login;->agent:Lcom/example/paul/a_sacco/Agent;

    .line 170
    move-object v3, v0

    iget-object v3, v3, Lcom/example/paul/a_sacco/Login$UserLoginTask;->this$0:Lcom/example/paul/a_sacco/Login;

    new-instance v4, Landroid/content/Intent;

    move-object v8, v4

    move-object v4, v8

    move-object v5, v8

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/Login$UserLoginTask;->this$0:Lcom/example/paul/a_sacco/Login;

    const-class v7, Lcom/example/paul/a_sacco/AgencyListActivity;

    invoke-direct {v5, v6, v7}, Landroid/content/Intent;-><init>(Landroid/content/Context;Ljava/lang/Class;)V

    iput-object v4, v3, Lcom/example/paul/a_sacco/Login;->intent:Landroid/content/Intent;

    .line 171
    move-object v3, v1

    iget-boolean v3, v3, Lcom/example/paul/a_sacco/Agent;->Pin_changed:Z

    if-nez v3, :cond_2

    .line 172
    new-instance v3, Lcom/example/paul/a_sacco/Login$Changepassword;

    move-object v8, v3

    move-object v3, v8

    move-object v4, v8

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/Login$UserLoginTask;->this$0:Lcom/example/paul/a_sacco/Login;

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/Login$Changepassword;-><init>(Lcom/example/paul/a_sacco/Login;)V

    move-object v2, v3

    .line 173
    .local v2, "p":Lcom/example/paul/a_sacco/Login$Changepassword;
    move-object v3, v2

    move-object v4, v1

    iget-object v4, v4, Lcom/example/paul/a_sacco/Agent;->pin:Ljava/lang/String;

    iput-object v4, v3, Lcom/example/paul/a_sacco/Login$Changepassword;->Old_password:Ljava/lang/String;

    .line 174
    move-object v3, v2

    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/Login$UserLoginTask;->this$0:Lcom/example/paul/a_sacco/Login;

    invoke-virtual {v3, v4}, Lcom/example/paul/a_sacco/Login$Changepassword;->changepin(Landroid/content/Context;)V

    .line 175
    move-object v3, v2

    iget-boolean v3, v3, Lcom/example/paul/a_sacco/Login$Changepassword;->changed:Z

    if-eqz v3, :cond_1

    .line 176
    move-object v3, v1

    move-object v4, v2

    iget-object v4, v4, Lcom/example/paul/a_sacco/Login$Changepassword;->New_password:Ljava/lang/String;

    iput-object v4, v3, Lcom/example/paul/a_sacco/Agent;->new_pin:Ljava/lang/String;

    .line 178
    .line 189
    .end local v2    # "p":Lcom/example/paul/a_sacco/Login$Changepassword;
    :cond_1
    :goto_0
    return-void

    .line 180
    :cond_2
    move-object v3, v0

    iget-object v3, v3, Lcom/example/paul/a_sacco/Login$UserLoginTask;->this$0:Lcom/example/paul/a_sacco/Login;

    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/Login$UserLoginTask;->this$0:Lcom/example/paul/a_sacco/Login;

    iget-object v4, v4, Lcom/example/paul/a_sacco/Login;->intent:Landroid/content/Intent;

    invoke-virtual {v3, v4}, Lcom/example/paul/a_sacco/Login;->startActivity(Landroid/content/Intent;)V

    goto :goto_0

    .line 184
    :cond_3
    move-object v3, v1

    iget-object v3, v3, Lcom/example/paul/a_sacco/Agent;->message:Ljava/lang/String;

    if-eqz v3, :cond_4

    .line 185
    move-object v3, v0

    iget-object v3, v3, Lcom/example/paul/a_sacco/Login$UserLoginTask;->this$0:Lcom/example/paul/a_sacco/Login;

    invoke-virtual {v3}, Lcom/example/paul/a_sacco/Login;->getApplicationContext()Landroid/content/Context;

    move-result-object v3

    move-object v4, v1

    iget-object v4, v4, Lcom/example/paul/a_sacco/Agent;->message:Ljava/lang/String;

    const/4 v5, 0x1

    invoke-static {v3, v4, v5}, Landroid/widget/Toast;->makeText(Landroid/content/Context;Ljava/lang/CharSequence;I)Landroid/widget/Toast;

    move-result-object v3

    invoke-virtual {v3}, Landroid/widget/Toast;->show()V

    goto :goto_0

    .line 187
    :cond_4
    move-object v3, v0

    iget-object v3, v3, Lcom/example/paul/a_sacco/Login$UserLoginTask;->this$0:Lcom/example/paul/a_sacco/Login;

    iget-object v3, v3, Lcom/example/paul/a_sacco/Login;->agentpin:Landroid/widget/EditText;

    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/Login$UserLoginTask;->this$0:Lcom/example/paul/a_sacco/Login;

    const v5, 0x7f0c001c

    invoke-virtual {v4, v5}, Lcom/example/paul/a_sacco/Login;->getString(I)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    goto :goto_0
.end method

.method protected bridge synthetic onPostExecute(Ljava/lang/Object;)V
    .locals 4

    .prologue
    .line 121
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Login$UserLoginTask;
    move-object v1, p1

    .local v1, "x0":Ljava/lang/Object;
    move-object v2, v0

    move-object v3, v1

    check-cast v3, Lcom/example/paul/a_sacco/Agent;

    invoke-virtual {v2, v3}, Lcom/example/paul/a_sacco/Login$UserLoginTask;->onPostExecute(Lcom/example/paul/a_sacco/Agent;)V

    return-void
.end method

.method protected onPreExecute()V
    .locals 3

    .prologue
    .line 130
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Login$UserLoginTask;
    move-object v1, v0

    iget-object v1, v1, Lcom/example/paul/a_sacco/Login$UserLoginTask;->dialog:Landroid/app/ProgressDialog;

    const-string v2, "Signing in..."

    invoke-virtual {v1, v2}, Landroid/app/ProgressDialog;->setMessage(Ljava/lang/CharSequence;)V

    .line 131
    move-object v1, v0

    iget-object v1, v1, Lcom/example/paul/a_sacco/Login$UserLoginTask;->dialog:Landroid/app/ProgressDialog;

    invoke-virtual {v1}, Landroid/app/ProgressDialog;->show()V

    .line 132
    return-void
.end method
