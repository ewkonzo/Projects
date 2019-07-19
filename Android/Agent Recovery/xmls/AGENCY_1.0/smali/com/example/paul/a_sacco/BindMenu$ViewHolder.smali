.class Lcom/example/paul/a_sacco/BindMenu$ViewHolder;
.super Ljava/lang/Object;
.source "BindMenu.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/example/paul/a_sacco/BindMenu;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x8
    name = "ViewHolder"
.end annotation


# instance fields
.field gtotal:Landroid/widget/TextView;

.field id:Landroid/widget/TextView;

.field tvDesc:Landroid/widget/TextView;

.field tvName:Landroid/widget/TextView;

.field tvdelete:Landroid/widget/ImageView;

.field tvitems:Landroid/widget/TextView;

.field tvtotal:Landroid/widget/TextView;


# direct methods
.method constructor <init>()V
    .locals 2

    .prologue
    .line 85
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/BindMenu$ViewHolder;
    move-object v1, v0

    invoke-direct {v1}, Ljava/lang/Object;-><init>()V

    return-void
.end method
