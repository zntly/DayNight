using System;
using HarmonyLib;

namespace SkyControllerPP
{
	// Token: 0x0200000D RID: 13
	[HarmonyPatch(typeof(GlobalShaderColors), "SetToDay")]
	public class ShaderDay
	{
		// Token: 0x06000032 RID: 50 RVA: 0x000041FC File Offset: 0x000023FC
		[HarmonyPrefix]
		public static void Prefix(GlobalShaderColors __instance)
		{
			bool flag = SkyInfo.Phase != "Tribunal" && SkyInfo.Phase != "Court" && SkyInfo.Phase != "Daybreak";
			if (flag)
			{
				SkyInfo.Phase = "Day";
			}
		}
	}
}
