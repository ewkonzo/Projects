.class public Lcom/example/paul/a_sacco/Societies;
.super Ljava/lang/Object;
.source "Societies.java"


# static fields
.field static final Table:Ljava/lang/String; = "Societies"

.field static final colcode:Ljava/lang/String; = "Code"

.field static final colname:Ljava/lang/String; = "Name"


# instance fields
.field public code:Ljava/lang/String;

.field public memberid:Ljava/lang/String;

.field public name:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 3

    .prologue
    .line 14
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Societies;
    move-object v1, v0

    invoke-direct {v1}, Ljava/lang/Object;-><init>()V

    .line 17
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Societies;->memberid:Ljava/lang/String;

    return-void
.end method

.method public static AddSociety(Lcom/example/paul/a_sacco/Database;Lcom/example/paul/a_sacco/Societies;)Lcom/example/paul/a_sacco/Societies;
    .locals 10

    .prologue
    .line 26
    move-object v0, p0

    .local v0, "appdb":Lcom/example/paul/a_sacco/Database;
    move-object v1, p1

    .local v1, "data":Lcom/example/paul/a_sacco/Societies;
    move-object v4, v0

    invoke-virtual {v4}, Lcom/example/paul/a_sacco/Database;->getWritableDatabase()Landroid/database/sqlite/SQLiteDatabase;

    move-result-object v4

    move-object v2, v4

    .line 27
    .local v2, "db":Landroid/database/sqlite/SQLiteDatabase;
    new-instance v4, Landroid/content/ContentValues;

    move-object v9, v4

    move-object v4, v9

    move-object v5, v9

    invoke-direct {v5}, Landroid/content/ContentValues;-><init>()V

    move-object v3, v4

    .line 28
    .local v3, "cv":Landroid/content/ContentValues;
    move-object v4, v3

    const-string v5, "Code"

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Societies;->code:Ljava/lang/String;

    invoke-virtual {v4, v5, v6}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/String;)V

    .line 29
    move-object v4, v3

    const-string v5, "Name"

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Societies;->name:Ljava/lang/String;

    invoke-virtual {v4, v5, v6}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/String;)V

    .line 30
    move-object v4, v2

    const-string v5, "Societies"

    const-string v6, "Code"

    move-object v7, v3

    const/4 v8, 0x5

    invoke-virtual {v4, v5, v6, v7, v8}, Landroid/database/sqlite/SQLiteDatabase;->insertWithOnConflict(Ljava/lang/String;Ljava/lang/String;Landroid/content/ContentValues;I)J

    move-result-wide v4

    .line 32
    move-object v4, v2

    invoke-virtual {v4}, Landroid/database/sqlite/SQLiteDatabase;->close()V

    .line 33
    move-object v4, v1

    move-object v0, v4

    .end local v0    # "appdb":Lcom/example/paul/a_sacco/Database;
    return-object v0
.end method

