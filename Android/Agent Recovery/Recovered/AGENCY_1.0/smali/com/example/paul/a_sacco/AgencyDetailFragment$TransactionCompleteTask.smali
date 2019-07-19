.class public Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;
.super Landroid/os/AsyncTask;
.source "AgencyDetailFragment.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/example/paul/a_sacco/AgencyDetailFragment;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1
    name = "TransactionCompleteTask"
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
    .line 1396
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;
    move-object v1, p1

    move-object v2, p2

    .local v2, "trs":Lcom/example/paul/a_sacco/Transaction;
    move-object v3, v0

    move-object v4, v1

    iput-object v4, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object v3, v0

    invoke-direct {v3}, Landroid/os/AsyncTask;-><init>()V

    .line 1393
    move-object v3, v0

    new-instance v4, Landroid/app/ProgressDialog;

    move-object v7, v4

    move-object v4, v7

    move-object v5, v7

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    invoke-virtual {v6}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object v6

    invoke-direct {v5, v6}, Landroid/app/ProgressDialog;-><init>(Landroid/content/Context;)V

    iput-object v4, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->dialog:Landroid/app/ProgressDialog;

    .line 1397
    move-object v3, v0

    move-object v4, v2

    iput-object v4, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->tr:Lcom/example/paul/a_sacco/Transaction;

    .line 1398
    return-void
.end method


