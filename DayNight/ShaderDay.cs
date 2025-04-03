using System;
using HarmonyLib;
using Server.Shared.Extensions;
using UnityEngine;

namespace DayNight
{
	// Token: 0x02000011 RID: 17
	[HarmonyPatch(typeof(GlobalShaderColors), "SetToDay")]
	public class ShaderDay
	{
		// Token: 0x06000072 RID: 114
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
				if (skyType == SkyInfo.SkyType.Random)
				{
					skyType = (SkyInfo.SkyType)Enum.Parse(typeof(SkyInfo.SkyType), (string)Settings.SettingsCache.GetValue("Current Random Sky", null));
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
}