.method public static getSocieties(Lcom/example/paul/a_sacco/Database;)Ljava/util/List;
    .locals 15
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/example/paul/a_sacco/Database;",
            ")",
            "Ljava/util/List",
            "<",
            "Lcom/example/paul/a_sacco/Societies;",
            ">;"
        }
    .end annotation

    .prologue
    .line 36
    move-object v0, p0

    .local v0, "appdb":Lcom/example/paul/a_sacco/Database;
    new-instance v6, Ljava/util/ArrayList;

    move-object v14, v6

    move-object v6, v14

    move-object v7, v14

    invoke-direct {v7}, Ljava/util/ArrayList;-><init>()V

    move-object v1, v6

    .line 37
    .local v1, "stock":Ljava/util/List;, "Ljava/util/List<Lcom/example/paul/a_sacco/Societies;>;"
    const/4 v6, 0x0

    move-object v2, v6

    .line 39
    .local v2, "cur":Landroid/database/Cursor;
    move-object v6, v0

    :try_start_0
    invoke-virtual {v6}, Lcom/example/paul/a_sacco/Database;->getWritableDatabase()Landroid/database/sqlite/SQLiteDatabase;

    move-result-object v6

    move-object v3, v6

    .line 40
    .local v3, "db":Landroid/database/sqlite/SQLiteDatabase;
    const/4 v6, 0x1

    new-array v6, v6, [Ljava/lang/String;

    move-object v14, v6

    move-object v6, v14

    move-object v7, v14

    const/4 v8, 0x0

    const-string v9, "*"

    aput-object v9, v7, v8

    move-object v4, v6

    .line 41
    .local v4, "columns":[Ljava/lang/String;
    move-object v6, v3

    const-string v7, "Societies"

    move-object v8, v4

    const/4 v9, 0x0

    const/4 v10, 0x0

    const/4 v11, 0x0

    const/4 v12, 0x0

    const/4 v13, 0x0

    invoke-virtual/range {v6 .. v13}, Landroid/database/sqlite/SQLiteDatabase;->query(Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Landroid/database/Cursor;

    move-result-object v6

    move-object v2, v6

    .line 42
    move-object v6, v2

    invoke-interface {v6}, Landroid/database/Cursor;->moveToFirst()Z

    move-result v6

    .line 44
    :cond_0
    new-instance v6, Lcom/example/paul/a_sacco/Societies;

    move-object v14, v6

    move-object v6, v14

    move-object v7, v14

    invoke-direct {v7}, Lcom/example/paul/a_sacco/Societies;-><init>()V

    move-object v5, v6

    .line 45
    .local v5, "s":Lcom/example/paul/a_sacco/Societies;
    move-object v6, v5

    move-object v7, v2

    move-object v8, v2

    const-string v9, "Code"

    invoke-interface {v8, v9}, Landroid/database/Cursor;->getColumnIndex(Ljava/lang/String;)I

    move-result v8

    invoke-interface {v7, v8}, Landroid/database/Cursor;->getString(I)Ljava/lang/String;

    move-result-object v7

    iput-object v7, v6, Lcom/example/paul/a_sacco/Societies;->code:Ljava/lang/String;

    .line 46
    move-object v6, v5

    move-object v7, v2

    move-object v8, v2

    const-string v9, "Name"

    invoke-interface {v8, v9}, Landroid/database/Cursor;->getColumnIndex(Ljava/lang/String;)I

    move-result v8

    invoke-interface {v7, v8}, Landroid/database/Cursor;->getString(I)Ljava/lang/String;

    move-result-object v7

    iput-object v7, v6, Lcom/example/paul/a_sacco/Societies;->name:Ljava/lang/String;

    .line 47
    move-object v6, v1

    move-object v7, v5

    invoke-interface {v6, v7}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    move-result v6

    .line 48
    move-object v6, v2

    invoke-interface {v6}, Landroid/database/Cursor;->moveToNext()Z
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result v6

    if-nez v6, :cond_0

    .line 56
    .line 57
    .end local v3    # "db":Landroid/database/sqlite/SQLiteDatabase;
    .end local v4    # "columns":[Ljava/lang/String;
    .end local v5    # "s":Lcom/example/paul/a_sacco/Societies;
    :goto_0
    move-object v6, v1

    move-object v0, v6

    .end local v0    # "appdb":Lcom/example/paul/a_sacco/Database;
    return-object v0

    .line 50
    .restart local v0    # "appdb":Lcom/example/paul/a_sacco/Database;
    :catch_0
    move-exception v6

    move-object v3, v6

    .line 51
    .local v3, "ex":Ljava/lang/Exception;
    move-object v6, v3

    invoke-virtual {v6}, Ljava/lang/Exception;->printStackTrace()V

    .line 52
    move-object v6, v3

    invoke-virtual {v6}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v6

    if-nez v6, :cond_1

    .line 53
    move-object v6, v3

    invoke-virtual {v6}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_0

    .line 55
    :cond_1
    move-object v6, v3

    invoke-virtual {v6}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v6

    move-object v7, v3

    invoke-virtual {v7}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v7

    invoke-static {v6, v7}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    move-result v6

    goto :goto_0
.end method


# virtual methods
.method public toString()Ljava/lang/String;
    .locals 2

    .prologue
    .line 23
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Societies;
    move-object v1, v0

    iget-object v1, v1, Lcom/example/paul/a_sacco/Societies;->name:Ljava/lang/String;

    move-object v0, v1

    .end local v0    # "this":Lcom/example/paul/a_sacco/Societies;
    return-object v0
.end method
