using System;
using HarmonyLib;

namespace SkyControllerPP
{
	// Token: 0x02000016 RID: 22
	[HarmonyPatch(typeof(GlobalShaderColors), "SetToNight")]
	public class ShaderNight
	{
		// Token: 0x06000098 RID: 152 RVA: 0x0000235C File Offset: 0x0000055C
		[HarmonyPrefix]
		public static void Prefix(GlobalShaderColors __instance)
		{
			SkyInfo.Phase = "Night";
		}
	}
}
