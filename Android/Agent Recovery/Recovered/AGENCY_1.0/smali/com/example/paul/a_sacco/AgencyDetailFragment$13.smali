.class Lcom/example/paul/a_sacco/AgencyDetailFragment$13;
.super Ljava/lang/Object;
.source "AgencyDetailFragment.java"

# interfaces
.implements Landroid/view/View$OnClickListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/example/paul/a_sacco/AgencyDetailFragment;->Registration(Landroid/view/View;)V
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
    .line 554
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$13;
    move-object v1, p1

    move-object v2, v0

    move-object v3, v1

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object v2, v0

    invoke-direct {v2}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onClick(Landroid/view/View;)V
    .locals 14

    .prologue
    .line 557
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$13;
    move-object v1, p1

    .local v1, "v":Landroid/view/View;
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    const/4 v10, 0x0

    invoke-virtual {v9, v10}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 558
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name3:Landroid/widget/EditText;

    const/4 v10, 0x0

    invoke-virtual {v9, v10}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 559
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Tel:Landroid/widget/EditText;

    const/4 v10, 0x0

    invoke-virtual {v9, v10}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 560
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->amount:Landroid/widget/EditText;

    const/4 v10, 0x0

    invoke-virtual {v9, v10}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 561
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    invoke-virtual {v9}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v9

    invoke-virtual {v9}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v9

    move-object v2, v9

    .line 562
    .local v2, "id":Ljava/lang/String;
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->amount:Landroid/widget/EditText;

    invoke-virtual {v9}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v9

    invoke-virtual {v9}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v9

    move-object v3, v9

    .line 563
    .local v3, "am":Ljava/lang/String;
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name3:Landroid/widget/EditText;

    invoke-virtual {v9}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v9

    invoke-virtual {v9}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v9

    move-object v4, v9

    .line 564
    .local v4, "accname":Ljava/lang/String;
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Tel:Landroid/widget/EditText;

    invoke-virtual {v9}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v9

    invoke-virtual {v9}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v9

    move-object v5, v9

    .line 565
    .local v5, "telno":Ljava/lang/String;
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->society:Landroid/widget/AutoCompleteTextView;

    invoke-virtual {v9}, Landroid/widget/AutoCompleteTextView;->getText()Landroid/text/Editable;

    move-result-object v9

    invoke-virtual {v9}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v9

    move-object v6, v9

    .line 566
    .local v6, "soc":Ljava/lang/String;
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->society_no:Landroid/widget/EditText;

    invoke-virtual {v9}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v9

    invoke-virtual {v9}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v9

    move-object v7, v9

    .line 568
    .local v7, "socno":Ljava/lang/String;
    const/4 v9, 0x0

    move v8, v9

    .line 569
    .local v8, "cancel":Z
    move-object v9, v2

    invoke-static {v9}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v9

    if-eqz v9, :cond_0

    .line 571
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    move-object v10, v0

    iget-object v10, v10, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const v11, 0x7f0c001b

    invoke-virtual {v10, v11}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getString(I)Ljava/lang/String;

    move-result-object v10

    invoke-virtual {v9, v10}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 572
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    invoke-virtual {v9}, Landroid/widget/EditText;->requestFocus()Z

    move-result v9

    .line 573
    .line 619
    :goto_0
    return-void

    .line 576
    :cond_0
    move-object v9, v3

    invoke-static {v9}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v9

    if-eqz v9, :cond_1

    .line 577
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->amount:Landroid/widget/EditText;

    move-object v10, v0

    iget-object v10, v10, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const v11, 0x7f0c001b

    invoke-virtual {v10, v11}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getString(I)Ljava/lang/String;

    move-result-object v10

    invoke-virtual {v9, v10}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 578
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->amount:Landroid/widget/EditText;

    invoke-virtual {v9}, Landroid/widget/EditText;->requestFocus()Z

    move-result v9

    .line 579
    goto :goto_0

    .line 581
    :cond_1
    move-object v9, v4

    invoke-static {v9}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v9

    if-eqz v9, :cond_2

    .line 582
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name3:Landroid/widget/EditText;

    move-object v10, v0

    iget-object v10, v10, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const v11, 0x7f0c001b

    invoke-virtual {v10, v11}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getString(I)Ljava/lang/String;

    move-result-object v10

    invoke-virtual {v9, v10}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 583
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name3:Landroid/widget/EditText;

    invoke-virtual {v9}, Landroid/widget/EditText;->requestFocus()Z

    move-result v9

    .line 584
    goto :goto_0

    .line 586
    :cond_2
    move-object v9, v5

    invoke-static {v9}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v9

    if-eqz v9, :cond_3

    .line 587
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Tel:Landroid/widget/EditText;

    move-object v10, v0

    iget-object v10, v10, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const v11, 0x7f0c001b

    invoke-virtual {v10, v11}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getString(I)Ljava/lang/String;

    move-result-object v10

    invoke-virtual {v9, v10}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 588
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Tel:Landroid/widget/EditText;

    invoke-virtual {v9}, Landroid/widget/EditText;->requestFocus()Z

    move-result v9

    .line 589
    goto :goto_0

    .line 591
    :cond_3
    move-object v9, v6

    invoke-static {v9}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v9

    if-eqz v9, :cond_4

    .line 592
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->society:Landroid/widget/AutoCompleteTextView;

    move-object v10, v0

    iget-object v10, v10, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const v11, 0x7f0c001b

    invoke-virtual {v10, v11}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getString(I)Ljava/lang/String;

    move-result-object v10

    invoke-virtual {v9, v10}, Landroid/widget/AutoCompleteTextView;->setError(Ljava/lang/CharSequence;)V

    .line 593
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->society:Landroid/widget/AutoCompleteTextView;

    invoke-virtual {v9}, Landroid/widget/AutoCompleteTextView;->requestFocus()Z

    move-result v9

    .line 594
    goto/16 :goto_0

    .line 596
    :cond_4
    move-object v9, v7

    invoke-static {v9}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v9

    if-eqz v9, :cond_5

    .line 597
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->society_no:Landroid/widget/EditText;

    move-object v10, v0

    iget-object v10, v10, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const v11, 0x7f0c001b

    invoke-virtual {v10, v11}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getString(I)Ljava/lang/String;

    move-result-object v10

    invoke-virtual {v9, v10}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 598
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->society_no:Landroid/widget/EditText;

    invoke-virtual {v9}, Landroid/widget/EditText;->requestFocus()Z

    move-result v9

    .line 599
    goto/16 :goto_0

    .line 601
    :cond_5
    move-object v9, v5

    invoke-virtual {v9}, Ljava/lang/String;->length()I

    move-result v9

    const/16 v10, 0x9

    if-ge v9, v10, :cond_6

    .line 602
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Tel:Landroid/widget/EditText;

    move-object v10, v0

    iget-object v10, v10, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const v11, 0x7f0c0021

    invoke-virtual {v10, v11}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getString(I)Ljava/lang/String;

    move-result-object v10

    invoke-virtual {v9, v10}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 603
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Tel:Landroid/widget/EditText;

    invoke-virtual {v9}, Landroid/widget/EditText;->requestFocus()Z

    move-result v9

    .line 604
    goto/16 :goto_0

    .line 607
    :cond_6
    move v9, v8

    if-eqz v9, :cond_7

    .line 619
    :goto_1
    goto/16 :goto_0

    .line 610
    :cond_7
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object v10, v3

    invoke-static {v10}, Ljava/lang/Double;->valueOf(Ljava/lang/String;)Ljava/lang/Double;

    move-result-object v10

    invoke-virtual {v10}, Ljava/lang/Double;->doubleValue()D

    move-result-wide v10

    iput-wide v10, v9, Lcom/example/paul/a_sacco/Transaction;->amount:D

    .line 611
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    new-instance v10, Lcom/example/paul/a_sacco/Member;

    move-object v13, v10

    move-object v10, v13

    move-object v11, v13

    invoke-direct {v11}, Lcom/example/paul/a_sacco/Member;-><init>()V

    iput-object v10, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->member:Lcom/example/paul/a_sacco/Member;

    .line 612
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->member:Lcom/example/paul/a_sacco/Member;

    move-object v10, v2

    iput-object v10, v9, Lcom/example/paul/a_sacco/Member;->id_no:Ljava/lang/String;

    .line 613
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->member:Lcom/example/paul/a_sacco/Member;

    move-object v10, v5

    iput-object v10, v9, Lcom/example/paul/a_sacco/Member;->telephone:Ljava/lang/String;

    .line 614
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->member:Lcom/example/paul/a_sacco/Member;

    move-object v10, v4

    iput-object v10, v9, Lcom/example/paul/a_sacco/Member;->name:Ljava/lang/String;

    .line 615
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object v10, v0

    iget-object v10, v10, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v10, v10, Lcom/example/paul/a_sacco/AgencyDetailFragment;->member:Lcom/example/paul/a_sacco/Member;

    iput-object v10, v9, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    .line 616
    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v9, v9, Lcom/example/paul/a_sacco/Transaction;->society:Lcom/example/paul/a_sacco/Societies;

    move-object v10, v7

    iput-object v10, v9, Lcom/example/paul/a_sacco/Societies;->memberid:Ljava/lang/String;

    .line 617
    new-instance v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;

    move-object v13, v9

    move-object v9, v13

    move-object v10, v13

    move-object v11, v0

    iget-object v11, v11, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object v12, v0

    iget-object v12, v12, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v12, v12, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    invoke-direct {v10, v11, v12}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;Lcom/example/paul/a_sacco/Transaction;)V

    const/4 v10, 0x0

    new-array v10, v10, [Ljava/lang/Void;

    invoke-virtual {v9, v10}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->execute([Ljava/lang/Object;)Landroid/os/AsyncTask;

    move-result-object v9

    goto :goto_1
.end method
