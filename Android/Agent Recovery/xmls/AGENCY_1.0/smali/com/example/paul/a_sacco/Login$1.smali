.class Lcom/example/paul/a_sacco/Login$1;
.super Ljava/lang/Object;
.source "Login.java"

# interfaces
.implements Landroid/view/View$OnClickListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/example/paul/a_sacco/Login;->onCreate(Landroid/os/Bundle;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/example/paul/a_sacco/Login;


# direct methods
.method constructor <init>(Lcom/example/paul/a_sacco/Login;)V
    .locals 4

    .prologue
    .line 46
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Login$1;
    move-object v1, p1

    move-object v2, v0

    move-object v3, v1

    iput-object v3, v2, Lcom/example/paul/a_sacco/Login$1;->this$0:Lcom/example/paul/a_sacco/Login;

    move-object v2, v0

    invoke-direct {v2}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onClick(Landroid/view/View;)V
    .locals 3

    .prologue
    .line 49
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Login$1;
    move-object v1, p1

    .local v1, "v":Landroid/view/View;
    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/Login$1;->this$0:Lcom/example/paul/a_sacco/Login;

    invoke-virtual {v2}, Lcom/example/paul/a_sacco/Login;->attemptLogin()V

    .line 50
    return-void
.end method
