.class public Lcom/example/paul/a_sacco/AgencyDetailFragment;
.super Landroid/support/v4/app/Fragment;
.source "AgencyDetailFragment.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/example/paul/a_sacco/AgencyDetailFragment$19;,
        Lcom/example/paul/a_sacco/AgencyDetailFragment$ChangepinTask;,
        Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;,
        Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;,
        Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;
    }
.end annotation


# static fields
.field public static final ARG_ITEM_ID:Ljava/lang/String; = "item_id"

.field public static final ARG_TWOPANE:Ljava/lang/String; = "Pane"


# instance fields
.field Account_Name:Landroid/widget/TextView;

.field Account_Name2:Landroid/widget/TextView;

.field Account_Name3:Landroid/widget/EditText;

.field Account_No:Landroid/widget/TextView;

.field Account_No2:Landroid/widget/EditText;

.field Info:Landroid/widget/TextView;

.field Tel:Landroid/widget/EditText;

.field amount:Landroid/widget/EditText;

.field cancel:Landroid/widget/Button;

.field confirm:Landroid/widget/Button;

.field db:Lcom/example/paul/a_sacco/Database;

.field id_no:Landroid/widget/EditText;

.field id_no2:Landroid/widget/EditText;

.field loanNo:Landroid/widget/TextView;

.field loan_Type:Landroid/widget/TextView;

.field loan_bal:Landroid/widget/TextView;

.field loan_source:Landroid/widget/TextView;

.field private mItem:Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;

.field member:Lcom/example/paul/a_sacco/Member;

.field pacc:Landroid/widget/ProgressBar;

.field pacc2:Landroid/widget/ProgressBar;

.field paccname:Landroid/widget/ProgressBar;

.field paccno:Landroid/widget/ProgressBar;

.field pindialog:Landroid/app/AlertDialog;

.field ploan:Landroid/widget/ProgressBar;

.field rootView:Landroid/view/View;

.field society:Landroid/widget/AutoCompleteTextView;

.field society_no:Landroid/widget/EditText;

.field trans:Lcom/example/paul/a_sacco/Transaction;

.field twopane:Z


# direct methods
.method public constructor <init>()V
    .locals 3

    .prologue
    .line 104
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment;
    move-object v1, v0

    invoke-direct {v1}, Landroid/support/v4/app/Fragment;-><init>()V

    .line 61
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->pindialog:Landroid/app/AlertDialog;

    .line 62
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->db:Lcom/example/paul/a_sacco/Database;

    .line 63
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    .line 64
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_No:Landroid/widget/TextView;

    .line 65
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name:Landroid/widget/TextView;

    .line 66
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no2:Landroid/widget/EditText;

    .line 67
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_No2:Landroid/widget/EditText;

    .line 68
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name2:Landroid/widget/TextView;

    .line 69
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name3:Landroid/widget/EditText;

    .line 70
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Tel:Landroid/widget/EditText;

    .line 71
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->society:Landroid/widget/AutoCompleteTextView;

    .line 72
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->society_no:Landroid/widget/EditText;

    .line 73
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Info:Landroid/widget/TextView;

    .line 74
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->loanNo:Landroid/widget/TextView;

    .line 75
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->loan_Type:Landroid/widget/TextView;

    .line 76
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->loan_bal:Landroid/widget/TextView;

    .line 77
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->loan_source:Landroid/widget/TextView;

    .line 78
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->amount:Landroid/widget/EditText;

    .line 79
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->confirm:Landroid/widget/Button;

    .line 80
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->cancel:Landroid/widget/Button;

    .line 81
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->paccno:Landroid/widget/ProgressBar;

    .line 82
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->paccname:Landroid/widget/ProgressBar;

    .line 84
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->pacc:Landroid/widget/ProgressBar;

    .line 85
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->pacc2:Landroid/widget/ProgressBar;

    .line 86
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->ploan:Landroid/widget/ProgressBar;

    .line 88
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->member:Lcom/example/paul/a_sacco/Member;

    .line 90
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    .line 93
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    .line 105
    return-void
.end method

.method private Activation(Landroid/view/View;)V
    .locals 7

    .prologue
    .line 496
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment;
    move-object v1, p1

    .local v1, "view":Landroid/view/View;
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090042

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/EditText;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    .line 497
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090046

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/TextView;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_No:Landroid/widget/TextView;

    .line 498
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090049

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/TextView;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name:Landroid/widget/TextView;

    .line 499
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f09004c

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/Button;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->confirm:Landroid/widget/Button;

    .line 500
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f09004b

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/Button;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->cancel:Landroid/widget/Button;

    .line 501
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090044

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/ProgressBar;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->pacc:Landroid/widget/ProgressBar;

    .line 503
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Status;->Pending:Lcom/example/paul/a_sacco/Transaction$Status;

    iput-object v3, v2, Lcom/example/paul/a_sacco/Transaction;->status:Lcom/example/paul/a_sacco/Transaction$Status;

    .line 504
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->confirm:Landroid/widget/Button;

    new-instance v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$11;

    move-object v6, v3

    move-object v3, v6

    move-object v4, v6

    move-object v5, v0

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment$11;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;)V

    invoke-virtual {v2, v3}, Landroid/widget/Button;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    .line 525
    return-void
