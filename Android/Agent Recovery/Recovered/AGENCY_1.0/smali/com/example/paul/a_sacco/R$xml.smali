.class public final Lcom/example/paul/a_sacco/R$xml;
.super Ljava/lang/Object;
.source "R.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/example/paul/a_sacco/R;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "xml"
.end annotation


# static fields
.field public static final pref_data_sync:I = 0x7f050000

.field public static final pref_general:I = 0x7f050001

.field public static final pref_headers:I = 0x7f050002

.field public static final pref_notification:I = 0x7f050003


# direct methods
.method public constructor <init>()V
    .locals 2

    .prologue
    .line 1254
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/R$xml;
    move-object v1, v0

    invoke-direct {v1}, Ljava/lang/Object;-><init>()V

    return-void
.end method
