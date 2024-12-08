using System;
using System.Collections.Generic;
using System.Reflection;
using Server.Shared.Extensions;
using SML;
using UnityEngine;

namespace SkyControllerPP
{
	// Token: 0x02000008 RID: 8
	[Mod.SalemMod]
	public class Main
	{
		// Token: 0x06000044 RID: 68 RVA: 0x00003F08 File Offset: 0x00002108
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
		}

		// Token: 0x04000020 RID: 32
		public static Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();
	}
}
