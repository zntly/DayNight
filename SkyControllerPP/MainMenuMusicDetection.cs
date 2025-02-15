using System;
using HarmonyLib;
using Home.Services;

namespace SkyControllerPP
{
	// Token: 0x02000008 RID: 8
	[HarmonyPatch(typeof(HomeAudioService), "PlayMusic")]
	public class MainMenuMusicDetection
	{
		// Token: 0x0600000C RID: 12 RVA: 0x0000248C File Offset: 0x0000068C
		[HarmonyPostfix]
		public static void Postfix(string sound, bool loop, AudioController.AudioChannel channel, bool stopAllMusic)
		{
			bool flag = Utils.BTOS2Exists() && Leo.IsHomeScene();
			if (flag)
			{
				bool flag2 = sound == "Court";
				if (flag2)
				{
					SkyInfo.Phase = "Court";
					try
					{
						SkyInfo.Instance.UpdateSky();
					}
					catch
					{
					}
				}
				else
				{
					bool flag3 = sound == "TribunalLoop";
					if (flag3)
					{
						SkyInfo.Phase = "Tribunal";
						try
						{
							SkyInfo.Instance.UpdateSky();
						}
						catch
						{
						}
					}
					else
					{
						bool flag4 = sound == "Daybreak";
						if (flag4)
						{
							SkyInfo.Phase = "Daybreak";
							try
							{
								SkyInfo.Instance.UpdateSky();
							}
							catch
							{
							}
						}
					}
				}
			}
		}
	}
}
