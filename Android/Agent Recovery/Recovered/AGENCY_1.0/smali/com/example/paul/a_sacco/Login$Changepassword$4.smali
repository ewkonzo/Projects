.class Lcom/example/paul/a_sacco/Login$Changepassword$4;
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

.field final synthetic val$pindialog:Landroid/app/AlertDialog;


# direct methods
.method constructor <init>(Lcom/example/paul/a_sacco/Login$Changepassword;Landroid/app/AlertDialog;)V
    .locals 5

    .prologue
    .line 317
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Login$Changepassword$4;
    move-object v1, p1

    move-object v2, p2

    move-object v3, v0

    move-object v4, v1

    iput-object v4, v3, Lcom/example/paul/a_sacco/Login$Changepassword$4;->this$1:Lcom/example/paul/a_sacco/Login$Changepassword;

    move-object v3, v0

    move-object v4, v2

    iput-object v4, v3, Lcom/example/paul/a_sacco/Login$Changepassword$4;->val$pindialog:Landroid/app/AlertDialog;

    move-object v3, v0

    invoke-direct {v3}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onClick(Landroid/view/View;)V
    .locals 4

    .prologue
    .line 320
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Login$Changepassword$4;
    move-object v1, p1

    .local v1, "v":Landroid/view/View;
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/Login$Changepassword$4;->this$1:Lcom/example/paul/a_sacco/Login$Changepassword;

    const/4 v3, 0x0

    iput-boolean v3, v2, Lcom/example/paul/a_sacco/Login$Changepassword;->changed:Z

    .line 321
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/Login$Changepassword$4;->val$pindialog:Landroid/app/AlertDialog;

    invoke-virtual {v2}, Landroid/app/AlertDialog;->dismiss()V

    .line 323
    return-void
.end method