.end method

.method private Balance(Landroid/view/View;)V
    .locals 7

    .prologue
    .line 389
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment;
    move-object v1, p1

    .local v1, "view":Landroid/view/View;
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090042

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/EditText;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    .line 390
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090046

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/TextView;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_No:Landroid/widget/TextView;

    .line 391
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090049

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/TextView;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name:Landroid/widget/TextView;

    .line 392
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f09004c

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/Button;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->confirm:Landroid/widget/Button;

    .line 393
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f09004b

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/Button;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->cancel:Landroid/widget/Button;

    .line 394
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090044

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/ProgressBar;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->pacc:Landroid/widget/ProgressBar;

    .line 396
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Status;->Pending:Lcom/example/paul/a_sacco/Transaction$Status;

    iput-object v3, v2, Lcom/example/paul/a_sacco/Transaction;->status:Lcom/example/paul/a_sacco/Transaction$Status;

    .line 398
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->confirm:Landroid/widget/Button;

    new-instance v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$8;

    move-object v6, v3

    move-object v3, v6

    move-object v4, v6

    move-object v5, v0

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment$8;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;)V

    invoke-virtual {v2, v3}, Landroid/widget/Button;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    .line 421
    return-void
.end method

.method private Deposit(Landroid/view/View;)V
    .locals 7

    .prologue
    .line 321
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment;
    move-object v1, p1

    .local v1, "view":Landroid/view/View;
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090055

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/TextView;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_No:Landroid/widget/TextView;

    .line 322
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090049

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/TextView;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name:Landroid/widget/TextView;

    .line 323
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f09005a

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/EditText;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Tel:Landroid/widget/EditText;

    .line 324
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090058

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/EditText;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name3:Landroid/widget/EditText;

    .line 325
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f09004f

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/EditText;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->amount:Landroid/widget/EditText;

    .line 326
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f09004c

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/Button;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->confirm:Landroid/widget/Button;

    .line 327
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f09004b

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/Button;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->cancel:Landroid/widget/Button;

    .line 328
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090044

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/ProgressBar;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->pacc:Landroid/widget/ProgressBar;

    .line 329
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Status;->Pending:Lcom/example/paul/a_sacco/Transaction$Status;

    iput-object v3, v2, Lcom/example/paul/a_sacco/Transaction;->status:Lcom/example/paul/a_sacco/Transaction$Status;

    .line 330
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_No:Landroid/widget/TextView;

    new-instance v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$6;

    move-object v6, v3

    move-object v3, v6

    move-object v4, v6

    move-object v5, v0

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment$6;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;)V

    invoke-virtual {v2, v3}, Landroid/widget/TextView;->setOnFocusChangeListener(Landroid/view/View$OnFocusChangeListener;)V

    .line 343
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->confirm:Landroid/widget/Button;

    new-instance v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$7;

    move-object v6, v3

    move-object v3, v6

    move-object v4, v6

    move-object v5, v0

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment$7;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;)V

    invoke-virtual {v2, v3}, Landroid/widget/Button;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    .line 386
    return-void
.end method

.method private LoanRepayment(Landroid/view/View;)V
    .locals 7

    .prologue
    .line 713
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment;
    move-object v1, p1

    .local v1, "view":Landroid/view/View;
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090042

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/EditText;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    .line 714
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090046

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/TextView;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_No:Landroid/widget/TextView;

    .line 715
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090049

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/TextView;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name:Landroid/widget/TextView;

    .line 716
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090050

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/TextView;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Info:Landroid/widget/TextView;

    .line 717
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f09005f

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/TextView;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->loanNo:Landroid/widget/TextView;

    .line 718
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090061

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/TextView;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->loan_Type:Landroid/widget/TextView;

    .line 720
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f09004f

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/EditText;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->amount:Landroid/widget/EditText;

    .line 721
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f09004c

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/Button;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->confirm:Landroid/widget/Button;

    .line 722
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f09004b

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/Button;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->cancel:Landroid/widget/Button;

    .line 724
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f09005d

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/ProgressBar;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->ploan:Landroid/widget/ProgressBar;

    .line 726
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Status;->Pending:Lcom/example/paul/a_sacco/Transaction$Status;

    iput-object v3, v2, Lcom/example/paul/a_sacco/Transaction;->status:Lcom/example/paul/a_sacco/Transaction$Status;

    .line 727
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    new-instance v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$17;

    move-object v6, v3

    move-object v3, v6

    move-object v4, v6

    move-object v5, v0

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment$17;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;)V

    invoke-virtual {v2, v3}, Landroid/widget/EditText;->setOnFocusChangeListener(Landroid/view/View$OnFocusChangeListener;)V

    .line 741
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->confirm:Landroid/widget/Button;

    new-instance v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$18;

    move-object v6, v3

    move-object v3, v6

    move-object v4, v6

    move-object v5, v0

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment$18;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;)V

    invoke-virtual {v2, v3}, Landroid/widget/Button;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    .line 768
    return-void
