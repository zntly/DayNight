using System;
using HarmonyLib;

namespace SkyControllerPP
{
	// Token: 0x02000010 RID: 16
	[HarmonyPatch(typeof(GlobalShaderColors), "SetToNight")]
	public class ShaderNight
	{
		// Token: 0x0600005F RID: 95 RVA: 0x000020DE File Offset: 0x000002DE
		[HarmonyPrefix]
		public static void Prefix(GlobalShaderColors __instance)
		{
			SkyInfo.Phase = "Night";
		}
	}
}
