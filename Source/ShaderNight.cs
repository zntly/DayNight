using System;
using HarmonyLib;

namespace SkyControllerPP
{
	// Token: 0x02000016 RID: 22
	[HarmonyPatch(typeof(GlobalShaderColors), "SetToNight")]
	public class ShaderNight
	{
		// Token: 0x06000093 RID: 147 RVA: 0x0000236D File Offset: 0x0000056D
		[HarmonyPrefix]
		public static void Prefix(GlobalShaderColors __instance)
		{
			SkyInfo.Phase = "Night";
		}
	}
}
