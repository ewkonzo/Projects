.class public Lcom/example/paul/a_sacco/AgencyListFragment;
.super Landroid/support/v4/app/ListFragment;
.source "AgencyListFragment.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/example/paul/a_sacco/AgencyListFragment$Callbacks;
    }
.end annotation


# static fields
.field private static final STATE_ACTIVATED_POSITION:Ljava/lang/String; = "activated_position"

.field private static sDummyCallbacks:Lcom/example/paul/a_sacco/AgencyListFragment$Callbacks;


# instance fields
.field private mActivatedPosition:I

.field private mCallbacks:Lcom/example/paul/a_sacco/AgencyListFragment$Callbacks;


# direct methods
.method static constructor <clinit>()V
    .locals 3

    .prologue
    .line 57
    new-instance v0, Lcom/example/paul/a_sacco/AgencyListFragment$1;

    move-object v2, v0

    move-object v0, v2

    move-object v1, v2

    invoke-direct {v1}, Lcom/example/paul/a_sacco/AgencyListFragment$1;-><init>()V

    sput-object v0, Lcom/example/paul/a_sacco/AgencyListFragment;->sDummyCallbacks:Lcom/example/paul/a_sacco/AgencyListFragment$Callbacks;

    return-void
.end method

.method public constructor <init>()V
    .locals 3

    .prologue
    .line 67
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyListFragment;
    move-object v1, v0

    invoke-direct {v1}, Landroid/support/v4/app/ListFragment;-><init>()V

    .line 34
    move-object v1, v0

    sget-object v2, Lcom/example/paul/a_sacco/AgencyListFragment;->sDummyCallbacks:Lcom/example/paul/a_sacco/AgencyListFragment$Callbacks;

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyListFragment;->mCallbacks:Lcom/example/paul/a_sacco/AgencyListFragment$Callbacks;

    .line 39
    move-object v1, v0

    const/4 v2, -0x1

    iput v2, v1, Lcom/example/paul/a_sacco/AgencyListFragment;->mActivatedPosition:I

    .line 68
    return-void
.end method

.method private setActivatedPosition(I)V
    .locals 5

    .prologue
    .line 146
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyListFragment;
    move v1, p1

    .local v1, "position":I
    move v2, v1

    const/4 v3, -0x1

    if-ne v2, v3, :cond_0

    .line 147
    move-object v2, v0

    invoke-virtual {v2}, Lcom/example/paul/a_sacco/AgencyListFragment;->getListView()Landroid/widget/ListView;

    move-result-object v2

    move-object v3, v0

    iget v3, v3, Lcom/example/paul/a_sacco/AgencyListFragment;->mActivatedPosition:I

    const/4 v4, 0x0

    invoke-virtual {v2, v3, v4}, Landroid/widget/ListView;->setItemChecked(IZ)V

    .line 152
    :goto_0
    move-object v2, v0

    move v3, v1

    iput v3, v2, Lcom/example/paul/a_sacco/AgencyListFragment;->mActivatedPosition:I

    .line 153
    return-void

    .line 149
    :cond_0
    move-object v2, v0

    invoke-virtual {v2}, Lcom/example/paul/a_sacco/AgencyListFragment;->getListView()Landroid/widget/ListView;

    move-result-object v2

    move v3, v1

    const/4 v4, 0x1

    invoke-virtual {v2, v3, v4}, Landroid/widget/ListView;->setItemChecked(IZ)V

    goto :goto_0
.end method


# virtual methods
.method public onAttach(Landroid/app/Activity;)V
    .locals 6

    .prologue
    .line 97
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyListFragment;
    move-object v1, p1

    .local v1, "activity":Landroid/app/Activity;
    move-object v2, v0

    move-object v3, v1

    invoke-super {v2, v3}, Landroid/support/v4/app/ListFragment;->onAttach(Landroid/app/Activity;)V

    .line 100
    move-object v2, v1

    instance-of v2, v2, Lcom/example/paul/a_sacco/AgencyListFragment$Callbacks;

    if-nez v2, :cond_0

    .line 101
    new-instance v2, Ljava/lang/IllegalStateException;

    move-object v5, v2

    move-object v2, v5

    move-object v3, v5

    const-string v4, "Activity must implement fragment\'s callbacks."

    invoke-direct {v3, v4}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v2

    .line 104
    :cond_0
    move-object v2, v0

    move-object v3, v1

    check-cast v3, Lcom/example/paul/a_sacco/AgencyListFragment$Callbacks;

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyListFragment;->mCallbacks:Lcom/example/paul/a_sacco/AgencyListFragment$Callbacks;

    .line 105
    return-void
.end method

.method public onCreate(Landroid/os/Bundle;)V
    .locals 9

    .prologue
    .line 72
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyListFragment;
    move-object v1, p1

    .local v1, "savedInstanceState":Landroid/os/Bundle;
    move-object v3, v0

    move-object v4, v1

    invoke-super {v3, v4}, Landroid/support/v4/app/ListFragment;->onCreate(Landroid/os/Bundle;)V

    .line 75
    new-instance v3, Lcom/example/paul/a_sacco/BindMenu;

    move-object v8, v3

    move-object v3, v8

    move-object v4, v8

    move-object v5, v0

    invoke-virtual {v5}, Lcom/example/paul/a_sacco/AgencyListFragment;->getActivity()Landroid/support/v4/app/FragmentActivity;

    move-result-object v5

    new-instance v6, Lcom/example/paul/a_sacco/dummy/Menu;

    move-object v8, v6

    move-object v6, v8

    move-object v7, v8

    invoke-direct {v7}, Lcom/example/paul/a_sacco/dummy/Menu;-><init>()V

    sget-object v6, Lcom/example/paul/a_sacco/dummy/Menu;->ITEMS:Ljava/util/List;

    invoke-direct {v4, v5, v6}, Lcom/example/paul/a_sacco/BindMenu;-><init>(Landroid/app/Activity;Ljava/util/List;)V

    move-object v2, v3

    .line 76
    .local v2, "bindingData":Lcom/example/paul/a_sacco/BindMenu;
    move-object v3, v0

    move-object v4, v2

    invoke-virtual {v3, v4}, Lcom/example/paul/a_sacco/AgencyListFragment;->setListAdapter(Landroid/widget/ListAdapter;)V

    .line 82
    return-void
