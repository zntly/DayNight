using System;
using Cinematics.Players;
using HarmonyLib;

namespace SkyControllerPP
{
	// Token: 0x02000017 RID: 23
	[HarmonyPatch(typeof(TribunalCinematicPlayer), "Init")]
	internal class TribunalCheck
	{
		// Token: 0x06000090 RID: 144 RVA: 0x0000235C File Offset: 0x0000055C
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
