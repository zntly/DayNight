using System;
using HarmonyLib;

namespace SkyControllerPP
{
	// Token: 0x02000015 RID: 21
	[HarmonyPatch(typeof(GlobalShaderColors), "SetToDay")]
	public class ShaderDay
	{
		// Token: 0x06000096 RID: 150 RVA: 0x0000231D File Offset: 0x0000051D
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
