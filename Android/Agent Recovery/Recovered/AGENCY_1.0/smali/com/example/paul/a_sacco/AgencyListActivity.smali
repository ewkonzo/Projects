.class public Lcom/example/paul/a_sacco/AgencyListActivity;
.super Landroid/support/v4/app/FragmentActivity;
.source "AgencyListActivity.java"

# interfaces
.implements Lcom/example/paul/a_sacco/AgencyListFragment$Callbacks;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword;,
        Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;
    }
.end annotation


# instance fields
.field private mTwoPane:Z


# direct methods
.method public constructor <init>()V
    .locals 2

    .prologue
    .line 41
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyListActivity;
    move-object v1, v0

    invoke-direct {v1}, Landroid/support/v4/app/FragmentActivity;-><init>()V

    .line 182
    return-void
.end method


# virtual methods
.method protected onCreate(Landroid/os/Bundle;)V
    .locals 4

    .prologue
    .line 52
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyListActivity;
    move-object v1, p1

    .local v1, "savedInstanceState":Landroid/os/Bundle;
    move-object v2, v0

    move-object v3, v1

    invoke-super {v2, v3}, Landroid/support/v4/app/FragmentActivity;->onCreate(Landroid/os/Bundle;)V

    .line 53
    move-object v2, v0

    const v3, 0x7f03001a

    invoke-virtual {v2, v3}, Lcom/example/paul/a_sacco/AgencyListActivity;->setContentView(I)V

    .line 55
    move-object v2, v0

    const v3, 0x7f09003f

    invoke-virtual {v2, v3}, Lcom/example/paul/a_sacco/AgencyListActivity;->findViewById(I)Landroid/view/View;

    move-result-object v2

    if-eqz v2, :cond_0

    .line 60
    move-object v2, v0

    const/4 v3, 0x1

    iput-boolean v3, v2, Lcom/example/paul/a_sacco/AgencyListActivity;->mTwoPane:Z

    .line 64
    move-object v2, v0

    invoke-virtual {v2}, Lcom/example/paul/a_sacco/AgencyListActivity;->getSupportFragmentManager()Landroid/support/v4/app/FragmentManager;

    move-result-object v2

    const v3, 0x7f090040

    invoke-virtual {v2, v3}, Landroid/support/v4/app/FragmentManager;->findFragmentById(I)Landroid/support/v4/app/Fragment;

    move-result-object v2

    check-cast v2, Lcom/example/paul/a_sacco/AgencyListFragment;

    const/4 v3, 0x1

    invoke-virtual {v2, v3}, Lcom/example/paul/a_sacco/AgencyListFragment;->setActivateOnItemClick(Z)V

    .line 70
    :cond_0
    return-void
.end method

.method public onCreateOptionsMenu(Landroid/view/Menu;)Z
    .locals 5

    .prologue
    .line 104
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyListActivity;
    move-object v1, p1

    .local v1, "menu":Landroid/view/Menu;
    move-object v2, v0

    invoke-virtual {v2}, Lcom/example/paul/a_sacco/AgencyListActivity;->getMenuInflater()Landroid/view/MenuInflater;

    move-result-object v2

    const v3, 0x7f0e0004

    move-object v4, v1

    invoke-virtual {v2, v3, v4}, Landroid/view/MenuInflater;->inflate(ILandroid/view/Menu;)V

    .line 105
    move-object v2, v0

    move-object v3, v1

    invoke-super {v2, v3}, Landroid/support/v4/app/FragmentActivity;->onCreateOptionsMenu(Landroid/view/Menu;)Z

    move-result v2

    .line 106
    const/4 v2, 0x1

    move v0, v2

    .end local v0    # "this":Lcom/example/paul/a_sacco/AgencyListActivity;
    return v0
.end method

