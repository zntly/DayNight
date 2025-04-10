using System;
using HarmonyLib;
using Server.Shared.Extensions;
using UnityEngine;

namespace DayNight
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
			SkyInfo.SkyType skyType = SkyInfo.GetCurrentPermSkyType();
			if (SkyInfo.Phase != "Tribunal" && SkyInfo.Phase != "Court" && SkyInfo.Phase != "Daybreak" && Utils.ApocCheck())
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
			if ((string)Settings.SettingsCache.GetValue("Jail Cell Shading Mode", null) == "Night")
			{
				Color skyColor = SkyInfo.GetSkyColor(skyType);
				if (skyColor != JailCellShader.lastcolor)
				{
					JailCellShader.ShadeCell(skyColor);
				}
			}
			if (SkyInfo.Instance && SkyInfo.CurrentActive == skyType && Main.Snowflakes != null)
			{
				Color intendedColor = (bool)Settings.SettingsCache.GetValue("Color Snowflakes to Shader Color", null) ?
					SkyInfo.GetSkyColor(skyType) : Color.white;

				if (Main.Snowflakes.startColor != intendedColor)
				{
					Main.Snowflakes.startColor = intendedColor;
					Main.Snowflakes.Clear();
					Main.Snowflakes.Emit(250);
				}
			}
		}
	}
}
