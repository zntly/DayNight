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
	// Token: 0x02000007 RID: 7
	[Mod.SalemMod]
	public class Main
	{
		// Token: 0x06000009 RID: 9 RVA: 0x00002214 File Offset: 0x00000414
		public void Start()
		{
			AssetBundle assetBundleFromResources = FromAssetBundle.GetAssetBundleFromResources("SkyControllerPP.resources.assetbundles.daynight", Assembly.GetExecutingAssembly());
			assetBundleFromResources.LoadAllAssets<Texture2D>().ForEach(delegate(Texture2D s)
			{
				Main.Textures.Add(s.name, s);
			});
			bool flag = assetBundleFromResources != null;
			if (flag)
			{
				assetBundleFromResources.Unload(false);
			}
			try
			{
				string @string = ModSettings.GetString("Permanent Skybox", "curtis.day.night.sync");
				bool flag2 = @string != "Outdated";
				if (flag2)
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
				bool flag3 = ModSettings.GetString("Default Skybox", "curtis.day.night.sync") == "Random";
				if (flag3)
				{
					ModSettings.SetString("Default Skybox", "None", "curtis.day.night.sync");
				}
				bool flag4 = ModSettings.GetString("Day Skybox", "curtis.day.night.sync") == "Random";
				if (flag4)
				{
					ModSettings.SetString("Day Skybox", "None", "curtis.day.night.sync");
				}
				bool flag5 = ModSettings.GetString("Night Skybox", "curtis.day.night.sync") == "Random";
				if (flag5)
				{
					ModSettings.SetString("Night Skybox", "None", "curtis.day.night.sync");
				}
				bool flag6 = ModSettings.GetString("Tribunal Skybox", "curtis.day.night.sync") == "Random";
				if (flag6)
				{
					ModSettings.SetString("Tribunal Skybox", "None", "curtis.day.night.sync");
				}
				bool flag7 = ModSettings.GetString("Court Skybox", "curtis.day.night.sync") == "Random";
				if (flag7)
				{
					ModSettings.SetString("Court Skybox", "None", "curtis.day.night.sync");
				}
				bool flag8 = ModSettings.GetString("Daybreak Skybox", "curtis.day.night.sync") == "Random";
				if (flag8)
				{
					ModSettings.SetString("Daybreak Skybox", "None", "curtis.day.night.sync");
				}
			}
			catch
			{
			}
			Service.Home.ApplicationService.OnSceneLoaded += delegate(SceneType sceneType, LoadSceneMode loadSceneMode)
			{
				bool flag9 = Main.Snowflakes == null && (sceneType == SceneType.MAP || sceneType == SceneType.GAME) && Service.Home.Customizations.myCustomizationSelections.Data.mapId == 2;
				if (flag9)
				{
					Main.Snowflakes = GameObject.Find("SceneRoot/Snow_Particles").GetComponent<ParticleSystem>();
				}
				bool flag10 = SkyInfo.Instance;
				if (flag10)
				{
					SkyInfo.Instance.Pest = false;
					SkyInfo.Instance.Famine = false;
					SkyInfo.Instance.War = false;
					SkyInfo.Instance.Death = false;
					bool flag11 = Leo.IsHomeScene();
					if (flag11)
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
					else
					{
						bool flag12 = Leo.IsGameScene();
						if (flag12)
						{
							SkyInfo.Phase = "Day";
						}
					}
					SkyInfo.Instance.UpdateSky();
				}
			};
		}

		// Token: 0x04000002 RID: 2
		public static Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();

		// Token: 0x04000003 RID: 3
		public static ParticleSystem Snowflakes;
	}
}
