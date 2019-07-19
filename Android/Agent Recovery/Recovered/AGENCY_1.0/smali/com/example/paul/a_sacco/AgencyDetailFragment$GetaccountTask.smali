.class public Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;
.super Landroid/os/AsyncTask;
.source "AgencyDetailFragment.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/example/paul/a_sacco/AgencyDetailFragment;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1
    name = "GetaccountTask"
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
.field private mmember:Lcom/example/paul/a_sacco/Transaction;

.field final synthetic this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;


# direct methods
.method constructor <init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;Lcom/example/paul/a_sacco/Transaction;)V
    .locals 5

    .prologue
    .line 773
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;
    move-object v1, p1

    move-object v2, p2

    .local v2, "agent":Lcom/example/paul/a_sacco/Transaction;
    move-object v3, v0

    move-object v4, v1

    iput-object v4, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object v3, v0

    invoke-direct {v3}, Landroid/os/AsyncTask;-><init>()V

    .line 774
    move-object v3, v0

    move-object v4, v2

    iput-object v4, v3, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->mmember:Lcom/example/paul/a_sacco/Transaction;

    .line 775
    return-void
.end method

.method private SelectAcc(Lcom/example/paul/a_sacco/Member;)V
    .locals 11

    .prologue
    .line 1050
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;
    move-object v1, p1

    .local v1, "t":Lcom/example/paul/a_sacco/Member;
    new-instance v5, Landroid/app/AlertDialog$Builder;

    move-object v10, v5

    move-object v5, v10

    move-object v6, v10

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    invoke-virtual {v7}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object v7

    invoke-direct {v6, v7}, Landroid/app/AlertDialog$Builder;-><init>(Landroid/content/Context;)V

    move-object v2, v5

    .line 1051
    .local v2, "alert":Landroid/app/AlertDialog$Builder;
    move-object v5, v2

    const-string v6, "Accounts"

    invoke-virtual {v5, v6}, Landroid/app/AlertDialog$Builder;->setTitle(Ljava/lang/CharSequence;)Landroid/app/AlertDialog$Builder;

    move-result-object v5

    .line 1052
    move-object v5, v2

    const-string v6, "Select Account to use"

    invoke-virtual {v5, v6}, Landroid/app/AlertDialog$Builder;->setMessage(Ljava/lang/CharSequence;)Landroid/app/AlertDialog$Builder;

    move-result-object v5

    .line 1053
    new-instance v5, Landroid/widget/ListView;

    move-object v10, v5

    move-object v5, v10

    move-object v6, v10

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    invoke-virtual {v7}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object v7

    invoke-direct {v6, v7}, Landroid/widget/ListView;-><init>(Landroid/content/Context;)V

    move-object v3, v5

    .line 1054
    .local v3, "input":Landroid/widget/ListView;
    move-object v5, v3

    const/4 v6, 0x1

    invoke-virtual {v5, v6}, Landroid/widget/ListView;->setChoiceMode(I)V

    .line 1055
    new-instance v5, Lcom/example/paul/a_sacco/BindAccounts;

    move-object v10, v5

    move-object v5, v10

    move-object v6, v10

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    invoke-virtual {v7}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getActivity()Landroid/support/v4/app/FragmentActivity;

    move-result-object v7

    move-object v8, v1

    iget-object v8, v8, Lcom/example/paul/a_sacco/Member;->accounts:Ljava/util/List;

    invoke-direct {v6, v7, v8}, Lcom/example/paul/a_sacco/BindAccounts;-><init>(Landroid/app/Activity;Ljava/util/List;)V

    move-object v4, v5

    .line 1056
    .local v4, "bindingData":Lcom/example/paul/a_sacco/BindAccounts;
    move-object v5, v3

    move-object v6, v4

    invoke-virtual {v5, v6}, Landroid/widget/ListView;->setAdapter(Landroid/widget/ListAdapter;)V

    .line 1057
    move-object v5, v2

    move-object v6, v3

    invoke-virtual {v5, v6}, Landroid/app/AlertDialog$Builder;->setView(Landroid/view/View;)Landroid/app/AlertDialog$Builder;

    move-result-object v5

    .line 1058
    move-object v5, v2

    const-string v6, "Ok"

    new-instance v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$8;

    move-object v10, v7

    move-object v7, v10

    move-object v8, v10

    move-object v9, v0

    invoke-direct {v8, v9}, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$8;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;)V

    invoke-virtual {v5, v6, v7}, Landroid/app/AlertDialog$Builder;->setPositiveButton(Ljava/lang/CharSequence;Landroid/content/DialogInterface$OnClickListener;)Landroid/app/AlertDialog$Builder;

    move-result-object v5

    .line 1078
    move-object v5, v2

    const-string v6, "Cancel"

    new-instance v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$9;

    move-object v10, v7

    move-object v7, v10

    move-object v8, v10

    move-object v9, v0

    invoke-direct {v8, v9}, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$9;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;)V

    invoke-virtual {v5, v6, v7}, Landroid/app/AlertDialog$Builder;->setNegativeButton(Ljava/lang/CharSequence;Landroid/content/DialogInterface$OnClickListener;)Landroid/app/AlertDialog$Builder;

    move-result-object v5

    .line 1088
    move-object v5, v2

    invoke-virtual {v5}, Landroid/app/AlertDialog$Builder;->show()Landroid/app/AlertDialog;

    move-result-object v5

    .line 1090
    return-void
