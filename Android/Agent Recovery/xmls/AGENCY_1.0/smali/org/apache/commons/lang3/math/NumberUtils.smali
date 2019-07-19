.class public Lorg/apache/commons/lang3/math/NumberUtils;
.super Ljava/lang/Object;
.source "NumberUtils.java"


# static fields
.field public static final BYTE_MINUS_ONE:Ljava/lang/Byte;

.field public static final BYTE_ONE:Ljava/lang/Byte;

.field public static final BYTE_ZERO:Ljava/lang/Byte;

.field public static final DOUBLE_MINUS_ONE:Ljava/lang/Double;

.field public static final DOUBLE_ONE:Ljava/lang/Double;

.field public static final DOUBLE_ZERO:Ljava/lang/Double;

.field public static final FLOAT_MINUS_ONE:Ljava/lang/Float;

.field public static final FLOAT_ONE:Ljava/lang/Float;

.field public static final FLOAT_ZERO:Ljava/lang/Float;

.field public static final INTEGER_MINUS_ONE:Ljava/lang/Integer;

.field public static final INTEGER_ONE:Ljava/lang/Integer;

.field public static final INTEGER_ZERO:Ljava/lang/Integer;

.field public static final LONG_MINUS_ONE:Ljava/lang/Long;

.field public static final LONG_ONE:Ljava/lang/Long;

.field public static final LONG_ZERO:Ljava/lang/Long;

.field public static final SHORT_MINUS_ONE:Ljava/lang/Short;

.field public static final SHORT_ONE:Ljava/lang/Short;

.field public static final SHORT_ZERO:Ljava/lang/Short;


# direct methods
.method static constructor <clinit>()V
    .locals 5

    .prologue
    const/4 v4, 0x1

    const/4 v3, 0x0

    const/4 v2, -0x1

    .line 34
    const-wide/16 v0, 0x0

    invoke-static {v0, v1}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v0

    sput-object v0, Lorg/apache/commons/lang3/math/NumberUtils;->LONG_ZERO:Ljava/lang/Long;

    .line 36
    const-wide/16 v0, 0x1

    invoke-static {v0, v1}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v0

    sput-object v0, Lorg/apache/commons/lang3/math/NumberUtils;->LONG_ONE:Ljava/lang/Long;

    .line 38
    const-wide/16 v0, -0x1

    invoke-static {v0, v1}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v0

    sput-object v0, Lorg/apache/commons/lang3/math/NumberUtils;->LONG_MINUS_ONE:Ljava/lang/Long;

    .line 40
    invoke-static {v3}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v0

    sput-object v0, Lorg/apache/commons/lang3/math/NumberUtils;->INTEGER_ZERO:Ljava/lang/Integer;

    .line 42
    invoke-static {v4}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v0

    sput-object v0, Lorg/apache/commons/lang3/math/NumberUtils;->INTEGER_ONE:Ljava/lang/Integer;

    .line 44
    invoke-static {v2}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v0

    sput-object v0, Lorg/apache/commons/lang3/math/NumberUtils;->INTEGER_MINUS_ONE:Ljava/lang/Integer;

    .line 46
    invoke-static {v3}, Ljava/lang/Short;->valueOf(S)Ljava/lang/Short;

    move-result-object v0

    sput-object v0, Lorg/apache/commons/lang3/math/NumberUtils;->SHORT_ZERO:Ljava/lang/Short;

    .line 48
    invoke-static {v4}, Ljava/lang/Short;->valueOf(S)Ljava/lang/Short;

    move-result-object v0

    sput-object v0, Lorg/apache/commons/lang3/math/NumberUtils;->SHORT_ONE:Ljava/lang/Short;

    .line 50
    invoke-static {v2}, Ljava/lang/Short;->valueOf(S)Ljava/lang/Short;

    move-result-object v0

    sput-object v0, Lorg/apache/commons/lang3/math/NumberUtils;->SHORT_MINUS_ONE:Ljava/lang/Short;

    .line 52
    invoke-static {v3}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object v0

    sput-object v0, Lorg/apache/commons/lang3/math/NumberUtils;->BYTE_ZERO:Ljava/lang/Byte;

    .line 54
    invoke-static {v4}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object v0

    sput-object v0, Lorg/apache/commons/lang3/math/NumberUtils;->BYTE_ONE:Ljava/lang/Byte;

    .line 56
    invoke-static {v2}, Ljava/lang/Byte;->valueOf(B)Ljava/lang/Byte;

    move-result-object v0

    sput-object v0, Lorg/apache/commons/lang3/math/NumberUtils;->BYTE_MINUS_ONE:Ljava/lang/Byte;

    .line 58
    const-wide/16 v0, 0x0

    invoke-static {v0, v1}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v0

    sput-object v0, Lorg/apache/commons/lang3/math/NumberUtils;->DOUBLE_ZERO:Ljava/lang/Double;

    .line 60
    const-wide/high16 v0, 0x3ff0000000000000L    # 1.0

    invoke-static {v0, v1}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v0

    sput-object v0, Lorg/apache/commons/lang3/math/NumberUtils;->DOUBLE_ONE:Ljava/lang/Double;

    .line 62
    const-wide/high16 v0, -0x4010000000000000L    # -1.0

    invoke-static {v0, v1}, Ljava/lang/Double;->valueOf(D)Ljava/lang/Double;

    move-result-object v0

    sput-object v0, Lorg/apache/commons/lang3/math/NumberUtils;->DOUBLE_MINUS_ONE:Ljava/lang/Double;

    .line 64
    const/4 v0, 0x0

    invoke-static {v0}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v0

    sput-object v0, Lorg/apache/commons/lang3/math/NumberUtils;->FLOAT_ZERO:Ljava/lang/Float;

    .line 66
    const/high16 v0, 0x3f800000    # 1.0f

    invoke-static {v0}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v0

    sput-object v0, Lorg/apache/commons/lang3/math/NumberUtils;->FLOAT_ONE:Ljava/lang/Float;

    .line 68
    const/high16 v0, -0x40800000    # -1.0f

    invoke-static {v0}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v0

    sput-object v0, Lorg/apache/commons/lang3/math/NumberUtils;->FLOAT_MINUS_ONE:Ljava/lang/Float;

    return-void
.end method

.method public constructor <init>()V
    .locals 0

    .prologue
    .line 78
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 79
    return-void
.end method

