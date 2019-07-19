.class final Lcom/example/paul/a_sacco/JsonParser$2;
.super Ljava/lang/Object;
.source "JsonParser.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/example/paul/a_sacco/JsonParser;->getJSONFromUrl(Landroid/app/Activity;Ljava/lang/String;)Ljava/lang/String;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x8
    name = null
.end annotation


# instance fields
.field final synthetic val$activity:Landroid/app/Activity;


# direct methods
.method constructor <init>(Landroid/app/Activity;)V
    .locals 4

    .prologue
    .line 74
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/JsonParser$2;
    move-object v1, p1

    move-object v2, v0

    move-object v3, v1

    iput-object v3, v2, Lcom/example/paul/a_sacco/JsonParser$2;->val$activity:Landroid/app/Activity;

    move-object v2, v0

    invoke-direct {v2}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 4

    .prologue
    .line 77
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/JsonParser$2;
    move-object v1, v0

    iget-object v1, v1, Lcom/example/paul/a_sacco/JsonParser$2;->val$activity:Landroid/app/Activity;

    const-string v2, "Unable to connect to host, please check your connection"

    const/4 v3, 0x1

    invoke-static {v1, v2, v3}, Landroid/widget/Toast;->makeText(Landroid/content/Context;Ljava/lang/CharSequence;I)Landroid/widget/Toast;

    move-result-object v1

    invoke-virtual {v1}, Landroid/widget/Toast;->show()V

    .line 78
    return-void
.end method