.end method

.method private Registration(Landroid/view/View;)V
    .locals 10

    .prologue
    .line 528
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment;
    move-object v1, p1

    .local v1, "view":Landroid/view/View;
    move-object v4, v0

    move-object v5, v1

    const v6, 0x7f090042

    invoke-virtual {v5, v6}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v5

    check-cast v5, Landroid/widget/EditText;

    iput-object v5, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    .line 530
    move-object v4, v0

    move-object v5, v1

    const v6, 0x7f090049

    invoke-virtual {v5, v6}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v5

    check-cast v5, Landroid/widget/EditText;

    iput-object v5, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name3:Landroid/widget/EditText;

    .line 531
    move-object v4, v0

    move-object v5, v1

    const v6, 0x7f09006d

    invoke-virtual {v5, v6}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v5

    check-cast v5, Landroid/widget/EditText;

    iput-object v5, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Tel:Landroid/widget/EditText;

    .line 532
    move-object v4, v0

    move-object v5, v1

    const v6, 0x7f09004f

    invoke-virtual {v5, v6}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v5

    check-cast v5, Landroid/widget/EditText;

    iput-object v5, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->amount:Landroid/widget/EditText;

    .line 533
    move-object v4, v0

    move-object v5, v1

    const v6, 0x7f09006f

    invoke-virtual {v5, v6}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v5

    check-cast v5, Landroid/widget/AutoCompleteTextView;

    iput-object v5, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->society:Landroid/widget/AutoCompleteTextView;

    .line 534
    move-object v4, v0

    move-object v5, v1

    const v6, 0x7f090071

    invoke-virtual {v5, v6}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v5

    check-cast v5, Landroid/widget/EditText;

    iput-object v5, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->society_no:Landroid/widget/EditText;

    .line 535
    move-object v4, v0

    move-object v5, v1

    const v6, 0x7f09004c

    invoke-virtual {v5, v6}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v5

    check-cast v5, Landroid/widget/Button;

    iput-object v5, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->confirm:Landroid/widget/Button;

    .line 536
    move-object v4, v0

    move-object v5, v1

    const v6, 0x7f09004b

    invoke-virtual {v5, v6}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v5

    check-cast v5, Landroid/widget/Button;

    iput-object v5, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->cancel:Landroid/widget/Button;

    .line 537
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    sget-object v5, Lcom/example/paul/a_sacco/Transaction$Status;->Pending:Lcom/example/paul/a_sacco/Transaction$Status;

    iput-object v5, v4, Lcom/example/paul/a_sacco/Transaction;->status:Lcom/example/paul/a_sacco/Transaction$Status;

    .line 539
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->db:Lcom/example/paul/a_sacco/Database;

    invoke-static {v4}, Lcom/example/paul/a_sacco/Societies;->getSocieties(Lcom/example/paul/a_sacco/Database;)Ljava/util/List;

    move-result-object v4

    move-object v2, v4

    .line 542
    .local v2, "soc":Ljava/util/List;, "Ljava/util/List<Lcom/example/paul/a_sacco/Societies;>;"
    new-instance v4, Landroid/widget/ArrayAdapter;

    move-object v9, v4

    move-object v4, v9

    move-object v5, v9

    move-object v6, v1

    invoke-virtual {v6}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object v6

    const v7, 0x1090008

    move-object v8, v2

    invoke-direct {v5, v6, v7, v8}, Landroid/widget/ArrayAdapter;-><init>(Landroid/content/Context;ILjava/util/List;)V

    move-object v3, v4

    .line 544
    .local v3, "RevenueAdapter":Landroid/widget/ArrayAdapter;, "Landroid/widget/ArrayAdapter<Lcom/example/paul/a_sacco/Societies;>;"
    move-object v4, v3

    const v5, 0x1090009

    invoke-virtual {v4, v5}, Landroid/widget/ArrayAdapter;->setDropDownViewResource(I)V

    .line 545
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->society:Landroid/widget/AutoCompleteTextView;

    move-object v5, v3

    invoke-virtual {v4, v5}, Landroid/widget/AutoCompleteTextView;->setAdapter(Landroid/widget/ListAdapter;)V

    .line 546
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->society:Landroid/widget/AutoCompleteTextView;

    new-instance v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$12;

    move-object v9, v5

    move-object v5, v9

    move-object v6, v9

    move-object v7, v0

    invoke-direct {v6, v7}, Lcom/example/paul/a_sacco/AgencyDetailFragment$12;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;)V

    invoke-virtual {v4, v5}, Landroid/widget/AutoCompleteTextView;->setOnItemClickListener(Landroid/widget/AdapterView$OnItemClickListener;)V

    .line 554
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->confirm:Landroid/widget/Button;

    new-instance v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;

    move-object v9, v5

    move-object v5, v9

    move-object v6, v9

    move-object v7, v0

    invoke-direct {v6, v7}, Lcom/example/paul/a_sacco/AgencyDetailFragment$13;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;)V

    invoke-virtual {v4, v5}, Landroid/widget/Button;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    .line 621
    return-void
