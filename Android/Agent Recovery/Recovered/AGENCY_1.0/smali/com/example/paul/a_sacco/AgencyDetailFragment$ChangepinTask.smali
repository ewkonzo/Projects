.class public Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;
.super Landroid/os/AsyncTask;
.source "AgencyDetailFragment.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/example/paul/a_sacco/AgencyDetailFragment;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1
    name = "ChangepinTask"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Landroid/os/AsyncTask",
        "<",
        "Ljava/lang/Void;",
        "Ljava/lang/Void;",
        "Lcom/example/paul/a_sacco/Transaction;",
        ">;"
    }
.end annotation


# instance fields
.field final synthetic this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

.field private tr:Lcom/example/paul/a_sacco/Transaction;


# direct methods
.method constructor <init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;Lcom/example/paul/a_sacco/Transaction;)V
    .locals 5

    .prologue
    .line 1520
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;
    move-object v1, p1

    move-object v2, p2

    .local v2, "trs":Lcom/example/paul/a_sacco/Transaction;
    move-object v3, v0

    move-object v4, v1

    iput-object v4, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object v3, v0

    invoke-direct {v3}, Landroid/os/AsyncTask;-><init>()V

    .line 1522
    move-object v3, v0

    move-object v4, v2

    iput-object v4, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;->tr:Lcom/example/paul/a_sacco/Transaction;

    .line 1523
    return-void
.end method


