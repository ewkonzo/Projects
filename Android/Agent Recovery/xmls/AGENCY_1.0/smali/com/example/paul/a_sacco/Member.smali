.class public Lcom/example/paul/a_sacco/Member;
.super Ljava/lang/Object;
.source "Member.java"


# instance fields
.field public Society:Ljava/lang/String;

.field public accounts:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List",
            "<",
            "Lcom/example/paul/a_sacco/Account;",
            ">;"
        }
    .end annotation
.end field

.field public id_no:Ljava/lang/String;

.field public loans:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List",
            "<",
            "Lcom/example/paul/a_sacco/Loans;",
            ">;"
        }
    .end annotation
.end field

.field public message:Ljava/lang/String;

.field public name:Ljava/lang/String;

.field public pin:Ljava/lang/String;

.field public pin_changed:Z

.field public requestsuccessful:Z

.field public society_no:Ljava/lang/String;

.field public telephone:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 3

    .prologue
    .line 9
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Member;
    move-object v1, v0

    invoke-direct {v1}, Ljava/lang/Object;-><init>()V

    .line 10
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Member;->id_no:Ljava/lang/String;

    .line 11
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Member;->name:Ljava/lang/String;

    .line 12
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Member;->telephone:Ljava/lang/String;

    .line 13
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Member;->accounts:Ljava/util/List;

    .line 15
    move-object v1, v0

    const/4 v2, 0x0

    iput-boolean v2, v1, Lcom/example/paul/a_sacco/Member;->pin_changed:Z

    .line 18
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Member;->loans:Ljava/util/List;

    .line 19
    move-object v1, v0

    const/4 v2, 0x1

    iput-boolean v2, v1, Lcom/example/paul/a_sacco/Member;->requestsuccessful:Z

    .line 20
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Member;->message:Ljava/lang/String;

    .line 21
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Member;->Society:Ljava/lang/String;

    .line 22
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Member;->society_no:Ljava/lang/String;

    return-void
.end method
