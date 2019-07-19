.class public Lcom/example/paul/a_sacco/Transaction;
.super Ljava/lang/Object;
.source "Transaction.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/example/paul/a_sacco/Transaction$Status;,
        Lcom/example/paul/a_sacco/Transaction$Transtype;
    }
.end annotation


# static fields
.field static final Table:Ljava/lang/String; = "Transactions"

.field static final colAccount_1:Ljava/lang/String; = "Account_1"

.field static final colAccount_2:Ljava/lang/String; = "Account_2"

.field static final colAmount:Ljava/lang/String; = "Amount"

.field static final colCode:Ljava/lang/String; = "Code"

.field static final colDepositor_Name:Ljava/lang/String; = "Depositor"

.field static final colEntry:Ljava/lang/String; = "Entry"

.field static final colLoan_No:Ljava/lang/String; = "Loan_No"

.field static final colMaximun_Amount:Ljava/lang/String; = "Maximun"

.field static final colMinimun_Amount:Ljava/lang/String; = "Minimun"

.field static final colTelephone_No:Ljava/lang/String; = "Telephone"

.field static final colagent:Ljava/lang/String; = "agent"

.field static final colid:Ljava/lang/String; = "Id"

.field static final colmember_1:Ljava/lang/String; = "member_1"

.field static final colmember_2:Ljava/lang/String; = "member_2"

.field static final colstatus:Ljava/lang/String; = "status"

.field static final coltransactiontype:Ljava/lang/String; = "transactiontype"


# instance fields
.field public Depositor_Name:Ljava/lang/String;

.field public Maximun_Amount:D

.field public Minimun_Amount:D

.field public Telephone_No:Ljava/lang/String;

.field public account_1:Lcom/example/paul/a_sacco/Account;

.field public account_2:Lcom/example/paul/a_sacco/Account;

.field public agent:Lcom/example/paul/a_sacco/Agent;

.field public amount:D

.field public amount_charge:D

.field public code:Ljava/lang/String;

.field public id:I

.field public loan_no:Lcom/example/paul/a_sacco/Loans;

.field public member_1:Lcom/example/paul/a_sacco/Member;

.field public member_2:Lcom/example/paul/a_sacco/Member;

.field public message:Ljava/lang/String;

.field public newpin:Ljava/lang/String;

.field public pinchanged:Z

.field public reference:Ljava/lang/String;

.field public society:Lcom/example/paul/a_sacco/Societies;

.field public status:Lcom/example/paul/a_sacco/Transaction$Status;

.field public transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;


# direct methods
.method public constructor <init>()V
    .locals 4

    .prologue
    .line 11
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Transaction;
    move-object v1, v0

    invoke-direct {v1}, Ljava/lang/Object;-><init>()V

    .line 12
    move-object v1, v0

    const/4 v2, 0x0

    iput v2, v1, Lcom/example/paul/a_sacco/Transaction;->id:I

    .line 13
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Transaction;->reference:Ljava/lang/String;

    .line 14
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    .line 15
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Transaction;->member_2:Lcom/example/paul/a_sacco/Member;

    .line 16
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    .line 17
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Transaction;->account_2:Lcom/example/paul/a_sacco/Account;

    .line 18
    move-object v1, v0

    const-wide/16 v2, 0x0

    iput-wide v2, v1, Lcom/example/paul/a_sacco/Transaction;->amount:D

    .line 19
    move-object v1, v0

    const/4 v2, 0x0

    iput-boolean v2, v1, Lcom/example/paul/a_sacco/Transaction;->pinchanged:Z

    .line 21
    move-object v1, v0

    const-wide/16 v2, 0x0

    iput-wide v2, v1, Lcom/example/paul/a_sacco/Transaction;->amount_charge:D

    .line 22
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Transaction;->code:Ljava/lang/String;

    .line 23
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Transaction;->loan_no:Lcom/example/paul/a_sacco/Loans;

    .line 24
    move-object v1, v0

    sget-object v2, Lcom/example/paul/a_sacco/Transaction$Transtype;->None:Lcom/example/paul/a_sacco/Transaction$Transtype;

    iput-object v2, v1, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    .line 25
    move-object v1, v0

    sget-object v2, Lcom/example/paul/a_sacco/Transaction$Status;->Pending:Lcom/example/paul/a_sacco/Transaction$Status;

    iput-object v2, v1, Lcom/example/paul/a_sacco/Transaction;->status:Lcom/example/paul/a_sacco/Transaction$Status;

    .line 26
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Transaction;->agent:Lcom/example/paul/a_sacco/Agent;

    .line 27
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Transaction;->message:Ljava/lang/String;

    .line 28
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Transaction;->Telephone_No:Ljava/lang/String;

    .line 29
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Transaction;->Depositor_Name:Ljava/lang/String;

    .line 30
    move-object v1, v0

    const-wide/16 v2, 0x0

    iput-wide v2, v1, Lcom/example/paul/a_sacco/Transaction;->Minimun_Amount:D

    .line 31
    move-object v1, v0

    const-wide/16 v2, 0x0

    iput-wide v2, v1, Lcom/example/paul/a_sacco/Transaction;->Maximun_Amount:D

    .line 32
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Transaction;->society:Lcom/example/paul/a_sacco/Societies;

    .line 84
    return-void
.end method

