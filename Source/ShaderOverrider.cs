using System;
using HarmonyLib;
using Server.Shared.State;
using Services;
using Sight;
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
			if (Utils.IsBTOS2())
			{
				if (SkyInfo.Phase != "Daybreak" && Utils.CourtCheck())
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
				return;
			}
			else
			{
				MapShaderColors mapShaderColors2 = Service.Game.Map.mapShaderColors;
				SkyInfo.SkyType skyType2 = SkyInfo.GetCurrentPermSkyType();
				if (SkyInfo.Phase != "Tribunal" && (SkyInfo.Instance.Pest || SkyInfo.Instance.Famine || SkyInfo.Instance.Death || SkyInfo.Instance.War))
				{
					skyType2 = SkyInfo.GetCurrentApocSkyType();
				}
				if (mapShaderColors2 != null)
				{
					mapShaderColors2.dayColor = SkyInfo.GetSkyColor(skyType2);
					mapShaderColors2.nightColor = SkyInfo.GetSkyColor(skyType2);
					return;
				}
				__instance.dayColor = SkyInfo.GetSkyColor(skyType2);
				__instance.nightColor = SkyInfo.GetSkyColor(skyType2);
				SkyInfo.Instance.SetCurrentSkyType(skyType2);
				return;
			}
		}

		// Token: 0x06000096 RID: 150
		[HarmonyPostfix]
		public static void Postfix(GlobalShaderColors __instance)
		{
			if (__instance.colorProviders.Contains(GlobalShaderColors.ColorProviders.Cinematic))
			{
				if (Utils.IsBTOS2())
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
					if (__instance.cinematicPlayer.cinematicType == CinematicType.RoleReveal)
					{
						Color targetExteriorGlobalTintColor = __instance.targetExteriorGlobalTintColor;
						__instance.targetExteriorGlobalTintColor = targetExteriorGlobalTintColor * SkyInfo.GetSkyColor(skyType);
						return;
					}
				}
				else
				{
					SkyInfo.SkyType skyType2 = SkyInfo.GetCurrentPermSkyType();
					if (SkyInfo.Phase != "Tribunal" && (SkyInfo.Instance.Pest || SkyInfo.Instance.Famine || SkyInfo.Instance.Death || SkyInfo.Instance.War))
					{
						skyType2 = SkyInfo.GetCurrentApocSkyType();
					}
					if (__instance.cinematicPlayer.cinematicType != CinematicType.RoleReveal)
					{
						__instance.targetExteriorGlobalTintColor = SkyInfo.GetSkyColor(skyType2);
						return;
					}
					if (__instance.cinematicPlayer.cinematicType == CinematicType.RoleReveal)
					{
						Color targetExteriorGlobalTintColor2 = __instance.targetExteriorGlobalTintColor;
						__instance.targetExteriorGlobalTintColor = targetExteriorGlobalTintColor2 * SkyInfo.GetSkyColor(skyType2);
					}
				}
			}
		}
	}
}
