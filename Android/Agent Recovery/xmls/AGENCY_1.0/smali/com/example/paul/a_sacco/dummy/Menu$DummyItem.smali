.class public Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;
.super Ljava/lang/Object;
.source "Menu.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/example/paul/a_sacco/dummy/Menu;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x9
    name = "DummyItem"
.end annotation


# instance fields
.field public content:Ljava/lang/String;

.field public id:Ljava/lang/String;

.field public image:I


# direct methods
.method public constructor <init>(Ljava/lang/String;Ljava/lang/String;I)V
    .locals 6

    .prologue
    .line 59
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;
    move-object v1, p1

    .local v1, "id":Ljava/lang/String;
    move-object v2, p2

    .local v2, "content":Ljava/lang/String;
    move v3, p3

    .local v3, "image":I
    move-object v4, v0

    invoke-direct {v4}, Ljava/lang/Object;-><init>()V

    .line 60
    move-object v4, v0

    move-object v5, v1

    iput-object v5, v4, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;->id:Ljava/lang/String;

    .line 61
    move-object v4, v0

    move-object v5, v2

    iput-object v5, v4, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;->content:Ljava/lang/String;

    .line 62
    move-object v4, v0

    move v5, v3

    iput v5, v4, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;->image:I

    .line 63
    return-void
.end method


# virtual methods
.method public toString()Ljava/lang/String;
    .locals 2

    .prologue
    .line 67
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;
    move-object v1, v0

    iget-object v1, v1, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;->content:Ljava/lang/String;

    move-object v0, v1

    .end local v0    # "this":Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;
    return-object v0
.end method
