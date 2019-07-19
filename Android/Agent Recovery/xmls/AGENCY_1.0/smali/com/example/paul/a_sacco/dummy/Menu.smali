.class public Lcom/example/paul/a_sacco/dummy/Menu;
.super Ljava/lang/Object;
.source "Menu.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;
    }
.end annotation


# static fields
.field public static ITEMS:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List",
            "<",
            "Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;",
            ">;"
        }
    .end annotation
.end field

.field public static ITEM_MAP:Ljava/util/Map;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method static constructor <clinit>()V
    .locals 6

    .prologue
    .line 23
    new-instance v0, Ljava/util/ArrayList;

    move-object v5, v0

    move-object v0, v5

    move-object v1, v5

    invoke-direct {v1}, Ljava/util/ArrayList;-><init>()V

    sput-object v0, Lcom/example/paul/a_sacco/dummy/Menu;->ITEMS:Ljava/util/List;

    .line 28
    new-instance v0, Ljava/util/HashMap;

    move-object v5, v0

    move-object v0, v5

    move-object v1, v5

    invoke-direct {v1}, Ljava/util/HashMap;-><init>()V

    sput-object v0, Lcom/example/paul/a_sacco/dummy/Menu;->ITEM_MAP:Ljava/util/Map;

    .line 32
    new-instance v0, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;

    move-object v5, v0

    move-object v0, v5

    move-object v1, v5

    const-string v2, "11"

    const-string v3, "Account Activation"

    const v4, 0x7f02006e

    invoke-direct {v1, v2, v3, v4}, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;-><init>(Ljava/lang/String;Ljava/lang/String;I)V

    invoke-static {v0}, Lcom/example/paul/a_sacco/dummy/Menu;->addItem(Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;)V

    .line 33
    new-instance v0, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;

    move-object v5, v0

    move-object v0, v5

    move-object v1, v5

    const-string v2, "1"

    const-string v3, "Account Opening"

    const v4, 0x7f02006e

    invoke-direct {v1, v2, v3, v4}, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;-><init>(Ljava/lang/String;Ljava/lang/String;I)V

    invoke-static {v0}, Lcom/example/paul/a_sacco/dummy/Menu;->addItem(Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;)V

    .line 34
    new-instance v0, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;

    move-object v5, v0

    move-object v0, v5

    move-object v1, v5

    const-string v2, "12"

    const-string v3, "Member Registration"

    const v4, 0x7f02006e

    invoke-direct {v1, v2, v3, v4}, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;-><init>(Ljava/lang/String;Ljava/lang/String;I)V

    invoke-static {v0}, Lcom/example/paul/a_sacco/dummy/Menu;->addItem(Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;)V

    .line 35
    new-instance v0, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;

    move-object v5, v0

    move-object v0, v5

    move-object v1, v5

    const-string v2, "2"

    const-string v3, "Cash WithDraw"

    const v4, 0x7f02005d

    invoke-direct {v1, v2, v3, v4}, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;-><init>(Ljava/lang/String;Ljava/lang/String;I)V

    invoke-static {v0}, Lcom/example/paul/a_sacco/dummy/Menu;->addItem(Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;)V

    .line 36
    new-instance v0, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;

    move-object v5, v0

    move-object v0, v5

    move-object v1, v5

    const-string v2, "3"

    const-string v3, "Cash Deposit"

    const v4, 0x7f02005c

    invoke-direct {v1, v2, v3, v4}, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;-><init>(Ljava/lang/String;Ljava/lang/String;I)V

    invoke-static {v0}, Lcom/example/paul/a_sacco/dummy/Menu;->addItem(Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;)V

    .line 37
    new-instance v0, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;

    move-object v5, v0

    move-object v0, v5

    move-object v1, v5

    const-string v2, "4"

    const-string v3, "Loan Repayment"

    const v4, 0x7f020069

    invoke-direct {v1, v2, v3, v4}, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;-><init>(Ljava/lang/String;Ljava/lang/String;I)V

    invoke-static {v0}, Lcom/example/paul/a_sacco/dummy/Menu;->addItem(Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;)V

    .line 38
    new-instance v0, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;

    move-object v5, v0

    move-object v0, v5

    move-object v1, v5

    const-string v2, "5"

    const-string v3, "Cash Transfer"

    const v4, 0x7f020067

    invoke-direct {v1, v2, v3, v4}, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;-><init>(Ljava/lang/String;Ljava/lang/String;I)V

    invoke-static {v0}, Lcom/example/paul/a_sacco/dummy/Menu;->addItem(Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;)V

    .line 39
    new-instance v0, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;

    move-object v5, v0

    move-object v0, v5

    move-object v1, v5

    const-string v2, "6"

    const-string v3, "Share Deposit"

    const v4, 0x7f02006c

    invoke-direct {v1, v2, v3, v4}, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;-><init>(Ljava/lang/String;Ljava/lang/String;I)V

    invoke-static {v0}, Lcom/example/paul/a_sacco/dummy/Menu;->addItem(Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;)V

    .line 40
    new-instance v0, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;

    move-object v5, v0

    move-object v0, v5

    move-object v1, v5

    const-string v2, "7"

    const-string v3, "Balance Enquiry"

    const v4, 0x7f02005d

    invoke-direct {v1, v2, v3, v4}, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;-><init>(Ljava/lang/String;Ljava/lang/String;I)V

    invoke-static {v0}, Lcom/example/paul/a_sacco/dummy/Menu;->addItem(Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;)V

    .line 41
    new-instance v0, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;

    move-object v5, v0

    move-object v0, v5

    move-object v1, v5

    const-string v2, "8"

    const-string v3, "Mini statement"

    const v4, 0x7f020066

    invoke-direct {v1, v2, v3, v4}, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;-><init>(Ljava/lang/String;Ljava/lang/String;I)V

    invoke-static {v0}, Lcom/example/paul/a_sacco/dummy/Menu;->addItem(Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;)V

    .line 43
    new-instance v0, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;

    move-object v5, v0

    move-object v0, v5

    move-object v1, v5

    const-string v2, "10"

    const-string v3, "Change Client pin"

    const v4, 0x7f020063

    invoke-direct {v1, v2, v3, v4}, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;-><init>(Ljava/lang/String;Ljava/lang/String;I)V

    invoke-static {v0}, Lcom/example/paul/a_sacco/dummy/Menu;->addItem(Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;)V

    .line 44
    return-void
.end method

.method public constructor <init>()V
    .locals 2

    .prologue
    .line 18
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/dummy/Menu;
    move-object v1, v0

    invoke-direct {v1}, Ljava/lang/Object;-><init>()V

    .line 54
    return-void
.end method

.method private static addItem(Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;)V
    .locals 4

    .prologue
    .line 47
    move-object v0, p0

    .local v0, "item":Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;
    sget-object v1, Lcom/example/paul/a_sacco/dummy/Menu;->ITEMS:Ljava/util/List;

    move-object v2, v0

    invoke-interface {v1, v2}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    move-result v1

    .line 48
    sget-object v1, Lcom/example/paul/a_sacco/dummy/Menu;->ITEM_MAP:Ljava/util/Map;

    move-object v2, v0

    iget-object v2, v2, Lcom/example/paul/a_sacco/dummy/Menu$DummyItem;->id:Ljava/lang/String;

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    move-object v3, v0

    invoke-interface {v1, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    .line 49
    return-void
.end method
