using System;
using Game.Simulation;
using HarmonyLib;
using Server.Shared.Info;
using Server.Shared.State;

namespace SkyControllerPP
{
	// Token: 0x0200000A RID: 10
	[HarmonyPatch(typeof(GameSimulation), "HandleOnGameInfoChanged")]
	internal class ResetAll
	{
		// Token: 0x0600000E RID: 14 RVA: 0x0000256C File Offset: 0x0000076C
		[HarmonyPrefix]
		public static void Prefix(GameInfo gameInfo)
		{
			bool flag = gameInfo.gamePhase == GamePhase.RESULTS;
			if (flag)
			{
				SkyInfo.Instance.Pest = false;
				SkyInfo.Instance.War = false;
				SkyInfo.Instance.Famine = false;
				SkyInfo.Instance.Death = false;
				SkyInfo.Phase = "Day";
				SkyInfo.Instance.UpdateSky();
			}
		}
	}
}
