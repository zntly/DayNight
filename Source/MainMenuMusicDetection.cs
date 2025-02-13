﻿using System;
using HarmonyLib;
using Home.Services;

namespace SkyControllerPP
{
	// Token: 0x0200001C RID: 28
	[HarmonyPatch(typeof(HomeAudioService), "PlayMusic")]
	public class MainMenuMusicDetection
	{
		// Token: 0x060000A5 RID: 165 RVA: 0x00006780 File Offset: 0x00004980
		[HarmonyPostfix]
		public static void Postfix(string sound, bool loop, AudioController.AudioChannel channel, bool stopAllMusic)
		{
			if (Utils.BTOS2Exists() && Leo.IsHomeScene())
			{
				if (sound == "Court")
				{
					SkyInfo.Phase = "Court";
					try
					{
						SkyInfo.Instance.UpdateSky();
					}
					catch
					{
					}
					return;
				}
				if (sound == "TribunalLoop")
				{
					SkyInfo.Phase = "Tribunal";
					try
					{
						SkyInfo.Instance.UpdateSky();
					}
					catch
					{
					}
					return;
				}
				if (sound == "Daybreak")
				{
					SkyInfo.Phase = "Daybreak";
					try
					{
						SkyInfo.Instance.UpdateSky();
					}
					catch
					{
					}
					return;
				}
			}
		}
	}
}
