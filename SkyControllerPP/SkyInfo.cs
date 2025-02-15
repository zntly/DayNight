using System;
using SML;
using UnityEngine;

namespace SkyControllerPP
{
	// Token: 0x02000012 RID: 18
	public class SkyInfo
	{
		// Token: 0x06000056 RID: 86 RVA: 0x00005EB4 File Offset: 0x000040B4
		public static SkyInfo.SkyType StringToSkyType(string s)
		{
			bool flag = s != null;
			if (flag)
			{
				switch (s.Length)
				{
				case 3:
				{
					bool flag2 = s == "Day";
					if (flag2)
					{
						return SkyInfo.SkyType.Day;
					}
					break;
				}
				case 4:
				{
					char c = s[1];
					bool flag3 = c != 'a';
					if (flag3)
					{
						bool flag4 = c == 'u' && s == "Dusk";
						if (flag4)
						{
							return SkyInfo.SkyType.Dusk;
						}
					}
					else
					{
						bool flag5 = s == "Dawn";
						if (flag5)
						{
							return SkyInfo.SkyType.Dawn;
						}
					}
					break;
				}
				case 5:
				{
					char c2 = s[0];
					bool flag6 = c2 != 'N';
					if (flag6)
					{
						bool flag7 = c2 == 'S' && s == "Storm";
						if (flag7)
						{
							return SkyInfo.SkyType.Storm;
						}
					}
					else
					{
						bool flag8 = s == "Night";
						if (flag8)
						{
							return SkyInfo.SkyType.Night;
						}
					}
					break;
				}
				case 6:
				{
					char c3 = s[0];
					bool flag9 = c3 != 'R';
					if (flag9)
					{
						bool flag10 = c3 == 'W' && s == "Winter";
						if (flag10)
						{
							return SkyInfo.SkyType.Winter;
						}
					}
					else
					{
						bool flag11 = s == "Random";
						if (flag11)
						{
							return SkyInfo.SkyType.Random;
						}
					}
					break;
				}
				case 7:
				{
					bool flag12 = s == "Eclipse";
					if (flag12)
					{
						return SkyInfo.SkyType.Eclipse;
					}
					break;
				}
				case 10:
				{
					bool flag13 = s == "Blood Moon";
					if (flag13)
					{
						return SkyInfo.SkyType.BloodMoon;
					}
					break;
				}
				}
			}
			return SkyInfo.SkyType.None;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00006070 File Offset: 0x00004270
		public static SkyInfo.SkyType GetCurrentPermSkyType()
		{
			bool flag = SkyInfo.Phase == "NotGame";
			SkyInfo.SkyType result;
			if (flag)
			{
				result = SkyInfo.StringToSkyType(ModSettings.GetString("Default Skybox", "curtis.day.night.sync"));
			}
			else
			{
				bool flag2 = SkyInfo.Phase == "Day" && ModSettings.GetString("Day Skybox", "curtis.day.night.sync") != "None" && ModSettings.GetString("Default Skybox", "curtis.day.night.sync") != "None";
				if (flag2)
				{
					result = SkyInfo.StringToSkyType(ModSettings.GetString("Day Skybox", "curtis.day.night.sync"));
				}
				else
				{
					bool flag3 = SkyInfo.Phase == "Night" && ModSettings.GetString("Night Skybox", "curtis.day.night.sync") != "None" && ModSettings.GetString("Default Skybox", "curtis.day.night.sync") != "None";
					if (flag3)
					{
						result = SkyInfo.StringToSkyType(ModSettings.GetString("Night Skybox", "curtis.day.night.sync"));
					}
					else
					{
						bool flag4 = SkyInfo.Phase == "Daybreak" && ModSettings.GetString("Daybreak Skybox", "curtis.day.night.sync") != "None";
						if (flag4)
						{
							result = SkyInfo.StringToSkyType(ModSettings.GetString("Daybreak Skybox", "curtis.day.night.sync"));
						}
						else
						{
							bool flag5 = SkyInfo.Phase == "Court" && ModSettings.GetString("Court Skybox", "curtis.day.night.sync") != "None";
							if (flag5)
							{
								result = SkyInfo.StringToSkyType(ModSettings.GetString("Court Skybox", "curtis.day.night.sync"));
							}
							else
							{
								bool flag6 = SkyInfo.Phase == "Tribunal" && ModSettings.GetString("Tribunal Skybox", "curtis.day.night.sync") != "None";
								if (flag6)
								{
									result = SkyInfo.StringToSkyType(ModSettings.GetString("Tribunal Skybox", "curtis.day.night.sync"));
								}
								else
								{
									bool flag7 = SkyInfo.Phase == "Daybreak" && ModSettings.GetString("Daybreak Skybox", "curtis.day.night.sync") == "None" && ModSettings.GetString("Day Skybox", "curtis.day.night.sync") != "None" && ModSettings.GetString("Default Skybox", "curtis.day.night.sync") != "None";
									if (flag7)
									{
										result = SkyInfo.StringToSkyType(ModSettings.GetString("Day Skybox", "curtis.day.night.sync"));
									}
									else
									{
										bool flag8 = SkyInfo.Phase == "Court" && ModSettings.GetString("Court Skybox", "curtis.day.night.sync") == "None" && ModSettings.GetString("Day Skybox", "curtis.day.night.sync") != "None" && ModSettings.GetString("Default Skybox", "curtis.day.night.sync") != "None";
										if (flag8)
										{
											result = SkyInfo.StringToSkyType(ModSettings.GetString("Day Skybox", "curtis.day.night.sync"));
										}
										else
										{
											bool flag9 = SkyInfo.Phase == "Tribunal" && ModSettings.GetString("Tribunal Skybox", "curtis.day.night.sync") == "None" && ModSettings.GetString("Day Skybox", "curtis.day.night.sync") != "None" && ModSettings.GetString("Default Skybox", "curtis.day.night.sync") != "None";
											if (flag9)
											{
												result = SkyInfo.StringToSkyType(ModSettings.GetString("Day Skybox", "curtis.day.night.sync"));
											}
											else
											{
												result = SkyInfo.StringToSkyType(ModSettings.GetString("Default Skybox", "curtis.day.night.sync"));
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00006408 File Offset: 0x00004608
		public static SkyInfo.SkyType GetSyncedSkyType()
		{
			bool flag = SkyInfo.TOD == "Night";
			SkyInfo.SkyType result;
			if (flag)
			{
				bool flag2 = ModSettings.GetString("Night Skybox", "curtis.day.night.sync") != "None";
				if (flag2)
				{
					result = SkyInfo.StringToSkyType(ModSettings.GetString("Night Skybox", "curtis.day.night.sync"));
				}
				else
				{
					result = SkyInfo.SkyType.Night;
				}
			}
			else
			{
				bool flag3 = SkyInfo.TOD == "Dawn";
				if (flag3)
				{
					bool flag4 = ModSettings.GetString("Dawn Skybox", "curtis.day.night.sync") != "None";
					if (flag4)
					{
						result = SkyInfo.StringToSkyType(ModSettings.GetString("Dawn Skybox", "curtis.day.night.sync"));
					}
					else
					{
						result = SkyInfo.SkyType.Dawn;
					}
				}
				else
				{
					bool flag5 = SkyInfo.TOD == "Dusk";
					if (flag5)
					{
						bool flag6 = ModSettings.GetString("Dusk Skybox", "curtis.day.night.sync") != "None";
						if (flag6)
						{
							result = SkyInfo.StringToSkyType(ModSettings.GetString("Dusk Skybox", "curtis.day.night.sync"));
						}
						else
						{
							result = SkyInfo.SkyType.Dusk;
						}
					}
					else
					{
						bool flag7 = ModSettings.GetString("Day Skybox", "curtis.day.night.sync") != "None";
						if (flag7)
						{
							result = SkyInfo.StringToSkyType(ModSettings.GetString("Day Skybox", "curtis.day.night.sync"));
						}
						else
						{
							result = SkyInfo.SkyType.Day;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00006558 File Offset: 0x00004758
		public static SkyInfo.SkyType GetCurrentApocSkyType()
		{
			string @string = ModSettings.GetString("Apocalypse Skybox", "curtis.day.night.sync");
			bool flag = @string == "None";
			SkyInfo.SkyType result;
			if (flag)
			{
				result = SkyInfo.GetCurrentPermSkyType();
			}
			else
			{
				result = SkyInfo.StringToSkyType(@string);
			}
			return result;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00006598 File Offset: 0x00004798
		public static Color GetSkyColor(SkyInfo.SkyType skyType)
		{
			Color result;
			switch (skyType)
			{
			case SkyInfo.SkyType.Day:
			{
				result = ModSettings.GetColor("Day Shader Color", "curtis.day.night.sync");
				bool flag = SkyInfo.Phase == "Night";
				if (flag)
				{
					result = ModSettings.GetColor("Day Shader Color (Night)", "curtis.day.night.sync");
				}
				break;
			}
			case SkyInfo.SkyType.Night:
			{
				result = ModSettings.GetColor("Night Shader Color", "curtis.day.night.sync");
				bool flag2 = SkyInfo.Phase == "Night";
				if (flag2)
				{
					result = ModSettings.GetColor("Night Shader Color (Night)", "curtis.day.night.sync");
				}
				break;
			}
			case SkyInfo.SkyType.Dawn:
			{
				result = ModSettings.GetColor("Dawn Shader Color", "curtis.day.night.sync");
				bool flag3 = SkyInfo.Phase == "Night";
				if (flag3)
				{
					result = ModSettings.GetColor("Dawn Shader Color (Night)", "curtis.day.night.sync");
				}
				break;
			}
			case SkyInfo.SkyType.Dusk:
			{
				result = ModSettings.GetColor("Dusk Shader Color", "curtis.day.night.sync");
				bool flag4 = SkyInfo.Phase == "Night";
				if (flag4)
				{
					result = ModSettings.GetColor("Dusk Shader Color (Night)", "curtis.day.night.sync");
				}
				break;
			}
			case SkyInfo.SkyType.BloodMoon:
			{
				result = ModSettings.GetColor("Blood Moon Shader Color", "curtis.day.night.sync");
				bool flag5 = SkyInfo.Phase == "Night";
				if (flag5)
				{
					result = ModSettings.GetColor("Blood Moon Shader Color (Night)", "curtis.day.night.sync");
				}
				break;
			}
			case SkyInfo.SkyType.Storm:
			{
				result = ModSettings.GetColor("Storm Shader Color", "curtis.day.night.sync");
				bool flag6 = SkyInfo.Phase == "Night";
				if (flag6)
				{
					result = ModSettings.GetColor("Storm Shader Color (Night)", "curtis.day.night.sync");
				}
				break;
			}
			case SkyInfo.SkyType.Eclipse:
			{
				result = ModSettings.GetColor("Eclipse Shader Color", "curtis.day.night.sync");
				bool flag7 = SkyInfo.Phase == "Night";
				if (flag7)
				{
					result = ModSettings.GetColor("Eclipse Shader Color (Night)", "curtis.day.night.sync");
				}
				break;
			}
			case SkyInfo.SkyType.Winter:
			{
				result = ModSettings.GetColor("Winter Shader Color", "curtis.day.night.sync");
				bool flag8 = SkyInfo.Phase == "Night";
				if (flag8)
				{
					result = ModSettings.GetColor("Winter Shader Color (Night)", "curtis.day.night.sync");
				}
				break;
			}
			default:
				result = Color.white;
				break;
			}
			return result;
		}

		// Token: 0x0400001E RID: 30
		public static SkyControllerPlus Instance = new SkyControllerPlus();

		// Token: 0x0400001F RID: 31
		public static string Phase = "NotGame";

		// Token: 0x04000020 RID: 32
		public static string TOD = "Day";

		// Token: 0x04000021 RID: 33
		public static SkyboxController Already;

		// Token: 0x04000022 RID: 34
		public static SkyInfo.SkyType CurrentActive;

		// Token: 0x0200001A RID: 26
		public enum SkyType
		{
			// Token: 0x04000053 RID: 83
			None,
			// Token: 0x04000054 RID: 84
			Random,
			// Token: 0x04000055 RID: 85
			Day,
			// Token: 0x04000056 RID: 86
			Night,
			// Token: 0x04000057 RID: 87
			Dawn,
			// Token: 0x04000058 RID: 88
			Dusk,
			// Token: 0x04000059 RID: 89
			BloodMoon,
			// Token: 0x0400005A RID: 90
			Storm,
			// Token: 0x0400005B RID: 91
			Eclipse,
			// Token: 0x0400005C RID: 92
			Winter
		}
	}
}
