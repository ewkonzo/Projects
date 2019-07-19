.class Lcom/example/paul/a_sacco/AgencyDetailFragment$10;
.super Ljava/lang/Object;
.source "AgencyDetailFragment.java"

# interfaces
.implements Landroid/view/View$OnClickListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/example/paul/a_sacco/AgencyDetailFragment;->changepin(Landroid/view/View;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

.field final synthetic val$conpin:Landroid/widget/EditText;

.field final synthetic val$cpin:Landroid/widget/EditText;

.field final synthetic val$npin:Landroid/widget/EditText;


# direct methods
.method constructor <init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;Landroid/widget/EditText;Landroid/widget/EditText;Landroid/widget/EditText;)V
    .locals 7

    .prologue
    .line 445
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$10;
    move-object v1, p1

    move-object v2, p2

    move-object v3, p3

    move-object v4, p4

    move-object v5, v0

    move-object v6, v1

    iput-object v6, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object v5, v0

    move-object v6, v2

    iput-object v6, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->val$cpin:Landroid/widget/EditText;

    move-object v5, v0

    move-object v6, v3

    iput-object v6, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->val$npin:Landroid/widget/EditText;

    move-object v5, v0

    move-object v6, v4

    iput-object v6, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->val$conpin:Landroid/widget/EditText;

    move-object v5, v0

    invoke-direct {v5}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onClick(Landroid/view/View;)V
    .locals 12

    .prologue
    .line 448
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$10;
    move-object v1, p1

    .local v1, "v":Landroid/view/View;
    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    const/4 v8, 0x0

    invoke-virtual {v7, v8}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 449
    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    invoke-virtual {v7}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v7

    move-object v2, v7

    .line 450
    .local v2, "id":Ljava/lang/String;
    const/4 v7, 0x0

    move v3, v7

    .line 451
    .local v3, "cancel":Z
    move-object v7, v2

    invoke-static {v7}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v7

    if-eqz v7, :cond_0

    .line 452
    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    move-object v8, v0

    iget-object v8, v8, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const v9, 0x7f0c001b

    invoke-virtual {v8, v9}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getString(I)Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v7, v8}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 453
    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    invoke-virtual {v7}, Landroid/widget/EditText;->requestFocus()Z

    move-result v7

    .line 454
    .line 490
    :goto_0
    return-void

    .line 456
    :cond_0
    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->val$cpin:Landroid/widget/EditText;

    invoke-virtual {v7}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v7

    move-object v4, v7

    .line 457
    .local v4, "pinc":Ljava/lang/String;
    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->val$npin:Landroid/widget/EditText;

    invoke-virtual {v7}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v7

    move-object v5, v7

    .line 458
    .local v5, "pinn":Ljava/lang/String;
    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->val$conpin:Landroid/widget/EditText;

    invoke-virtual {v7}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v7

    move-object v6, v7

    .line 459
    .local v6, "pincon":Ljava/lang/String;
    move-object v7, v4

    invoke-static {v7}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v7

    if-eqz v7, :cond_1

    .line 460
    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->val$cpin:Landroid/widget/EditText;

    move-object v8, v0

    iget-object v8, v8, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const v9, 0x7f0c001b

    invoke-virtual {v8, v9}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getString(I)Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v7, v8}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 461
    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->val$cpin:Landroid/widget/EditText;

    invoke-virtual {v7}, Landroid/widget/EditText;->requestFocus()Z

    move-result v7

    .line 462
    goto :goto_0

    .line 464
    :cond_1
    move-object v7, v5

    invoke-static {v7}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v7

    if-eqz v7, :cond_2

    .line 465
    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->val$npin:Landroid/widget/EditText;

    move-object v8, v0

    iget-object v8, v8, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const v9, 0x7f0c001b

    invoke-virtual {v8, v9}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getString(I)Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v7, v8}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 466
    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->val$npin:Landroid/widget/EditText;

    invoke-virtual {v7}, Landroid/widget/EditText;->requestFocus()Z

    move-result v7

    .line 467
    goto :goto_0

    .line 469
    :cond_2
    move-object v7, v6

    invoke-static {v7}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v7

    if-eqz v7, :cond_3

    .line 470
    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->val$conpin:Landroid/widget/EditText;

    move-object v8, v0

    iget-object v8, v8, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const v9, 0x7f0c001b

    invoke-virtual {v8, v9}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getString(I)Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v7, v8}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 471
    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->val$conpin:Landroid/widget/EditText;

    invoke-virtual {v7}, Landroid/widget/EditText;->requestFocus()Z

    move-result v7

    .line 472
    goto/16 :goto_0

    .line 474
    :cond_3
    move-object v7, v4

    move-object v8, v0

    iget-object v8, v8, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v8, v8, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v8, v8, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    iget-object v8, v8, Lcom/example/paul/a_sacco/Member;->pin:Ljava/lang/String;

    invoke-virtual {v7, v8}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v7

    if-nez v7, :cond_4

    .line 475
    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->val$cpin:Landroid/widget/EditText;

    move-object v8, v0

    iget-object v8, v8, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const v9, 0x7f0c001a

    invoke-virtual {v8, v9}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getString(I)Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v7, v8}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 476
    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->val$cpin:Landroid/widget/EditText;

    invoke-virtual {v7}, Landroid/widget/EditText;->requestFocus()Z

    move-result v7

    .line 477
    goto/16 :goto_0

    .line 479
    :cond_4
    move-object v7, v5

    move-object v8, v6

    invoke-virtual {v7, v8}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v7

    if-nez v7, :cond_5

    .line 480
    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->val$conpin:Landroid/widget/EditText;

    move-object v8, v0

    iget-object v8, v8, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const v9, 0x7f0c0019

    invoke-virtual {v8, v9}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getString(I)Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v7, v8}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 481
    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->val$conpin:Landroid/widget/EditText;

    invoke-virtual {v7}, Landroid/widget/EditText;->requestFocus()Z

    move-result v7

    .line 482
    goto/16 :goto_0

    .line 487
    :cond_5
    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object v8, v5

    iput-object v8, v7, Lcom/example/paul/a_sacco/Transaction;->newpin:Ljava/lang/String;

    .line 489
    new-instance v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;

    move-object v11, v7

    move-object v7, v11

    move-object v8, v11

    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object v10, v0

    iget-object v10, v10, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v10, v10, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    invoke-direct {v8, v9, v10}, Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;Lcom/example/paul/a_sacco/Transaction;)V

    const/4 v8, 0x0

    new-array v8, v8, [Ljava/lang/Void;

    invoke-virtual {v7, v8}, Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;->execute([Ljava/lang/Object;)Landroid/os/AsyncTask;

    move-result-object v7

    .line 490
    goto/16 :goto_0
.end method