.end method

.method private Sharedeposit(Landroid/view/View;)V
    .locals 7

    .prologue
    .line 268
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment;
    move-object v1, p1

    .local v1, "view":Landroid/view/View;
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090042

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/EditText;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    .line 269
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090046

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/TextView;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_No:Landroid/widget/TextView;

    .line 270
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090049

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/TextView;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name:Landroid/widget/TextView;

    .line 271
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f09004f

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/EditText;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->amount:Landroid/widget/EditText;

    .line 272
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f09004c

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/Button;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->confirm:Landroid/widget/Button;

    .line 273
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f09004b

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/Button;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->cancel:Landroid/widget/Button;

    .line 274
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090044

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/ProgressBar;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->pacc:Landroid/widget/ProgressBar;

    .line 275
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Status;->Pending:Lcom/example/paul/a_sacco/Transaction$Status;

    iput-object v3, v2, Lcom/example/paul/a_sacco/Transaction;->status:Lcom/example/paul/a_sacco/Transaction$Status;

    .line 277
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    new-instance v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$4;

    move-object v6, v3

    move-object v3, v6

    move-object v4, v6

    move-object v5, v0

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment$4;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;)V

    invoke-virtual {v2, v3}, Landroid/widget/EditText;->setOnFocusChangeListener(Landroid/view/View$OnFocusChangeListener;)V

    .line 290
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->confirm:Landroid/widget/Button;

    new-instance v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$5;

    move-object v6, v3

    move-object v3, v6

    move-object v4, v6

    move-object v5, v0

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment$5;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;)V

    invoke-virtual {v2, v3}, Landroid/widget/Button;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    .line 317
    return-void
.end method

.method private Transfer(Landroid/view/View;)V
    .locals 7

    .prologue
    .line 624
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment;
    move-object v1, p1

    .local v1, "view":Landroid/view/View;
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090042

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/EditText;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    .line 625
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090046

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/TextView;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_No:Landroid/widget/TextView;

    .line 626
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090049

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/TextView;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name:Landroid/widget/TextView;

    .line 628
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090077

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/EditText;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_No2:Landroid/widget/EditText;

    .line 629
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090079

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/TextView;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name2:Landroid/widget/TextView;

    .line 630
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f09004f

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/EditText;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->amount:Landroid/widget/EditText;

    .line 631
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f09004c

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/Button;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->confirm:Landroid/widget/Button;

    .line 632
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f09004b

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/Button;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->cancel:Landroid/widget/Button;

    .line 633
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090044

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/ProgressBar;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->pacc:Landroid/widget/ProgressBar;

    .line 634
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090075

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/ProgressBar;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->pacc2:Landroid/widget/ProgressBar;

    .line 636
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Status;->Pending:Lcom/example/paul/a_sacco/Transaction$Status;

    iput-object v3, v2, Lcom/example/paul/a_sacco/Transaction;->status:Lcom/example/paul/a_sacco/Transaction$Status;

    .line 637
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    new-instance v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$14;

    move-object v6, v3

    move-object v3, v6

    move-object v4, v6

    move-object v5, v0

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment$14;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;)V

    invoke-virtual {v2, v3}, Landroid/widget/EditText;->setOnFocusChangeListener(Landroid/view/View$OnFocusChangeListener;)V

    .line 650
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_No2:Landroid/widget/EditText;

    new-instance v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$15;

    move-object v6, v3

    move-object v3, v6

    move-object v4, v6

    move-object v5, v0

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment$15;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;)V

    invoke-virtual {v2, v3}, Landroid/widget/EditText;->setOnFocusChangeListener(Landroid/view/View$OnFocusChangeListener;)V

    .line 663
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->confirm:Landroid/widget/Button;

    new-instance v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$16;

    move-object v6, v3

    move-object v3, v6

    move-object v4, v6

    move-object v5, v0

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment$16;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;)V

    invoke-virtual {v2, v3}, Landroid/widget/Button;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    .line 710
    return-void
.end method

