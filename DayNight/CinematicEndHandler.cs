using Game.Services;
using HarmonyLib;
using Server.Shared.Cinematics.Data;
using Home.Shared;

namespace DayNight
{
    // Token: 0x02000015 RID: 21
    [HarmonyPatch(typeof(CinematicService), "EndCinematic")]
    public class CinematicEndHandler
    {
        // Token: 0x060000CD RID: 205
        [HarmonyPrefix]
        public static void Prefix()
        {
            if (CinematicHandler.OldPhase != "")
            {
                SkyInfo.Phase = CinematicHandler.OldPhase;
                CinematicHandler.OldPhase = "";
            }
            if (CinematicHandler.DaybreakPhases != null)
            {
                ApplicationController.ApplicationContext.StopCoroutine(CinematicHandler.DaybreakPhases);
                CinematicHandler.DaybreakPhases = null;
            }
        }
    }
}
