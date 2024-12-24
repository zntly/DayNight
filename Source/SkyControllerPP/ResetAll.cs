using System;
using Game.Simulation;
using HarmonyLib;
using Server.Shared.Info;
using Server.Shared.State;

namespace SkyControllerPP
{
	// Token: 0x0200001A RID: 26
	[HarmonyPatch(typeof(GameSimulation), "HandleOnGameInfoChanged")]
	internal class ResetAll
	{
		// Token: 0x0600009E RID: 158 RVA: 0x00006478 File Offset: 0x00004678
		[HarmonyPrefix]
		public static void Prefix(GameInfo gameInfo)
		{
			if (gameInfo.gamePhase == GamePhase.RESULTS)
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
