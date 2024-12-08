using System;
using Game.Simulation;
using HarmonyLib;
using Server.Shared.Messages;
using Server.Shared.State;

namespace SkyControllerPP
{
	// Token: 0x02000018 RID: 24
	[HarmonyPatch(typeof(GameSimulation), "HandlePlayCinematic")]
	public class DaybreakCheck
	{
		// Token: 0x06000095 RID: 149 RVA: 0x0000236E File Offset: 0x0000056E
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
