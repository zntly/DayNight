using System;
using System.Collections;
using HarmonyLib;
using Home.Shared;

namespace SkyControllerPP
{
	// Token: 0x02000012 RID: 18
	[HarmonyPatch(typeof(SkyboxController), "Update")]
	public class SkyboxControllerPatch
	{
		// Token: 0x06000063 RID: 99 RVA: 0x000020EB File Offset: 0x000002EB
		private static IEnumerator SetSkyShader()
		{
			yield return null;
			if (Leo.IsHomeScene())
			{
				switch (SkyInfo.Instance.GetCurrentSkyType())
				{
				case SkyInfo.SkyType.Day:
					SkyInfo.Instance.UpdateIntroClouds("Day");
					break;
				case SkyInfo.SkyType.Night:
					SkyInfo.Instance.UpdateIntroClouds("Night");
					break;
				case SkyInfo.SkyType.Dawn:
					SkyInfo.Instance.UpdateIntroClouds("Dawn");
					break;
				case SkyInfo.SkyType.Dusk:
					SkyInfo.Instance.UpdateIntroClouds("Dawn");
					break;
				case SkyInfo.SkyType.BloodMoon:
					SkyInfo.Instance.UpdateIntroClouds("BloodMoon");
					break;
				case SkyInfo.SkyType.Storm:
					SkyInfo.Instance.UpdateIntroClouds("Storm");
					break;
				case SkyInfo.SkyType.Eclipse:
					SkyInfo.Instance.UpdateIntroClouds("Invis");
					break;
				case SkyInfo.SkyType.Winter:
					SkyInfo.Instance.UpdateIntroClouds("Invis");
					break;
				case SkyInfo.SkyType.Void:
					SkyInfo.Instance.UpdateIntroClouds("Invis");
					break;
				}
			}
			SkyInfo.Instance.UpdateSky();
			yield break;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00004D48 File Offset: 0x00002F48
		[HarmonyPostfix]
		public static void Postfix(SkyboxController __instance)
		{
			if (SkyInfo.Already != __instance)
			{
				SkyInfo.Already = __instance;
				if (Leo.IsGameScene())
				{
					SkyInfo.Instance = __instance.gameObject.AddComponent<SkyControllerPlus>();
					SkyInfo.Phase = "Day";
					return;
				}
				SkyInfo.Instance = __instance.gameObject.AddComponent<SkyControllerPlus>();
				SkyInfo.Phase = "NotGame";
				ApplicationController.ApplicationContext.StartCoroutine(SkyboxControllerPatch.SetSkyShader());
			}
		}

		// Token: 0x0400002E RID: 46
		public static bool Last;

		// Token: 0x0400002F RID: 47
		public static string LastScene;
	}
}
