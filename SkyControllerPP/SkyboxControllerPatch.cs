using System;
using System.Collections;
using HarmonyLib;
using Home.Shared;

namespace SkyControllerPP
{
	// Token: 0x02000010 RID: 16
	[HarmonyPatch(typeof(SkyboxController), "Update")]
	public class SkyboxControllerPatch
	{
		// Token: 0x06000038 RID: 56 RVA: 0x00004683 File Offset: 0x00002883
		private static IEnumerator SetSkyShader()
		{
			yield return null;
			bool flag = Leo.IsHomeScene();
			if (flag)
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

		// Token: 0x06000039 RID: 57 RVA: 0x0000468C File Offset: 0x0000288C
		[HarmonyPostfix]
		public static void Postfix(SkyboxController __instance)
		{
			bool flag = SkyInfo.Already != __instance;
			if (flag)
			{
				SkyInfo.Already = __instance;
				bool flag2 = Leo.IsGameScene();
				if (flag2)
				{
					SkyInfo.Instance = __instance.gameObject.AddComponent<SkyControllerPlus>();
					SkyInfo.Phase = "Day";
				}
				else
				{
					SkyInfo.Instance = __instance.gameObject.AddComponent<SkyControllerPlus>();
					SkyInfo.Phase = "NotGame";
					ApplicationController.ApplicationContext.StartCoroutine(SkyboxControllerPatch.SetSkyShader());
				}
			}
		}

		// Token: 0x04000008 RID: 8
		public static bool Last;

		// Token: 0x04000009 RID: 9
		public static string LastScene;
	}
}
