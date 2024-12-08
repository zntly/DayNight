using System;
using Cinematics.Players;
using HarmonyLib;

namespace SkyControllerPP
{
	// Token: 0x02000017 RID: 23
	[HarmonyPatch(typeof(TribunalCinematicPlayer), "Init")]
	internal class TribunalCheck
	{
		// Token: 0x06000092 RID: 146 RVA: 0x00002351 File Offset: 0x00000551
		[HarmonyPrefix]
		public static void Prefix()
		{
			if (SkyInfo.Phase != "Court")
			{
				SkyInfo.Phase = "Tribunal";
			}
		}
	}
}
