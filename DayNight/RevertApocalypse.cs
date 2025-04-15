using System;
using Game.Chat.Decoders;
using HarmonyLib;
using Server.Shared.Messages;
using Server.Shared.State;
using Server.Shared.State.Chat;

namespace DayNight
{
    // Token: 0x0200000C RID: 12
    [HarmonyPatch(typeof(WhoDiedRoleDecoder), "Encode")]
    public class RevertApocalypse
    {
        // Token: 0x06000014 RID: 20 RVA: 0x000029AC File Offset: 0x00000BAC
        [HarmonyPostfix]
        public static void Postfix(ChatLogMessage chatLogMessage)
        {
            bool flag = !(SkyInfo.Instance == null);
            bool flag2 = flag;
            if (flag2)
            {
                KillRecord killRecord = ((ChatLogWhoDiedEntry)chatLogMessage.chatLogEntry).killRecord;
                bool flag3 = killRecord != null;
                bool flag4 = flag3;
                if (flag4)
                {
                    switch (killRecord.playerRole)
                    {
                        case Role.BAKER:
                        case Role.FAMINE:
                            int nv = SkyInfo.Instance.Famine - 1;
                            SkyInfo.Instance.Famine = Math.Max(0, nv);
                            break;
                        case Role.BERSERKER:
                        case Role.WAR:
                            int nv2 = SkyInfo.Instance.War - 1;
                            SkyInfo.Instance.War = Math.Max(0, nv2);
                            break;
                        case Role.PLAGUEBEARER:
                        case Role.PESTILENCE:
                            int nv3 = SkyInfo.Instance.Pest - 1;
                            SkyInfo.Instance.Pest = Math.Max(0, nv3);
                            break;
                        case Role.SOULCOLLECTOR:
                        case Role.DEATH:
                            int nv4 = SkyInfo.Instance.Death - 1;
                            SkyInfo.Instance.Death = Math.Max(0, nv4);
                            break;
                    }
                }
            }
        }
    }
}
