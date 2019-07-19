.class public Lcom/example/paul/a_sacco/BindLoans;
.super Landroid/widget/BaseAdapter;
.source "BindLoans.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/example/paul/a_sacco/BindLoans$ViewHolder;
    }
.end annotation


# static fields
.field public static outdata:Lcom/example/paul/a_sacco/Loans;


# instance fields
.field DataCollection:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List",
            "<",
            "Lcom/example/paul/a_sacco/Loans;",
            ">;"
        }
    .end annotation
.end field

.field holder:Lcom/example/paul/a_sacco/BindLoans$ViewHolder;

.field inflater:Landroid/view/LayoutInflater;

.field private mSelectedPosition:I

.field private mSelectedRB:Landroid/widget/RadioButton;

.field thumb_image:Landroid/widget/ImageView;


# direct methods
.method public constructor <init>()V
    .locals 3

    .prologue
    .line 24
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/BindLoans;
    move-object v1, v0

    invoke-direct {v1}, Landroid/widget/BaseAdapter;-><init>()V

    .line 17
    move-object v1, v0

    const/4 v2, -0x1

    iput v2, v1, Lcom/example/paul/a_sacco/BindLoans;->mSelectedPosition:I

    .line 26
    return-void
.end method

.method public constructor <init>(Landroid/app/Activity;Ljava/util/List;)V
    .locals 6
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/app/Activity;",
            "Ljava/util/List",
            "<",
            "Lcom/example/paul/a_sacco/Loans;",
            ">;)V"
        }
    .end annotation

    .prologue
    .line 28
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/BindLoans;
    move-object v1, p1

    .local v1, "act":Landroid/app/Activity;
    move-object v2, p2

    .local v2, "map":Ljava/util/List;, "Ljava/util/List<Lcom/example/paul/a_sacco/Loans;>;"
    move-object v3, v0

    invoke-direct {v3}, Landroid/widget/BaseAdapter;-><init>()V

    .line 17
    move-object v3, v0

    const/4 v4, -0x1

    iput v4, v3, Lcom/example/paul/a_sacco/BindLoans;->mSelectedPosition:I

    .line 30
    move-object v3, v0

    move-object v4, v2

    iput-object v4, v3, Lcom/example/paul/a_sacco/BindLoans;->DataCollection:Ljava/util/List;

    .line 32
    move-object v3, v0

    move-object v4, v1

    const-string v5, "layout_inflater"

    invoke-virtual {v4, v5}, Landroid/app/Activity;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Landroid/view/LayoutInflater;

    iput-object v4, v3, Lcom/example/paul/a_sacco/BindLoans;->inflater:Landroid/view/LayoutInflater;

    .line 34
    return-void
.end method

.method static synthetic access$000(Lcom/example/paul/a_sacco/BindLoans;)I
    .locals 2

    .prologue
    .line 16
    move-object v0, p0

    .local v0, "x0":Lcom/example/paul/a_sacco/BindLoans;
    move-object v1, v0

    iget v1, v1, Lcom/example/paul/a_sacco/BindLoans;->mSelectedPosition:I

    move v0, v1

    .end local v0    # "x0":Lcom/example/paul/a_sacco/BindLoans;
    return v0
.end method

.method static synthetic access$002(Lcom/example/paul/a_sacco/BindLoans;I)I
    .locals 7

    .prologue
    .line 16
    move-object v0, p0

    .local v0, "x0":Lcom/example/paul/a_sacco/BindLoans;
    move v1, p1

    .local v1, "x1":I
    move-object v2, v0

    move v3, v1

    move-object v5, v2

    move v6, v3

    move v2, v6

    move-object v3, v5

    move v4, v6

    iput v4, v3, Lcom/example/paul/a_sacco/BindLoans;->mSelectedPosition:I

    move v0, v2

    .end local v0    # "x0":Lcom/example/paul/a_sacco/BindLoans;
    return v0
.end method

.method static synthetic access$100(Lcom/example/paul/a_sacco/BindLoans;)Landroid/widget/RadioButton;
    .locals 2

    .prologue
    .line 16
    move-object v0, p0

    .local v0, "x0":Lcom/example/paul/a_sacco/BindLoans;
    move-object v1, v0

    iget-object v1, v1, Lcom/example/paul/a_sacco/BindLoans;->mSelectedRB:Landroid/widget/RadioButton;

    move-object v0, v1

    .end local v0    # "x0":Lcom/example/paul/a_sacco/BindLoans;
    return-object v0
.end method

