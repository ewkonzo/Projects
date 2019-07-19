.class Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;
.super Ljava/lang/Object;
.source "AgencyListActivity.java"

# interfaces
.implements Landroid/view/View$OnClickListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword;->changepin(Landroid/content/Context;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$1:Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword;

.field final synthetic val$c:Landroid/content/Context;

.field final synthetic val$conpin:Landroid/widget/EditText;

.field final synthetic val$cpin:Landroid/widget/EditText;

.field final synthetic val$npin:Landroid/widget/EditText;

.field final synthetic val$pindialog:Landroid/app/AlertDialog;


# direct methods
.method constructor <init>(Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword;Landroid/widget/EditText;Landroid/widget/EditText;Landroid/widget/EditText;Landroid/content/Context;Landroid/app/AlertDialog;)V
    .locals 9

    .prologue
    .line 207
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;
    move-object v1, p1

    move-object v2, p2

    move-object v3, p3

    move-object v4, p4

    move-object v5, p5

    move-object v6, p6

    move-object v7, v0

    move-object v8, v1

    iput-object v8, v7, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->this$1:Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword;

    move-object v7, v0

    move-object v8, v2

    iput-object v8, v7, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->val$cpin:Landroid/widget/EditText;

    move-object v7, v0

    move-object v8, v3

    iput-object v8, v7, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->val$npin:Landroid/widget/EditText;

    move-object v7, v0

    move-object v8, v4

    iput-object v8, v7, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->val$conpin:Landroid/widget/EditText;

    move-object v7, v0

    move-object v8, v5

    iput-object v8, v7, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->val$c:Landroid/content/Context;

    move-object v7, v0

    move-object v8, v6

    iput-object v8, v7, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->val$pindialog:Landroid/app/AlertDialog;

    move-object v7, v0

    invoke-direct {v7}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onClick(Landroid/view/View;)V
    .locals 11

    .prologue
    .line 210
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;
    move-object v1, p1

    .local v1, "v":Landroid/view/View;
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->val$cpin:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v5

    move-object v2, v5

    .line 211
    .local v2, "pinc":Ljava/lang/String;
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->val$npin:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v5

    move-object v3, v5

    .line 212
    .local v3, "pinn":Ljava/lang/String;
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->val$conpin:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v5

    move-object v4, v5

    .line 213
    .local v4, "pincon":Ljava/lang/String;
    move-object v5, v2

    invoke-static {v5}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v5

    if-eqz v5, :cond_0

    .line 214
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->val$cpin:Landroid/widget/EditText;

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->val$c:Landroid/content/Context;

    const v7, 0x7f0c001b

    invoke-virtual {v6, v7}, Landroid/content/Context;->getString(I)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 215
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->val$cpin:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->requestFocus()Z

    move-result v5

    .line 216
    .line 243
    :goto_0
    return-void

    .line 218
    :cond_0
    move-object v5, v3

    invoke-static {v5}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v5

    if-eqz v5, :cond_1

    .line 219
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->val$npin:Landroid/widget/EditText;

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->val$c:Landroid/content/Context;

    const v7, 0x7f0c001b

    invoke-virtual {v6, v7}, Landroid/content/Context;->getString(I)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 220
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->val$npin:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->requestFocus()Z

    move-result v5

    .line 221
    goto :goto_0

    .line 223
    :cond_1
    move-object v5, v4

    invoke-static {v5}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v5

    if-eqz v5, :cond_2

    .line 224
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->val$conpin:Landroid/widget/EditText;

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->val$c:Landroid/content/Context;

    const v7, 0x7f0c001b

    invoke-virtual {v6, v7}, Landroid/content/Context;->getString(I)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 225
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->val$conpin:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->requestFocus()Z

    move-result v5

    .line 226
    goto :goto_0

    .line 228
    :cond_2
    move-object v5, v2

    sget-object v6, Lcom/example/paul/a_sacco/Login;->agent:Lcom/example/paul/a_sacco/Agent;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Agent;->pin:Ljava/lang/String;

    invoke-virtual {v5, v6}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v5

    if-nez v5, :cond_3

    .line 229
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->val$cpin:Landroid/widget/EditText;

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->val$c:Landroid/content/Context;

    const v7, 0x7f0c001a

    invoke-virtual {v6, v7}, Landroid/content/Context;->getString(I)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 230
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->val$cpin:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->requestFocus()Z

    move-result v5

    .line 231
    goto :goto_0

    .line 233
    :cond_3
    move-object v5, v3

    move-object v6, v4

    invoke-virtual {v5, v6}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v5

    if-nez v5, :cond_4

    .line 234
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->val$conpin:Landroid/widget/EditText;

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->val$c:Landroid/content/Context;

    const v7, 0x7f0c0019

    invoke-virtual {v6, v7}, Landroid/content/Context;->getString(I)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 235
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->val$conpin:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->requestFocus()Z

    move-result v5

    .line 236
    goto/16 :goto_0

    .line 238
    :cond_4
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->this$1:Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword;

    const/4 v6, 0x1

    iput-boolean v6, v5, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword;->changed:Z

    .line 239
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->this$1:Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword;

    move-object v6, v3

    iput-object v6, v5, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword;->New_password:Ljava/lang/String;

    .line 240
    sget-object v5, Lcom/example/paul/a_sacco/Login;->agent:Lcom/example/paul/a_sacco/Agent;

    move-object v6, v3

    iput-object v6, v5, Lcom/example/paul/a_sacco/Agent;->new_pin:Ljava/lang/String;

    .line 241
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->val$pindialog:Landroid/app/AlertDialog;

    invoke-virtual {v5}, Landroid/app/AlertDialog;->dismiss()V

    .line 242
    new-instance v5, Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;

    move-object v10, v5

    move-object v5, v10

    move-object v6, v10

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;->this$1:Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword;

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword;->this$0:Lcom/example/paul/a_sacco/AgencyListActivity;

    sget-object v8, Lcom/example/paul/a_sacco/Login;->agent:Lcom/example/paul/a_sacco/Agent;

    invoke-direct {v6, v7, v8}, Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;-><init>(Lcom/example/paul/a_sacco/AgencyListActivity;Lcom/example/paul/a_sacco/Agent;)V

    const/4 v6, 0x1

    new-array v6, v6, [Ljava/lang/Void;

    move-object v10, v6

    move-object v6, v10

    move-object v7, v10

    const/4 v8, 0x0

    const/4 v9, 0x0

    check-cast v9, Ljava/lang/Void;

    aput-object v9, v7, v8

    invoke-virtual {v5, v6}, Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;->execute([Ljava/lang/Object;)Landroid/os/AsyncTask;

    move-result-object v5

    .line 243
    goto/16 :goto_0
.end method
