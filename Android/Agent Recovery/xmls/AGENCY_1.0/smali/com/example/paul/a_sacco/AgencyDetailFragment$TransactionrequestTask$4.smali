.class Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;
.super Ljava/lang/Object;
.source "AgencyDetailFragment.java"

# interfaces
.implements Landroid/view/View$OnClickListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->onPostExecute(Lcom/example/paul/a_sacco/Transaction;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;

.field final synthetic val$code:Landroid/widget/EditText;

.field final synthetic val$dialog:Landroid/app/AlertDialog;

.field final synthetic val$pin:Landroid/widget/EditText;


# direct methods
.method constructor <init>(Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;Landroid/widget/EditText;Landroid/widget/EditText;Landroid/app/AlertDialog;)V
    .locals 7

    .prologue
    .line 1246
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;
    move-object v1, p1

    move-object v2, p2

    move-object v3, p3

    move-object v4, p4

    move-object v5, v0

    move-object v6, v1

    iput-object v6, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;

    move-object v5, v0

    move-object v6, v2

    iput-object v6, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->val$code:Landroid/widget/EditText;

    move-object v5, v0

    move-object v6, v3

    iput-object v6, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->val$pin:Landroid/widget/EditText;

    move-object v5, v0

    move-object v6, v4

    iput-object v6, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->val$dialog:Landroid/app/AlertDialog;

    move-object v5, v0

    invoke-direct {v5}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onClick(Landroid/view/View;)V
    .locals 9

    .prologue
    .line 1249
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;
    move-object v1, p1

    .local v1, "v":Landroid/view/View;
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->val$code:Landroid/widget/EditText;

    invoke-virtual {v4}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v4

    move-object v2, v4

    .line 1250
    .local v2, "codes":Ljava/lang/String;
    sget-object v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$19;->$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype:[I

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v5, v5, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    invoke-virtual {v5}, Lcom/example/paul/a_sacco/Transaction$Transtype;->ordinal()I

    move-result v5

    aget v4, v4, v5

    packed-switch v4, :pswitch_data_0

    .line 1275
    :pswitch_0
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->val$code:Landroid/widget/EditText;

    const/4 v5, 0x0

    invoke-virtual {v4, v5}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 1276
    move-object v4, v2

    invoke-static {v4}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v4

    if-eqz v4, :cond_2

    .line 1277
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->val$code:Landroid/widget/EditText;

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const v6, 0x7f0c001b

    invoke-virtual {v5, v6}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getString(I)Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 1278
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->val$code:Landroid/widget/EditText;

    invoke-virtual {v4}, Landroid/widget/EditText;->requestFocus()Z

    move-result v4

    .line 1279
    .line 1303
    :goto_0
    return-void

    .line 1255
    .line 1300
    :cond_0
    :pswitch_1
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    sget-object v5, Lcom/example/paul/a_sacco/Transaction$Status;->Confirmation:Lcom/example/paul/a_sacco/Transaction$Status;

    iput-object v5, v4, Lcom/example/paul/a_sacco/Transaction;->status:Lcom/example/paul/a_sacco/Transaction$Status;

    .line 1301
    new-instance v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;

    move-object v8, v4

    move-object v4, v8

    move-object v5, v8

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    invoke-direct {v5, v6, v7}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;Lcom/example/paul/a_sacco/Transaction;)V

    const/4 v5, 0x0

    new-array v5, v5, [Ljava/lang/Void;

    invoke-virtual {v4, v5}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->execute([Ljava/lang/Object;)Landroid/os/AsyncTask;

    move-result-object v4

    .line 1302
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->val$dialog:Landroid/app/AlertDialog;

    invoke-virtual {v4}, Landroid/app/AlertDialog;->dismiss()V

    .line 1303
    goto :goto_0

    .line 1261
    :pswitch_2
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->val$code:Landroid/widget/EditText;

    const/4 v5, 0x0

    invoke-virtual {v4, v5}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 1262
    move-object v4, v2

    invoke-static {v4}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v4

    if-eqz v4, :cond_1

    .line 1263
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->val$code:Landroid/widget/EditText;

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const v6, 0x7f0c001b

    invoke-virtual {v5, v6}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getString(I)Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 1264
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->val$code:Landroid/widget/EditText;

    invoke-virtual {v4}, Landroid/widget/EditText;->requestFocus()Z

    move-result v4

    .line 1265
    goto :goto_0

    .line 1267
    :cond_1
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->val$code:Landroid/widget/EditText;

    invoke-virtual {v4}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v4

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v5, v5, Lcom/example/paul/a_sacco/Transaction;->code:Ljava/lang/String;

    invoke-virtual {v4, v5}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-nez v4, :cond_0

    .line 1268
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->val$code:Landroid/widget/EditText;

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const v6, 0x7f0c0018

    invoke-virtual {v5, v6}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getString(I)Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 1269
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->val$code:Landroid/widget/EditText;

    invoke-virtual {v4}, Landroid/widget/EditText;->requestFocus()Z

    move-result v4

    .line 1270
    goto/16 :goto_0

    .line 1281
    :cond_2
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->val$pin:Landroid/widget/EditText;

    const/4 v5, 0x0

    invoke-virtual {v4, v5}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 1282
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->val$pin:Landroid/widget/EditText;

    invoke-virtual {v4}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v4

    move-object v3, v4

    .line 1283
    .local v3, "pins":Ljava/lang/String;
    move-object v4, v3

    invoke-static {v4}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v4

    if-eqz v4, :cond_3

    .line 1284
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->val$pin:Landroid/widget/EditText;

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const v6, 0x7f0c001b

    invoke-virtual {v5, v6}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getString(I)Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 1285
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->val$pin:Landroid/widget/EditText;

    invoke-virtual {v4}, Landroid/widget/EditText;->requestFocus()Z

    move-result v4

    .line 1286
    goto/16 :goto_0

    .line 1288
    :cond_3
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->val$code:Landroid/widget/EditText;

    invoke-virtual {v4}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v4

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v5, v5, Lcom/example/paul/a_sacco/Transaction;->code:Ljava/lang/String;

    invoke-virtual {v4, v5}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-nez v4, :cond_4

    .line 1289
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->val$code:Landroid/widget/EditText;

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const v6, 0x7f0c0018

    invoke-virtual {v5, v6}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getString(I)Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 1290
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->val$code:Landroid/widget/EditText;

    invoke-virtual {v4}, Landroid/widget/EditText;->requestFocus()Z

    move-result v4

    .line 1291
    goto/16 :goto_0

    .line 1293
    :cond_4
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->val$pin:Landroid/widget/EditText;

    invoke-virtual {v4}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v4

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v5, v5, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    iget-object v5, v5, Lcom/example/paul/a_sacco/Member;->pin:Ljava/lang/String;

    invoke-virtual {v4, v5}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-nez v4, :cond_0

    .line 1294
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->val$pin:Landroid/widget/EditText;

    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->this$1:Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    const v6, 0x7f0c001f

    invoke-virtual {v5, v6}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getString(I)Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 1295
    move-object v4, v0

    iget-object v4, v4, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;->val$pin:Landroid/widget/EditText;

    invoke-virtual {v4}, Landroid/widget/EditText;->requestFocus()Z

    move-result v4

    .line 1296
    goto/16 :goto_0

    .line 1250
    nop

    :pswitch_data_0
    .packed-switch 0x5
        :pswitch_2
        :pswitch_0
        :pswitch_1
        :pswitch_1
        :pswitch_1
        :pswitch_2
        :pswitch_2
    .end packed-switch
.end method