.method public static createBigDecimal(Ljava/lang/String;)Ljava/math/BigDecimal;
    .locals 3
    .param p0, "str"    # Ljava/lang/String;

    .prologue
    .line 761
    if-nez p0, :cond_0

    .line 762
    const/4 v0, 0x0

    .line 775
    :goto_0
    return-object v0

    .line 765
    :cond_0
    invoke-static {p0}, Lorg/apache/commons/lang3/StringUtils;->isBlank(Ljava/lang/CharSequence;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 766
    new-instance v0, Ljava/lang/NumberFormatException;

    const-string v1, "A blank string is not a valid number"

    invoke-direct {v0, v1}, Ljava/lang/NumberFormatException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 768
    :cond_1
    invoke-virtual {p0}, Ljava/lang/String;->trim()Ljava/lang/String;

    move-result-object v0

    const-string v1, "--"

    invoke-virtual {v0, v1}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_2

    .line 773
    new-instance v0, Ljava/lang/NumberFormatException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, " is not a valid number."

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/lang/NumberFormatException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 775
    :cond_2
    new-instance v0, Ljava/math/BigDecimal;

    invoke-direct {v0, p0}, Ljava/math/BigDecimal;-><init>(Ljava/lang/String;)V

    goto :goto_0
.end method

.method public static createBigInteger(Ljava/lang/String;)Ljava/math/BigInteger;
    .locals 6
    .param p0, "str"    # Ljava/lang/String;

    .prologue
    .line 726
    if-nez p0, :cond_1

    .line 727
    const/4 v3, 0x0

    .line 748
    :cond_0
    :goto_0
    return-object v3

    .line 729
    :cond_1
    const/4 v1, 0x0

    .line 730
    .local v1, "pos":I
    const/16 v2, 0xa

    .line 731
    .local v2, "radix":I
    const/4 v0, 0x0

    .line 732
    .local v0, "negate":Z
    const-string v4, "-"

    invoke-virtual {p0, v4}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v4

    if-eqz v4, :cond_2

    .line 733
    const/4 v0, 0x1

    .line 734
    const/4 v1, 0x1

    .line 736
    :cond_2
    const-string v4, "0x"

    invoke-virtual {p0, v4, v1}, Ljava/lang/String;->startsWith(Ljava/lang/String;I)Z

    move-result v4

    if-nez v4, :cond_3

    const-string v4, "0x"

    invoke-virtual {p0, v4, v1}, Ljava/lang/String;->startsWith(Ljava/lang/String;I)Z

    move-result v4

    if-eqz v4, :cond_5

    .line 737
    :cond_3
    const/16 v2, 0x10

    .line 738
    add-int/lit8 v1, v1, 0x2

    .line 747
    :cond_4
    :goto_1
    new-instance v3, Ljava/math/BigInteger;

    invoke-virtual {p0, v1}, Ljava/lang/String;->substring(I)Ljava/lang/String;

    move-result-object v4

    invoke-direct {v3, v4, v2}, Ljava/math/BigInteger;-><init>(Ljava/lang/String;I)V

    .line 748
    .local v3, "value":Ljava/math/BigInteger;
    if-eqz v0, :cond_0

    invoke-virtual {v3}, Ljava/math/BigInteger;->negate()Ljava/math/BigInteger;

    move-result-object v3

    goto :goto_0

    .line 739
    .end local v3    # "value":Ljava/math/BigInteger;
    :cond_5
    const-string v4, "#"

    invoke-virtual {p0, v4, v1}, Ljava/lang/String;->startsWith(Ljava/lang/String;I)Z

    move-result v4

    if-eqz v4, :cond_6

    .line 740
    const/16 v2, 0x10

    .line 741
    add-int/lit8 v1, v1, 0x1

    goto :goto_1

    .line 742
    :cond_6
    const-string v4, "0"

    invoke-virtual {p0, v4, v1}, Ljava/lang/String;->startsWith(Ljava/lang/String;I)Z

    move-result v4

    if-eqz v4, :cond_4

    invoke-virtual {p0}, Ljava/lang/String;->length()I

    move-result v4

    add-int/lit8 v5, v1, 0x1

    if-le v4, v5, :cond_4

    .line 743
    const/16 v2, 0x8

    .line 744
    add-int/lit8 v1, v1, 0x1

    goto :goto_1
.end method

.method public static createDouble(Ljava/lang/String;)Ljava/lang/Double;
    .locals 1
    .param p0, "str"    # Ljava/lang/String;

    .prologue
    .line 672
    if-nez p0, :cond_0

    .line 673
    const/4 v0, 0x0

    .line 675
    :goto_0
    return-object v0

    :cond_0
    invoke-static {p0}, Ljava/lang/Double;->valueOf(Ljava/lang/String;)Ljava/lang/Double;

    move-result-object v0

    goto :goto_0
.end method

.method public static createFloat(Ljava/lang/String;)Ljava/lang/Float;
    .locals 1
    .param p0, "str"    # Ljava/lang/String;

    .prologue
    .line 656
    if-nez p0, :cond_0

    .line 657
    const/4 v0, 0x0

    .line 659
    :goto_0
    return-object v0

    :cond_0
    invoke-static {p0}, Ljava/lang/Float;->valueOf(Ljava/lang/String;)Ljava/lang/Float;

    move-result-object v0

    goto :goto_0
.end method

.method public static createInteger(Ljava/lang/String;)Ljava/lang/Integer;
    .locals 1
    .param p0, "str"    # Ljava/lang/String;

    .prologue
    .line 690
    if-nez p0, :cond_0

    .line 691
    const/4 v0, 0x0

    .line 694
    :goto_0
    return-object v0

    :cond_0
    invoke-static {p0}, Ljava/lang/Integer;->decode(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v0

    goto :goto_0
.end method

.method public static createLong(Ljava/lang/String;)Ljava/lang/Long;
    .locals 1
    .param p0, "str"    # Ljava/lang/String;

    .prologue
    .line 709
    if-nez p0, :cond_0

    .line 710
    const/4 v0, 0x0

    .line 712
    :goto_0
    return-object v0

    :cond_0
    invoke-static {p0}, Ljava/lang/Long;->decode(Ljava/lang/String;)Ljava/lang/Long;

    move-result-object v0

    goto :goto_0
.end method

.method public static createNumber(Ljava/lang/String;)Ljava/lang/Number;
    .locals 27
    .param p0, "str"    # Ljava/lang/String;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/lang/NumberFormatException;
        }
    .end annotation

    .prologue
    .line 451
    if-nez p0, :cond_1

    .line 452
    const/4 v10, 0x0

    .line 622
    :cond_0
    :goto_0
    return-object v10

    .line 454
    :cond_1
    invoke-static/range {p0 .. p0}, Lorg/apache/commons/lang3/StringUtils;->isBlank(Ljava/lang/CharSequence;)Z

    move-result v23

    if-eqz v23, :cond_2

    .line 455
    new-instance v23, Ljava/lang/NumberFormatException;

    const-string v24, "A blank string is not a valid number"

    invoke-direct/range {v23 .. v24}, Ljava/lang/NumberFormatException;-><init>(Ljava/lang/String;)V

    throw v23

    .line 458
    :cond_2
    const/16 v23, 0x6

    move/from16 v0, v23

    new-array v13, v0, [Ljava/lang/String;

    const/16 v23, 0x0

    const-string v24, "0x"

    aput-object v24, v13, v23

    const/16 v23, 0x1

    const-string v24, "0X"

    aput-object v24, v13, v23

    const/16 v23, 0x2

    const-string v24, "-0x"

    aput-object v24, v13, v23

    const/16 v23, 0x3

    const-string v24, "-0X"

    aput-object v24, v13, v23

    const/16 v23, 0x4

    const-string v24, "#"

    aput-object v24, v13, v23

    const/16 v23, 0x5

    const-string v24, "-#"

    aput-object v24, v13, v23

    .line 459
    .local v13, "hex_prefixes":[Ljava/lang/String;
    const/16 v22, 0x0

    .line 460
    .local v22, "pfxLen":I
    move-object v4, v13

    .local v4, "arr$":[Ljava/lang/String;
    array-length v0, v4

    move/from16 v17, v0

    .local v17, "len$":I
    const/4 v15, 0x0

    .local v15, "i$":I
    :goto_1
    move/from16 v0, v17

    if-ge v15, v0, :cond_3

    aget-object v21, v4, v15

    .line 461
    .local v21, "pfx":Ljava/lang/String;
    move-object/from16 v0, p0

    move-object/from16 v1, v21

    invoke-virtual {v0, v1}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v23

    if-eqz v23, :cond_4

    .line 462
    invoke-virtual/range {v21 .. v21}, Ljava/lang/String;->length()I

    move-result v23

    add-int v22, v22, v23

    .line 466
    .end local v21    # "pfx":Ljava/lang/String;
    :cond_3
    if-lez v22, :cond_a

    .line 467
    const/4 v11, 0x0

    .line 468
    .local v11, "firstSigDigit":C
    move/from16 v14, v22

    .local v14, "i":I
    :goto_2
    invoke-virtual/range {p0 .. p0}, Ljava/lang/String;->length()I

    move-result v23

    move/from16 v0, v23

    if-ge v14, v0, :cond_5

    .line 469
    move-object/from16 v0, p0

    invoke-virtual {v0, v14}, Ljava/lang/String;->charAt(I)C

    move-result v11

    .line 470
    const/16 v23, 0x30

    move/from16 v0, v23

    if-ne v11, v0, :cond_5

    .line 471
    add-int/lit8 v22, v22, 0x1

    .line 468
    add-int/lit8 v14, v14, 0x1

    goto :goto_2

    .line 460
    .end local v11    # "firstSigDigit":C
    .end local v14    # "i":I
    .restart local v21    # "pfx":Ljava/lang/String;
    :cond_4
    add-int/lit8 v15, v15, 0x1

    goto :goto_1

    .line 476
    .end local v21    # "pfx":Ljava/lang/String;
    .restart local v11    # "firstSigDigit":C
    .restart local v14    # "i":I
    :cond_5
    invoke-virtual/range {p0 .. p0}, Ljava/lang/String;->length()I

    move-result v23

    sub-int v12, v23, v22

    .line 477
    .local v12, "hexDigits":I
    const/16 v23, 0x10

    move/from16 v0, v23

    if-gt v12, v0, :cond_6

    const/16 v23, 0x10

    move/from16 v0, v23

    if-ne v12, v0, :cond_7

    const/16 v23, 0x37

    move/from16 v0, v23

    if-le v11, v0, :cond_7

    .line 478
    :cond_6
    invoke-static/range {p0 .. p0}, Lorg/apache/commons/lang3/math/NumberUtils;->createBigInteger(Ljava/lang/String;)Ljava/math/BigInteger;

    move-result-object v10

    goto/16 :goto_0

    .line 480
    :cond_7
    const/16 v23, 0x8

    move/from16 v0, v23

    if-gt v12, v0, :cond_8

    const/16 v23, 0x8

    move/from16 v0, v23

    if-ne v12, v0, :cond_9

    const/16 v23, 0x37

    move/from16 v0, v23

    if-le v11, v0, :cond_9

    .line 481
    :cond_8
    invoke-static/range {p0 .. p0}, Lorg/apache/commons/lang3/math/NumberUtils;->createLong(Ljava/lang/String;)Ljava/lang/Long;

    move-result-object v10

    goto/16 :goto_0

    .line 483
    :cond_9
    invoke-static/range {p0 .. p0}, Lorg/apache/commons/lang3/math/NumberUtils;->createInteger(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v10

    goto/16 :goto_0

    .line 485
    .end local v11    # "firstSigDigit":C
    .end local v12    # "hexDigits":I
    .end local v14    # "i":I
    :cond_a
    invoke-virtual/range {p0 .. p0}, Ljava/lang/String;->length()I

    move-result v23

    add-int/lit8 v23, v23, -0x1

    move-object/from16 v0, p0

    move/from16 v1, v23

    invoke-virtual {v0, v1}, Ljava/lang/String;->charAt(I)C

    move-result v16

    .line 489
    .local v16, "lastChar":C
    const/16 v23, 0x2e

    move-object/from16 v0, p0

    move/from16 v1, v23

    invoke-virtual {v0, v1}, Ljava/lang/String;->indexOf(I)I

    move-result v7

    .line 490
    .local v7, "decPos":I
    const/16 v23, 0x65

    move-object/from16 v0, p0

    move/from16 v1, v23

    invoke-virtual {v0, v1}, Ljava/lang/String;->indexOf(I)I

    move-result v23

    const/16 v24, 0x45

    move-object/from16 v0, p0

    move/from16 v1, v24

    invoke-virtual {v0, v1}, Ljava/lang/String;->indexOf(I)I

    move-result v24

    add-int v23, v23, v24

    add-int/lit8 v9, v23, 0x1

    .line 494
    .local v9, "expPos":I
    const/16 v19, 0x0

    .line 495
    .local v19, "numDecimals":I
    const/16 v23, -0x1

    move/from16 v0, v23

    if-le v7, v0, :cond_e

    .line 497
    const/16 v23, -0x1

    move/from16 v0, v23

    if-le v9, v0, :cond_d

    .line 498
    if-lt v9, v7, :cond_b

    invoke-virtual/range {p0 .. p0}, Ljava/lang/String;->length()I

    move-result v23

    move/from16 v0, v23

    if-le v9, v0, :cond_c

    .line 499
    :cond_b
    new-instance v23, Ljava/lang/NumberFormatException;

    new-instance v24, Ljava/lang/StringBuilder;

    invoke-direct/range {v24 .. v24}, Ljava/lang/StringBuilder;-><init>()V

    move-object/from16 v0, v24

    move-object/from16 v1, p0

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v24

    const-string v25, " is not a valid number."

    invoke-virtual/range {v24 .. v25}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v24

    invoke-virtual/range {v24 .. v24}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v24

    invoke-direct/range {v23 .. v24}, Ljava/lang/NumberFormatException;-><init>(Ljava/lang/String;)V

    throw v23

    .line 501
    :cond_c
    add-int/lit8 v23, v7, 0x1

    move-object/from16 v0, p0

    move/from16 v1, v23

    invoke-virtual {v0, v1, v9}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v6

    .line 505
    .local v6, "dec":Ljava/lang/String;
    :goto_3
    const/16 v23, 0x0

    move-object/from16 v0, p0

    move/from16 v1, v23

    invoke-virtual {v0, v1, v7}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v18

    .line 506
    .local v18, "mant":Ljava/lang/String;
    invoke-virtual {v6}, Ljava/lang/String;->length()I

    move-result v19

    .line 518
    :goto_4
    invoke-static/range {v16 .. v16}, Ljava/lang/Character;->isDigit(C)Z

    move-result v23

    if-nez v23, :cond_19

    const/16 v23, 0x2e

    move/from16 v0, v16

    move/from16 v1, v23

    if-eq v0, v1, :cond_19

    .line 519
    const/16 v23, -0x1

    move/from16 v0, v23

    if-le v9, v0, :cond_11

    invoke-virtual/range {p0 .. p0}, Ljava/lang/String;->length()I

    move-result v23

    add-int/lit8 v23, v23, -0x1

    move/from16 v0, v23

    if-ge v9, v0, :cond_11

    .line 520
    add-int/lit8 v23, v9, 0x1

    invoke-virtual/range {p0 .. p0}, Ljava/lang/String;->length()I

    move-result v24

    add-int/lit8 v24, v24, -0x1

    move-object/from16 v0, p0

    move/from16 v1, v23

    move/from16 v2, v24

    invoke-virtual {v0, v1, v2}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v8

    .line 525
    .local v8, "exp":Ljava/lang/String;
    :goto_5
    const/16 v23, 0x0

    invoke-virtual/range {p0 .. p0}, Ljava/lang/String;->length()I

    move-result v24

    add-int/lit8 v24, v24, -0x1

    move-object/from16 v0, p0

    move/from16 v1, v23

    move/from16 v2, v24

    invoke-virtual {v0, v1, v2}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v20

    .line 526
    .local v20, "numeric":Ljava/lang/String;
    invoke-static/range {v18 .. v18}, Lorg/apache/commons/lang3/math/NumberUtils;->isAllZeros(Ljava/lang/String;)Z

    move-result v23

    if-eqz v23, :cond_12

    invoke-static {v8}, Lorg/apache/commons/lang3/math/NumberUtils;->isAllZeros(Ljava/lang/String;)Z

    move-result v23

    if-eqz v23, :cond_12

    const/4 v3, 0x1

    .line 527
    .local v3, "allZeros":Z
    :goto_6
    sparse-switch v16, :sswitch_data_0

    .line 573
    :goto_7
    new-instance v23, Ljava/lang/NumberFormatException;

    new-instance v24, Ljava/lang/StringBuilder;

    invoke-direct/range {v24 .. v24}, Ljava/lang/StringBuilder;-><init>()V

    move-object/from16 v0, v24

    move-object/from16 v1, p0

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v24

    const-string v25, " is not a valid number."

    invoke-virtual/range {v24 .. v25}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v24

    invoke-virtual/range {v24 .. v24}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v24

    invoke-direct/range {v23 .. v24}, Ljava/lang/NumberFormatException;-><init>(Ljava/lang/String;)V

    throw v23

    .line 503
    .end local v3    # "allZeros":Z
    .end local v6    # "dec":Ljava/lang/String;
    .end local v8    # "exp":Ljava/lang/String;
    .end local v18    # "mant":Ljava/lang/String;
    .end local v20    # "numeric":Ljava/lang/String;
    :cond_d
    add-int/lit8 v23, v7, 0x1

    move-object/from16 v0, p0

    move/from16 v1, v23

    invoke-virtual {v0, v1}, Ljava/lang/String;->substring(I)Ljava/lang/String;

    move-result-object v6

    .restart local v6    # "dec":Ljava/lang/String;
    goto/16 :goto_3

    .line 508
    .end local v6    # "dec":Ljava/lang/String;
    :cond_e
    const/16 v23, -0x1

    move/from16 v0, v23

    if-le v9, v0, :cond_10

    .line 509
    invoke-virtual/range {p0 .. p0}, Ljava/lang/String;->length()I

    move-result v23

    move/from16 v0, v23

    if-le v9, v0, :cond_f

    .line 510
    new-instance v23, Ljava/lang/NumberFormatException;

    new-instance v24, Ljava/lang/StringBuilder;

    invoke-direct/range {v24 .. v24}, Ljava/lang/StringBuilder;-><init>()V

    move-object/from16 v0, v24

    move-object/from16 v1, p0

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v24

    const-string v25, " is not a valid number."

    invoke-virtual/range {v24 .. v25}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v24

    invoke-virtual/range {v24 .. v24}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v24

    invoke-direct/range {v23 .. v24}, Ljava/lang/NumberFormatException;-><init>(Ljava/lang/String;)V

    throw v23

    .line 512
    :cond_f
    const/16 v23, 0x0

    move-object/from16 v0, p0

    move/from16 v1, v23

    invoke-virtual {v0, v1, v9}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v18

    .line 516
    .restart local v18    # "mant":Ljava/lang/String;
    :goto_8
    const/4 v6, 0x0

    .restart local v6    # "dec":Ljava/lang/String;
    goto/16 :goto_4

    .line 514
    .end local v6    # "dec":Ljava/lang/String;
    .end local v18    # "mant":Ljava/lang/String;
    :cond_10
    move-object/from16 v18, p0

    .restart local v18    # "mant":Ljava/lang/String;
    goto :goto_8

    .line 522
    .restart local v6    # "dec":Ljava/lang/String;
    :cond_11
    const/4 v8, 0x0

    .restart local v8    # "exp":Ljava/lang/String;
    goto/16 :goto_5

    .line 526
    .restart local v20    # "numeric":Ljava/lang/String;
    :cond_12
    const/4 v3, 0x0

    goto :goto_6

    .line 530
    .restart local v3    # "allZeros":Z
    :sswitch_0
    if-nez v6, :cond_15

    if-nez v8, :cond_15

    const/16 v23, 0x0

    move-object/from16 v0, v20

    move/from16 v1, v23

    invoke-virtual {v0, v1}, Ljava/lang/String;->charAt(I)C

    move-result v23

    const/16 v24, 0x2d

    move/from16 v0, v23

    move/from16 v1, v24

    if-ne v0, v1, :cond_13

    const/16 v23, 0x1

    move-object/from16 v0, v20

    move/from16 v1, v23

    invoke-virtual {v0, v1}, Ljava/lang/String;->substring(I)Ljava/lang/String;

    move-result-object v23

    invoke-static/range {v23 .. v23}, Lorg/apache/commons/lang3/math/NumberUtils;->isDigits(Ljava/lang/String;)Z

    move-result v23

    if-nez v23, :cond_14

    :cond_13
    invoke-static/range {v20 .. v20}, Lorg/apache/commons/lang3/math/NumberUtils;->isDigits(Ljava/lang/String;)Z

    move-result v23

    if-eqz v23, :cond_15

    .line 534
    :cond_14
    :try_start_0
    invoke-static/range {v20 .. v20}, Lorg/apache/commons/lang3/math/NumberUtils;->createLong(Ljava/lang/String;)Ljava/lang/Long;
    :try_end_0
    .catch Ljava/lang/NumberFormatException; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v10

    goto/16 :goto_0

    .line 535
    :catch_0
    move-exception v23

    .line 538
    invoke-static/range {v20 .. v20}, Lorg/apache/commons/lang3/math/NumberUtils;->createBigInteger(Ljava/lang/String;)Ljava/math/BigInteger;

    move-result-object v10

    goto/16 :goto_0

    .line 541
    :cond_15
    new-instance v23, Ljava/lang/NumberFormatException;

    new-instance v24, Ljava/lang/StringBuilder;

    invoke-direct/range {v24 .. v24}, Ljava/lang/StringBuilder;-><init>()V

    move-object/from16 v0, v24

    move-object/from16 v1, p0

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v24

    const-string v25, " is not a valid number."

    invoke-virtual/range {v24 .. v25}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v24

    invoke-virtual/range {v24 .. v24}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v24

    invoke-direct/range {v23 .. v24}, Ljava/lang/NumberFormatException;-><init>(Ljava/lang/String;)V

    throw v23

    .line 545
    :sswitch_1
    :try_start_1
    invoke-static/range {v20 .. v20}, Lorg/apache/commons/lang3/math/NumberUtils;->createFloat(Ljava/lang/String;)Ljava/lang/Float;

    move-result-object v10

    .line 546
    .local v10, "f":Ljava/lang/Float;
    invoke-virtual {v10}, Ljava/lang/Float;->isInfinite()Z

    move-result v23

    if-nez v23, :cond_16

    invoke-virtual {v10}, Ljava/lang/Float;->floatValue()F
    :try_end_1
    .catch Ljava/lang/NumberFormatException; {:try_start_1 .. :try_end_1} :catch_7

    move-result v23

    const/16 v24, 0x0

    cmpl-float v23, v23, v24

    if-nez v23, :cond_0

    if-nez v3, :cond_0

    .line 559
    .end local v10    # "f":Ljava/lang/Float;
    :cond_16
    :goto_9
    :sswitch_2
    :try_start_2
    invoke-static/range {v20 .. v20}, Lorg/apache/commons/lang3/math/NumberUtils;->createDouble(Ljava/lang/String;)Ljava/lang/Double;

    move-result-object v5

    .line 560
    .local v5, "d":Ljava/lang/Double;
    invoke-virtual {v5}, Ljava/lang/Double;->isInfinite()Z

    move-result v23

    if-nez v23, :cond_18

    invoke-virtual {v5}, Ljava/lang/Double;->floatValue()F
    :try_end_2
    .catch Ljava/lang/NumberFormatException; {:try_start_2 .. :try_end_2} :catch_1

    move-result v23

    move/from16 v0, v23

    float-to-double v0, v0

    move-wide/from16 v23, v0

    const-wide/16 v25, 0x0

    cmpl-double v23, v23, v25

    if-nez v23, :cond_17

    if-eqz v3, :cond_18

    :cond_17
    move-object v10, v5

    .line 561
    goto/16 :goto_0

    .line 563
    .end local v5    # "d":Ljava/lang/Double;
    :catch_1
    move-exception v23

    .line 567
    :cond_18
    :try_start_3
    invoke-static/range {v20 .. v20}, Lorg/apache/commons/lang3/math/NumberUtils;->createBigDecimal(Ljava/lang/String;)Ljava/math/BigDecimal;
    :try_end_3
    .catch Ljava/lang/NumberFormatException; {:try_start_3 .. :try_end_3} :catch_5

    move-result-object v10

    goto/16 :goto_0

    .line 579
    .end local v3    # "allZeros":Z
    .end local v8    # "exp":Ljava/lang/String;
    .end local v20    # "numeric":Ljava/lang/String;
    :cond_19
    const/16 v23, -0x1

    move/from16 v0, v23

    if-le v9, v0, :cond_1a

    invoke-virtual/range {p0 .. p0}, Ljava/lang/String;->length()I

    move-result v23

    add-int/lit8 v23, v23, -0x1

    move/from16 v0, v23

    if-ge v9, v0, :cond_1a

    .line 580
    add-int/lit8 v23, v9, 0x1

    invoke-virtual/range {p0 .. p0}, Ljava/lang/String;->length()I

    move-result v24

    move-object/from16 v0, p0

    move/from16 v1, v23

    move/from16 v2, v24

    invoke-virtual {v0, v1, v2}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v8

    .line 584
    .restart local v8    # "exp":Ljava/lang/String;
    :goto_a
    if-nez v6, :cond_1b

    if-nez v8, :cond_1b

    .line 587
    :try_start_4
    invoke-static/range {p0 .. p0}, Lorg/apache/commons/lang3/math/NumberUtils;->createInteger(Ljava/lang/String;)Ljava/lang/Integer;
    :try_end_4
    .catch Ljava/lang/NumberFormatException; {:try_start_4 .. :try_end_4} :catch_2

    move-result-object v10

    goto/16 :goto_0

    .line 582
    .end local v8    # "exp":Ljava/lang/String;
    :cond_1a
    const/4 v8, 0x0

    .restart local v8    # "exp":Ljava/lang/String;
    goto :goto_a

    .line 588
    :catch_2
    move-exception v23

    .line 592
    :try_start_5
    invoke-static/range {p0 .. p0}, Lorg/apache/commons/lang3/math/NumberUtils;->createLong(Ljava/lang/String;)Ljava/lang/Long;
    :try_end_5
    .catch Ljava/lang/NumberFormatException; {:try_start_5 .. :try_end_5} :catch_3

    move-result-object v10

    goto/16 :goto_0

    .line 593
    :catch_3
    move-exception v23

    .line 596
    invoke-static/range {p0 .. p0}, Lorg/apache/commons/lang3/math/NumberUtils;->createBigInteger(Ljava/lang/String;)Ljava/math/BigInteger;

    move-result-object v10

    goto/16 :goto_0

    .line 600
    :cond_1b
    invoke-static/range {v18 .. v18}, Lorg/apache/commons/lang3/math/NumberUtils;->isAllZeros(Ljava/lang/String;)Z

    move-result v23

    if-eqz v23, :cond_1e

    invoke-static {v8}, Lorg/apache/commons/lang3/math/NumberUtils;->isAllZeros(Ljava/lang/String;)Z

    move-result v23

    if-eqz v23, :cond_1e

    const/4 v3, 0x1

    .line 602
    .restart local v3    # "allZeros":Z
    :goto_b
    const/16 v23, 0x7

    move/from16 v0, v19

    move/from16 v1, v23

    if-gt v0, v1, :cond_1c

    .line 603
    :try_start_6
    invoke-static/range {p0 .. p0}, Lorg/apache/commons/lang3/math/NumberUtils;->createFloat(Ljava/lang/String;)Ljava/lang/Float;

    move-result-object v10

    .line 604
    .restart local v10    # "f":Ljava/lang/Float;
    invoke-virtual {v10}, Ljava/lang/Float;->isInfinite()Z

    move-result v23

    if-nez v23, :cond_1c

    invoke-virtual {v10}, Ljava/lang/Float;->floatValue()F
    :try_end_6
    .catch Ljava/lang/NumberFormatException; {:try_start_6 .. :try_end_6} :catch_6

    move-result v23

    const/16 v24, 0x0

    cmpl-float v23, v23, v24

    if-nez v23, :cond_0

    if-nez v3, :cond_0

    .line 612
    .end local v10    # "f":Ljava/lang/Float;
    :cond_1c
    :goto_c
    const/16 v23, 0x10

    move/from16 v0, v19

    move/from16 v1, v23

    if-gt v0, v1, :cond_1f

    .line 613
    :try_start_7
    invoke-static/range {p0 .. p0}, Lorg/apache/commons/lang3/math/NumberUtils;->createDouble(Ljava/lang/String;)Ljava/lang/Double;

    move-result-object v5

    .line 614
    .restart local v5    # "d":Ljava/lang/Double;
    invoke-virtual {v5}, Ljava/lang/Double;->isInfinite()Z

    move-result v23

    if-nez v23, :cond_1f

    invoke-virtual {v5}, Ljava/lang/Double;->doubleValue()D
    :try_end_7
    .catch Ljava/lang/NumberFormatException; {:try_start_7 .. :try_end_7} :catch_4

    move-result-wide v23

    const-wide/16 v25, 0x0

    cmpl-double v23, v23, v25

    if-nez v23, :cond_1d

    if-eqz v3, :cond_1f

    :cond_1d
    move-object v10, v5

    .line 615
    goto/16 :goto_0

    .line 600
    .end local v3    # "allZeros":Z
    .end local v5    # "d":Ljava/lang/Double;
    :cond_1e
    const/4 v3, 0x0

    goto :goto_b

    .line 618
    .restart local v3    # "allZeros":Z
    :catch_4
    move-exception v23

    .line 622
    :cond_1f
    invoke-static/range {p0 .. p0}, Lorg/apache/commons/lang3/math/NumberUtils;->createBigDecimal(Ljava/lang/String;)Ljava/math/BigDecimal;

    move-result-object v10

    goto/16 :goto_0

    .line 568
    .restart local v20    # "numeric":Ljava/lang/String;
    :catch_5
    move-exception v23

    goto/16 :goto_7

    .line 608
    .end local v20    # "numeric":Ljava/lang/String;
    :catch_6
    move-exception v23

    goto :goto_c

    .line 552
    .restart local v20    # "numeric":Ljava/lang/String;
    :catch_7
    move-exception v23

    goto/16 :goto_9

    .line 527
    :sswitch_data_0
    .sparse-switch
        0x44 -> :sswitch_2
        0x46 -> :sswitch_1
        0x4c -> :sswitch_0
        0x64 -> :sswitch_2
        0x66 -> :sswitch_1
        0x6c -> :sswitch_0
    .end sparse-switch
.end method

.method private static isAllZeros(Ljava/lang/String;)Z
    .locals 5
    .param p0, "str"    # Ljava/lang/String;

    .prologue
    const/4 v1, 0x1

    const/4 v2, 0x0

    .line 634
    if-nez p0, :cond_1

    .line 642
    :cond_0
    :goto_0
    return v1

    .line 637
    :cond_1
    invoke-virtual {p0}, Ljava/lang/String;->length()I

    move-result v3

    add-int/lit8 v0, v3, -0x1

    .local v0, "i":I
    :goto_1
    if-ltz v0, :cond_3

    .line 638
    invoke-virtual {p0, v0}, Ljava/lang/String;->charAt(I)C

    move-result v3

    const/16 v4, 0x30

    if-eq v3, v4, :cond_2

    move v1, v2

    .line 639
    goto :goto_0

    .line 637
    :cond_2
    add-int/lit8 v0, v0, -0x1

    goto :goto_1

    .line 642
    :cond_3
    invoke-virtual {p0}, Ljava/lang/String;->length()I

    move-result v3

    if-gtz v3, :cond_0

    move v1, v2

    goto :goto_0
.end method

.method public static isDigits(Ljava/lang/String;)Z
    .locals 3
    .param p0, "str"    # Ljava/lang/String;

    .prologue
    const/4 v1, 0x0

    .line 1312
    invoke-static {p0}, Lorg/apache/commons/lang3/StringUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v2

    if-eqz v2, :cond_1

    .line 1320
    :cond_0
    :goto_0
    return v1

    .line 1315
    :cond_1
    const/4 v0, 0x0

    .local v0, "i":I
    :goto_1
    invoke-virtual {p0}, Ljava/lang/String;->length()I

    move-result v2

    if-ge v0, v2, :cond_2

    .line 1316
    invoke-virtual {p0, v0}, Ljava/lang/String;->charAt(I)C

    move-result v2

    invoke-static {v2}, Ljava/lang/Character;->isDigit(C)Z

    move-result v2

    if-eqz v2, :cond_0

    .line 1315
    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    .line 1320
    :cond_2
    const/4 v1, 0x1

    goto :goto_0
.end method

.method public static isNumber(Ljava/lang/String;)Z
    .locals 15
    .param p0, "str"    # Ljava/lang/String;

    .prologue
    const/16 v14, 0x2d

    const/16 v13, 0x39

    const/16 v12, 0x30

    const/4 v8, 0x1

    const/4 v9, 0x0

    .line 1338
    invoke-static {p0}, Lorg/apache/commons/lang3/StringUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v10

    if-eqz v10, :cond_1

    .line 1450
    :cond_0
    :goto_0
    return v9

    .line 1341
    :cond_1
    invoke-virtual {p0}, Ljava/lang/String;->toCharArray()[C

    move-result-object v1

    .line 1342
    .local v1, "chars":[C
    array-length v7, v1

    .line 1343
    .local v7, "sz":I
    const/4 v4, 0x0

    .line 1344
    .local v4, "hasExp":Z
    const/4 v3, 0x0

    .line 1345
    .local v3, "hasDecPoint":Z
    const/4 v0, 0x0

    .line 1346
    .local v0, "allowSigns":Z
    const/4 v2, 0x0

    .line 1348
    .local v2, "foundDigit":Z
    aget-char v10, v1, v9

    if-ne v10, v14, :cond_6

    move v6, v8

    .line 1349
    .local v6, "start":I
    :goto_1
    add-int/lit8 v10, v6, 0x1

    if-le v7, v10, :cond_a

    aget-char v10, v1, v6

    if-ne v10, v12, :cond_a

    .line 1350
    add-int/lit8 v10, v6, 0x1

    aget-char v10, v1, v10

    const/16 v11, 0x78

    if-eq v10, v11, :cond_2

    add-int/lit8 v10, v6, 0x1

    aget-char v10, v1, v10

    const/16 v11, 0x58

    if-ne v10, v11, :cond_8

    .line 1354
    :cond_2
    add-int/lit8 v5, v6, 0x2

    .line 1355
    .local v5, "i":I
    if-eq v5, v7, :cond_0

    .line 1359
    :goto_2
    array-length v10, v1

    if-ge v5, v10, :cond_7

    .line 1360
    aget-char v10, v1, v5

    if-lt v10, v12, :cond_3

    aget-char v10, v1, v5

    if-le v10, v13, :cond_5

    :cond_3
    aget-char v10, v1, v5

    const/16 v11, 0x61

    if-lt v10, v11, :cond_4

    aget-char v10, v1, v5

    const/16 v11, 0x66

    if-le v10, v11, :cond_5

    :cond_4
    aget-char v10, v1, v5

    const/16 v11, 0x41

    if-lt v10, v11, :cond_0

    aget-char v10, v1, v5

    const/16 v11, 0x46

    if-gt v10, v11, :cond_0

    .line 1359
    :cond_5
    add-int/lit8 v5, v5, 0x1

    goto :goto_2

    .end local v5    # "i":I
    .end local v6    # "start":I
    :cond_6
    move v6, v9

    .line 1348
    goto :goto_1

    .restart local v5    # "i":I
    .restart local v6    # "start":I
    :cond_7
    move v9, v8

    .line 1366
    goto :goto_0

    .line 1367
    .end local v5    # "i":I
    :cond_8
    add-int/lit8 v10, v6, 0x1

    aget-char v10, v1, v10

    invoke-static {v10}, Ljava/lang/Character;->isDigit(C)Z

    move-result v10

    if-eqz v10, :cond_a

    .line 1369
    add-int/lit8 v5, v6, 0x1

    .line 1370
    .restart local v5    # "i":I
    :goto_3
    array-length v10, v1

    if-ge v5, v10, :cond_9

    .line 1371
    aget-char v10, v1, v5

    if-lt v10, v12, :cond_0

    aget-char v10, v1, v5

    const/16 v11, 0x37

    if-gt v10, v11, :cond_0

    .line 1370
    add-int/lit8 v5, v5, 0x1

    goto :goto_3

    :cond_9
    move v9, v8

    .line 1375
    goto :goto_0

    .line 1378
    .end local v5    # "i":I
    :cond_a
    add-int/lit8 v7, v7, -0x1

    .line 1380
    move v5, v6

    .line 1383
    .restart local v5    # "i":I
    :goto_4
    if-lt v5, v7, :cond_b

    add-int/lit8 v10, v7, 0x1

    if-ge v5, v10, :cond_11

    if-eqz v0, :cond_11

    if-nez v2, :cond_11

    .line 1384
    :cond_b
    aget-char v10, v1, v5

    if-lt v10, v12, :cond_c

    aget-char v10, v1, v5

    if-gt v10, v13, :cond_c

    .line 1385
    const/4 v2, 0x1

    .line 1386
    const/4 v0, 0x0

    .line 1414
    :goto_5
    add-int/lit8 v5, v5, 0x1

    goto :goto_4

    .line 1388
    :cond_c
    aget-char v10, v1, v5

    const/16 v11, 0x2e

    if-ne v10, v11, :cond_d

    .line 1389
    if-nez v3, :cond_0

    if-nez v4, :cond_0

    .line 1393
    const/4 v3, 0x1

    goto :goto_5

    .line 1394
    :cond_d
    aget-char v10, v1, v5

    const/16 v11, 0x65

    if-eq v10, v11, :cond_e

    aget-char v10, v1, v5

    const/16 v11, 0x45

    if-ne v10, v11, :cond_f

    .line 1396
    :cond_e
    if-nez v4, :cond_0

    .line 1400
    if-eqz v2, :cond_0

    .line 1403
    const/4 v4, 0x1

    .line 1404
    const/4 v0, 0x1

    goto :goto_5

    .line 1405
    :cond_f
    aget-char v10, v1, v5

    const/16 v11, 0x2b

    if-eq v10, v11, :cond_10

    aget-char v10, v1, v5

    if-ne v10, v14, :cond_0

    .line 1406
    :cond_10
    if-eqz v0, :cond_0

    .line 1409
    const/4 v0, 0x0

    .line 1410
    const/4 v2, 0x0

    goto :goto_5

    .line 1416
    :cond_11
    array-length v10, v1

    if-ge v5, v10, :cond_18

    .line 1417
    aget-char v10, v1, v5

    if-lt v10, v12, :cond_12

    aget-char v10, v1, v5

    if-gt v10, v13, :cond_12

    move v9, v8

    .line 1419
    goto/16 :goto_0

    .line 1421
    :cond_12
    aget-char v10, v1, v5

    const/16 v11, 0x65

    if-eq v10, v11, :cond_0

    aget-char v10, v1, v5

    const/16 v11, 0x45

    if-eq v10, v11, :cond_0

    .line 1425
    aget-char v10, v1, v5

    const/16 v11, 0x2e

    if-ne v10, v11, :cond_13

    .line 1426
    if-nez v3, :cond_0

    if-nez v4, :cond_0

    move v9, v2

    .line 1431
    goto/16 :goto_0

    .line 1433
    :cond_13
    if-nez v0, :cond_15

    aget-char v10, v1, v5

    const/16 v11, 0x64

    if-eq v10, v11, :cond_14

    aget-char v10, v1, v5

    const/16 v11, 0x44

    if-eq v10, v11, :cond_14

    aget-char v10, v1, v5

    const/16 v11, 0x66

    if-eq v10, v11, :cond_14

    aget-char v10, v1, v5

    const/16 v11, 0x46

    if-ne v10, v11, :cond_15

    :cond_14
    move v9, v2

    .line 1438
    goto/16 :goto_0

    .line 1440
    :cond_15
    aget-char v10, v1, v5

    const/16 v11, 0x6c

    if-eq v10, v11, :cond_16

    aget-char v10, v1, v5

    const/16 v11, 0x4c

    if-ne v10, v11, :cond_0

    .line 1443
    :cond_16
    if-eqz v2, :cond_17

    if-nez v4, :cond_17

    if-nez v3, :cond_17

    :goto_6
    move v9, v8

    goto/16 :goto_0

    :cond_17
    move v8, v9

    goto :goto_6

    .line 1450
    :cond_18
    if-nez v0, :cond_19

    if-eqz v2, :cond_19

    :goto_7
    move v9, v8

    goto/16 :goto_0

    :cond_19
    move v8, v9

    goto :goto_7
.end method

.method public static max(BBB)B
    .locals 0
    .param p0, "a"    # B
    .param p1, "b"    # B
    .param p2, "c"    # B

    .prologue
    .line 1259
    if-le p1, p0, :cond_0

    .line 1260
    move p0, p1

    .line 1262
    :cond_0
    if-le p2, p0, :cond_1

    .line 1263
    move p0, p2

    .line 1265
    :cond_1
    return p0
.end method

.method public static max([B)B
    .locals 3
    .param p0, "array"    # [B

    .prologue
    .line 1007
    invoke-static {p0}, Lorg/apache/commons/lang3/math/NumberUtils;->validateArray(Ljava/lang/Object;)V

    .line 1010
    const/4 v2, 0x0

    aget-byte v1, p0, v2

    .line 1011
    .local v1, "max":B
    const/4 v0, 0x1

    .local v0, "i":I
    :goto_0
    array-length v2, p0

    if-ge v0, v2, :cond_1

    .line 1012
    aget-byte v2, p0, v0

    if-le v2, v1, :cond_0

    .line 1013
    aget-byte v1, p0, v0

    .line 1011
    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 1017
    :cond_1
    return v1
.end method

.method public static max(DDD)D
    .locals 2
    .param p0, "a"    # D
    .param p2, "b"    # D
    .param p4, "c"    # D

    .prologue
    .line 1281
    invoke-static {p0, p1, p2, p3}, Ljava/lang/Math;->max(DD)D

    move-result-wide v0

    invoke-static {v0, v1, p4, p5}, Ljava/lang/Math;->max(DD)D

    move-result-wide v0

    return-wide v0
.end method

.method public static max([D)D
    .locals 5
    .param p0, "array"    # [D

    .prologue
    .line 1031
    invoke-static {p0}, Lorg/apache/commons/lang3/math/NumberUtils;->validateArray(Ljava/lang/Object;)V

    .line 1034
    const/4 v3, 0x0

    aget-wide v1, p0, v3

    .line 1035
    .local v1, "max":D
    const/4 v0, 0x1

    .local v0, "j":I
    :goto_0
    array-length v3, p0

    if-ge v0, v3, :cond_0

    .line 1036
    aget-wide v3, p0, v0

    invoke-static {v3, v4}, Ljava/lang/Double;->isNaN(D)Z

    move-result v3

    if-eqz v3, :cond_1

    .line 1037
    const-wide/high16 v1, 0x7ff8000000000000L    # NaN

    .line 1044
    .end local v1    # "max":D
    :cond_0
    return-wide v1

    .line 1039
    .restart local v1    # "max":D
    :cond_1
    aget-wide v3, p0, v0

    cmpl-double v3, v3, v1

    if-lez v3, :cond_2

    .line 1040
    aget-wide v1, p0, v0

    .line 1035
    :cond_2
    add-int/lit8 v0, v0, 0x1

    goto :goto_0
.end method

.method public static max(FFF)F
    .locals 1
    .param p0, "a"    # F
    .param p1, "b"    # F
    .param p2, "c"    # F

    .prologue
    .line 1297
    invoke-static {p0, p1}, Ljava/lang/Math;->max(FF)F

    move-result v0

    invoke-static {v0, p2}, Ljava/lang/Math;->max(FF)F

    move-result v0

    return v0
.end method

.method public static max([F)F
    .locals 3
    .param p0, "array"    # [F

    .prologue
    .line 1058
    invoke-static {p0}, Lorg/apache/commons/lang3/math/NumberUtils;->validateArray(Ljava/lang/Object;)V

    .line 1061
    const/4 v2, 0x0

    aget v1, p0, v2

    .line 1062
    .local v1, "max":F
    const/4 v0, 0x1

    .local v0, "j":I
    :goto_0
    array-length v2, p0

    if-ge v0, v2, :cond_0

    .line 1063
    aget v2, p0, v0

    invoke-static {v2}, Ljava/lang/Float;->isNaN(F)Z

    move-result v2

    if-eqz v2, :cond_1

    .line 1064
    const/high16 v1, 0x7fc00000    # NaNf

    .line 1071
    .end local v1    # "max":F
    :cond_0
    return v1

    .line 1066
    .restart local v1    # "max":F
    :cond_1
    aget v2, p0, v0

    cmpl-float v2, v2, v1

    if-lez v2, :cond_2

    .line 1067
    aget v1, p0, v0

    .line 1062
    :cond_2
    add-int/lit8 v0, v0, 0x1

    goto :goto_0
.end method

.method public static max(III)I
    .locals 0
    .param p0, "a"    # I
    .param p1, "b"    # I
    .param p2, "c"    # I

    .prologue
    .line 1223
    if-le p1, p0, :cond_0

    .line 1224
    move p0, p1

    .line 1226
    :cond_0
    if-le p2, p0, :cond_1

    .line 1227
    move p0, p2

    .line 1229
    :cond_1
    return p0
.end method

.method public static max([I)I
    .locals 3
    .param p0, "array"    # [I

    .prologue
    .line 961
    invoke-static {p0}, Lorg/apache/commons/lang3/math/NumberUtils;->validateArray(Ljava/lang/Object;)V

    .line 964
    const/4 v2, 0x0

    aget v1, p0, v2

    .line 965
    .local v1, "max":I
    const/4 v0, 0x1

    .local v0, "j":I
    :goto_0
    array-length v2, p0

    if-ge v0, v2, :cond_1

    .line 966
    aget v2, p0, v0

    if-le v2, v1, :cond_0

    .line 967
    aget v1, p0, v0

    .line 965
    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 971
    :cond_1
    return v1
.end method

.method public static max(JJJ)J
    .locals 1
    .param p0, "a"    # J
    .param p2, "b"    # J
    .param p4, "c"    # J

    .prologue
    .line 1205
    cmp-long v0, p2, p0

    if-lez v0, :cond_0

    .line 1206
    move-wide p0, p2

    .line 1208
    :cond_0
    cmp-long v0, p4, p0

    if-lez v0, :cond_1

    .line 1209
    move-wide p0, p4

    .line 1211
    :cond_1
    return-wide p0
.end method

.method public static max([J)J
    .locals 5
    .param p0, "array"    # [J

    .prologue
    .line 938
    invoke-static {p0}, Lorg/apache/commons/lang3/math/NumberUtils;->validateArray(Ljava/lang/Object;)V

    .line 941
    const/4 v3, 0x0

    aget-wide v1, p0, v3

    .line 942
    .local v1, "max":J
    const/4 v0, 0x1

    .local v0, "j":I
    :goto_0
    array-length v3, p0

    if-ge v0, v3, :cond_1

    .line 943
    aget-wide v3, p0, v0

    cmp-long v3, v3, v1

    if-lez v3, :cond_0

    .line 944
    aget-wide v1, p0, v0

    .line 942
    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 948
    :cond_1
    return-wide v1
.end method

.method public static max(SSS)S
    .locals 0
    .param p0, "a"    # S
    .param p1, "b"    # S
    .param p2, "c"    # S

    .prologue
    .line 1241
    if-le p1, p0, :cond_0

    .line 1242
    move p0, p1

    .line 1244
    :cond_0
    if-le p2, p0, :cond_1

    .line 1245
    move p0, p2

    .line 1247
    :cond_1
    return p0
.end method

.method public static max([S)S
    .locals 3
    .param p0, "array"    # [S

    .prologue
    .line 984
    invoke-static {p0}, Lorg/apache/commons/lang3/math/NumberUtils;->validateArray(Ljava/lang/Object;)V

    .line 987
    const/4 v2, 0x0

    aget-short v1, p0, v2

    .line 988
    .local v1, "max":S
    const/4 v0, 0x1

    .local v0, "i":I
    :goto_0
    array-length v2, p0

    if-ge v0, v2, :cond_1

    .line 989
    aget-short v2, p0, v0

    if-le v2, v1, :cond_0

    .line 990
    aget-short v1, p0, v0

    .line 988
    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 994
    :cond_1
    return v1
.end method

.method public static min(BBB)B
    .locals 0
    .param p0, "a"    # B
    .param p1, "b"    # B
    .param p2, "c"    # B

    .prologue
    .line 1153
    if-ge p1, p0, :cond_0

    .line 1154
    move p0, p1

    .line 1156
    :cond_0
    if-ge p2, p0, :cond_1

    .line 1157
    move p0, p2

    .line 1159
    :cond_1
    return p0
.end method

.method public static min([B)B
    .locals 3
    .param p0, "array"    # [B

    .prologue
    .line 859
    invoke-static {p0}, Lorg/apache/commons/lang3/math/NumberUtils;->validateArray(Ljava/lang/Object;)V

    .line 862
    const/4 v2, 0x0

    aget-byte v1, p0, v2

    .line 863
    .local v1, "min":B
    const/4 v0, 0x1

    .local v0, "i":I
    :goto_0
    array-length v2, p0

    if-ge v0, v2, :cond_1

    .line 864
    aget-byte v2, p0, v0

    if-ge v2, v1, :cond_0

    .line 865
    aget-byte v1, p0, v0

    .line 863
    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 869
    :cond_1
    return v1
.end method

.method public static min(DDD)D
    .locals 2
    .param p0, "a"    # D
    .param p2, "b"    # D
    .param p4, "c"    # D

    .prologue
    .line 1175
    invoke-static {p0, p1, p2, p3}, Ljava/lang/Math;->min(DD)D

    move-result-wide v0

    invoke-static {v0, v1, p4, p5}, Ljava/lang/Math;->min(DD)D

    move-result-wide v0

    return-wide v0
.end method

.method public static min([D)D
    .locals 5
    .param p0, "array"    # [D

    .prologue
    .line 883
    invoke-static {p0}, Lorg/apache/commons/lang3/math/NumberUtils;->validateArray(Ljava/lang/Object;)V

    .line 886
    const/4 v3, 0x0

    aget-wide v1, p0, v3

    .line 887
    .local v1, "min":D
    const/4 v0, 0x1

    .local v0, "i":I
    :goto_0
    array-length v3, p0

    if-ge v0, v3, :cond_0

    .line 888
    aget-wide v3, p0, v0

    invoke-static {v3, v4}, Ljava/lang/Double;->isNaN(D)Z

    move-result v3

    if-eqz v3, :cond_1

    .line 889
    const-wide/high16 v1, 0x7ff8000000000000L    # NaN

    .line 896
    .end local v1    # "min":D
    :cond_0
    return-wide v1

    .line 891
    .restart local v1    # "min":D
    :cond_1
    aget-wide v3, p0, v0

    cmpg-double v3, v3, v1

    if-gez v3, :cond_2

    .line 892
    aget-wide v1, p0, v0

    .line 887
    :cond_2
    add-int/lit8 v0, v0, 0x1

    goto :goto_0
.end method

.method public static min(FFF)F
    .locals 1
    .param p0, "a"    # F
    .param p1, "b"    # F
    .param p2, "c"    # F

    .prologue
    .line 1191
    invoke-static {p0, p1}, Ljava/lang/Math;->min(FF)F

    move-result v0

    invoke-static {v0, p2}, Ljava/lang/Math;->min(FF)F

    move-result v0

    return v0
.end method

.method public static min([F)F
    .locals 3
    .param p0, "array"    # [F

    .prologue
    .line 910
    invoke-static {p0}, Lorg/apache/commons/lang3/math/NumberUtils;->validateArray(Ljava/lang/Object;)V

    .line 913
    const/4 v2, 0x0

    aget v1, p0, v2

    .line 914
    .local v1, "min":F
    const/4 v0, 0x1

    .local v0, "i":I
    :goto_0
    array-length v2, p0

    if-ge v0, v2, :cond_0

    .line 915
    aget v2, p0, v0

    invoke-static {v2}, Ljava/lang/Float;->isNaN(F)Z

    move-result v2

    if-eqz v2, :cond_1

    .line 916
    const/high16 v1, 0x7fc00000    # NaNf

    .line 923
    .end local v1    # "min":F
    :cond_0
    return v1

    .line 918
    .restart local v1    # "min":F
    :cond_1
    aget v2, p0, v0

    cmpg-float v2, v2, v1

    if-gez v2, :cond_2

    .line 919
    aget v1, p0, v0

    .line 914
    :cond_2
    add-int/lit8 v0, v0, 0x1

    goto :goto_0
.end method

.method public static min(III)I
    .locals 0
    .param p0, "a"    # I
    .param p1, "b"    # I
    .param p2, "c"    # I

    .prologue
    .line 1117
    if-ge p1, p0, :cond_0

    .line 1118
    move p0, p1

    .line 1120
    :cond_0
    if-ge p2, p0, :cond_1

    .line 1121
    move p0, p2

    .line 1123
    :cond_1
    return p0
.end method

.method public static min([I)I
    .locals 3
    .param p0, "array"    # [I

    .prologue
    .line 813
    invoke-static {p0}, Lorg/apache/commons/lang3/math/NumberUtils;->validateArray(Ljava/lang/Object;)V

    .line 816
    const/4 v2, 0x0

    aget v1, p0, v2

    .line 817
    .local v1, "min":I
    const/4 v0, 0x1

    .local v0, "j":I
    :goto_0
    array-length v2, p0

    if-ge v0, v2, :cond_1

    .line 818
    aget v2, p0, v0

    if-ge v2, v1, :cond_0

    .line 819
    aget v1, p0, v0

    .line 817
    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 823
    :cond_1
    return v1
.end method

.method public static min(JJJ)J
    .locals 1
    .param p0, "a"    # J
    .param p2, "b"    # J
    .param p4, "c"    # J

    .prologue
    .line 1099
    cmp-long v0, p2, p0

    if-gez v0, :cond_0

    .line 1100
    move-wide p0, p2

    .line 1102
    :cond_0
    cmp-long v0, p4, p0

    if-gez v0, :cond_1

    .line 1103
    move-wide p0, p4

    .line 1105
    :cond_1
    return-wide p0
.end method

.method public static min([J)J
    .locals 5
    .param p0, "array"    # [J

    .prologue
    .line 790
    invoke-static {p0}, Lorg/apache/commons/lang3/math/NumberUtils;->validateArray(Ljava/lang/Object;)V

    .line 793
    const/4 v3, 0x0

    aget-wide v1, p0, v3

    .line 794
    .local v1, "min":J
    const/4 v0, 0x1

    .local v0, "i":I
    :goto_0
    array-length v3, p0

    if-ge v0, v3, :cond_1

    .line 795
    aget-wide v3, p0, v0

    cmp-long v3, v3, v1

    if-gez v3, :cond_0

    .line 796
    aget-wide v1, p0, v0

    .line 794
    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 800
    :cond_1
    return-wide v1
.end method

.method public static min(SSS)S
    .locals 0
    .param p0, "a"    # S
    .param p1, "b"    # S
    .param p2, "c"    # S

    .prologue
    .line 1135
    if-ge p1, p0, :cond_0

    .line 1136
    move p0, p1

    .line 1138
    :cond_0
    if-ge p2, p0, :cond_1

    .line 1139
    move p0, p2

    .line 1141
    :cond_1
    return p0
.end method

.method public static min([S)S
    .locals 3
    .param p0, "array"    # [S

    .prologue
    .line 836
    invoke-static {p0}, Lorg/apache/commons/lang3/math/NumberUtils;->validateArray(Ljava/lang/Object;)V

    .line 839
    const/4 v2, 0x0

    aget-short v1, p0, v2

    .line 840
    .local v1, "min":S
    const/4 v0, 0x1

    .local v0, "i":I
    :goto_0
    array-length v2, p0

    if-ge v0, v2, :cond_1

    .line 841
    aget-short v2, p0, v0

    if-ge v2, v1, :cond_0

    .line 842
    aget-short v1, p0, v0

    .line 840
    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 846
    :cond_1
    return v1
.end method

.method public static toByte(Ljava/lang/String;)B
    .locals 1
    .param p0, "str"    # Ljava/lang/String;

    .prologue
    .line 303
    const/4 v0, 0x0

    invoke-static {p0, v0}, Lorg/apache/commons/lang3/math/NumberUtils;->toByte(Ljava/lang/String;B)B

    move-result v0

    return v0
.end method

.method public static toByte(Ljava/lang/String;B)B
    .locals 1
    .param p0, "str"    # Ljava/lang/String;
    .param p1, "defaultValue"    # B

    .prologue
    .line 324
    if-nez p0, :cond_0

    .line 330
    .end local p1    # "defaultValue":B
    :goto_0
    return p1

    .line 328
    .restart local p1    # "defaultValue":B
    :cond_0
    :try_start_0
    invoke-static {p0}, Ljava/lang/Byte;->parseByte(Ljava/lang/String;)B
    :try_end_0
    .catch Ljava/lang/NumberFormatException; {:try_start_0 .. :try_end_0} :catch_0

    move-result p1

    goto :goto_0

    .line 329
    :catch_0
    move-exception v0

    .line 330
    .local v0, "nfe":Ljava/lang/NumberFormatException;
    goto :goto_0
.end method

.method public static toDouble(Ljava/lang/String;)D
    .locals 2
    .param p0, "str"    # Ljava/lang/String;

    .prologue
    .line 251
    const-wide/16 v0, 0x0

    invoke-static {p0, v0, v1}, Lorg/apache/commons/lang3/math/NumberUtils;->toDouble(Ljava/lang/String;D)D

    move-result-wide v0

    return-wide v0
.end method

.method public static toDouble(Ljava/lang/String;D)D
    .locals 1
    .param p0, "str"    # Ljava/lang/String;
    .param p1, "defaultValue"    # D

    .prologue
    .line 274
    if-nez p0, :cond_0

    .line 280
    .end local p1    # "defaultValue":D
    :goto_0
    return-wide p1

    .line 278
    .restart local p1    # "defaultValue":D
    :cond_0
    :try_start_0
    invoke-static {p0}, Ljava/lang/Double;->parseDouble(Ljava/lang/String;)D
    :try_end_0
    .catch Ljava/lang/NumberFormatException; {:try_start_0 .. :try_end_0} :catch_0

    move-result-wide p1

    goto :goto_0

    .line 279
    :catch_0
    move-exception v0

    .line 280
    .local v0, "nfe":Ljava/lang/NumberFormatException;
    goto :goto_0
.end method

.method public static toFloat(Ljava/lang/String;)F
    .locals 1
    .param p0, "str"    # Ljava/lang/String;

    .prologue
    .line 199
    const/4 v0, 0x0

    invoke-static {p0, v0}, Lorg/apache/commons/lang3/math/NumberUtils;->toFloat(Ljava/lang/String;F)F

    move-result v0

    return v0
.end method

.method public static toFloat(Ljava/lang/String;F)F
    .locals 1
    .param p0, "str"    # Ljava/lang/String;
    .param p1, "defaultValue"    # F

    .prologue
    .line 222
    if-nez p0, :cond_0

    .line 228
    .end local p1    # "defaultValue":F
    :goto_0
    return p1

    .line 226
    .restart local p1    # "defaultValue":F
    :cond_0
    :try_start_0
    invoke-static {p0}, Ljava/lang/Float;->parseFloat(Ljava/lang/String;)F
    :try_end_0
    .catch Ljava/lang/NumberFormatException; {:try_start_0 .. :try_end_0} :catch_0

    move-result p1

    goto :goto_0

    .line 227
    :catch_0
    move-exception v0

    .line 228
    .local v0, "nfe":Ljava/lang/NumberFormatException;
    goto :goto_0
.end method

.method public static toInt(Ljava/lang/String;)I
    .locals 1
    .param p0, "str"    # Ljava/lang/String;

    .prologue
    .line 100
    const/4 v0, 0x0

    invoke-static {p0, v0}, Lorg/apache/commons/lang3/math/NumberUtils;->toInt(Ljava/lang/String;I)I

    move-result v0

    return v0
.end method

.method public static toInt(Ljava/lang/String;I)I
    .locals 1
    .param p0, "str"    # Ljava/lang/String;
    .param p1, "defaultValue"    # I

    .prologue
    .line 121
    if-nez p0, :cond_0

    .line 127
    .end local p1    # "defaultValue":I
    :goto_0
    return p1

    .line 125
    .restart local p1    # "defaultValue":I
    :cond_0
    :try_start_0
    invoke-static {p0}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I
    :try_end_0
    .catch Ljava/lang/NumberFormatException; {:try_start_0 .. :try_end_0} :catch_0

    move-result p1

    goto :goto_0

    .line 126
    :catch_0
    move-exception v0

    .line 127
    .local v0, "nfe":Ljava/lang/NumberFormatException;
    goto :goto_0
.end method

.method public static toLong(Ljava/lang/String;)J
    .locals 2
    .param p0, "str"    # Ljava/lang/String;

    .prologue
    .line 149
    const-wide/16 v0, 0x0

    invoke-static {p0, v0, v1}, Lorg/apache/commons/lang3/math/NumberUtils;->toLong(Ljava/lang/String;J)J

    move-result-wide v0

    return-wide v0
.end method

.method public static toLong(Ljava/lang/String;J)J
    .locals 1
    .param p0, "str"    # Ljava/lang/String;
    .param p1, "defaultValue"    # J

    .prologue
    .line 170
    if-nez p0, :cond_0

    .line 176
    .end local p1    # "defaultValue":J
    :goto_0
    return-wide p1

    .line 174
    .restart local p1    # "defaultValue":J
    :cond_0
    :try_start_0
    invoke-static {p0}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J
    :try_end_0
    .catch Ljava/lang/NumberFormatException; {:try_start_0 .. :try_end_0} :catch_0

    move-result-wide p1

    goto :goto_0

    .line 175
    :catch_0
    move-exception v0

    .line 176
    .local v0, "nfe":Ljava/lang/NumberFormatException;
    goto :goto_0
.end method

.method public static toShort(Ljava/lang/String;)S
    .locals 1
    .param p0, "str"    # Ljava/lang/String;

    .prologue
    .line 352
    const/4 v0, 0x0

    invoke-static {p0, v0}, Lorg/apache/commons/lang3/math/NumberUtils;->toShort(Ljava/lang/String;S)S

    move-result v0

    return v0
.end method

.method public static toShort(Ljava/lang/String;S)S
    .locals 1
    .param p0, "str"    # Ljava/lang/String;
    .param p1, "defaultValue"    # S

    .prologue
    .line 373
    if-nez p0, :cond_0

    .line 379
    .end local p1    # "defaultValue":S
    :goto_0
    return p1

    .line 377
    .restart local p1    # "defaultValue":S
    :cond_0
    :try_start_0
    invoke-static {p0}, Ljava/lang/Short;->parseShort(Ljava/lang/String;)S
    :try_end_0
    .catch Ljava/lang/NumberFormatException; {:try_start_0 .. :try_end_0} :catch_0

    move-result p1

    goto :goto_0

    .line 378
    :catch_0
    move-exception v0

    .line 379
    .local v0, "nfe":Ljava/lang/NumberFormatException;
    goto :goto_0
.end method

.method private static validateArray(Ljava/lang/Object;)V
    .locals 2
    .param p0, "array"    # Ljava/lang/Object;

    .prologue
    .line 1081
    if-nez p0, :cond_0

    .line 1082
    new-instance v0, Ljava/lang/IllegalArgumentException;

    const-string v1, "The Array must not be null"

    invoke-direct {v0, v1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 1083
    :cond_0
    invoke-static {p0}, Ljava/lang/reflect/Array;->getLength(Ljava/lang/Object;)I

    move-result v0

    if-nez v0, :cond_1

    .line 1084
    new-instance v0, Ljava/lang/IllegalArgumentException;

    const-string v1, "Array cannot be empty."

    invoke-direct {v0, v1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 1086
    :cond_1
    return-void
.end method