.method private changepin(Landroid/view/View;)V
    .locals 13

    .prologue
    .line 424
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment;
    move-object v1, p1

    .local v1, "view":Landroid/view/View;
    move-object v5, v0

    move-object v6, v1

    const v7, 0x7f090042

    invoke-virtual {v6, v7}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v6

    check-cast v6, Landroid/widget/EditText;

    iput-object v6, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    .line 425
    move-object v5, v1

    const v6, 0x7f090068

    invoke-virtual {v5, v6}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v5

    check-cast v5, Landroid/widget/EditText;

    move-object v2, v5

    .line 426
    .local v2, "cpin":Landroid/widget/EditText;
    move-object v5, v1

    const v6, 0x7f090069

    invoke-virtual {v5, v6}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v5

    check-cast v5, Landroid/widget/EditText;

    move-object v3, v5

    .line 427
    .local v3, "npin":Landroid/widget/EditText;
    move-object v5, v1

    const v6, 0x7f09006a

    invoke-virtual {v5, v6}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v5

    check-cast v5, Landroid/widget/EditText;

    move-object v4, v5

    .line 428
    .local v4, "conpin":Landroid/widget/EditText;
    move-object v5, v0

    move-object v6, v1

    const v7, 0x7f09004c

    invoke-virtual {v6, v7}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v6

    check-cast v6, Landroid/widget/Button;

    iput-object v6, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->confirm:Landroid/widget/Button;

    .line 429
    move-object v5, v0

    move-object v6, v1

    const v7, 0x7f09004b

    invoke-virtual {v6, v7}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v6

    check-cast v6, Landroid/widget/Button;

    iput-object v6, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->cancel:Landroid/widget/Button;

    .line 430
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    sget-object v6, Lcom/example/paul/a_sacco/Transaction$Status;->Pending:Lcom/example/paul/a_sacco/Transaction$Status;

    iput-object v6, v5, Lcom/example/paul/a_sacco/Transaction;->status:Lcom/example/paul/a_sacco/Transaction$Status;

    .line 431
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    new-instance v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$9;

    move-object v12, v6

    move-object v6, v12

    move-object v7, v12

    move-object v8, v0

    invoke-direct {v7, v8}, Lcom/example/paul/a_sacco/AgencyDetailFragment$9;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;)V

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setOnFocusChangeListener(Landroid/view/View$OnFocusChangeListener;)V

    .line 445
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->confirm:Landroid/widget/Button;

    new-instance v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;

    move-object v12, v6

    move-object v6, v12

    move-object v7, v12

    move-object v8, v0

    move-object v9, v2

    move-object v10, v3

    move-object v11, v4

    invoke-direct {v7, v8, v9, v10, v11}, Lcom/example/paul/a_sacco/AgencyDetailFragment$10;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;Landroid/widget/EditText;Landroid/widget/EditText;Landroid/widget/EditText;)V

    invoke-virtual {v5, v6}, Landroid/widget/Button;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    .line 493
    return-void
.end method

.method private withdrawal(Landroid/view/View;)V
    .locals 7

    .prologue
    .line 216
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment;
    move-object v1, p1

    .local v1, "view":Landroid/view/View;
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090042

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/EditText;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    .line 217
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090046

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/TextView;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_No:Landroid/widget/TextView;

    .line 218
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090049

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/TextView;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name:Landroid/widget/TextView;

    .line 219
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090050

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/TextView;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Info:Landroid/widget/TextView;

    .line 220
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f09004f

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/EditText;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->amount:Landroid/widget/EditText;

    .line 221
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f09004c

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/Button;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->confirm:Landroid/widget/Button;

    .line 222
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f09004b

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/Button;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->cancel:Landroid/widget/Button;

    .line 223
    move-object v2, v0

    move-object v3, v1

    const v4, 0x7f090044

    invoke-virtual {v3, v4}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v3

    check-cast v3, Landroid/widget/ProgressBar;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->pacc:Landroid/widget/ProgressBar;

    .line 224
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Status;->Pending:Lcom/example/paul/a_sacco/Transaction$Status;

    iput-object v3, v2, Lcom/example/paul/a_sacco/Transaction;->status:Lcom/example/paul/a_sacco/Transaction$Status;

    .line 225
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    new-instance v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$2;

    move-object v6, v3

    move-object v3, v6

    move-object v4, v6

    move-object v5, v0

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment$2;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;)V

    invoke-virtual {v2, v3}, Landroid/widget/EditText;->setOnFocusChangeListener(Landroid/view/View$OnFocusChangeListener;)V

    .line 238
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/AgencyDetailFragment;->confirm:Landroid/widget/Button;

    new-instance v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$3;

    move-object v6, v3

    move-object v3, v6

    move-object v4, v6

    move-object v5, v0

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment$3;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;)V

    invoke-virtual {v2, v3}, Landroid/widget/Button;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    .line 265
    return-void
.end method


