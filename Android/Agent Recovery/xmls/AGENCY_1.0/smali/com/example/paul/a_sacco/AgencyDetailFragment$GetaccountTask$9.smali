.class Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$9;
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
    .line 1078
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$9;
    move-object v1, p1

    move-object v2, v0

    move-object v3, v1

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$9;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    move-object v2, v0

    invoke-direct {v2}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onClick(Landroid/content/DialogInterface;I)V
    .locals 5

    .prologue
    .line 1080
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$9;
    move-object v1, p1

    .local v1, "dialog":Landroid/content/DialogInterface;
    move v2, p2

    .local v2, "whichButton":I
    move-object v3, v0

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$9;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    const/4 v4, 0x0

    iput-object v4, v3, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    .line 1081
    move-object v3, v0

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$9;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_No:Landroid/widget/TextView;

    const-string v4, ""

    invoke-virtual {v3, v4}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1082
    move-object v3, v0

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$9;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name:Landroid/widget/TextView;

    const-string v4, ""

    invoke-virtual {v3, v4}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1085
    return-void
.end method
