.class Lcom/example/paul/a_sacco/BindAccounts$ViewHolder;
.super Ljava/lang/Object;
.source "BindAccounts.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/example/paul/a_sacco/BindAccounts;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x8
    name = "ViewHolder"
.end annotation


# instance fields
.field Account:Landroid/widget/TextView;

.field Type:Landroid/widget/TextView;

.field radio:Landroid/widget/RadioButton;

.field tvName:Landroid/widget/TextView;


# direct methods
.method constructor <init>()V
    .locals 2

    .prologue
    .line 99
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/BindAccounts$ViewHolder;
    move-object v1, v0

    invoke-direct {v1}, Ljava/lang/Object;-><init>()V

    return-void
.end method
