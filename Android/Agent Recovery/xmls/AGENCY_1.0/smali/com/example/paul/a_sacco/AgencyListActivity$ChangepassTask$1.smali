.class Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask$1;
.super Lcom/google/gson/reflect/TypeToken;
.source "AgencyListActivity.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;->doInBackground([Ljava/lang/Void;)Lcom/example/paul/a_sacco/Agent;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/gson/reflect/TypeToken",
        "<",
        "Lcom/example/paul/a_sacco/Agent;",
        ">;"
    }
.end annotation


# instance fields
.field final synthetic this$1:Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;


# direct methods
.method constructor <init>(Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;)V
    .locals 4

    .prologue
    .line 153
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask$1;
    move-object v1, p1

    move-object v2, v0

    move-object v3, v1

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask$1;->this$1:Lcom/example/paul/a_sacco/AgencyListActivity$ChangepassTask;

    move-object v2, v0

    invoke-direct {v2}, Lcom/google/gson/reflect/TypeToken;-><init>()V

    return-void
.end method
