.class Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;
.super Ljava/lang/Object;
.source "AgencyDetailFragment.java"

# interfaces
.implements Landroid/view/View$OnClickListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->changepin()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

.field final synthetic val$conpin:Landroid/widget/EditText;

.field final synthetic val$cpin:Landroid/widget/EditText;

.field final synthetic val$npin:Landroid/widget/EditText;


# direct methods
.method constructor <init>(Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;Landroid/widget/EditText;Landroid/widget/EditText;Landroid/widget/EditText;)V
    .locals 7

    .prologue
    .line 999
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;
    move-object v1, p1

    move-object v2, p2

    move-object v3, p3

    move-object v4, p4

    move-object v5, v0

    move-object v6, v1

    iput-object v6, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    move-object v5, v0

    move-object v6, v2

    iput-object v6, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->val$cpin:Landroid/widget/EditText;

    move-object v5, v0

    move-object v6, v3

    iput-object v6, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->val$npin:Landroid/widget/EditText;

    move-object v5, v0

    move-object v6, v4

    iput-object v6, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->val$conpin:Landroid/widget/EditText;

    move-object v5, v0

    invoke-direct {v5}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onClick(Landroid/view/View;)V
    .locals 8

    .prologue
    .line 1002
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;
    move-object v1, p1

    .local v1, "v":Landroid/view/View;
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->val$cpin:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v5

    move-object v2, v5

    .line 1003
    .local v2, "pinc":Ljava/lang/String;
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->val$npin:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v5

    move-object v3, v5

    .line 1004
    .local v3, "pinn":Ljava/lang/String;
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->val$conpin:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v5

    move-object v4, v5

    .line 1005
    .local v4, "pincon":Ljava/lang/String;
    move-object v5, v2

    invoke-static {v5}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v5

    if-eqz v5, :cond_0

    .line 1006
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->val$cpin:Landroid/widget/EditText;

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const v7, 0x7f0c001b

    invoke-virtual {v6, v7}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getString(I)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 1007
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->val$cpin:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->requestFocus()Z

    move-result v5

    .line 1008
    .line 1035
    :goto_0
    return-void

    .line 1010
    :cond_0
    move-object v5, v3

    invoke-static {v5}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v5

    if-eqz v5, :cond_1

    .line 1011
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->val$npin:Landroid/widget/EditText;

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const v7, 0x7f0c001b

    invoke-virtual {v6, v7}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getString(I)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 1012
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->val$npin:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->requestFocus()Z

    move-result v5

    .line 1013
    goto :goto_0

    .line 1015
    :cond_1
    move-object v5, v4

    invoke-static {v5}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v5

    if-eqz v5, :cond_2

    .line 1016
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->val$conpin:Landroid/widget/EditText;

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const v7, 0x7f0c001b

    invoke-virtual {v6, v7}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getString(I)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 1017
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->val$conpin:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->requestFocus()Z

    move-result v5

    .line 1018
    goto :goto_0

    .line 1020
    :cond_2
    move-object v5, v2

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Member;->pin:Ljava/lang/String;

    invoke-virtual {v5, v6}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v5

    if-nez v5, :cond_3

    .line 1021
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->val$cpin:Landroid/widget/EditText;

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const v7, 0x7f0c001a

    invoke-virtual {v6, v7}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getString(I)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 1022
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->val$cpin:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->requestFocus()Z

    move-result v5

    .line 1023
    goto :goto_0

    .line 1025
    :cond_3
    move-object v5, v3

    move-object v6, v4

    invoke-virtual {v5, v6}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v5

    if-nez v5, :cond_4

    .line 1026
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->val$conpin:Landroid/widget/EditText;

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const v7, 0x7f0c0019

    invoke-virtual {v6, v7}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getString(I)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 1027
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->val$conpin:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->requestFocus()Z

    move-result v5

    .line 1028
    goto/16 :goto_0

    .line 1030
    :cond_4
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v5, v5, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    move-object v6, v4

    iput-object v6, v5, Lcom/example/paul/a_sacco/Member;->pin:Ljava/lang/String;

    .line 1031
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    const/4 v6, 0x1

    iput-boolean v6, v5, Lcom/example/paul/a_sacco/Transaction;->pinchanged:Z

    .line 1032
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object v6, v4

    iput-object v6, v5, Lcom/example/paul/a_sacco/Transaction;->newpin:Ljava/lang/String;

    .line 1033
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->pindialog:Landroid/app/AlertDialog;

    invoke-virtual {v5}, Landroid/app/AlertDialog;->dismiss()V

    .line 1034
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const/4 v6, 0x0

    iput-object v6, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->pindialog:Landroid/app/AlertDialog;

    .line 1035
    goto/16 :goto_0
.end method
