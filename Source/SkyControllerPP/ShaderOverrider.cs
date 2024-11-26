using System;
using BetterTOS2;
using BetterTOS2.Observations;
using HarmonyLib;
using Server.Shared.State;
using Services;
using Sight;
using SML;
using UnityEngine;

namespace SkyControllerPP
{
	// Token: 0x02000017 RID: 23
	[HarmonyPatch(typeof(GlobalShaderColors), "ValidateColors")]
	public class ShaderOverrider
	{
		// Token: 0x06000095 RID: 149
		[HarmonyPrefix]
		public static void Prefix(GlobalShaderColors __instance)
		{
			if (SkyInfo.Phase != "Daybreak" && ModStates.IsEnabled("curtis.tuba.better.tos2") && BTOSInfo.IS_MODDED && GameObservationsPatch.musicOverrideObservation.Data.court)
			{
				SkyInfo.Phase = "Court";
			}
			MapShaderColors mapShaderColors = Service.Game.Map.mapShaderColors;
			SkyInfo.SkyType skyType = SkyInfo.GetCurrentPermSkyType();
			if (SkyInfo.Phase != "Tribunal" && SkyInfo.Phase != "Court" && SkyInfo.Phase != "Daybreak" && (SkyInfo.Instance.Pest || SkyInfo.Instance.Famine || SkyInfo.Instance.Death || SkyInfo.Instance.War))
			{
				skyType = SkyInfo.GetCurrentApocSkyType();
			}
			if (mapShaderColors != null)
			{
				mapShaderColors.dayColor = SkyInfo.GetSkyColor(skyType);
				mapShaderColors.nightColor = SkyInfo.GetSkyColor(skyType);
				return;
			}
			__instance.dayColor = SkyInfo.GetSkyColor(skyType);
			__instance.nightColor = SkyInfo.GetSkyColor(skyType);
			SkyInfo.Instance.SetCurrentSkyType(skyType);
		}

		// Token: 0x06000096 RID: 150
		[HarmonyPostfix]
		public static void Postfix(GlobalShaderColors __instance)
		{
			if (__instance.colorProviders.Contains(GlobalShaderColors.ColorProviders.Cinematic))
			{
				SkyInfo.SkyType skyType = SkyInfo.GetCurrentPermSkyType();
				if (SkyInfo.Phase != "Tribunal" && SkyInfo.Phase != "Court" && SkyInfo.Phase != "Daybreak" && (SkyInfo.Instance.Pest || SkyInfo.Instance.Famine || SkyInfo.Instance.Death || SkyInfo.Instance.War))
				{
					skyType = SkyInfo.GetCurrentApocSkyType();
				}
				if (__instance.cinematicPlayer.cinematicType != CinematicType.RoleReveal)
				{
					__instance.targetExteriorGlobalTintColor = SkyInfo.GetSkyColor(skyType);
					return;
				}
				Color tc = __instance.targetExteriorGlobalTintColor;
				__instance.targetExteriorGlobalTintColor = tc * SkyInfo.GetSkyColor(skyType);
			}
		}
	}
}
