.class public Lcom/example/paul/a_sacco/SettingsActivity;
.super Landroid/preference/PreferenceActivity;
.source "SettingsActivity.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/example/paul/a_sacco/SettingsActivity$DataSyncPreferenceFragment;,
        Lcom/example/paul/a_sacco/SettingsActivity$NotificationPreferenceFragment;,
        Lcom/example/paul/a_sacco/SettingsActivity$GeneralPreferenceFragment;
    }
.end annotation


# static fields
.field private static final ALWAYS_SIMPLE_PREFS:Z

.field private static sBindPreferenceSummaryToValueListener:Landroid/preference/Preference$OnPreferenceChangeListener;


# direct methods
.method static constructor <clinit>()V
    .locals 3

    .prologue
    .line 129
    new-instance v0, Lcom/example/paul/a_sacco/SettingsActivity$1;

    move-object v2, v0

    move-object v0, v2

    move-object v1, v2

    invoke-direct {v1}, Lcom/example/paul/a_sacco/SettingsActivity$1;-><init>()V

    sput-object v0, Lcom/example/paul/a_sacco/SettingsActivity;->sBindPreferenceSummaryToValueListener:Landroid/preference/Preference$OnPreferenceChangeListener;

    return-void
.end method

.method public constructor <init>()V
    .locals 2

    .prologue
    .line 34
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/SettingsActivity;
    move-object v1, v0

    invoke-direct {v1}, Landroid/preference/PreferenceActivity;-><init>()V

    .line 241
    return-void
.end method

.method static synthetic access$000(Landroid/preference/Preference;)V
    .locals 2

    .prologue
    .line 34
    move-object v0, p0

    .local v0, "x0":Landroid/preference/Preference;
    move-object v1, v0

    invoke-static {v1}, Lcom/example/paul/a_sacco/SettingsActivity;->bindPreferenceSummaryToValue(Landroid/preference/Preference;)V

    return-void
.end method

.method private static bindPreferenceSummaryToValue(Landroid/preference/Preference;)V
    .locals 6

    .prologue
    .line 188
    move-object v0, p0

    .local v0, "preference":Landroid/preference/Preference;
    move-object v1, v0

    sget-object v2, Lcom/example/paul/a_sacco/SettingsActivity;->sBindPreferenceSummaryToValueListener:Landroid/preference/Preference$OnPreferenceChangeListener;

    invoke-virtual {v1, v2}, Landroid/preference/Preference;->setOnPreferenceChangeListener(Landroid/preference/Preference$OnPreferenceChangeListener;)V

    .line 192
    sget-object v1, Lcom/example/paul/a_sacco/SettingsActivity;->sBindPreferenceSummaryToValueListener:Landroid/preference/Preference$OnPreferenceChangeListener;

    move-object v2, v0

    move-object v3, v0

    invoke-virtual {v3}, Landroid/preference/Preference;->getContext()Landroid/content/Context;

    move-result-object v3

    invoke-static {v3}, Landroid/preference/PreferenceManager;->getDefaultSharedPreferences(Landroid/content/Context;)Landroid/content/SharedPreferences;

    move-result-object v3

    move-object v4, v0

    invoke-virtual {v4}, Landroid/preference/Preference;->getKey()Ljava/lang/String;

    move-result-object v4

    const-string v5, ""

    invoke-interface {v3, v4, v5}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-interface {v1, v2, v3}, Landroid/preference/Preference$OnPreferenceChangeListener;->onPreferenceChange(Landroid/preference/Preference;Ljava/lang/Object;)Z

    move-result v1

    .line 196
    return-void
.end method

.method private static isSimplePreferences(Landroid/content/Context;)Z
    .locals 3

    .prologue
    .line 111
    move-object v0, p0

    .local v0, "context":Landroid/content/Context;
    sget v1, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v2, 0xb

    if-lt v1, v2, :cond_0

    move-object v1, v0

    invoke-static {v1}, Lcom/example/paul/a_sacco/SettingsActivity;->isXLargeTablet(Landroid/content/Context;)Z

    move-result v1

    if-nez v1, :cond_1

    :cond_0
    const/4 v1, 0x1

    :goto_0
    move v0, v1

    .end local v0    # "context":Landroid/content/Context;
    return v0

    .restart local v0    # "context":Landroid/content/Context;
    :cond_1
    const/4 v1, 0x0

    goto :goto_0
.end method

