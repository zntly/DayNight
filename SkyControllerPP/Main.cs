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
		// Token: 0x06000009 RID: 9
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
				Settings.SettingsCache.SetValue("Default Skybox", ModSettings.GetString("Default Skybox", "curtis.day.night.sync"));
				Settings.SettingsCache.SetValue("Day Skybox", ModSettings.GetString("Day Skybox", "curtis.day.night.sync"));
				Settings.SettingsCache.SetValue("Night Skybox", ModSettings.GetString("Night Skybox", "curtis.day.night.sync"));
				Settings.SettingsCache.SetValue("Dawn Skybox", ModSettings.GetString("Dawn Skybox", "curtis.day.night.sync"));
				Settings.SettingsCache.SetValue("Dusk Skybox", ModSettings.GetString("Dusk Skybox", "curtis.day.night.sync"));
				Settings.SettingsCache.SetValue("Apocalypse Skybox", ModSettings.GetString("Apocalypse Skybox", "curtis.day.night.sync"));
				Settings.SettingsCache.SetValue("Tribunal Skybox", ModSettings.GetString("Tribunal Skybox", "curtis.day.night.sync"));
				Settings.SettingsCache.SetValue("Court Skybox", ModSettings.GetString("Court Skybox", "curtis.day.night.sync"));
				Settings.SettingsCache.SetValue("Daybreak Skybox", ModSettings.GetString("Daybreak Skybox", "curtis.day.night.sync"));
				Settings.SettingsCache.SetValue("Color Snowflakes to Shader Color", ModSettings.GetBool("Color Snowflakes to Shader Color", "curtis.day.night.sync"));
				Settings.SettingsCache.SetValue("Jail Cell Shading Mode", ModSettings.GetString("Jail Cell Shading Mode", "curtis.day.night.sync"));
				Settings.SettingsCache.SetValue("Random Sky Mode", ModSettings.GetString("Random Sky Mode", "curtis.day.night.sync"));
				Settings.SettingsCache.SetValue("Random Sky Wait in Seconds", (float)ModSettings.GetInt("Random Sky Wait", "curtis.day.night.sync"));
			}
			catch
			{
			}
			this.Corotine = this.RandomSkyWaitCoroutine();
			ApplicationController.ApplicationContext.StartCoroutine(this.Corotine);
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
						case SkyInfo.SkyType.Greek:
							SkyInfo.Instance.UpdateIntroClouds("Day");
							break;
						case SkyInfo.SkyType.Void:
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

		// Token: 0x0600000C RID: 12
		public IEnumerator<WaitForSeconds> RandomSkyWaitCoroutine()
		{
			for (;;)
			{
				yield return new WaitForSeconds((float)Settings.SettingsCache.GetValue("Random Sky Wait in Seconds", null));
				if ((string)Settings.SettingsCache.GetValue("Random Sky Mode", null) == "Time in Seconds" && SkyInfo.Instance)
				{
					Settings.SettingsCache.SetValue("Current Random Sky", SkyInfo.Instance.RandomSkyTypeAsString());
					if (Leo.IsHomeScene())
					{
						SkyInfo.Instance.UpdateSky();
					}
				}
			}
			yield break;
		}

		// Token: 0x04000002 RID: 2
		public static Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();

		// Token: 0x04000003 RID: 3
		public static ParticleSystem Snowflakes;

		// Token: 0x04000004 RID: 4
		public IEnumerator<WaitForSeconds> Corotine;
	}
}
