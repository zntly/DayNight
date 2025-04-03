using System;
using HarmonyLib;
using Home.Services;

namespace DayNight
{
	// Token: 0x02000009 RID: 9
	[HarmonyPatch(typeof(HomeAudioService), "PlayMusic")]
	public class MainMenuMusicDetection
	{
		// Token: 0x06000010 RID: 16 RVA: 0x00002858 File Offset: 0x00000A58
		[HarmonyPostfix]
		public static void Postfix(string sound, bool loop, AudioController.AudioChannel channel, bool stopAllMusic)
		{
			bool flag = Utils.BTOS2Exists() && Leo.IsHomeScene();
			bool flag2 = flag;
			if (flag2)
			{
				bool flag3 = sound == "Court";
				bool flag4 = flag3;
				if (flag4)
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
					bool flag5 = sound == "TribunalLoop";
					bool flag6 = flag5;
					if (flag6)
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
						bool flag7 = sound == "Daybreak";
						bool flag8 = flag7;
						if (flag8)
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