.method private static isXLargeTablet(Landroid/content/Context;)Z
    .locals 3

    .prologue
    .line 99
    move-object v0, p0

    .local v0, "context":Landroid/content/Context;
    move-object v1, v0

    invoke-virtual {v1}, Landroid/content/Context;->getResources()Landroid/content/res/Resources;

    move-result-object v1

    invoke-virtual {v1}, Landroid/content/res/Resources;->getConfiguration()Landroid/content/res/Configuration;

    move-result-object v1

    iget v1, v1, Landroid/content/res/Configuration;->screenLayout:I

    const/16 v2, 0xf

    and-int/lit8 v1, v1, 0xf

    const/4 v2, 0x4

    if-lt v1, v2, :cond_0

    const/4 v1, 0x1

    :goto_0
    move v0, v1

    .end local v0    # "context":Landroid/content/Context;
    return v0

    .restart local v0    # "context":Landroid/content/Context;
    :cond_0
    const/4 v1, 0x0

    goto :goto_0
.end method

.method private setupSimplePreferencesScreen()V
    .locals 3

    .prologue
    .line 57
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/SettingsActivity;
    move-object v1, v0

    invoke-static {v1}, Lcom/example/paul/a_sacco/SettingsActivity;->isSimplePreferences(Landroid/content/Context;)Z

    move-result v1

    if-nez v1, :cond_0

    .line 58
    .line 86
    :goto_0
    return-void

    .line 65
    :cond_0
    move-object v1, v0

    const v2, 0x7f050001

    invoke-virtual {v1, v2}, Lcom/example/paul/a_sacco/SettingsActivity;->addPreferencesFromResource(I)V

    .line 82
    move-object v1, v0

    const-string v2, "Agency_Code"

    invoke-virtual {v1, v2}, Lcom/example/paul/a_sacco/SettingsActivity;->findPreference(Ljava/lang/CharSequence;)Landroid/preference/Preference;

    move-result-object v1

    invoke-static {v1}, Lcom/example/paul/a_sacco/SettingsActivity;->bindPreferenceSummaryToValue(Landroid/preference/Preference;)V

    .line 86
    goto :goto_0
.end method


# virtual methods
.method public onBuildHeaders(Ljava/util/List;)V
    .locals 5
    .annotation build Landroid/annotation/TargetApi;
        value = 0xb
    .end annotation

    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List",
            "<",
            "Landroid/preference/PreferenceActivity$Header;",
            ">;)V"
        }
    .end annotation

    .prologue
    .line 120
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/SettingsActivity;
    move-object v1, p1

    .local v1, "target":Ljava/util/List;, "Ljava/util/List<Landroid/preference/PreferenceActivity$Header;>;"
    move-object v2, v0

    invoke-static {v2}, Lcom/example/paul/a_sacco/SettingsActivity;->isSimplePreferences(Landroid/content/Context;)Z

    move-result v2

    if-nez v2, :cond_0

    .line 121
    move-object v2, v0

    const v3, 0x7f050002

    move-object v4, v1

    invoke-virtual {v2, v3, v4}, Lcom/example/paul/a_sacco/SettingsActivity;->loadHeadersFromResource(ILjava/util/List;)V

    .line 123
    :cond_0
    return-void
.end method

.method public onIsMultiPane()Z
    .locals 2

    .prologue
    .line 91
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/SettingsActivity;
    move-object v1, v0

    invoke-static {v1}, Lcom/example/paul/a_sacco/SettingsActivity;->isXLargeTablet(Landroid/content/Context;)Z

    move-result v1

    if-eqz v1, :cond_0

    move-object v1, v0

    invoke-static {v1}, Lcom/example/paul/a_sacco/SettingsActivity;->isSimplePreferences(Landroid/content/Context;)Z

    move-result v1

    if-nez v1, :cond_0

    const/4 v1, 0x1

    :goto_0
    move v0, v1

    .end local v0    # "this":Lcom/example/paul/a_sacco/SettingsActivity;
    return v0

    .restart local v0    # "this":Lcom/example/paul/a_sacco/SettingsActivity;
    :cond_0
    const/4 v1, 0x0

    goto :goto_0
.end method

.method protected onPostCreate(Landroid/os/Bundle;)V
    .locals 4

    .prologue
    .line 46
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/SettingsActivity;
    move-object v1, p1

    .local v1, "savedInstanceState":Landroid/os/Bundle;
    move-object v2, v0

    move-object v3, v1

    invoke-super {v2, v3}, Landroid/preference/PreferenceActivity;->onPostCreate(Landroid/os/Bundle;)V

    .line 48
    move-object v2, v0

    invoke-direct {v2}, Lcom/example/paul/a_sacco/SettingsActivity;->setupSimplePreferencesScreen()V

    .line 49
    return-void
.end method
