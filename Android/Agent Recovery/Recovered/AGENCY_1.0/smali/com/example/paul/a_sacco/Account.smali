.class public Lcom/example/paul/a_sacco/Account;
.super Ljava/lang/Object;
.source "Account.java"


# instance fields
.field public Account_Balance:D

.field public Account_Name:Ljava/lang/String;

.field public Account_No:Ljava/lang/String;

.field public Account_ok:Z

.field public Account_type:Ljava/lang/String;

.field public Message:Ljava/lang/String;

.field public Selected:Z

.field public Telephone:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 4

    .prologue
    .line 3
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Account;
    move-object v1, v0

    invoke-direct {v1}, Ljava/lang/Object;-><init>()V

    .line 4
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Account;->Account_No:Ljava/lang/String;

    .line 5
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Account;->Account_Name:Ljava/lang/String;

    .line 6
    move-object v1, v0

    const-wide/16 v2, 0x0

    iput-wide v2, v1, Lcom/example/paul/a_sacco/Account;->Account_Balance:D

    .line 7
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Account;->Account_type:Ljava/lang/String;

    .line 8
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Account;->Telephone:Ljava/lang/String;

    .line 9
    move-object v1, v0

    const/4 v2, 0x0

    iput-boolean v2, v1, Lcom/example/paul/a_sacco/Account;->Selected:Z

    .line 10
    move-object v1, v0

    const/4 v2, 0x1

    iput-boolean v2, v1, Lcom/example/paul/a_sacco/Account;->Account_ok:Z

    .line 11
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Account;->Message:Ljava/lang/String;

    return-void
.end method
