.class Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$8;
.super Ljava/lang/Object;
.source "AgencyDetailFragment.java"

# interfaces
.implements Landroid/content/DialogInterface$OnClickListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->SelectAcc(Lcom/example/paul/a_sacco/Member;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;


# direct methods
.method constructor <init>(Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;)V
    .locals 4

    .prologue
    .line 1058
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$8;
    move-object v1, p1

    move-object v2, v0

    move-object v3, v1

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$8;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    move-object v2, v0

    invoke-direct {v2}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onClick(Landroid/content/DialogInterface;I)V
    .locals 8

    .prologue
    .line 1061
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$8;
    move-object v1, p1

    .local v1, "dialog":Landroid/content/DialogInterface;
    move v2, p2

    .local v2, "whichButton":I
    move-object v3, v0

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$8;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    sget-object v4, Lcom/example/paul/a_sacco/BindAccounts;->outdata:Lcom/example/paul/a_sacco/Account;

    iput-object v4, v3, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    .line 1062
    move-object v3, v0

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$8;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v3, v3, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    if-eqz v3, :cond_0

    .line 1063
    move-object v3, v0

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$8;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_No:Landroid/widget/TextView;

    sget-object v4, Lcom/example/paul/a_sacco/BindAccounts;->outdata:Lcom/example/paul/a_sacco/Account;

    iget-object v4, v4, Lcom/example/paul/a_sacco/Account;->Account_No:Ljava/lang/String;

    invoke-virtual {v3, v4}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1064
    move-object v3, v0

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$8;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name:Landroid/widget/TextView;

    sget-object v4, Lcom/example/paul/a_sacco/BindAccounts;->outdata:Lcom/example/paul/a_sacco/Account;

    iget-object v4, v4, Lcom/example/paul/a_sacco/Account;->Account_Name:Ljava/lang/String;

    invoke-virtual {v3, v4}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1065
    sget-object v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$19;->$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype:[I

    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$8;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v4, v4, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    invoke-virtual {v4}, Lcom/example/paul/a_sacco/Transaction$Transtype;->ordinal()I

    move-result v4

    aget v3, v3, v4

    packed-switch v3, :pswitch_data_0

    .line 1075
    :cond_0
    :goto_0
    return-void

    .line 1069
    :pswitch_0
    move-object v3, v0

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$8;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v3, v3, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    if-eqz v3, :cond_0

    .line 1070
    new-instance v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;

    move-object v7, v3

    move-object v3, v7

    move-object v4, v7

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$8;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$8;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    invoke-direct {v4, v5, v6}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;Lcom/example/paul/a_sacco/Transaction;)V

    const/4 v4, 0x0

    new-array v4, v4, [Ljava/lang/Void;

    invoke-virtual {v3, v4}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->execute([Ljava/lang/Object;)Landroid/os/AsyncTask;

    move-result-object v3

    goto :goto_0

    .line 1065
    nop

    :pswitch_data_0
    .packed-switch 0x3
        :pswitch_0
        :pswitch_0
        :pswitch_0
    .end packed-switch
.end method
