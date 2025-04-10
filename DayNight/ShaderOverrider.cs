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
