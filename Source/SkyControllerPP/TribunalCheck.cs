using System;
using Cinematics.Players;
using HarmonyLib;

namespace SkyControllerPP
{
	// Token: 0x02000018 RID: 24
	[HarmonyPatch(typeof(TribunalCinematicPlayer), "Init")]
	internal class TribunalCheck
	{
		// Token: 0x06000099 RID: 153 RVA: 0x00002381 File Offset: 0x00000581
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
