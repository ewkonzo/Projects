.class public Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;
.super Landroid/os/AsyncTask;
.source "AgencyDetailFragment.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/example/paul/a_sacco/AgencyDetailFragment;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1
    name = "TransactionrequestTask"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Landroid/os/AsyncTask",
        "<",
        "Ljava/lang/Void;",
        "Ljava/lang/Void;",
        "Lcom/example/paul/a_sacco/Transaction;",
        ">;"
    }
.end annotation


# instance fields
.field private final dialog:Landroid/app/ProgressDialog;

.field final synthetic this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

.field private tr:Lcom/example/paul/a_sacco/Transaction;


# direct methods
.method constructor <init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;Lcom/example/paul/a_sacco/Transaction;)V
    .locals 8

    .prologue
    .line 1097
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;
    move-object v1, p1

    move-object v2, p2

    .local v2, "trs":Lcom/example/paul/a_sacco/Transaction;
    move-object v3, v0

    move-object v4, v1

    iput-object v4, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object v3, v0

    invoke-direct {v3}, Landroid/os/AsyncTask;-><init>()V

    .line 1094
    move-object v3, v0

    new-instance v4, Landroid/app/ProgressDialog;

    move-object v7, v4

    move-object v4, v7

    move-object v5, v7

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    invoke-virtual {v6}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object v6

    invoke-direct {v5, v6}, Landroid/app/ProgressDialog;-><init>(Landroid/content/Context;)V

    iput-object v4, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->dialog:Landroid/app/ProgressDialog;

    .line 1101
    move-object v3, v0

    move-object v4, v2

    iput-object v4, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->tr:Lcom/example/paul/a_sacco/Transaction;

    .line 1102
    return-void
.end method


