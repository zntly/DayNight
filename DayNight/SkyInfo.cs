using System;
using Server.Shared.Extensions;
using SML;
using UnityEngine;

namespace DayNight
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
                                else
                                {
                                    return SkyInfo.SkyType.Mafia;
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
                        Color color = Settings.ColorCache.GetValue("Day Shader Color");
                        if (SkyInfo.Phase == "Night")
                        {
                            return Settings.ColorCache.GetValue("Day Shader Color (Night)");
                        }
                        return color;
                    }
                case SkyInfo.SkyType.Night:
                    {
                        Color color2 = Settings.ColorCache.GetValue("Night Shader Color");
                        if (SkyInfo.Phase == "Night")
                        {
                            return Settings.ColorCache.GetValue("Night Shader Color (Night)");
                        }
                        return color2;
                    }
                case SkyInfo.SkyType.Dawn:
                    {
                        Color color3 = Settings.ColorCache.GetValue("Dawn Shader Color");
                        if (SkyInfo.Phase == "Night")
                        {
                            return Settings.ColorCache.GetValue("Dawn Shader Color (Night)");
                        }
                        return color3;
                    }
                case SkyInfo.SkyType.Dusk:
                    {
                        Color color4 = Settings.ColorCache.GetValue("Dusk Shader Color");
                        if (SkyInfo.Phase == "Night")
                        {
                            return Settings.ColorCache.GetValue("Dusk Shader Color (Night)");
                        }
                        return color4;
                    }
                case SkyInfo.SkyType.BloodMoon:
                    {
                        Color color5 = Settings.ColorCache.GetValue("Blood Moon Shader Color");
                        if (SkyInfo.Phase == "Night")
                        {
                            return Settings.ColorCache.GetValue("Blood Moon Shader Color (Night)");
                        }
                        return color5;
                    }
                case SkyInfo.SkyType.Storm:
                    {
                        Color color6 = Settings.ColorCache.GetValue("Storm Shader Color");
                        if (SkyInfo.Phase == "Night")
                        {
                            return Settings.ColorCache.GetValue("Storm Shader Color (Night)");
                        }
                        return color6;
                    }
                case SkyInfo.SkyType.Eclipse:
                    {
                        Color color7 = Settings.ColorCache.GetValue("Eclipse Shader Color");
                        if (SkyInfo.Phase == "Night")
                        {
                            return Settings.ColorCache.GetValue("Eclipse Shader Color (Night)");
                        }
                        return color7;
                    }
                case SkyInfo.SkyType.Winter:
                    {
                        Color color8 = Settings.ColorCache.GetValue("Winter Shader Color");
                        if (SkyInfo.Phase == "Night")
                        {
                            return Settings.ColorCache.GetValue("Winter Shader Color (Night)");
                        }
                        return color8;
                    }
                case SkyInfo.SkyType.Greek:
                    {
                        Color color9 = Settings.ColorCache.GetValue("Greek Shader Color");
                        if (SkyInfo.Phase == "Night")
                        {
                            return Settings.ColorCache.GetValue("Greek Shader Color (Night)");
                        }
                        return color9;
                    }
                case SkyInfo.SkyType.Mafia:
                    {
                        Color color10 = Settings.ColorCache.GetValue("Mafia Shader Color");
                        if (SkyInfo.Phase == "Night")
                        {
                            return Settings.ColorCache.GetValue("Mafia Shader Color (Night)");
                        }
                        return color10;
                    }
                case SkyInfo.SkyType.Void:
                    {
                        Color color11 = Settings.ColorCache.GetValue("Void Shader Color");
                        if (SkyInfo.Phase == "Night")
                        {
                            return Settings.ColorCache.GetValue("Void Shader Color (Night)");
                        }
                        return color11;
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
            None,
            Random,
            Day,
            Night,
            Dawn,
            Dusk,
            BloodMoon,
            Storm,
            Eclipse,
            Winter,
            Greek,
            Mafia,
            Void
        }
    }
}
