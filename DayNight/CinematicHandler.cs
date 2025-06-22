using Game.Services;
using HarmonyLib;
using Server.Shared.Cinematics.Data;
using Server.Shared.State;
using Server.Shared.Extensions;
using UnityEngine;
using System.Collections.Generic;
using Home.Shared;

namespace DayNight
{
    // Token: 0x02000015 RID: 21
    [HarmonyPatch(typeof(CinematicService), "StartCinematic")]
    public class CinematicHandler
    {
        // Token: 0x060000CD RID: 205
        [HarmonyPostfix]
        public static void Postfix(ref ICinematicData cinematic)
        {
            CinematicType cinematicType = cinematic.cinematicType;
            if (cinematicType == CinematicType.MarshalTribunal && SkyInfo.Phase != "Court" && SkyInfo.Phase != "Daybreak")
            {
                SkyInfo.Phase = "Tribunal";
            }
            else if (cinematicType == CinematicType.TownWins)
            {
                CinematicHandler.OldPhase = SkyInfo.Phase;
                SkyInfo.Phase = "Day";
            }
            else if (cinematicType == CinematicType.ArsonistsWins || cinematicType == CinematicType.WerewolvesWin || cinematicType == CinematicType.FactionWins)
            {
                CinematicHandler.OldPhase = SkyInfo.Phase;
                SkyInfo.Phase = "Night";
            }
            else if (Utils.IsBTOS2() && cinematicType == (CinematicType)101)
            {
                CinematicHandler.OldPhase = SkyInfo.Phase;
                CinematicHandler.DaybreakPhases = CinematicHandler.DaybreakCoroutine();
                ApplicationController.ApplicationContext.StartCoroutine(CinematicHandler.DaybreakPhases);
            }
        }
        public static IEnumerator<WaitForSeconds> DaybreakCoroutine()
        {
            SkyInfo.Phase = "Night";
            yield return new WaitForSeconds(5.5f);
            SkyInfo.Phase = "Daybreak";
            yield break;
        }

        public static IEnumerator<WaitForSeconds> DaybreakPhases;

        public static string OldPhase = "";
    }
}
