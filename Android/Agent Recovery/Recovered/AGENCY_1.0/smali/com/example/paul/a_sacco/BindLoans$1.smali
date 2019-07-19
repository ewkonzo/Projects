.class Lcom/example/paul/a_sacco/BindLoans$1;
.super Ljava/lang/Object;
.source "BindLoans.java"

# interfaces
.implements Landroid/view/View$OnClickListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/example/paul/a_sacco/BindLoans;->getView(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/example/paul/a_sacco/BindLoans;

.field final synthetic val$position:I


# direct methods
.method constructor <init>(Lcom/example/paul/a_sacco/BindLoans;I)V
    .locals 5

    .prologue
    .line 74
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/BindLoans$1;
    move-object v1, p1

    move v2, p2

    move-object v3, v0

    move-object v4, v1

    iput-object v4, v3, Lcom/example/paul/a_sacco/BindLoans$1;->this$0:Lcom/example/paul/a_sacco/BindLoans;

    move-object v3, v0

    move v4, v2

    iput v4, v3, Lcom/example/paul/a_sacco/BindLoans$1;->val$position:I

    move-object v3, v0

    invoke-direct {v3}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onClick(Landroid/view/View;)V
    .locals 4

    .prologue
    .line 77
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/BindLoans$1;
    move-object v1, p1

    .local v1, "v":Landroid/view/View;
    move-object v2, v0

    iget v2, v2, Lcom/example/paul/a_sacco/BindLoans$1;->val$position:I

    move-object v3, v0

    iget-object v3, v3, Lcom/example/paul/a_sacco/BindLoans$1;->this$0:Lcom/example/paul/a_sacco/BindLoans;

    invoke-static {v3}, Lcom/example/paul/a_sacco/BindLoans;->access$000(Lcom/example/paul/a_sacco/BindLoans;)I

    move-result v3

    if-eq v2, v3, :cond_0

    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/BindLoans$1;->this$0:Lcom/example/paul/a_sacco/BindLoans;

    invoke-static {v2}, Lcom/example/paul/a_sacco/BindLoans;->access$100(Lcom/example/paul/a_sacco/BindLoans;)Landroid/widget/RadioButton;

    move-result-object v2

    if-eqz v2, :cond_0

    .line 78
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/BindLoans$1;->this$0:Lcom/example/paul/a_sacco/BindLoans;

    invoke-static {v2}, Lcom/example/paul/a_sacco/BindLoans;->access$100(Lcom/example/paul/a_sacco/BindLoans;)Landroid/widget/RadioButton;

    move-result-object v2

    const/4 v3, 0x0

    invoke-virtual {v2, v3}, Landroid/widget/RadioButton;->setChecked(Z)V

    .line 80
    :cond_0
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/BindLoans$1;->this$0:Lcom/example/paul/a_sacco/BindLoans;

    move-object v3, v0

    iget v3, v3, Lcom/example/paul/a_sacco/BindLoans$1;->val$position:I

    invoke-static {v2, v3}, Lcom/example/paul/a_sacco/BindLoans;->access$002(Lcom/example/paul/a_sacco/BindLoans;I)I

    move-result v2

    .line 81
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/BindLoans$1;->this$0:Lcom/example/paul/a_sacco/BindLoans;

    move-object v3, v1

    check-cast v3, Landroid/widget/RadioButton;

    invoke-static {v2, v3}, Lcom/example/paul/a_sacco/BindLoans;->access$102(Lcom/example/paul/a_sacco/BindLoans;Landroid/widget/RadioButton;)Landroid/widget/RadioButton;

    move-result-object v2

    .line 82
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/BindLoans$1;->this$0:Lcom/example/paul/a_sacco/BindLoans;

    iget-object v2, v2, Lcom/example/paul/a_sacco/BindLoans;->DataCollection:Ljava/util/List;

    move-object v3, v0

    iget v3, v3, Lcom/example/paul/a_sacco/BindLoans$1;->val$position:I

    invoke-interface {v2, v3}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/example/paul/a_sacco/Loans;

    sput-object v2, Lcom/example/paul/a_sacco/BindLoans;->outdata:Lcom/example/paul/a_sacco/Loans;

    .line 83
    return-void
.end method
