using System;
using HarmonyLib;
using Server.Shared.Extensions;
using Server.Shared.State;
using UnityEngine;

namespace SkyControllerPP
{
	// Token: 0x02000013 RID: 19
	[HarmonyPatch(typeof(GlobalShaderColors), "ValidateColors")]
	public class ShaderOverrider
	{
		// Token: 0x06000076 RID: 118
		[HarmonyPostfix]
		public static void Postfix(GlobalShaderColors __instance)
		{
			if (Utils.IsBTOS2())
			{
				if (SkyInfo.Phase != "Daybreak" && Utils.CourtCheck())
				{
					SkyInfo.Phase = "Court";
				}
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
				if (SkyInfo.Instance && SkyInfo.CurrentActive != skyType)
				{
					SkyInfo.Instance.SetCurrentSkyType(skyType);
					if (Main.Snowflakes != null)
					{
						if ((bool)Settings.SettingsCache.GetValue("Color Snowflakes to Shader Color", null))
						{
							if (Main.Snowflakes.startColor != SkyInfo.GetSkyColor(skyType))
							{
								Main.Snowflakes.startColor = SkyInfo.GetSkyColor(skyType);
								Main.Snowflakes.Clear();
								Main.Snowflakes.Emit(250);
							}
							return;
						}
						if (Main.Snowflakes.startColor != Color.white)
						{
							Main.Snowflakes.startColor = Color.white;
							Main.Snowflakes.Clear();
							Main.Snowflakes.Emit(250);
						}
					}
				}
				if (__instance.colorProviders.Contains(GlobalShaderColors.ColorProviders.Cinematic) && (__instance.cinematicPlayer.cinematicType == CinematicType.RoleReveal || __instance.cinematicPlayer.cinematicType == CinematicType.HexBomb || __instance.cinematicPlayer.cinematicType == CinematicType.None))
				{
					Color targetExteriorGlobalTintColor = __instance.targetExteriorGlobalTintColor;
					__instance.targetExteriorGlobalTintColor = targetExteriorGlobalTintColor * SkyInfo.GetSkyColor(skyType);
					return;
				}
				Color skyColor = SkyInfo.GetSkyColor(skyType);
				__instance.targetExteriorGlobalTintColor = skyColor;
				return;
			}
			else
			{
				SkyInfo.SkyType skyType2 = SkyInfo.GetCurrentPermSkyType();
				if (SkyInfo.Phase != "Tribunal" && (SkyInfo.Instance.Pest || SkyInfo.Instance.Famine || SkyInfo.Instance.Death || SkyInfo.Instance.War))
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
				if (SkyInfo.Instance && SkyInfo.CurrentActive != skyType2)
				{
					SkyInfo.Instance.SetCurrentSkyType(skyType2);
					if (Main.Snowflakes != null)
					{
						if ((bool)Settings.SettingsCache.GetValue("Color Snowflakes to Shader Color", null))
						{
							if (Main.Snowflakes.startColor != SkyInfo.GetSkyColor(skyType2))
							{
								Main.Snowflakes.startColor = SkyInfo.GetSkyColor(skyType2);
								Main.Snowflakes.Clear();
								Main.Snowflakes.Emit(250);
							}
							return;
						}
						if (Main.Snowflakes.startColor != Color.white)
						{
							Main.Snowflakes.startColor = Color.white;
							Main.Snowflakes.Clear();
							Main.Snowflakes.Emit(250);
						}
					}
				}
				if (__instance.colorProviders.Contains(GlobalShaderColors.ColorProviders.Cinematic) && (__instance.cinematicPlayer.cinematicType == CinematicType.RoleReveal || __instance.cinematicPlayer.cinematicType == CinematicType.HexBomb))
				{
					Color targetExteriorGlobalTintColor2 = __instance.targetExteriorGlobalTintColor;
					__instance.targetExteriorGlobalTintColor = targetExteriorGlobalTintColor2 * SkyInfo.GetSkyColor(skyType2);
					return;
				}
				Color skyColor2 = SkyInfo.GetSkyColor(skyType2);
				__instance.targetExteriorGlobalTintColor = skyColor2;
				return;
			}
		}
	}
}
