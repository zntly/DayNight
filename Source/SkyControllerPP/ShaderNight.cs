using System;
using HarmonyLib;

namespace SkyControllerPP
{
	// Token: 0x02000015 RID: 21
	[HarmonyPatch(typeof(GlobalShaderColors), "SetToNight")]
	public class ShaderNight
	{
		// Token: 0x0600008F RID: 143 RVA: 0x00002345 File Offset: 0x00000545
		[HarmonyPrefix]
		public static void Prefix(GlobalShaderColors __instance)
		{
			SkyInfo.Phase = "Night";
		}
	}
}
