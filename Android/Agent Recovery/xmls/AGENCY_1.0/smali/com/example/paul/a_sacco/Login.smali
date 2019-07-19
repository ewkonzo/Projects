.class public Lcom/example/paul/a_sacco/Login;
.super Landroid/support/v7/app/ActionBarActivity;
.source "Login.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/example/paul/a_sacco/Login$Changepassword;,
        Lcom/example/paul/a_sacco/Login$ChangepassTask;,
        Lcom/example/paul/a_sacco/Login$UserLoginTask;
    }
.end annotation


# static fields
.field public static agent:Lcom/example/paul/a_sacco/Agent;


# instance fields
.field agentcode:Landroid/widget/EditText;

.field agentpin:Landroid/widget/EditText;

.field cancel:Landroid/widget/Button;

.field intent:Landroid/content/Intent;

.field login:Landroid/widget/Button;


# direct methods
.method public constructor <init>()V
    .locals 3

    .prologue
    .line 31
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Login;
    move-object v1, v0

    invoke-direct {v1}, Landroid/support/v7/app/ActionBarActivity;-><init>()V

    .line 32
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Login;->agentcode:Landroid/widget/EditText;

    .line 33
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Login;->agentpin:Landroid/widget/EditText;

    .line 34
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Login;->login:Landroid/widget/Button;

    .line 35
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Login;->cancel:Landroid/widget/Button;

    .line 37
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Login;->intent:Landroid/content/Intent;

    .line 251
    return-void
.end method

.method private isPasswordValid(Ljava/lang/String;)Z
    .locals 4

    .prologue
    .line 96
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Login;
    move-object v1, p1

    .local v1, "password":Ljava/lang/String;
    move-object v2, v1

    invoke-virtual {v2}, Ljava/lang/String;->length()I

    move-result v2

    const/4 v3, 0x3

    if-le v2, v3, :cond_0

    const/4 v2, 0x1

    :goto_0
    move v0, v2

    .end local v0    # "this":Lcom/example/paul/a_sacco/Login;
    return v0

    .restart local v0    # "this":Lcom/example/paul/a_sacco/Login;
    :cond_0
    const/4 v2, 0x0

    goto :goto_0
.end method


