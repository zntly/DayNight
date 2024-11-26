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
		// Token: 0x06000041 RID: 65 RVA: 0x000036A8 File Offset: 0x000018A8
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
		}

		// Token: 0x0400001E RID: 30
		public static Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();
	}
}
