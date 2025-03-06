using System;
using Game.Houses;
using HarmonyLib;
using SML;
using UnityEngine;

namespace SkyControllerPP
{
	// Token: 0x0200001C RID: 28
	[HarmonyPatch(typeof(JailInterior), "Start")]
	public class JailCellShader
	{
		// Token: 0x060000A6 RID: 166
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
			JailCellShader.ShadeCell(SkyInfo.GetSkyColor(skyType));
		}

		// Token: 0x060000A8 RID: 168
		public static void ShadeCell(Color color)
		{
			if (ModSettings.GetString("Jail Cell Shading Mode") == "Custom")
			{
				color = ModSettings.GetColor("Jail Cell Shader Color");
			}
			else if (ModSettings.GetString("Jail Cell Shading Mode") == "Normal")
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

		// Token: 0x04000066 RID: 102
		public static Transform jailz;

		// Token: 0x04000067 RID: 103
		public static Color lastcolor = Color.white;
	}
}
