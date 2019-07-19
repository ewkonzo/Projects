.class Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$1;
.super Ljava/lang/Object;
.source "AgencyListActivity.java"

# interfaces
.implements Landroid/content/DialogInterface$OnClickListener;


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


# direct methods
.method constructor <init>(Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword;)V
    .locals 4

    .prologue
    .line 197
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$1;
    move-object v1, p1

    move-object v2, v0

    move-object v3, v1

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$1;->this$1:Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword;

    move-object v2, v0

    invoke-direct {v2}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onClick(Landroid/content/DialogInterface;I)V
    .locals 0
    .param p1, "dialog"    # Landroid/content/DialogInterface;
    .param p2, "whichButton"    # I

    .prologue
    .line 199
    return-void
.end method
