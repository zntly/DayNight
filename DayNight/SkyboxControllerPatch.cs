﻿using System;
using System.Collections;
using HarmonyLib;
using Home.Shared;

namespace DayNight
{
    // Token: 0x02000012 RID: 18
    [HarmonyPatch(typeof(SkyboxController), "Update")]
    public class SkyboxControllerPatch
    {
        // Token: 0x06000066 RID: 102 RVA: 0x000020D2 File Offset: 0x000002D2
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
                    case SkyInfo.SkyType.Greek:
                        SkyInfo.Instance.UpdateIntroClouds("Day");
                        break;
                    case SkyInfo.SkyType.Mafia:
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

        // Token: 0x06000067 RID: 103 RVA: 0x00003FF8 File Offset: 0x000021F8
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

        // Token: 0x04000030 RID: 48
        public static bool Last;

        // Token: 0x04000031 RID: 49
        public static string LastScene;
    }
}
