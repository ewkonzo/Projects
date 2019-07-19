.class Lcom/example/paul/a_sacco/AgencyDetailFragment$4;
.super Ljava/lang/Object;
.source "AgencyDetailFragment.java"

# interfaces
.implements Landroid/view/View$OnFocusChangeListener;


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
    .line 277
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$4;
    move-object v1, p1

    move-object v2, v0

    move-object v3, v1

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$4;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object v2, v0

    invoke-direct {v2}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onFocusChange(Landroid/view/View;Z)V
    .locals 8

    .prologue
    .line 280
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$4;
    move-object v1, p1

    .local v1, "v":Landroid/view/View;
    move v2, p2

    .local v2, "hasFocus":Z
    move v3, v2

    if-nez v3, :cond_0

    .line 281
    move-object v3, v0

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$4;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    invoke-virtual {v3}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v3

    const-string v4, ""

    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-nez v3, :cond_0

    .line 282
    move-object v3, v0

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$4;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    new-instance v4, Lcom/example/paul/a_sacco/Member;

    move-object v7, v4

    move-object v4, v7

    move-object v5, v7

    invoke-direct {v5}, Lcom/example/paul/a_sacco/Member;-><init>()V

    iput-object v4, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment;->member:Lcom/example/paul/a_sacco/Member;

    .line 283
    move-object v3, v0

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$4;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment;->member:Lcom/example/paul/a_sacco/Member;

    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$4;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    invoke-virtual {v4}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v4

    iput-object v4, v3, Lcom/example/paul/a_sacco/Member;->id_no:Ljava/lang/String;

    .line 284
    move-object v3, v0

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$4;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$4;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->member:Lcom/example/paul/a_sacco/Member;

    iput-object v4, v3, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    .line 285
    move-object v3, v0

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$4;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v3, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment;->pacc:Landroid/widget/ProgressBar;

    const/4 v4, 0x0

    invoke-virtual {v3, v4}, Landroid/widget/ProgressBar;->setVisibility(I)V

    .line 286
    new-instance v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    move-object v7, v3

    move-object v3, v7

    move-object v4, v7

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$4;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$4;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    invoke-direct {v4, v5, v6}, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;Lcom/example/paul/a_sacco/Transaction;)V

    const/4 v4, 0x0

    new-array v4, v4, [Ljava/lang/Void;

    invoke-virtual {v3, v4}, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->execute([Ljava/lang/Object;)Landroid/os/AsyncTask;

    move-result-object v3

    .line 288
    :cond_0
    return-void
.end method