# virtual methods
.method public attemptLogin()V
    .locals 10

    .prologue
    .line 63
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Login;
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/Login;->agentcode:Landroid/widget/EditText;

    const/4 v5, 0x0

    invoke-virtual {v4, v5}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 64
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/Login;->agentpin:Landroid/widget/EditText;

    const/4 v5, 0x0

    invoke-virtual {v4, v5}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 67
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/Login;->agentcode:Landroid/widget/EditText;

    invoke-virtual {v4}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v4

    move-object v1, v4

    .line 68
    .local v1, "email":Ljava/lang/String;
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/Login;->agentpin:Landroid/widget/EditText;

    invoke-virtual {v4}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v4

    move-object v2, v4

    .line 70
    .local v2, "password":Ljava/lang/String;
    const/4 v4, 0x0

    move v3, v4

    .line 74
    .local v3, "cancel":Z
    move-object v4, v2

    invoke-static {v4}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v4

    if-nez v4, :cond_0

    move-object v4, v0

    move-object v5, v2

    invoke-direct {v4, v5}, Lcom/example/paul/a_sacco/Login;->isPasswordValid(Ljava/lang/String;)Z

    move-result v4

    if-nez v4, :cond_0

    .line 75
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/Login;->agentpin:Landroid/widget/EditText;

    move-object v5, v0

    const v6, 0x7f0c001e

    invoke-virtual {v5, v6}, Lcom/example/paul/a_sacco/Login;->getString(I)Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 76
    const/4 v4, 0x1

    move v3, v4

    .line 79
    :cond_0
    move-object v4, v1

    invoke-static {v4}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v4

    if-eqz v4, :cond_1

    .line 80
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/Login;->agentcode:Landroid/widget/EditText;

    move-object v5, v0

    const v6, 0x7f0c001b

    invoke-virtual {v5, v6}, Lcom/example/paul/a_sacco/Login;->getString(I)Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 81
    const/4 v4, 0x1

    move v3, v4

    .line 84
    :cond_1
    move v4, v3

    if-eqz v4, :cond_2

    .line 92
    :goto_0
    return-void

    .line 87
    :cond_2
    sget-object v4, Lcom/example/paul/a_sacco/Login;->agent:Lcom/example/paul/a_sacco/Agent;

    move-object v5, v1

    iput-object v5, v4, Lcom/example/paul/a_sacco/Agent;->agent_code:Ljava/lang/String;

    .line 88
    sget-object v4, Lcom/example/paul/a_sacco/Login;->agent:Lcom/example/paul/a_sacco/Agent;

    move-object v5, v2

    iput-object v5, v4, Lcom/example/paul/a_sacco/Agent;->pin:Ljava/lang/String;

    .line 90
    new-instance v4, Lcom/example/paul/a_sacco/Login$UserLoginTask;

    move-object v9, v4

    move-object v4, v9

    move-object v5, v9

    move-object v6, v0

    sget-object v7, Lcom/example/paul/a_sacco/Login;->agent:Lcom/example/paul/a_sacco/Agent;

    invoke-direct {v5, v6, v7}, Lcom/example/paul/a_sacco/Login$UserLoginTask;-><init>(Lcom/example/paul/a_sacco/Login;Lcom/example/paul/a_sacco/Agent;)V

    const/4 v5, 0x1

    new-array v5, v5, [Ljava/lang/Void;

    move-object v9, v5

    move-object v5, v9

    move-object v6, v9

    const/4 v7, 0x0

    const/4 v8, 0x0

    check-cast v8, Ljava/lang/Void;

    aput-object v8, v6, v7

    invoke-virtual {v4, v5}, Lcom/example/paul/a_sacco/Login$UserLoginTask;->execute([Ljava/lang/Object;)Landroid/os/AsyncTask;

    move-result-object v4

    goto :goto_0
.end method

.method protected onCreate(Landroid/os/Bundle;)V
    .locals 9

    .prologue
    .line 40
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Login;
    move-object v1, p1

    .local v1, "savedInstanceState":Landroid/os/Bundle;
    move-object v4, v0

    move-object v5, v1

    invoke-super {v4, v5}, Landroid/support/v7/app/ActionBarActivity;->onCreate(Landroid/os/Bundle;)V

    .line 41
    move-object v4, v0

    const v5, 0x7f030020

    invoke-virtual {v4, v5}, Lcom/example/paul/a_sacco/Login;->setContentView(I)V

    .line 42
    move-object v4, v0

    move-object v5, v0

    const v6, 0x7f090064

    invoke-virtual {v5, v6}, Lcom/example/paul/a_sacco/Login;->findViewById(I)Landroid/view/View;

    move-result-object v5

    check-cast v5, Landroid/widget/EditText;

    iput-object v5, v4, Lcom/example/paul/a_sacco/Login;->agentcode:Landroid/widget/EditText;

    .line 43
    move-object v4, v0

    move-object v5, v0

    const v6, 0x7f090066

    invoke-virtual {v5, v6}, Lcom/example/paul/a_sacco/Login;->findViewById(I)Landroid/view/View;

    move-result-object v5

    check-cast v5, Landroid/widget/EditText;

    iput-object v5, v4, Lcom/example/paul/a_sacco/Login;->agentpin:Landroid/widget/EditText;

    .line 44
    move-object v4, v0

    move-object v5, v0

    const v6, 0x7f090067

    invoke-virtual {v5, v6}, Lcom/example/paul/a_sacco/Login;->findViewById(I)Landroid/view/View;

    move-result-object v5

    check-cast v5, Landroid/widget/Button;

    iput-object v5, v4, Lcom/example/paul/a_sacco/Login;->login:Landroid/widget/Button;

    .line 45
    move-object v4, v0

    move-object v5, v0

    const v6, 0x7f09004b

    invoke-virtual {v5, v6}, Lcom/example/paul/a_sacco/Login;->findViewById(I)Landroid/view/View;

    move-result-object v5

    check-cast v5, Landroid/widget/Button;

    iput-object v5, v4, Lcom/example/paul/a_sacco/Login;->cancel:Landroid/widget/Button;

    .line 46
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/Login;->login:Landroid/widget/Button;

    new-instance v5, Lcom/example/paul/a_sacco/Login$1;

    move-object v8, v5

    move-object v5, v8

    move-object v6, v8

    move-object v7, v0

    invoke-direct {v6, v7}, Lcom/example/paul/a_sacco/Login$1;-><init>(Lcom/example/paul/a_sacco/Login;)V

    invoke-virtual {v4, v5}, Landroid/widget/Button;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    .line 52
    new-instance v4, Lcom/example/paul/a_sacco/Agent;

    move-object v8, v4

    move-object v4, v8

    move-object v5, v8

    invoke-direct {v5}, Lcom/example/paul/a_sacco/Agent;-><init>()V

    sput-object v4, Lcom/example/paul/a_sacco/Login;->agent:Lcom/example/paul/a_sacco/Agent;

    .line 53
    move-object v4, v0

    invoke-static {v4}, Landroid/preference/PreferenceManager;->getDefaultSharedPreferences(Landroid/content/Context;)Landroid/content/SharedPreferences;

    move-result-object v4

    move-object v2, v4

    .line 54
    .local v2, "prefs":Landroid/content/SharedPreferences;
    move-object v4, v2

    const-string v5, "Agency_Code"

    const-string v6, ""

    invoke-interface {v4, v5, v6}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    move-object v3, v4

    .line 55
    .local v3, "st":Ljava/lang/String;
    move-object v4, v3

    const-string v5, ""

    invoke-virtual {v4, v5}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-nez v4, :cond_0

    .line 56
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/Login;->agentcode:Landroid/widget/EditText;

    move-object v5, v3

    invoke-virtual {v4, v5}, Landroid/widget/EditText;->setText(Ljava/lang/CharSequence;)V

    .line 57
    :cond_0
    return-void
.end method

.method public onCreateOptionsMenu(Landroid/view/Menu;)Z
    .locals 5

    .prologue
    .line 102
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Login;
    move-object v1, p1

    .local v1, "menu":Landroid/view/Menu;
    move-object v2, v0

    invoke-virtual {v2}, Lcom/example/paul/a_sacco/Login;->getMenuInflater()Landroid/view/MenuInflater;

    move-result-object v2

    const v3, 0x7f0e0003

    move-object v4, v1

    invoke-virtual {v2, v3, v4}, Landroid/view/MenuInflater;->inflate(ILandroid/view/Menu;)V

    .line 103
    const/4 v2, 0x1

    move v0, v2

    .end local v0    # "this":Lcom/example/paul/a_sacco/Login;
    return v0
.end method

.method public onOptionsItemSelected(Landroid/view/MenuItem;)Z
    .locals 9

    .prologue
    .line 111
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Login;
    move-object v1, p1

    .local v1, "item":Landroid/view/MenuItem;
    move-object v4, v1

    invoke-interface {v4}, Landroid/view/MenuItem;->getItemId()I

    move-result v4

    move v2, v4

    .line 112
    .local v2, "id":I
    move v4, v2

    const v5, 0x7f090080

    if-ne v4, v5, :cond_0

    .line 113
    new-instance v4, Landroid/content/Intent;

    move-object v8, v4

    move-object v4, v8

    move-object v5, v8

    move-object v6, v0

    invoke-virtual {v6}, Lcom/example/paul/a_sacco/Login;->getApplicationContext()Landroid/content/Context;

    move-result-object v6

    const-class v7, Lcom/example/paul/a_sacco/SettingsActivity;

    invoke-direct {v5, v6, v7}, Landroid/content/Intent;-><init>(Landroid/content/Context;Ljava/lang/Class;)V

    move-object v3, v4

    .line 114
    .local v3, "intent":Landroid/content/Intent;
    move-object v4, v0

    move-object v5, v3

    invoke-virtual {v4, v5}, Lcom/example/paul/a_sacco/Login;->startActivity(Landroid/content/Intent;)V

    .line 115
    const/4 v4, 0x1

    move v0, v4

    .line 118
    .end local v0    # "this":Lcom/example/paul/a_sacco/Login;
    .end local v3    # "intent":Landroid/content/Intent;
    :goto_0
    return v0

    .restart local v0    # "this":Lcom/example/paul/a_sacco/Login;
    :cond_0
    move-object v4, v0

    move-object v5, v1

    invoke-super {v4, v5}, Landroid/support/v7/app/ActionBarActivity;->onOptionsItemSelected(Landroid/view/MenuItem;)Z

    move-result v4

    move v0, v4

    goto :goto_0
.end method
