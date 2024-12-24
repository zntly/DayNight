using System;
using HarmonyLib;
using Services;

namespace SkyControllerPP
{
	// Token: 0x02000016 RID: 22
	[HarmonyPatch(typeof(GlobalShaderColors), "SetToNight")]
	public class ShaderNight
	{
		// Token: 0x06000096 RID: 150 RVA: 0x0000235C File Offset: 0x0000055C
		[HarmonyPrefix]
		public static void Prefix(GlobalShaderColors __instance)
		{
			SkyInfo.Phase = "Night";
			Service.Game.Sim.simulation.SetDeathNote("some test death note that logically shouldn't be shown because this role does not have a death note");
		}
	}
}
