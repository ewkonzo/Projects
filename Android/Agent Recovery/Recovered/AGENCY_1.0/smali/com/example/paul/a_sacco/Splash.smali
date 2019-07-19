.class public Lcom/example/paul/a_sacco/Splash;
.super Landroid/support/v7/app/ActionBarActivity;
.source "Splash.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/example/paul/a_sacco/Splash$GetDataTask;
    }
.end annotation


# instance fields
.field db:Lcom/example/paul/a_sacco/Database;


# direct methods
.method public constructor <init>()V
    .locals 3

    .prologue
    .line 18
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Splash;
    move-object v1, v0

    invoke-direct {v1}, Landroid/support/v7/app/ActionBarActivity;-><init>()V

    .line 19
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Splash;->db:Lcom/example/paul/a_sacco/Database;

    .line 44
    return-void
.end method


# virtual methods
.method protected onCreate(Landroid/os/Bundle;)V
    .locals 7

    .prologue
    .line 22
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Splash;
    move-object v1, p1

    .local v1, "savedInstanceState":Landroid/os/Bundle;
    move-object v2, v0

    move-object v3, v1

    invoke-super {v2, v3}, Landroid/support/v7/app/ActionBarActivity;->onCreate(Landroid/os/Bundle;)V

    .line 23
    move-object v2, v0

    const v3, 0x7f030025

    invoke-virtual {v2, v3}, Lcom/example/paul/a_sacco/Splash;->setContentView(I)V

    .line 24
    move-object v2, v0

    new-instance v3, Lcom/example/paul/a_sacco/Database;

    move-object v6, v3

    move-object v3, v6

    move-object v4, v6

    move-object v5, v0

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/Database;-><init>(Landroid/content/Context;)V

    iput-object v3, v2, Lcom/example/paul/a_sacco/Splash;->db:Lcom/example/paul/a_sacco/Database;

    .line 25
    new-instance v2, Lcom/example/paul/a_sacco/Splash$GetDataTask;

    move-object v6, v2

    move-object v2, v6

    move-object v3, v6

    move-object v4, v0

    invoke-direct {v3, v4}, Lcom/example/paul/a_sacco/Splash$GetDataTask;-><init>(Lcom/example/paul/a_sacco/Splash;)V

    const/4 v3, 0x0

    new-array v3, v3, [Ljava/lang/Void;

    invoke-virtual {v2, v3}, Lcom/example/paul/a_sacco/Splash$GetDataTask;->execute([Ljava/lang/Object;)Landroid/os/AsyncTask;

    move-result-object v2

    .line 26
    return-void
.end method

.method public onCreateOptionsMenu(Landroid/view/Menu;)Z
    .locals 5

    .prologue
    .line 30
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Splash;
    move-object v1, p1

    .local v1, "menu":Landroid/view/Menu;
    move-object v2, v0

    invoke-virtual {v2}, Lcom/example/paul/a_sacco/Splash;->getMenuInflater()Landroid/view/MenuInflater;

    move-result-object v2

    const v3, 0x7f0e0007

    move-object v4, v1

    invoke-virtual {v2, v3, v4}, Landroid/view/MenuInflater;->inflate(ILandroid/view/Menu;)V

    .line 31
    const/4 v2, 0x1

    move v0, v2

    .end local v0    # "this":Lcom/example/paul/a_sacco/Splash;
    return v0
.end method

.method public onOptionsItemSelected(Landroid/view/MenuItem;)Z
    .locals 5

    .prologue
    .line 38
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Splash;
    move-object v1, p1

    .local v1, "item":Landroid/view/MenuItem;
    move-object v3, v1

    invoke-interface {v3}, Landroid/view/MenuItem;->getItemId()I

    move-result v3

    move v2, v3

    .line 39
    .local v2, "id":I
    move v3, v2

    const v4, 0x7f090080

    if-ne v3, v4, :cond_0

    .line 40
    const/4 v3, 0x1

    move v0, v3

    .line 42
    .end local v0    # "this":Lcom/example/paul/a_sacco/Splash;
    :goto_0
    return v0

    .restart local v0    # "this":Lcom/example/paul/a_sacco/Splash;
    :cond_0
    move-object v3, v0

    move-object v4, v1

    invoke-super {v3, v4}, Landroid/support/v7/app/ActionBarActivity;->onOptionsItemSelected(Landroid/view/MenuItem;)Z

    move-result v3

    move v0, v3

    goto :goto_0
.end method
