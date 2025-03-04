using System;
using SML;
using UnityEngine;

namespace SkyControllerPP
{
	// Token: 0x02000018 RID: 24
	public class SkyInfo
	{
		// Token: 0x06000099 RID: 153 RVA: 0x00006534 File Offset: 0x00004734
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

		// Token: 0x0600009A RID: 154 RVA: 0x0000665C File Offset: 0x0000485C
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

		// Token: 0x0600009B RID: 155 RVA: 0x000069B0 File Offset: 0x00004BB0
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

		// Token: 0x0600009C RID: 156 RVA: 0x00006AD0 File Offset: 0x00004CD0
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

		// Token: 0x0600009D RID: 157 RVA: 0x00006B0C File Offset: 0x00004D0C
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
			case SkyInfo.SkyType.Void:
				result = ModSettings.GetColor("Void Shader Color", "curtis.day.night.sync");
				if (SkyInfo.Phase == "Night")
				{
					result = ModSettings.GetColor("Void Shader Color (Night)", "curtis.day.night.sync");
				}
				break;
			default:
				result = Color.white;
				break;
			}
			return result;
		}

		// Token: 0x04000055 RID: 85
		public static SkyControllerPlus Instance = new SkyControllerPlus();

		// Token: 0x04000056 RID: 86
		public static string Phase = "NotGame";

		// Token: 0x04000057 RID: 87
		public static string TOD = "Day";

		// Token: 0x04000058 RID: 88
		public static SkyboxController Already;

		// Token: 0x04000059 RID: 89
		public static SkyInfo.SkyType CurrentActive;

		// Token: 0x02000019 RID: 25
		public enum SkyType
		{
			// Token: 0x0400005B RID: 91
			None,
			// Token: 0x0400005C RID: 92
			Random,
			// Token: 0x0400005D RID: 93
			Day,
			// Token: 0x0400005E RID: 94
			Night,
			// Token: 0x0400005F RID: 95
			Dawn,
			// Token: 0x04000060 RID: 96
			Dusk,
			// Token: 0x04000061 RID: 97
			BloodMoon,
			// Token: 0x04000062 RID: 98
			Storm,
			// Token: 0x04000063 RID: 99
			Eclipse,
			// Token: 0x04000064 RID: 100
			Winter,
			// Token: 0x04000065 RID: 101
			Void
		}
	}
}
