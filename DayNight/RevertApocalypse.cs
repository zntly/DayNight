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
            if (flag2 && !ApocalypseSwap.processedList.Contains(chatLogMessage))
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
                            ApocalypseSwap.processedList.Add(chatLogMessage);
                            SkyInfo.Instance.Famine -= 1;
                            if (SkyInfo.Instance.Famine < 0)
                                SkyInfo.Instance.Famine = 0;
                            break;
                        case Role.BERSERKER:
                        case Role.WAR:
                            ApocalypseSwap.processedList.Add(chatLogMessage);
                            SkyInfo.Instance.War -= 1;
                            if (SkyInfo.Instance.War < 0)
                                SkyInfo.Instance.War = 0;
                            break;
                        case Role.PLAGUEBEARER:
                        case Role.PESTILENCE:
                            ApocalypseSwap.processedList.Add(chatLogMessage);
                            SkyInfo.Instance.Pest -= 1;
                            if (SkyInfo.Instance.Pest < 0)
                                SkyInfo.Instance.Pest = 0;
                            break;
                        case Role.SOULCOLLECTOR:
                        case Role.DEATH:
                            ApocalypseSwap.processedList.Add(chatLogMessage);
                            SkyInfo.Instance.Death -= 1;
                            if (SkyInfo.Instance.Death < 0)
                                SkyInfo.Instance.Death = 0;
                            break;
                    }
                }
            }
        }
    }
}
