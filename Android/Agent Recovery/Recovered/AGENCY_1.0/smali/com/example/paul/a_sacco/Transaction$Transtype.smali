.class public final enum Lcom/example/paul/a_sacco/Transaction$Transtype;
.super Ljava/lang/Enum;
.source "Transaction.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/example/paul/a_sacco/Transaction;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "Transtype"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum",
        "<",
        "Lcom/example/paul/a_sacco/Transaction$Transtype;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/example/paul/a_sacco/Transaction$Transtype;

.field public static final enum Balance:Lcom/example/paul/a_sacco/Transaction$Transtype;
    .annotation runtime Lcom/google/gson/annotations/SerializedName;
        value = "8"
    .end annotation
.end field

.field public static final enum Changepin:Lcom/example/paul/a_sacco/Transaction$Transtype;
    .annotation runtime Lcom/google/gson/annotations/SerializedName;
        value = "13"
    .end annotation
.end field

.field public static final enum Deposit:Lcom/example/paul/a_sacco/Transaction$Transtype;
    .annotation runtime Lcom/google/gson/annotations/SerializedName;
        value = "3"
    .end annotation
.end field

.field public static final enum LoanRepayment:Lcom/example/paul/a_sacco/Transaction$Transtype;
    .annotation runtime Lcom/google/gson/annotations/SerializedName;
        value = "4"
    .end annotation
.end field

.field public static final enum MemberRegistration:Lcom/example/paul/a_sacco/Transaction$Transtype;
    .annotation runtime Lcom/google/gson/annotations/SerializedName;
        value = "12"
    .end annotation
.end field

.field public static final enum Memberactivation:Lcom/example/paul/a_sacco/Transaction$Transtype;
    .annotation runtime Lcom/google/gson/annotations/SerializedName;
        value = "11"
    .end annotation
.end field

.field public static final enum Ministatment:Lcom/example/paul/a_sacco/Transaction$Transtype;
    .annotation runtime Lcom/google/gson/annotations/SerializedName;
        value = "9"
    .end annotation
.end field

.field public static final enum None:Lcom/example/paul/a_sacco/Transaction$Transtype;
    .annotation runtime Lcom/google/gson/annotations/SerializedName;
        value = "0"
    .end annotation
.end field

.field public static final enum Paybill:Lcom/example/paul/a_sacco/Transaction$Transtype;
    .annotation runtime Lcom/google/gson/annotations/SerializedName;
        value = "10"
    .end annotation
.end field

.field public static final enum Registration:Lcom/example/paul/a_sacco/Transaction$Transtype;
    .annotation runtime Lcom/google/gson/annotations/SerializedName;
        value = "1"
    .end annotation
.end field

.field public static final enum Schoolfeespayment:Lcom/example/paul/a_sacco/Transaction$Transtype;
    .annotation runtime Lcom/google/gson/annotations/SerializedName;
        value = "7"
    .end annotation
.end field

.field public static final enum Sharedeposit:Lcom/example/paul/a_sacco/Transaction$Transtype;
    .annotation runtime Lcom/google/gson/annotations/SerializedName;
        value = "6"
    .end annotation
.end field

.field public static final enum Transfer:Lcom/example/paul/a_sacco/Transaction$Transtype;
    .annotation runtime Lcom/google/gson/annotations/SerializedName;
        value = "5"
    .end annotation
.end field

.field public static final enum Withdrawal:Lcom/example/paul/a_sacco/Transaction$Transtype;
    .annotation runtime Lcom/google/gson/annotations/SerializedName;
        value = "2"
    .end annotation
.end field


