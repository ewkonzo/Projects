.class public Lcom/example/paul/a_sacco/Loanrepayment;
.super Landroid/app/Activity;
.source "Loanrepayment.java"


# direct methods
.method public constructor <init>()V
    .locals 2

    .prologue
    .line 7
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Loanrepayment;
    move-object v1, v0

    invoke-direct {v1}, Landroid/app/Activity;-><init>()V

    return-void
.end method


# virtual methods
.method protected onCreate(Landroid/os/Bundle;)V
    .locals 4

    .prologue
    .line 11
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Loanrepayment;
    move-object v1, p1

    .local v1, "savedInstanceState":Landroid/os/Bundle;
    move-object v2, v0

    move-object v3, v1

    invoke-super {v2, v3}, Landroid/app/Activity;->onCreate(Landroid/os/Bundle;)V

    .line 12
    move-object v2, v0

    const v3, 0x7f03001f

    invoke-virtual {v2, v3}, Lcom/example/paul/a_sacco/Loanrepayment;->setContentView(I)V

    .line 13
    return-void
.end method

.method public onCreateOptionsMenu(Landroid/view/Menu;)Z
    .locals 5

    .prologue
    .line 17
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Loanrepayment;
    move-object v1, p1

    .local v1, "menu":Landroid/view/Menu;
    move-object v2, v0

    invoke-virtual {v2}, Lcom/example/paul/a_sacco/Loanrepayment;->getMenuInflater()Landroid/view/MenuInflater;

    move-result-object v2

    const v3, 0x7f0e0002

    move-object v4, v1

    invoke-virtual {v2, v3, v4}, Landroid/view/MenuInflater;->inflate(ILandroid/view/Menu;)V

    .line 18
    const/4 v2, 0x1

    move v0, v2

    .end local v0    # "this":Lcom/example/paul/a_sacco/Loanrepayment;
    return v0
.end method

.method public onOptionsItemSelected(Landroid/view/MenuItem;)Z
    .locals 5

    .prologue
    .line 25
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Loanrepayment;
    move-object v1, p1

    .local v1, "item":Landroid/view/MenuItem;
    move-object v3, v1

    invoke-interface {v3}, Landroid/view/MenuItem;->getItemId()I

    move-result v3

    move v2, v3

    .line 26
    .local v2, "id":I
    move v3, v2

    const v4, 0x7f090080

    if-ne v3, v4, :cond_0

    .line 27
    const/4 v3, 0x1

    move v0, v3

    .line 29
    .end local v0    # "this":Lcom/example/paul/a_sacco/Loanrepayment;
    :goto_0
    return v0

    .restart local v0    # "this":Lcom/example/paul/a_sacco/Loanrepayment;
    :cond_0
    move-object v3, v0

    move-object v4, v1

    invoke-super {v3, v4}, Landroid/app/Activity;->onOptionsItemSelected(Landroid/view/MenuItem;)Z

    move-result v3

    move v0, v3

    goto :goto_0
.end method