# virtual methods
.method public onCreate(Landroid/os/Bundle;)V
    .locals 7

    .prologue
    .line 109
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment;
    move-object v1, p1

    .local v1, "savedInstanceState":Landroid/os/Bundle;
    move-object v3, v0

    move-object v4, v1

    invoke-super {v3, v4}, Landroid/support/v4/app/Fragment;->onCreate(Landroid/os/Bundle;)V

    .line 110
    move-object v3, v0

    invoke-virtual {v3}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getArguments()Landroid/os/Bundle;

    move-result-object v3

    const-string v4, "item_id"

    invoke-virtual {v3, v4}, Landroid/os/Bundle;->containsKey(Ljava/lang/String;)Z

    move-result v3

    if-eqz v3, :cond_0

    .line 111
    move-object v3, v0

    sget-object v4, Lcom/example/paul/a_sacco/dummy/Menu;->ITEM_MAP:Ljava/util/Map;

    move-object v5, v0

    invoke-virtual {v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getArguments()Landroid/os/Bundle;

    move-result-object v5

    const-string v6, "item_id"

    invoke-virtual {v5, v6}, Landroid/os/Bundle;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v5

    invoke-interface {v4, v5}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;

    iput-object v4, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment;->mItem:Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;

    .line 112
    move-object v3, v0

    move-object v4, v0

    invoke-virtual {v4}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getArguments()Landroid/os/Bundle;

    move-result-object v4

    const-string v5, "Pane"

    invoke-virtual {v4, v5}, Landroid/os/Bundle;->getBoolean(Ljava/lang/String;)Z

    move-result v4

    iput-boolean v4, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment;->twopane:Z

    .line 113
    move-object v3, v0

    invoke-virtual {v3}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getActivity()Landroid/support/v4/app/FragmentActivity;

    move-result-object v3

    invoke-virtual {v3}, Landroid/support/v4/app/FragmentActivity;->getActionBar()Landroid/app/ActionBar;

    move-result-object v3

    move-object v2, v3

    .line 114
    .local v2, "ab":Landroid/app/ActionBar;
    move-object v3, v2

    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->mItem:Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;

    iget-object v4, v4, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;->content:Ljava/lang/String;

    invoke-virtual {v3, v4}, Landroid/app/ActionBar;->setTitle(Ljava/lang/CharSequence;)V

    .line 115
    move-object v3, v2

    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->mItem:Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;

    iget v4, v4, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;->image:I

    invoke-virtual {v3, v4}, Landroid/app/ActionBar;->setIcon(I)V

    .line 117
    .end local v2    # "ab":Landroid/app/ActionBar;
    :cond_0
    return-void
.end method

.method public onCreateView(Landroid/view/LayoutInflater;Landroid/view/ViewGroup;Landroid/os/Bundle;)Landroid/view/View;
    .locals 10

    .prologue
    .line 122
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment;
    move-object v1, p1

    .local v1, "inflater":Landroid/view/LayoutInflater;
    move-object v2, p2

    .local v2, "container":Landroid/view/ViewGroup;
    move-object v3, p3

    .local v3, "savedInstanceState":Landroid/os/Bundle;
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->mItem:Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;

    if-eqz v4, :cond_0

    .line 123
    move-object v4, v0

    new-instance v5, Lcom/example/paul/a_sacco/Transaction;

    move-object v9, v5

    move-object v5, v9

    move-object v6, v9

    invoke-direct {v6}, Lcom/example/paul/a_sacco/Transaction;-><init>()V

    iput-object v5, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    .line 124
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    sget-object v5, Lcom/example/paul/a_sacco/Login;->agent:Lcom/example/paul/a_sacco/Agent;

    iput-object v5, v4, Lcom/example/paul/a_sacco/Transaction;->agent:Lcom/example/paul/a_sacco/Agent;

    .line 125
    move-object v4, v0

    new-instance v5, Lcom/example/paul/a_sacco/Database;

    move-object v9, v5

    move-object v5, v9

    move-object v6, v9

    move-object v7, v0

    invoke-virtual {v7}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getActivity()Landroid/support/v4/app/FragmentActivity;

    move-result-object v7

    invoke-direct {v6, v7}, Lcom/example/paul/a_sacco/Database;-><init>(Landroid/content/Context;)V

    iput-object v5, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->db:Lcom/example/paul/a_sacco/Database;

    .line 126
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->mItem:Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;

    iget-object v4, v4, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;->id:Ljava/lang/String;

    invoke-static {v4}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v4

    packed-switch v4, :pswitch_data_0

    .line 201
    :goto_0
    move-object v4, v0

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    const v6, 0x7f09004b

    invoke-virtual {v5, v6}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v5

    check-cast v5, Landroid/widget/Button;

    iput-object v5, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->cancel:Landroid/widget/Button;

    .line 202
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->cancel:Landroid/widget/Button;

    new-instance v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$1;

    move-object v9, v5

    move-object v5, v9

    move-object v6, v9

    move-object v7, v0

    invoke-direct {v6, v7}, Lcom/example/paul/a_sacco/AgencyDetailFragment$1;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;)V

    invoke-virtual {v4, v5}, Landroid/widget/Button;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    .line 212
    :cond_0
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    move-object v0, v4

    .end local v0    # "this":Lcom/example/paul/a_sacco/AgencyDetailFragment;
    return-object v0

    .line 128
    .restart local v0    # "this":Lcom/example/paul/a_sacco/AgencyDetailFragment;
    :pswitch_0
    move-object v4, v0

    move-object v5, v1

    const v6, 0x7f030023

    move-object v7, v2

    const/4 v8, 0x0

    invoke-virtual {v5, v6, v7, v8}, Landroid/view/LayoutInflater;->inflate(ILandroid/view/ViewGroup;Z)Landroid/view/View;

    move-result-object v5

    iput-object v5, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    .line 129
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    sget-object v5, Lcom/example/paul/a_sacco/Transaction$Transtype;->Registration:Lcom/example/paul/a_sacco/Transaction$Transtype;

    iput-object v5, v4, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    .line 130
    move-object v4, v0

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Registration(Landroid/view/View;)V

    .line 131
    goto :goto_0

    .line 134
    :pswitch_1
    move-object v4, v0

    move-object v5, v1

    const v6, 0x7f030027

    move-object v7, v2

    const/4 v8, 0x0

    invoke-virtual {v5, v6, v7, v8}, Landroid/view/LayoutInflater;->inflate(ILandroid/view/ViewGroup;Z)Landroid/view/View;

    move-result-object v5

    iput-object v5, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    .line 135
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    sget-object v5, Lcom/example/paul/a_sacco/Transaction$Transtype;->Withdrawal:Lcom/example/paul/a_sacco/Transaction$Transtype;

    iput-object v5, v4, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    .line 136
    move-object v4, v0

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->withdrawal(Landroid/view/View;)V

    .line 137
    goto :goto_0

    .line 140
    :pswitch_2
    move-object v4, v0

    move-object v5, v1

    const v6, 0x7f03001e

    move-object v7, v2

    const/4 v8, 0x0

    invoke-virtual {v5, v6, v7, v8}, Landroid/view/LayoutInflater;->inflate(ILandroid/view/ViewGroup;Z)Landroid/view/View;

    move-result-object v5

    iput-object v5, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    .line 141
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    sget-object v5, Lcom/example/paul/a_sacco/Transaction$Transtype;->Deposit:Lcom/example/paul/a_sacco/Transaction$Transtype;

    iput-object v5, v4, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    .line 142
    move-object v4, v0

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Deposit(Landroid/view/View;)V

    .line 143
    goto :goto_0

    .line 146
    :pswitch_3
    move-object v4, v0

    move-object v5, v1

    const v6, 0x7f03001f

    move-object v7, v2

    const/4 v8, 0x0

    invoke-virtual {v5, v6, v7, v8}, Landroid/view/LayoutInflater;->inflate(ILandroid/view/ViewGroup;Z)Landroid/view/View;

    move-result-object v5

    iput-object v5, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    .line 147
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    sget-object v5, Lcom/example/paul/a_sacco/Transaction$Transtype;->LoanRepayment:Lcom/example/paul/a_sacco/Transaction$Transtype;

    iput-object v5, v4, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    .line 148
    move-object v4, v0

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->LoanRepayment(Landroid/view/View;)V

    .line 149
    goto/16 :goto_0

    .line 152
    :pswitch_4
    move-object v4, v0

    move-object v5, v1

    const v6, 0x7f030026

    move-object v7, v2

    const/4 v8, 0x0

    invoke-virtual {v5, v6, v7, v8}, Landroid/view/LayoutInflater;->inflate(ILandroid/view/ViewGroup;Z)Landroid/view/View;

    move-result-object v5

    iput-object v5, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    .line 153
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    sget-object v5, Lcom/example/paul/a_sacco/Transaction$Transtype;->Transfer:Lcom/example/paul/a_sacco/Transaction$Transtype;

    iput-object v5, v4, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    .line 154
    move-object v4, v0

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Transfer(Landroid/view/View;)V

    .line 155
    goto/16 :goto_0

    .line 158
    :pswitch_5
    move-object v4, v0

    move-object v5, v1

    const v6, 0x7f030027

    move-object v7, v2

    const/4 v8, 0x0

    invoke-virtual {v5, v6, v7, v8}, Landroid/view/LayoutInflater;->inflate(ILandroid/view/ViewGroup;Z)Landroid/view/View;

    move-result-object v5

    iput-object v5, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    .line 159
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    sget-object v5, Lcom/example/paul/a_sacco/Transaction$Transtype;->Sharedeposit:Lcom/example/paul/a_sacco/Transaction$Transtype;

    iput-object v5, v4, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    .line 160
    move-object v4, v0

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Sharedeposit(Landroid/view/View;)V

    .line 161
    goto/16 :goto_0

    .line 165
    :pswitch_6
    move-object v4, v0

    move-object v5, v1

    const v6, 0x7f03001c

    move-object v7, v2

    const/4 v8, 0x0

    invoke-virtual {v5, v6, v7, v8}, Landroid/view/LayoutInflater;->inflate(ILandroid/view/ViewGroup;Z)Landroid/view/View;

    move-result-object v5

    iput-object v5, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    .line 166
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    sget-object v5, Lcom/example/paul/a_sacco/Transaction$Transtype;->Balance:Lcom/example/paul/a_sacco/Transaction$Transtype;

    iput-object v5, v4, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    .line 167
    move-object v4, v0

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Balance(Landroid/view/View;)V

    .line 168
    goto/16 :goto_0

    .line 171
    :pswitch_7
    move-object v4, v0

    move-object v5, v1

    const v6, 0x7f03001c

    move-object v7, v2

    const/4 v8, 0x0

    invoke-virtual {v5, v6, v7, v8}, Landroid/view/LayoutInflater;->inflate(ILandroid/view/ViewGroup;Z)Landroid/view/View;

    move-result-object v5

    iput-object v5, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    .line 172
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    sget-object v5, Lcom/example/paul/a_sacco/Transaction$Transtype;->Ministatment:Lcom/example/paul/a_sacco/Transaction$Transtype;

    iput-object v5, v4, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    .line 173
    move-object v4, v0

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Balance(Landroid/view/View;)V

    .line 174
    goto/16 :goto_0

    .line 177
    :pswitch_8
    move-object v4, v0

    move-object v5, v1

    const v6, 0x7f030026

    move-object v7, v2

    const/4 v8, 0x0

    invoke-virtual {v5, v6, v7, v8}, Landroid/view/LayoutInflater;->inflate(ILandroid/view/ViewGroup;Z)Landroid/view/View;

    move-result-object v5

    iput-object v5, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    .line 178
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    sget-object v5, Lcom/example/paul/a_sacco/Transaction$Transtype;->Paybill:Lcom/example/paul/a_sacco/Transaction$Transtype;

    iput-object v5, v4, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    .line 179
    move-object v4, v0

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Transfer(Landroid/view/View;)V

    .line 180
    goto/16 :goto_0

    .line 183
    :pswitch_9
    move-object v4, v0

    move-object v5, v1

    const v6, 0x7f030022

    move-object v7, v2

    const/4 v8, 0x0

    invoke-virtual {v5, v6, v7, v8}, Landroid/view/LayoutInflater;->inflate(ILandroid/view/ViewGroup;Z)Landroid/view/View;

    move-result-object v5

    iput-object v5, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    .line 184
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    sget-object v5, Lcom/example/paul/a_sacco/Transaction$Transtype;->Changepin:Lcom/example/paul/a_sacco/Transaction$Transtype;

    iput-object v5, v4, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    .line 185
    move-object v4, v0

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->changepin(Landroid/view/View;)V

    .line 186
    goto/16 :goto_0

    .line 189
    :pswitch_a
    move-object v4, v0

    move-object v5, v1

    const v6, 0x7f03002a

    move-object v7, v2

    const/4 v8, 0x0

    invoke-virtual {v5, v6, v7, v8}, Landroid/view/LayoutInflater;->inflate(ILandroid/view/ViewGroup;Z)Landroid/view/View;

    move-result-object v5

    iput-object v5, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    .line 190
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    sget-object v5, Lcom/example/paul/a_sacco/Transaction$Transtype;->Memberactivation:Lcom/example/paul/a_sacco/Transaction$Transtype;

    iput-object v5, v4, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    .line 191
    move-object v4, v0

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Activation(Landroid/view/View;)V

    .line 192
    goto/16 :goto_0

    .line 195
    :pswitch_b
    move-object v4, v0

    move-object v5, v1

    const v6, 0x7f030023

    move-object v7, v2

    const/4 v8, 0x0

    invoke-virtual {v5, v6, v7, v8}, Landroid/view/LayoutInflater;->inflate(ILandroid/view/ViewGroup;Z)Landroid/view/View;

    move-result-object v5

    iput-object v5, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    .line 196
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    sget-object v5, Lcom/example/paul/a_sacco/Transaction$Transtype;->MemberRegistration:Lcom/example/paul/a_sacco/Transaction$Transtype;

    iput-object v5, v4, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    .line 197
    move-object v4, v0

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Registration(Landroid/view/View;)V

    goto/16 :goto_0

    .line 126
    nop

    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_0
        :pswitch_1
        :pswitch_2
        :pswitch_3
        :pswitch_4
        :pswitch_5
        :pswitch_6
        :pswitch_7
        :pswitch_8
        :pswitch_9
        :pswitch_a
        :pswitch_b
    .end packed-switch
.end method