# virtual methods
.method protected varargs doInBackground([Ljava/lang/Void;)Lcom/example/paul/a_sacco/Transaction;
    .locals 11

    .prologue
    .line 1529
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;
    move-object v1, p1

    .local v1, "params":[Ljava/lang/Void;
    :try_start_0
    new-instance v6, Lcom/google/gson/Gson;

    move-object v10, v6

    move-object v6, v10

    move-object v7, v10

    invoke-direct {v7}, Lcom/google/gson/Gson;-><init>()V

    move-object v2, v6

    .line 1531
    .local v2, "gson":Lcom/google/gson/Gson;
    move-object v6, v2

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;->tr:Lcom/example/paul/a_sacco/Transaction;

    invoke-virtual {v6, v7}, Lcom/google/gson/Gson;->toJson(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v6

    move-object v3, v6

    .line 1533
    .local v3, "jsondata":Ljava/lang/String;
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    invoke-virtual {v6}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getActivity()Landroid/support/v4/app/FragmentActivity;

    move-result-object v6

    const-string v7, "Changepin"

    move-object v8, v3

    const-string v9, "data"

    invoke-static {v6, v7, v8, v9}, Lcom/example/paul/a_sacco/JsonParser;->SendHttpPost(Landroid/app/Activity;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    move-object v4, v6

    .line 1535
    .local v4, "json":Ljava/lang/String;
    new-instance v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask$1;

    move-object v10, v6

    move-object v6, v10

    move-object v7, v10

    move-object v8, v0

    invoke-direct {v7, v8}, Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask$1;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;)V

    invoke-virtual {v6}, Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask$1;->getType()Ljava/lang/reflect/Type;

    move-result-object v6

    move-object v5, v6

    .line 1538
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

    check-cast v7, Lcom/example/paul/a_sacco/Transaction;

    iput-object v7, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;->tr:Lcom/example/paul/a_sacco/Transaction;

    .line 1540
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;->tr:Lcom/example/paul/a_sacco/Transaction;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-object v0, v6

    .line 1547
    .end local v0    # "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;
    .end local v2    # "gson":Lcom/google/gson/Gson;
    .end local v3    # "jsondata":Ljava/lang/String;
    .end local v4    # "json":Ljava/lang/String;
    .end local v5    # "collectionType":Ljava/lang/reflect/Type;
    :goto_0
    return-object v0

    .line 1541
    .restart local v0    # "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;
    :catch_0
    move-exception v6

    move-object v2, v6

    .line 1542
    .local v2, "e":Ljava/lang/Exception;
    move-object v6, v2

    invoke-virtual {v6}, Ljava/lang/Exception;->printStackTrace()V

    .line 1543
    move-object v6, v2

    invoke-virtual {v6}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v6

    const-string v7, "Connection to"

    invoke-virtual {v6, v7}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v6

    if-eqz v6, :cond_0

    .line 1544
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;->tr:Lcom/example/paul/a_sacco/Transaction;

    const-string v7, "No Connection, make sure that your mobile data is enabled, or you are on a wifi."

    iput-object v7, v6, Lcom/example/paul/a_sacco/Transaction;->message:Ljava/lang/String;

    .line 1547
    :goto_1
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;->tr:Lcom/example/paul/a_sacco/Transaction;

    move-object v0, v6

    goto :goto_0

    .line 1546
    :cond_0
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;->tr:Lcom/example/paul/a_sacco/Transaction;

    move-object v7, v2

    invoke-virtual {v7}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v7

    iput-object v7, v6, Lcom/example/paul/a_sacco/Transaction;->message:Ljava/lang/String;

    goto :goto_1
.end method

.method protected bridge synthetic doInBackground([Ljava/lang/Object;)Ljava/lang/Object;
    .locals 4

    .prologue
    .line 1517
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;
    move-object v1, p1

    .local v1, "x0":[Ljava/lang/Object;
    move-object v2, v0

    move-object v3, v1

    check-cast v3, [Ljava/lang/Void;

    invoke-virtual {v2, v3}, Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;->doInBackground([Ljava/lang/Void;)Lcom/example/paul/a_sacco/Transaction;

    move-result-object v2

    move-object v0, v2

    .end local v0    # "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;
    return-object v0
.end method

.method protected onCancelled()V
    .locals 0

    .prologue
    .line 1566
    return-void
.end method

.method protected onPostExecute(Lcom/example/paul/a_sacco/Transaction;)V
    .locals 5

    .prologue
    .line 1553
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;
    move-object v1, p1

    .local v1, "suc":Lcom/example/paul/a_sacco/Transaction;
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object v3, v1

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    .line 1554
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v2, v2, Lcom/example/paul/a_sacco/Transaction;->status:Lcom/example/paul/a_sacco/Transaction$Status;

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Status;->Successful:Lcom/example/paul/a_sacco/Transaction$Status;

    if-ne v2, v3, :cond_1

    .line 1555
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    invoke-virtual {v2}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getActivity()Landroid/support/v4/app/FragmentActivity;

    move-result-object v2

    const-string v3, "Pin changed"

    const/4 v4, 0x1

    invoke-static {v2, v3, v4}, Landroid/widget/Toast;->makeText(Landroid/content/Context;Ljava/lang/CharSequence;I)Landroid/widget/Toast;

    move-result-object v2

    invoke-virtual {v2}, Landroid/widget/Toast;->show()V

    .line 1556
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-boolean v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->twopane:Z

    if-eqz v2, :cond_0

    .line 1557
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    invoke-virtual {v2}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getActivity()Landroid/support/v4/app/FragmentActivity;

    move-result-object v2

    invoke-virtual {v2}, Landroid/support/v4/app/FragmentActivity;->finish()V

    .line 1562
    :cond_0
    :goto_0
    return-void

    .line 1559
    :cond_1
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    move-object v3, v0

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;->tr:Lcom/example/paul/a_sacco/Transaction;

    iget-object v3, v3, Lcom/example/paul/a_sacco/Transaction;->message:Ljava/lang/String;

    invoke-virtual {v2, v3}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 1560
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    invoke-virtual {v2}, Landroid/widget/EditText;->requestFocus()Z

    move-result v2

    goto :goto_0
.end method

.method protected bridge synthetic onPostExecute(Ljava/lang/Object;)V
    .locals 4

    .prologue
    .line 1517
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;
    move-object v1, p1

    .local v1, "x0":Ljava/lang/Object;
    move-object v2, v0

    move-object v3, v1

    check-cast v3, Lcom/example/paul/a_sacco/Transaction;

    invoke-virtual {v2, v3}, Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;->onPostExecute(Lcom/example/paul/a_sacco/Transaction;)V

    return-void
.end method