.method static synthetic access$102(Lcom/example/paul/a_sacco/BindLoans;Landroid/widget/RadioButton;)Landroid/widget/RadioButton;
    .locals 7

    .prologue
    .line 16
    move-object v0, p0

    .local v0, "x0":Lcom/example/paul/a_sacco/BindLoans;
    move-object v1, p1

    .local v1, "x1":Landroid/widget/RadioButton;
    move-object v2, v0

    move-object v3, v1

    move-object v5, v2

    move-object v6, v3

    move-object v2, v6

    move-object v3, v5

    move-object v4, v6

    iput-object v4, v3, Lcom/example/paul/a_sacco/BindLoans;->mSelectedRB:Landroid/widget/RadioButton;

    move-object v0, v2

    .end local v0    # "x0":Lcom/example/paul/a_sacco/BindLoans;
    return-object v0
.end method


# virtual methods
.method public getCount()I
    .locals 2

    .prologue
    .line 40
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/BindLoans;
    move-object v1, v0

    iget-object v1, v1, Lcom/example/paul/a_sacco/BindLoans;->DataCollection:Ljava/util/List;

    invoke-interface {v1}, Ljava/util/List;->size()I

    move-result v1

    move v0, v1

    .end local v0    # "this":Lcom/example/paul/a_sacco/BindLoans;
    return v0
.end method

.method public getItem(I)Ljava/lang/Object;
    .locals 3

    .prologue
    .line 45
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/BindLoans;
    move v1, p1

    .local v1, "arg0":I
    const/4 v2, 0x0

    move-object v0, v2

    .end local v0    # "this":Lcom/example/paul/a_sacco/BindLoans;
    return-object v0
.end method

.method public getItemId(I)J
    .locals 4

    .prologue
    .line 50
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/BindLoans;
    move v1, p1

    .local v1, "position":I
    const-wide/16 v2, 0x0

    move-wide v0, v2

    .end local v0    # "this":Lcom/example/paul/a_sacco/BindLoans;
    return-wide v0
.end method

