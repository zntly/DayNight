using System;
using Cinematics.Players;
using HarmonyLib;

namespace SkyControllerPP
{
	// Token: 0x02000013 RID: 19
	[HarmonyPatch(typeof(TribunalCinematicPlayer), "Init")]
	internal class TribunalCheck
	{
		// Token: 0x0600005D RID: 93 RVA: 0x000067DC File Offset: 0x000049DC
		[HarmonyPrefix]
		public static void Prefix()
		{
			bool flag = SkyInfo.Phase != "Court";
			if (flag)
			{
				SkyInfo.Phase = "Tribunal";
			}
		}
	}
}
