.class Lcom/example/paul/a_sacco/Login$Changepassword$3;
.super Ljava/lang/Object;
.source "Login.java"

# interfaces
.implements Landroid/view/View$OnClickListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/example/paul/a_sacco/Login$Changepassword;->changepin(Landroid/content/Context;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$1:Lcom/example/paul/a_sacco/Login$Changepassword;

.field final synthetic val$c:Landroid/content/Context;

.field final synthetic val$conpin:Landroid/widget/EditText;

.field final synthetic val$cpin:Landroid/widget/EditText;

.field final synthetic val$npin:Landroid/widget/EditText;

.field final synthetic val$pindialog:Landroid/app/AlertDialog;


# direct methods
.method constructor <init>(Lcom/example/paul/a_sacco/Login$Changepassword;Landroid/widget/EditText;Landroid/widget/EditText;Landroid/widget/EditText;Landroid/content/Context;Landroid/app/AlertDialog;)V
    .locals 9

    .prologue
    .line 276
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Login$Changepassword$3;
    move-object v1, p1

    move-object v2, p2

    move-object v3, p3

    move-object v4, p4

    move-object v5, p5

    move-object v6, p6

    move-object v7, v0

    move-object v8, v1

    iput-object v8, v7, Lcom/example/paul/a_sacco/Login$Changepassword$3;->this$1:Lcom/example/paul/a_sacco/Login$Changepassword;

    move-object v7, v0

    move-object v8, v2

    iput-object v8, v7, Lcom/example/paul/a_sacco/Login$Changepassword$3;->val$cpin:Landroid/widget/EditText;

    move-object v7, v0

    move-object v8, v3

    iput-object v8, v7, Lcom/example/paul/a_sacco/Login$Changepassword$3;->val$npin:Landroid/widget/EditText;

    move-object v7, v0

    move-object v8, v4

    iput-object v8, v7, Lcom/example/paul/a_sacco/Login$Changepassword$3;->val$conpin:Landroid/widget/EditText;

    move-object v7, v0

    move-object v8, v5

    iput-object v8, v7, Lcom/example/paul/a_sacco/Login$Changepassword$3;->val$c:Landroid/content/Context;

    move-object v7, v0

    move-object v8, v6

    iput-object v8, v7, Lcom/example/paul/a_sacco/Login$Changepassword$3;->val$pindialog:Landroid/app/AlertDialog;

    move-object v7, v0

    invoke-direct {v7}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onClick(Landroid/view/View;)V
    .locals 11

    .prologue
    .line 279
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Login$Changepassword$3;
    move-object v1, p1

    .local v1, "v":Landroid/view/View;
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/Login$Changepassword$3;->val$cpin:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v5

    move-object v2, v5

    .line 280
    .local v2, "pinc":Ljava/lang/String;
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/Login$Changepassword$3;->val$npin:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v5

    move-object v3, v5

    .line 281
    .local v3, "pinn":Ljava/lang/String;
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/Login$Changepassword$3;->val$conpin:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v5

    move-object v4, v5

    .line 282
    .local v4, "pincon":Ljava/lang/String;
    move-object v5, v2

    invoke-static {v5}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v5

    if-eqz v5, :cond_0

    .line 283
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/Login$Changepassword$3;->val$cpin:Landroid/widget/EditText;

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/Login$Changepassword$3;->val$c:Landroid/content/Context;

    const v7, 0x7f0c001b

    invoke-virtual {v6, v7}, Landroid/content/Context;->getString(I)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 284
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/Login$Changepassword$3;->val$cpin:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->requestFocus()Z

    move-result v5

    .line 285
    .line 315
    :goto_0
    return-void

    .line 287
    :cond_0
    move-object v5, v3

    invoke-static {v5}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v5

    if-eqz v5, :cond_1

    .line 288
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/Login$Changepassword$3;->val$npin:Landroid/widget/EditText;

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/Login$Changepassword$3;->val$c:Landroid/content/Context;

    const v7, 0x7f0c001b

    invoke-virtual {v6, v7}, Landroid/content/Context;->getString(I)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 289
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/Login$Changepassword$3;->val$npin:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->requestFocus()Z

    move-result v5

    .line 290
    goto :goto_0

    .line 292
    :cond_1
    move-object v5, v4

    invoke-static {v5}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v5

    if-eqz v5, :cond_2

    .line 293
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/Login$Changepassword$3;->val$conpin:Landroid/widget/EditText;

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/Login$Changepassword$3;->val$c:Landroid/content/Context;

    const v7, 0x7f0c001b

    invoke-virtual {v6, v7}, Landroid/content/Context;->getString(I)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 294
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/Login$Changepassword$3;->val$conpin:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->requestFocus()Z

    move-result v5

    .line 295
    goto :goto_0

    .line 297
    :cond_2
    move-object v5, v2

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/Login$Changepassword$3;->this$1:Lcom/example/paul/a_sacco/Login$Changepassword;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Login$Changepassword;->Old_password:Ljava/lang/String;

    invoke-virtual {v5, v6}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v5

    if-nez v5, :cond_3

    .line 298
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/Login$Changepassword$3;->val$cpin:Landroid/widget/EditText;

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/Login$Changepassword$3;->val$c:Landroid/content/Context;

    const v7, 0x7f0c001a

    invoke-virtual {v6, v7}, Landroid/content/Context;->getString(I)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 299
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/Login$Changepassword$3;->val$cpin:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->requestFocus()Z

    move-result v5

    .line 300
    goto :goto_0

    .line 302
    :cond_3
    move-object v5, v3

    move-object v6, v4

    invoke-virtual {v5, v6}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v5

    if-nez v5, :cond_4

    .line 303
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/Login$Changepassword$3;->val$conpin:Landroid/widget/EditText;

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/Login$Changepassword$3;->val$c:Landroid/content/Context;

    const v7, 0x7f0c0019

    invoke-virtual {v6, v7}, Landroid/content/Context;->getString(I)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 304
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/Login$Changepassword$3;->val$conpin:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->requestFocus()Z

    move-result v5

    .line 305
    goto/16 :goto_0

    .line 307
    :cond_4
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/Login$Changepassword$3;->this$1:Lcom/example/paul/a_sacco/Login$Changepassword;

    const/4 v6, 0x1

    iput-boolean v6, v5, Lcom/example/paul/a_sacco/Login$Changepassword;->changed:Z

    .line 308
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/Login$Changepassword$3;->this$1:Lcom/example/paul/a_sacco/Login$Changepassword;

    move-object v6, v3

    iput-object v6, v5, Lcom/example/paul/a_sacco/Login$Changepassword;->New_password:Ljava/lang/String;

    .line 309
    sget-object v5, Lcom/example/paul/a_sacco/Login;->agent:Lcom/example/paul/a_sacco/Agent;

    move-object v6, v3

    iput-object v6, v5, Lcom/example/paul/a_sacco/Agent;->new_pin:Ljava/lang/String;

    .line 310
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/Login$Changepassword$3;->val$pindialog:Landroid/app/AlertDialog;

    invoke-virtual {v5}, Landroid/app/AlertDialog;->dismiss()V

    .line 311
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/Login$Changepassword$3;->this$1:Lcom/example/paul/a_sacco/Login$Changepassword;

    iget-object v5, v5, Lcom/example/paul/a_sacco/Login$Changepassword;->this$0:Lcom/example/paul/a_sacco/Login;

    iget-object v5, v5, Lcom/example/paul/a_sacco/Login;->intent:Landroid/content/Intent;

    if-eqz v5, :cond_5

    .line 312
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/Login$Changepassword$3;->this$1:Lcom/example/paul/a_sacco/Login$Changepassword;

    iget-object v5, v5, Lcom/example/paul/a_sacco/Login$Changepassword;->this$0:Lcom/example/paul/a_sacco/Login;

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/Login$Changepassword$3;->this$1:Lcom/example/paul/a_sacco/Login$Changepassword;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Login$Changepassword;->this$0:Lcom/example/paul/a_sacco/Login;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Login;->intent:Landroid/content/Intent;

    invoke-virtual {v5, v6}, Lcom/example/paul/a_sacco/Login;->startActivity(Landroid/content/Intent;)V

    .line 314
    :cond_5
    new-instance v5, Lcom/example/paul/a_sacco/Login$ChangepassTask;

    move-object v10, v5

    move-object v5, v10

    move-object v6, v10

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/Login$Changepassword$3;->this$1:Lcom/example/paul/a_sacco/Login$Changepassword;

    iget-object v7, v7, Lcom/example/paul/a_sacco/Login$Changepassword;->this$0:Lcom/example/paul/a_sacco/Login;

    sget-object v8, Lcom/example/paul/a_sacco/Login;->agent:Lcom/example/paul/a_sacco/Agent;

    invoke-direct {v6, v7, v8}, Lcom/example/paul/a_sacco/Login$ChangepassTask;-><init>(Lcom/example/paul/a_sacco/Login;Lcom/example/paul/a_sacco/Agent;)V

    const/4 v6, 0x1

    new-array v6, v6, [Ljava/lang/Void;

    move-object v10, v6

    move-object v6, v10

    move-object v7, v10

    const/4 v8, 0x0

    const/4 v9, 0x0

    check-cast v9, Ljava/lang/Void;

    aput-object v9, v7, v8

    invoke-virtual {v5, v6}, Lcom/example/paul/a_sacco/Login$ChangepassTask;->execute([Ljava/lang/Object;)Landroid/os/AsyncTask;

    move-result-object v5

    .line 315
    goto/16 :goto_0
.end method
