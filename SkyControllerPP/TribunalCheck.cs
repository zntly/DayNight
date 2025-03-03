using System;
using Cinematics.Players;
using HarmonyLib;

namespace SkyControllerPP
{
	// Token: 0x02000019 RID: 25
	[HarmonyPatch(typeof(TribunalCinematicPlayer), "Init")]
	internal class TribunalCheck
	{
		// Token: 0x06000092 RID: 146 RVA: 0x00006CC0 File Offset: 0x00004EC0
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