# virtual methods
.method protected varargs doInBackground([Ljava/lang/Void;)Lcom/example/paul/a_sacco/Transaction;
    .locals 11

    .prologue
    .line 1111
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;
    move-object v1, p1

    .local v1, "params":[Ljava/lang/Void;
    :try_start_0
    new-instance v6, Lcom/google/gson/Gson;

    move-object v10, v6

    move-object v6, v10

    move-object v7, v10

    invoke-direct {v7}, Lcom/google/gson/Gson;-><init>()V

    move-object v2, v6

    .line 1112
    .local v2, "gson":Lcom/google/gson/Gson;
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->tr:Lcom/example/paul/a_sacco/Transaction;

    const/4 v7, 0x0

    iput-object v7, v6, Lcom/example/paul/a_sacco/Transaction;->message:Ljava/lang/String;

    .line 1113
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->tr:Lcom/example/paul/a_sacco/Transaction;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    if-eqz v6, :cond_0

    .line 1114
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->tr:Lcom/example/paul/a_sacco/Transaction;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    if-eqz v6, :cond_0

    .line 1115
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->tr:Lcom/example/paul/a_sacco/Transaction;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->tr:Lcom/example/paul/a_sacco/Transaction;

    iget-object v7, v7, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    iget-object v7, v7, Lcom/example/paul/a_sacco/Account;->Account_Name:Ljava/lang/String;

    iput-object v7, v6, Lcom/example/paul/a_sacco/Member;->name:Ljava/lang/String;

    .line 1116
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->tr:Lcom/example/paul/a_sacco/Transaction;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->tr:Lcom/example/paul/a_sacco/Transaction;

    iget-object v7, v7, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    iget-object v7, v7, Lcom/example/paul/a_sacco/Account;->Telephone:Ljava/lang/String;

    iput-object v7, v6, Lcom/example/paul/a_sacco/Member;->telephone:Ljava/lang/String;

    .line 1118
    :cond_0
    move-object v6, v2

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->tr:Lcom/example/paul/a_sacco/Transaction;

    invoke-virtual {v6, v7}, Lcom/google/gson/Gson;->toJson(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v6

    move-object v3, v6

    .line 1120
    .local v3, "jsondata":Ljava/lang/String;
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    invoke-virtual {v6}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getActivity()Landroid/support/v4/app/FragmentActivity;

    move-result-object v6

    const-string v7, "Transactions"

    move-object v8, v3

    const-string v9, "data"

    invoke-static {v6, v7, v8, v9}, Lcom/example/paul/a_sacco/JsonParser;->SendHttpPost(Landroid/app/Activity;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    move-object v4, v6

    .line 1122
    .local v4, "json":Ljava/lang/String;
    new-instance v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$1;

    move-object v10, v6

    move-object v6, v10

    move-object v7, v10

    move-object v8, v0

    invoke-direct {v7, v8}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$1;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;)V

    invoke-virtual {v6}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$1;->getType()Ljava/lang/reflect/Type;

    move-result-object v6

    move-object v5, v6

    .line 1125
    .local v5, "collectionType":Ljava/lang/reflect/Type;
    move-object v6, v0

    new-instance v7, Lcom/google/gson/Gson;

    move-object v10, v7

    move-object v7, v10

    move-object v8, v10

    invoke-direct {v8}, Lcom/google/gson/Gson;-><init>()V

    move-object v8, v4

    move-object v9, v5

    invoke-virtual {v7, v8, v9}, Lcom/google/gson/Gson;->fromJson(Ljava/lang/String;Ljava/lang/reflect/Type;)Ljava/lang/Object;

    move-result-object v7

    check-cast v7, Lcom/example/paul/a_sacco/Transaction;

    iput-object v7, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->tr:Lcom/example/paul/a_sacco/Transaction;

    .line 1127
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->tr:Lcom/example/paul/a_sacco/Transaction;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-object v0, v6

    .line 1134
    .end local v0    # "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;
    .end local v2    # "gson":Lcom/google/gson/Gson;
    .end local v3    # "jsondata":Ljava/lang/String;
    .end local v4    # "json":Ljava/lang/String;
    .end local v5    # "collectionType":Ljava/lang/reflect/Type;
    :goto_0
    return-object v0

    .line 1128
    .restart local v0    # "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;
    :catch_0
    move-exception v6

    move-object v2, v6

    .line 1129
    .local v2, "e":Ljava/lang/Exception;
    move-object v6, v2

    invoke-virtual {v6}, Ljava/lang/Exception;->printStackTrace()V

    .line 1130
    move-object v6, v2

    invoke-virtual {v6}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v6

    const-string v7, "Connection to"

    invoke-virtual {v6, v7}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v6

    if-eqz v6, :cond_1

    .line 1131
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->tr:Lcom/example/paul/a_sacco/Transaction;

    const-string v7, "No Connection, make sure that your mobile data is enabled, or you are on a wifi."

    iput-object v7, v6, Lcom/example/paul/a_sacco/Transaction;->message:Ljava/lang/String;

    .line 1134
    :goto_1
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->tr:Lcom/example/paul/a_sacco/Transaction;

    move-object v0, v6

    goto :goto_0

    .line 1133
    :cond_1
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->tr:Lcom/example/paul/a_sacco/Transaction;

    move-object v7, v2

    invoke-virtual {v7}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v7

    iput-object v7, v6, Lcom/example/paul/a_sacco/Transaction;->message:Ljava/lang/String;

    goto :goto_1
.end method

.method protected bridge synthetic doInBackground([Ljava/lang/Object;)Ljava/lang/Object;
    .locals 4

    .prologue
    .line 1093
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;
    move-object v1, p1

    .local v1, "x0":[Ljava/lang/Object;
    move-object v2, v0

    move-object v3, v1

    check-cast v3, [Ljava/lang/Void;

    invoke-virtual {v2, v3}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->doInBackground([Ljava/lang/Void;)Lcom/example/paul/a_sacco/Transaction;

    move-result-object v2

    move-object v0, v2

    .end local v0    # "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;
    return-object v0
.end method

.method protected onCancelled()V
    .locals 0

    .prologue
    .line 1389
    return-void
.end method

.method protected onPostExecute(Lcom/example/paul/a_sacco/Transaction;)V
    .locals 25

    .prologue
    .line 1140
    move-object/from16 v2, p0

    .local v2, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;
    move-object/from16 v3, p1

    .local v3, "suc":Lcom/example/paul/a_sacco/Transaction;
    move-object/from16 v17, v2

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->dialog:Landroid/app/ProgressDialog;

    move-object/from16 v17, v0

    invoke-virtual/range {v17 .. v17}, Landroid/app/ProgressDialog;->isShowing()Z

    move-result v17

    if-eqz v17, :cond_0

    .line 1141
    move-object/from16 v17, v2

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->dialog:Landroid/app/ProgressDialog;

    move-object/from16 v17, v0

    invoke-virtual/range {v17 .. v17}, Landroid/app/ProgressDialog;->dismiss()V

    .line 1143
    :cond_0
    move-object/from16 v17, v2

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v17, v0

    move-object/from16 v18, v3

    move-object/from16 v0, v18

    move-object/from16 v1, v17

    iput-object v0, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    .line 1144
    const/16 v17, 0x1

    move/from16 v4, v17

    .line 1145
    .local v4, "amountok":Z
    move-object/from16 v17, v2

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v17, v0

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v17, v0

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->status:Lcom/example/paul/a_sacco/Transaction$Status;

    move-object/from16 v17, v0

    sget-object v18, Lcom/example/paul/a_sacco/Transaction$Status;->Confirmation:Lcom/example/paul/a_sacco/Transaction$Status;

    move-object/from16 v0, v17

    move-object/from16 v1, v18

    if-ne v0, v1, :cond_4

    .line 1146
    move-object/from16 v17, v2

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v17, v0

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v17, v0

    sget-object v18, Lcom/example/paul/a_sacco/Transaction$Status;->Pending:Lcom/example/paul/a_sacco/Transaction$Status;

    move-object/from16 v0, v18

    move-object/from16 v1, v17

    iput-object v0, v1, Lcom/example/paul/a_sacco/Transaction;->status:Lcom/example/paul/a_sacco/Transaction$Status;

    .line 1147
    sget-object v17, Lcom/example/paul/a_sacco/AgencyDetailFragment$19;->$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype:[I

    move-object/from16 v18, v2

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    move-object/from16 v18, v0

    invoke-virtual/range {v18 .. v18}, Lcom/example/paul/a_sacco/Transaction$Transtype;->ordinal()I

    move-result v18

    aget v17, v17, v18

    packed-switch v17, :pswitch_data_0

    .line 1151
    move-object/from16 v17, v2

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v17, v0

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v17, v0

    move-object/from16 v0, v17

    iget-wide v0, v0, Lcom/example/paul/a_sacco/Transaction;->amount:D

    move-wide/from16 v17, v0

    move-object/from16 v19, v2

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-wide v0, v0, Lcom/example/paul/a_sacco/Transaction;->Minimun_Amount:D

    move-wide/from16 v19, v0

    cmpg-double v17, v17, v19

    if-gez v17, :cond_1

    .line 1152
    move-object/from16 v17, v2

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v17, v0

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->amount:Landroid/widget/EditText;

    move-object/from16 v17, v0

    if-eqz v17, :cond_1

    .line 1153
    move-object/from16 v17, v2

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v17, v0

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->amount:Landroid/widget/EditText;

    move-object/from16 v17, v0

    invoke-virtual/range {v17 .. v17}, Landroid/widget/EditText;->requestFocus()Z

    move-result v17

    .line 1154
    move-object/from16 v17, v2

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v17, v0

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->amount:Landroid/widget/EditText;

    move-object/from16 v17, v0

    new-instance v18, Ljava/lang/StringBuilder;

    move-object/from16 v24, v18

    move-object/from16 v18, v24

    move-object/from16 v19, v24

    invoke-direct/range {v19 .. v19}, Ljava/lang/StringBuilder;-><init>()V

    const-string v19, "Minimun Amount allowed is "

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    move-object/from16 v19, v2

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-wide v0, v0, Lcom/example/paul/a_sacco/Transaction;->Minimun_Amount:D

    move-wide/from16 v19, v0

    invoke-virtual/range {v18 .. v20}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    move-result-object v18

    invoke-virtual/range {v18 .. v18}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v18

    invoke-virtual/range {v17 .. v18}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 1155
    move-object/from16 v17, v2

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v17, v0

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v17, v0

    sget-object v18, Lcom/example/paul/a_sacco/Transaction$Status;->Pending:Lcom/example/paul/a_sacco/Transaction$Status;

    move-object/from16 v0, v18

    move-object/from16 v1, v17

    iput-object v0, v1, Lcom/example/paul/a_sacco/Transaction;->status:Lcom/example/paul/a_sacco/Transaction$Status;

    .line 1156
    const/16 v17, 0x0

    move/from16 v4, v17

    .line 1158
    :cond_1
    move-object/from16 v17, v2

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v17, v0

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v17, v0

    move-object/from16 v0, v17

    iget-wide v0, v0, Lcom/example/paul/a_sacco/Transaction;->amount:D

    move-wide/from16 v17, v0

    move-object/from16 v19, v2

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-wide v0, v0, Lcom/example/paul/a_sacco/Transaction;->Maximun_Amount:D

    move-wide/from16 v19, v0

    cmpl-double v17, v17, v19

    if-lez v17, :cond_2

    .line 1159
    move-object/from16 v17, v2

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v17, v0

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->amount:Landroid/widget/EditText;

    move-object/from16 v17, v0

    if-eqz v17, :cond_2

    .line 1160
    move-object/from16 v17, v2

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v17, v0

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->amount:Landroid/widget/EditText;

    move-object/from16 v17, v0

    invoke-virtual/range {v17 .. v17}, Landroid/widget/EditText;->requestFocus()Z

    move-result v17

    .line 1161
    move-object/from16 v17, v2

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v17, v0

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->amount:Landroid/widget/EditText;

    move-object/from16 v17, v0

    new-instance v18, Ljava/lang/StringBuilder;

    move-object/from16 v24, v18

    move-object/from16 v18, v24

    move-object/from16 v19, v24

    invoke-direct/range {v19 .. v19}, Ljava/lang/StringBuilder;-><init>()V

    const-string v19, "Maximun Amount allowed is "

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    move-object/from16 v19, v2

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-wide v0, v0, Lcom/example/paul/a_sacco/Transaction;->Maximun_Amount:D

    move-wide/from16 v19, v0

    invoke-virtual/range {v18 .. v20}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    move-result-object v18

    invoke-virtual/range {v18 .. v18}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v18

    invoke-virtual/range {v17 .. v18}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 1162
    const/16 v17, 0x0

    move/from16 v4, v17

    .line 1163
    move-object/from16 v17, v2

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v17, v0

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v17, v0

    sget-object v18, Lcom/example/paul/a_sacco/Transaction$Status;->Pending:Lcom/example/paul/a_sacco/Transaction$Status;

    move-object/from16 v0, v18

    move-object/from16 v1, v17

    iput-object v0, v1, Lcom/example/paul/a_sacco/Transaction;->status:Lcom/example/paul/a_sacco/Transaction$Status;

    .line 1168
    :cond_2
    :goto_0
    move/from16 v17, v4

    const/16 v18, 0x1

    move/from16 v0, v17

    move/from16 v1, v18

    if-ne v0, v1, :cond_3

    .line 1170
    move-object/from16 v17, v2

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v17, v0

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    move-object/from16 v17, v0

    invoke-virtual/range {v17 .. v17}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object v17

    invoke-static/range {v17 .. v17}, Landroid/view/LayoutInflater;->from(Landroid/content/Context;)Landroid/view/LayoutInflater;

    move-result-object v17

    move-object/from16 v5, v17

    .line 1171
    .local v5, "factory":Landroid/view/LayoutInflater;
    move-object/from16 v17, v5

    const v18, 0x7f03001d

    const/16 v19, 0x0

    invoke-virtual/range {v17 .. v19}, Landroid/view/LayoutInflater;->inflate(ILandroid/view/ViewGroup;)Landroid/view/View;

    move-result-object v17

    move-object/from16 v6, v17

    .line 1172
    .local v6, "textEntryView":Landroid/view/View;
    move-object/from16 v17, v6

    const v18, 0x7f09004d

    invoke-virtual/range {v17 .. v18}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v17

    check-cast v17, Landroid/widget/TextView;

    move-object/from16 v7, v17

    .line 1173
    .local v7, "trantype":Landroid/widget/TextView;
    move-object/from16 v17, v6

    const v18, 0x7f090046

    invoke-virtual/range {v17 .. v18}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v17

    check-cast v17, Landroid/widget/TextView;

    move-object/from16 v8, v17

    .line 1174
    .local v8, "acc":Landroid/widget/TextView;
    move-object/from16 v17, v6

    const v18, 0x7f09004e

    invoke-virtual/range {v17 .. v18}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v17

    check-cast v17, Landroid/widget/TableRow;

    move-object/from16 v9, v17

    .line 1175
    .local v9, "tramount":Landroid/widget/TableRow;
    move-object/from16 v17, v6

    const v18, 0x7f09004f

    invoke-virtual/range {v17 .. v18}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v17

    check-cast v17, Landroid/widget/TextView;

    move-object/from16 v10, v17

    .line 1176
    .local v10, "tamount":Landroid/widget/TextView;
    move-object/from16 v17, v6

    const v18, 0x7f090053

    invoke-virtual/range {v17 .. v18}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v17

    check-cast v17, Landroid/widget/TableRow;

    move-object/from16 v11, v17

    .line 1177
    .local v11, "trpin":Landroid/widget/TableRow;
    move-object/from16 v17, v6

    const v18, 0x7f090051

    invoke-virtual/range {v17 .. v18}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v17

    check-cast v17, Landroid/widget/TableRow;

    move-object/from16 v12, v17

    .line 1178
    .local v12, "trcode":Landroid/widget/TableRow;
    move-object/from16 v17, v6

    const v18, 0x7f090052

    invoke-virtual/range {v17 .. v18}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v17

    check-cast v17, Landroid/widget/EditText;

    move-object/from16 v13, v17

    .line 1179
    .local v13, "code":Landroid/widget/EditText;
    move-object/from16 v17, v6

    const v18, 0x7f090054

    invoke-virtual/range {v17 .. v18}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v17

    check-cast v17, Landroid/widget/EditText;

    move-object/from16 v14, v17

    .line 1181
    .local v14, "pin":Landroid/widget/EditText;
    move-object/from16 v17, v7

    move-object/from16 v18, v2

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    move-object/from16 v18, v0

    invoke-virtual/range {v18 .. v18}, Lcom/example/paul/a_sacco/Transaction$Transtype;->toString()Ljava/lang/String;

    move-result-object v18

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1183
    sget-object v17, Lcom/example/paul/a_sacco/AgencyDetailFragment$19;->$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype:[I

    move-object/from16 v18, v2

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    move-object/from16 v18, v0

    invoke-virtual/range {v18 .. v18}, Lcom/example/paul/a_sacco/Transaction$Transtype;->ordinal()I

    move-result v18

    aget v17, v17, v18

    packed-switch v17, :pswitch_data_1

    .line 1230
    :goto_1
    move-object/from16 v17, v10

    move-object/from16 v18, v2

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-wide v0, v0, Lcom/example/paul/a_sacco/Transaction;->amount:D

    move-wide/from16 v18, v0

    invoke-static/range {v18 .. v19}, Ljava/lang/String;->valueOf(D)Ljava/lang/String;

    move-result-object v18

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1231
    new-instance v17, Landroid/app/AlertDialog$Builder;

    move-object/from16 v24, v17

    move-object/from16 v17, v24

    move-object/from16 v18, v24

    move-object/from16 v19, v2

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    move-object/from16 v19, v0

    invoke-virtual/range {v19 .. v19}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object v19

    invoke-direct/range {v18 .. v19}, Landroid/app/AlertDialog$Builder;-><init>(Landroid/content/Context;)V

    move-object/from16 v15, v17

    .line 1232
    .local v15, "alert":Landroid/app/AlertDialog$Builder;
    move-object/from16 v17, v15

    const-string v18, "Client Confirmation"

    invoke-virtual/range {v17 .. v18}, Landroid/app/AlertDialog$Builder;->setTitle(Ljava/lang/CharSequence;)Landroid/app/AlertDialog$Builder;

    move-result-object v17

    .line 1233
    move-object/from16 v17, v15

    move-object/from16 v18, v6

    invoke-virtual/range {v17 .. v18}, Landroid/app/AlertDialog$Builder;->setView(Landroid/view/View;)Landroid/app/AlertDialog$Builder;

    move-result-object v17

    .line 1234
    move-object/from16 v17, v15

    const-string v18, "Ok"

    new-instance v19, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$2;

    move-object/from16 v24, v19

    move-object/from16 v19, v24

    move-object/from16 v20, v24

    move-object/from16 v21, v2

    invoke-direct/range {v20 .. v21}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$2;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;)V

    invoke-virtual/range {v17 .. v19}, Landroid/app/AlertDialog$Builder;->setPositiveButton(Ljava/lang/CharSequence;Landroid/content/DialogInterface$OnClickListener;)Landroid/app/AlertDialog$Builder;

    move-result-object v17

    .line 1238
    move-object/from16 v17, v15

    const-string v18, "Cancel"

    new-instance v19, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$3;

    move-object/from16 v24, v19

    move-object/from16 v19, v24

    move-object/from16 v20, v24

    move-object/from16 v21, v2

    invoke-direct/range {v20 .. v21}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$3;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;)V

    invoke-virtual/range {v17 .. v19}, Landroid/app/AlertDialog$Builder;->setNegativeButton(Ljava/lang/CharSequence;Landroid/content/DialogInterface$OnClickListener;)Landroid/app/AlertDialog$Builder;

    move-result-object v17

    .line 1242
    move-object/from16 v17, v15

    invoke-virtual/range {v17 .. v17}, Landroid/app/AlertDialog$Builder;->create()Landroid/app/AlertDialog;

    move-result-object v17

    move-object/from16 v16, v17

    .line 1245
    .local v16, "dialog":Landroid/app/AlertDialog;
    move-object/from16 v17, v16

    invoke-virtual/range {v17 .. v17}, Landroid/app/AlertDialog;->show()V

    .line 1246
    move-object/from16 v17, v16

    const/16 v18, -0x1

    invoke-virtual/range {v17 .. v18}, Landroid/app/AlertDialog;->getButton(I)Landroid/widget/Button;

    move-result-object v17

    new-instance v18, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;

    move-object/from16 v24, v18

    move-object/from16 v18, v24

    move-object/from16 v19, v24

    move-object/from16 v20, v2

    move-object/from16 v21, v13

    move-object/from16 v22, v14

    move-object/from16 v23, v16

    invoke-direct/range {v19 .. v23}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$4;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;Landroid/widget/EditText;Landroid/widget/EditText;Landroid/app/AlertDialog;)V

    invoke-virtual/range {v17 .. v18}, Landroid/widget/Button;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    .line 1305
    move-object/from16 v17, v16

    const/16 v18, -0x2

    invoke-virtual/range {v17 .. v18}, Landroid/app/AlertDialog;->getButton(I)Landroid/widget/Button;

    move-result-object v17

    new-instance v18, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$5;

    move-object/from16 v24, v18

    move-object/from16 v18, v24

    move-object/from16 v19, v24

    move-object/from16 v20, v2

    move-object/from16 v21, v16

    invoke-direct/range {v19 .. v21}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$5;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;Landroid/app/AlertDialog;)V

    invoke-virtual/range {v17 .. v18}, Landroid/widget/Button;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    .line 1312
    .line 1384
    .end local v5    # "factory":Landroid/view/LayoutInflater;
    .end local v6    # "textEntryView":Landroid/view/View;
    .end local v7    # "trantype":Landroid/widget/TextView;
    .end local v8    # "acc":Landroid/widget/TextView;
    .end local v9    # "tramount":Landroid/widget/TableRow;
    .end local v10    # "tamount":Landroid/widget/TextView;
    .end local v11    # "trpin":Landroid/widget/TableRow;
    .end local v12    # "trcode":Landroid/widget/TableRow;
    .end local v13    # "code":Landroid/widget/EditText;
    .end local v14    # "pin":Landroid/widget/EditText;
    .end local v15    # "alert":Landroid/app/AlertDialog$Builder;
    .end local v16    # "dialog":Landroid/app/AlertDialog;
    :cond_3
    :goto_2
    return-void

    .line 1149
    :pswitch_0
    goto/16 :goto_0

    .line 1187
    .restart local v5    # "factory":Landroid/view/LayoutInflater;
    .restart local v6    # "textEntryView":Landroid/view/View;
    .restart local v7    # "trantype":Landroid/widget/TextView;
    .restart local v8    # "acc":Landroid/widget/TextView;
    .restart local v9    # "tramount":Landroid/widget/TableRow;
    .restart local v10    # "tamount":Landroid/widget/TextView;
    .restart local v11    # "trpin":Landroid/widget/TableRow;
    .restart local v12    # "trcode":Landroid/widget/TableRow;
    .restart local v13    # "code":Landroid/widget/EditText;
    .restart local v14    # "pin":Landroid/widget/EditText;
    :pswitch_1
    move-object/from16 v17, v11

    const/16 v18, 0x8

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TableRow;->setVisibility(I)V

    .line 1188
    move-object/from16 v17, v12

    const/16 v18, 0x8

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TableRow;->setVisibility(I)V

    .line 1189
    move-object/from16 v17, v8

    new-instance v18, Ljava/lang/StringBuilder;

    move-object/from16 v24, v18

    move-object/from16 v18, v24

    move-object/from16 v19, v24

    invoke-direct/range {v19 .. v19}, Ljava/lang/StringBuilder;-><init>()V

    move-object/from16 v19, v2

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Account;->Account_No:Ljava/lang/String;

    move-object/from16 v19, v0

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    const-string v19, "\n"

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    move-object/from16 v19, v2

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Account;->Account_Name:Ljava/lang/String;

    move-object/from16 v19, v0

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    invoke-virtual/range {v18 .. v18}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v18

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1190
    goto/16 :goto_1

    .line 1195
    :pswitch_2
    move-object/from16 v17, v8

    move-object/from16 v18, v2

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/Account;->Account_No:Ljava/lang/String;

    move-object/from16 v18, v0

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1196
    goto/16 :goto_1

    .line 1199
    :pswitch_3
    move-object/from16 v17, v9

    const/16 v18, 0x8

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TableRow;->setVisibility(I)V

    .line 1200
    move-object/from16 v17, v8

    move-object/from16 v18, v2

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/Account;->Account_No:Ljava/lang/String;

    move-object/from16 v18, v0

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1201
    goto/16 :goto_1

    .line 1204
    :pswitch_4
    move-object/from16 v17, v11

    const/16 v18, 0x8

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TableRow;->setVisibility(I)V

    .line 1205
    move-object/from16 v17, v12

    const/16 v18, 0x8

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TableRow;->setVisibility(I)V

    .line 1206
    move-object/from16 v17, v8

    move-object/from16 v18, v2

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->loan_no:Lcom/example/paul/a_sacco/Loans;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/Loans;->Loan_No:Ljava/lang/String;

    move-object/from16 v18, v0

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1207
    goto/16 :goto_1

    .line 1210
    :pswitch_5
    move-object/from16 v17, v8

    new-instance v18, Ljava/lang/StringBuilder;

    move-object/from16 v24, v18

    move-object/from16 v18, v24

    move-object/from16 v19, v24

    invoke-direct/range {v19 .. v19}, Ljava/lang/StringBuilder;-><init>()V

    move-object/from16 v19, v2

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Account;->Account_No:Ljava/lang/String;

    move-object/from16 v19, v0

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    const-string v19, " To "

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    move-object/from16 v19, v2

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->account_2:Lcom/example/paul/a_sacco/Account;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Account;->Account_No:Ljava/lang/String;

    move-object/from16 v19, v0

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    invoke-virtual/range {v18 .. v18}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v18

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1211
    goto/16 :goto_1

    .line 1214
    :pswitch_6
    move-object/from16 v17, v11

    const/16 v18, 0x8

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TableRow;->setVisibility(I)V

    .line 1215
    move-object/from16 v17, v8

    new-instance v18, Ljava/lang/StringBuilder;

    move-object/from16 v24, v18

    move-object/from16 v18, v24

    move-object/from16 v19, v24

    invoke-direct/range {v19 .. v19}, Ljava/lang/StringBuilder;-><init>()V

    move-object/from16 v19, v2

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Member;->name:Ljava/lang/String;

    move-object/from16 v19, v0

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    const-string v19, "\n"

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    move-object/from16 v19, v2

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Member;->id_no:Ljava/lang/String;

    move-object/from16 v19, v0

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    const-string v19, "\n"

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    move-object/from16 v19, v2

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Member;->telephone:Ljava/lang/String;

    move-object/from16 v19, v0

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    invoke-virtual/range {v18 .. v18}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v18

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1216
    goto/16 :goto_1

    .line 1219
    :pswitch_7
    move-object/from16 v17, v11

    const/16 v18, 0x8

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TableRow;->setVisibility(I)V

    .line 1220
    move-object/from16 v17, v9

    const/16 v18, 0x8

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TableRow;->setVisibility(I)V

    .line 1221
    move-object/from16 v17, v8

    new-instance v18, Ljava/lang/StringBuilder;

    move-object/from16 v24, v18

    move-object/from16 v18, v24

    move-object/from16 v19, v24

    invoke-direct/range {v19 .. v19}, Ljava/lang/StringBuilder;-><init>()V

    move-object/from16 v19, v2

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Account;->Account_No:Ljava/lang/String;

    move-object/from16 v19, v0

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    const-string v19, "\n"

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    move-object/from16 v19, v2

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Account;->Account_Name:Ljava/lang/String;

    move-object/from16 v19, v0

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    const-string v19, "\n"

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    move-object/from16 v19, v2

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Account;->Telephone:Ljava/lang/String;

    move-object/from16 v19, v0

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    invoke-virtual/range {v18 .. v18}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v18

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1222
    goto/16 :goto_1

    .line 1225
    :pswitch_8
    move-object/from16 v17, v11

    const/16 v18, 0x8

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TableRow;->setVisibility(I)V

    .line 1226
    move-object/from16 v17, v8

    new-instance v18, Ljava/lang/StringBuilder;

    move-object/from16 v24, v18

    move-object/from16 v18, v24

    move-object/from16 v19, v24

    invoke-direct/range {v19 .. v19}, Ljava/lang/StringBuilder;-><init>()V

    move-object/from16 v19, v2

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Member;->name:Ljava/lang/String;

    move-object/from16 v19, v0

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    const-string v19, "\n"

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    move-object/from16 v19, v2

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Member;->id_no:Ljava/lang/String;

    move-object/from16 v19, v0

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    const-string v19, "\n"

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    move-object/from16 v19, v2

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Member;->telephone:Ljava/lang/String;

    move-object/from16 v19, v0

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    invoke-virtual/range {v18 .. v18}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v18

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    goto/16 :goto_1

    .line 1316
    .end local v5    # "factory":Landroid/view/LayoutInflater;
    .end local v6    # "textEntryView":Landroid/view/View;
    .end local v7    # "trantype":Landroid/widget/TextView;
    .end local v8    # "acc":Landroid/widget/TextView;
    .end local v9    # "tramount":Landroid/widget/TableRow;
    .end local v10    # "tamount":Landroid/widget/TextView;
    .end local v11    # "trpin":Landroid/widget/TableRow;
    .end local v12    # "trcode":Landroid/widget/TableRow;
    .end local v13    # "code":Landroid/widget/EditText;
    .end local v14    # "pin":Landroid/widget/EditText;
    :cond_4
    move-object/from16 v17, v2

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v17, v0

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    move-object/from16 v17, v0

    invoke-virtual/range {v17 .. v17}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object v17

    invoke-static/range {v17 .. v17}, Landroid/view/LayoutInflater;->from(Landroid/content/Context;)Landroid/view/LayoutInflater;

    move-result-object v17

    move-object/from16 v5, v17

    .line 1317
    .restart local v5    # "factory":Landroid/view/LayoutInflater;
    move-object/from16 v17, v5

    const v18, 0x7f030024

    const/16 v19, 0x0

    invoke-virtual/range {v17 .. v19}, Landroid/view/LayoutInflater;->inflate(ILandroid/view/ViewGroup;)Landroid/view/View;

    move-result-object v17

    move-object/from16 v6, v17

    .line 1318
    .restart local v6    # "textEntryView":Landroid/view/View;
    move-object/from16 v17, v6

    const v18, 0x7f090050

    invoke-virtual/range {v17 .. v18}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v17

    check-cast v17, Landroid/widget/TextView;

    move-object/from16 v7, v17

    .line 1319
    .local v7, "status":Landroid/widget/TextView;
    move-object/from16 v17, v6

    const v18, 0x7f09006b

    invoke-virtual/range {v17 .. v18}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v17

    check-cast v17, Landroid/widget/TextView;

    move-object/from16 v8, v17

    .line 1320
    .local v8, "errors":Landroid/widget/TextView;
    move-object/from16 v17, v6

    const v18, 0x7f09004d

    invoke-virtual/range {v17 .. v18}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v17

    check-cast v17, Landroid/widget/TextView;

    move-object/from16 v9, v17

    .line 1321
    .local v9, "trantype":Landroid/widget/TextView;
    move-object/from16 v17, v6

    const v18, 0x7f090046

    invoke-virtual/range {v17 .. v18}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v17

    check-cast v17, Landroid/widget/TextView;

    move-object/from16 v10, v17

    .line 1322
    .local v10, "acc":Landroid/widget/TextView;
    move-object/from16 v17, v6

    const v18, 0x7f09004f

    invoke-virtual/range {v17 .. v18}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v17

    check-cast v17, Landroid/widget/TextView;

    move-object/from16 v11, v17

    .line 1323
    .local v11, "tramount":Landroid/widget/TextView;
    move-object/from16 v17, v6

    const v18, 0x7f090072

    invoke-virtual/range {v17 .. v18}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v17

    check-cast v17, Landroid/widget/TextView;

    move-object/from16 v12, v17

    .line 1324
    .local v12, "reference":Landroid/widget/TextView;
    move-object/from16 v17, v6

    const v18, 0x7f09004e

    invoke-virtual/range {v17 .. v18}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v17

    check-cast v17, Landroid/widget/TableRow;

    move-object/from16 v13, v17

    .line 1325
    .local v13, "tamount":Landroid/widget/TableRow;
    move-object/from16 v17, v12

    move-object/from16 v18, v2

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->reference:Ljava/lang/String;

    move-object/from16 v18, v0

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1327
    move-object/from16 v17, v7

    move-object/from16 v18, v2

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->status:Lcom/example/paul/a_sacco/Transaction$Status;

    move-object/from16 v18, v0

    invoke-virtual/range {v18 .. v18}, Lcom/example/paul/a_sacco/Transaction$Status;->toString()Ljava/lang/String;

    move-result-object v18

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1328
    move-object/from16 v17, v9

    move-object/from16 v18, v2

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    move-object/from16 v18, v0

    invoke-virtual/range {v18 .. v18}, Lcom/example/paul/a_sacco/Transaction$Transtype;->toString()Ljava/lang/String;

    move-result-object v18

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1329
    sget-object v17, Lcom/example/paul/a_sacco/AgencyDetailFragment$19;->$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype:[I

    move-object/from16 v18, v2

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    move-object/from16 v18, v0

    invoke-virtual/range {v18 .. v18}, Lcom/example/paul/a_sacco/Transaction$Transtype;->ordinal()I

    move-result v18

    aget v17, v17, v18

    packed-switch v17, :pswitch_data_2

    .line 1357
    :goto_3
    :pswitch_9
    move-object/from16 v17, v11

    move-object/from16 v18, v2

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-wide v0, v0, Lcom/example/paul/a_sacco/Transaction;->amount:D

    move-wide/from16 v18, v0

    invoke-static/range {v18 .. v19}, Ljava/lang/String;->valueOf(D)Ljava/lang/String;

    move-result-object v18

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1358
    move-object/from16 v17, v2

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v17, v0

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v17, v0

    move-object/from16 v0, v17

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->message:Ljava/lang/String;

    move-object/from16 v17, v0

    if-eqz v17, :cond_5

    .line 1359
    move-object/from16 v17, v8

    move-object/from16 v18, v2

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->message:Ljava/lang/String;

    move-object/from16 v18, v0

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1360
    :cond_5
    new-instance v17, Landroid/app/AlertDialog$Builder;

    move-object/from16 v24, v17

    move-object/from16 v17, v24

    move-object/from16 v18, v24

    move-object/from16 v19, v2

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    move-object/from16 v19, v0

    invoke-virtual/range {v19 .. v19}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object v19

    invoke-direct/range {v18 .. v19}, Landroid/app/AlertDialog$Builder;-><init>(Landroid/content/Context;)V

    move-object/from16 v14, v17

    .line 1361
    .local v14, "alert":Landroid/app/AlertDialog$Builder;
    move-object/from16 v17, v14

    const-string v18, "RESULTS"

    invoke-virtual/range {v17 .. v18}, Landroid/app/AlertDialog$Builder;->setTitle(Ljava/lang/CharSequence;)Landroid/app/AlertDialog$Builder;

    move-result-object v17

    .line 1362
    move-object/from16 v17, v14

    move-object/from16 v18, v6

    invoke-virtual/range {v17 .. v18}, Landroid/app/AlertDialog$Builder;->setView(Landroid/view/View;)Landroid/app/AlertDialog$Builder;

    move-result-object v17

    .line 1363
    move-object/from16 v17, v14

    const-string v18, "Ok"

    new-instance v19, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$6;

    move-object/from16 v24, v19

    move-object/from16 v19, v24

    move-object/from16 v20, v24

    move-object/from16 v21, v2

    invoke-direct/range {v20 .. v21}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$6;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;)V

    invoke-virtual/range {v17 .. v19}, Landroid/app/AlertDialog$Builder;->setPositiveButton(Ljava/lang/CharSequence;Landroid/content/DialogInterface$OnClickListener;)Landroid/app/AlertDialog$Builder;

    move-result-object v17

    .line 1368
    move-object/from16 v17, v14

    invoke-virtual/range {v17 .. v17}, Landroid/app/AlertDialog$Builder;->create()Landroid/app/AlertDialog;

    move-result-object v17

    move-object/from16 v15, v17

    .line 1369
    .local v15, "dialog":Landroid/app/AlertDialog;
    move-object/from16 v17, v15

    invoke-virtual/range {v17 .. v17}, Landroid/app/AlertDialog;->show()V

    .line 1370
    move-object/from16 v17, v15

    const/16 v18, -0x1

    invoke-virtual/range {v17 .. v18}, Landroid/app/AlertDialog;->getButton(I)Landroid/widget/Button;

    move-result-object v17

    new-instance v18, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$7;

    move-object/from16 v24, v18

    move-object/from16 v18, v24

    move-object/from16 v19, v24

    move-object/from16 v20, v2

    move-object/from16 v21, v15

    invoke-direct/range {v19 .. v21}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask$7;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;Landroid/app/AlertDialog;)V

    invoke-virtual/range {v17 .. v18}, Landroid/widget/Button;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    goto/16 :goto_2

    .line 1334
    .end local v14    # "alert":Landroid/app/AlertDialog$Builder;
    .end local v15    # "dialog":Landroid/app/AlertDialog;
    :pswitch_a
    move-object/from16 v17, v10

    move-object/from16 v18, v2

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/Account;->Account_No:Ljava/lang/String;

    move-object/from16 v18, v0

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1335
    goto/16 :goto_3

    .line 1338
    :pswitch_b
    move-object/from16 v17, v10

    move-object/from16 v18, v2

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->loan_no:Lcom/example/paul/a_sacco/Loans;

    move-object/from16 v18, v0

    move-object/from16 v0, v18

    iget-object v0, v0, Lcom/example/paul/a_sacco/Loans;->Loan_No:Ljava/lang/String;

    move-object/from16 v18, v0

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1339
    goto/16 :goto_3

    .line 1342
    :pswitch_c
    move-object/from16 v17, v10

    new-instance v18, Ljava/lang/StringBuilder;

    move-object/from16 v24, v18

    move-object/from16 v18, v24

    move-object/from16 v19, v24

    invoke-direct/range {v19 .. v19}, Ljava/lang/StringBuilder;-><init>()V

    move-object/from16 v19, v2

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Account;->Account_No:Ljava/lang/String;

    move-object/from16 v19, v0

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    const-string v19, " To "

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    move-object/from16 v19, v2

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->account_2:Lcom/example/paul/a_sacco/Account;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Account;->Account_No:Ljava/lang/String;

    move-object/from16 v19, v0

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    invoke-virtual/range {v18 .. v18}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v18

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1343
    goto/16 :goto_3

    .line 1346
    :pswitch_d
    move-object/from16 v17, v10

    new-instance v18, Ljava/lang/StringBuilder;

    move-object/from16 v24, v18

    move-object/from16 v18, v24

    move-object/from16 v19, v24

    invoke-direct/range {v19 .. v19}, Ljava/lang/StringBuilder;-><init>()V

    move-object/from16 v19, v2

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Member;->name:Ljava/lang/String;

    move-object/from16 v19, v0

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    const-string v19, "\n"

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    move-object/from16 v19, v2

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Member;->id_no:Ljava/lang/String;

    move-object/from16 v19, v0

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    const-string v19, "\n"

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    move-object/from16 v19, v2

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Member;->telephone:Ljava/lang/String;

    move-object/from16 v19, v0

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    invoke-virtual/range {v18 .. v18}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v18

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1347
    goto/16 :goto_3

    .line 1350
    :pswitch_e
    move-object/from16 v17, v13

    const/16 v18, 0x8

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TableRow;->setVisibility(I)V

    .line 1351
    move-object/from16 v17, v10

    new-instance v18, Ljava/lang/StringBuilder;

    move-object/from16 v24, v18

    move-object/from16 v18, v24

    move-object/from16 v19, v24

    invoke-direct/range {v19 .. v19}, Ljava/lang/StringBuilder;-><init>()V

    move-object/from16 v19, v2

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Account;->Account_No:Ljava/lang/String;

    move-object/from16 v19, v0

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    const-string v19, "\n"

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    move-object/from16 v19, v2

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Account;->Account_Name:Ljava/lang/String;

    move-object/from16 v19, v0

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    const-string v19, "\n"

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    move-object/from16 v19, v2

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    move-object/from16 v19, v0

    move-object/from16 v0, v19

    iget-object v0, v0, Lcom/example/paul/a_sacco/Account;->Telephone:Ljava/lang/String;

    move-object/from16 v19, v0

    invoke-virtual/range {v18 .. v19}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v18

    invoke-virtual/range {v18 .. v18}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v18

    invoke-virtual/range {v17 .. v18}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    goto/16 :goto_3

    .line 1147
    nop

    :pswitch_data_0
    .packed-switch 0x5
        :pswitch_0
    .end packed-switch

    .line 1183
    :pswitch_data_1
    .packed-switch 0x2
        :pswitch_5
        :pswitch_3
        :pswitch_3
        :pswitch_7
        :pswitch_2
        :pswitch_1
        :pswitch_1
        :pswitch_4
        :pswitch_6
        :pswitch_8
    .end packed-switch

    .line 1329
    :pswitch_data_2
    .packed-switch 0x2
        :pswitch_c
        :pswitch_a
        :pswitch_a
        :pswitch_e
        :pswitch_a
        :pswitch_a
        :pswitch_9
        :pswitch_b
        :pswitch_d
    .end packed-switch
.end method

.method protected bridge synthetic onPostExecute(Ljava/lang/Object;)V
    .locals 4

    .prologue
    .line 1093
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;
    move-object v1, p1

    .local v1, "x0":Ljava/lang/Object;
    move-object v2, v0

    move-object v3, v1

    check-cast v3, Lcom/example/paul/a_sacco/Transaction;

    invoke-virtual {v2, v3}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->onPostExecute(Lcom/example/paul/a_sacco/Transaction;)V

    return-void
.end method

.method protected onPreExecute()V
    .locals 3

    .prologue
    .line 1104
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;
    move-object v1, v0

    iget-object v1, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->dialog:Landroid/app/ProgressDialog;

    const-string v2, "Processing request..."

    invoke-virtual {v1, v2}, Landroid/app/ProgressDialog;->setMessage(Ljava/lang/CharSequence;)V

    .line 1105
    move-object v1, v0

    iget-object v1, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->dialog:Landroid/app/ProgressDialog;

    invoke-virtual {v1}, Landroid/app/ProgressDialog;->show()V

    .line 1106
    return-void
.end method
