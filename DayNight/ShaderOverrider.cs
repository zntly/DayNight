/*using System;
using HarmonyLib;
using Server.Shared.Extensions;
using Server.Shared.State;
using UnityEngine;

namespace DayNight
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
}*/
using System;
using HarmonyLib;
using Server.Shared.Extensions;
using Server.Shared.State;
using UnityEngine;

namespace DayNight
{
	[HarmonyPatch(typeof(GlobalShaderColors), "ValidateColors")]
	public class ShaderOverrider
	{
		[HarmonyPostfix]
		public static void Postfix(GlobalShaderColors __instance)
		{
			bool isBTOS2 = Utils.IsBTOS2();
			SkyInfo.SkyType skyType = SkyInfo.GetCurrentPermSkyType();
			if (isBTOS2)
            {
				if (SkyInfo.Phase != "Daybreak" && Utils.CourtCheck())
                {
					SkyInfo.Phase = "Court";
                }
            }
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
				skyType = GetRandomSkyType();
			}

			UpdateSkyTypeIfChanged(skyType);
			UpdateCinematicTint(__instance, skyType, isBTOS2);
		}
		private static SkyInfo.SkyType GetRandomSkyType()
		{
			return (SkyInfo.SkyType)Enum.Parse(typeof(SkyInfo.SkyType), (string)Settings.SettingsCache.GetValue("Current Random Sky", null));
		}

		private static void UpdateSkyTypeIfChanged(SkyInfo.SkyType skyType)
		{
			if (SkyInfo.Instance && SkyInfo.CurrentActive != skyType)
			{
				SkyInfo.Instance.SetCurrentSkyType(skyType);
				UpdateSnowflakesColor(skyType);
			}
		}

		private static void UpdateSnowflakesColor(SkyInfo.SkyType skyType)
		{
			if (Main.Snowflakes == null) return;

			Color intendedColor = (bool)Settings.SettingsCache.GetValue("Color Snowflakes to Shader Color", null) ?
				SkyInfo.GetSkyColor(skyType) : Color.white;

			if (Main.Snowflakes.startColor != intendedColor)
			{
				Main.Snowflakes.startColor = intendedColor;
				Main.Snowflakes.Clear();
				Main.Snowflakes.Emit(250);
			}
		}

		private static void UpdateCinematicTint(GlobalShaderColors instance, SkyInfo.SkyType skyType, bool isBTOS2)
		{
			if (instance.colorProviders.Contains(GlobalShaderColors.ColorProviders.Cinematic) &&
				(instance.cinematicPlayer.cinematicType == CinematicType.RoleReveal ||
				 instance.cinematicPlayer.cinematicType == CinematicType.HexBomb ||
				 (isBTOS2 && instance.cinematicPlayer.cinematicType == CinematicType.None)))
			{
				instance.targetExteriorGlobalTintColor *= SkyInfo.GetSkyColor(skyType);
			}
			else
			{
				instance.targetExteriorGlobalTintColor = SkyInfo.GetSkyColor(skyType);
			}
		}
	}
}
