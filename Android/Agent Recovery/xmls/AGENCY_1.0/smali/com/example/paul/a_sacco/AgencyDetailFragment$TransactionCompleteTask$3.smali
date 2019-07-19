.class Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask$3;
.super Ljava/lang/Object;
.source "AgencyDetailFragment.java"

# interfaces
.implements Landroid/view/View$OnClickListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->onPostExecute(Lcom/example/paul/a_sacco/Transaction;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;

.field final synthetic val$dialog:Landroid/app/AlertDialog;


# direct methods
.method constructor <init>(Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;Landroid/app/AlertDialog;)V
    .locals 5

    .prologue
    .line 1494
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask$3;
    move-object v1, p1

    move-object v2, p2

    move-object v3, v0

    move-object v4, v1

    iput-object v4, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask$3;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;

    move-object v3, v0

    move-object v4, v2

    iput-object v4, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask$3;->val$dialog:Landroid/app/AlertDialog;

    move-object v3, v0

    invoke-direct {v3}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onClick(Landroid/view/View;)V
    .locals 4

    .prologue
    .line 1498
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask$3;
    move-object v1, p1

    .local v1, "v":Landroid/view/View;
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask$3;->val$dialog:Landroid/app/AlertDialog;

    invoke-virtual {v2}, Landroid/app/AlertDialog;->dismiss()V

    .line 1499
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask$3;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const/4 v3, 0x0

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    .line 1500
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask$3;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-boolean v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->twopane:Z

    if-nez v2, :cond_0

    .line 1501
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask$3;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    invoke-virtual {v2}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getActivity()Landroid/support/v4/app/FragmentActivity;

    move-result-object v2

    invoke-virtual {v2}, Landroid/support/v4/app/FragmentActivity;->finish()V

    .line 1505
    :goto_0
    return-void

    .line 1503
    :cond_0
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask$3;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const/4 v3, 0x0

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    goto :goto_0
.end method
