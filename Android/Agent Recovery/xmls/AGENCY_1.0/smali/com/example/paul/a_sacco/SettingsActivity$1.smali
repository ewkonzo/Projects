.class final Lcom/example/paul/a_sacco/SettingsActivity$1;
.super Ljava/lang/Object;
.source "SettingsActivity.java"

# interfaces
.implements Landroid/preference/Preference$OnPreferenceChangeListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/example/paul/a_sacco/SettingsActivity;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x8
    name = null
.end annotation


# direct methods
.method constructor <init>()V
    .locals 2

    .prologue
    .line 129
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/SettingsActivity$1;
    move-object v1, v0

    invoke-direct {v1}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onPreferenceChange(Landroid/preference/Preference;Ljava/lang/Object;)Z
    .locals 9

    .prologue
    .line 132
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/SettingsActivity$1;
    move-object v1, p1

    .local v1, "preference":Landroid/preference/Preference;
    move-object v2, p2

    .local v2, "value":Ljava/lang/Object;
    move-object v6, v2

    invoke-virtual {v6}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v6

    move-object v3, v6

    .line 134
    .local v3, "stringValue":Ljava/lang/String;
    move-object v6, v1

    instance-of v6, v6, Landroid/preference/ListPreference;

    if-eqz v6, :cond_1

    .line 137
    move-object v6, v1

    check-cast v6, Landroid/preference/ListPreference;

    move-object v4, v6

    .line 138
    .local v4, "listPreference":Landroid/preference/ListPreference;
    move-object v6, v4

    move-object v7, v3

    invoke-virtual {v6, v7}, Landroid/preference/ListPreference;->findIndexOfValue(Ljava/lang/String;)I

    move-result v6

    move v5, v6

    .line 141
    .local v5, "index":I
    move-object v6, v1

    move v7, v5

    if-ltz v7, :cond_0

    move-object v7, v4

    invoke-virtual {v7}, Landroid/preference/ListPreference;->getEntries()[Ljava/lang/CharSequence;

    move-result-object v7

    move v8, v5

    aget-object v7, v7, v8

    :goto_0
    invoke-virtual {v6, v7}, Landroid/preference/Preference;->setSummary(Ljava/lang/CharSequence;)V

    .line 146
    .line 173
    .end local v4    # "listPreference":Landroid/preference/ListPreference;
    .end local v5    # "index":I
    :goto_1
    const/4 v6, 0x1

    move v0, v6

    .end local v0    # "this":Lcom/example/paul/a_sacco/SettingsActivity$1;
    return v0

    .line 141
    .restart local v0    # "this":Lcom/example/paul/a_sacco/SettingsActivity$1;
    .restart local v4    # "listPreference":Landroid/preference/ListPreference;
    .restart local v5    # "index":I
    :cond_0
    const/4 v7, 0x0

    goto :goto_0

    .line 146
    .end local v4    # "listPreference":Landroid/preference/ListPreference;
    .end local v5    # "index":I
    :cond_1
    move-object v6, v1

    instance-of v6, v6, Landroid/preference/RingtonePreference;

    if-eqz v6, :cond_4

    .line 149
    move-object v6, v3

    invoke-static {v6}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v6

    if-eqz v6, :cond_2

    .line 151
    move-object v6, v1

    const v7, 0x7f0c002b

    invoke-virtual {v6, v7}, Landroid/preference/Preference;->setSummary(I)V

    goto :goto_1

    .line 154
    :cond_2
    move-object v6, v1

    invoke-virtual {v6}, Landroid/preference/Preference;->getContext()Landroid/content/Context;

    move-result-object v6

    move-object v7, v3

    invoke-static {v7}, Landroid/net/Uri;->parse(Ljava/lang/String;)Landroid/net/Uri;

    move-result-object v7

    invoke-static {v6, v7}, Landroid/media/RingtoneManager;->getRingtone(Landroid/content/Context;Landroid/net/Uri;)Landroid/media/Ringtone;

    move-result-object v6

    move-object v4, v6

    .line 157
    .local v4, "ringtone":Landroid/media/Ringtone;
    move-object v6, v4

    if-nez v6, :cond_3

    .line 159
    move-object v6, v1

    const/4 v7, 0x0

    invoke-virtual {v6, v7}, Landroid/preference/Preference;->setSummary(Ljava/lang/CharSequence;)V

    .line 166
    :goto_2
    goto :goto_1

    .line 163
    :cond_3
    move-object v6, v4

    move-object v7, v1

    invoke-virtual {v7}, Landroid/preference/Preference;->getContext()Landroid/content/Context;

    move-result-object v7

    invoke-virtual {v6, v7}, Landroid/media/Ringtone;->getTitle(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v6

    move-object v5, v6

    .line 164
    .local v5, "name":Ljava/lang/String;
    move-object v6, v1

    move-object v7, v5

    invoke-virtual {v6, v7}, Landroid/preference/Preference;->setSummary(Ljava/lang/CharSequence;)V

    goto :goto_2

    .line 171
    .end local v4    # "ringtone":Landroid/media/Ringtone;
    .end local v5    # "name":Ljava/lang/String;
    :cond_4
    move-object v6, v1

    move-object v7, v3

    invoke-virtual {v6, v7}, Landroid/preference/Preference;->setSummary(Ljava/lang/CharSequence;)V

    goto :goto_1
.end method
