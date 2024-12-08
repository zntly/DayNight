using System;
using HarmonyLib;

namespace SkyControllerPP
{
	// Token: 0x02000014 RID: 20
	[HarmonyPatch(typeof(GlobalShaderColors), "SetToDay")]
	public class ShaderDay
	{
		// Token: 0x0600008D RID: 141 RVA: 0x00002306 File Offset: 0x00000506
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
