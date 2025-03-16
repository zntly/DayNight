using System;
using HarmonyLib;
using SML;
using UnityEngine;

namespace SkyControllerPP
{
	// Token: 0x0200000F RID: 15
	[HarmonyPatch(typeof(GlobalShaderColors), "SetToDay")]
	public class ShaderDay
	{
		// Token: 0x06000060 RID: 96
		[HarmonyPrefix]
		public static void Prefix(GlobalShaderColors __instance)
		{
			if (SkyInfo.Phase != "Tribunal" && SkyInfo.Phase != "Court" && SkyInfo.Phase != "Daybreak")
			{
				SkyInfo.Phase = "Day";
				SkyInfo.SkyType skyType = SkyInfo.GetCurrentPermSkyType();
				if (SkyInfo.Instance.Pest || SkyInfo.Instance.Famine || SkyInfo.Instance.Death || SkyInfo.Instance.War)
				{
					skyType = SkyInfo.GetCurrentApocSkyType();
				}
				if (skyType == SkyInfo.SkyType.None)
				{
					skyType = SkyInfo.GetSyncedSkyType();
				}
				if (SkyInfo.Instance && SkyInfo.CurrentActive == skyType && Main.Snowflakes != null)
				{
					if (ModSettings.GetBool("Color Snowflakes to Shader Color"))
					{
						if (Main.Snowflakes.startColor != SkyInfo.GetSkyColor(skyType))
						{
							Main.Snowflakes.startColor = SkyInfo.GetSkyColor(skyType);
							Main.Snowflakes.Clear();
							Main.Snowflakes.Emit(250);
							return;
						}
					}
					else if (Main.Snowflakes.startColor != Color.white)
					{
						Main.Snowflakes.startColor = Color.white;
						Main.Snowflakes.Clear();
						Main.Snowflakes.Emit(250);
					}
				}
			}
		}
	}
}
