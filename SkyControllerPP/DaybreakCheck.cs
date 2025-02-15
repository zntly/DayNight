﻿using System;
using Game.Simulation;
using HarmonyLib;
using Server.Shared.Messages;
using Server.Shared.State;

namespace SkyControllerPP
{
	// Token: 0x02000005 RID: 5
	[HarmonyPatch(typeof(GameSimulation), "HandlePlayCinematic")]
	public class DaybreakCheck
	{
		// Token: 0x06000005 RID: 5 RVA: 0x00002148 File Offset: 0x00000348
		[HarmonyPrefix]
		public static void Prefix(GameSimulation __instance, PlayCinematicMessage message)
		{
			bool flag = Utils.IsBTOS2() && message.cinematicEntry.GetData().cinematicType == (CinematicType)100;
			if (flag)
			{
				SkyInfo.Phase = "Daybreak";
			}
		}
	}
}
