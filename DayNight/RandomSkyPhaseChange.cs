using System;
using Game.Simulation;
using HarmonyLib;
using Server.Shared.Extensions;
using Server.Shared.Info;

namespace DayNight
{
    // Token: 0x0200001F RID: 31
    [HarmonyPatch(typeof(GameSimulation), "HandleOnGameInfoChanged")]
    public class RandomSkyPhaseChange
    {
        // Token: 0x060000C3 RID: 195 RVA: 0x00008854 File Offset: 0x00006A54
        [HarmonyPostfix]
        public static void Postfix(GameInfo gameInfo)
        {
            if ((string)Settings.SettingsCache.GetValue("Random Sky Mode", null) == "Phase Change" && SkyInfo.Instance)
            {
                Settings.SettingsCache.SetValue("Current Random Sky", SkyInfo.Instance.RandomSkyTypeAsString());
                if (Leo.IsHomeScene())
                {
                    SkyInfo.Instance.UpdateSky();
                }
            }
        }
    }
}
