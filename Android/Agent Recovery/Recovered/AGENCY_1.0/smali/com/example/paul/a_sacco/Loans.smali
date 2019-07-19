.class public Lcom/example/paul/a_sacco/Loans;
.super Ljava/lang/Object;
.source "Loans.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/example/paul/a_sacco/Loans$Loan_Source;
    }
.end annotation


# instance fields
.field public Loan_Balance:D

.field public Loan_No:Ljava/lang/String;

.field public Loan_Type:Ljava/lang/String;

.field public Loan_Type_Name:Ljava/lang/String;

.field public loan_source:Lcom/example/paul/a_sacco/Loans$Loan_Source;

.field public member:Lcom/example/paul/a_sacco/Member;


# direct methods
.method public constructor <init>()V
    .locals 4

    .prologue
    .line 5
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Loans;
    move-object v1, v0

    invoke-direct {v1}, Ljava/lang/Object;-><init>()V

    .line 6
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Loans;->member:Lcom/example/paul/a_sacco/Member;

    .line 7
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Loans;->Loan_No:Ljava/lang/String;

    .line 8
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Loans;->Loan_Type:Ljava/lang/String;

    .line 9
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Loans;->Loan_Type_Name:Ljava/lang/String;

    .line 10
    move-object v1, v0

    const-wide/16 v2, 0x0

    iput-wide v2, v1, Lcom/example/paul/a_sacco/Loans;->Loan_Balance:D

    .line 13
    return-void
.end method
