using System;
using HarmonyLib;
using Server.Shared.Extensions;
using UnityEngine;

namespace SkyControllerPP
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
					if ((bool)Settings.SettingsCache.GetValue("Color Snowflakes to Shader Color", null))
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
