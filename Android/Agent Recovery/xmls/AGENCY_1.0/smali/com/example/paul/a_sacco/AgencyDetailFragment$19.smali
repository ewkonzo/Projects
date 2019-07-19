.class synthetic Lcom/example/paul/a_sacco/AgencyDetailFragment$19;
.super Ljava/lang/Object;
.source "AgencyDetailFragment.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/example/paul/a_sacco/AgencyDetailFragment;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1008
    name = null
.end annotation


# static fields
.field static final synthetic $SwitchMap$com$example$paul$a_sacco$Transaction$Transtype:[I


# direct methods
.method static constructor <clinit>()V
    .locals 4

    .prologue
    .line 824
    invoke-static {}, Lcom/example/paul/a_sacco/Transaction$Transtype;->values()[Lcom/example/paul/a_sacco/Transaction$Transtype;

    move-result-object v1

    array-length v1, v1

    new-array v1, v1, [I

    sput-object v1, Lcom/example/paul/a_sacco/AgencyDetailFragment$19;->$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype:[I

    :try_start_0
    sget-object v1, Lcom/example/paul/a_sacco/AgencyDetailFragment$19;->$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype:[I

    sget-object v2, Lcom/example/paul/a_sacco/Transaction$Transtype;->Changepin:Lcom/example/paul/a_sacco/Transaction$Transtype;

    invoke-virtual {v2}, Lcom/example/paul/a_sacco/Transaction$Transtype;->ordinal()I

    move-result v2

    const/4 v3, 0x1

    aput v3, v1, v2
    :try_end_0
    .catch Ljava/lang/NoSuchFieldError; {:try_start_0 .. :try_end_0} :catch_0

    :goto_0
    :try_start_1
    sget-object v1, Lcom/example/paul/a_sacco/AgencyDetailFragment$19;->$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype:[I

    sget-object v2, Lcom/example/paul/a_sacco/Transaction$Transtype;->Transfer:Lcom/example/paul/a_sacco/Transaction$Transtype;

    invoke-virtual {v2}, Lcom/example/paul/a_sacco/Transaction$Transtype;->ordinal()I

    move-result v2

    const/4 v3, 0x2

    aput v3, v1, v2
    :try_end_1
    .catch Ljava/lang/NoSuchFieldError; {:try_start_1 .. :try_end_1} :catch_1

    :goto_1
    :try_start_2
    sget-object v1, Lcom/example/paul/a_sacco/AgencyDetailFragment$19;->$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype:[I

    sget-object v2, Lcom/example/paul/a_sacco/Transaction$Transtype;->Balance:Lcom/example/paul/a_sacco/Transaction$Transtype;

    invoke-virtual {v2}, Lcom/example/paul/a_sacco/Transaction$Transtype;->ordinal()I

    move-result v2

    const/4 v3, 0x3

    aput v3, v1, v2
    :try_end_2
    .catch Ljava/lang/NoSuchFieldError; {:try_start_2 .. :try_end_2} :catch_2

    :goto_2
    :try_start_3
    sget-object v1, Lcom/example/paul/a_sacco/AgencyDetailFragment$19;->$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype:[I

    sget-object v2, Lcom/example/paul/a_sacco/Transaction$Transtype;->Ministatment:Lcom/example/paul/a_sacco/Transaction$Transtype;

    invoke-virtual {v2}, Lcom/example/paul/a_sacco/Transaction$Transtype;->ordinal()I

    move-result v2

    const/4 v3, 0x4

    aput v3, v1, v2
    :try_end_3
    .catch Ljava/lang/NoSuchFieldError; {:try_start_3 .. :try_end_3} :catch_3

    :goto_3
    :try_start_4
    sget-object v1, Lcom/example/paul/a_sacco/AgencyDetailFragment$19;->$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype:[I

    sget-object v2, Lcom/example/paul/a_sacco/Transaction$Transtype;->Memberactivation:Lcom/example/paul/a_sacco/Transaction$Transtype;

    invoke-virtual {v2}, Lcom/example/paul/a_sacco/Transaction$Transtype;->ordinal()I

    move-result v2

    const/4 v3, 0x5

    aput v3, v1, v2
    :try_end_4
    .catch Ljava/lang/NoSuchFieldError; {:try_start_4 .. :try_end_4} :catch_4

    :goto_4
    :try_start_5
    sget-object v1, Lcom/example/paul/a_sacco/AgencyDetailFragment$19;->$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype:[I

    sget-object v2, Lcom/example/paul/a_sacco/Transaction$Transtype;->Withdrawal:Lcom/example/paul/a_sacco/Transaction$Transtype;

    invoke-virtual {v2}, Lcom/example/paul/a_sacco/Transaction$Transtype;->ordinal()I

    move-result v2

    const/4 v3, 0x6

    aput v3, v1, v2
    :try_end_5
    .catch Ljava/lang/NoSuchFieldError; {:try_start_5 .. :try_end_5} :catch_5

    :goto_5
    :try_start_6
    sget-object v1, Lcom/example/paul/a_sacco/AgencyDetailFragment$19;->$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype:[I

    sget-object v2, Lcom/example/paul/a_sacco/Transaction$Transtype;->Deposit:Lcom/example/paul/a_sacco/Transaction$Transtype;

    invoke-virtual {v2}, Lcom/example/paul/a_sacco/Transaction$Transtype;->ordinal()I

    move-result v2

    const/4 v3, 0x7

    aput v3, v1, v2
    :try_end_6
    .catch Ljava/lang/NoSuchFieldError; {:try_start_6 .. :try_end_6} :catch_6

    :goto_6
    :try_start_7
    sget-object v1, Lcom/example/paul/a_sacco/AgencyDetailFragment$19;->$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype:[I

    sget-object v2, Lcom/example/paul/a_sacco/Transaction$Transtype;->Sharedeposit:Lcom/example/paul/a_sacco/Transaction$Transtype;

    invoke-virtual {v2}, Lcom/example/paul/a_sacco/Transaction$Transtype;->ordinal()I

    move-result v2

    const/16 v3, 0x8

    aput v3, v1, v2
    :try_end_7
    .catch Ljava/lang/NoSuchFieldError; {:try_start_7 .. :try_end_7} :catch_7

    :goto_7
    :try_start_8
    sget-object v1, Lcom/example/paul/a_sacco/AgencyDetailFragment$19;->$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype:[I

    sget-object v2, Lcom/example/paul/a_sacco/Transaction$Transtype;->LoanRepayment:Lcom/example/paul/a_sacco/Transaction$Transtype;

    invoke-virtual {v2}, Lcom/example/paul/a_sacco/Transaction$Transtype;->ordinal()I

    move-result v2

    const/16 v3, 0x9

    aput v3, v1, v2
    :try_end_8
    .catch Ljava/lang/NoSuchFieldError; {:try_start_8 .. :try_end_8} :catch_8

    :goto_8
    :try_start_9
    sget-object v1, Lcom/example/paul/a_sacco/AgencyDetailFragment$19;->$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype:[I

    sget-object v2, Lcom/example/paul/a_sacco/Transaction$Transtype;->Registration:Lcom/example/paul/a_sacco/Transaction$Transtype;

    invoke-virtual {v2}, Lcom/example/paul/a_sacco/Transaction$Transtype;->ordinal()I

    move-result v2

    const/16 v3, 0xa

    aput v3, v1, v2
    :try_end_9
    .catch Ljava/lang/NoSuchFieldError; {:try_start_9 .. :try_end_9} :catch_9

    :goto_9
    :try_start_a
    sget-object v1, Lcom/example/paul/a_sacco/AgencyDetailFragment$19;->$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype:[I

    sget-object v2, Lcom/example/paul/a_sacco/Transaction$Transtype;->MemberRegistration:Lcom/example/paul/a_sacco/Transaction$Transtype;

    invoke-virtual {v2}, Lcom/example/paul/a_sacco/Transaction$Transtype;->ordinal()I

    move-result v2

    const/16 v3, 0xb

    aput v3, v1, v2
    :try_end_a
    .catch Ljava/lang/NoSuchFieldError; {:try_start_a .. :try_end_a} :catch_a

    :goto_a
    return-void

    :catch_0
    move-exception v1

    move-object v0, v1

    goto :goto_0

    :catch_1
    move-exception v1

    move-object v0, v1

    goto :goto_1

    :catch_2
    move-exception v1

    move-object v0, v1

    goto :goto_2

    :catch_3
    move-exception v1

    move-object v0, v1

    goto :goto_3

    :catch_4
    move-exception v1

    move-object v0, v1

    goto :goto_4

    :catch_5
    move-exception v1

    move-object v0, v1

    goto :goto_5

    :catch_6
    move-exception v1

    move-object v0, v1

    goto :goto_6

    :catch_7
    move-exception v1

    move-object v0, v1

    goto :goto_7

    :catch_8
    move-exception v1

    move-object v0, v1

    goto :goto_8

    :catch_9
    move-exception v1

    move-object v0, v1

    goto :goto_9

    :catch_a
    move-exception v1

    move-object v0, v1

    goto :goto_a
.end method