# direct methods
.method static constructor <clinit>()V
    .locals 5

    .prologue
    .line 54
    new-instance v0, Lcom/example/paul/a_sacco/Transaction$Transtype;

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const-string v2, "None"

    const/4 v3, 0x0

    invoke-direct {v1, v2, v3}, Lcom/example/paul/a_sacco/Transaction$Transtype;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/example/paul/a_sacco/Transaction$Transtype;->None:Lcom/example/paul/a_sacco/Transaction$Transtype;

    .line 56
    new-instance v0, Lcom/example/paul/a_sacco/Transaction$Transtype;

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const-string v2, "Registration"

    const/4 v3, 0x1

    invoke-direct {v1, v2, v3}, Lcom/example/paul/a_sacco/Transaction$Transtype;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/example/paul/a_sacco/Transaction$Transtype;->Registration:Lcom/example/paul/a_sacco/Transaction$Transtype;

    .line 58
    new-instance v0, Lcom/example/paul/a_sacco/Transaction$Transtype;

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const-string v2, "Withdrawal"

    const/4 v3, 0x2

    invoke-direct {v1, v2, v3}, Lcom/example/paul/a_sacco/Transaction$Transtype;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/example/paul/a_sacco/Transaction$Transtype;->Withdrawal:Lcom/example/paul/a_sacco/Transaction$Transtype;

    .line 60
    new-instance v0, Lcom/example/paul/a_sacco/Transaction$Transtype;

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const-string v2, "Deposit"

    const/4 v3, 0x3

    invoke-direct {v1, v2, v3}, Lcom/example/paul/a_sacco/Transaction$Transtype;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/example/paul/a_sacco/Transaction$Transtype;->Deposit:Lcom/example/paul/a_sacco/Transaction$Transtype;

    .line 62
    new-instance v0, Lcom/example/paul/a_sacco/Transaction$Transtype;

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const-string v2, "LoanRepayment"

    const/4 v3, 0x4

    invoke-direct {v1, v2, v3}, Lcom/example/paul/a_sacco/Transaction$Transtype;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/example/paul/a_sacco/Transaction$Transtype;->LoanRepayment:Lcom/example/paul/a_sacco/Transaction$Transtype;

    .line 64
    new-instance v0, Lcom/example/paul/a_sacco/Transaction$Transtype;

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const-string v2, "Transfer"

    const/4 v3, 0x5

    invoke-direct {v1, v2, v3}, Lcom/example/paul/a_sacco/Transaction$Transtype;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/example/paul/a_sacco/Transaction$Transtype;->Transfer:Lcom/example/paul/a_sacco/Transaction$Transtype;

    .line 66
    new-instance v0, Lcom/example/paul/a_sacco/Transaction$Transtype;

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const-string v2, "Sharedeposit"

    const/4 v3, 0x6

    invoke-direct {v1, v2, v3}, Lcom/example/paul/a_sacco/Transaction$Transtype;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/example/paul/a_sacco/Transaction$Transtype;->Sharedeposit:Lcom/example/paul/a_sacco/Transaction$Transtype;

    .line 68
    new-instance v0, Lcom/example/paul/a_sacco/Transaction$Transtype;

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const-string v2, "Schoolfeespayment"

    const/4 v3, 0x7

    invoke-direct {v1, v2, v3}, Lcom/example/paul/a_sacco/Transaction$Transtype;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/example/paul/a_sacco/Transaction$Transtype;->Schoolfeespayment:Lcom/example/paul/a_sacco/Transaction$Transtype;

    .line 70
    new-instance v0, Lcom/example/paul/a_sacco/Transaction$Transtype;

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const-string v2, "Balance"

    const/16 v3, 0x8

    invoke-direct {v1, v2, v3}, Lcom/example/paul/a_sacco/Transaction$Transtype;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/example/paul/a_sacco/Transaction$Transtype;->Balance:Lcom/example/paul/a_sacco/Transaction$Transtype;

    .line 72
    new-instance v0, Lcom/example/paul/a_sacco/Transaction$Transtype;

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const-string v2, "Ministatment"

    const/16 v3, 0x9

    invoke-direct {v1, v2, v3}, Lcom/example/paul/a_sacco/Transaction$Transtype;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/example/paul/a_sacco/Transaction$Transtype;->Ministatment:Lcom/example/paul/a_sacco/Transaction$Transtype;

    .line 74
    new-instance v0, Lcom/example/paul/a_sacco/Transaction$Transtype;

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const-string v2, "Paybill"

    const/16 v3, 0xa

    invoke-direct {v1, v2, v3}, Lcom/example/paul/a_sacco/Transaction$Transtype;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/example/paul/a_sacco/Transaction$Transtype;->Paybill:Lcom/example/paul/a_sacco/Transaction$Transtype;

    .line 76
    new-instance v0, Lcom/example/paul/a_sacco/Transaction$Transtype;

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const-string v2, "Memberactivation"

    const/16 v3, 0xb

    invoke-direct {v1, v2, v3}, Lcom/example/paul/a_sacco/Transaction$Transtype;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/example/paul/a_sacco/Transaction$Transtype;->Memberactivation:Lcom/example/paul/a_sacco/Transaction$Transtype;

    .line 78
    new-instance v0, Lcom/example/paul/a_sacco/Transaction$Transtype;

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const-string v2, "MemberRegistration"

    const/16 v3, 0xc

    invoke-direct {v1, v2, v3}, Lcom/example/paul/a_sacco/Transaction$Transtype;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/example/paul/a_sacco/Transaction$Transtype;->MemberRegistration:Lcom/example/paul/a_sacco/Transaction$Transtype;

    .line 80
    new-instance v0, Lcom/example/paul/a_sacco/Transaction$Transtype;

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const-string v2, "Changepin"

    const/16 v3, 0xd

    invoke-direct {v1, v2, v3}, Lcom/example/paul/a_sacco/Transaction$Transtype;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/example/paul/a_sacco/Transaction$Transtype;->Changepin:Lcom/example/paul/a_sacco/Transaction$Transtype;

    .line 53
    const/16 v0, 0xe

    new-array v0, v0, [Lcom/example/paul/a_sacco/Transaction$Transtype;

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const/4 v2, 0x0

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Transtype;->None:Lcom/example/paul/a_sacco/Transaction$Transtype;

    aput-object v3, v1, v2

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const/4 v2, 0x1

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Transtype;->Registration:Lcom/example/paul/a_sacco/Transaction$Transtype;

    aput-object v3, v1, v2

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const/4 v2, 0x2

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Transtype;->Withdrawal:Lcom/example/paul/a_sacco/Transaction$Transtype;

    aput-object v3, v1, v2

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const/4 v2, 0x3

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Transtype;->Deposit:Lcom/example/paul/a_sacco/Transaction$Transtype;

    aput-object v3, v1, v2

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const/4 v2, 0x4

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Transtype;->LoanRepayment:Lcom/example/paul/a_sacco/Transaction$Transtype;

    aput-object v3, v1, v2

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const/4 v2, 0x5

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Transtype;->Transfer:Lcom/example/paul/a_sacco/Transaction$Transtype;

    aput-object v3, v1, v2

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const/4 v2, 0x6

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Transtype;->Sharedeposit:Lcom/example/paul/a_sacco/Transaction$Transtype;

    aput-object v3, v1, v2

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const/4 v2, 0x7

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Transtype;->Schoolfeespayment:Lcom/example/paul/a_sacco/Transaction$Transtype;

    aput-object v3, v1, v2

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const/16 v2, 0x8

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Transtype;->Balance:Lcom/example/paul/a_sacco/Transaction$Transtype;

    aput-object v3, v1, v2

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const/16 v2, 0x9

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Transtype;->Ministatment:Lcom/example/paul/a_sacco/Transaction$Transtype;

    aput-object v3, v1, v2

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const/16 v2, 0xa

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Transtype;->Paybill:Lcom/example/paul/a_sacco/Transaction$Transtype;

    aput-object v3, v1, v2

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const/16 v2, 0xb

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Transtype;->Memberactivation:Lcom/example/paul/a_sacco/Transaction$Transtype;

    aput-object v3, v1, v2

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const/16 v2, 0xc

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Transtype;->MemberRegistration:Lcom/example/paul/a_sacco/Transaction$Transtype;

    aput-object v3, v1, v2

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const/16 v2, 0xd

    sget-object v3, Lcom/example/paul/a_sacco/Transaction$Transtype;->Changepin:Lcom/example/paul/a_sacco/Transaction$Transtype;

    aput-object v3, v1, v2

    sput-object v0, Lcom/example/paul/a_sacco/Transaction$Transtype;->$VALUES:[Lcom/example/paul/a_sacco/Transaction$Transtype;

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
    .line 53
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Transaction$Transtype;
    move-object v1, p1

    move v2, p2

    move-object v3, v0

    move-object v4, v1

    move v5, v2

    invoke-direct {v3, v4, v5}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/example/paul/a_sacco/Transaction$Transtype;
    .locals 3

    .prologue
    .line 53
    move-object v0, p0

    .local v0, "name":Ljava/lang/String;
    const-class v1, Lcom/example/paul/a_sacco/Transaction$Transtype;

    move-object v2, v0

    invoke-static {v1, v2}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object v1

    check-cast v1, Lcom/example/paul/a_sacco/Transaction$Transtype;

    move-object v0, v1

    .end local v0    # "name":Ljava/lang/String;
    return-object v0
.end method

.method public static values()[Lcom/example/paul/a_sacco/Transaction$Transtype;
    .locals 1

    .prologue
    .line 53
    sget-object v0, Lcom/example/paul/a_sacco/Transaction$Transtype;->$VALUES:[Lcom/example/paul/a_sacco/Transaction$Transtype;

    invoke-virtual {v0}, [Lcom/example/paul/a_sacco/Transaction$Transtype;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/example/paul/a_sacco/Transaction$Transtype;

    return-object v0
.end method