# virtual methods
.method protected varargs doInBackground([Ljava/lang/Void;)Lcom/example/paul/a_sacco/Transaction;
    .locals 11

    .prologue
    .line 1407
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;
    move-object v1, p1

    .local v1, "params":[Ljava/lang/Void;
    :try_start_0
    new-instance v6, Lcom/google/gson/Gson;

    move-object v10, v6

    move-object v6, v10

    move-object v7, v10

    invoke-direct {v7}, Lcom/google/gson/Gson;-><init>()V

    move-object v2, v6

    .line 1408
    .local v2, "gson":Lcom/google/gson/Gson;
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->tr:Lcom/example/paul/a_sacco/Transaction;

    const/4 v7, 0x0

    iput-object v7, v6, Lcom/example/paul/a_sacco/Transaction;->message:Ljava/lang/String;

    .line 1410
    move-object v6, v2

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->tr:Lcom/example/paul/a_sacco/Transaction;

    invoke-virtual {v6, v7}, Lcom/google/gson/Gson;->toJson(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v6

    move-object v3, v6

    .line 1412
    .local v3, "jsondata":Ljava/lang/String;
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    invoke-virtual {v6}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getActivity()Landroid/support/v4/app/FragmentActivity;

    move-result-object v6

    const-string v7, "Transactions"

    move-object v8, v3

    const-string v9, "data"

    invoke-static {v6, v7, v8, v9}, Lcom/example/paul/a_sacco/JsonParser;->SendHttpPost(Landroid/app/Activity;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    move-object v4, v6

    .line 1414
    .local v4, "json":Ljava/lang/String;
    new-instance v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask$1;

    move-object v10, v6

    move-object v6, v10

    move-object v7, v10

    move-object v8, v0

    invoke-direct {v7, v8}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask$1;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;)V

    invoke-virtual {v6}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask$1;->getType()Ljava/lang/reflect/Type;

    move-result-object v6

    move-object v5, v6

    .line 1417
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

    iput-object v7, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->tr:Lcom/example/paul/a_sacco/Transaction;

    .line 1419
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->tr:Lcom/example/paul/a_sacco/Transaction;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-object v0, v6

    .line 1426
    .end local v0    # "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;
    .end local v2    # "gson":Lcom/google/gson/Gson;
    .end local v3    # "jsondata":Ljava/lang/String;
    .end local v4    # "json":Ljava/lang/String;
    .end local v5    # "collectionType":Ljava/lang/reflect/Type;
    :goto_0
    return-object v0

    .line 1420
    .restart local v0    # "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;
    :catch_0
    move-exception v6

    move-object v2, v6

    .line 1421
    .local v2, "e":Ljava/lang/Exception;
    move-object v6, v2

    invoke-virtual {v6}, Ljava/lang/Exception;->printStackTrace()V

    .line 1422
    move-object v6, v2

    invoke-virtual {v6}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v6

    const-string v7, "Connection to"

    invoke-virtual {v6, v7}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v6

    if-eqz v6, :cond_0

    .line 1423
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->tr:Lcom/example/paul/a_sacco/Transaction;

    const-string v7, "No Connection, make sure that your mobile data is enabled, or you are on a wifi."

    iput-object v7, v6, Lcom/example/paul/a_sacco/Transaction;->message:Ljava/lang/String;

    .line 1426
    :goto_1
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->tr:Lcom/example/paul/a_sacco/Transaction;

    move-object v0, v6

    goto :goto_0

    .line 1425
    :cond_0
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->tr:Lcom/example/paul/a_sacco/Transaction;

    move-object v7, v2

    invoke-virtual {v7}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v7

    iput-object v7, v6, Lcom/example/paul/a_sacco/Transaction;->message:Ljava/lang/String;

    goto :goto_1
.end method

.method protected bridge synthetic doInBackground([Ljava/lang/Object;)Ljava/lang/Object;
    .locals 4

    .prologue
    .line 1392
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;
    move-object v1, p1

    .local v1, "x0":[Ljava/lang/Object;
    move-object v2, v0

    move-object v3, v1

    check-cast v3, [Ljava/lang/Void;

    invoke-virtual {v2, v3}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->doInBackground([Ljava/lang/Void;)Lcom/example/paul/a_sacco/Transaction;

    move-result-object v2

    move-object v0, v2

    .end local v0    # "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;
    return-object v0
.end method

.method protected onCancelled()V
    .locals 0

    .prologue
    .line 1514
    return-void
.end method

.method protected onPostExecute(Lcom/example/paul/a_sacco/Transaction;)V
    .locals 19

    .prologue
    .line 1432
    move-object/from16 v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;
    move-object/from16 v1, p1

    .local v1, "success":Lcom/example/paul/a_sacco/Transaction;
    move-object v13, v0

    iget-object v13, v13, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->dialog:Landroid/app/ProgressDialog;

    invoke-virtual {v13}, Landroid/app/ProgressDialog;->isShowing()Z

    move-result v13

    if-eqz v13, :cond_0

    .line 1433
    move-object v13, v0

    iget-object v13, v13, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->dialog:Landroid/app/ProgressDialog;

    invoke-virtual {v13}, Landroid/app/ProgressDialog;->dismiss()V

    .line 1435
    :cond_0
    move-object v13, v0

    iget-object v13, v13, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object v14, v1

    iput-object v14, v13, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    .line 1436
    move-object v13, v0

    iget-object v13, v13, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v13, v13, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    invoke-virtual {v13}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object v13

    invoke-static {v13}, Landroid/view/LayoutInflater;->from(Landroid/content/Context;)Landroid/view/LayoutInflater;

    move-result-object v13

    move-object v2, v13

    .line 1437
    .local v2, "factory":Landroid/view/LayoutInflater;
    move-object v13, v2

    const v14, 0x7f030024

    const/4 v15, 0x0

    invoke-virtual {v13, v14, v15}, Landroid/view/LayoutInflater;->inflate(ILandroid/view/ViewGroup;)Landroid/view/View;

    move-result-object v13

    move-object v3, v13

    .line 1438
    .local v3, "textEntryView":Landroid/view/View;
    move-object v13, v3

    const v14, 0x7f090050

    invoke-virtual {v13, v14}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v13

    check-cast v13, Landroid/widget/TextView;

    move-object v4, v13

    .line 1439
    .local v4, "status":Landroid/widget/TextView;
    move-object v13, v3

    const v14, 0x7f09006b

    invoke-virtual {v13, v14}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v13

    check-cast v13, Landroid/widget/TextView;

    move-object v5, v13

    .line 1440
    .local v5, "errors":Landroid/widget/TextView;
    move-object v13, v3

    const v14, 0x7f09004d

    invoke-virtual {v13, v14}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v13

    check-cast v13, Landroid/widget/TextView;

    move-object v6, v13

    .line 1441
    .local v6, "trantype":Landroid/widget/TextView;
    move-object v13, v3

    const v14, 0x7f090046

    invoke-virtual {v13, v14}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v13

    check-cast v13, Landroid/widget/TextView;

    move-object v7, v13

    .line 1442
    .local v7, "acc":Landroid/widget/TextView;
    move-object v13, v3

    const v14, 0x7f09004f

    invoke-virtual {v13, v14}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v13

    check-cast v13, Landroid/widget/TextView;

    move-object v8, v13

    .line 1443
    .local v8, "tramount":Landroid/widget/TextView;
    move-object v13, v3

    const v14, 0x7f090072

    invoke-virtual {v13, v14}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v13

    check-cast v13, Landroid/widget/TextView;

    move-object v9, v13

    .line 1444
    .local v9, "reference":Landroid/widget/TextView;
    move-object v13, v3

    const v14, 0x7f09004e

    invoke-virtual {v13, v14}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v13

    check-cast v13, Landroid/widget/TableRow;

    move-object v10, v13

    .line 1445
    .local v10, "tamount":Landroid/widget/TableRow;
    move-object v13, v9

    move-object v14, v0

    iget-object v14, v14, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v14, v14, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v14, v14, Lcom/example/paul/a_sacco/Transaction;->reference:Ljava/lang/String;

    invoke-virtual {v13, v14}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1446
    move-object v13, v4

    move-object v14, v0

    iget-object v14, v14, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v14, v14, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v14, v14, Lcom/example/paul/a_sacco/Transaction;->status:Lcom/example/paul/a_sacco/Transaction$Status;

    invoke-virtual {v14}, Lcom/example/paul/a_sacco/Transaction$Status;->toString()Ljava/lang/String;

    move-result-object v14

    invoke-virtual {v13, v14}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1447
    move-object v13, v6

    move-object v14, v0

    iget-object v14, v14, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v14, v14, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v14, v14, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    invoke-virtual {v14}, Lcom/example/paul/a_sacco/Transaction$Transtype;->toString()Ljava/lang/String;

    move-result-object v14

    invoke-virtual {v13, v14}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1448
    move-object v13, v8

    move-object v14, v0

    iget-object v14, v14, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v14, v14, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-wide v14, v14, Lcom/example/paul/a_sacco/Transaction;->amount:D

    invoke-static {v14, v15}, Ljava/lang/String;->valueOf(D)Ljava/lang/String;

    move-result-object v14

    invoke-virtual {v13, v14}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1449
    sget-object v13, Lcom/example/paul/a_sacco/AgencyDetailFragment$19;->$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype:[I

    move-object v14, v0

    iget-object v14, v14, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v14, v14, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v14, v14, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    invoke-virtual {v14}, Lcom/example/paul/a_sacco/Transaction$Transtype;->ordinal()I

    move-result v14

    aget v13, v13, v14

    packed-switch v13, :pswitch_data_0

    .line 1482
    :goto_0
    :pswitch_0
    move-object v13, v0

    iget-object v13, v13, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v13, v13, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v13, v13, Lcom/example/paul/a_sacco/Transaction;->message:Ljava/lang/String;

    if-eqz v13, :cond_1

    .line 1483
    move-object v13, v5

    move-object v14, v0

    iget-object v14, v14, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v14, v14, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v14, v14, Lcom/example/paul/a_sacco/Transaction;->message:Ljava/lang/String;

    invoke-virtual {v13, v14}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1484
    :cond_1
    new-instance v13, Landroid/app/AlertDialog$Builder;

    move-object/from16 v18, v13

    move-object/from16 v13, v18

    move-object/from16 v14, v18

    move-object v15, v0

    iget-object v15, v15, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v15, v15, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    invoke-virtual {v15}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object v15

    invoke-direct {v14, v15}, Landroid/app/AlertDialog$Builder;-><init>(Landroid/content/Context;)V

    move-object v11, v13

    .line 1485
    .local v11, "alert":Landroid/app/AlertDialog$Builder;
    move-object v13, v11

    const-string v14, "RESULTS"

    invoke-virtual {v13, v14}, Landroid/app/AlertDialog$Builder;->setTitle(Ljava/lang/CharSequence;)Landroid/app/AlertDialog$Builder;

    move-result-object v13

    .line 1486
    move-object v13, v11

    move-object v14, v3

    invoke-virtual {v13, v14}, Landroid/app/AlertDialog$Builder;->setView(Landroid/view/View;)Landroid/app/AlertDialog$Builder;

    move-result-object v13

    .line 1487
    move-object v13, v11

    const-string v14, "Ok"

    new-instance v15, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask$2;

    move-object/from16 v18, v15

    move-object/from16 v15, v18

    move-object/from16 v16, v18

    move-object/from16 v17, v0

    invoke-direct/range {v16 .. v17}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask$2;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;)V

    invoke-virtual {v13, v14, v15}, Landroid/app/AlertDialog$Builder;->setPositiveButton(Ljava/lang/CharSequence;Landroid/content/DialogInterface$OnClickListener;)Landroid/app/AlertDialog$Builder;

    move-result-object v13

    .line 1492
    move-object v13, v11

    invoke-virtual {v13}, Landroid/app/AlertDialog$Builder;->create()Landroid/app/AlertDialog;

    move-result-object v13

    move-object v12, v13

    .line 1493
    .local v12, "dialog":Landroid/app/AlertDialog;
    move-object v13, v12

    invoke-virtual {v13}, Landroid/app/AlertDialog;->show()V

    .line 1494
    move-object v13, v12

    const/4 v14, -0x1

    invoke-virtual {v13, v14}, Landroid/app/AlertDialog;->getButton(I)Landroid/widget/Button;

    move-result-object v13

    new-instance v14, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask$3;

    move-object/from16 v18, v14

    move-object/from16 v14, v18

    move-object/from16 v15, v18

    move-object/from16 v16, v0

    move-object/from16 v17, v12

    invoke-direct/range {v15 .. v17}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask$3;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;Landroid/app/AlertDialog;)V

    invoke-virtual {v13, v14}, Landroid/widget/Button;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    .line 1509
    return-void

    .line 1454
    .end local v11    # "alert":Landroid/app/AlertDialog$Builder;
    .end local v12    # "dialog":Landroid/app/AlertDialog;
    :pswitch_1
    move-object v13, v7

    move-object v14, v0

    iget-object v14, v14, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v14, v14, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v14, v14, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    iget-object v14, v14, Lcom/example/paul/a_sacco/Account;->Account_No:Ljava/lang/String;

    invoke-virtual {v13, v14}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1455
    goto :goto_0

    .line 1458
    :pswitch_2
    move-object v13, v10

    const/16 v14, 0x8

    invoke-virtual {v13, v14}, Landroid/widget/TableRow;->setVisibility(I)V

    .line 1459
    move-object v13, v7

    move-object v14, v0

    iget-object v14, v14, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v14, v14, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v14, v14, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    iget-object v14, v14, Lcom/example/paul/a_sacco/Account;->Account_No:Ljava/lang/String;

    invoke-virtual {v13, v14}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1460
    goto/16 :goto_0

    .line 1464
    :pswitch_3
    move-object v13, v7

    move-object v14, v0

    iget-object v14, v14, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v14, v14, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v14, v14, Lcom/example/paul/a_sacco/Transaction;->loan_no:Lcom/example/paul/a_sacco/Loans;

    iget-object v14, v14, Lcom/example/paul/a_sacco/Loans;->Loan_No:Ljava/lang/String;

    invoke-virtual {v13, v14}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1465
    goto/16 :goto_0

    .line 1468
    :pswitch_4
    move-object v13, v7

    new-instance v14, Ljava/lang/StringBuilder;

    move-object/from16 v18, v14

    move-object/from16 v14, v18

    move-object/from16 v15, v18

    invoke-direct {v15}, Ljava/lang/StringBuilder;-><init>()V

    move-object v15, v0

    iget-object v15, v15, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v15, v15, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v15, v15, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    iget-object v15, v15, Lcom/example/paul/a_sacco/Account;->Account_No:Ljava/lang/String;

    invoke-virtual {v14, v15}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v14

    const-string v15, " To "

    invoke-virtual {v14, v15}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v14

    move-object v15, v0

    iget-object v15, v15, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v15, v15, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v15, v15, Lcom/example/paul/a_sacco/Transaction;->account_2:Lcom/example/paul/a_sacco/Account;

    iget-object v15, v15, Lcom/example/paul/a_sacco/Account;->Account_No:Ljava/lang/String;

    invoke-virtual {v14, v15}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v14

    invoke-virtual {v14}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v14

    invoke-virtual {v13, v14}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1469
    goto/16 :goto_0

    .line 1472
    :pswitch_5
    move-object v13, v7

    new-instance v14, Ljava/lang/StringBuilder;

    move-object/from16 v18, v14

    move-object/from16 v14, v18

    move-object/from16 v15, v18

    invoke-direct {v15}, Ljava/lang/StringBuilder;-><init>()V

    move-object v15, v0

    iget-object v15, v15, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v15, v15, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v15, v15, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    iget-object v15, v15, Lcom/example/paul/a_sacco/Member;->name:Ljava/lang/String;

    invoke-virtual {v14, v15}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v14

    const-string v15, "\n"

    invoke-virtual {v14, v15}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v14

    move-object v15, v0

    iget-object v15, v15, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v15, v15, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v15, v15, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    iget-object v15, v15, Lcom/example/paul/a_sacco/Member;->id_no:Ljava/lang/String;

    invoke-virtual {v14, v15}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v14

    const-string v15, "\n"

    invoke-virtual {v14, v15}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v14

    move-object v15, v0

    iget-object v15, v15, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v15, v15, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v15, v15, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    iget-object v15, v15, Lcom/example/paul/a_sacco/Member;->telephone:Ljava/lang/String;

    invoke-virtual {v14, v15}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v14

    invoke-virtual {v14}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v14

    invoke-virtual {v13, v14}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 1473
    goto/16 :goto_0

    .line 1477
    :pswitch_6
    move-object v13, v7

    new-instance v14, Ljava/lang/StringBuilder;

    move-object/from16 v18, v14

    move-object/from16 v14, v18

    move-object/from16 v15, v18

    invoke-direct {v15}, Ljava/lang/StringBuilder;-><init>()V

    move-object v15, v0

    iget-object v15, v15, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v15, v15, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v15, v15, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    iget-object v15, v15, Lcom/example/paul/a_sacco/Account;->Account_No:Ljava/lang/String;

    invoke-virtual {v14, v15}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v14

    const-string v15, "\n"

    invoke-virtual {v14, v15}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v14

    move-object v15, v0

    iget-object v15, v15, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v15, v15, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v15, v15, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    iget-object v15, v15, Lcom/example/paul/a_sacco/Account;->Account_Name:Ljava/lang/String;

    invoke-virtual {v14, v15}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v14

    const-string v15, "\n"

    invoke-virtual {v14, v15}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v14

    move-object v15, v0

    iget-object v15, v15, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v15, v15, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v15, v15, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    iget-object v15, v15, Lcom/example/paul/a_sacco/Account;->Telephone:Ljava/lang/String;

    invoke-virtual {v14, v15}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v14

    invoke-virtual {v14}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v14

    invoke-virtual {v13, v14}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    goto/16 :goto_0

    .line 1449
    :pswitch_data_0
    .packed-switch 0x2
        :pswitch_4
        :pswitch_2
        :pswitch_2
        :pswitch_6
        :pswitch_1
        :pswitch_1
        :pswitch_0
        :pswitch_3
        :pswitch_5
    .end packed-switch
.end method

.method protected bridge synthetic onPostExecute(Ljava/lang/Object;)V
    .locals 4

    .prologue
    .line 1392
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;
    move-object v1, p1

    .local v1, "x0":Ljava/lang/Object;
    move-object v2, v0

    move-object v3, v1

    check-cast v3, Lcom/example/paul/a_sacco/Transaction;

    invoke-virtual {v2, v3}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->onPostExecute(Lcom/example/paul/a_sacco/Transaction;)V

    return-void
.end method

.method protected onPreExecute()V
    .locals 3

    .prologue
    .line 1400
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;
    move-object v1, v0

    iget-object v1, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->dialog:Landroid/app/ProgressDialog;

    const-string v2, "Processing request..."

    invoke-virtual {v1, v2}, Landroid/app/ProgressDialog;->setMessage(Ljava/lang/CharSequence;)V

    .line 1401
    move-object v1, v0

    iget-object v1, v1, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionCompleteTask;->dialog:Landroid/app/ProgressDialog;

    invoke-virtual {v1}, Landroid/app/ProgressDialog;->show()V

    .line 1402
    return-void
.end method