.method public static AddRanch(Lcom/example/paul/a_sacco/Database;Lcom/example/paul/a_sacco/Transaction;)Lcom/example/paul/a_sacco/Transaction;
    .locals 11

    .prologue
    .line 97
    move-object v0, p0

    .local v0, "appdb":Lcom/example/paul/a_sacco/Database;
    move-object v1, p1

    .local v1, "data":Lcom/example/paul/a_sacco/Transaction;
    move-object v4, v0

    invoke-virtual {v4}, Lcom/example/paul/a_sacco/Database;->getWritableDatabase()Landroid/database/sqlite/SQLiteDatabase;

    move-result-object v4

    move-object v2, v4

    .line 98
    .local v2, "db":Landroid/database/sqlite/SQLiteDatabase;
    new-instance v4, Landroid/content/ContentValues;

    move-object v10, v4

    move-object v4, v10

    move-object v5, v10

    invoke-direct {v5}, Landroid/content/ContentValues;-><init>()V

    move-object v3, v4

    .line 99
    .local v3, "cv":Landroid/content/ContentValues;
    move-object v4, v3

    const-string v5, "Entry"

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->reference:Ljava/lang/String;

    invoke-virtual {v4, v5, v6}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/String;)V

    .line 100
    move-object v4, v3

    const-string v5, "member_1"

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Member;->id_no:Ljava/lang/String;

    invoke-virtual {v4, v5, v6}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/String;)V

    .line 101
    move-object v4, v3

    const-string v5, "member_2"

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->member_2:Lcom/example/paul/a_sacco/Member;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Member;->id_no:Ljava/lang/String;

    invoke-virtual {v4, v5, v6}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/String;)V

    .line 102
    move-object v4, v3

    const-string v5, "Account_1"

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Account;->Account_No:Ljava/lang/String;

    invoke-virtual {v4, v5, v6}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/String;)V

    .line 103
    move-object v4, v3

    const-string v5, "Account_2"

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->account_2:Lcom/example/paul/a_sacco/Account;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Account;->Account_No:Ljava/lang/String;

    invoke-virtual {v4, v5, v6}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/String;)V

    .line 104
    move-object v4, v3

    const-string v5, "Amount"

    move-object v6, v1

    iget-wide v6, v6, Lcom/example/paul/a_sacco/Transaction;->amount:D

    invoke-static {v6, v7}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v6

    invoke-virtual {v4, v5, v6}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/Double;)V

    .line 105
    move-object v4, v3

    const-string v5, "Code"

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->code:Ljava/lang/String;

    invoke-virtual {v4, v5, v6}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/String;)V

    .line 106
    move-object v4, v3

    const-string v5, "Loan_No"

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->loan_no:Lcom/example/paul/a_sacco/Loans;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Loans;->Loan_No:Ljava/lang/String;

    invoke-virtual {v4, v5, v6}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/String;)V

    .line 107
    move-object v4, v3

    const-string v5, "transactiontype"

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    invoke-virtual {v6}, Lcom/example/paul/a_sacco/Transaction$Transtype;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v4, v5, v6}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/String;)V

    .line 108
    move-object v4, v3

    const-string v5, "status"

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->status:Lcom/example/paul/a_sacco/Transaction$Status;

    invoke-virtual {v6}, Lcom/example/paul/a_sacco/Transaction$Status;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v4, v5, v6}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/String;)V

    .line 109
    move-object v4, v3

    const-string v5, "agent"

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->agent:Lcom/example/paul/a_sacco/Agent;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Agent;->agent_code:Ljava/lang/String;

    invoke-virtual {v4, v5, v6}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/String;)V

    .line 110
    move-object v4, v3

    const-string v5, "Telephone"

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->Telephone_No:Ljava/lang/String;

    invoke-virtual {v4, v5, v6}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/String;)V

    .line 111
    move-object v4, v3

    const-string v5, "Depositor"

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->Depositor_Name:Ljava/lang/String;

    invoke-virtual {v4, v5, v6}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/String;)V

    .line 112
    move-object v4, v3

    const-string v5, "Minimun"

    move-object v6, v1

    iget-wide v6, v6, Lcom/example/paul/a_sacco/Transaction;->Minimun_Amount:D

    invoke-static {v6, v7}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v6

    invoke-virtual {v4, v5, v6}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/Double;)V

    .line 113
    move-object v4, v3

    const-string v5, "Maximun"

    move-object v6, v1

    iget-wide v6, v6, Lcom/example/paul/a_sacco/Transaction;->Maximun_Amount:D

    invoke-static {v6, v7}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v6

    invoke-virtual {v4, v5, v6}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/Double;)V

    .line 115
    move-object v4, v1

    move-object v5, v2

    const-string v6, "Transactions"

    const-string v7, "Account_1"

    move-object v8, v3

    const/4 v9, 0x5

    invoke-virtual {v5, v6, v7, v8, v9}, Landroid/database/sqlite/SQLiteDatabase;->insertWithOnConflict(Ljava/lang/String;Ljava/lang/String;Landroid/content/ContentValues;I)J

    move-result-wide v5

    long-to-int v5, v5

    iput v5, v4, Lcom/example/paul/a_sacco/Transaction;->id:I

    .line 117
    move-object v4, v2

    invoke-virtual {v4}, Landroid/database/sqlite/SQLiteDatabase;->close()V

    .line 118
    move-object v4, v1

    move-object v0, v4

    .end local v0    # "appdb":Lcom/example/paul/a_sacco/Database;
    return-object v0
.end method