.method public onItemSelected(Ljava/lang/String;)V
    .locals 9

    .prologue
    .line 78
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyListActivity;
    move-object v1, p1

    .local v1, "id":Ljava/lang/String;
    move-object v4, v0

    iget-boolean v4, v4, Lcom/example/paul/a_sacco/AgencyListActivity;->mTwoPane:Z

    if-eqz v4, :cond_0

    .line 82
    new-instance v4, Landroid/os/Bundle;

    move-object v8, v4

    move-object v4, v8

    move-object v5, v8

    invoke-direct {v5}, Landroid/os/Bundle;-><init>()V

    move-object v2, v4

    .line 83
    .local v2, "arguments":Landroid/os/Bundle;
    move-object v4, v2

    const-string v5, "item_id"

    move-object v6, v1

    invoke-virtual {v4, v5, v6}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 84
    move-object v4, v2

    const-string v5, "Pane"

    move-object v6, v0

    iget-boolean v6, v6, Lcom/example/paul/a_sacco/AgencyListActivity;->mTwoPane:Z

    invoke-virtual {v4, v5, v6}, Landroid/os/Bundle;->putBoolean(Ljava/lang/String;Z)V

    .line 85
    new-instance v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object v8, v4

    move-object v4, v8

    move-object v5, v8

    invoke-direct {v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment;-><init>()V

    move-object v3, v4

    .line 86
    .local v3, "fragment":Lcom/example/paul/a_sacco/AgencyDetailFragment;
    move-object v4, v3

    move-object v5, v2

    invoke-virtual {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->setArguments(Landroid/os/Bundle;)V

    .line 87
    move-object v4, v0

    invoke-virtual {v4}, Lcom/example/paul/a_sacco/AgencyListActivity;->getSupportFragmentManager()Landroid/support/v4/app/FragmentManager;

    move-result-object v4

    invoke-virtual {v4}, Landroid/support/v4/app/FragmentManager;->beginTransaction()Landroid/support/v4/app/FragmentTransaction;

    move-result-object v4

    const v5, 0x7f09003f

    move-object v6, v3

    invoke-virtual {v4, v5, v6}, Landroid/support/v4/app/FragmentTransaction;->replace(ILandroid/support/v4/app/Fragment;)Landroid/support/v4/app/FragmentTransaction;

    move-result-object v4

    invoke-virtual {v4}, Landroid/support/v4/app/FragmentTransaction;->commit()I

    move-result v4

    .line 91
    .line 99
    .end local v2    # "arguments":Landroid/os/Bundle;
    .end local v3    # "fragment":Lcom/example/paul/a_sacco/AgencyDetailFragment;
    :goto_0
    return-void

    .line 94
    :cond_0
    new-instance v4, Landroid/content/Intent;

    move-object v8, v4

    move-object v4, v8

    move-object v5, v8

    move-object v6, v0

    const-class v7, Lcom/example/paul/a_sacco/AgencyDetailActivity;

    invoke-direct {v5, v6, v7}, Landroid/content/Intent;-><init>(Landroid/content/Context;Ljava/lang/Class;)V

    move-object v2, v4

    .line 95
    .local v2, "detailIntent":Landroid/content/Intent;
    move-object v4, v2

    const-string v5, "item_id"

    move-object v6, v1

    invoke-virtual {v4, v5, v6}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Ljava/lang/String;)Landroid/content/Intent;

    move-result-object v4

    .line 96
    move-object v4, v2

    const-string v5, "Pane"

    move-object v6, v0

    iget-boolean v6, v6, Lcom/example/paul/a_sacco/AgencyListActivity;->mTwoPane:Z

    invoke-virtual {v4, v5, v6}, Landroid/content/Intent;->putExtra(Ljava/lang/String;Z)Landroid/content/Intent;

    move-result-object v4

    .line 97
    move-object v4, v0

    move-object v5, v2

    invoke-virtual {v4, v5}, Lcom/example/paul/a_sacco/AgencyListActivity;->startActivity(Landroid/content/Intent;)V

    goto :goto_0
.end method

.method public onOptionsItemSelected(Landroid/view/MenuItem;)Z
    .locals 10

    .prologue
    .line 114
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyListActivity;
    move-object v1, p1

    .local v1, "item":Landroid/view/MenuItem;
    move-object v5, v1

    invoke-interface {v5}, Landroid/view/MenuItem;->getItemId()I

    move-result v5

    move v2, v5

    .line 115
    .local v2, "id":I
    move v5, v2

    packed-switch v5, :pswitch_data_0

    .line 128
    :goto_0
    move-object v5, v0

    move-object v6, v1

    invoke-super {v5, v6}, Landroid/support/v4/app/FragmentActivity;->onOptionsItemSelected(Landroid/view/MenuItem;)Z

    move-result v5

    move v0, v5

    .end local v0    # "this":Lcom/example/paul/a_sacco/AgencyListActivity;
    return v0

    .line 119
    .restart local v0    # "this":Lcom/example/paul/a_sacco/AgencyListActivity;
    :pswitch_0
    new-instance v5, Landroid/content/Intent;

    move-object v9, v5

    move-object v5, v9

    move-object v6, v9

    move-object v7, v0

    invoke-virtual {v7}, Lcom/example/paul/a_sacco/AgencyListActivity;->getApplicationContext()Landroid/content/Context;

    move-result-object v7

    const-class v8, Lcom/example/paul/a_sacco/SettingsActivity;

    invoke-direct {v6, v7, v8}, Landroid/content/Intent;-><init>(Landroid/content/Context;Ljava/lang/Class;)V

    move-object v3, v5

    .line 120
    .local v3, "intent":Landroid/content/Intent;
    move-object v5, v0

    move-object v6, v3

    invoke-virtual {v5, v6}, Lcom/example/paul/a_sacco/AgencyListActivity;->startActivity(Landroid/content/Intent;)V

    .line 121
    goto :goto_0

    .line 123
    .end local v3    # "intent":Landroid/content/Intent;
    :pswitch_1
    new-instance v5, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword;

    move-object v9, v5

    move-object v5, v9

    move-object v6, v9

    move-object v7, v0

    invoke-direct {v6, v7}, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword;-><init>(Lcom/example/paul/a_sacco/AgencyListActivity;)V

    move-object v4, v5

    .line 124
    .local v4, "c":Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword;
    move-object v5, v4

    move-object v6, v0

    invoke-virtual {v5, v6}, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword;->changepin(Landroid/content/Context;)V

    goto :goto_0

    .line 115
    :pswitch_data_0
    .packed-switch 0x7f090081
        :pswitch_0
        :pswitch_1
    .end packed-switch
.end method
