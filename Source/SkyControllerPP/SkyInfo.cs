using System;
using SML;
using UnityEngine;

namespace SkyControllerPP
{
	// Token: 0x0200000D RID: 13
	public class SkyInfo
	{
		// Token: 0x0600005A RID: 90 RVA: 0x00004508 File Offset: 0x00002708
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

		// Token: 0x0600005B RID: 91 RVA: 0x0000461C File Offset: 0x0000281C
		public static SkyInfo.SkyType GetCurrentPermSkyType()
		{
			if (SkyInfo.Phase == "NotGame")
			{
				return SkyInfo.StringToSkyType(ModSettings.GetString("Default Skybox", "curtis.day.night.sync"));
			}
			if (SkyInfo.Phase == "Day" && ModSettings.GetString("Day Skybox", "curtis.day.night.sync") != "None" && ModSettings.GetString("Default Skybox", "curtis.day.night.sync") != "None")
			{
				return SkyInfo.StringToSkyType(ModSettings.GetString("Day Skybox", "curtis.day.night.sync"));
			}
			if (SkyInfo.Phase == "Night" && ModSettings.GetString("Night Skybox", "curtis.day.night.sync") != "None" && ModSettings.GetString("Default Skybox", "curtis.day.night.sync") != "None")
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
			if (SkyInfo.Phase == "Daybreak" && ModSettings.GetString("Daybreak Skybox", "curtis.day.night.sync") == "None" && ModSettings.GetString("Day Skybox", "curtis.day.night.sync") != "None" && ModSettings.GetString("Default Skybox", "curtis.day.night.sync") != "None")
			{
				return SkyInfo.StringToSkyType(ModSettings.GetString("Day Skybox", "curtis.day.night.sync"));
			}
			if (SkyInfo.Phase == "Court" && ModSettings.GetString("Court Skybox", "curtis.day.night.sync") == "None" && ModSettings.GetString("Day Skybox", "curtis.day.night.sync") != "None" && ModSettings.GetString("Default Skybox", "curtis.day.night.sync") != "None")
			{
				return SkyInfo.StringToSkyType(ModSettings.GetString("Day Skybox", "curtis.day.night.sync"));
			}
			if (SkyInfo.Phase == "Tribunal" && ModSettings.GetString("Tribunal Skybox", "curtis.day.night.sync") == "None" && ModSettings.GetString("Day Skybox", "curtis.day.night.sync") != "None" && ModSettings.GetString("Default Skybox", "curtis.day.night.sync") != "None")
			{
				return SkyInfo.StringToSkyType(ModSettings.GetString("Day Skybox", "curtis.day.night.sync"));
			}
			return SkyInfo.StringToSkyType(ModSettings.GetString("Default Skybox", "curtis.day.night.sync"));
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00004944 File Offset: 0x00002B44
		public static SkyInfo.SkyType GetSyncedSkyType()
		{
			SkyInfo.SkyType result;
			if (SkyInfo.TOD == "Night")
			{
				if (ModSettings.GetString("Night Skybox", "curtis.day.night.sync") != "None")
				{
					result = SkyInfo.StringToSkyType(ModSettings.GetString("Night Skybox", "curtis.day.night.sync"));
				}
				else
				{
					result = SkyInfo.SkyType.Night;
				}
			}
			else if (SkyInfo.TOD == "Dawn")
			{
				if (ModSettings.GetString("Dawn Skybox", "curtis.day.night.sync") != "None")
				{
					result = SkyInfo.StringToSkyType(ModSettings.GetString("Dawn Skybox", "curtis.day.night.sync"));
				}
				else
				{
					result = SkyInfo.SkyType.Dawn;
				}
			}
			else if (SkyInfo.TOD == "Dusk")
			{
				if (ModSettings.GetString("Dusk Skybox", "curtis.day.night.sync") != "None")
				{
					result = SkyInfo.StringToSkyType(ModSettings.GetString("Dusk Skybox", "curtis.day.night.sync"));
				}
				else
				{
					result = SkyInfo.SkyType.Dusk;
				}
			}
			else if (ModSettings.GetString("Day Skybox", "curtis.day.night.sync") != "None")
			{
				result = SkyInfo.StringToSkyType(ModSettings.GetString("Day Skybox", "curtis.day.night.sync"));
			}
			else
			{
				result = SkyInfo.SkyType.Day;
			}
			return result;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00004A64 File Offset: 0x00002C64
		public static SkyInfo.SkyType GetCurrentApocSkyType()
		{
			string @string = ModSettings.GetString("Apocalypse Skybox", "curtis.day.night.sync");
			if (@string == "None")
			{
				return SkyInfo.GetCurrentPermSkyType();
			}
			return SkyInfo.StringToSkyType(@string);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00004A9C File Offset: 0x00002C9C
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

		// Token: 0x0400002A RID: 42
		public static SkyControllerPlus Instance = new SkyControllerPlus();

		// Token: 0x0400002B RID: 43
		public static string Phase = "NotGame";

		// Token: 0x0400002C RID: 44
		public static string TOD = "Day";

		// Token: 0x0400002D RID: 45
		public static SkyboxController Already;

		// Token: 0x0200000E RID: 14
		public enum SkyType
		{
			// Token: 0x0400002F RID: 47
			None,
			// Token: 0x04000030 RID: 48
			Random,
			// Token: 0x04000031 RID: 49
			Day,
			// Token: 0x04000032 RID: 50
			Night,
			// Token: 0x04000033 RID: 51
			Dawn,
			// Token: 0x04000034 RID: 52
			Dusk,
			// Token: 0x04000035 RID: 53
			BloodMoon,
			// Token: 0x04000036 RID: 54
			Storm,
			// Token: 0x04000037 RID: 55
			Eclipse,
			// Token: 0x04000038 RID: 56
			Winter
		}
	}
}
