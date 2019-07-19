.class Lcom/example/paul/a_sacco/AgencyDetailFragment$5;
.super Ljava/lang/Object;
.source "AgencyDetailFragment.java"

# interfaces
.implements Landroid/view/View$OnClickListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/example/paul/a_sacco/AgencyDetailFragment;->Sharedeposit(Landroid/view/View;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;


# direct methods
.method constructor <init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;)V
    .locals 4

    .prologue
    .line 290
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$5;
    move-object v1, p1

    move-object v2, v0

    move-object v3, v1

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$5;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object v2, v0

    invoke-direct {v2}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onClick(Landroid/view/View;)V
    .locals 10

    .prologue
    .line 293
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$5;
    move-object v1, p1

    .local v1, "v":Landroid/view/View;
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$5;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    const/4 v6, 0x0

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 294
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$5;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->amount:Landroid/widget/EditText;

    const/4 v6, 0x0

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 295
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$5;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v5

    move-object v2, v5

    .line 296
    .local v2, "id":Ljava/lang/String;
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$5;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->amount:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v5

    move-object v3, v5

    .line 297
    .local v3, "am":Ljava/lang/String;
    const/4 v5, 0x0

    move v4, v5

    .line 298
    .local v4, "cancel":Z
    move-object v5, v2

    invoke-static {v5}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v5

    if-eqz v5, :cond_0

    .line 299
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$5;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$5;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const v7, 0x7f0c001b

    invoke-virtual {v6, v7}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getString(I)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 300
    const/4 v5, 0x1

    move v4, v5

    .line 302
    :cond_0
    move-object v5, v3

    invoke-static {v5}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v5

    if-eqz v5, :cond_1

    .line 303
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$5;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->amount:Landroid/widget/EditText;

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$5;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const v7, 0x7f0c001b

    invoke-virtual {v6, v7}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getString(I)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 304
    const/4 v5, 0x1

    move v4, v5

    .line 306
    :cond_1
    move v5, v4

    if-eqz v5, :cond_2

    .line 315
    :goto_0
    return-void

    .line 309
    :cond_2
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$5;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object v6, v3

    invoke-static {v6}, Ljava/lang/Double;->valueOf(Ljava/lang/String;)Ljava/lang/Double;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/Double;->doubleValue()D

    move-result-wide v6

    iput-wide v6, v5, Lcom/example/paul/a_sacco/Transaction;->amount:D

    .line 310
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$5;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v5, v5, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    if-nez v5, :cond_3

    .line 311
    new-instance v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    move-object v9, v5

    move-object v5, v9

    move-object v6, v9

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$5;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object v8, v0

    iget-object v8, v8, Lcom/example/paul/a_sacco/AgencyDetailFragment$5;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v8, v8, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    invoke-direct {v6, v7, v8}, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;Lcom/example/paul/a_sacco/Transaction;)V

    const/4 v6, 0x0

    new-array v6, v6, [Ljava/lang/Void;

    invoke-virtual {v5, v6}, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->execute([Ljava/lang/Object;)Landroid/os/AsyncTask;

    move-result-object v5

    goto :goto_0

    .line 313
    :cond_3
    new-instance v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;

    move-object v9, v5

    move-object v5, v9

    move-object v6, v9

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$5;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object v8, v0

    iget-object v8, v8, Lcom/example/paul/a_sacco/AgencyDetailFragment$5;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v8, v8, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    invoke-direct {v6, v7, v8}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;Lcom/example/paul/a_sacco/Transaction;)V

    const/4 v6, 0x0

    new-array v6, v6, [Ljava/lang/Void;

    invoke-virtual {v5, v6}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->execute([Ljava/lang/Object;)Landroid/os/AsyncTask;

    move-result-object v5

    goto :goto_0
.end method
