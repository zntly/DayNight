using System;
using HarmonyLib;

namespace SkyControllerPP
{
	// Token: 0x0200000F RID: 15
	[HarmonyPatch(typeof(GlobalShaderColors), "SetToDay")]
	public class ShaderDay
	{
		// Token: 0x0600005D RID: 93 RVA: 0x00004918 File Offset: 0x00002B18
		[HarmonyPrefix]
		public static void Prefix(GlobalShaderColors __instance)
		{
			bool flag = SkyInfo.Phase != "Tribunal" && SkyInfo.Phase != "Court" && SkyInfo.Phase != "Daybreak";
			bool flag2 = flag;
			if (flag2)
			{
				SkyInfo.Phase = "Day";
			}
		}
	}
}
