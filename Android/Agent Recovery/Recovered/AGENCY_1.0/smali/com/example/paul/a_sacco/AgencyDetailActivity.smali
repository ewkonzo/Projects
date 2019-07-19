.class public Lcom/example/paul/a_sacco/AgencyDetailActivity;
.super Landroid/support/v7/app/ActionBarActivity;
.source "AgencyDetailActivity.java"


# direct methods
.method public constructor <init>()V
    .locals 2

    .prologue
    .line 20
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailActivity;
    move-object v1, v0

    invoke-direct {v1}, Landroid/support/v7/app/ActionBarActivity;-><init>()V

    return-void
.end method


# virtual methods
.method protected onCreate(Landroid/os/Bundle;)V
    .locals 9

    .prologue
    .line 24
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailActivity;
    move-object v1, p1

    .local v1, "savedInstanceState":Landroid/os/Bundle;
    move-object v4, v0

    move-object v5, v1

    invoke-super {v4, v5}, Landroid/support/v7/app/ActionBarActivity;->onCreate(Landroid/os/Bundle;)V

    .line 25
    move-object v4, v0

    const v5, 0x7f030019

    invoke-virtual {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailActivity;->setContentView(I)V

    .line 28
    move-object v4, v0

    invoke-virtual {v4}, Lcom/example/paul/a_sacco/AgencyDetailActivity;->getSupportActionBar()Landroid/support/v7/app/ActionBar;

    move-result-object v4

    const/4 v5, 0x1

    invoke-virtual {v4, v5}, Landroid/support/v7/app/ActionBar;->setDisplayHomeAsUpEnabled(Z)V

    .line 40
    move-object v4, v1

    if-nez v4, :cond_0

    .line 43
    new-instance v4, Landroid/os/Bundle;

    move-object v8, v4

    move-object v4, v8

    move-object v5, v8

    invoke-direct {v5}, Landroid/os/Bundle;-><init>()V

    move-object v2, v4

    .line 44
    .local v2, "arguments":Landroid/os/Bundle;
    move-object v4, v2

    const-string v5, "item_id"

    move-object v6, v0

    invoke-virtual {v6}, Lcom/example/paul/a_sacco/AgencyDetailActivity;->getIntent()Landroid/content/Intent;

    move-result-object v6

    const-string v7, "item_id"

    invoke-virtual {v6, v7}, Landroid/content/Intent;->getStringExtra(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v4, v5, v6}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 46
    new-instance v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object v8, v4

    move-object v4, v8

    move-object v5, v8

    invoke-direct {v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment;-><init>()V

    move-object v3, v4

    .line 47
    .local v3, "fragment":Lcom/example/paul/a_sacco/AgencyDetailFragment;
    move-object v4, v3

    move-object v5, v2

    invoke-virtual {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->setArguments(Landroid/os/Bundle;)V

    .line 48
    move-object v4, v0

    invoke-virtual {v4}, Lcom/example/paul/a_sacco/AgencyDetailActivity;->getSupportFragmentManager()Landroid/support/v4/app/FragmentManager;

    move-result-object v4

    invoke-virtual {v4}, Landroid/support/v4/app/FragmentManager;->beginTransaction()Landroid/support/v4/app/FragmentTransaction;

    move-result-object v4

    const v5, 0x7f09003f

    move-object v6, v3

    invoke-virtual {v4, v5, v6}, Landroid/support/v4/app/FragmentTransaction;->add(ILandroid/support/v4/app/Fragment;)Landroid/support/v4/app/FragmentTransaction;

    move-result-object v4

    invoke-virtual {v4}, Landroid/support/v4/app/FragmentTransaction;->commit()I

    move-result v4

    .line 52
    .end local v2    # "arguments":Landroid/os/Bundle;
    .end local v3    # "fragment":Lcom/example/paul/a_sacco/AgencyDetailFragment;
    :cond_0
    return-void
.end method

.method public onOptionsItemSelected(Landroid/view/MenuItem;)Z
    .locals 9

    .prologue
    .line 56
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailActivity;
    move-object v1, p1

    .local v1, "item":Landroid/view/MenuItem;
    move-object v3, v1

    invoke-interface {v3}, Landroid/view/MenuItem;->getItemId()I

    move-result v3

    move v2, v3

    .line 57
    .local v2, "id":I
    move v3, v2

    const v4, 0x102002c

    if-ne v3, v4, :cond_0

    .line 65
    move-object v3, v0

    new-instance v4, Landroid/content/Intent;

    move-object v8, v4

    move-object v4, v8

    move-object v5, v8

    move-object v6, v0

    const-class v7, Lcom/example/paul/a_sacco/AgencyListActivity;

    invoke-direct {v5, v6, v7}, Landroid/content/Intent;-><init>(Landroid/content/Context;Ljava/lang/Class;)V

    invoke-static {v3, v4}, Landroid/support/v4/app/NavUtils;->navigateUpTo(Landroid/app/Activity;Landroid/content/Intent;)V

    .line 66
    const/4 v3, 0x1

    move v0, v3

    .line 68
    .end local v0    # "this":Lcom/example/paul/a_sacco/AgencyDetailActivity;
    :goto_0
    return v0

    .restart local v0    # "this":Lcom/example/paul/a_sacco/AgencyDetailActivity;
    :cond_0
    move-object v3, v0

    move-object v4, v1

    invoke-super {v3, v4}, Landroid/support/v7/app/ActionBarActivity;->onOptionsItemSelected(Landroid/view/MenuItem;)Z

    move-result v3

    move v0, v3

    goto :goto_0
.end method
