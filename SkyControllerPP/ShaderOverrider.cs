using System;
using HarmonyLib;
using Server.Shared.State;
using SML;
using UnityEngine;

namespace SkyControllerPP
{
	// Token: 0x0200000F RID: 15
	[HarmonyPatch(typeof(GlobalShaderColors), "ValidateColors")]
	public class ShaderOverrider
	{
		// Token: 0x06000036 RID: 54 RVA: 0x0000425C File Offset: 0x0000245C
		[HarmonyPostfix]
		public static void Postfix(GlobalShaderColors __instance)
		{
			bool flag = Utils.IsBTOS2();
			if (flag)
			{
				bool flag2 = SkyInfo.Phase != "Daybreak" && Utils.CourtCheck();
				if (flag2)
				{
					SkyInfo.Phase = "Court";
				}
				SkyInfo.SkyType skyType = SkyInfo.GetCurrentPermSkyType();
				bool flag3 = SkyInfo.Phase != "Tribunal" && SkyInfo.Phase != "Court" && SkyInfo.Phase != "Daybreak" && (SkyInfo.Instance.Pest || SkyInfo.Instance.Famine || SkyInfo.Instance.Death || SkyInfo.Instance.War);
				if (flag3)
				{
					skyType = SkyInfo.GetCurrentApocSkyType();
				}
				bool flag4 = skyType == SkyInfo.SkyType.None;
				if (flag4)
				{
					skyType = SkyInfo.GetSyncedSkyType();
				}
				bool flag5 = SkyInfo.Instance && SkyInfo.CurrentActive != skyType;
				if (flag5)
				{
					SkyInfo.Instance.SetCurrentSkyType(skyType);
					bool flag6 = Main.Snowflakes != null;
					if (flag6)
					{
						bool @bool = ModSettings.GetBool("Color Snowflakes to Shader Color (Winter Map)");
						if (@bool)
						{
							bool flag7 = Main.Snowflakes.startColor != SkyInfo.GetSkyColor(skyType);
							Main.Snowflakes.startColor = SkyInfo.GetSkyColor(skyType);
							bool flag8 = flag7;
							if (flag8)
							{
								Main.Snowflakes.Clear();
								Main.Snowflakes.Emit(250);
							}
							return;
						}
						bool flag9 = Main.Snowflakes.startColor != new Color(1f, 1f, 1f, 1f);
						Main.Snowflakes.startColor = new Color(1f, 1f, 1f, 1f);
						bool flag10 = flag9;
						if (flag10)
						{
							Main.Snowflakes.Clear();
							Main.Snowflakes.Emit(250);
						}
					}
				}
				bool flag11 = __instance.colorProviders.Contains(GlobalShaderColors.ColorProviders.Cinematic) && __instance.cinematicPlayer.cinematicType == CinematicType.RoleReveal;
				if (flag11)
				{
					Color targetExteriorGlobalTintColor = __instance.targetExteriorGlobalTintColor;
					__instance.targetExteriorGlobalTintColor = targetExteriorGlobalTintColor * SkyInfo.GetSkyColor(skyType);
				}
				else
				{
					__instance.targetExteriorGlobalTintColor = SkyInfo.GetSkyColor(skyType);
				}
			}
			else
			{
				SkyInfo.SkyType skyType2 = SkyInfo.GetCurrentPermSkyType();
				bool flag12 = SkyInfo.Phase != "Tribunal" && (SkyInfo.Instance.Pest || SkyInfo.Instance.Famine || SkyInfo.Instance.Death || SkyInfo.Instance.War);
				if (flag12)
				{
					skyType2 = SkyInfo.GetCurrentApocSkyType();
				}
				bool flag13 = skyType2 == SkyInfo.SkyType.None;
				if (flag13)
				{
					skyType2 = SkyInfo.GetSyncedSkyType();
				}
				bool flag14 = SkyInfo.Instance && SkyInfo.CurrentActive != skyType2;
				if (flag14)
				{
					SkyInfo.Instance.SetCurrentSkyType(skyType2);
					bool flag15 = Main.Snowflakes != null;
					if (flag15)
					{
						bool bool2 = ModSettings.GetBool("Color Snowflakes to Shader Color (Winter Map)");
						if (bool2)
						{
							bool flag16 = Main.Snowflakes.startColor != SkyInfo.GetSkyColor(skyType2);
							Main.Snowflakes.startColor = SkyInfo.GetSkyColor(skyType2);
							bool flag17 = flag16;
							if (flag17)
							{
								Main.Snowflakes.Clear();
								Main.Snowflakes.Emit(250);
							}
							return;
						}
						bool flag18 = Main.Snowflakes.startColor != new Color(1f, 1f, 1f, 1f);
						Main.Snowflakes.startColor = new Color(1f, 1f, 1f, 1f);
						bool flag19 = flag18;
						if (flag19)
						{
							Main.Snowflakes.Clear();
							Main.Snowflakes.Emit(250);
						}
					}
				}
				bool flag20 = __instance.colorProviders.Contains(GlobalShaderColors.ColorProviders.Cinematic) && __instance.cinematicPlayer.cinematicType == CinematicType.RoleReveal;
				if (flag20)
				{
					Color targetExteriorGlobalTintColor2 = __instance.targetExteriorGlobalTintColor;
					__instance.targetExteriorGlobalTintColor = targetExteriorGlobalTintColor2 * SkyInfo.GetSkyColor(skyType2);
				}
				else
				{
					__instance.targetExteriorGlobalTintColor = SkyInfo.GetSkyColor(skyType2);
				}
			}
		}
	}
}
