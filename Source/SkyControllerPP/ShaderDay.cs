using System;
using HarmonyLib;

namespace SkyControllerPP
{
	// Token: 0x02000015 RID: 21
	[HarmonyPatch(typeof(GlobalShaderColors), "SetToDay")]
	public class ShaderDay
	{
		// Token: 0x06000091 RID: 145 RVA: 0x00002328 File Offset: 0x00000528
		[HarmonyPrefix]
		public static void Prefix(GlobalShaderColors __instance)
		{
			if (SkyInfo.Phase != "Tribunal" && SkyInfo.Phase != "Court" && SkyInfo.Phase != "Daybreak")
			{
				SkyInfo.Phase = "Day";
			}
		}
	}
}
