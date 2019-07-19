.class Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$5;
.super Ljava/lang/Object;
.source "AgencyDetailFragment.java"

# interfaces
.implements Landroid/view/View$OnClickListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->onPostExecute(Lcom/example/paul/a_sacco/Transaction;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;

.field final synthetic val$dialog:Landroid/app/AlertDialog;


# direct methods
.method constructor <init>(Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;Landroid/app/AlertDialog;)V
    .locals 5

    .prologue
    .line 1305
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$5;
    move-object v1, p1

    move-object v2, p2

    move-object v3, v0

    move-object v4, v1

    iput-object v4, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$5;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;

    move-object v3, v0

    move-object v4, v2

    iput-object v4, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$5;->val$dialog:Landroid/app/AlertDialog;

    move-object v3, v0

    invoke-direct {v3}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onClick(Landroid/view/View;)V
    .locals 4

    .prologue
    .line 1308
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$5;
    move-object v1, p1

    .local v1, "v":Landroid/view/View;
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$5;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Status;->Pending:Lcom/example/paul/a_sacco/Transaction$Status;

    iput-object v3, v2, Lcom/example/paul/a_sacco/Transaction;->status:Lcom/example/paul/a_sacco/Transaction$Status;

    .line 1309
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$5;->val$dialog:Landroid/app/AlertDialog;

    invoke-virtual {v2}, Landroid/app/AlertDialog;->dismiss()V

    .line 1310
    return-void
.end method
