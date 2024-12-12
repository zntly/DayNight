using System;
using System.Collections;
using HarmonyLib;
using Home.Shared;

namespace SkyControllerPP
{
	// Token: 0x0200000A RID: 10
	[HarmonyPatch(typeof(SkyboxController), "Update")]
	public class SkyboxControllerPatch
	{
		// Token: 0x0600004B RID: 75 RVA: 0x0000425C File Offset: 0x0000245C
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

		// Token: 0x0600004D RID: 77 RVA: 0x000020D4 File Offset: 0x000002D4
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
				}
			}
			SkyInfo.Instance.UpdateSky();
			yield break;
		}

		// Token: 0x04000024 RID: 36
		public static bool Last;

		// Token: 0x04000025 RID: 37
		public static string LastScene;
	}
}
