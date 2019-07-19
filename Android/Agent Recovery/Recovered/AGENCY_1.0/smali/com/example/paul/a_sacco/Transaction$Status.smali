.class public final enum Lcom/example/paul/a_sacco/Transaction$Status;
.super Ljava/lang/Enum;
.source "Transaction.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/example/paul/a_sacco/Transaction;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "Status"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum",
        "<",
        "Lcom/example/paul/a_sacco/Transaction$Status;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/example/paul/a_sacco/Transaction$Status;

.field public static final enum Completed:Lcom/example/paul/a_sacco/Transaction$Status;
    .annotation runtime Lcom/google/gson/annotations/SerializedName;
        value = "4"
    .end annotation
.end field

.field public static final enum Confirmation:Lcom/example/paul/a_sacco/Transaction$Status;
    .annotation runtime Lcom/google/gson/annotations/SerializedName;
        value = "1"
    .end annotation
.end field

.field public static final enum Failed:Lcom/example/paul/a_sacco/Transaction$Status;
    .annotation runtime Lcom/google/gson/annotations/SerializedName;
        value = "3"
    .end annotation
.end field

.field public static final enum Pending:Lcom/example/paul/a_sacco/Transaction$Status;
    .annotation runtime Lcom/google/gson/annotations/SerializedName;
        value = "0"
    .end annotation
.end field

.field public static final enum Successful:Lcom/example/paul/a_sacco/Transaction$Status;
    .annotation runtime Lcom/google/gson/annotations/SerializedName;
        value = "2"
    .end annotation
.end field


# direct methods
.method static constructor <clinit>()V
    .locals 5

    .prologue
    .line 85
    new-instance v0, Lcom/example/paul/a_sacco/Transaction$Status;

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const-string v2, "Pending"

    const/4 v3, 0x0

    invoke-direct {v1, v2, v3}, Lcom/example/paul/a_sacco/Transaction$Status;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/example/paul/a_sacco/Transaction$Status;->Pending:Lcom/example/paul/a_sacco/Transaction$Status;

    .line 87
    new-instance v0, Lcom/example/paul/a_sacco/Transaction$Status;

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const-string v2, "Confirmation"

    const/4 v3, 0x1

    invoke-direct {v1, v2, v3}, Lcom/example/paul/a_sacco/Transaction$Status;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/example/paul/a_sacco/Transaction$Status;->Confirmation:Lcom/example/paul/a_sacco/Transaction$Status;

    .line 89
    new-instance v0, Lcom/example/paul/a_sacco/Transaction$Status;

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const-string v2, "Successful"

    const/4 v3, 0x2

    invoke-direct {v1, v2, v3}, Lcom/example/paul/a_sacco/Transaction$Status;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/example/paul/a_sacco/Transaction$Status;->Successful:Lcom/example/paul/a_sacco/Transaction$Status;

    .line 91
    new-instance v0, Lcom/example/paul/a_sacco/Transaction$Status;

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const-string v2, "Failed"

    const/4 v3, 0x3

    invoke-direct {v1, v2, v3}, Lcom/example/paul/a_sacco/Transaction$Status;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/example/paul/a_sacco/Transaction$Status;->Failed:Lcom/example/paul/a_sacco/Transaction$Status;

    .line 93
    new-instance v0, Lcom/example/paul/a_sacco/Transaction$Status;

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const-string v2, "Completed"

    const/4 v3, 0x4

    invoke-direct {v1, v2, v3}, Lcom/example/paul/a_sacco/Transaction$Status;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/example/paul/a_sacco/Transaction$Status;->Completed:Lcom/example/paul/a_sacco/Transaction$Status;

    .line 84
    const/4 v0, 0x5

    new-array v0, v0, [Lcom/example/paul/a_sacco/Transaction$Status;

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const/4 v2, 0x0

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Status;->Pending:Lcom/example/paul/a_sacco/Transaction$Status;

    aput-object v3, v1, v2

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const/4 v2, 0x1

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Status;->Confirmation:Lcom/example/paul/a_sacco/Transaction$Status;

    aput-object v3, v1, v2

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const/4 v2, 0x2

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Status;->Successful:Lcom/example/paul/a_sacco/Transaction$Status;

    aput-object v3, v1, v2

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const/4 v2, 0x3

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Status;->Failed:Lcom/example/paul/a_sacco/Transaction$Status;

    aput-object v3, v1, v2

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const/4 v2, 0x4

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Status;->Completed:Lcom/example/paul/a_sacco/Transaction$Status;

    aput-object v3, v1, v2

    sput-object v0, Lcom/example/paul/a_sacco/Transaction$Status;->$VALUES:[Lcom/example/paul/a_sacco/Transaction$Status;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;I)V
    .locals 6
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()V"
        }
    .end annotation

    .prologue
    .line 84
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Transaction$Status;
    move-object v1, p1

    move v2, p2

    move-object v3, v0

    move-object v4, v1

    move v5, v2

    invoke-direct {v3, v4, v5}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/example/paul/a_sacco/Transaction$Status;
    .locals 3

    .prologue
    .line 84
    move-object v0, p0

    .local v0, "name":Ljava/lang/String;
    const-class v1, Lcom/example/paul/a_sacco/Transaction$Status;

    move-object v2, v0

    invoke-static {v1, v2}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object v1

    check-cast v1, Lcom/example/paul/a_sacco/Transaction$Status;

    move-object v0, v1

    .end local v0    # "name":Ljava/lang/String;
    return-object v0
.end method

.method public static values()[Lcom/example/paul/a_sacco/Transaction$Status;
    .locals 1

    .prologue
    .line 84
    sget-object v0, Lcom/example/paul/a_sacco/Transaction$Status;->$VALUES:[Lcom/example/paul/a_sacco/Transaction$Status;

    invoke-virtual {v0}, [Lcom/example/paul/a_sacco/Transaction$Status;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/example/paul/a_sacco/Transaction$Status;

    return-object v0
.end method
