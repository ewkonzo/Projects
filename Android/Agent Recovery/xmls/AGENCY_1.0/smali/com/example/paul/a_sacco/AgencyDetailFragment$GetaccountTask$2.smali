.class Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$2;
.super Ljava/lang/Object;
.source "AgencyDetailFragment.java"

# interfaces
.implements Landroid/content/DialogInterface$OnClickListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->onPostExecute(Lcom/example/paul/a_sacco/Transaction;)V
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
    .line 940
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$2;
    move-object v1, p1

    move-object v2, v0

    move-object v3, v1

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$2;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    move-object v2, v0

    invoke-direct {v2}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onClick(Landroid/content/DialogInterface;I)V
    .locals 5

    .prologue
    .line 942
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$2;
    move-object v1, p1

    .local v1, "dialog":Landroid/content/DialogInterface;
    move v2, p2

    .local v2, "whichButton":I
    sget-object v3, Lcom/example/paul/a_sacco/BindLoans;->outdata:Lcom/example/paul/a_sacco/Loans;

    if-eqz v3, :cond_0

    .line 943
    move-object v3, v0

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$2;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment;->loanNo:Landroid/widget/TextView;

    sget-object v4, Lcom/example/paul/a_sacco/BindLoans;->outdata:Lcom/example/paul/a_sacco/Loans;

    iget-object v4, v4, Lcom/example/paul/a_sacco/Loans;->Loan_No:Ljava/lang/String;

    invoke-virtual {v3, v4}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 944
    move-object v3, v0

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$2;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment;->loan_Type:Landroid/widget/TextView;

    sget-object v4, Lcom/example/paul/a_sacco/BindLoans;->outdata:Lcom/example/paul/a_sacco/Loans;

    iget-object v4, v4, Lcom/example/paul/a_sacco/Loans;->Loan_Type:Ljava/lang/String;

    invoke-virtual {v3, v4}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 946
    move-object v3, v0

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$2;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    sget-object v4, Lcom/example/paul/a_sacco/BindLoans;->outdata:Lcom/example/paul/a_sacco/Loans;

    iput-object v4, v3, Lcom/example/paul/a_sacco/Transaction;->loan_no:Lcom/example/paul/a_sacco/Loans;

    .line 951
    :goto_0
    return-void

    .line 948
    :cond_0
    move-object v3, v0

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$2;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment;->loanNo:Landroid/widget/TextView;

    const-string v4, ""

    invoke-virtual {v3, v4}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 949
    move-object v3, v0

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$2;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment;->loan_Type:Landroid/widget/TextView;

    const-string v4, ""

    invoke-virtual {v3, v4}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    goto :goto_0
.end method
