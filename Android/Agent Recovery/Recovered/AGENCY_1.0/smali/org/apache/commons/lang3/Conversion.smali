.class public Lorg/apache/commons/lang3/Conversion;
.super Ljava/lang/Object;
.source "Conversion.java"


# static fields
.field static final synthetic $assertionsDisabled:Z


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 67
    const-class v0, Lorg/apache/commons/lang3/Conversion;

    invoke-virtual {v0}, Ljava/lang/Class;->desiredAssertionStatus()Z

    move-result v0

    if-nez v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    sput-boolean v0, Lorg/apache/commons/lang3/Conversion;->$assertionsDisabled:Z

    return-void

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public constructor <init>()V
    .locals 0

    .prologue
    .line 67
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static binaryBeMsb0ToHexDigit([Z)C
    .locals 1
    .param p0, "src"    # [Z

    .prologue
    .line 494
    const/4 v0, 0x0

    invoke-static {p0, v0}, Lorg/apache/commons/lang3/Conversion;->binaryBeMsb0ToHexDigit([ZI)C

    move-result v0

    return v0
.end method

.method public static binaryBeMsb0ToHexDigit([ZI)C
    .locals 8
    .param p0, "src"    # [Z
    .param p1, "srcPos"    # I

    .prologue
    const/4 v4, 0x4

    const/4 v7, 0x1

    const/4 v6, 0x2

    const/4 v5, 0x3

    .line 514
    array-length v3, p0

    if-nez v3, :cond_0

    .line 515
    new-instance v3, Ljava/lang/IllegalArgumentException;

    const-string v4, "Cannot convert an empty array."

    invoke-direct {v3, v4}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v3

    .line 517
    :cond_0
    array-length v3, p0

    add-int/lit8 v3, v3, -0x1

    sub-int v0, v3, p1

    .line 518
    .local v0, "beSrcPos":I
    add-int/lit8 v3, v0, 0x1

    invoke-static {v4, v3}, Ljava/lang/Math;->min(II)I

    move-result v2

    .line 519
    .local v2, "srcLen":I
    new-array v1, v4, [Z

    .line 520
    .local v1, "paddedSrc":[Z
    add-int/lit8 v3, v0, 0x1

    sub-int/2addr v3, v2

    rsub-int/lit8 v4, v2, 0x4

    invoke-static {p0, v3, v1, v4, v2}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    .line 521
    move-object p0, v1

    .line 522
    const/4 p1, 0x0

    .line 523
    aget-boolean v3, p0, p1

    if-eqz v3, :cond_8

    .line 524
    array-length v3, p0

    if-le v3, v7, :cond_4

    aget-boolean v3, p0, v7

    if-eqz v3, :cond_4

    .line 525
    array-length v3, p0

    if-le v3, v6, :cond_2

    aget-boolean v3, p0, v6

    if-eqz v3, :cond_2

    .line 526
    array-length v3, p0

    if-le v3, v5, :cond_1

    aget-boolean v3, p0, v5

    if-eqz v3, :cond_1

    .line 527
    const/16 v3, 0x66

    .line 579
    :goto_0
    return v3

    .line 529
    :cond_1
    const/16 v3, 0x65

    goto :goto_0

    .line 532
    :cond_2
    array-length v3, p0

    if-le v3, v5, :cond_3

    aget-boolean v3, p0, v5

    if-eqz v3, :cond_3

    .line 533
    const/16 v3, 0x64

    goto :goto_0

    .line 535
    :cond_3
    const/16 v3, 0x63

    goto :goto_0

    .line 539
    :cond_4
    array-length v3, p0

    if-le v3, v6, :cond_6

    aget-boolean v3, p0, v6

    if-eqz v3, :cond_6

    .line 540
    array-length v3, p0

    if-le v3, v5, :cond_5

    aget-boolean v3, p0, v5

    if-eqz v3, :cond_5

    .line 541
    const/16 v3, 0x62

    goto :goto_0

    .line 543
    :cond_5
    const/16 v3, 0x61

    goto :goto_0

    .line 546
    :cond_6
    array-length v3, p0

    if-le v3, v5, :cond_7

    aget-boolean v3, p0, v5

    if-eqz v3, :cond_7

    .line 547
    const/16 v3, 0x39

    goto :goto_0

    .line 549
    :cond_7
    const/16 v3, 0x38

    goto :goto_0

    .line 554
    :cond_8
    array-length v3, p0

    if-le v3, v7, :cond_c

    aget-boolean v3, p0, v7

    if-eqz v3, :cond_c

    .line 555
    array-length v3, p0

    if-le v3, v6, :cond_a

    aget-boolean v3, p0, v6

    if-eqz v3, :cond_a

    .line 556
    array-length v3, p0

    if-le v3, v5, :cond_9

    aget-boolean v3, p0, v5

    if-eqz v3, :cond_9

    .line 557
    const/16 v3, 0x37

    goto :goto_0

    .line 559
    :cond_9
    const/16 v3, 0x36

    goto :goto_0

    .line 562
    :cond_a
    array-length v3, p0

    if-le v3, v5, :cond_b

    aget-boolean v3, p0, v5

    if-eqz v3, :cond_b

    .line 563
    const/16 v3, 0x35

    goto :goto_0

    .line 565
    :cond_b
    const/16 v3, 0x34

    goto :goto_0

    .line 569
    :cond_c
    array-length v3, p0

    if-le v3, v6, :cond_e

    aget-boolean v3, p0, v6

    if-eqz v3, :cond_e

    .line 570
    array-length v3, p0

    if-le v3, v5, :cond_d

    aget-boolean v3, p0, v5

    if-eqz v3, :cond_d

    .line 571
    const/16 v3, 0x33

    goto :goto_0

    .line 573
    :cond_d
    const/16 v3, 0x32

    goto :goto_0

    .line 576
    :cond_e
    array-length v3, p0

    if-le v3, v5, :cond_f

    aget-boolean v3, p0, v5

    if-eqz v3, :cond_f

    .line 577
    const/16 v3, 0x31

    goto :goto_0

    .line 579
    :cond_f
    const/16 v3, 0x30

    goto :goto_0
.end method

.method public static binaryToByte([ZIBII)B
    .locals 8
    .param p0, "src"    # [Z
    .param p1, "srcPos"    # I
    .param p2, "dstInit"    # B
    .param p3, "dstPos"    # I
    .param p4, "nBools"    # I

    .prologue
    const/4 v6, 0x1

    .line 1154
    array-length v5, p0

    if-nez v5, :cond_0

    if-eqz p1, :cond_1

    :cond_0
    if-nez p4, :cond_2

    .line 1168
    .end local p2    # "dstInit":B
    :cond_1
    :goto_0
    return p2

    .line 1157
    .restart local p2    # "dstInit":B
    :cond_2
    add-int/lit8 v5, p4, -0x1

    add-int/2addr v5, p3

    const/16 v7, 0x8

    if-lt v5, v7, :cond_3

    .line 1158
    new-instance v5, Ljava/lang/IllegalArgumentException;

    const-string v6, "nBools-1+dstPos is greather or equal to than 8"

    invoke-direct {v5, v6}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v5

    .line 1160
    :cond_3
    move v3, p2

    .line 1161
    .local v3, "out":B
    const/4 v4, 0x0

    .line 1162
    .local v4, "shift":I
    const/4 v1, 0x0

    .local v1, "i":I
    :goto_1
    if-ge v1, p4, :cond_5

    .line 1163
    mul-int/lit8 v5, v1, 0x1

    add-int v4, v5, p3

    .line 1164
    add-int v5, v1, p1

    aget-boolean v5, p0, v5

    if-eqz v5, :cond_4

    move v5, v6

    :goto_2
    shl-int v0, v5, v4

    .line 1165
    .local v0, "bits":I
    shl-int v2, v6, v4

    .line 1166
    .local v2, "mask":I
    xor-int/lit8 v5, v2, -0x1

    and-int/2addr v5, v3

    or-int/2addr v5, v0

    int-to-byte v3, v5

    .line 1162
    add-int/lit8 v1, v1, 0x1

    goto :goto_1

    .line 1164
    .end local v0    # "bits":I
    .end local v2    # "mask":I
    :cond_4
    const/4 v5, 0x0

    goto :goto_2

    :cond_5
    move p2, v3

    .line 1168
    goto :goto_0
.end method

.method public static binaryToHexDigit([Z)C
    .locals 1
    .param p0, "src"    # [Z

    .prologue
    .line 284
    const/4 v0, 0x0

    invoke-static {p0, v0}, Lorg/apache/commons/lang3/Conversion;->binaryToHexDigit([ZI)C

    move-result v0

    return v0
.end method

.method public static binaryToHexDigit([ZI)C
    .locals 2
    .param p0, "src"    # [Z
    .param p1, "srcPos"    # I

    .prologue
    .line 303
    array-length v0, p0

    if-nez v0, :cond_0

    .line 304
    new-instance v0, Ljava/lang/IllegalArgumentException;

    const-string v1, "Cannot convert an empty array."

    invoke-direct {v0, v1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 306
    :cond_0
    array-length v0, p0

    add-int/lit8 v1, p1, 0x3

    if-le v0, v1, :cond_8

    add-int/lit8 v0, p1, 0x3

    aget-boolean v0, p0, v0

    if-eqz v0, :cond_8

    .line 307
    array-length v0, p0

    add-int/lit8 v1, p1, 0x2

    if-le v0, v1, :cond_4

    add-int/lit8 v0, p1, 0x2

    aget-boolean v0, p0, v0

    if-eqz v0, :cond_4

    .line 308
    array-length v0, p0

    add-int/lit8 v1, p1, 0x1

    if-le v0, v1, :cond_2

    add-int/lit8 v0, p1, 0x1

    aget-boolean v0, p0, v0

    if-eqz v0, :cond_2

    .line 309
    aget-boolean v0, p0, p1

    if-eqz v0, :cond_1

    .line 310
    const/16 v0, 0x66

    .line 362
    :goto_0
    return v0

    .line 312
    :cond_1
    const/16 v0, 0x65

    goto :goto_0

    .line 315
    :cond_2
    aget-boolean v0, p0, p1

    if-eqz v0, :cond_3

    .line 316
    const/16 v0, 0x64

    goto :goto_0

    .line 318
    :cond_3
    const/16 v0, 0x63

    goto :goto_0

    .line 322
    :cond_4
    array-length v0, p0

    add-int/lit8 v1, p1, 0x1

    if-le v0, v1, :cond_6

    add-int/lit8 v0, p1, 0x1

    aget-boolean v0, p0, v0

    if-eqz v0, :cond_6

    .line 323
    aget-boolean v0, p0, p1

    if-eqz v0, :cond_5

    .line 324
    const/16 v0, 0x62

    goto :goto_0

    .line 326
    :cond_5
    const/16 v0, 0x61

    goto :goto_0

    .line 329
    :cond_6
    aget-boolean v0, p0, p1

    if-eqz v0, :cond_7

    .line 330
    const/16 v0, 0x39

    goto :goto_0

    .line 332
    :cond_7
    const/16 v0, 0x38

    goto :goto_0

    .line 337
    :cond_8
    array-length v0, p0

    add-int/lit8 v1, p1, 0x2

    if-le v0, v1, :cond_c

    add-int/lit8 v0, p1, 0x2

    aget-boolean v0, p0, v0

    if-eqz v0, :cond_c

    .line 338
    array-length v0, p0

    add-int/lit8 v1, p1, 0x1

    if-le v0, v1, :cond_a

    add-int/lit8 v0, p1, 0x1

    aget-boolean v0, p0, v0

    if-eqz v0, :cond_a

    .line 339
    aget-boolean v0, p0, p1

    if-eqz v0, :cond_9

    .line 340
    const/16 v0, 0x37

    goto :goto_0

    .line 342
    :cond_9
    const/16 v0, 0x36

    goto :goto_0

    .line 345
    :cond_a
    aget-boolean v0, p0, p1

    if-eqz v0, :cond_b

    .line 346
    const/16 v0, 0x35

    goto :goto_0

    .line 348
    :cond_b
    const/16 v0, 0x34

    goto :goto_0

    .line 352
    :cond_c
    array-length v0, p0

    add-int/lit8 v1, p1, 0x1

    if-le v0, v1, :cond_e

    add-int/lit8 v0, p1, 0x1

    aget-boolean v0, p0, v0

    if-eqz v0, :cond_e

    .line 353
    aget-boolean v0, p0, p1

    if-eqz v0, :cond_d

    .line 354
    const/16 v0, 0x33

    goto :goto_0

    .line 356
    :cond_d
    const/16 v0, 0x32

    goto :goto_0

    .line 359
    :cond_e
    aget-boolean v0, p0, p1

    if-eqz v0, :cond_f

    .line 360
    const/16 v0, 0x31

    goto :goto_0

    .line 362
    :cond_f
    const/16 v0, 0x30

    goto :goto_0
.end method

.method public static binaryToHexDigitMsb0_4bits([Z)C
    .locals 1
    .param p0, "src"    # [Z

    .prologue
    .line 385
    const/4 v0, 0x0

    invoke-static {p0, v0}, Lorg/apache/commons/lang3/Conversion;->binaryToHexDigitMsb0_4bits([ZI)C

    move-result v0

    return v0
.end method

.method public static binaryToHexDigitMsb0_4bits([ZI)C
    .locals 3
    .param p0, "src"    # [Z
    .param p1, "srcPos"    # I

    .prologue
    .line 406
    array-length v0, p0

    const/16 v1, 0x8

    if-le v0, v1, :cond_0

    .line 407
    new-instance v0, Ljava/lang/IllegalArgumentException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "src.length>8: src.length="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    array-length v2, p0

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 409
    :cond_0
    array-length v0, p0

    sub-int/2addr v0, p1

    const/4 v1, 0x4

    if-ge v0, v1, :cond_1

    .line 410
    new-instance v0, Ljava/lang/IllegalArgumentException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "src.length-srcPos<4: src.length="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    array-length v2, p0

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, ", srcPos="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 415
    :cond_1
    add-int/lit8 v0, p1, 0x3

    aget-boolean v0, p0, v0

    if-eqz v0, :cond_9

    .line 416
    add-int/lit8 v0, p1, 0x2

    aget-boolean v0, p0, v0

    if-eqz v0, :cond_5

    .line 417
    add-int/lit8 v0, p1, 0x1

    aget-boolean v0, p0, v0

    if-eqz v0, :cond_3

    .line 418
    aget-boolean v0, p0, p1

    if-eqz v0, :cond_2

    .line 419
    const/16 v0, 0x66

    .line 471
    :goto_0
    return v0

    .line 421
    :cond_2
    const/16 v0, 0x37

    goto :goto_0

    .line 424
    :cond_3
    aget-boolean v0, p0, p1

    if-eqz v0, :cond_4

    .line 425
    const/16 v0, 0x62

    goto :goto_0

    .line 427
    :cond_4
    const/16 v0, 0x33

    goto :goto_0

    .line 431
    :cond_5
    add-int/lit8 v0, p1, 0x1

    aget-boolean v0, p0, v0

    if-eqz v0, :cond_7

    .line 432
    aget-boolean v0, p0, p1

    if-eqz v0, :cond_6

    .line 433
    const/16 v0, 0x64

    goto :goto_0

    .line 435
    :cond_6
    const/16 v0, 0x35

    goto :goto_0

    .line 438
    :cond_7
    aget-boolean v0, p0, p1

    if-eqz v0, :cond_8

    .line 439
    const/16 v0, 0x39

    goto :goto_0

    .line 441
    :cond_8
    const/16 v0, 0x31

    goto :goto_0

    .line 446
    :cond_9
    add-int/lit8 v0, p1, 0x2

    aget-boolean v0, p0, v0

    if-eqz v0, :cond_d

    .line 447
    add-int/lit8 v0, p1, 0x1

    aget-boolean v0, p0, v0

    if-eqz v0, :cond_b

    .line 448
    aget-boolean v0, p0, p1

    if-eqz v0, :cond_a

    .line 449
    const/16 v0, 0x65

    goto :goto_0

    .line 451
    :cond_a
    const/16 v0, 0x36

    goto :goto_0

    .line 454
    :cond_b
    aget-boolean v0, p0, p1

    if-eqz v0, :cond_c

    .line 455
    const/16 v0, 0x61

    goto :goto_0

    .line 457
    :cond_c
    const/16 v0, 0x32

    goto :goto_0

    .line 461
    :cond_d
    add-int/lit8 v0, p1, 0x1

    aget-boolean v0, p0, v0

    if-eqz v0, :cond_f

    .line 462
    aget-boolean v0, p0, p1

    if-eqz v0, :cond_e

    .line 463
    const/16 v0, 0x63

    goto :goto_0

    .line 465
    :cond_e
    const/16 v0, 0x34

    goto :goto_0

    .line 468
    :cond_f
    aget-boolean v0, p0, p1

    if-eqz v0, :cond_10

    .line 469
    const/16 v0, 0x38

    goto :goto_0

    .line 471
    :cond_10
    const/16 v0, 0x30

    goto :goto_0
.end method

.method public static binaryToInt([ZIIII)I
    .locals 8
    .param p0, "src"    # [Z
    .param p1, "srcPos"    # I
    .param p2, "dstInit"    # I
    .param p3, "dstPos"    # I
    .param p4, "nBools"    # I

    .prologue
    const/4 v6, 0x1

    .line 1080
    array-length v5, p0

    if-nez v5, :cond_0

    if-eqz p1, :cond_1

    :cond_0
    if-nez p4, :cond_2

    .line 1095
    .end local p2    # "dstInit":I
    :cond_1
    :goto_0
    return p2

    .line 1083
    .restart local p2    # "dstInit":I
    :cond_2
    add-int/lit8 v5, p4, -0x1

    add-int/2addr v5, p3

    const/16 v7, 0x20

    if-lt v5, v7, :cond_3

    .line 1084
    new-instance v5, Ljava/lang/IllegalArgumentException;

    const-string v6, "nBools-1+dstPos is greather or equal to than 32"

    invoke-direct {v5, v6}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v5

    .line 1087
    :cond_3
    move v3, p2

    .line 1088
    .local v3, "out":I
    const/4 v4, 0x0

    .line 1089
    .local v4, "shift":I
    const/4 v1, 0x0

    .local v1, "i":I
    :goto_1
    if-ge v1, p4, :cond_5

    .line 1090
    mul-int/lit8 v5, v1, 0x1

    add-int v4, v5, p3

    .line 1091
    add-int v5, v1, p1

    aget-boolean v5, p0, v5

    if-eqz v5, :cond_4

    move v5, v6

    :goto_2
    shl-int v0, v5, v4

    .line 1092
    .local v0, "bits":I
    shl-int v2, v6, v4

    .line 1093
    .local v2, "mask":I
    xor-int/lit8 v5, v2, -0x1

    and-int/2addr v5, v3

    or-int v3, v5, v0

    .line 1089
    add-int/lit8 v1, v1, 0x1

    goto :goto_1

    .line 1091
    .end local v0    # "bits":I
    .end local v2    # "mask":I
    :cond_4
    const/4 v5, 0x0

    goto :goto_2

    :cond_5
    move p2, v3

    .line 1095
    goto :goto_0
.end method

.method public static binaryToLong([ZIJII)J
    .locals 10
    .param p0, "src"    # [Z
    .param p1, "srcPos"    # I
    .param p2, "dstInit"    # J
    .param p4, "dstPos"    # I
    .param p5, "nBools"    # I

    .prologue
    .line 1044
    array-length v8, p0

    if-nez v8, :cond_0

    if-eqz p1, :cond_1

    :cond_0
    if-nez p5, :cond_2

    .line 1059
    .end local p2    # "dstInit":J
    :cond_1
    :goto_0
    return-wide p2

    .line 1047
    .restart local p2    # "dstInit":J
    :cond_2
    add-int/lit8 v8, p5, -0x1

    add-int/2addr v8, p4

    const/16 v9, 0x40

    if-lt v8, v9, :cond_3

    .line 1048
    new-instance v8, Ljava/lang/IllegalArgumentException;

    const-string v9, "nBools-1+dstPos is greather or equal to than 64"

    invoke-direct {v8, v9}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v8

    .line 1051
    :cond_3
    move-wide v5, p2

    .line 1052
    .local v5, "out":J
    const/4 v7, 0x0

    .line 1053
    .local v7, "shift":I
    const/4 v2, 0x0

    .local v2, "i":I
    :goto_1
    if-ge v2, p5, :cond_5

    .line 1054
    mul-int/lit8 v8, v2, 0x1

    add-int v7, v8, p4

    .line 1055
    add-int v8, v2, p1

    aget-boolean v8, p0, v8

    if-eqz v8, :cond_4

    const-wide/16 v8, 0x1

    :goto_2
    shl-long v0, v8, v7

    .line 1056
    .local v0, "bits":J
    const-wide/16 v8, 0x1

    shl-long v3, v8, v7

    .line 1057
    .local v3, "mask":J
    const-wide/16 v8, -0x1

    xor-long/2addr v8, v3

    and-long/2addr v8, v5

    or-long v5, v8, v0

    .line 1053
    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    .line 1055
    .end local v0    # "bits":J
    .end local v3    # "mask":J
    :cond_4
    const-wide/16 v8, 0x0

    goto :goto_2

    :cond_5
    move-wide p2, v5

    .line 1059
    goto :goto_0
.end method

.method public static binaryToShort([ZISII)S
    .locals 8
    .param p0, "src"    # [Z
    .param p1, "srcPos"    # I
    .param p2, "dstInit"    # S
    .param p3, "dstPos"    # I
    .param p4, "nBools"    # I

    .prologue
    const/4 v6, 0x1

    .line 1117
    array-length v5, p0

    if-nez v5, :cond_0

    if-eqz p1, :cond_1

    :cond_0
    if-nez p4, :cond_2

    .line 1132
    .end local p2    # "dstInit":S
    :cond_1
    :goto_0
    return p2

    .line 1120
    .restart local p2    # "dstInit":S
    :cond_2
    add-int/lit8 v5, p4, -0x1

    add-int/2addr v5, p3

    const/16 v7, 0x10

    if-lt v5, v7, :cond_3

    .line 1121
    new-instance v5, Ljava/lang/IllegalArgumentException;

    const-string v6, "nBools-1+dstPos is greather or equal to than 16"

    invoke-direct {v5, v6}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v5

    .line 1124
    :cond_3
    move v3, p2

    .line 1125
    .local v3, "out":S
    const/4 v4, 0x0

    .line 1126
    .local v4, "shift":I
    const/4 v1, 0x0

    .local v1, "i":I
    :goto_1
    if-ge v1, p4, :cond_5

    .line 1127
    mul-int/lit8 v5, v1, 0x1

    add-int v4, v5, p3

    .line 1128
    add-int v5, v1, p1

    aget-boolean v5, p0, v5

    if-eqz v5, :cond_4

    move v5, v6

    :goto_2
    shl-int v0, v5, v4

    .line 1129
    .local v0, "bits":I
    shl-int v2, v6, v4

    .line 1130
    .local v2, "mask":I
    xor-int/lit8 v5, v2, -0x1

    and-int/2addr v5, v3

    or-int/2addr v5, v0

    int-to-short v3, v5

    .line 1126
    add-int/lit8 v1, v1, 0x1

    goto :goto_1

    .line 1128
    .end local v0    # "bits":I
    .end local v2    # "mask":I
    :cond_4
    const/4 v5, 0x0

    goto :goto_2

    :cond_5
    move p2, v3

    .line 1132
    goto :goto_0
.end method

.method public static byteArrayToInt([BIIII)I
    .locals 7
    .param p0, "src"    # [B
    .param p1, "srcPos"    # I
    .param p2, "dstInit"    # I
    .param p3, "dstPos"    # I
    .param p4, "nBytes"    # I

    .prologue
    .line 834
    array-length v5, p0

    if-nez v5, :cond_0

    if-eqz p1, :cond_1

    :cond_0
    if-nez p4, :cond_2

    .line 849
    .end local p2    # "dstInit":I
    :cond_1
    :goto_0
    return p2

    .line 837
    .restart local p2    # "dstInit":I
    :cond_2
    add-int/lit8 v5, p4, -0x1

    mul-int/lit8 v5, v5, 0x8

    add-int/2addr v5, p3

    const/16 v6, 0x20

    if-lt v5, v6, :cond_3

    .line 838
    new-instance v5, Ljava/lang/IllegalArgumentException;

    const-string v6, "(nBytes-1)*8+dstPos is greather or equal to than 32"

    invoke-direct {v5, v6}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v5

    .line 841
    :cond_3
    move v3, p2

    .line 842
    .local v3, "out":I
    const/4 v4, 0x0

    .line 843
    .local v4, "shift":I
    const/4 v1, 0x0

    .local v1, "i":I
    :goto_1
    if-ge v1, p4, :cond_4

    .line 844
    mul-int/lit8 v5, v1, 0x8

    add-int v4, v5, p3

    .line 845
    add-int v5, v1, p1

    aget-byte v5, p0, v5

    and-int/lit16 v5, v5, 0xff

    shl-int v0, v5, v4

    .line 846
    .local v0, "bits":I
    const/16 v5, 0xff

    shl-int v2, v5, v4

    .line 847
    .local v2, "mask":I
    xor-int/lit8 v5, v2, -0x1

    and-int/2addr v5, v3

    or-int v3, v5, v0

    .line 843
    add-int/lit8 v1, v1, 0x1

    goto :goto_1

    .end local v0    # "bits":I
    .end local v2    # "mask":I
    :cond_4
    move p2, v3

    .line 849
    goto :goto_0
.end method

.method public static byteArrayToLong([BIJII)J
    .locals 13
    .param p0, "src"    # [B
    .param p1, "srcPos"    # I
    .param p2, "dstInit"    # J
    .param p4, "dstPos"    # I
    .param p5, "nBytes"    # I

    .prologue
    .line 798
    array-length v9, p0

    if-nez v9, :cond_0

    if-eqz p1, :cond_1

    :cond_0
    if-nez p5, :cond_2

    .line 813
    .end local p2    # "dstInit":J
    :cond_1
    :goto_0
    return-wide p2

    .line 801
    .restart local p2    # "dstInit":J
    :cond_2
    add-int/lit8 v9, p5, -0x1

    mul-int/lit8 v9, v9, 0x8

    add-int v9, v9, p4

    const/16 v10, 0x40

    if-lt v9, v10, :cond_3

    .line 802
    new-instance v9, Ljava/lang/IllegalArgumentException;

    const-string v10, "(nBytes-1)*8+dstPos is greather or equal to than 64"

    invoke-direct {v9, v10}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v9

    .line 805
    :cond_3
    move-wide v6, p2

    .line 806
    .local v6, "out":J
    const/4 v8, 0x0

    .line 807
    .local v8, "shift":I
    const/4 v3, 0x0

    .local v3, "i":I
    :goto_1
    move/from16 v0, p5

    if-ge v3, v0, :cond_4

    .line 808
    mul-int/lit8 v9, v3, 0x8

    add-int v8, v9, p4

    .line 809
    const-wide/16 v9, 0xff

    add-int v11, v3, p1

    aget-byte v11, p0, v11

    int-to-long v11, v11

    and-long/2addr v9, v11

    shl-long v1, v9, v8

    .line 810
    .local v1, "bits":J
    const-wide/16 v9, 0xff

    shl-long v4, v9, v8

    .line 811
    .local v4, "mask":J
    const-wide/16 v9, -0x1

    xor-long/2addr v9, v4

    and-long/2addr v9, v6

    or-long v6, v9, v1

    .line 807
    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    .end local v1    # "bits":J
    .end local v4    # "mask":J
    :cond_4
    move-wide p2, v6

    .line 813
    goto :goto_0
.end method

.method public static byteArrayToShort([BISII)S
    .locals 7
    .param p0, "src"    # [B
    .param p1, "srcPos"    # I
    .param p2, "dstInit"    # S
    .param p3, "dstPos"    # I
    .param p4, "nBytes"    # I

    .prologue
    .line 871
    array-length v5, p0

    if-nez v5, :cond_0

    if-eqz p1, :cond_1

    :cond_0
    if-nez p4, :cond_2

    .line 886
    .end local p2    # "dstInit":S
    :cond_1
    :goto_0
    return p2

    .line 874
    .restart local p2    # "dstInit":S
    :cond_2
    add-int/lit8 v5, p4, -0x1

    mul-int/lit8 v5, v5, 0x8

    add-int/2addr v5, p3

    const/16 v6, 0x10

    if-lt v5, v6, :cond_3

    .line 875
    new-instance v5, Ljava/lang/IllegalArgumentException;

    const-string v6, "(nBytes-1)*8+dstPos is greather or equal to than 16"

    invoke-direct {v5, v6}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v5

    .line 878
    :cond_3
    move v3, p2

    .line 879
    .local v3, "out":S
    const/4 v4, 0x0

    .line 880
    .local v4, "shift":I
    const/4 v1, 0x0

    .local v1, "i":I
    :goto_1
    if-ge v1, p4, :cond_4

    .line 881
    mul-int/lit8 v5, v1, 0x8

    add-int v4, v5, p3

    .line 882
    add-int v5, v1, p1

    aget-byte v5, p0, v5

    and-int/lit16 v5, v5, 0xff

    shl-int v0, v5, v4

    .line 883
    .local v0, "bits":I
    const/16 v5, 0xff

    shl-int v2, v5, v4

    .line 884
    .local v2, "mask":I
    xor-int/lit8 v5, v2, -0x1

    and-int/2addr v5, v3

    or-int/2addr v5, v0

    int-to-short v3, v5

    .line 880
    add-int/lit8 v1, v1, 0x1

    goto :goto_1

    .end local v0    # "bits":I
    .end local v2    # "mask":I
    :cond_4
    move p2, v3

    .line 886
    goto :goto_0
.end method

.method public static byteArrayToUuid([BI)Ljava/util/UUID;
    .locals 9
    .param p0, "src"    # [B
    .param p1, "srcPos"    # I

    .prologue
    const-wide/16 v2, 0x0

    const/16 v5, 0x8

    const/4 v4, 0x0

    .line 1713
    array-length v0, p0

    sub-int/2addr v0, p1

    const/16 v1, 0x10

    if-ge v0, v1, :cond_0

    .line 1714
    new-instance v0, Ljava/lang/IllegalArgumentException;

    const-string v1, "Need at least 16 bytes for UUID"

    invoke-direct {v0, v1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 1716
    :cond_0
    new-instance v6, Ljava/util/UUID;

    move-object v0, p0

    move v1, p1

    invoke-static/range {v0 .. v5}, Lorg/apache/commons/lang3/Conversion;->byteArrayToLong([BIJII)J

    move-result-wide v7

    add-int/lit8 v1, p1, 0x8

    move-object v0, p0

    invoke-static/range {v0 .. v5}, Lorg/apache/commons/lang3/Conversion;->byteArrayToLong([BIJII)J

    move-result-wide v0

    invoke-direct {v6, v7, v8, v0, v1}, Ljava/util/UUID;-><init>(JJ)V

    return-object v6
.end method

.method public static byteToBinary(BI[ZII)[Z
    .locals 4
    .param p0, "src"    # B
    .param p1, "srcPos"    # I
    .param p2, "dst"    # [Z
    .param p3, "dstPos"    # I
    .param p4, "nBools"    # I

    .prologue
    .line 1655
    if-nez p4, :cond_1

    .line 1666
    :cond_0
    return-object p2

    .line 1658
    :cond_1
    add-int/lit8 v2, p4, -0x1

    add-int/2addr v2, p1

    const/16 v3, 0x8

    if-lt v2, v3, :cond_2

    .line 1659
    new-instance v2, Ljava/lang/IllegalArgumentException;

    const-string v3, "nBools-1+srcPos is greather or equal to than 8"

    invoke-direct {v2, v3}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v2

    .line 1661
    :cond_2
    const/4 v1, 0x0

    .line 1662
    .local v1, "shift":I
    const/4 v0, 0x0

    .local v0, "i":I
    :goto_0
    if-ge v0, p4, :cond_0

    .line 1663
    mul-int/lit8 v2, v0, 0x1

    add-int v1, v2, p1

    .line 1664
    add-int v3, p3, v0

    shr-int v2, p0, v1

    and-int/lit8 v2, v2, 0x1

    if-eqz v2, :cond_3

    const/4 v2, 0x1

    :goto_1
    aput-boolean v2, p2, v3

    .line 1662
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 1664
    :cond_3
    const/4 v2, 0x0

    goto :goto_1
.end method

.method public static byteToHex(BILjava/lang/String;II)Ljava/lang/String;
    .locals 7
    .param p0, "src"    # B
    .param p1, "srcPos"    # I
    .param p2, "dstInit"    # Ljava/lang/String;
    .param p3, "dstPos"    # I
    .param p4, "nHexs"    # I

    .prologue
    .line 1510
    if-nez p4, :cond_0

    .line 1530
    .end local p2    # "dstInit":Ljava/lang/String;
    :goto_0
    return-object p2

    .line 1513
    .restart local p2    # "dstInit":Ljava/lang/String;
    :cond_0
    add-int/lit8 v5, p4, -0x1

    mul-int/lit8 v5, v5, 0x4

    add-int/2addr v5, p1

    const/16 v6, 0x8

    if-lt v5, v6, :cond_1

    .line 1514
    new-instance v5, Ljava/lang/IllegalArgumentException;

    const-string v6, "(nHexs-1)*4+srcPos is greather or equal to than 8"

    invoke-direct {v5, v6}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v5

    .line 1517
    :cond_1
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3, p2}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    .line 1518
    .local v3, "sb":Ljava/lang/StringBuilder;
    const/4 v4, 0x0

    .line 1519
    .local v4, "shift":I
    invoke-virtual {v3}, Ljava/lang/StringBuilder;->length()I

    move-result v0

    .line 1520
    .local v0, "append":I
    const/4 v2, 0x0

    .local v2, "i":I
    :goto_1
    if-ge v2, p4, :cond_3

    .line 1521
    mul-int/lit8 v5, v2, 0x4

    add-int v4, v5, p1

    .line 1522
    shr-int v5, p0, v4

    and-int/lit8 v1, v5, 0xf

    .line 1523
    .local v1, "bits":I
    add-int v5, p3, v2

    if-ne v5, v0, :cond_2

    .line 1524
    add-int/lit8 v0, v0, 0x1

    .line 1525
    invoke-static {v1}, Lorg/apache/commons/lang3/Conversion;->intToHexDigit(I)C

    move-result v5

    invoke-virtual {v3, v5}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    .line 1520
    :goto_2
    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    .line 1527
    :cond_2
    add-int v5, p3, v2

    invoke-static {v1}, Lorg/apache/commons/lang3/Conversion;->intToHexDigit(I)C

    move-result v6

    invoke-virtual {v3, v5, v6}, Ljava/lang/StringBuilder;->setCharAt(IC)V

    goto :goto_2

    .line 1530
    .end local v1    # "bits":I
    :cond_3
    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    goto :goto_0
.end method

.method public static hexDigitMsb0ToBinary(C)[Z
    .locals 3
    .param p0, "hexDigit"    # C

    .prologue
    const/4 v0, 0x4

    .line 223
    sparse-switch p0, :sswitch_data_0

    .line 263
    new-instance v0, Ljava/lang/IllegalArgumentException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Cannot interpret \'"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "\' as a hexadecimal digit"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 225
    :sswitch_0
    new-array v0, v0, [Z

    fill-array-data v0, :array_0

    .line 261
    :goto_0
    return-object v0

    .line 227
    :sswitch_1
    new-array v0, v0, [Z

    fill-array-data v0, :array_1

    goto :goto_0

    .line 229
    :sswitch_2
    new-array v0, v0, [Z

    fill-array-data v0, :array_2

    goto :goto_0

    .line 231
    :sswitch_3
    new-array v0, v0, [Z

    fill-array-data v0, :array_3

    goto :goto_0

    .line 233
    :sswitch_4
    new-array v0, v0, [Z

    fill-array-data v0, :array_4

    goto :goto_0

    .line 235
    :sswitch_5
    new-array v0, v0, [Z

    fill-array-data v0, :array_5

    goto :goto_0

    .line 237
    :sswitch_6
    new-array v0, v0, [Z

    fill-array-data v0, :array_6

    goto :goto_0

    .line 239
    :sswitch_7
    new-array v0, v0, [Z

    fill-array-data v0, :array_7

    goto :goto_0

    .line 241
    :sswitch_8
    new-array v0, v0, [Z

    fill-array-data v0, :array_8

    goto :goto_0

    .line 243
    :sswitch_9
    new-array v0, v0, [Z

    fill-array-data v0, :array_9

    goto :goto_0

    .line 246
    :sswitch_a
    new-array v0, v0, [Z

    fill-array-data v0, :array_a

    goto :goto_0

    .line 249
    :sswitch_b
    new-array v0, v0, [Z

    fill-array-data v0, :array_b

    goto :goto_0

    .line 252
    :sswitch_c
    new-array v0, v0, [Z

    fill-array-data v0, :array_c

    goto :goto_0

    .line 255
    :sswitch_d
    new-array v0, v0, [Z

    fill-array-data v0, :array_d

    goto :goto_0

    .line 258
    :sswitch_e
    new-array v0, v0, [Z

    fill-array-data v0, :array_e

    goto :goto_0

    .line 261
    :sswitch_f
    new-array v0, v0, [Z

    fill-array-data v0, :array_f

    goto :goto_0

    .line 223
    nop

    :sswitch_data_0
    .sparse-switch
        0x30 -> :sswitch_0
        0x31 -> :sswitch_1
        0x32 -> :sswitch_2
        0x33 -> :sswitch_3
        0x34 -> :sswitch_4
        0x35 -> :sswitch_5
        0x36 -> :sswitch_6
        0x37 -> :sswitch_7
        0x38 -> :sswitch_8
        0x39 -> :sswitch_9
        0x41 -> :sswitch_a
        0x42 -> :sswitch_b
        0x43 -> :sswitch_c
        0x44 -> :sswitch_d
        0x45 -> :sswitch_e
        0x46 -> :sswitch_f
        0x61 -> :sswitch_a
        0x62 -> :sswitch_b
        0x63 -> :sswitch_c
        0x64 -> :sswitch_d
        0x65 -> :sswitch_e
        0x66 -> :sswitch_f
    .end sparse-switch

    .line 225
    :array_0
    .array-data 1
        0x0t
        0x0t
        0x0t
        0x0t
    .end array-data

    .line 227
    :array_1
    .array-data 1
        0x0t
        0x0t
        0x0t
        0x1t
    .end array-data

    .line 229
    :array_2
    .array-data 1
        0x0t
        0x0t
        0x1t
        0x0t
    .end array-data

    .line 231
    :array_3
    .array-data 1
        0x0t
        0x0t
        0x1t
        0x1t
    .end array-data

    .line 233
    :array_4
    .array-data 1
        0x0t
        0x1t
        0x0t
        0x0t
    .end array-data

    .line 235
    :array_5
    .array-data 1
        0x0t
        0x1t
        0x0t
        0x1t
    .end array-data

    .line 237
    :array_6
    .array-data 1
        0x0t
        0x1t
        0x1t
        0x0t
    .end array-data

    .line 239
    :array_7
    .array-data 1
        0x0t
        0x1t
        0x1t
        0x1t
    .end array-data

    .line 241
    :array_8
    .array-data 1
        0x1t
        0x0t
        0x0t
        0x0t
    .end array-data

    .line 243
    :array_9
    .array-data 1
        0x1t
        0x0t
        0x0t
        0x1t
    .end array-data

    .line 246
    :array_a
    .array-data 1
        0x1t
        0x0t
        0x1t
        0x0t
    .end array-data

    .line 249
    :array_b
    .array-data 1
        0x1t
        0x0t
        0x1t
        0x1t
    .end array-data

    .line 252
    :array_c
    .array-data 1
        0x1t
        0x1t
        0x0t
        0x0t
    .end array-data

    .line 255
    :array_d
    .array-data 1
        0x1t
        0x1t
        0x0t
        0x1t
    .end array-data

    .line 258
    :array_e
    .array-data 1
        0x1t
        0x1t
        0x1t
        0x0t
    .end array-data

    .line 261
    :array_f
    .array-data 1
        0x1t
        0x1t
        0x1t
        0x1t
    .end array-data
.end method

.method public static hexDigitMsb0ToInt(C)I
    .locals 3
    .param p0, "hexDigit"    # C

    .prologue
    .line 103
    sparse-switch p0, :sswitch_data_0

    .line 143
    new-instance v0, Ljava/lang/IllegalArgumentException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Cannot interpret \'"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "\' as a hexadecimal digit"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 105
    :sswitch_0
    const/4 v0, 0x0

    .line 141
    :goto_0
    return v0

    .line 107
    :sswitch_1
    const/16 v0, 0x8

    goto :goto_0

    .line 109
    :sswitch_2
    const/4 v0, 0x4

    goto :goto_0

    .line 111
    :sswitch_3
    const/16 v0, 0xc

    goto :goto_0

    .line 113
    :sswitch_4
    const/4 v0, 0x2

    goto :goto_0

    .line 115
    :sswitch_5
    const/16 v0, 0xa

    goto :goto_0

    .line 117
    :sswitch_6
    const/4 v0, 0x6

    goto :goto_0

    .line 119
    :sswitch_7
    const/16 v0, 0xe

    goto :goto_0

    .line 121
    :sswitch_8
    const/4 v0, 0x1

    goto :goto_0

    .line 123
    :sswitch_9
    const/16 v0, 0x9

    goto :goto_0

    .line 126
    :sswitch_a
    const/4 v0, 0x5

    goto :goto_0

    .line 129
    :sswitch_b
    const/16 v0, 0xd

    goto :goto_0

    .line 132
    :sswitch_c
    const/4 v0, 0x3

    goto :goto_0

    .line 135
    :sswitch_d
    const/16 v0, 0xb

    goto :goto_0

    .line 138
    :sswitch_e
    const/4 v0, 0x7

    goto :goto_0

    .line 141
    :sswitch_f
    const/16 v0, 0xf

    goto :goto_0

    .line 103
    :sswitch_data_0
    .sparse-switch
        0x30 -> :sswitch_0
        0x31 -> :sswitch_1
        0x32 -> :sswitch_2
        0x33 -> :sswitch_3
        0x34 -> :sswitch_4
        0x35 -> :sswitch_5
        0x36 -> :sswitch_6
        0x37 -> :sswitch_7
        0x38 -> :sswitch_8
        0x39 -> :sswitch_9
        0x41 -> :sswitch_a
        0x42 -> :sswitch_b
        0x43 -> :sswitch_c
        0x44 -> :sswitch_d
        0x45 -> :sswitch_e
        0x46 -> :sswitch_f
        0x61 -> :sswitch_a
        0x62 -> :sswitch_b
        0x63 -> :sswitch_c
        0x64 -> :sswitch_d
        0x65 -> :sswitch_e
        0x66 -> :sswitch_f
    .end sparse-switch
.end method

.method public static hexDigitToBinary(C)[Z
    .locals 3
    .param p0, "hexDigit"    # C

    .prologue
    const/4 v0, 0x4

    .line 163
    sparse-switch p0, :sswitch_data_0

    .line 203
    new-instance v0, Ljava/lang/IllegalArgumentException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Cannot interpret \'"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "\' as a hexadecimal digit"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 165
    :sswitch_0
    new-array v0, v0, [Z

    fill-array-data v0, :array_0

    .line 201
    :goto_0
    return-object v0

    .line 167
    :sswitch_1
    new-array v0, v0, [Z

    fill-array-data v0, :array_1

    goto :goto_0

    .line 169
    :sswitch_2
    new-array v0, v0, [Z

    fill-array-data v0, :array_2

    goto :goto_0

    .line 171
    :sswitch_3
    new-array v0, v0, [Z

    fill-array-data v0, :array_3

    goto :goto_0

    .line 173
    :sswitch_4
    new-array v0, v0, [Z

    fill-array-data v0, :array_4

    goto :goto_0

    .line 175
    :sswitch_5
    new-array v0, v0, [Z

    fill-array-data v0, :array_5

    goto :goto_0

    .line 177
    :sswitch_6
    new-array v0, v0, [Z

    fill-array-data v0, :array_6

    goto :goto_0

    .line 179
    :sswitch_7
    new-array v0, v0, [Z

    fill-array-data v0, :array_7

    goto :goto_0

    .line 181
    :sswitch_8
    new-array v0, v0, [Z

    fill-array-data v0, :array_8

    goto :goto_0

    .line 183
    :sswitch_9
    new-array v0, v0, [Z

    fill-array-data v0, :array_9

    goto :goto_0

    .line 186
    :sswitch_a
    new-array v0, v0, [Z

    fill-array-data v0, :array_a

    goto :goto_0

    .line 189
    :sswitch_b
    new-array v0, v0, [Z

    fill-array-data v0, :array_b

    goto :goto_0

    .line 192
    :sswitch_c
    new-array v0, v0, [Z

    fill-array-data v0, :array_c

    goto :goto_0

    .line 195
    :sswitch_d
    new-array v0, v0, [Z

    fill-array-data v0, :array_d

    goto :goto_0

    .line 198
    :sswitch_e
    new-array v0, v0, [Z

    fill-array-data v0, :array_e

    goto :goto_0

    .line 201
    :sswitch_f
    new-array v0, v0, [Z

    fill-array-data v0, :array_f

    goto :goto_0

    .line 163
    nop

    :sswitch_data_0
    .sparse-switch
        0x30 -> :sswitch_0
        0x31 -> :sswitch_1
        0x32 -> :sswitch_2
        0x33 -> :sswitch_3
        0x34 -> :sswitch_4
        0x35 -> :sswitch_5
        0x36 -> :sswitch_6
        0x37 -> :sswitch_7
        0x38 -> :sswitch_8
        0x39 -> :sswitch_9
        0x41 -> :sswitch_a
        0x42 -> :sswitch_b
        0x43 -> :sswitch_c
        0x44 -> :sswitch_d
        0x45 -> :sswitch_e
        0x46 -> :sswitch_f
        0x61 -> :sswitch_a
        0x62 -> :sswitch_b
        0x63 -> :sswitch_c
        0x64 -> :sswitch_d
        0x65 -> :sswitch_e
        0x66 -> :sswitch_f
    .end sparse-switch

    .line 165
    :array_0
    .array-data 1
        0x0t
        0x0t
        0x0t
        0x0t
    .end array-data

    .line 167
    :array_1
    .array-data 1
        0x1t
        0x0t
        0x0t
        0x0t
    .end array-data

    .line 169
    :array_2
    .array-data 1
        0x0t
        0x1t
        0x0t
        0x0t
    .end array-data

    .line 171
    :array_3
    .array-data 1
        0x1t
        0x1t
        0x0t
        0x0t
    .end array-data

    .line 173
    :array_4
    .array-data 1
        0x0t
        0x0t
        0x1t
        0x0t
    .end array-data

    .line 175
    :array_5
    .array-data 1
        0x1t
        0x0t
        0x1t
        0x0t
    .end array-data

    .line 177
    :array_6
    .array-data 1
        0x0t
        0x1t
        0x1t
        0x0t
    .end array-data

    .line 179
    :array_7
    .array-data 1
        0x1t
        0x1t
        0x1t
        0x0t
    .end array-data

    .line 181
    :array_8
    .array-data 1
        0x0t
        0x0t
        0x0t
        0x1t
    .end array-data

    .line 183
    :array_9
    .array-data 1
        0x1t
        0x0t
        0x0t
        0x1t
    .end array-data

    .line 186
    :array_a
    .array-data 1
        0x0t
        0x1t
        0x0t
        0x1t
    .end array-data

    .line 189
    :array_b
    .array-data 1
        0x1t
        0x1t
        0x0t
        0x1t
    .end array-data

    .line 192
    :array_c
    .array-data 1
        0x0t
        0x0t
        0x1t
        0x1t
    .end array-data

    .line 195
    :array_d
    .array-data 1
        0x1t
        0x0t
        0x1t
        0x1t
    .end array-data

    .line 198
    :array_e
    .array-data 1
        0x0t
        0x1t
        0x1t
        0x1t
    .end array-data

    .line 201
    :array_f
    .array-data 1
        0x1t
        0x1t
        0x1t
        0x1t
    .end array-data
.end method

.method public static hexDigitToInt(C)I
    .locals 4
    .param p0, "hexDigit"    # C

    .prologue
    .line 81
    const/16 v1, 0x10

    invoke-static {p0, v1}, Ljava/lang/Character;->digit(CI)I

    move-result v0

    .line 82
    .local v0, "digit":I
    if-gez v0, :cond_0

    .line 83
    new-instance v1, Ljava/lang/IllegalArgumentException;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Cannot interpret \'"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, p0}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "\' as a hexadecimal digit"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-direct {v1, v2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v1

    .line 87
    :cond_0
    return v0
.end method

.method public static hexToByte(Ljava/lang/String;IBII)B
    .locals 7
    .param p0, "src"    # Ljava/lang/String;
    .param p1, "srcPos"    # I
    .param p2, "dstInit"    # B
    .param p3, "dstPos"    # I
    .param p4, "nHex"    # I

    .prologue
    .line 1007
    if-nez p4, :cond_0

    .line 1022
    .end local p2    # "dstInit":B
    :goto_0
    return p2

    .line 1010
    .restart local p2    # "dstInit":B
    :cond_0
    add-int/lit8 v5, p4, -0x1

    mul-int/lit8 v5, v5, 0x4

    add-int/2addr v5, p3

    const/16 v6, 0x8

    if-lt v5, v6, :cond_1

    .line 1011
    new-instance v5, Ljava/lang/IllegalArgumentException;

    const-string v6, "(nHexs-1)*4+dstPos is greather or equal to than 8"

    invoke-direct {v5, v6}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v5

    .line 1014
    :cond_1
    move v3, p2

    .line 1015
    .local v3, "out":B
    const/4 v4, 0x0

    .line 1016
    .local v4, "shift":I
    const/4 v1, 0x0

    .local v1, "i":I
    :goto_1
    if-ge v1, p4, :cond_2

    .line 1017
    mul-int/lit8 v5, v1, 0x4

    add-int v4, v5, p3

    .line 1018
    add-int v5, v1, p1

    invoke-virtual {p0, v5}, Ljava/lang/String;->charAt(I)C

    move-result v5

    invoke-static {v5}, Lorg/apache/commons/lang3/Conversion;->hexDigitToInt(C)I

    move-result v5

    and-int/lit8 v5, v5, 0xf

    shl-int v0, v5, v4

    .line 1019
    .local v0, "bits":I
    const/16 v5, 0xf

    shl-int v2, v5, v4

    .line 1020
    .local v2, "mask":I
    xor-int/lit8 v5, v2, -0x1

    and-int/2addr v5, v3

    or-int/2addr v5, v0

    int-to-byte v3, v5

    .line 1016
    add-int/lit8 v1, v1, 0x1

    goto :goto_1

    .end local v0    # "bits":I
    .end local v2    # "mask":I
    :cond_2
    move p2, v3

    .line 1022
    goto :goto_0
.end method

.method public static hexToInt(Ljava/lang/String;IIII)I
    .locals 7
    .param p0, "src"    # Ljava/lang/String;
    .param p1, "srcPos"    # I
    .param p2, "dstInit"    # I
    .param p3, "dstPos"    # I
    .param p4, "nHex"    # I

    .prologue
    .line 939
    if-nez p4, :cond_0

    .line 954
    .end local p2    # "dstInit":I
    :goto_0
    return p2

    .line 942
    .restart local p2    # "dstInit":I
    :cond_0
    add-int/lit8 v5, p4, -0x1

    mul-int/lit8 v5, v5, 0x4

    add-int/2addr v5, p3

    const/16 v6, 0x20

    if-lt v5, v6, :cond_1

    .line 943
    new-instance v5, Ljava/lang/IllegalArgumentException;

    const-string v6, "(nHexs-1)*4+dstPos is greather or equal to than 32"

    invoke-direct {v5, v6}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v5

    .line 946
    :cond_1
    move v3, p2

    .line 947
    .local v3, "out":I
    const/4 v4, 0x0

    .line 948
    .local v4, "shift":I
    const/4 v1, 0x0

    .local v1, "i":I
    :goto_1
    if-ge v1, p4, :cond_2

    .line 949
    mul-int/lit8 v5, v1, 0x4

    add-int v4, v5, p3

    .line 950
    add-int v5, v1, p1

    invoke-virtual {p0, v5}, Ljava/lang/String;->charAt(I)C

    move-result v5

    invoke-static {v5}, Lorg/apache/commons/lang3/Conversion;->hexDigitToInt(C)I

    move-result v5

    and-int/lit8 v5, v5, 0xf

    shl-int v0, v5, v4

    .line 951
    .local v0, "bits":I
    const/16 v5, 0xf

    shl-int v2, v5, v4

    .line 952
    .local v2, "mask":I
    xor-int/lit8 v5, v2, -0x1

    and-int/2addr v5, v3

    or-int v3, v5, v0

    .line 948
    add-int/lit8 v1, v1, 0x1

    goto :goto_1

    .end local v0    # "bits":I
    .end local v2    # "mask":I
    :cond_2
    move p2, v3

    .line 954
    goto :goto_0
.end method

.method public static hexToLong(Ljava/lang/String;IJII)J
    .locals 13
    .param p0, "src"    # Ljava/lang/String;
    .param p1, "srcPos"    # I
    .param p2, "dstInit"    # J
    .param p4, "dstPos"    # I
    .param p5, "nHex"    # I

    .prologue
    .line 905
    if-nez p5, :cond_0

    .line 920
    .end local p2    # "dstInit":J
    :goto_0
    return-wide p2

    .line 908
    .restart local p2    # "dstInit":J
    :cond_0
    add-int/lit8 v9, p5, -0x1

    mul-int/lit8 v9, v9, 0x4

    add-int v9, v9, p4

    const/16 v10, 0x40

    if-lt v9, v10, :cond_1

    .line 909
    new-instance v9, Ljava/lang/IllegalArgumentException;

    const-string v10, "(nHexs-1)*4+dstPos is greather or equal to than 64"

    invoke-direct {v9, v10}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v9

    .line 912
    :cond_1
    move-wide v6, p2

    .line 913
    .local v6, "out":J
    const/4 v8, 0x0

    .line 914
    .local v8, "shift":I
    const/4 v3, 0x0

    .local v3, "i":I
    :goto_1
    move/from16 v0, p5

    if-ge v3, v0, :cond_2

    .line 915
    mul-int/lit8 v9, v3, 0x4

    add-int v8, v9, p4

    .line 916
    const-wide/16 v9, 0xf

    add-int v11, v3, p1

    invoke-virtual {p0, v11}, Ljava/lang/String;->charAt(I)C

    move-result v11

    invoke-static {v11}, Lorg/apache/commons/lang3/Conversion;->hexDigitToInt(C)I

    move-result v11

    int-to-long v11, v11

    and-long/2addr v9, v11

    shl-long v1, v9, v8

    .line 917
    .local v1, "bits":J
    const-wide/16 v9, 0xf

    shl-long v4, v9, v8

    .line 918
    .local v4, "mask":J
    const-wide/16 v9, -0x1

    xor-long/2addr v9, v4

    and-long/2addr v9, v6

    or-long v6, v9, v1

    .line 914
    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    .end local v1    # "bits":J
    .end local v4    # "mask":J
    :cond_2
    move-wide p2, v6

    .line 920
    goto :goto_0
.end method

.method public static hexToShort(Ljava/lang/String;ISII)S
    .locals 7
    .param p0, "src"    # Ljava/lang/String;
    .param p1, "srcPos"    # I
    .param p2, "dstInit"    # S
    .param p3, "dstPos"    # I
    .param p4, "nHex"    # I

    .prologue
    .line 973
    if-nez p4, :cond_0

    .line 988
    .end local p2    # "dstInit":S
    :goto_0
    return p2

    .line 976
    .restart local p2    # "dstInit":S
    :cond_0
    add-int/lit8 v5, p4, -0x1

    mul-int/lit8 v5, v5, 0x4

    add-int/2addr v5, p3

    const/16 v6, 0x10

    if-lt v5, v6, :cond_1

    .line 977
    new-instance v5, Ljava/lang/IllegalArgumentException;

    const-string v6, "(nHexs-1)*4+dstPos is greather or equal to than 16"

    invoke-direct {v5, v6}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v5

    .line 980
    :cond_1
    move v3, p2

    .line 981
    .local v3, "out":S
    const/4 v4, 0x0

    .line 982
    .local v4, "shift":I
    const/4 v1, 0x0

    .local v1, "i":I
    :goto_1
    if-ge v1, p4, :cond_2

    .line 983
    mul-int/lit8 v5, v1, 0x4

    add-int v4, v5, p3

    .line 984
    add-int v5, v1, p1

    invoke-virtual {p0, v5}, Ljava/lang/String;->charAt(I)C

    move-result v5

    invoke-static {v5}, Lorg/apache/commons/lang3/Conversion;->hexDigitToInt(C)I

    move-result v5

    and-int/lit8 v5, v5, 0xf

    shl-int v0, v5, v4

    .line 985
    .local v0, "bits":I
    const/16 v5, 0xf

    shl-int v2, v5, v4

    .line 986
    .local v2, "mask":I
    xor-int/lit8 v5, v2, -0x1

    and-int/2addr v5, v3

    or-int/2addr v5, v0

    int-to-short v3, v5

    .line 982
    add-int/lit8 v1, v1, 0x1

    goto :goto_1

    .end local v0    # "bits":I
    .end local v2    # "mask":I
    :cond_2
    move p2, v3

    .line 988
    goto :goto_0
.end method

.method public static intArrayToLong([IIJII)J
    .locals 13
    .param p0, "src"    # [I
    .param p1, "srcPos"    # I
    .param p2, "dstInit"    # J
    .param p4, "dstPos"    # I
    .param p5, "nInts"    # I

    .prologue
    .line 687
    array-length v9, p0

    if-nez v9, :cond_0

    if-eqz p1, :cond_1

    :cond_0
    if-nez p5, :cond_2

    .line 702
    .end local p2    # "dstInit":J
    :cond_1
    :goto_0
    return-wide p2

    .line 690
    .restart local p2    # "dstInit":J
    :cond_2
    add-int/lit8 v9, p5, -0x1

    mul-int/lit8 v9, v9, 0x20

    add-int v9, v9, p4

    const/16 v10, 0x40

    if-lt v9, v10, :cond_3

    .line 691
    new-instance v9, Ljava/lang/IllegalArgumentException;

    const-string v10, "(nInts-1)*32+dstPos is greather or equal to than 64"

    invoke-direct {v9, v10}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v9

    .line 694
    :cond_3
    move-wide v6, p2

    .line 695
    .local v6, "out":J
    const/4 v8, 0x0

    .line 696
    .local v8, "shift":I
    const/4 v3, 0x0

    .local v3, "i":I
    :goto_1
    move/from16 v0, p5

    if-ge v3, v0, :cond_4

    .line 697
    mul-int/lit8 v9, v3, 0x20

    add-int v8, v9, p4

    .line 698
    const-wide v9, 0xffffffffL

    add-int v11, v3, p1

    aget v11, p0, v11

    int-to-long v11, v11

    and-long/2addr v9, v11

    shl-long v1, v9, v8

    .line 699
    .local v1, "bits":J
    const-wide v9, 0xffffffffL

    shl-long v4, v9, v8

    .line 700
    .local v4, "mask":J
    const-wide/16 v9, -0x1

    xor-long/2addr v9, v4

    and-long/2addr v9, v6

    or-long v6, v9, v1

    .line 696
    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    .end local v1    # "bits":J
    .end local v4    # "mask":J
    :cond_4
    move-wide p2, v6

    .line 702
    goto :goto_0
.end method

.method public static intToBinary(II[ZII)[Z
    .locals 4
    .param p0, "src"    # I
    .param p1, "srcPos"    # I
    .param p2, "dst"    # [Z
    .param p3, "dstPos"    # I
    .param p4, "nBools"    # I

    .prologue
    .line 1586
    if-nez p4, :cond_1

    .line 1598
    :cond_0
    return-object p2

    .line 1589
    :cond_1
    add-int/lit8 v2, p4, -0x1

    add-int/2addr v2, p1

    const/16 v3, 0x20

    if-lt v2, v3, :cond_2

    .line 1590
    new-instance v2, Ljava/lang/IllegalArgumentException;

    const-string v3, "nBools-1+srcPos is greather or equal to than 32"

    invoke-direct {v2, v3}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v2

    .line 1593
    :cond_2
    const/4 v1, 0x0

    .line 1594
    .local v1, "shift":I
    const/4 v0, 0x0

    .local v0, "i":I
    :goto_0
    if-ge v0, p4, :cond_0

    .line 1595
    mul-int/lit8 v2, v0, 0x1

    add-int v1, v2, p1

    .line 1596
    add-int v3, p3, v0

    shr-int v2, p0, v1

    and-int/lit8 v2, v2, 0x1

    if-eqz v2, :cond_3

    const/4 v2, 0x1

    :goto_1
    aput-boolean v2, p2, v3

    .line 1594
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 1596
    :cond_3
    const/4 v2, 0x0

    goto :goto_1
.end method

.method public static intToByteArray(II[BII)[B
    .locals 4
    .param p0, "src"    # I
    .param p1, "srcPos"    # I
    .param p2, "dst"    # [B
    .param p3, "dstPos"    # I
    .param p4, "nBytes"    # I

    .prologue
    .line 1324
    if-nez p4, :cond_1

    .line 1336
    :cond_0
    return-object p2

    .line 1327
    :cond_1
    add-int/lit8 v2, p4, -0x1

    mul-int/lit8 v2, v2, 0x8

    add-int/2addr v2, p1

    const/16 v3, 0x20

    if-lt v2, v3, :cond_2

    .line 1328
    new-instance v2, Ljava/lang/IllegalArgumentException;

    const-string v3, "(nBytes-1)*8+srcPos is greather or equal to than 32"

    invoke-direct {v2, v3}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v2

    .line 1331
    :cond_2
    const/4 v1, 0x0

    .line 1332
    .local v1, "shift":I
    const/4 v0, 0x0

    .local v0, "i":I
    :goto_0
    if-ge v0, p4, :cond_0

    .line 1333
    mul-int/lit8 v2, v0, 0x8

    add-int v1, v2, p1

    .line 1334
    add-int v2, p3, v0

    shr-int v3, p0, v1

    and-int/lit16 v3, v3, 0xff

    int-to-byte v3, v3

    aput-byte v3, p2, v2

    .line 1332
    add-int/lit8 v0, v0, 0x1

    goto :goto_0
.end method

.method public static intToHex(IILjava/lang/String;II)Ljava/lang/String;
    .locals 7
    .param p0, "src"    # I
    .param p1, "srcPos"    # I
    .param p2, "dstInit"    # Ljava/lang/String;
    .param p3, "dstPos"    # I
    .param p4, "nHexs"    # I

    .prologue
    .line 1430
    if-nez p4, :cond_0

    .line 1450
    .end local p2    # "dstInit":Ljava/lang/String;
    :goto_0
    return-object p2

    .line 1433
    .restart local p2    # "dstInit":Ljava/lang/String;
    :cond_0
    add-int/lit8 v5, p4, -0x1

    mul-int/lit8 v5, v5, 0x4

    add-int/2addr v5, p1

    const/16 v6, 0x20

    if-lt v5, v6, :cond_1

    .line 1434
    new-instance v5, Ljava/lang/IllegalArgumentException;

    const-string v6, "(nHexs-1)*4+srcPos is greather or equal to than 32"

    invoke-direct {v5, v6}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v5

    .line 1437
    :cond_1
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3, p2}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    .line 1438
    .local v3, "sb":Ljava/lang/StringBuilder;
    const/4 v4, 0x0

    .line 1439
    .local v4, "shift":I
    invoke-virtual {v3}, Ljava/lang/StringBuilder;->length()I

    move-result v0

    .line 1440
    .local v0, "append":I
    const/4 v2, 0x0

    .local v2, "i":I
    :goto_1
    if-ge v2, p4, :cond_3

    .line 1441
    mul-int/lit8 v5, v2, 0x4

    add-int v4, v5, p1

    .line 1442
    shr-int v5, p0, v4

    and-int/lit8 v1, v5, 0xf

    .line 1443
    .local v1, "bits":I
    add-int v5, p3, v2

    if-ne v5, v0, :cond_2

    .line 1444
    add-int/lit8 v0, v0, 0x1

    .line 1445
    invoke-static {v1}, Lorg/apache/commons/lang3/Conversion;->intToHexDigit(I)C

    move-result v5

    invoke-virtual {v3, v5}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    .line 1440
    :goto_2
    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    .line 1447
    :cond_2
    add-int v5, p3, v2

    invoke-static {v1}, Lorg/apache/commons/lang3/Conversion;->intToHexDigit(I)C

    move-result v6

    invoke-virtual {v3, v5, v6}, Ljava/lang/StringBuilder;->setCharAt(IC)V

    goto :goto_2

    .line 1450
    .end local v1    # "bits":I
    :cond_3
    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    goto :goto_0
.end method

.method public static intToHexDigit(I)C
    .locals 4
    .param p0, "nibble"    # I

    .prologue
    .line 605
    const/16 v1, 0x10

    invoke-static {p0, v1}, Ljava/lang/Character;->forDigit(II)C

    move-result v0

    .line 606
    .local v0, "c":C
    if-nez v0, :cond_0

    .line 607
    new-instance v1, Ljava/lang/IllegalArgumentException;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "nibble value not between 0 and 15: "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, p0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-direct {v1, v2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v1

    .line 609
    :cond_0
    return v0
.end method

.method public static intToHexDigitMsb0(I)C
    .locals 3
    .param p0, "nibble"    # I

    .prologue
    .line 631
    packed-switch p0, :pswitch_data_0

    .line 665
    new-instance v0, Ljava/lang/IllegalArgumentException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "nibble value not between 0 and 15: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 633
    :pswitch_0
    const/16 v0, 0x30

    .line 663
    :goto_0
    return v0

    .line 635
    :pswitch_1
    const/16 v0, 0x38

    goto :goto_0

    .line 637
    :pswitch_2
    const/16 v0, 0x34

    goto :goto_0

    .line 639
    :pswitch_3
    const/16 v0, 0x63

    goto :goto_0

    .line 641
    :pswitch_4
    const/16 v0, 0x32

    goto :goto_0

    .line 643
    :pswitch_5
    const/16 v0, 0x61

    goto :goto_0

    .line 645
    :pswitch_6
    const/16 v0, 0x36

    goto :goto_0

    .line 647
    :pswitch_7
    const/16 v0, 0x65

    goto :goto_0

    .line 649
    :pswitch_8
    const/16 v0, 0x31

    goto :goto_0

    .line 651
    :pswitch_9
    const/16 v0, 0x39

    goto :goto_0

    .line 653
    :pswitch_a
    const/16 v0, 0x35

    goto :goto_0

    .line 655
    :pswitch_b
    const/16 v0, 0x64

    goto :goto_0

    .line 657
    :pswitch_c
    const/16 v0, 0x33

    goto :goto_0

    .line 659
    :pswitch_d
    const/16 v0, 0x62

    goto :goto_0

    .line 661
    :pswitch_e
    const/16 v0, 0x37

    goto :goto_0

    .line 663
    :pswitch_f
    const/16 v0, 0x66

    goto :goto_0

    .line 631
    :pswitch_data_0
    .packed-switch 0x0
        :pswitch_0
        :pswitch_1
        :pswitch_2
        :pswitch_3
        :pswitch_4
        :pswitch_5
        :pswitch_6
        :pswitch_7
        :pswitch_8
        :pswitch_9
        :pswitch_a
        :pswitch_b
        :pswitch_c
        :pswitch_d
        :pswitch_e
        :pswitch_f
    .end packed-switch
.end method

.method public static intToShortArray(II[SII)[S
    .locals 5
    .param p0, "src"    # I
    .param p1, "srcPos"    # I
    .param p2, "dst"    # [S
    .param p3, "dstPos"    # I
    .param p4, "nShorts"    # I

    .prologue
    .line 1257
    if-nez p4, :cond_1

    .line 1269
    :cond_0
    return-object p2

    .line 1260
    :cond_1
    add-int/lit8 v2, p4, -0x1

    mul-int/lit8 v2, v2, 0x10

    add-int/2addr v2, p1

    const/16 v3, 0x20

    if-lt v2, v3, :cond_2

    .line 1261
    new-instance v2, Ljava/lang/IllegalArgumentException;

    const-string v3, "(nShorts-1)*16+srcPos is greather or equal to than 32"

    invoke-direct {v2, v3}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v2

    .line 1264
    :cond_2
    const/4 v1, 0x0

    .line 1265
    .local v1, "shift":I
    const/4 v0, 0x0

    .local v0, "i":I
    :goto_0
    if-ge v0, p4, :cond_0

    .line 1266
    mul-int/lit8 v2, v0, 0x10

    add-int v1, v2, p1

    .line 1267
    add-int v2, p3, v0

    const v3, 0xffff

    shr-int v4, p0, v1

    and-int/2addr v3, v4

    int-to-short v3, v3

    aput-short v3, p2, v2

    .line 1265
    add-int/lit8 v0, v0, 0x1

    goto :goto_0
.end method

.method public static longToBinary(JI[ZII)[Z
    .locals 8
    .param p0, "src"    # J
    .param p2, "srcPos"    # I
    .param p3, "dst"    # [Z
    .param p4, "dstPos"    # I
    .param p5, "nBools"    # I

    .prologue
    .line 1552
    if-nez p5, :cond_1

    .line 1564
    :cond_0
    return-object p3

    .line 1555
    :cond_1
    add-int/lit8 v2, p5, -0x1

    add-int/2addr v2, p2

    const/16 v3, 0x40

    if-lt v2, v3, :cond_2

    .line 1556
    new-instance v2, Ljava/lang/IllegalArgumentException;

    const-string v3, "nBools-1+srcPos is greather or equal to than 64"

    invoke-direct {v2, v3}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v2

    .line 1559
    :cond_2
    const/4 v1, 0x0

    .line 1560
    .local v1, "shift":I
    const/4 v0, 0x0

    .local v0, "i":I
    :goto_0
    if-ge v0, p5, :cond_0

    .line 1561
    mul-int/lit8 v2, v0, 0x1

    add-int v1, v2, p2

    .line 1562
    add-int v3, p4, v0

    const-wide/16 v4, 0x1

    shr-long v6, p0, v1

    and-long/2addr v4, v6

    const-wide/16 v6, 0x0

    cmp-long v2, v4, v6

    if-eqz v2, :cond_3

    const/4 v2, 0x1

    :goto_1
    aput-boolean v2, p3, v3

    .line 1560
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 1562
    :cond_3
    const/4 v2, 0x0

    goto :goto_1
.end method

.method public static longToByteArray(JI[BII)[B
    .locals 7
    .param p0, "src"    # J
    .param p2, "srcPos"    # I
    .param p3, "dst"    # [B
    .param p4, "dstPos"    # I
    .param p5, "nBytes"    # I

    .prologue
    .line 1291
    if-nez p5, :cond_1

    .line 1303
    :cond_0
    return-object p3

    .line 1294
    :cond_1
    add-int/lit8 v2, p5, -0x1

    mul-int/lit8 v2, v2, 0x8

    add-int/2addr v2, p2

    const/16 v3, 0x40

    if-lt v2, v3, :cond_2

    .line 1295
    new-instance v2, Ljava/lang/IllegalArgumentException;

    const-string v3, "(nBytes-1)*8+srcPos is greather or equal to than 64"

    invoke-direct {v2, v3}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v2

    .line 1298
    :cond_2
    const/4 v1, 0x0

    .line 1299
    .local v1, "shift":I
    const/4 v0, 0x0

    .local v0, "i":I
    :goto_0
    if-ge v0, p5, :cond_0

    .line 1300
    mul-int/lit8 v2, v0, 0x8

    add-int v1, v2, p2

    .line 1301
    add-int v2, p4, v0

    const-wide/16 v3, 0xff

    shr-long v5, p0, v1

    and-long/2addr v3, v5

    long-to-int v3, v3

    int-to-byte v3, v3

    aput-byte v3, p3, v2

    .line 1299
    add-int/lit8 v0, v0, 0x1

    goto :goto_0
.end method

.method public static longToHex(JILjava/lang/String;II)Ljava/lang/String;
    .locals 9
    .param p0, "src"    # J
    .param p2, "srcPos"    # I
    .param p3, "dstInit"    # Ljava/lang/String;
    .param p4, "dstPos"    # I
    .param p5, "nHexs"    # I

    .prologue
    .line 1390
    if-nez p5, :cond_0

    .line 1410
    .end local p3    # "dstInit":Ljava/lang/String;
    :goto_0
    return-object p3

    .line 1393
    .restart local p3    # "dstInit":Ljava/lang/String;
    :cond_0
    add-int/lit8 v5, p5, -0x1

    mul-int/lit8 v5, v5, 0x4

    add-int/2addr v5, p2

    const/16 v6, 0x40

    if-lt v5, v6, :cond_1

    .line 1394
    new-instance v5, Ljava/lang/IllegalArgumentException;

    const-string v6, "(nHexs-1)*4+srcPos is greather or equal to than 64"

    invoke-direct {v5, v6}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v5

    .line 1397
    :cond_1
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3, p3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    .line 1398
    .local v3, "sb":Ljava/lang/StringBuilder;
    const/4 v4, 0x0

    .line 1399
    .local v4, "shift":I
    invoke-virtual {v3}, Ljava/lang/StringBuilder;->length()I

    move-result v0

    .line 1400
    .local v0, "append":I
    const/4 v2, 0x0

    .local v2, "i":I
    :goto_1
    if-ge v2, p5, :cond_3

    .line 1401
    mul-int/lit8 v5, v2, 0x4

    add-int v4, v5, p2

    .line 1402
    const-wide/16 v5, 0xf

    shr-long v7, p0, v4

    and-long/2addr v5, v7

    long-to-int v1, v5

    .line 1403
    .local v1, "bits":I
    add-int v5, p4, v2

    if-ne v5, v0, :cond_2

    .line 1404
    add-int/lit8 v0, v0, 0x1

    .line 1405
    invoke-static {v1}, Lorg/apache/commons/lang3/Conversion;->intToHexDigit(I)C

    move-result v5

    invoke-virtual {v3, v5}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    .line 1400
    :goto_2
    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    .line 1407
    :cond_2
    add-int v5, p4, v2

    invoke-static {v1}, Lorg/apache/commons/lang3/Conversion;->intToHexDigit(I)C

    move-result v6

    invoke-virtual {v3, v5, v6}, Ljava/lang/StringBuilder;->setCharAt(IC)V

    goto :goto_2

    .line 1410
    .end local v1    # "bits":I
    :cond_3
    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p3

    goto :goto_0
.end method

.method public static longToIntArray(JI[III)[I
    .locals 7
    .param p0, "src"    # J
    .param p2, "srcPos"    # I
    .param p3, "dst"    # [I
    .param p4, "dstPos"    # I
    .param p5, "nInts"    # I

    .prologue
    .line 1189
    if-nez p5, :cond_1

    .line 1201
    :cond_0
    return-object p3

    .line 1192
    :cond_1
    add-int/lit8 v2, p5, -0x1

    mul-int/lit8 v2, v2, 0x20

    add-int/2addr v2, p2

    const/16 v3, 0x40

    if-lt v2, v3, :cond_2

    .line 1193
    new-instance v2, Ljava/lang/IllegalArgumentException;

    const-string v3, "(nInts-1)*32+srcPos is greather or equal to than 64"

    invoke-direct {v2, v3}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v2

    .line 1196
    :cond_2
    const/4 v1, 0x0

    .line 1197
    .local v1, "shift":I
    const/4 v0, 0x0

    .local v0, "i":I
    :goto_0
    if-ge v0, p5, :cond_0

    .line 1198
    mul-int/lit8 v2, v0, 0x20

    add-int v1, v2, p2

    .line 1199
    add-int v2, p4, v0

    const-wide/16 v3, -0x1

    shr-long v5, p0, v1

    and-long/2addr v3, v5

    long-to-int v3, v3

    aput v3, p3, v2

    .line 1197
    add-int/lit8 v0, v0, 0x1

    goto :goto_0
.end method

.method public static longToShortArray(JI[SII)[S
    .locals 7
    .param p0, "src"    # J
    .param p2, "srcPos"    # I
    .param p3, "dst"    # [S
    .param p4, "dstPos"    # I
    .param p5, "nShorts"    # I

    .prologue
    .line 1223
    if-nez p5, :cond_1

    .line 1235
    :cond_0
    return-object p3

    .line 1226
    :cond_1
    add-int/lit8 v2, p5, -0x1

    mul-int/lit8 v2, v2, 0x10

    add-int/2addr v2, p2

    const/16 v3, 0x40

    if-lt v2, v3, :cond_2

    .line 1227
    new-instance v2, Ljava/lang/IllegalArgumentException;

    const-string v3, "(nShorts-1)*16+srcPos is greather or equal to than 64"

    invoke-direct {v2, v3}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v2

    .line 1230
    :cond_2
    const/4 v1, 0x0

    .line 1231
    .local v1, "shift":I
    const/4 v0, 0x0

    .local v0, "i":I
    :goto_0
    if-ge v0, p5, :cond_0

    .line 1232
    mul-int/lit8 v2, v0, 0x10

    add-int v1, v2, p2

    .line 1233
    add-int v2, p4, v0

    const-wide/32 v3, 0xffff

    shr-long v5, p0, v1

    and-long/2addr v3, v5

    long-to-int v3, v3

    int-to-short v3, v3

    aput-short v3, p3, v2

    .line 1231
    add-int/lit8 v0, v0, 0x1

    goto :goto_0
.end method

.method public static shortArrayToInt([SIIII)I
    .locals 8
    .param p0, "src"    # [S
    .param p1, "srcPos"    # I
    .param p2, "dstInit"    # I
    .param p3, "dstPos"    # I
    .param p4, "nShorts"    # I

    .prologue
    const v7, 0xffff

    .line 761
    array-length v5, p0

    if-nez v5, :cond_0

    if-eqz p1, :cond_1

    :cond_0
    if-nez p4, :cond_2

    .line 776
    .end local p2    # "dstInit":I
    :cond_1
    :goto_0
    return p2

    .line 764
    .restart local p2    # "dstInit":I
    :cond_2
    add-int/lit8 v5, p4, -0x1

    mul-int/lit8 v5, v5, 0x10

    add-int/2addr v5, p3

    const/16 v6, 0x20

    if-lt v5, v6, :cond_3

    .line 765
    new-instance v5, Ljava/lang/IllegalArgumentException;

    const-string v6, "(nShorts-1)*16+dstPos is greather or equal to than 32"

    invoke-direct {v5, v6}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v5

    .line 768
    :cond_3
    move v3, p2

    .line 769
    .local v3, "out":I
    const/4 v4, 0x0

    .line 770
    .local v4, "shift":I
    const/4 v1, 0x0

    .local v1, "i":I
    :goto_1
    if-ge v1, p4, :cond_4

    .line 771
    mul-int/lit8 v5, v1, 0x10

    add-int v4, v5, p3

    .line 772
    add-int v5, v1, p1

    aget-short v5, p0, v5

    and-int/2addr v5, v7

    shl-int v0, v5, v4

    .line 773
    .local v0, "bits":I
    shl-int v2, v7, v4

    .line 774
    .local v2, "mask":I
    xor-int/lit8 v5, v2, -0x1

    and-int/2addr v5, v3

    or-int v3, v5, v0

    .line 770
    add-int/lit8 v1, v1, 0x1

    goto :goto_1

    .end local v0    # "bits":I
    .end local v2    # "mask":I
    :cond_4
    move p2, v3

    .line 776
    goto :goto_0
.end method

.method public static shortArrayToLong([SIJII)J
    .locals 13
    .param p0, "src"    # [S
    .param p1, "srcPos"    # I
    .param p2, "dstInit"    # J
    .param p4, "dstPos"    # I
    .param p5, "nShorts"    # I

    .prologue
    .line 724
    array-length v9, p0

    if-nez v9, :cond_0

    if-eqz p1, :cond_1

    :cond_0
    if-nez p5, :cond_2

    .line 739
    .end local p2    # "dstInit":J
    :cond_1
    :goto_0
    return-wide p2

    .line 727
    .restart local p2    # "dstInit":J
    :cond_2
    add-int/lit8 v9, p5, -0x1

    mul-int/lit8 v9, v9, 0x10

    add-int v9, v9, p4

    const/16 v10, 0x40

    if-lt v9, v10, :cond_3

    .line 728
    new-instance v9, Ljava/lang/IllegalArgumentException;

    const-string v10, "(nShorts-1)*16+dstPos is greather or equal to than 64"

    invoke-direct {v9, v10}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v9

    .line 731
    :cond_3
    move-wide v6, p2

    .line 732
    .local v6, "out":J
    const/4 v8, 0x0

    .line 733
    .local v8, "shift":I
    const/4 v3, 0x0

    .local v3, "i":I
    :goto_1
    move/from16 v0, p5

    if-ge v3, v0, :cond_4

    .line 734
    mul-int/lit8 v9, v3, 0x10

    add-int v8, v9, p4

    .line 735
    const-wide/32 v9, 0xffff

    add-int v11, v3, p1

    aget-short v11, p0, v11

    int-to-long v11, v11

    and-long/2addr v9, v11

    shl-long v1, v9, v8

    .line 736
    .local v1, "bits":J
    const-wide/32 v9, 0xffff

    shl-long v4, v9, v8

    .line 737
    .local v4, "mask":J
    const-wide/16 v9, -0x1

    xor-long/2addr v9, v4

    and-long/2addr v9, v6

    or-long v6, v9, v1

    .line 733
    add-int/lit8 v3, v3, 0x1

    goto :goto_1

    .end local v1    # "bits":J
    .end local v4    # "mask":J
    :cond_4
    move-wide p2, v6

    .line 739
    goto :goto_0
.end method

.method public static shortToBinary(SI[ZII)[Z
    .locals 4
    .param p0, "src"    # S
    .param p1, "srcPos"    # I
    .param p2, "dst"    # [Z
    .param p3, "dstPos"    # I
    .param p4, "nBools"    # I

    .prologue
    .line 1620
    if-nez p4, :cond_1

    .line 1633
    :cond_0
    return-object p2

    .line 1623
    :cond_1
    add-int/lit8 v2, p4, -0x1

    add-int/2addr v2, p1

    const/16 v3, 0x10

    if-lt v2, v3, :cond_2

    .line 1624
    new-instance v2, Ljava/lang/IllegalArgumentException;

    const-string v3, "nBools-1+srcPos is greather or equal to than 16"

    invoke-direct {v2, v3}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v2

    .line 1627
    :cond_2
    const/4 v1, 0x0

    .line 1628
    .local v1, "shift":I
    sget-boolean v2, Lorg/apache/commons/lang3/Conversion;->$assertionsDisabled:Z

    if-nez v2, :cond_3

    add-int/lit8 v2, p4, -0x1

    mul-int/lit8 v2, v2, 0x1

    rsub-int/lit8 v3, p1, 0x10

    if-lt v2, v3, :cond_3

    new-instance v2, Ljava/lang/AssertionError;

    invoke-direct {v2}, Ljava/lang/AssertionError;-><init>()V

    throw v2

    .line 1629
    :cond_3
    const/4 v0, 0x0

    .local v0, "i":I
    :goto_0
    if-ge v0, p4, :cond_0

    .line 1630
    mul-int/lit8 v2, v0, 0x1

    add-int v1, v2, p1

    .line 1631
    add-int v3, p3, v0

    shr-int v2, p0, v1

    and-int/lit8 v2, v2, 0x1

    if-eqz v2, :cond_4

    const/4 v2, 0x1

    :goto_1
    aput-boolean v2, p2, v3

    .line 1629
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 1631
    :cond_4
    const/4 v2, 0x0

    goto :goto_1
.end method

.method public static shortToByteArray(SI[BII)[B
    .locals 4
    .param p0, "src"    # S
    .param p1, "srcPos"    # I
    .param p2, "dst"    # [B
    .param p3, "dstPos"    # I
    .param p4, "nBytes"    # I

    .prologue
    .line 1358
    if-nez p4, :cond_1

    .line 1370
    :cond_0
    return-object p2

    .line 1361
    :cond_1
    add-int/lit8 v2, p4, -0x1

    mul-int/lit8 v2, v2, 0x8

    add-int/2addr v2, p1

    const/16 v3, 0x10

    if-lt v2, v3, :cond_2

    .line 1362
    new-instance v2, Ljava/lang/IllegalArgumentException;

    const-string v3, "(nBytes-1)*8+srcPos is greather or equal to than 16"

    invoke-direct {v2, v3}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v2

    .line 1365
    :cond_2
    const/4 v1, 0x0

    .line 1366
    .local v1, "shift":I
    const/4 v0, 0x0

    .local v0, "i":I
    :goto_0
    if-ge v0, p4, :cond_0

    .line 1367
    mul-int/lit8 v2, v0, 0x8

    add-int v1, v2, p1

    .line 1368
    add-int v2, p3, v0

    shr-int v3, p0, v1

    and-int/lit16 v3, v3, 0xff

    int-to-byte v3, v3

    aput-byte v3, p2, v2

    .line 1366
    add-int/lit8 v0, v0, 0x1

    goto :goto_0
.end method

.method public static shortToHex(SILjava/lang/String;II)Ljava/lang/String;
    .locals 7
    .param p0, "src"    # S
    .param p1, "srcPos"    # I
    .param p2, "dstInit"    # Ljava/lang/String;
    .param p3, "dstPos"    # I
    .param p4, "nHexs"    # I

    .prologue
    .line 1470
    if-nez p4, :cond_0

    .line 1490
    .end local p2    # "dstInit":Ljava/lang/String;
    :goto_0
    return-object p2

    .line 1473
    .restart local p2    # "dstInit":Ljava/lang/String;
    :cond_0
    add-int/lit8 v5, p4, -0x1

    mul-int/lit8 v5, v5, 0x4

    add-int/2addr v5, p1

    const/16 v6, 0x10

    if-lt v5, v6, :cond_1

    .line 1474
    new-instance v5, Ljava/lang/IllegalArgumentException;

    const-string v6, "(nHexs-1)*4+srcPos is greather or equal to than 16"

    invoke-direct {v5, v6}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v5

    .line 1477
    :cond_1
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3, p2}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    .line 1478
    .local v3, "sb":Ljava/lang/StringBuilder;
    const/4 v4, 0x0

    .line 1479
    .local v4, "shift":I
    invoke-virtual {v3}, Ljava/lang/StringBuilder;->length()I

    move-result v0

    .line 1480
    .local v0, "append":I
    const/4 v2, 0x0

    .local v2, "i":I
    :goto_1
    if-ge v2, p4, :cond_3

    .line 1481
    mul-int/lit8 v5, v2, 0x4

    add-int v4, v5, p1

    .line 1482
    shr-int v5, p0, v4

    and-int/lit8 v1, v5, 0xf

    .line 1483
    .local v1, "bits":I
    add-int v5, p3, v2

    if-ne v5, v0, :cond_2

    .line 1484
    add-int/lit8 v0, v0, 0x1

    .line 1485
    invoke-static {v1}, Lorg/apache/commons/lang3/Conversion;->intToHexDigit(I)C

    move-result v5

    invoke-virtual {v3, v5}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    .line 1480
    :goto_2
    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    .line 1487
    :cond_2
    add-int v5, p3, v2

    invoke-static {v1}, Lorg/apache/commons/lang3/Conversion;->intToHexDigit(I)C

    move-result v6

    invoke-virtual {v3, v5, v6}, Ljava/lang/StringBuilder;->setCharAt(IC)V

    goto :goto_2

    .line 1490
    .end local v1    # "bits":I
    :cond_3
    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    goto :goto_0
.end method

.method public static uuidToByteArray(Ljava/util/UUID;[BII)[B
    .locals 7
    .param p0, "src"    # Ljava/util/UUID;
    .param p1, "dst"    # [B
    .param p2, "dstPos"    # I
    .param p3, "nBytes"    # I

    .prologue
    const/4 v2, 0x0

    const/16 v6, 0x8

    .line 1686
    if-nez p3, :cond_1

    .line 1696
    :cond_0
    :goto_0
    return-object p1

    .line 1689
    :cond_1
    const/16 v0, 0x10

    if-le p3, v0, :cond_2

    .line 1690
    new-instance v0, Ljava/lang/IllegalArgumentException;

    const-string v1, "nBytes is greather than 16"

    invoke-direct {v0, v1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 1692
    :cond_2
    invoke-virtual {p0}, Ljava/util/UUID;->getMostSignificantBits()J

    move-result-wide v0

    if-le p3, v6, :cond_3

    move v5, v6

    :goto_1
    move-object v3, p1

    move v4, p2

    invoke-static/range {v0 .. v5}, Lorg/apache/commons/lang3/Conversion;->longToByteArray(JI[BII)[B

    .line 1693
    if-lt p3, v6, :cond_0

    .line 1694
    invoke-virtual {p0}, Ljava/util/UUID;->getLeastSignificantBits()J

    move-result-wide v0

    add-int/lit8 v4, p2, 0x8

    add-int/lit8 v5, p3, -0x8

    move-object v3, p1

    invoke-static/range {v0 .. v5}, Lorg/apache/commons/lang3/Conversion;->longToByteArray(JI[BII)[B

    goto :goto_0

    :cond_3
    move v5, p3

    .line 1692
    goto :goto_1
.end method
