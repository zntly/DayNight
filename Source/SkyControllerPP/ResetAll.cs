using System;
using Cinematics.Players;
using HarmonyLib;

namespace SkyControllerPP
{
	// Token: 0x0200001A RID: 26
	[HarmonyPatch(typeof(FactionWinsStandardCinematicPlayer), "Init")]
	internal class ResetAll
	{
		// Token: 0x0600009B RID: 155 RVA: 0x000058C8 File Offset: 0x00003AC8
		[HarmonyPrefix]
		public static void Prefix()
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