.method public getView(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;
    .locals 12

    .prologue
    .line 55
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/BindLoans;
    move v1, p1

    .local v1, "position":I
    move-object v2, p2

    .local v2, "convertView":Landroid/view/View;
    move-object v3, p3

    .local v3, "parent":Landroid/view/ViewGroup;
    move-object v6, v2

    move-object v4, v6

    .line 57
    .local v4, "vi":Landroid/view/View;
    move-object v6, v0

    move v7, v1

    invoke-virtual {v6, v7}, Lcom/example/paul/a_sacco/BindLoans;->getItemViewType(I)I

    move-result v6

    move v5, v6

    .line 58
    .local v5, "_intPosition":I
    move-object v6, v2

    if-nez v6, :cond_1

    .line 59
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/BindLoans;->inflater:Landroid/view/LayoutInflater;

    const v7, 0x7f030029

    const/4 v8, 0x0

    invoke-virtual {v6, v7, v8}, Landroid/view/LayoutInflater;->inflate(ILandroid/view/ViewGroup;)Landroid/view/View;

    move-result-object v6

    move-object v4, v6

    .line 60
    move-object v6, v0

    new-instance v7, Lcom/example/paul/a_sacco/BindLoans$ViewHolder;

    move-object v11, v7

    move-object v7, v11

    move-object v8, v11

    invoke-direct {v8}, Lcom/example/paul/a_sacco/BindLoans$ViewHolder;-><init>()V

    iput-object v7, v6, Lcom/example/paul/a_sacco/BindLoans;->holder:Lcom/example/paul/a_sacco/BindLoans$ViewHolder;

    .line 61
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/BindLoans;->holder:Lcom/example/paul/a_sacco/BindLoans$ViewHolder;

    move-object v7, v4

    const v8, 0x7f09007c

    invoke-virtual {v7, v8}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v7

    check-cast v7, Landroid/widget/TextView;

    iput-object v7, v6, Lcom/example/paul/a_sacco/BindLoans$ViewHolder;->Loan_no:Landroid/widget/TextView;

    .line 62
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/BindLoans;->holder:Lcom/example/paul/a_sacco/BindLoans$ViewHolder;

    move-object v7, v4

    const v8, 0x7f09007b

    invoke-virtual {v7, v8}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v7

    check-cast v7, Landroid/widget/TextView;

    iput-object v7, v6, Lcom/example/paul/a_sacco/BindLoans$ViewHolder;->Type:Landroid/widget/TextView;

    .line 64
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/BindLoans;->holder:Lcom/example/paul/a_sacco/BindLoans$ViewHolder;

    move-object v7, v4

    const v8, 0x7f09002f

    invoke-virtual {v7, v8}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v7

    check-cast v7, Landroid/widget/RadioButton;

    iput-object v7, v6, Lcom/example/paul/a_sacco/BindLoans$ViewHolder;->radio:Landroid/widget/RadioButton;

    .line 65
    move-object v6, v4

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/BindLoans;->holder:Lcom/example/paul/a_sacco/BindLoans$ViewHolder;

    invoke-virtual {v6, v7}, Landroid/view/View;->setTag(Ljava/lang/Object;)V

    .line 71
    :goto_0
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/BindLoans;->holder:Lcom/example/paul/a_sacco/BindLoans$ViewHolder;

    iget-object v6, v6, Lcom/example/paul/a_sacco/BindLoans$ViewHolder;->Loan_no:Landroid/widget/TextView;

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/BindLoans;->DataCollection:Ljava/util/List;

    move v8, v1

    invoke-interface {v7, v8}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v7

    check-cast v7, Lcom/example/paul/a_sacco/Loans;

    iget-object v7, v7, Lcom/example/paul/a_sacco/Loans;->Loan_No:Ljava/lang/String;

    invoke-virtual {v6, v7}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 72
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/BindLoans;->holder:Lcom/example/paul/a_sacco/BindLoans$ViewHolder;

    iget-object v6, v6, Lcom/example/paul/a_sacco/BindLoans$ViewHolder;->Type:Landroid/widget/TextView;

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/BindLoans;->DataCollection:Ljava/util/List;

    move v8, v1

    invoke-interface {v7, v8}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v7

    check-cast v7, Lcom/example/paul/a_sacco/Loans;

    iget-object v7, v7, Lcom/example/paul/a_sacco/Loans;->Loan_Type_Name:Ljava/lang/String;

    invoke-virtual {v6, v7}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 74
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/BindLoans;->holder:Lcom/example/paul/a_sacco/BindLoans$ViewHolder;

    iget-object v6, v6, Lcom/example/paul/a_sacco/BindLoans$ViewHolder;->radio:Landroid/widget/RadioButton;

    new-instance v7, Lcom/example/paul/a_sacco/BindLoans$1;

    move-object v11, v7

    move-object v7, v11

    move-object v8, v11

    move-object v9, v0

    move v10, v1

    invoke-direct {v8, v9, v10}, Lcom/example/paul/a_sacco/BindLoans$1;-><init>(Lcom/example/paul/a_sacco/BindLoans;I)V

    invoke-virtual {v6, v7}, Landroid/widget/RadioButton;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    .line 85
    move-object v6, v0

    iget v6, v6, Lcom/example/paul/a_sacco/BindLoans;->mSelectedPosition:I

    move v7, v1

    if-eq v6, v7, :cond_2

    .line 86
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/BindLoans;->holder:Lcom/example/paul/a_sacco/BindLoans$ViewHolder;

    iget-object v6, v6, Lcom/example/paul/a_sacco/BindLoans$ViewHolder;->radio:Landroid/widget/RadioButton;

    const/4 v7, 0x0

    invoke-virtual {v6, v7}, Landroid/widget/RadioButton;->setChecked(Z)V

    .line 92
    :cond_0
    :goto_1
    move-object v6, v4

    move-object v0, v6

    .end local v0    # "this":Lcom/example/paul/a_sacco/BindLoans;
    return-object v0

    .line 68
    .restart local v0    # "this":Lcom/example/paul/a_sacco/BindLoans;
    :cond_1
    move-object v6, v0

    move-object v7, v4

    invoke-virtual {v7}, Landroid/view/View;->getTag()Ljava/lang/Object;

    move-result-object v7

    check-cast v7, Lcom/example/paul/a_sacco/BindLoans$ViewHolder;

    iput-object v7, v6, Lcom/example/paul/a_sacco/BindLoans;->holder:Lcom/example/paul/a_sacco/BindLoans$ViewHolder;

    goto :goto_0

    .line 88
    :cond_2
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/BindLoans;->holder:Lcom/example/paul/a_sacco/BindLoans$ViewHolder;

    iget-object v6, v6, Lcom/example/paul/a_sacco/BindLoans$ViewHolder;->radio:Landroid/widget/RadioButton;

    const/4 v7, 0x1

    invoke-virtual {v6, v7}, Landroid/widget/RadioButton;->setChecked(Z)V

    .line 89
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/BindLoans;->mSelectedRB:Landroid/widget/RadioButton;

    if-eqz v6, :cond_0

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/BindLoans;->holder:Lcom/example/paul/a_sacco/BindLoans$ViewHolder;

    iget-object v6, v6, Lcom/example/paul/a_sacco/BindLoans$ViewHolder;->radio:Landroid/widget/RadioButton;

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/BindLoans;->mSelectedRB:Landroid/widget/RadioButton;

    if-eq v6, v7, :cond_0

    .line 90
    move-object v6, v0

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/BindLoans;->holder:Lcom/example/paul/a_sacco/BindLoans$ViewHolder;

    iget-object v7, v7, Lcom/example/paul/a_sacco/BindLoans$ViewHolder;->radio:Landroid/widget/RadioButton;

    iput-object v7, v6, Lcom/example/paul/a_sacco/BindLoans;->mSelectedRB:Landroid/widget/RadioButton;

    goto :goto_1
.end method
