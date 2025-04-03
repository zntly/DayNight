using System;
using Game.Houses;
using HarmonyLib;
using Server.Shared.Extensions;
using SML;
using UnityEngine;

namespace DayNight
{
	// Token: 0x0200001E RID: 30
	[HarmonyPatch(typeof(JailInterior), "Start")]
	public class JailCellShader
	{
		// Token: 0x060000BF RID: 191 RVA: 0x000086AC File Offset: 0x000068AC
		[HarmonyPostfix]
		public static void Postfix(JailInterior __instance)
		{
			JailCellShader.jailz = __instance.jailPrefab;
			JailCellShader.lastcolor = Color.white;
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
			JailCellShader.ShadeCell(SkyInfo.GetSkyColor(skyType));
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00008780 File Offset: 0x00006980
		public static void ShadeCell(Color color)
		{
			if ((string)Settings.SettingsCache.GetValue("Jail Cell Shading Mode", null) == "Custom")
			{
				color = Settings.ColorCache.GetValue("Jail Cell Shader Color");
			}
			else if ((string)Settings.SettingsCache.GetValue("Jail Cell Shading Mode", null) == "Normal")
			{
				color = Color.white;
			}
			if (JailCellShader.jailz != null && color != JailCellShader.lastcolor)
			{
				JailCellShader.lastcolor = color;
				MeshRenderer[] componentsInChildren = JailCellShader.jailz.GetComponentsInChildren<MeshRenderer>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					foreach (Material material in componentsInChildren[i].materials)
					{
						if (material.name != "Outline_Black (Instance)")
						{
							material.color = color;
						}
					}
				}
			}
		}

		// Token: 0x04000075 RID: 117
		public static Transform jailz;

		// Token: 0x04000076 RID: 118
		public static Color lastcolor = Color.white;
	}
}
