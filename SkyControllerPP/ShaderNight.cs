using System;
using HarmonyLib;
using SML;
using UnityEngine;

namespace SkyControllerPP
{
	// Token: 0x02000010 RID: 16
	[HarmonyPatch(typeof(GlobalShaderColors), "SetToNight")]
	public class ShaderNight
	{
		// Token: 0x06000062 RID: 98
		[HarmonyPrefix]
		public static void Prefix(GlobalShaderColors __instance)
		{
			SkyInfo.Phase = "Night";
			if (ModSettings.GetString("Jail Cell Shading Mode") == "Night")
			{
				SkyInfo.SkyType skyType = SkyInfo.GetCurrentPermSkyType();
				if (SkyInfo.Phase != "Tribunal" && SkyInfo.Phase != "Court" && SkyInfo.Phase != "Daybreak" && (SkyInfo.Instance.Pest || SkyInfo.Instance.Famine || SkyInfo.Instance.Death || SkyInfo.Instance.War))
				{
					skyType = SkyInfo.GetCurrentApocSkyType();
				}
				if (skyType == SkyInfo.SkyType.None)
				{
					skyType = SkyInfo.GetSyncedSkyType();
				}
				Color skyColor = SkyInfo.GetSkyColor(skyType);
				if (skyColor != JailCellShader.lastcolor)
				{
					JailCellShader.ShadeCell(skyColor);
				}
			}
			SkyInfo.SkyType skyType2 = SkyInfo.GetCurrentPermSkyType();
			if (SkyInfo.Instance.Pest || SkyInfo.Instance.Famine || SkyInfo.Instance.Death || SkyInfo.Instance.War)
			{
				skyType2 = SkyInfo.GetCurrentApocSkyType();
			}
			if (skyType2 == SkyInfo.SkyType.None)
			{
				skyType2 = SkyInfo.GetSyncedSkyType();
			}
			if (SkyInfo.Instance && SkyInfo.CurrentActive == skyType2 && Main.Snowflakes != null)
			{
				if (ModSettings.GetBool("Color Snowflakes to Shader Color"))
				{
					if (Main.Snowflakes.startColor != SkyInfo.GetSkyColor(skyType2))
					{
						Main.Snowflakes.startColor = SkyInfo.GetSkyColor(skyType2);
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
