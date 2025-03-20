using System;
using HarmonyLib;
using Server.Shared.Extensions;
using UnityEngine;

namespace SkyControllerPP
{
	// Token: 0x02000012 RID: 18
	[HarmonyPatch(typeof(GlobalShaderColors), "SetToNight")]
	public class ShaderNight
	{
		// Token: 0x06000074 RID: 116
		[HarmonyPrefix]
		public static void Prefix(GlobalShaderColors __instance)
		{
			SkyInfo.Phase = "Night";
			if ((string)Settings.SettingsCache.GetValue("Jail Cell Shading Mode", null) == "Night")
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
				if (skyType == SkyInfo.SkyType.Random)
				{
					skyType = (SkyInfo.SkyType)Enum.Parse(typeof(SkyInfo.SkyType), (string)Settings.SettingsCache.GetValue("Current Random Sky", null));
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
			if (skyType2 == SkyInfo.SkyType.Random)
			{
				skyType2 = (SkyInfo.SkyType)Enum.Parse(typeof(SkyInfo.SkyType), (string)Settings.SettingsCache.GetValue("Current Random Sky", null));
			}
			if (SkyInfo.Instance && SkyInfo.CurrentActive == skyType2 && Main.Snowflakes != null)
			{
				if ((bool)Settings.SettingsCache.GetValue("Color Snowflakes to Shader Color", null))
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
