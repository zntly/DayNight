using System;
using Game.Simulation;
using HarmonyLib;
using Server.Shared.Messages;
using Server.Shared.State;

namespace SkyControllerPP
{
	// Token: 0x02000019 RID: 25
	[HarmonyPatch(typeof(GameSimulation), "HandlePlayCinematic")]
	public class DaybreakCheck
	{
		// Token: 0x0600009C RID: 156 RVA: 0x0000239E File Offset: 0x0000059E
		[HarmonyPrefix]
		public static void Prefix(GameSimulation __instance, PlayCinematicMessage message)
		{
			if (Utils.IsBTOS2() && message.cinematicEntry.GetData().cinematicType == (CinematicType)100)
			{
				SkyInfo.Phase = "Daybreak";
			}
		}
	}
}
