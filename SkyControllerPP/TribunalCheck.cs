using System;
using Cinematics.Players;
using HarmonyLib;

namespace SkyControllerPP
{
	// Token: 0x0200001A RID: 26
	[HarmonyPatch(typeof(TribunalCinematicPlayer), "Init")]
	internal class TribunalCheck
	{
		// Token: 0x060000A0 RID: 160 RVA: 0x00006CF4 File Offset: 0x00004EF4
		[HarmonyPrefix]
		public static void Prefix()
		{
			bool flag = SkyInfo.Phase != "Court";
			bool flag2 = flag;
			if (flag2)
			{
				SkyInfo.Phase = "Tribunal";
			}
		}
	}
}
