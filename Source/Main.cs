using System;
using System.Collections.Generic;
using System.Reflection;
using Home.Shared;
using Server.Shared.Extensions;
using Services;
using SML;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SkyControllerPP
{
	// Token: 0x02000008 RID: 8
	[Mod.SalemMod]
	public class Main
	{
		// Token: 0x06000046 RID: 70 RVA: 0x00003F74 File Offset: 0x00002174
		public void Start()
		{
			AssetBundle assetBundleFromResources = FromAssetBundle.GetAssetBundleFromResources("SkyControllerPP.resources.assetbundles.daynight", Assembly.GetExecutingAssembly());
			assetBundleFromResources.LoadAllAssets<Texture2D>().ForEach(delegate(Texture2D s)
			{
				Main.Textures.Add(s.name, s);
			});
			if (assetBundleFromResources != null)
			{
				assetBundleFromResources.Unload(false);
			}
			try
			{
				string @string = ModSettings.GetString("Permanent Skybox", "curtis.day.night.sync");
				if (@string != "Outdated")
				{
					ModSettings.SetString("Default Skybox", @string, "curtis.day.night.sync");
					ModSettings.SetString("Permanent Skybox", "Outdated", "curtis.day.night.sync");
				}
			}
			catch
			{
				Console.WriteLine("If you're seeing this you aren't an OG :pensive:");
			}
			try
			{
				if (ModSettings.GetString("Default Skybox", "curtis.day.night.sync") == "Random")
				{
					ModSettings.SetString("Default Skybox", "None", "curtis.day.night.sync");
				}
				if (ModSettings.GetString("Day Skybox", "curtis.day.night.sync") == "Random")
				{
					ModSettings.SetString("Day Skybox", "None", "curtis.day.night.sync");
				}
				if (ModSettings.GetString("Night Skybox", "curtis.day.night.sync") == "Random")
				{
					ModSettings.SetString("Night Skybox", "None", "curtis.day.night.sync");
				}
				if (ModSettings.GetString("Tribunal Skybox", "curtis.day.night.sync") == "Random")
				{
					ModSettings.SetString("Tribunal Skybox", "None", "curtis.day.night.sync");
				}
				if (ModSettings.GetString("Court Skybox", "curtis.day.night.sync") == "Random")
				{
					ModSettings.SetString("Court Skybox", "None", "curtis.day.night.sync");
				}
				if (ModSettings.GetString("Daybreak Skybox", "curtis.day.night.sync") == "Random")
				{
					ModSettings.SetString("Daybreak Skybox", "None", "curtis.day.night.sync");
				}
			}
			catch
			{
			}
			Service.Home.ApplicationService.OnSceneLoaded += delegate(SceneType sceneType, LoadSceneMode loadSceneMode)
			{
				if (Main.Snowflakes == null && (sceneType == SceneType.MAP || sceneType == SceneType.GAME) && Service.Home.Customizations.myCustomizationSelections.Data.mapId == 2)
				{
					Main.Snowflakes = GameObject.Find("SceneRoot/Snow_Particles").GetComponent<ParticleSystem>();
				}
				if (SkyInfo.Instance)
				{
					SkyInfo.Instance.Pest = false;
					SkyInfo.Instance.Famine = false;
					SkyInfo.Instance.War = false;
					SkyInfo.Instance.Death = false;
					if (Leo.IsHomeScene())
					{
						SkyInfo.Phase = "NotGame";
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
					else if (Leo.IsGameScene())
					{
						SkyInfo.Phase = "Day";
					}
					SkyInfo.Instance.UpdateSky();
				}
			};
		}

		// Token: 0x04000021 RID: 33
		public static Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();

		// Token: 0x04000022 RID: 34
		public static ParticleSystem Snowflakes;
	}
}
