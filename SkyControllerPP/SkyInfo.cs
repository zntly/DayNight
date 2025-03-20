using System;
using Server.Shared.Extensions;
using SML;
using UnityEngine;

namespace SkyControllerPP
{
	// Token: 0x0200001A RID: 26
	public class SkyInfo
	{
		// Token: 0x060000B2 RID: 178 RVA: 0x00007CC8 File Offset: 0x00005EC8
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

		// Token: 0x060000B3 RID: 179 RVA: 0x00007E04 File Offset: 0x00006004
		public static SkyInfo.SkyType GetCurrentPermSkyType()
		{
			SkyInfo.SkyType result;
			if (SkyInfo.Phase == "NotGame")
			{
				result = SkyInfo.StringToSkyType((string)Settings.SettingsCache.GetValue("Default Skybox", null));
			}
			else if (SkyInfo.Phase == "Day" && (string)Settings.SettingsCache.GetValue("Day Skybox", null) != "None" && (string)Settings.SettingsCache.GetValue("Default Skybox", null) != "None")
			{
				result = SkyInfo.StringToSkyType((string)Settings.SettingsCache.GetValue("Day Skybox", null));
			}
			else if (SkyInfo.Phase == "Night" && (string)Settings.SettingsCache.GetValue("Night Skybox", null) != "None" && (string)Settings.SettingsCache.GetValue("Default Skybox", null) != "None")
			{
				result = SkyInfo.StringToSkyType((string)Settings.SettingsCache.GetValue("Night Skybox", null));
			}
			else if (SkyInfo.Phase == "Daybreak" && (string)Settings.SettingsCache.GetValue("Daybreak Skybox", null) != "None")
			{
				result = SkyInfo.StringToSkyType((string)Settings.SettingsCache.GetValue("Daybreak Skybox", null));
			}
			else if (SkyInfo.Phase == "Court" && (string)Settings.SettingsCache.GetValue("Court Skybox", null) != "None")
			{
				result = SkyInfo.StringToSkyType((string)Settings.SettingsCache.GetValue("Court Skybox", null));
			}
			else if (SkyInfo.Phase == "Tribunal" && (string)Settings.SettingsCache.GetValue("Tribunal Skybox", null) != "None")
			{
				result = SkyInfo.StringToSkyType((string)Settings.SettingsCache.GetValue("Tribunal Skybox", null));
			}
			else if (SkyInfo.Phase == "Daybreak" && (string)Settings.SettingsCache.GetValue("Daybreak Skybox", null) == "None" && (string)Settings.SettingsCache.GetValue("Day Skybox", null) != "None" && (string)Settings.SettingsCache.GetValue("Default Skybox", null) != "None")
			{
				result = SkyInfo.StringToSkyType((string)Settings.SettingsCache.GetValue("Day Skybox", null));
			}
			else if (SkyInfo.Phase == "Court" && (string)Settings.SettingsCache.GetValue("Court Skybox", null) == "None" && (string)Settings.SettingsCache.GetValue("Day Skybox", null) != "None" && (string)Settings.SettingsCache.GetValue("Default Skybox", null) != "None")
			{
				result = SkyInfo.StringToSkyType((string)Settings.SettingsCache.GetValue("Day Skybox", null));
			}
			else if (SkyInfo.Phase == "Tribunal" && (string)Settings.SettingsCache.GetValue("Tribunal Skybox", null) == "None" && (string)Settings.SettingsCache.GetValue("Day Skybox", null) != "None" && (string)Settings.SettingsCache.GetValue("Default Skybox", null) != "None")
			{
				result = SkyInfo.StringToSkyType((string)Settings.SettingsCache.GetValue("Day Skybox", null));
			}
			else
			{
				result = SkyInfo.StringToSkyType((string)Settings.SettingsCache.GetValue("Default Skybox", null));
			}
			return result;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000081FC File Offset: 0x000063FC
		public static SkyInfo.SkyType GetSyncedSkyType()
		{
			SkyInfo.SkyType result;
			if (SkyInfo.TOD == "Night")
			{
				if ((string)Settings.SettingsCache.GetValue("Night Skybox", null) != "None")
				{
					result = SkyInfo.StringToSkyType((string)Settings.SettingsCache.GetValue("Night Skybox", null));
				}
				else
				{
					result = SkyInfo.SkyType.Night;
				}
			}
			else if (SkyInfo.TOD == "Dawn")
			{
				if ((string)Settings.SettingsCache.GetValue("Dawn Skybox", null) != "None")
				{
					result = SkyInfo.StringToSkyType((string)Settings.SettingsCache.GetValue("Dawn Skybox", null));
				}
				else
				{
					result = SkyInfo.SkyType.Dawn;
				}
			}
			else if (SkyInfo.TOD == "Dusk")
			{
				if ((string)Settings.SettingsCache.GetValue("Dusk Skybox", null) != "None")
				{
					result = SkyInfo.StringToSkyType((string)Settings.SettingsCache.GetValue("Dusk Skybox", null));
				}
				else
				{
					result = SkyInfo.SkyType.Dusk;
				}
			}
			else if ((string)Settings.SettingsCache.GetValue("Day Skybox", null) != "None")
			{
				result = SkyInfo.StringToSkyType((string)Settings.SettingsCache.GetValue("Day Skybox", null));
			}
			else
			{
				result = SkyInfo.SkyType.Day;
			}
			return result;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00008350 File Offset: 0x00006550
		public static SkyInfo.SkyType GetCurrentApocSkyType()
		{
			string text = (string)Settings.SettingsCache.GetValue("Apocalypse Skybox", null);
			SkyInfo.SkyType result;
			if (text == "None")
			{
				result = SkyInfo.GetCurrentPermSkyType();
			}
			else
			{
				result = SkyInfo.StringToSkyType(text);
			}
			return result;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00008390 File Offset: 0x00006590
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

		// Token: 0x04000063 RID: 99
		public static SkyControllerPlus Instance = new SkyControllerPlus();

		// Token: 0x04000064 RID: 100
		public static string Phase = "NotGame";

		// Token: 0x04000065 RID: 101
		public static string TOD = "Day";

		// Token: 0x04000066 RID: 102
		public static SkyboxController Already;

		// Token: 0x04000067 RID: 103
		public static SkyInfo.SkyType CurrentActive;

		// Token: 0x0200001B RID: 27
		public enum SkyType
		{
			// Token: 0x04000069 RID: 105
			None,
			// Token: 0x0400006A RID: 106
			Random,
			// Token: 0x0400006B RID: 107
			Day,
			// Token: 0x0400006C RID: 108
			Night,
			// Token: 0x0400006D RID: 109
			Dawn,
			// Token: 0x0400006E RID: 110
			Dusk,
			// Token: 0x0400006F RID: 111
			BloodMoon,
			// Token: 0x04000070 RID: 112
			Storm,
			// Token: 0x04000071 RID: 113
			Eclipse,
			// Token: 0x04000072 RID: 114
			Winter,
			// Token: 0x04000073 RID: 115
			Void = 11,
			// Token: 0x04000074 RID: 116
			Greek = 10
		}
	}
}
