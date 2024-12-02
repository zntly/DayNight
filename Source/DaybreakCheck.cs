using System;
using BetterTOS2;
using Game.Simulation;
using HarmonyLib;
using Server.Shared.Messages;
using Server.Shared.State;
using SML;

namespace SkyControllerPP
{
	// Token: 0x02000019 RID: 25
	[HarmonyPatch(typeof(GameSimulation), "HandlePlayCinematic")]
	public class DaybreakCheck
	{
		// Token: 0x0600009A RID: 154 RVA: 0x00002396 File Offset: 0x00000596
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
