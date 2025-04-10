using System;
using Game.Simulation;
using HarmonyLib;
using Server.Shared.Info;
using Server.Shared.State;

namespace DayNight
{
	// Token: 0x0200000B RID: 11
	[HarmonyPatch(typeof(GameSimulation), "HandleOnGameInfoChanged")]
	internal class ResetAll
	{
		// Token: 0x06000012 RID: 18 RVA: 0x0000294C File Offset: 0x00000B4C
		[HarmonyPrefix]
		public static void Prefix(GameInfo gameInfo)
		{
			bool flag = gameInfo.gamePhase == GamePhase.RESULTS;
			bool flag2 = flag;
			if (flag2)
			{
				SkyInfo.Instance.Pest = 0;
				SkyInfo.Instance.War = 0;
				SkyInfo.Instance.Famine = 0;
				SkyInfo.Instance.Death = 0;
				SkyInfo.Phase = "Day";
				SkyInfo.Instance.UpdateSky();
			}
		}
	}
}
