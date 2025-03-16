using System;
using SML;
using UnityEngine;

namespace SkyControllerPP
{
	// Token: 0x02000018 RID: 24
	public class SkyInfo
	{
		// Token: 0x0600009F RID: 159
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
						if (c == 'o' && s == "Void")
						{
							return SkyInfo.SkyType.Void;
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
						if (c2 == 'G' && s == "Greek")
						{
							return SkyInfo.SkyType.Greek;
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

		// Token: 0x060000A0 RID: 160
		public static SkyInfo.SkyType GetCurrentPermSkyType()
		{
			SkyInfo.SkyType result;
			if (SkyInfo.Phase == "NotGame")
			{
				result = SkyInfo.StringToSkyType(ModSettings.GetString("Default Skybox", "curtis.day.night.sync"));
			}
			else if (SkyInfo.Phase == "Day" && ModSettings.GetString("Day Skybox", "curtis.day.night.sync") != "None" && ModSettings.GetString("Default Skybox", "curtis.day.night.sync") != "None")
			{
				result = SkyInfo.StringToSkyType(ModSettings.GetString("Day Skybox", "curtis.day.night.sync"));
			}
			else if (SkyInfo.Phase == "Night" && ModSettings.GetString("Night Skybox", "curtis.day.night.sync") != "None" && ModSettings.GetString("Default Skybox", "curtis.day.night.sync") != "None")
			{
				result = SkyInfo.StringToSkyType(ModSettings.GetString("Night Skybox", "curtis.day.night.sync"));
			}
			else if (SkyInfo.Phase == "Daybreak" && ModSettings.GetString("Daybreak Skybox", "curtis.day.night.sync") != "None")
			{
				result = SkyInfo.StringToSkyType(ModSettings.GetString("Daybreak Skybox", "curtis.day.night.sync"));
			}
			else if (SkyInfo.Phase == "Court" && ModSettings.GetString("Court Skybox", "curtis.day.night.sync") != "None")
			{
				result = SkyInfo.StringToSkyType(ModSettings.GetString("Court Skybox", "curtis.day.night.sync"));
			}
			else if (SkyInfo.Phase == "Tribunal" && ModSettings.GetString("Tribunal Skybox", "curtis.day.night.sync") != "None")
			{
				result = SkyInfo.StringToSkyType(ModSettings.GetString("Tribunal Skybox", "curtis.day.night.sync"));
			}
			else if (SkyInfo.Phase == "Daybreak" && ModSettings.GetString("Daybreak Skybox", "curtis.day.night.sync") == "None" && ModSettings.GetString("Day Skybox", "curtis.day.night.sync") != "None" && ModSettings.GetString("Default Skybox", "curtis.day.night.sync") != "None")
			{
				result = SkyInfo.StringToSkyType(ModSettings.GetString("Day Skybox", "curtis.day.night.sync"));
			}
			else if (SkyInfo.Phase == "Court" && ModSettings.GetString("Court Skybox", "curtis.day.night.sync") == "None" && ModSettings.GetString("Day Skybox", "curtis.day.night.sync") != "None" && ModSettings.GetString("Default Skybox", "curtis.day.night.sync") != "None")
			{
				result = SkyInfo.StringToSkyType(ModSettings.GetString("Day Skybox", "curtis.day.night.sync"));
			}
			else if (SkyInfo.Phase == "Tribunal" && ModSettings.GetString("Tribunal Skybox", "curtis.day.night.sync") == "None" && ModSettings.GetString("Day Skybox", "curtis.day.night.sync") != "None" && ModSettings.GetString("Default Skybox", "curtis.day.night.sync") != "None")
			{
				result = SkyInfo.StringToSkyType(ModSettings.GetString("Day Skybox", "curtis.day.night.sync"));
			}
			else
			{
				result = SkyInfo.StringToSkyType(ModSettings.GetString("Default Skybox", "curtis.day.night.sync"));
			}
			return result;
		}

		// Token: 0x060000A1 RID: 161
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

		// Token: 0x060000A2 RID: 162
		public static SkyInfo.SkyType GetCurrentApocSkyType()
		{
			string @string = ModSettings.GetString("Apocalypse Skybox", "curtis.day.night.sync");
			SkyInfo.SkyType result;
			if (@string == "None")
			{
				result = SkyInfo.GetCurrentPermSkyType();
			}
			else
			{
				result = SkyInfo.StringToSkyType(@string);
			}
			return result;
		}

		// Token: 0x060000A3 RID: 163
		public static Color GetSkyColor(SkyInfo.SkyType skyType)
		{
			switch (skyType)
			{
			case SkyInfo.SkyType.Day:
			{
				Color color = ModSettings.GetColor("Day Shader Color", "curtis.day.night.sync");
				if (SkyInfo.Phase == "Night")
				{
					return ModSettings.GetColor("Day Shader Color (Night)", "curtis.day.night.sync");
				}
				return color;
			}
			case SkyInfo.SkyType.Night:
			{
				Color color2 = ModSettings.GetColor("Night Shader Color", "curtis.day.night.sync");
				if (SkyInfo.Phase == "Night")
				{
					return ModSettings.GetColor("Night Shader Color (Night)", "curtis.day.night.sync");
				}
				return color2;
			}
			case SkyInfo.SkyType.Dawn:
			{
				Color color3 = ModSettings.GetColor("Dawn Shader Color", "curtis.day.night.sync");
				if (SkyInfo.Phase == "Night")
				{
					return ModSettings.GetColor("Dawn Shader Color (Night)", "curtis.day.night.sync");
				}
				return color3;
			}
			case SkyInfo.SkyType.Dusk:
			{
				Color color4 = ModSettings.GetColor("Dusk Shader Color", "curtis.day.night.sync");
				if (SkyInfo.Phase == "Night")
				{
					return ModSettings.GetColor("Dusk Shader Color (Night)", "curtis.day.night.sync");
				}
				return color4;
			}
			case SkyInfo.SkyType.BloodMoon:
			{
				Color color5 = ModSettings.GetColor("Blood Moon Shader Color", "curtis.day.night.sync");
				if (SkyInfo.Phase == "Night")
				{
					return ModSettings.GetColor("Blood Moon Shader Color (Night)", "curtis.day.night.sync");
				}
				return color5;
			}
			case SkyInfo.SkyType.Storm:
			{
				Color color6 = ModSettings.GetColor("Storm Shader Color", "curtis.day.night.sync");
				if (SkyInfo.Phase == "Night")
				{
					return ModSettings.GetColor("Storm Shader Color (Night)", "curtis.day.night.sync");
				}
				return color6;
			}
			case SkyInfo.SkyType.Eclipse:
			{
				Color color7 = ModSettings.GetColor("Eclipse Shader Color", "curtis.day.night.sync");
				if (SkyInfo.Phase == "Night")
				{
					return ModSettings.GetColor("Eclipse Shader Color (Night)", "curtis.day.night.sync");
				}
				return color7;
			}
			case SkyInfo.SkyType.Winter:
			{
				Color color8 = ModSettings.GetColor("Winter Shader Color", "curtis.day.night.sync");
				if (SkyInfo.Phase == "Night")
				{
					return ModSettings.GetColor("Winter Shader Color (Night)", "curtis.day.night.sync");
				}
				return color8;
			}
			case SkyInfo.SkyType.Greek:
			{
				Color color9 = ModSettings.GetColor("Greek Shader Color", "curtis.day.night.sync");
				if (SkyInfo.Phase == "Night")
				{
					return ModSettings.GetColor("Greek Shader Color (Night)", "curtis.day.night.sync");
				}
				return color9;
			}
			case SkyInfo.SkyType.Void:
			{
				Color color10 = ModSettings.GetColor("Void Shader Color", "curtis.day.night.sync");
				if (SkyInfo.Phase == "Night")
				{
					return ModSettings.GetColor("Void Shader Color (Night)", "curtis.day.night.sync");
				}
				return color10;
			}
			default:
				return Color.white;
			}
		}

		// Token: 0x0400005A RID: 90
		public static SkyControllerPlus Instance = new SkyControllerPlus();

		// Token: 0x0400005B RID: 91
		public static string Phase = "NotGame";

		// Token: 0x0400005C RID: 92
		public static string TOD = "Day";

		// Token: 0x0400005D RID: 93
		public static SkyboxController Already;

		// Token: 0x0400005E RID: 94
		public static SkyInfo.SkyType CurrentActive;

		// Token: 0x02000019 RID: 25
		public enum SkyType
		{
			// Token: 0x04000060 RID: 96
			None,
			// Token: 0x04000061 RID: 97
			Random,
			// Token: 0x04000062 RID: 98
			Day,
			// Token: 0x04000063 RID: 99
			Night,
			// Token: 0x04000064 RID: 100
			Dawn,
			// Token: 0x04000065 RID: 101
			Dusk,
			// Token: 0x04000066 RID: 102
			BloodMoon,
			// Token: 0x04000067 RID: 103
			Storm,
			// Token: 0x04000068 RID: 104
			Eclipse,
			// Token: 0x04000069 RID: 105
			Winter,
			// Token: 0x0400006A RID: 106
			Void = 11,
			// Token: 0x0400006B RID: 107
			Greek = 10
		}
	}
}
