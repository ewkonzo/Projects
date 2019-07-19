.class public final Lcom/example/paul/a_sacco/R$array;
.super Ljava/lang/Object;
.source "R.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/example/paul/a_sacco/R;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "array"
.end annotation


# static fields
.field public static final pref_example_list_titles:I = 0x7f060000

.field public static final pref_example_list_values:I = 0x7f060001

.field public static final pref_sync_frequency_titles:I = 0x7f060002

.field public static final pref_sync_frequency_values:I = 0x7f060003


# direct methods
.method public constructor <init>()V
    .locals 2

    .prologue
    .line 19
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/R$array;
    move-object v1, v0

    invoke-direct {v1}, Ljava/lang/Object;-><init>()V

    return-void
.end method
