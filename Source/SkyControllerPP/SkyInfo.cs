using System;
using SML;
using UnityEngine;

namespace SkyControllerPP
{
	// Token: 0x0200000D RID: 13
	public class SkyInfo
	{
		// Token: 0x06000057 RID: 87 RVA: 0x00003B64 File Offset: 0x00001D64
		public static SkyInfo.SkyType StringToSkyType(string s)
		{
			if (s != null)
			{
				switch (s.Length)
				{
				case 3:
					if (s == "Day")
					{
						return SkyInfo.SkyType.Day;
					}
					break;
				case 4:
				{
					char c = s[1];
					if (c != 'a')
					{
						if (c == 'u' && s == "Dusk")
						{
							return SkyInfo.SkyType.Dusk;
						}
					}
					else if (s == "Dawn")
					{
						return SkyInfo.SkyType.Dawn;
					}
					break;
				}
				case 5:
				{
					char c2 = s[0];
					if (c2 != 'N')
					{
						if (c2 == 'S' && s == "Storm")
						{
							return SkyInfo.SkyType.Storm;
						}
					}
					else if (s == "Night")
					{
						return SkyInfo.SkyType.Night;
					}
					break;
				}
				case 6:
				{
					char c3 = s[0];
					if (c3 != 'R')
					{
						if (c3 == 'W' && s == "Winter")
						{
							return SkyInfo.SkyType.Winter;
						}
					}
					else if (s == "Random")
					{
						return SkyInfo.SkyType.Random;
					}
					break;
				}
				case 7:
					if (s == "Eclipse")
					{
						return SkyInfo.SkyType.Eclipse;
					}
					break;
				case 10:
					if (s == "Blood Moon")
					{
						return SkyInfo.SkyType.BloodMoon;
					}
					break;
				}
			}
			return SkyInfo.SkyType.None;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00003C78 File Offset: 0x00001E78
		public static SkyInfo.SkyType GetCurrentPermSkyType()
		{
			if (SkyInfo.Phase == "Home")
			{
				return SkyInfo.StringToSkyType(ModSettings.GetString("Default Skybox", "curtis.day.night.sync"));
			}
			if (SkyInfo.Phase == "Day" && ModSettings.GetString("Day Skybox", "curtis.day.night.sync") != "None")
			{
				return SkyInfo.StringToSkyType(ModSettings.GetString("Day Skybox", "curtis.day.night.sync"));
			}
			if (SkyInfo.Phase == "Night" && ModSettings.GetString("Night Skybox", "curtis.day.night.sync") != "None")
			{
				return SkyInfo.StringToSkyType(ModSettings.GetString("Night Skybox", "curtis.day.night.sync"));
			}
			if (SkyInfo.Phase == "Daybreak" && ModSettings.GetString("Daybreak Skybox", "curtis.day.night.sync") != "None")
			{
				return SkyInfo.StringToSkyType(ModSettings.GetString("Daybreak Skybox", "curtis.day.night.sync"));
			}
			if (SkyInfo.Phase == "Court" && ModSettings.GetString("Court Skybox", "curtis.day.night.sync") != "None")
			{
				return SkyInfo.StringToSkyType(ModSettings.GetString("Court Skybox", "curtis.day.night.sync"));
			}
			if (SkyInfo.Phase == "Tribunal" && ModSettings.GetString("Tribunal Skybox", "curtis.day.night.sync") != "None")
			{
				return SkyInfo.StringToSkyType(ModSettings.GetString("Tribunal Skybox", "curtis.day.night.sync"));
			}
			if (SkyInfo.Phase == "Daybreak" && ModSettings.GetString("Daybreak Skybox", "curtis.day.night.sync") == "None" && ModSettings.GetString("Day Skybox", "curtis.day.night.sync") != "None")
			{
				return SkyInfo.StringToSkyType(ModSettings.GetString("Day Skybox", "curtis.day.night.sync"));
			}
			if (SkyInfo.Phase == "Court" && ModSettings.GetString("Court Skybox", "curtis.day.night.sync") == "None" && ModSettings.GetString("Day Skybox", "curtis.day.night.sync") != "None")
			{
				return SkyInfo.StringToSkyType(ModSettings.GetString("Day Skybox", "curtis.day.night.sync"));
			}
			if (SkyInfo.Phase == "Tribunal" && ModSettings.GetString("Tribunal Skybox", "curtis.day.night.sync") == "None" && ModSettings.GetString("Day Skybox", "curtis.day.night.sync") != "None")
			{
				return SkyInfo.StringToSkyType(ModSettings.GetString("Day Skybox", "curtis.day.night.sync"));
			}
			return SkyInfo.StringToSkyType(ModSettings.GetString("Default Skybox", "curtis.day.night.sync"));
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00003F18 File Offset: 0x00002118
		public static SkyInfo.SkyType GetSyncedSkyType()
		{
			int @int = ModSettings.GetInt("Dawn/Dusk Length");
			TimeSpan t = TimeSpan.Parse(ModSettings.GetString("Night Start"));
			TimeSpan t2 = TimeSpan.Parse(ModSettings.GetString("Night End"));
			TimeSpan timeOfDay = DateTime.Now.TimeOfDay;
			TimeSpan t3 = t2.Add(new TimeSpan(0, -@int / 2, 0));
			TimeSpan t4 = t2.Add(new TimeSpan(0, @int / 2, 0));
			TimeSpan t5 = t.Add(new TimeSpan(0, -@int / 2, 0));
			TimeSpan t6 = t.Add(new TimeSpan(0, @int / 2, 0));
			SkyInfo.SkyType result;
			if (t > t2)
			{
				if (timeOfDay >= t6 || timeOfDay <= t3)
				{
					result = SkyInfo.SkyType.Night;
				}
				else if (timeOfDay > t3 && timeOfDay < t4)
				{
					result = SkyInfo.SkyType.Dawn;
				}
				else if (timeOfDay > t5 && timeOfDay < t6)
				{
					result = SkyInfo.SkyType.Dusk;
				}
				else
				{
					result = SkyInfo.SkyType.Day;
				}
			}
			else if (timeOfDay >= t6 && timeOfDay <= t3)
			{
				result = SkyInfo.SkyType.Night;
			}
			else if (timeOfDay > t3 && timeOfDay < t4)
			{
				result = SkyInfo.SkyType.Dawn;
			}
			else if (timeOfDay > t5 && timeOfDay < t6)
			{
				result = SkyInfo.SkyType.Dusk;
			}
			else
			{
				result = SkyInfo.SkyType.Day;
			}
			return result;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0000405C File Offset: 0x0000225C
		public static SkyInfo.SkyType GetCurrentApocSkyType()
		{
			string @string = ModSettings.GetString("Apocalypse Skybox", "curtis.day.night.sync");
			if (@string == "None")
			{
				return SkyInfo.GetCurrentPermSkyType();
			}
			return SkyInfo.StringToSkyType(@string);
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00004094 File Offset: 0x00002294
		public static Color GetSkyColor(SkyInfo.SkyType skyType)
		{
			Color result;
			switch (skyType)
			{
			case SkyInfo.SkyType.Day:
				result = ModSettings.GetColor("Day Shader Color", "curtis.day.night.sync");
				if (SkyInfo.Phase == "Night")
				{
					result = ModSettings.GetColor("Day Shader Color (Night)", "curtis.day.night.sync");
				}
				break;
			case SkyInfo.SkyType.Night:
				result = ModSettings.GetColor("Night Shader Color", "curtis.day.night.sync");
				if (SkyInfo.Phase == "Night")
				{
					result = ModSettings.GetColor("Night Shader Color (Night)", "curtis.day.night.sync");
				}
				break;
			case SkyInfo.SkyType.Dawn:
				result = ModSettings.GetColor("Dawn Shader Color", "curtis.day.night.sync");
				if (SkyInfo.Phase == "Night")
				{
					result = ModSettings.GetColor("Dawn Shader Color (Night)", "curtis.day.night.sync");
				}
				break;
			case SkyInfo.SkyType.Dusk:
				result = ModSettings.GetColor("Dusk Shader Color", "curtis.day.night.sync");
				if (SkyInfo.Phase == "Night")
				{
					result = ModSettings.GetColor("Dusk Shader Color (Night)", "curtis.day.night.sync");
				}
				break;
			case SkyInfo.SkyType.BloodMoon:
				result = ModSettings.GetColor("Blood Moon Shader Color", "curtis.day.night.sync");
				if (SkyInfo.Phase == "Night")
				{
					result = ModSettings.GetColor("Blood Moon Shader Color (Night)", "curtis.day.night.sync");
				}
				break;
			case SkyInfo.SkyType.Storm:
				result = ModSettings.GetColor("Storm Shader Color", "curtis.day.night.sync");
				if (SkyInfo.Phase == "Night")
				{
					result = ModSettings.GetColor("Storm Shader Color (Night)", "curtis.day.night.sync");
				}
				break;
			case SkyInfo.SkyType.Eclipse:
				result = ModSettings.GetColor("Eclipse Shader Color", "curtis.day.night.sync");
				if (SkyInfo.Phase == "Night")
				{
					result = ModSettings.GetColor("Eclipse Shader Color (Night)", "curtis.day.night.sync");
				}
				break;
			case SkyInfo.SkyType.Winter:
				result = ModSettings.GetColor("Winter Shader Color", "curtis.day.night.sync");
				if (SkyInfo.Phase == "Night")
				{
					result = ModSettings.GetColor("Winter Shader Color (Night)", "curtis.day.night.sync");
				}
				break;
			default:
				result = Color.white;
				break;
			}
			return result;
		}

		// Token: 0x04000027 RID: 39
		public static SkyControllerPlus Instance = new SkyControllerPlus();

		// Token: 0x04000028 RID: 40
		public static string Phase = "NotGame";

		// Token: 0x0200000E RID: 14
		public enum SkyType
		{
			// Token: 0x0400002A RID: 42
			None,
			// Token: 0x0400002B RID: 43
			Random,
			// Token: 0x0400002C RID: 44
			Day,
			// Token: 0x0400002D RID: 45
			Night,
			// Token: 0x0400002E RID: 46
			Dawn,
			// Token: 0x0400002F RID: 47
			Dusk,
			// Token: 0x04000030 RID: 48
			BloodMoon,
			// Token: 0x04000031 RID: 49
			Storm,
			// Token: 0x04000032 RID: 50
			Eclipse,
			// Token: 0x04000033 RID: 51
			Winter
		}
	}
}
