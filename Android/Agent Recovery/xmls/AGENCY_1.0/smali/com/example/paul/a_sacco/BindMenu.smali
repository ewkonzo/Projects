.class public Lcom/example/paul/a_sacco/BindMenu;
.super Landroid/widget/BaseAdapter;
.source "BindMenu.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/example/paul/a_sacco/BindMenu$ViewHolder;
    }
.end annotation


# instance fields
.field holder:Lcom/example/paul/a_sacco/BindMenu$ViewHolder;

.field inflater:Landroid/view/LayoutInflater;

.field thumb_image:Landroid/widget/ImageView;

.field weatherDataCollection:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List",
            "<",
            "Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method public constructor <init>()V
    .locals 2

    .prologue
    .line 28
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/BindMenu;
    move-object v1, v0

    invoke-direct {v1}, Landroid/widget/BaseAdapter;-><init>()V

    .line 30
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
            "Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;",
            ">;)V"
        }
    .end annotation

    .prologue
    .line 32
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/BindMenu;
    move-object v1, p1

    .local v1, "act":Landroid/app/Activity;
    move-object v2, p2

    .local v2, "map":Ljava/util/List;, "Ljava/util/List<Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;>;"
    move-object v3, v0

    invoke-direct {v3}, Landroid/widget/BaseAdapter;-><init>()V

    .line 34
    move-object v3, v0

    move-object v4, v2

    iput-object v4, v3, Lcom/example/paul/a_sacco/BindMenu;->weatherDataCollection:Ljava/util/List;

    .line 36
    move-object v3, v0

    move-object v4, v1

    const-string v5, "layout_inflater"

    invoke-virtual {v4, v5}, Landroid/app/Activity;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Landroid/view/LayoutInflater;

    iput-object v4, v3, Lcom/example/paul/a_sacco/BindMenu;->inflater:Landroid/view/LayoutInflater;

    .line 38
    return-void
.end method


# virtual methods
.method public getCount()I
    .locals 2

    .prologue
    .line 44
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/BindMenu;
    move-object v1, v0

    iget-object v1, v1, Lcom/example/paul/a_sacco/BindMenu;->weatherDataCollection:Ljava/util/List;

    invoke-interface {v1}, Ljava/util/List;->size()I

    move-result v1

    move v0, v1

    .end local v0    # "this":Lcom/example/paul/a_sacco/BindMenu;
    return v0
.end method

.method public getItem(I)Ljava/lang/Object;
    .locals 3

    .prologue
    .line 49
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/BindMenu;
    move v1, p1

    .local v1, "arg0":I
    const/4 v2, 0x0

    move-object v0, v2

    .end local v0    # "this":Lcom/example/paul/a_sacco/BindMenu;
    return-object v0
.end method

.method public getItemId(I)J
    .locals 4

    .prologue
    .line 54
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/BindMenu;
    move v1, p1

    .local v1, "position":I
    const-wide/16 v2, 0x0

    move-wide v0, v2

    .end local v0    # "this":Lcom/example/paul/a_sacco/BindMenu;
    return-wide v0
.end method

.method public getView(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;
    .locals 9

    .prologue
    .line 59
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/BindMenu;
    move v1, p1

    .local v1, "position":I
    move-object v2, p2

    .local v2, "convertView":Landroid/view/View;
    move-object v3, p3

    .local v3, "parent":Landroid/view/ViewGroup;
    move-object v5, v2

    move-object v4, v5

    .line 62
    .local v4, "vi":Landroid/view/View;
    move-object v5, v2

    if-nez v5, :cond_0

    .line 63
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/BindMenu;->inflater:Landroid/view/LayoutInflater;

    const v6, 0x7f03002b

    const/4 v7, 0x0

    invoke-virtual {v5, v6, v7}, Landroid/view/LayoutInflater;->inflate(ILandroid/view/ViewGroup;)Landroid/view/View;

    move-result-object v5

    move-object v4, v5

    .line 64
    move-object v5, v0

    new-instance v6, Lcom/example/paul/a_sacco/BindMenu$ViewHolder;

    move-object v8, v6

    move-object v6, v8

    move-object v7, v8

    invoke-direct {v7}, Lcom/example/paul/a_sacco/BindMenu$ViewHolder;-><init>()V

    iput-object v6, v5, Lcom/example/paul/a_sacco/BindMenu;->holder:Lcom/example/paul/a_sacco/BindMenu$ViewHolder;

    .line 66
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/BindMenu;->holder:Lcom/example/paul/a_sacco/BindMenu$ViewHolder;

    move-object v6, v4

    const v7, 0x7f09007f

    invoke-virtual {v6, v7}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v6

    check-cast v6, Landroid/widget/TextView;

    iput-object v6, v5, Lcom/example/paul/a_sacco/BindMenu$ViewHolder;->tvName:Landroid/widget/TextView;

    .line 67
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/BindMenu;->holder:Lcom/example/paul/a_sacco/BindMenu$ViewHolder;

    move-object v6, v4

    const v7, 0x7f09007e

    invoke-virtual {v6, v7}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v6

    check-cast v6, Landroid/widget/ImageView;

    iput-object v6, v5, Lcom/example/paul/a_sacco/BindMenu$ViewHolder;->tvdelete:Landroid/widget/ImageView;

    .line 68
    move-object v5, v4

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/BindMenu;->holder:Lcom/example/paul/a_sacco/BindMenu$ViewHolder;

    invoke-virtual {v5, v6}, Landroid/view/View;->setTag(Ljava/lang/Object;)V

    .line 74
    :goto_0
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/BindMenu;->holder:Lcom/example/paul/a_sacco/BindMenu$ViewHolder;

    iget-object v5, v5, Lcom/example/paul/a_sacco/BindMenu$ViewHolder;->tvName:Landroid/widget/TextView;

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/BindMenu;->weatherDataCollection:Ljava/util/List;

    move v7, v1

    invoke-interface {v6, v7}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;

    iget-object v6, v6, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;->content:Ljava/lang/String;

    invoke-virtual {v5, v6}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 75
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/BindMenu;->holder:Lcom/example/paul/a_sacco/BindMenu$ViewHolder;

    iget-object v5, v5, Lcom/example/paul/a_sacco/BindMenu$ViewHolder;->tvdelete:Landroid/widget/ImageView;

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/BindMenu;->weatherDataCollection:Ljava/util/List;

    move v7, v1

    invoke-interface {v6, v7}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;

    iget v6, v6, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;->image:I

    invoke-virtual {v5, v6}, Landroid/widget/ImageView;->setImageResource(I)V

    .line 79
    move-object v5, v4

    move-object v0, v5

    .end local v0    # "this":Lcom/example/paul/a_sacco/BindMenu;
    return-object v0

    .line 71
    .restart local v0    # "this":Lcom/example/paul/a_sacco/BindMenu;
    :cond_0
    move-object v5, v0

    move-object v6, v4

    invoke-virtual {v6}, Landroid/view/View;->getTag()Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/example/paul/a_sacco/BindMenu$ViewHolder;

    iput-object v6, v5, Lcom/example/paul/a_sacco/BindMenu;->holder:Lcom/example/paul/a_sacco/BindMenu$ViewHolder;

    goto :goto_0
.end method