.end method

.method private changepin()V
    .locals 15

    .prologue
    .line 981
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;
    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    invoke-virtual {v7}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object v7

    invoke-static {v7}, Landroid/view/LayoutInflater;->from(Landroid/content/Context;)Landroid/view/LayoutInflater;

    move-result-object v7

    move-object v1, v7

    .line 982
    .local v1, "factory":Landroid/view/LayoutInflater;
    move-object v7, v1

    const v8, 0x7f030022

    const/4 v9, 0x0

    invoke-virtual {v7, v8, v9}, Landroid/view/LayoutInflater;->inflate(ILandroid/view/ViewGroup;)Landroid/view/View;

    move-result-object v7

    move-object v2, v7

    .line 983
    .local v2, "textEntryView":Landroid/view/View;
    move-object v7, v2

    const v8, 0x7f090068

    invoke-virtual {v7, v8}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v7

    check-cast v7, Landroid/widget/EditText;

    move-object v3, v7

    .line 984
    .local v3, "cpin":Landroid/widget/EditText;
    move-object v7, v2

    const v8, 0x7f090069

    invoke-virtual {v7, v8}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v7

    check-cast v7, Landroid/widget/EditText;

    move-object v4, v7

    .line 985
    .local v4, "npin":Landroid/widget/EditText;
    move-object v7, v2

    const v8, 0x7f09006a

    invoke-virtual {v7, v8}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v7

    check-cast v7, Landroid/widget/EditText;

    move-object v5, v7

    .line 986
    .local v5, "conpin":Landroid/widget/EditText;
    new-instance v7, Landroid/app/AlertDialog$Builder;

    move-object v14, v7

    move-object v7, v14

    move-object v8, v14

    move-object v9, v0

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v9, v9, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    invoke-virtual {v9}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object v9

    invoke-direct {v8, v9}, Landroid/app/AlertDialog$Builder;-><init>(Landroid/content/Context;)V

    move-object v6, v7

    .line 987
    .local v6, "alert":Landroid/app/AlertDialog$Builder;
    move-object v7, v6

    const-string v8, "Client Change Pin"

    invoke-virtual {v7, v8}, Landroid/app/AlertDialog$Builder;->setTitle(Ljava/lang/CharSequence;)Landroid/app/AlertDialog$Builder;

    move-result-object v7

    .line 988
    move-object v7, v6

    move-object v8, v2

    invoke-virtual {v7, v8}, Landroid/app/AlertDialog$Builder;->setView(Landroid/view/View;)Landroid/app/AlertDialog$Builder;

    move-result-object v7

    .line 989
    move-object v7, v6

    const-string v8, "Ok"

    new-instance v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$4;

    move-object v14, v9

    move-object v9, v14

    move-object v10, v14

    move-object v11, v0

    invoke-direct {v10, v11}, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$4;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;)V

    invoke-virtual {v7, v8, v9}, Landroid/app/AlertDialog$Builder;->setPositiveButton(Ljava/lang/CharSequence;Landroid/content/DialogInterface$OnClickListener;)Landroid/app/AlertDialog$Builder;

    move-result-object v7

    .line 993
    move-object v7, v6

    const-string v8, "Cancel"

    new-instance v9, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$5;

    move-object v14, v9

    move-object v9, v14

    move-object v10, v14

    move-object v11, v0

    invoke-direct {v10, v11}, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$5;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;)V

    invoke-virtual {v7, v8, v9}, Landroid/app/AlertDialog$Builder;->setNegativeButton(Ljava/lang/CharSequence;Landroid/content/DialogInterface$OnClickListener;)Landroid/app/AlertDialog$Builder;

    move-result-object v7

    .line 997
    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object v8, v6

    invoke-virtual {v8}, Landroid/app/AlertDialog$Builder;->create()Landroid/app/AlertDialog;

    move-result-object v8

    iput-object v8, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment;->pindialog:Landroid/app/AlertDialog;

    .line 998
    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment;->pindialog:Landroid/app/AlertDialog;

    invoke-virtual {v7}, Landroid/app/AlertDialog;->show()V

    .line 999
    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment;->pindialog:Landroid/app/AlertDialog;

    const/4 v8, -0x1

    invoke-virtual {v7, v8}, Landroid/app/AlertDialog;->getButton(I)Landroid/widget/Button;

    move-result-object v7

    new-instance v8, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;

    move-object v14, v8

    move-object v8, v14

    move-object v9, v14

    move-object v10, v0

    move-object v11, v3

    move-object v12, v4

    move-object v13, v5

    invoke-direct {v9, v10, v11, v12, v13}, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$6;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;Landroid/widget/EditText;Landroid/widget/EditText;Landroid/widget/EditText;)V

    invoke-virtual {v7, v8}, Landroid/widget/Button;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    .line 1037
    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment;->pindialog:Landroid/app/AlertDialog;

    const/4 v8, -0x2

    invoke-virtual {v7, v8}, Landroid/app/AlertDialog;->getButton(I)Landroid/widget/Button;

    move-result-object v7

    new-instance v8, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$7;

    move-object v14, v8

    move-object v8, v14

    move-object v9, v14

    move-object v10, v0

    invoke-direct {v9, v10}, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$7;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;)V

    invoke-virtual {v7, v8}, Landroid/widget/Button;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    .line 1047
    return-void
