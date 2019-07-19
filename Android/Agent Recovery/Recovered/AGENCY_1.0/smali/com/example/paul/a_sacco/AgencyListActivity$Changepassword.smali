.class public Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword;
.super Ljava/lang/Object;
.source "AgencyListActivity.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/example/paul/a_sacco/AgencyListActivity;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1
    name = "Changepassword"
.end annotation


# instance fields
.field public New_password:Ljava/lang/String;

.field public Old_password:Ljava/lang/String;

.field public changed:Z

.field final synthetic this$0:Lcom/example/paul/a_sacco/AgencyListActivity;


# direct methods
.method public constructor <init>(Lcom/example/paul/a_sacco/AgencyListActivity;)V
    .locals 4

    .prologue
    .line 182
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword;
    move-object v1, p1

    move-object v2, v0

    move-object v3, v1

    iput-object v3, v2, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword;->this$0:Lcom/example/paul/a_sacco/AgencyListActivity;

    move-object v2, v0

    invoke-direct {v2}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public changepin(Landroid/content/Context;)V
    .locals 20

    .prologue
    .line 188
    move-object/from16 v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword;
    move-object/from16 v1, p1

    .local v1, "c":Landroid/content/Context;
    const/4 v10, 0x0

    move-object v2, v10

    .line 189
    .local v2, "newpassword":Ljava/lang/String;
    move-object v10, v1

    invoke-static {v10}, Landroid/view/LayoutInflater;->from(Landroid/content/Context;)Landroid/view/LayoutInflater;

    move-result-object v10

    move-object v3, v10

    .line 190
    .local v3, "factory":Landroid/view/LayoutInflater;
    move-object v10, v3

    const v11, 0x7f030021

    const/4 v12, 0x0

    invoke-virtual {v10, v11, v12}, Landroid/view/LayoutInflater;->inflate(ILandroid/view/ViewGroup;)Landroid/view/View;

    move-result-object v10

    move-object v4, v10

    .line 191
    .local v4, "textEntryView":Landroid/view/View;
    move-object v10, v4

    const v11, 0x7f090068

    invoke-virtual {v10, v11}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v10

    check-cast v10, Landroid/widget/EditText;

    move-object v5, v10

    .line 192
    .local v5, "cpin":Landroid/widget/EditText;
    move-object v10, v4

    const v11, 0x7f090069

    invoke-virtual {v10, v11}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v10

    check-cast v10, Landroid/widget/EditText;

    move-object v6, v10

    .line 193
    .local v6, "npin":Landroid/widget/EditText;
    move-object v10, v4

    const v11, 0x7f09006a

    invoke-virtual {v10, v11}, Landroid/view/View;->findViewById(I)Landroid/view/View;

    move-result-object v10

    check-cast v10, Landroid/widget/EditText;

    move-object v7, v10

    .line 194
    .local v7, "conpin":Landroid/widget/EditText;
    new-instance v10, Landroid/app/AlertDialog$Builder;

    move-object/from16 v19, v10

    move-object/from16 v10, v19

    move-object/from16 v11, v19

    move-object v12, v0

    iget-object v12, v12, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword;->this$0:Lcom/example/paul/a_sacco/AgencyListActivity;

    invoke-direct {v11, v12}, Landroid/app/AlertDialog$Builder;-><init>(Landroid/content/Context;)V

    move-object v8, v10

    .line 195
    .local v8, "alert":Landroid/app/AlertDialog$Builder;
    move-object v10, v8

    const-string v11, "Client Change Pin"

    invoke-virtual {v10, v11}, Landroid/app/AlertDialog$Builder;->setTitle(Ljava/lang/CharSequence;)Landroid/app/AlertDialog$Builder;

    move-result-object v10

    .line 196
    move-object v10, v8

    move-object v11, v4

    invoke-virtual {v10, v11}, Landroid/app/AlertDialog$Builder;->setView(Landroid/view/View;)Landroid/app/AlertDialog$Builder;

    move-result-object v10

    .line 197
    move-object v10, v8

    const-string v11, "Ok"

    new-instance v12, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$1;

    move-object/from16 v19, v12

    move-object/from16 v12, v19

    move-object/from16 v13, v19

    move-object v14, v0

    invoke-direct {v13, v14}, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$1;-><init>(Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword;)V

    invoke-virtual {v10, v11, v12}, Landroid/app/AlertDialog$Builder;->setPositiveButton(Ljava/lang/CharSequence;Landroid/content/DialogInterface$OnClickListener;)Landroid/app/AlertDialog$Builder;

    move-result-object v10

    .line 201
    move-object v10, v8

    const-string v11, "Cancel"

    new-instance v12, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$2;

    move-object/from16 v19, v12

    move-object/from16 v12, v19

    move-object/from16 v13, v19

    move-object v14, v0

    invoke-direct {v13, v14}, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$2;-><init>(Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword;)V

    invoke-virtual {v10, v11, v12}, Landroid/app/AlertDialog$Builder;->setNegativeButton(Ljava/lang/CharSequence;Landroid/content/DialogInterface$OnClickListener;)Landroid/app/AlertDialog$Builder;

    move-result-object v10

    .line 205
    move-object v10, v8

    invoke-virtual {v10}, Landroid/app/AlertDialog$Builder;->create()Landroid/app/AlertDialog;

    move-result-object v10

    move-object v9, v10

    .line 206
    .local v9, "pindialog":Landroid/app/AlertDialog;
    move-object v10, v9

    invoke-virtual {v10}, Landroid/app/AlertDialog;->show()V

    .line 207
    move-object v10, v9

    const/4 v11, -0x1

    invoke-virtual {v10, v11}, Landroid/app/AlertDialog;->getButton(I)Landroid/widget/Button;

    move-result-object v10

    new-instance v11, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;

    move-object/from16 v19, v11

    move-object/from16 v11, v19

    move-object/from16 v12, v19

    move-object v13, v0

    move-object v14, v5

    move-object v15, v6

    move-object/from16 v16, v7

    move-object/from16 v17, v1

    move-object/from16 v18, v9

    invoke-direct/range {v12 .. v18}, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$3;-><init>(Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword;Landroid/widget/EditText;Landroid/widget/EditText;Landroid/widget/EditText;Landroid/content/Context;Landroid/app/AlertDialog;)V

    invoke-virtual {v10, v11}, Landroid/widget/Button;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    .line 245
    move-object v10, v9

    const/4 v11, -0x2

    invoke-virtual {v10, v11}, Landroid/app/AlertDialog;->getButton(I)Landroid/widget/Button;

    move-result-object v10

    new-instance v11, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$4;

    move-object/from16 v19, v11

    move-object/from16 v11, v19

    move-object/from16 v12, v19

    move-object v13, v0

    move-object v14, v9

    invoke-direct {v12, v13, v14}, Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword$4;-><init>(Lcom/example/paul/a_sacco/AgencyListActivity$Changepassword;Landroid/app/AlertDialog;)V

    invoke-virtual {v10, v11}, Landroid/widget/Button;->setOnClickListener(Landroid/view/View$OnClickListener;)V

    .line 255
    return-void
.end method
