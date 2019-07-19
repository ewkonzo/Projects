.class public Lcom/example/paul/a_sacco/Agent;
.super Ljava/lang/Object;
.source "Agent.java"


# instance fields
.field public Pin_changed:Z

.field public Telephone:Ljava/lang/String;

.field public account_balance:D

.field public agent_Account:Ljava/lang/String;

.field public agent_Name:Ljava/lang/String;

.field public agent_code:Ljava/lang/String;

.field public logged_in:Z

.field public message:Ljava/lang/String;

.field public new_pin:Ljava/lang/String;

.field public pin:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 4

    .prologue
    .line 2
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/Agent;
    move-object v1, v0

    invoke-direct {v1}, Ljava/lang/Object;-><init>()V

    .line 3
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Agent;->agent_code:Ljava/lang/String;

    .line 4
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Agent;->agent_Name:Ljava/lang/String;

    .line 5
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Agent;->agent_Account:Ljava/lang/String;

    .line 6
    move-object v1, v0

    const-wide/16 v2, 0x0

    iput-wide v2, v1, Lcom/example/paul/a_sacco/Agent;->account_balance:D

    .line 7
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Agent;->Telephone:Ljava/lang/String;

    .line 8
    move-object v1, v0

    const/4 v2, 0x0

    iput-boolean v2, v1, Lcom/example/paul/a_sacco/Agent;->logged_in:Z

    .line 9
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Agent;->pin:Ljava/lang/String;

    .line 10
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Agent;->message:Ljava/lang/String;

    .line 11
    move-object v1, v0

    const/4 v2, 0x0

    iput-boolean v2, v1, Lcom/example/paul/a_sacco/Agent;->Pin_changed:Z

    .line 12
    move-object v1, v0

    const/4 v2, 0x0

    iput-object v2, v1, Lcom/example/paul/a_sacco/Agent;->new_pin:Ljava/lang/String;

    return-void
.end method