.end method


# virtual methods
.method protected varargs doInBackground([Ljava/lang/Void;)Lcom/example/paul/a_sacco/Transaction;
    .locals 11

    .prologue
    .line 781
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;
    move-object v1, p1

    .local v1, "params":[Ljava/lang/Void;
    :try_start_0
    new-instance v6, Lcom/google/gson/Gson;

    move-object v10, v6

    move-object v6, v10

    move-object v7, v10

    invoke-direct {v7}, Lcom/google/gson/Gson;-><init>()V

    move-object v2, v6

    .line 782
    .local v2, "gson":Lcom/google/gson/Gson;
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->mmember:Lcom/example/paul/a_sacco/Transaction;

    const/4 v7, 0x0

    iput-object v7, v6, Lcom/example/paul/a_sacco/Transaction;->message:Ljava/lang/String;

    .line 783
    move-object v6, v2

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->mmember:Lcom/example/paul/a_sacco/Transaction;

    invoke-virtual {v6, v7}, Lcom/google/gson/Gson;->toJson(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v6

    move-object v3, v6

    .line 785
    .local v3, "jsondata":Ljava/lang/String;
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    invoke-virtual {v6}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getActivity()Landroid/support/v4/app/FragmentActivity;

    move-result-object v6

    const-string v7, "Accounts"

    move-object v8, v3

    const-string v9, "data"

    invoke-static {v6, v7, v8, v9}, Lcom/example/paul/a_sacco/JsonParser;->SendHttpPost(Landroid/app/Activity;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    move-object v4, v6

    .line 787
    .local v4, "json":Ljava/lang/String;
    new-instance v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$1;

    move-object v10, v6

    move-object v6, v10

    move-object v7, v10

    move-object v8, v0

    invoke-direct {v7, v8}, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$1;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;)V

    invoke-virtual {v6}, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$1;->getType()Ljava/lang/reflect/Type;

    move-result-object v6

    move-object v5, v6

    .line 790
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

    iput-object v7, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->mmember:Lcom/example/paul/a_sacco/Transaction;

    .line 792
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->mmember:Lcom/example/paul/a_sacco/Transaction;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-object v0, v6

    .line 800
    .end local v0    # "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;
    .end local v2    # "gson":Lcom/google/gson/Gson;
    .end local v3    # "jsondata":Ljava/lang/String;
    .end local v4    # "json":Ljava/lang/String;
    .end local v5    # "collectionType":Ljava/lang/reflect/Type;
    :goto_0
    return-object v0

    .line 793
    .restart local v0    # "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;
    :catch_0
    move-exception v6

    move-object v2, v6

    .line 794
    .local v2, "e":Ljava/lang/Exception;
    move-object v6, v2

    invoke-virtual {v6}, Ljava/lang/Exception;->printStackTrace()V

    .line 796
    move-object v6, v2

    invoke-virtual {v6}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v6

    const-string v7, "Connection to"

    invoke-virtual {v6, v7}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v6

    if-eqz v6, :cond_0

    .line 797
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->mmember:Lcom/example/paul/a_sacco/Transaction;

    const-string v7, "No Connection, make sure that your mobile data is enabled, or you are on a wifi."

    iput-object v7, v6, Lcom/example/paul/a_sacco/Transaction;->message:Ljava/lang/String;

    .line 800
    :goto_1
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->mmember:Lcom/example/paul/a_sacco/Transaction;

    move-object v0, v6

    goto :goto_0

    .line 799
    :cond_0
    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->mmember:Lcom/example/paul/a_sacco/Transaction;

    move-object v7, v2

    invoke-virtual {v7}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v7

    iput-object v7, v6, Lcom/example/paul/a_sacco/Transaction;->message:Ljava/lang/String;

    goto :goto_1
.end method

.method protected bridge synthetic doInBackground([Ljava/lang/Object;)Ljava/lang/Object;
    .locals 4

    .prologue
    .line 770
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;
    move-object v1, p1

    .local v1, "x0":[Ljava/lang/Object;
    move-object v2, v0

    move-object v3, v1

    check-cast v3, [Ljava/lang/Void;

    invoke-virtual {v2, v3}, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->doInBackground([Ljava/lang/Void;)Lcom/example/paul/a_sacco/Transaction;

    move-result-object v2

    move-object v0, v2

    .end local v0    # "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;
    return-object v0
.end method

.method protected onCancelled()V
    .locals 0

    .prologue
    .line 977
    return-void
.end method

.method protected onPostExecute(Lcom/example/paul/a_sacco/Transaction;)V
    .locals 11

    .prologue
    .line 806
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;
    move-object v1, p1

    .local v1, "success":Lcom/example/paul/a_sacco/Transaction;
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object v6, v1

    iput-object v6, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    .line 808
    move-object v5, v1

    iget-object v5, v5, Lcom/example/paul/a_sacco/Transaction;->status:Lcom/example/paul/a_sacco/Transaction$Status;

    sget-object v6, Lcom/example/paul/a_sacco/Transaction$Status;->Failed:Lcom/example/paul/a_sacco/Transaction$Status;

    if-eq v5, v6, :cond_f

    .line 813
    sget-object v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$19;->$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype:[I

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    invoke-virtual {v6}, Lcom/example/paul/a_sacco/Transaction$Transtype;->ordinal()I

    move-result v6

    aget v5, v5, v6

    packed-switch v5, :pswitch_data_0

    .line 822
    move-object v5, v1

    iget-object v5, v5, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    iget-object v5, v5, Lcom/example/paul/a_sacco/Member;->accounts:Ljava/util/List;

    invoke-interface {v5}, Ljava/util/List;->size()I

    move-result v5

    packed-switch v5, :pswitch_data_1

    .line 873
    sget-object v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$19;->$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype:[I

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    invoke-virtual {v6}, Lcom/example/paul/a_sacco/Transaction$Transtype;->ordinal()I

    move-result v6

    aget v5, v5, v6

    packed-switch v5, :pswitch_data_2

    .line 903
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Member;->accounts:Ljava/util/List;

    const/4 v7, 0x0

    invoke-interface {v6, v7}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/example/paul/a_sacco/Account;

    iput-object v6, v5, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    .line 904
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_No:Landroid/widget/TextView;

    if-eqz v5, :cond_0

    .line 905
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_No:Landroid/widget/TextView;

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Account;->Account_No:Ljava/lang/String;

    invoke-virtual {v5, v6}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 906
    :cond_0
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name:Landroid/widget/TextView;

    if-eqz v5, :cond_1

    .line 907
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name:Landroid/widget/TextView;

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Account;->Account_Name:Ljava/lang/String;

    invoke-virtual {v5, v6}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 917
    :cond_1
    :goto_0
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v5, v5, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    sget-object v6, Lcom/example/paul/a_sacco/Transaction$Transtype;->LoanRepayment:Lcom/example/paul/a_sacco/Transaction$Transtype;

    if-ne v5, v6, :cond_2

    .line 918
    move-object v5, v1

    iget-object v5, v5, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    iget-object v5, v5, Lcom/example/paul/a_sacco/Member;->loans:Ljava/util/List;

    invoke-interface {v5}, Ljava/util/List;->size()I

    move-result v5

    packed-switch v5, :pswitch_data_3

    .line 932
    new-instance v5, Landroid/app/AlertDialog$Builder;

    move-object v10, v5

    move-object v5, v10

    move-object v6, v10

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    invoke-virtual {v7}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object v7

    invoke-direct {v6, v7}, Landroid/app/AlertDialog$Builder;-><init>(Landroid/content/Context;)V

    move-object v2, v5

    .line 933
    .local v2, "alert":Landroid/app/AlertDialog$Builder;
    move-object v5, v2

    const-string v6, "Loans"

    invoke-virtual {v5, v6}, Landroid/app/AlertDialog$Builder;->setTitle(Ljava/lang/CharSequence;)Landroid/app/AlertDialog$Builder;

    move-result-object v5

    .line 934
    move-object v5, v2

    const-string v6, "Select Loan to pay"

    invoke-virtual {v5, v6}, Landroid/app/AlertDialog$Builder;->setMessage(Ljava/lang/CharSequence;)Landroid/app/AlertDialog$Builder;

    move-result-object v5

    .line 935
    new-instance v5, Landroid/widget/ListView;

    move-object v10, v5

    move-object v5, v10

    move-object v6, v10

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment;->rootView:Landroid/view/View;

    invoke-virtual {v7}, Landroid/view/View;->getContext()Landroid/content/Context;

    move-result-object v7

    invoke-direct {v6, v7}, Landroid/widget/ListView;-><init>(Landroid/content/Context;)V

    move-object v3, v5

    .line 936
    .local v3, "input":Landroid/widget/ListView;
    move-object v5, v3

    const/4 v6, 0x1

    invoke-virtual {v5, v6}, Landroid/widget/ListView;->setChoiceMode(I)V

    .line 937
    new-instance v5, Lcom/example/paul/a_sacco/BindLoans;

    move-object v10, v5

    move-object v5, v10

    move-object v6, v10

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    invoke-virtual {v7}, Lcom/example/paul/a_sacco/AgencyDetailFragment;->getActivity()Landroid/support/v4/app/FragmentActivity;

    move-result-object v7

    move-object v8, v1

    iget-object v8, v8, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    iget-object v8, v8, Lcom/example/paul/a_sacco/Member;->loans:Ljava/util/List;

    invoke-direct {v6, v7, v8}, Lcom/example/paul/a_sacco/BindLoans;-><init>(Landroid/app/Activity;Ljava/util/List;)V

    move-object v4, v5

    .line 938
    .local v4, "bindingData":Lcom/example/paul/a_sacco/BindLoans;
    move-object v5, v3

    move-object v6, v4

    invoke-virtual {v5, v6}, Landroid/widget/ListView;->setAdapter(Landroid/widget/ListAdapter;)V

    .line 939
    move-object v5, v2

    move-object v6, v3

    invoke-virtual {v5, v6}, Landroid/app/AlertDialog$Builder;->setView(Landroid/view/View;)Landroid/app/AlertDialog$Builder;

    move-result-object v5

    .line 940
    move-object v5, v2

    const-string v6, "Ok"

    new-instance v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$2;

    move-object v10, v7

    move-object v7, v10

    move-object v8, v10

    move-object v9, v0

    invoke-direct {v8, v9}, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$2;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;)V

    invoke-virtual {v5, v6, v7}, Landroid/app/AlertDialog$Builder;->setPositiveButton(Ljava/lang/CharSequence;Landroid/content/DialogInterface$OnClickListener;)Landroid/app/AlertDialog$Builder;

    move-result-object v5

    .line 953
    move-object v5, v2

    const-string v6, "Cancel"

    new-instance v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$3;

    move-object v10, v7

    move-object v7, v10

    move-object v8, v10

    move-object v9, v0

    invoke-direct {v8, v9}, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask$3;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;)V

    invoke-virtual {v5, v6, v7}, Landroid/app/AlertDialog$Builder;->setNegativeButton(Ljava/lang/CharSequence;Landroid/content/DialogInterface$OnClickListener;)Landroid/app/AlertDialog$Builder;

    move-result-object v5

    .line 960
    move-object v5, v2

    invoke-virtual {v5}, Landroid/app/AlertDialog$Builder;->show()Landroid/app/AlertDialog;

    move-result-object v5

    .line 961
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->ploan:Landroid/widget/ProgressBar;

    const/16 v6, 0x8

    invoke-virtual {v5, v6}, Landroid/widget/ProgressBar;->setVisibility(I)V

    .line 962
    .line 969
    .end local v2    # "alert":Landroid/app/AlertDialog$Builder;
    .end local v3    # "input":Landroid/widget/ListView;
    .end local v4    # "bindingData":Lcom/example/paul/a_sacco/BindLoans;
    :cond_2
    :goto_1
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->pacc:Landroid/widget/ProgressBar;

    if-eqz v5, :cond_3

    .line 970
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->pacc:Landroid/widget/ProgressBar;

    const/16 v6, 0x8

    invoke-virtual {v5, v6}, Landroid/widget/ProgressBar;->setVisibility(I)V

    .line 971
    :cond_3
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->pacc2:Landroid/widget/ProgressBar;

    if-eqz v5, :cond_4

    .line 972
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->pacc2:Landroid/widget/ProgressBar;

    const/16 v6, 0x8

    invoke-virtual {v5, v6}, Landroid/widget/ProgressBar;->setVisibility(I)V

    .line 973
    :cond_4
    return-void

    .line 815
    :pswitch_0
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v5, v5, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    iget-boolean v5, v5, Lcom/example/paul/a_sacco/Account;->Account_ok:Z

    if-eqz v5, :cond_5

    .line 816
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name:Landroid/widget/TextView;

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Account;->Account_Name:Ljava/lang/String;

    invoke-virtual {v5, v6}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    goto/16 :goto_0

    .line 818
    :cond_5
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name:Landroid/widget/TextView;

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Account;->Message:Ljava/lang/String;

    invoke-virtual {v5, v6}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 820
    goto/16 :goto_0

    .line 824
    :pswitch_1
    sget-object v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$19;->$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype:[I

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    invoke-virtual {v6}, Lcom/example/paul/a_sacco/Transaction$Transtype;->ordinal()I

    move-result v6

    aget v5, v5, v6

    packed-switch v5, :pswitch_data_4

    .line 831
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    const-string v6, "No Active Account"

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 832
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->requestFocus()Z

    move-result v5

    .line 833
    goto/16 :goto_0

    .line 826
    :pswitch_2
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    const-string v6, "Invalid ID"

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 827
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    const-string v6, ""

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setText(Ljava/lang/CharSequence;)V

    .line 828
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->requestFocus()Z

    move-result v5

    .line 829
    goto/16 :goto_0

    .line 838
    :pswitch_3
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Member;->accounts:Ljava/util/List;

    const/4 v7, 0x0

    invoke-interface {v6, v7}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/example/paul/a_sacco/Account;

    iput-object v6, v5, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    .line 839
    sget-object v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$19;->$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype:[I

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    invoke-virtual {v6}, Lcom/example/paul/a_sacco/Transaction$Transtype;->ordinal()I

    move-result v6

    aget v5, v5, v6

    packed-switch v5, :pswitch_data_5

    .line 855
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Member;->accounts:Ljava/util/List;

    const/4 v7, 0x0

    invoke-interface {v6, v7}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/example/paul/a_sacco/Account;

    iput-object v6, v5, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    .line 856
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name:Landroid/widget/TextView;

    if-eqz v5, :cond_6

    .line 857
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name:Landroid/widget/TextView;

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Member;->accounts:Ljava/util/List;

    const/4 v7, 0x0

    invoke-interface {v6, v7}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/example/paul/a_sacco/Account;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Account;->Account_Name:Ljava/lang/String;

    invoke-virtual {v5, v6}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 858
    :cond_6
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_No:Landroid/widget/TextView;

    if-eqz v5, :cond_7

    .line 859
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_No:Landroid/widget/TextView;

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Member;->accounts:Ljava/util/List;

    const/4 v7, 0x0

    invoke-interface {v6, v7}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/example/paul/a_sacco/Account;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Account;->Account_No:Ljava/lang/String;

    invoke-virtual {v5, v6}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 862
    :cond_7
    :goto_2
    sget-object v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$19;->$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype:[I

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->transactiontype:Lcom/example/paul/a_sacco/Transaction$Transtype;

    invoke-virtual {v6}, Lcom/example/paul/a_sacco/Transaction$Transtype;->ordinal()I

    move-result v6

    aget v5, v5, v6

    packed-switch v5, :pswitch_data_6

    .line 870
    :cond_8
    :goto_3
    goto/16 :goto_0

    .line 841
    :pswitch_4
    goto :goto_2

    .line 843
    :pswitch_5
    move-object v5, v1

    iget-object v5, v5, Lcom/example/paul/a_sacco/Transaction;->account_2:Lcom/example/paul/a_sacco/Account;

    if-nez v5, :cond_9

    .line 844
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name:Landroid/widget/TextView;

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Member;->accounts:Ljava/util/List;

    const/4 v7, 0x0

    invoke-interface {v6, v7}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/example/paul/a_sacco/Account;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Account;->Account_Name:Ljava/lang/String;

    invoke-virtual {v5, v6}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 845
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_No:Landroid/widget/TextView;

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Member;->accounts:Ljava/util/List;

    const/4 v7, 0x0

    invoke-interface {v6, v7}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/example/paul/a_sacco/Account;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Account;->Account_No:Ljava/lang/String;

    invoke-virtual {v5, v6}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    goto :goto_2

    .line 847
    :cond_9
    move-object v5, v1

    iget-object v5, v5, Lcom/example/paul/a_sacco/Transaction;->account_2:Lcom/example/paul/a_sacco/Account;

    iget-boolean v5, v5, Lcom/example/paul/a_sacco/Account;->Account_ok:Z

    if-eqz v5, :cond_a

    .line 848
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name2:Landroid/widget/TextView;

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->account_2:Lcom/example/paul/a_sacco/Account;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Account;->Account_Name:Ljava/lang/String;

    invoke-virtual {v5, v6}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    goto :goto_2

    .line 850
    :cond_a
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name2:Landroid/widget/TextView;

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->account_2:Lcom/example/paul/a_sacco/Account;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Account;->Message:Ljava/lang/String;

    invoke-virtual {v5, v6}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 852
    goto :goto_2

    .line 866
    :pswitch_6
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v5, v5, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    if-eqz v5, :cond_8

    .line 867
    new-instance v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;

    move-object v10, v5

    move-object v5, v10

    move-object v6, v10

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object v8, v0

    iget-object v8, v8, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v8, v8, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    invoke-direct {v6, v7, v8}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;Lcom/example/paul/a_sacco/Transaction;)V

    const/4 v6, 0x0

    new-array v6, v6, [Ljava/lang/Void;

    invoke-virtual {v5, v6}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->execute([Ljava/lang/Object;)Landroid/os/AsyncTask;

    move-result-object v5

    goto :goto_3

    .line 875
    :pswitch_7
    goto/16 :goto_0

    .line 879
    :pswitch_8
    move-object v5, v0

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    invoke-direct {v5, v6}, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->SelectAcc(Lcom/example/paul/a_sacco/Member;)V

    .line 880
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->pacc:Landroid/widget/ProgressBar;

    const/16 v6, 0x8

    invoke-virtual {v5, v6}, Landroid/widget/ProgressBar;->setVisibility(I)V

    .line 881
    goto/16 :goto_0

    .line 883
    :pswitch_9
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v5, v5, Lcom/example/paul/a_sacco/Transaction;->account_2:Lcom/example/paul/a_sacco/Account;

    if-nez v5, :cond_b

    .line 884
    move-object v5, v0

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    invoke-direct {v5, v6}, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->SelectAcc(Lcom/example/paul/a_sacco/Member;)V

    goto/16 :goto_0

    .line 886
    :cond_b
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v5, v5, Lcom/example/paul/a_sacco/Transaction;->account_2:Lcom/example/paul/a_sacco/Account;

    iget-boolean v5, v5, Lcom/example/paul/a_sacco/Account;->Account_ok:Z

    if-eqz v5, :cond_c

    .line 887
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name2:Landroid/widget/TextView;

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->account_2:Lcom/example/paul/a_sacco/Account;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Account;->Account_Name:Ljava/lang/String;

    invoke-virtual {v5, v6}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    goto/16 :goto_0

    .line 889
    :cond_c
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name2:Landroid/widget/TextView;

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->account_2:Lcom/example/paul/a_sacco/Account;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Account;->Message:Ljava/lang/String;

    invoke-virtual {v5, v6}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 891
    goto/16 :goto_0

    .line 893
    :pswitch_a
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Member;->accounts:Ljava/util/List;

    const/4 v7, 0x0

    invoke-interface {v6, v7}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/example/paul/a_sacco/Account;

    iput-object v6, v5, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    .line 894
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_No:Landroid/widget/TextView;

    if-eqz v5, :cond_d

    .line 895
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_No:Landroid/widget/TextView;

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Account;->Account_No:Ljava/lang/String;

    invoke-virtual {v5, v6}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 896
    :cond_d
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name:Landroid/widget/TextView;

    if-eqz v5, :cond_e

    .line 897
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Account_Name:Landroid/widget/TextView;

    move-object v6, v0

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v6, v6, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Account;->Account_Name:Ljava/lang/String;

    invoke-virtual {v5, v6}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 898
    :cond_e
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    iget-object v5, v5, Lcom/example/paul/a_sacco/Transaction;->account_1:Lcom/example/paul/a_sacco/Account;

    if-eqz v5, :cond_1

    .line 899
    new-instance v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;

    move-object v10, v5

    move-object v5, v10

    move-object v6, v10

    move-object v7, v0

    iget-object v7, v7, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    move-object v8, v0

    iget-object v8, v8, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v8, v8, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    invoke-direct {v6, v7, v8}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;-><init>(Lcom/example/paul/a_sacco/AgencyDetailFragment;Lcom/example/paul/a_sacco/Transaction;)V

    const/4 v6, 0x0

    new-array v6, v6, [Ljava/lang/Void;

    invoke-virtual {v5, v6}, Lcom/example/paul/a_sacco/AgencyDetailFragment$TransactionrequestTask;->execute([Ljava/lang/Object;)Landroid/os/AsyncTask;

    move-result-object v5

    goto/16 :goto_0

    .line 920
    :pswitch_b
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    const-string v6, "No Outstanding loans"

    invoke-virtual {v5, v6}, Landroid/widget/EditText;->setError(Ljava/lang/CharSequence;)V

    .line 921
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->id_no:Landroid/widget/EditText;

    invoke-virtual {v5}, Landroid/widget/EditText;->requestFocus()Z

    move-result v5

    .line 922
    goto/16 :goto_1

    .line 925
    :pswitch_c
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->trans:Lcom/example/paul/a_sacco/Transaction;

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Member;->loans:Ljava/util/List;

    const/4 v7, 0x0

    invoke-interface {v6, v7}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/example/paul/a_sacco/Loans;

    iput-object v6, v5, Lcom/example/paul/a_sacco/Transaction;->loan_no:Lcom/example/paul/a_sacco/Loans;

    .line 926
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->loanNo:Landroid/widget/TextView;

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Member;->loans:Ljava/util/List;

    const/4 v7, 0x0

    invoke-interface {v6, v7}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/example/paul/a_sacco/Loans;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Loans;->Loan_No:Ljava/lang/String;

    invoke-virtual {v5, v6}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 927
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->loan_Type:Landroid/widget/TextView;

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->member_1:Lcom/example/paul/a_sacco/Member;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Member;->loans:Ljava/util/List;

    const/4 v7, 0x0

    invoke-interface {v6, v7}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/example/paul/a_sacco/Loans;

    iget-object v6, v6, Lcom/example/paul/a_sacco/Loans;->Loan_Type:Ljava/lang/String;

    invoke-virtual {v5, v6}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 929
    goto/16 :goto_1

    .line 966
    :cond_f
    move-object v5, v1

    iget-object v5, v5, Lcom/example/paul/a_sacco/Transaction;->message:Ljava/lang/String;

    if-eqz v5, :cond_2

    .line 967
    move-object v5, v0

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->this$0:Lcom/example/paul/a_sacco/AgencyDetailFragment;

    iget-object v5, v5, Lcom/example/paul/a_sacco/AgencyDetailFragment;->Info:Landroid/widget/TextView;

    move-object v6, v1

    iget-object v6, v6, Lcom/example/paul/a_sacco/Transaction;->message:Ljava/lang/String;

    invoke-virtual {v5, v6}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    goto/16 :goto_1

    .line 813
    nop

    :pswitch_data_0
    .packed-switch 0x7
        :pswitch_0
    .end packed-switch

    .line 822
    :pswitch_data_1
    .packed-switch 0x0
        :pswitch_1
        :pswitch_3
    .end packed-switch

    .line 873
    :pswitch_data_2
    .packed-switch 0x1
        :pswitch_7
        :pswitch_9
        :pswitch_8
        :pswitch_8
        :pswitch_a
        :pswitch_8
    .end packed-switch

    .line 918
    :pswitch_data_3
    .packed-switch 0x0
        :pswitch_b
        :pswitch_c
    .end packed-switch

    .line 824
    :pswitch_data_4
    .packed-switch 0x1
        :pswitch_2
    .end packed-switch

    .line 839
    :pswitch_data_5
    .packed-switch 0x1
        :pswitch_4
        :pswitch_5
    .end packed-switch

    .line 862
    :pswitch_data_6
    .packed-switch 0x3
        :pswitch_6
        :pswitch_6
        :pswitch_6
    .end packed-switch
.end method

.method protected bridge synthetic onPostExecute(Ljava/lang/Object;)V
    .locals 4

    .prologue
    .line 770
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;
    move-object v1, p1

    .local v1, "x0":Ljava/lang/Object;
    move-object v2, v0

    move-object v3, v1

    check-cast v3, Lcom/example/paul/a_sacco/Transaction;

    invoke-virtual {v2, v3}, Lcom/example/paul/a_sacco/AgencyDetailFragment$GetaccountTask;->onPostExecute(Lcom/example/paul/a_sacco/Transaction;)V

    return-void
.end method
