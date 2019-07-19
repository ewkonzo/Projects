.class public Lcom/example/paul/a_sacco/Database;
.super Landroid/database/sqlite/SQLiteOpenHelper;
.source "Database.java"


# static fields
.field static final dbName:Ljava/lang/String; = "Agency"


# direct methods
.method public constructor <init>(Landroid/content/Context;)V
    .locals 7

    .prologue
    .line 11
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Database;
    move-object v1, p1

    .local v1, "context":Landroid/content/Context;
    move-object v2, v0

    move-object v3, v1

    const-string v4, "Agency"

    const/4 v5, 0x0

    const/4 v6, 0x1

    invoke-direct {v2, v3, v4, v5, v6}, Landroid/database/sqlite/SQLiteOpenHelper;-><init>(Landroid/content/Context;Ljava/lang/String;Landroid/database/sqlite/SQLiteDatabase$CursorFactory;I)V

    .line 13
    return-void
.end method


# virtual methods
.method public onCreate(Landroid/database/sqlite/SQLiteDatabase;)V
    .locals 4

    .prologue
    .line 16
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Database;
    move-object v1, p1

    .local v1, "db":Landroid/database/sqlite/SQLiteDatabase;
    move-object v2, v1

    const-string v3, "CREATE TABLE Transactions (Id INTEGER PRIMARY KEY AUTOINCREMENT,Entry Text,Account_1 Text,Account_2 Text,member_1 Text,member_2 Text,Loan_No Text,Code Text,Amount decimaltransactiontype Text,agent Text,Telephone Text,Depositor Text,Maximun decimal,Minimun decimal,status Text )"

    invoke-virtual {v2, v3}, Landroid/database/sqlite/SQLiteDatabase;->execSQL(Ljava/lang/String;)V

    .line 33
    move-object v2, v1

    const-string v3, "CREATE TABLE Societies (id INTEGER PRIMARY KEY AUTOINCREMENT,Code Text,Name Text )"

    invoke-virtual {v2, v3}, Landroid/database/sqlite/SQLiteDatabase;->execSQL(Ljava/lang/String;)V

    .line 37
    return-void
.end method

.method public onUpgrade(Landroid/database/sqlite/SQLiteDatabase;II)V
    .locals 6

    .prologue
    .line 43
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Database;
    move-object v1, p1

    .local v1, "db":Landroid/database/sqlite/SQLiteDatabase;
    move v2, p2

    .local v2, "oldVersion":I
    move v3, p3

    .local v3, "newVersion":I
    move-object v4, v1

    const-string v5, "DROP TABLE IF EXISTS Transactions"

    invoke-virtual {v4, v5}, Landroid/database/sqlite/SQLiteDatabase;->execSQL(Ljava/lang/String;)V

    .line 44
    move-object v4, v1

    const-string v5, "DROP TABLE IF EXISTS Societies"

    invoke-virtual {v4, v5}, Landroid/database/sqlite/SQLiteDatabase;->execSQL(Ljava/lang/String;)V

    .line 45
    move-object v4, v0

    move-object v5, v1

    invoke-virtual {v4, v5}, Lcom/example/paul/a_sacco/Database;->onCreate(Landroid/database/sqlite/SQLiteDatabase;)V

    .line 46
    return-void
.end method