.end method

.method public onDetach()V
    .locals 3

    .prologue
    .line 109
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyListFragment;
    move-object v1, v0

    invoke-super {v1}, Landroid/support/v4/app/ListFragment;->onDetach()V

    .line 112
    move-object v1, v0

    sget-object v2, Lcom/example/paul/a_sacco/AgencyListFragment;->sDummyCallbacks:Lcom/example/paul/a_sacco/AgencyListFragment$Callbacks;

    iput-object v2, v1, Lcom/example/paul/a_sacco/AgencyListFragment;->mCallbacks:Lcom/example/paul/a_sacco/AgencyListFragment$Callbacks;

    .line 113
    return-void
.end method

.method public onListItemClick(Landroid/widget/ListView;Landroid/view/View;IJ)V
    .locals 12

    .prologue
    .line 117
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyListFragment;
    move-object v1, p1

    .local v1, "listView":Landroid/widget/ListView;
    move-object v2, p2

    .local v2, "view":Landroid/view/View;
    move v3, p3

    .local v3, "position":I
    move-wide/from16 v4, p4

    .local v4, "id":J
    move-object v6, v0

    move-object v7, v1

    move-object v8, v2

    move v9, v3

    move-wide v10, v4

    invoke-super/range {v6 .. v11}, Landroid/support/v4/app/ListFragment;->onListItemClick(Landroid/widget/ListView;Landroid/view/View;IJ)V

    .line 121
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyListFragment;->mCallbacks:Lcom/example/paul/a_sacco/AgencyListFragment$Callbacks;

    sget-object v7, Lcom/example/paul/a_sacco/dummy/Menu;->ITEMS:Ljava/util/List;

    move v8, v3

    invoke-interface {v7, v8}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v7

    check-cast v7, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;

    iget-object v7, v7, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;->id:Ljava/lang/String;

    invoke-interface {v6, v7}, Lcom/example/paul/a_sacco/AgencyListFragment$Callbacks;->onItemSelected(Ljava/lang/String;)V

    .line 122
    return-void
.end method

.method public onSaveInstanceState(Landroid/os/Bundle;)V
    .locals 5

    .prologue
    .line 126
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyListFragment;
    move-object v1, p1

    .local v1, "outState":Landroid/os/Bundle;
    move-object v2, v0

    move-object v3, v1

    invoke-super {v2, v3}, Landroid/support/v4/app/ListFragment;->onSaveInstanceState(Landroid/os/Bundle;)V

    .line 127
    move-object v2, v0

    iget v2, v2, Lcom/example/paul/a_sacco/AgencyListFragment;->mActivatedPosition:I

    const/4 v3, -0x1

    if-eq v2, v3, :cond_0

    .line 129
    move-object v2, v1

    const-string v3, "activated_position"

    move-object v4, v0

    iget v4, v4, Lcom/example/paul/a_sacco/AgencyListFragment;->mActivatedPosition:I

    invoke-virtual {v2, v3, v4}, Landroid/os/Bundle;->putInt(Ljava/lang/String;I)V

    .line 131
    :cond_0
    return-void
.end method

.method public onViewCreated(Landroid/view/View;Landroid/os/Bundle;)V
    .locals 6

    .prologue
    .line 86
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyListFragment;
    move-object v1, p1

    .local v1, "view":Landroid/view/View;
    move-object v2, p2

    .local v2, "savedInstanceState":Landroid/os/Bundle;
    move-object v3, v0

    move-object v4, v1

    move-object v5, v2

    invoke-super {v3, v4, v5}, Landroid/support/v4/app/ListFragment;->onViewCreated(Landroid/view/View;Landroid/os/Bundle;)V

    .line 89
    move-object v3, v2

    if-eqz v3, :cond_0

    move-object v3, v2

    const-string v4, "activated_position"

    invoke-virtual {v3, v4}, Landroid/os/Bundle;->containsKey(Ljava/lang/String;)Z

    move-result v3

    if-eqz v3, :cond_0

    .line 91
    move-object v3, v0

    move-object v4, v2

    const-string v5, "activated_position"

    invoke-virtual {v4, v5}, Landroid/os/Bundle;->getInt(Ljava/lang/String;)I

    move-result v4

    invoke-direct {v3, v4}, Lcom/example/paul/a_sacco/AgencyListFragment;->setActivatedPosition(I)V

    .line 93
    :cond_0
    return-void
.end method

.method public setActivateOnItemClick(Z)V
    .locals 4

    .prologue
    .line 140
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyListFragment;
    move v1, p1

    .local v1, "activateOnItemClick":Z
    move-object v2, v0

    invoke-virtual {v2}, Lcom/example/paul/a_sacco/AgencyListFragment;->getListView()Landroid/widget/ListView;

    move-result-object v2

    move v3, v1

    if-eqz v3, :cond_0

    const/4 v3, 0x1

    :goto_0
    invoke-virtual {v2, v3}, Landroid/widget/ListView;->setChoiceMode(I)V

    .line 143
    return-void

    .line 140
    :cond_0
    const/4 v3, 0x0

    goto :goto_0
.end method
