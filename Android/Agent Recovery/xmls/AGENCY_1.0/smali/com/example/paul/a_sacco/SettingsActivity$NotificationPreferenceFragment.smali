.class public Lcom/example/paul/a_sacco/SettingsActivity$NotificationPreferenceFragment;
.super Landroid/preference/PreferenceFragment;
.source "SettingsActivity.java"


# annotations
.annotation build Landroid/annotation/TargetApi;
    value = 0xb
.end annotation

.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/example/paul/a_sacco/SettingsActivity;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x9
    name = "NotificationPreferenceFragment"
.end annotation


# direct methods
.method public constructor <init>()V
    .locals 2

    .prologue
    .line 223
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/SettingsActivity$NotificationPreferenceFragment;
    move-object v1, v0

    invoke-direct {v1}, Landroid/preference/PreferenceFragment;-><init>()V

    return-void
.end method


# virtual methods
.method public onCreate(Landroid/os/Bundle;)V
    .locals 4

    .prologue
    .line 226
    move-object v0, p0

    .local v0, "this":Lcom/example/paul/a_sacco/SettingsActivity$NotificationPreferenceFragment;
    move-object v1, p1

    .local v1, "savedInstanceState":Landroid/os/Bundle;
    move-object v2, v0

    move-object v3, v1

    invoke-super {v2, v3}, Landroid/preference/PreferenceFragment;->onCreate(Landroid/os/Bundle;)V

    .line 227
    move-object v2, v0

    const v3, 0x7f050003

    invoke-virtual {v2, v3}, Lcom/example/paul/a_sacco/SettingsActivity$NotificationPreferenceFragment;->addPreferencesFromResource(I)V

    .line 233
    move-object v2, v0

    const-string v3, "notifications_new_message_ringtone"

    invoke-virtual {v2, v3}, Lcom/example/paul/a_sacco/SettingsActivity$NotificationPreferenceFragment;->findPreference(Ljava/lang/CharSequence;)Landroid/preference/Preference;

    move-result-object v2

    invoke-static {v2}, Lcom/example/paul/a_sacco/SettingsActivity;->access$000(Landroid/preference/Preference;)V

    .line 234
    return-void
.end method
