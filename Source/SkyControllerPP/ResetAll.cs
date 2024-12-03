using System;
using Cinematics.Players;
using HarmonyLib;

namespace SkyControllerPP
{
	// Token: 0x02000019 RID: 25
	[HarmonyPatch(typeof(FactionWinsStandardCinematicPlayer), "Cleanup")]
	internal class ResetAll
	{
		// Token: 0x06000095 RID: 149 RVA: 0x000058E8 File Offset: 0x00003AE8
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
