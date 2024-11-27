using System;
using Cinematics.Players;
using HarmonyLib;
using Server.Shared.Cinematics.Data;

namespace SkyControllerPP
{
	// Token: 0x0200001A RID: 26
	[HarmonyPatch(typeof(FactionWinsStandardCinematicPlayer), "Cleanup")]
	internal class ResetAll
	{
		// Token: 0x0600009C RID: 156
		[HarmonyPrefix]
		public static void Prefix(ICinematicData cinematicData)
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
