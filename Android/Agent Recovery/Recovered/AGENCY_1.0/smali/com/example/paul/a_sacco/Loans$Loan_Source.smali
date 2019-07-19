.class public final enum Lcom/example/paul/a_sacco/Loans$Loan_Source;
.super Ljava/lang/Enum;
.source "Loans.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/example/paul/a_sacco/Loans;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "Loan_Source"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum",
        "<",
        "Lcom/example/paul/a_sacco/Loans$Loan_Source;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/example/paul/a_sacco/Loans$Loan_Source;

.field public static final enum Bosa:Lcom/example/paul/a_sacco/Loans$Loan_Source;
    .annotation runtime Lcom/google/gson/annotations/SerializedName;
        value = "0"
    .end annotation
.end field

.field public static final enum Fosa:Lcom/example/paul/a_sacco/Loans$Loan_Source;
    .annotation runtime Lcom/google/gson/annotations/SerializedName;
        value = "1"
    .end annotation
.end field


# direct methods
.method static constructor <clinit>()V
    .locals 5

    .prologue
    .line 14
    new-instance v0, Lcom/example/paul/a_sacco/Loans$Loan_Source;

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const-string v2, "Bosa"

    const/4 v3, 0x0

    invoke-direct {v1, v2, v3}, Lcom/example/paul/a_sacco/Loans$Loan_Source;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/example/paul/a_sacco/Loans$Loan_Source;->Bosa:Lcom/example/paul/a_sacco/Loans$Loan_Source;

    .line 16
    new-instance v0, Lcom/example/paul/a_sacco/Loans$Loan_Source;

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const-string v2, "Fosa"

    const/4 v3, 0x1

    invoke-direct {v1, v2, v3}, Lcom/example/paul/a_sacco/Loans$Loan_Source;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/example/paul/a_sacco/Loans$Loan_Source;->Fosa:Lcom/example/paul/a_sacco/Loans$Loan_Source;

    .line 13
    const/4 v0, 0x2

    new-array v0, v0, [Lcom/example/paul/a_sacco/Loans$Loan_Source;

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const/4 v2, 0x0

    sget-object v3, Lcom/example/paul/a_sacco/Loans$Loan_Source;->Bosa:Lcom/example/paul/a_sacco/Loans$Loan_Source;

    aput-object v3, v1, v2

    move-object v4, v0

    move-object v0, v4

    move-object v1, v4

    const/4 v2, 0x1

    sget-object v3, Lcom/example/paul/a_sacco/Loans$Loan_Source;->Fosa:Lcom/example/paul/a_sacco/Loans$Loan_Source;

    aput-object v3, v1, v2

    sput-object v0, Lcom/example/paul/a_sacco/Loans$Loan_Source;->$VALUES:[Lcom/example/paul/a_sacco/Loans$Loan_Source;

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
    .line 13
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Loans$Loan_Source;
    move-object v1, p1

    move v2, p2

    move-object v3, v0

    move-object v4, v1

    move v5, v2

    invoke-direct {v3, v4, v5}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/example/paul/a_sacco/Loans$Loan_Source;
    .locals 3

    .prologue
    .line 13
    move-object v0, p0

    .local v0, "name":Ljava/lang/String;
    const-class v1, Lcom/example/paul/a_sacco/Loans$Loan_Source;

    move-object v2, v0

    invoke-static {v1, v2}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object v1

    check-cast v1, Lcom/example/paul/a_sacco/Loans$Loan_Source;

    move-object v0, v1

    .end local v0    # "name":Ljava/lang/String;
    return-object v0
.end method

.method public static values()[Lcom/example/paul/a_sacco/Loans$Loan_Source;
    .locals 1

    .prologue
    .line 13
    sget-object v0, Lcom/example/paul/a_sacco/Loans$Loan_Source;->$VALUES:[Lcom/example/paul/a_sacco/Loans$Loan_Source;

    invoke-virtual {v0}, [Lcom/example/paul/a_sacco/Loans$Loan_Source;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/example/paul/a_sacco/Loans$Loan_Source;

    return-object v0
.end method
