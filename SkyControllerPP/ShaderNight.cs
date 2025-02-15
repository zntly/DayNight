using System;
using HarmonyLib;

namespace SkyControllerPP
{
	// Token: 0x0200000E RID: 14
	[HarmonyPatch(typeof(GlobalShaderColors), "SetToNight")]
	public class ShaderNight
	{
		// Token: 0x06000034 RID: 52 RVA: 0x0000424E File Offset: 0x0000244E
		[HarmonyPrefix]
		public static void Prefix(GlobalShaderColors __instance)
		{
			SkyInfo.Phase = "Night";
		}
	}
}
