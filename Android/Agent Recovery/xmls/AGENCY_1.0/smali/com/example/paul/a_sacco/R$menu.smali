.class public final Lcom/example/paul/a_sacco/R$menu;
.super Ljava/lang/Object;
.source "R.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/example/paul/a_sacco/R;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "menu"
.end annotation


# static fields
.field public static final balance:I = 0x7f0e0000

.field public static final confirmation_box:I = 0x7f0e0001

.field public static final loanrepayment:I = 0x7f0e0002

.field public static final login:I = 0x7f0e0003

.field public static final main:I = 0x7f0e0004

.field public static final registration:I = 0x7f0e0005

.field public static final results:I = 0x7f0e0006

.field public static final splash:I = 0x7f0e0007

.field public static final transfers:I = 0x7f0e0008

.field public static final withdrawal:I = 0x7f0e0009


# direct methods
.method public constructor <init>()V
    .locals 2

    .prologue
    .line 1030
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/R$menu;
    move-object v1, v0

    invoke-direct {v1}, Ljava/lang/Object;-><init>()V

    return-void
.end method
