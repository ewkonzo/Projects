.class Lcom/example/paul/a_sacco/AgencyDetailFragment$11;
.super Ljava/lang/Object;
.source "AgencyDetailFragment.java"

# interfaces
.implements Landroid/view/View$OnClickListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/example/paul/a_sacco/AgencyDetailFragment;->Activation(Landroid/view/View;)V
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
    .line 504
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$11;
    move-object v1, p1

    move-object v2, v0

    move-object v3, v1

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$11;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object v2, v0

    invoke-direct {v2}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onClick(Landroid/view/View;)V
    .locals 9

    .prologue
    .line 507
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$11;
    move-object v1, p1

    .local v1, "v":Landroid/view/View;
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$11;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    const/4 v5, 0x0

    invoke-virtual {v4, v5}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 508
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$11;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    invoke-virtual {v4}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v4

    move-object v2, v4

    .line 509
    .local v2, "id":Ljava/lang/String;
    const/4 v4, 0x0

    move v3, v4

    .line 510
    .local v3, "cancel":Z
    move-object v4, v2

    invoke-static {v4}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v4

    if-eqz v4, :cond_0

    .line 511
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$11;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$11;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const v6, 0x7f0c001b

    invoke-virtual {v5, v6}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getString(I)Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 512
    const/4 v4, 0x1

    move v3, v4

    .line 514
    :cond_0
    move v4, v3

    if-eqz v4, :cond_1

    .line 523
    :goto_0
    return-void

    .line 517
    :cond_1
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$11;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    new-instance v5, Lcom/example/paul/a_sacco/Member;

    move-object v8, v5

    move-object v5, v8

    move-object v6, v8

    invoke-direct {v6}, Lcom/example/paul/a_sacco/Member;-><init>()V

    iput-object v5, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->member:Lcom/example/paul/a_sacco/Member;

    .line 518
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$11;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->member:Lcom/example/paul/a_sacco/Member;

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$11;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v5

    iput-object v5, v4, Lcom/example/paul/a_sacco/Member;->id_no:Ljava/lang/String;

    .line 519
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$11;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$11;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->member:Lcom/example/paul/a_sacco/Member;

    iput-object v5, v4, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    .line 520
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$11;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->pacc:Landroid/widget/ProgressBar;

    const/4 v5, 0x0

    invoke-virtual {v4, v5}, Landroid/widget/ProgressBar;->setVisibility(I)V

    .line 521
    new-instance v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    move-object v8, v4

    move-object v4, v8

    move-object v5, v8

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$11;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$11;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    invoke-direct {v5, v6, v7}, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;Lcom/example/paul/a_sacco/Transaction;)V

    const/4 v5, 0x0

    new-array v5, v5, [Ljava/lang/Void;

    invoke-virtual {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->execute([Ljava/lang/Object;)Landroid/os/AsyncTask;

    move-result-object v4

    goto :goto_0
.end method
