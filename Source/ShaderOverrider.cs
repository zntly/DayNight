using System;
using HarmonyLib;
using Server.Shared.State;
using SML;
using UnityEngine;

namespace SkyControllerPP
{
	// Token: 0x02000017 RID: 23
	[HarmonyPatch(typeof(GlobalShaderColors), "ValidateColors")]
	public class ShaderOverrider
	{
		// Token: 0x0600009A RID: 154 RVA: 0x000063A0 File Offset: 0x000045A0
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
				if (SkyInfo.Instance && SkyInfo.CurrentActive != skyType)
				{
					SkyInfo.Instance.SetCurrentSkyType(skyType);
					if (Main.Snowflakes != null)
					{
						if (ModSettings.GetBool("Color Snowflakes to Shader Color (Winter Map)"))
						{
							bool flag = Main.Snowflakes.startColor != SkyInfo.GetSkyColor(skyType);
							Main.Snowflakes.startColor = SkyInfo.GetSkyColor(skyType);
							if (flag)
							{
								Main.Snowflakes.Clear();
								Main.Snowflakes.Emit(250);
							}
							return;
						}
						bool flag2 = Main.Snowflakes.startColor != new Color(1f, 1f, 1f, 1f);
						Main.Snowflakes.startColor = new Color(1f, 1f, 1f, 1f);
						if (flag2)
						{
							Main.Snowflakes.Clear();
							Main.Snowflakes.Emit(250);
						}
					}
				}
				if (__instance.colorProviders.Contains(GlobalShaderColors.ColorProviders.Cinematic) && __instance.cinematicPlayer.cinematicType == CinematicType.RoleReveal)
				{
					Color targetExteriorGlobalTintColor = __instance.targetExteriorGlobalTintColor;
					__instance.targetExteriorGlobalTintColor = targetExteriorGlobalTintColor * SkyInfo.GetSkyColor(skyType);
					return;
				}
				__instance.targetExteriorGlobalTintColor = SkyInfo.GetSkyColor(skyType);
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
				if (SkyInfo.Instance && SkyInfo.CurrentActive != skyType2)
				{
					SkyInfo.Instance.SetCurrentSkyType(skyType2);
					if (Main.Snowflakes != null)
					{
						if (ModSettings.GetBool("Color Snowflakes to Shader Color (Winter Map)"))
						{
							bool flag3 = Main.Snowflakes.startColor != SkyInfo.GetSkyColor(skyType2);
							Main.Snowflakes.startColor = SkyInfo.GetSkyColor(skyType2);
							if (flag3)
							{
								Main.Snowflakes.Clear();
								Main.Snowflakes.Emit(250);
							}
							return;
						}
						bool flag4 = Main.Snowflakes.startColor != new Color(1f, 1f, 1f, 1f);
						Main.Snowflakes.startColor = new Color(1f, 1f, 1f, 1f);
						if (flag4)
						{
							Main.Snowflakes.Clear();
							Main.Snowflakes.Emit(250);
						}
					}
				}
				if (__instance.colorProviders.Contains(GlobalShaderColors.ColorProviders.Cinematic) && __instance.cinematicPlayer.cinematicType == CinematicType.RoleReveal)
				{
					Color targetExteriorGlobalTintColor2 = __instance.targetExteriorGlobalTintColor;
					__instance.targetExteriorGlobalTintColor = targetExteriorGlobalTintColor2 * SkyInfo.GetSkyColor(skyType2);
					return;
				}
				__instance.targetExteriorGlobalTintColor = SkyInfo.GetSkyColor(skyType2);
				return;
			}
		}
	}
}
