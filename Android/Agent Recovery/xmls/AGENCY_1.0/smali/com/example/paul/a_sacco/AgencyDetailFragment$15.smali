.class Lcom/example/paul/a_sacco/AgencyDetailFragment$15;
.super Ljava/lang/Object;
.source "AgencyDetailFragment.java"

# interfaces
.implements Landroid/view/View$OnFocusChangeListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/example/paul/a_sacco/AgencyDetailFragment;->Transfer(Landroid/view/View;)V
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
    .line 650
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$15;
    move-object v1, p1

    move-object v2, v0

    move-object v3, v1

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$15;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object v2, v0

    invoke-direct {v2}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onFocusChange(Landroid/view/View;Z)V
    .locals 9

    .prologue
    .line 653
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$15;
    move-object v1, p1

    .local v1, "v":Landroid/view/View;
    move v2, p2

    .local v2, "hasFocus":Z
    move v4, v2

    if-nez v4, :cond_0

    .line 654
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$15;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_No2:Landroid/widget/EditText;

    invoke-virtual {v4}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v4

    const-string v5, ""

    invoke-virtual {v4, v5}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-nez v4, :cond_0

    .line 655
    new-instance v4, Lcom/example/paul/a_sacco/Account;

    move-object v8, v4

    move-object v4, v8

    move-object v5, v8

    invoke-direct {v5}, Lcom/example/paul/a_sacco/Account;-><init>()V

    move-object v3, v4

    .line 656
    .local v3, "acc":Lcom/example/paul/a_sacco/Account;
    move-object v4, v3

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$15;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_No2:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v5

    iput-object v5, v4, Lcom/example/paul/a_sacco/Account;->Account_No:Ljava/lang/String;

    .line 657
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$15;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object v5, v3

    iput-object v5, v4, Lcom/example/paul/a_sacco/Transaction;->account_2:Lcom/example/paul/a_sacco/Account;

    .line 658
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$15;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->pacc2:Landroid/widget/ProgressBar;

    const/4 v5, 0x0

    invoke-virtual {v4, v5}, Landroid/widget/ProgressBar;->setVisibility(I)V

    .line 659
    new-instance v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    move-object v8, v4

    move-object v4, v8

    move-object v5, v8

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$15;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$15;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    invoke-direct {v5, v6, v7}, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;Lcom/example/paul/a_sacco/Transaction;)V

    const/4 v5, 0x0

    new-array v5, v5, [Ljava/lang/Void;

    invoke-virtual {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->execute([Ljava/lang/Object;)Landroid/os/AsyncTask;

    move-result-object v4

    .line 661
    .end local v3    # "acc":Lcom/example/paul/a_sacco/Account;
    :cond_0
    return-void
.end method