.class Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$7;
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


# direct methods
.method constructor <init>(Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;)V
    .locals 4

    .prologue
    .line 1037
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$7;
    move-object v1, p1

    move-object v2, v0

    move-object v3, v1

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$7;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    move-object v2, v0

    invoke-direct {v2}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onClick(Landroid/view/View;)V
    .locals 4

    .prologue
    .line 1041
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$7;
    move-object v1, p1

    .local v1, "v":Landroid/view/View;
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$7;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->pindialog:Landroid/app/AlertDialog;

    invoke-virtual {v2}, Landroid/app/AlertDialog;->dismiss()V

    .line 1042
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$7;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const/4 v3, 0x0

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->pindialog:Landroid/app/AlertDialog;

    .line 1043
    return-void
.end method
