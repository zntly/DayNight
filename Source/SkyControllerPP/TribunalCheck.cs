using System;
using Cinematics.Players;
using HarmonyLib;

namespace SkyControllerPP
{
	// Token: 0x02000018 RID: 24
	[HarmonyPatch(typeof(TribunalCinematicPlayer), "Init")]
	internal class TribunalCheck
	{
		// Token: 0x06000097 RID: 151 RVA: 0x00002373 File Offset: 0x00000573
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
