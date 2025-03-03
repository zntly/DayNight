using System;
using HarmonyLib;

namespace SkyControllerPP
{
	// Token: 0x02000010 RID: 16
	[HarmonyPatch(typeof(GlobalShaderColors), "SetToNight")]
	public class ShaderNight
	{
		// Token: 0x06000057 RID: 87 RVA: 0x000020E3 File Offset: 0x000002E3
		[HarmonyPrefix]
		public static void Prefix(GlobalShaderColors __instance)
		{
			SkyInfo.Phase = "Night";
		}
	}
}
