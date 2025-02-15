using System;
using System.Collections.Generic;
using SML;
using UnityEngine;

namespace SkyControllerPP
{
	// Token: 0x0200000C RID: 12
	[DynamicSettings]
	public class Settings
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000012 RID: 18 RVA: 0x00002668 File Offset: 0x00000868
		public ModSettings.TextInputSetting NightStart
		{
			get
			{
				ModSettings.TextInputSetting textInputSetting = new ModSettings.TextInputSetting();
				textInputSetting.Name = "Night Start";
				textInputSetting.Description = "(For real-time sync) The time night will start (24 hour time format) (HH:MM)";
				textInputSetting.DefaultValue = "21:00";
				textInputSetting.Regex = "^([01]?[0-9]|2[0-3]):[0-5][0-9]$";
				textInputSetting.CharacterLimit = 5;
				textInputSetting.AvailableInGame = true;
				textInputSetting.Available = true;
				textInputSetting.OnChanged = delegate(string s)
				{
					Settings.UpdateSky();
				};
				return textInputSetting;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000013 RID: 19 RVA: 0x000026E8 File Offset: 0x000008E8
		public ModSettings.TextInputSetting NightEnd
		{
			get
			{
				ModSettings.TextInputSetting textInputSetting = new ModSettings.TextInputSetting();
				textInputSetting.Name = "Night End";
				textInputSetting.Description = "(For real-time sync) The time night will end (24 hour time format) (HH:MM)";
				textInputSetting.DefaultValue = "6:00";
				textInputSetting.Regex = "^([01]?[0-9]|2[0-3]):[0-5][0-9]$";
				textInputSetting.CharacterLimit = 5;
				textInputSetting.AvailableInGame = true;
				textInputSetting.Available = true;
				textInputSetting.OnChanged = delegate(string s)
				{
					Settings.UpdateSky();
				};
				return textInputSetting;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000014 RID: 20 RVA: 0x00002768 File Offset: 0x00000968
		public ModSettings.IntegerInputSetting DawnDuskLength
		{
			get
			{
				ModSettings.IntegerInputSetting integerInputSetting = new ModSettings.IntegerInputSetting();
				integerInputSetting.Name = "Dawn/Dusk Length";
				integerInputSetting.Description = "(For real-time sync) How long dawn/dusk will last. (Minutes)";
				integerInputSetting.DefaultValue = 90;
				integerInputSetting.MinValue = 0;
				integerInputSetting.MaxValue = 1440;
				integerInputSetting.AvailableInGame = true;
				integerInputSetting.Available = true;
				integerInputSetting.OnChanged = delegate(int s)
				{
					Settings.UpdateSky();
				};
				return integerInputSetting;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000015 RID: 21 RVA: 0x000027E4 File Offset: 0x000009E4
		public ModSettings.ColorPickerSetting DayShaderColor
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Day Shader Color";
				colorPickerSetting.Description = "The shader color applied when using the Day skybox";
				colorPickerSetting.DefaultValue = "#FFFFFF";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = ((ModSettings.GetString("Default Skybox") == "None" && (ModSettings.GetString("Day Skybox") == "Day" || ModSettings.GetString("Night Skybox") == "Day" || ModSettings.GetString("Dawn Skybox") == "Day" || ModSettings.GetString("Dusk Skybox") == "Day")) || ModSettings.GetString("Default Skybox") == "Day" || ModSettings.GetString("Day Skybox") == "Day" || ModSettings.GetString("Apocalypse Skybox") == "Day" || ModSettings.GetString("Tribunal Skybox") == "Day" || (Settings.IsBTOS2() && (ModSettings.GetString("Court Skybox") == "Day" || ModSettings.GetString("Daybreak Skybox") == "Day")));
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000016 RID: 22 RVA: 0x0000295C File Offset: 0x00000B5C
		public ModSettings.ColorPickerSetting NightShaderColor
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Night Shader Color";
				colorPickerSetting.Description = "The shader color applied when using the Night skybox";
				colorPickerSetting.DefaultValue = "#4455EE";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = ((ModSettings.GetString("Default Skybox") == "None" && (ModSettings.GetString("Day Skybox") == "Night" || ModSettings.GetString("Night Skybox") == "Night" || ModSettings.GetString("Dawn Skybox") == "Night" || ModSettings.GetString("Dusk Skybox") == "Night")) || ModSettings.GetString("Default Skybox") == "Night" || ModSettings.GetString("Day Skybox") == "Night" || ModSettings.GetString("Apocalypse Skybox") == "Night" || ModSettings.GetString("Tribunal Skybox") == "Night" || (Settings.IsBTOS2() && (ModSettings.GetString("Court Skybox") == "Night" || ModSettings.GetString("Daybreak Skybox") == "Night")));
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000017 RID: 23 RVA: 0x00002AD4 File Offset: 0x00000CD4
		public ModSettings.ColorPickerSetting DawnShaderColor
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Dawn Shader Color";
				colorPickerSetting.Description = "The shader color applied when using the Dawn skybox";
				colorPickerSetting.DefaultValue = "#FFCCC0";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = ((ModSettings.GetString("Default Skybox") == "None" && (ModSettings.GetString("Day Skybox") == "Dawn" || ModSettings.GetString("Night Skybox") == "Dawn" || ModSettings.GetString("Dawn Skybox") == "Dawn" || ModSettings.GetString("Dusk Skybox") == "Dawn")) || ModSettings.GetString("Default Skybox") == "Dawn" || ModSettings.GetString("Day Skybox") == "Dawn" || ModSettings.GetString("Apocalypse Skybox") == "Dawn" || ModSettings.GetString("Tribunal Skybox") == "Dawn" || (Settings.IsBTOS2() && (ModSettings.GetString("Court Skybox") == "Dawn" || ModSettings.GetString("Daybreak Skybox") == "Dawn")));
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000018 RID: 24 RVA: 0x00002C4C File Offset: 0x00000E4C
		public ModSettings.ColorPickerSetting DuskShaderColor
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Dusk Shader Color";
				colorPickerSetting.Description = "The shader color applied when using the Dusk skybox";
				colorPickerSetting.DefaultValue = "#FFCCC0";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = ((ModSettings.GetString("Default Skybox") == "None" && (ModSettings.GetString("Day Skybox") == "Dusk" || ModSettings.GetString("Night Skybox") == "Dusk" || ModSettings.GetString("Dawn Skybox") == "Dusk" || ModSettings.GetString("Dusk Skybox") == "Dusk")) || ModSettings.GetString("Default Skybox") == "Dusk" || ModSettings.GetString("Day Skybox") == "Dusk" || ModSettings.GetString("Apocalypse Skybox") == "Dusk" || ModSettings.GetString("Tribunal Skybox") == "Dusk" || (Settings.IsBTOS2() && (ModSettings.GetString("Court Skybox") == "Dusk" || ModSettings.GetString("Daybreak Skybox") == "Dusk")));
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000019 RID: 25 RVA: 0x00002DC4 File Offset: 0x00000FC4
		public ModSettings.ColorPickerSetting BloodMoonShaderColor
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Blood Moon Shader Color";
				colorPickerSetting.Description = "The shader color applied when using the Blood Moon skybox";
				colorPickerSetting.DefaultValue = "#FF7F7F";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = ((ModSettings.GetString("Default Skybox") == "None" && (ModSettings.GetString("Day Skybox") == "Blood Moon" || ModSettings.GetString("Night Skybox") == "Blood Moon" || ModSettings.GetString("Dawn Skybox") == "Blood Moon" || ModSettings.GetString("Dusk Skybox") == "Blood Moon")) || ModSettings.GetString("Default Skybox") == "Blood Moon" || ModSettings.GetString("Day Skybox") == "Blood Moon" || ModSettings.GetString("Apocalypse Skybox") == "Blood Moon" || ModSettings.GetString("Tribunal Skybox") == "Blood Moon" || (Settings.IsBTOS2() && (ModSettings.GetString("Court Skybox") == "Blood Moon" || ModSettings.GetString("Daybreak Skybox") == "Blood Moon")));
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600001A RID: 26 RVA: 0x00002F3C File Offset: 0x0000113C
		public ModSettings.ColorPickerSetting StormShaderColor
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Storm Shader Color";
				colorPickerSetting.Description = "The shader color applied when using the Storm skybox";
				colorPickerSetting.DefaultValue = "#707070";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = ((ModSettings.GetString("Default Skybox") == "None" && (ModSettings.GetString("Day Skybox") == "Storm" || ModSettings.GetString("Night Skybox") == "Storm" || ModSettings.GetString("Dawn Skybox") == "Storm" || ModSettings.GetString("Dusk Skybox") == "Storm")) || ModSettings.GetString("Default Skybox") == "Storm" || ModSettings.GetString("Day Skybox") == "Storm" || ModSettings.GetString("Apocalypse Skybox") == "Storm" || ModSettings.GetString("Tribunal Skybox") == "Storm" || (Settings.IsBTOS2() && (ModSettings.GetString("Court Skybox") == "Storm" || ModSettings.GetString("Daybreak Skybox") == "Storm")));
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600001B RID: 27 RVA: 0x000030B4 File Offset: 0x000012B4
		public ModSettings.ColorPickerSetting EclipseShaderColor
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Eclipse Shader Color";
				colorPickerSetting.Description = "The shader color applied when using the Eclipse skybox";
				colorPickerSetting.DefaultValue = "#8855FF";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = ((ModSettings.GetString("Default Skybox") == "None" && (ModSettings.GetString("Day Skybox") == "Eclipse" || ModSettings.GetString("Night Skybox") == "Eclipse" || ModSettings.GetString("Dawn Skybox") == "Eclipse" || ModSettings.GetString("Dusk Skybox") == "Eclipse")) || ModSettings.GetString("Default Skybox") == "Eclipse" || ModSettings.GetString("Day Skybox") == "Eclipse" || ModSettings.GetString("Apocalypse Skybox") == "Eclipse" || ModSettings.GetString("Tribunal Skybox") == "Eclipse" || (Settings.IsBTOS2() && (ModSettings.GetString("Court Skybox") == "Eclipse" || ModSettings.GetString("Daybreak Skybox") == "Eclipse")));
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600001C RID: 28 RVA: 0x0000322C File Offset: 0x0000142C
		public ModSettings.ColorPickerSetting WinterShaderColor
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Winter Shader Color";
				colorPickerSetting.Description = "The shader color applied when using the Winter skybox";
				colorPickerSetting.DefaultValue = "#99B3FF";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = ((ModSettings.GetString("Default Skybox") == "None" && (ModSettings.GetString("Day Skybox") == "Winter" || ModSettings.GetString("Night Skybox") == "Winter" || ModSettings.GetString("Dawn Skybox") == "Winter" || ModSettings.GetString("Dusk Skybox") == "Winter")) || ModSettings.GetString("Default Skybox") == "Winter" || ModSettings.GetString("Day Skybox") == "Winter" || ModSettings.GetString("Apocalypse Skybox") == "Winter" || ModSettings.GetString("Tribunal Skybox") == "Winter" || (Settings.IsBTOS2() && (ModSettings.GetString("Court Skybox") == "Winter" || ModSettings.GetString("Daybreak Skybox") == "Winter")));
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600001D RID: 29 RVA: 0x000033A4 File Offset: 0x000015A4
		public ModSettings.DropdownSetting SetDefaultSky
		{
			get
			{
				ModSettings.DropdownSetting dropdownSetting = new ModSettings.DropdownSetting();
				dropdownSetting.Name = "Default Skybox";
				dropdownSetting.Description = "The selected skybox will be used in all menus and will override any real-time sync settings.";
				dropdownSetting.Options = this.AvailableSkyboxes;
				dropdownSetting.AvailableInGame = true;
				dropdownSetting.Available = true;
				dropdownSetting.OnChanged = delegate(string s)
				{
					Settings.UpdateSky();
				};
				return dropdownSetting;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600001E RID: 30 RVA: 0x00003414 File Offset: 0x00001614
		public ModSettings.DropdownSetting SetDaySky
		{
			get
			{
				ModSettings.DropdownSetting dropdownSetting = new ModSettings.DropdownSetting();
				dropdownSetting.Name = "Day Skybox";
				dropdownSetting.Description = "The selected skybox will be used in-game during the day phase. Set to None to use your default skybox. If the default skybox is set to None, this will be the skybox used during your set real-time sync day time.";
				dropdownSetting.Options = this.AvailableSkyboxes;
				dropdownSetting.AvailableInGame = true;
				dropdownSetting.Available = true;
				dropdownSetting.OnChanged = delegate(string s)
				{
					Settings.UpdateSky();
				};
				return dropdownSetting;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600001F RID: 31 RVA: 0x00003484 File Offset: 0x00001684
		public ModSettings.DropdownSetting SetNightSky
		{
			get
			{
				ModSettings.DropdownSetting dropdownSetting = new ModSettings.DropdownSetting();
				dropdownSetting.Name = "Night Skybox";
				dropdownSetting.Description = "The selected skybox will be used in-game during the night phase. Set to None to use your default skybox. If the default skybox is set to None, this will be the skybox used during your set real-time sync night time.";
				dropdownSetting.Options = this.AvailableSkyboxes;
				dropdownSetting.AvailableInGame = true;
				dropdownSetting.Available = true;
				dropdownSetting.OnChanged = delegate(string s)
				{
					Settings.UpdateSky();
				};
				return dropdownSetting;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000020 RID: 32 RVA: 0x000034F4 File Offset: 0x000016F4
		public ModSettings.DropdownSetting SetApocSky
		{
			get
			{
				ModSettings.DropdownSetting dropdownSetting = new ModSettings.DropdownSetting();
				dropdownSetting.Name = "Apocalypse Skybox";
				dropdownSetting.Description = "The selected skybox will be used in-game when a Horseman of the Apocalypse emerges. Set to None to use your day/night skyboxes (or the default skybox if those are set to None)";
				dropdownSetting.Options = this.AvailableSkyboxes;
				dropdownSetting.AvailableInGame = true;
				dropdownSetting.Available = true;
				dropdownSetting.OnChanged = delegate(string s)
				{
					Settings.UpdateSky();
				};
				return dropdownSetting;
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00003564 File Offset: 0x00001764
		public static void UpdateSky()
		{
			bool flag = !(SkyInfo.Instance == null);
			if (flag)
			{
				SkyInfo.Instance.UpdateSky();
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000022 RID: 34 RVA: 0x00003594 File Offset: 0x00001794
		public ModSettings.ColorPickerSetting DayShaderColorNight
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Day Shader Color (Night)";
				colorPickerSetting.Description = "The shader color applied when using the Day skybox, during the in-game Night phase";
				colorPickerSetting.DefaultValue = "#FFFFFF";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = ((ModSettings.GetString("Default Skybox") == "None" && (ModSettings.GetString("Day Skybox") == "Day" || ModSettings.GetString("Night Skybox") == "Day" || ModSettings.GetString("Dawn Skybox") == "Day" || ModSettings.GetString("Dusk Skybox") == "Day")) || ModSettings.GetString("Default Skybox") == "Day" || ModSettings.GetString("Night Skybox") == "Day" || ModSettings.GetString("Apocalypse Skybox") == "Day");
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000023 RID: 35 RVA: 0x000036B4 File Offset: 0x000018B4
		public ModSettings.ColorPickerSetting NightShaderColorNight
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Night Shader Color (Night)";
				colorPickerSetting.Description = "The shader color applied when using the Night skybox, during the in-game Night phase";
				colorPickerSetting.DefaultValue = "#4455EE";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = ((ModSettings.GetString("Default Skybox") == "None" && (ModSettings.GetString("Day Skybox") == "Night" || ModSettings.GetString("Night Skybox") == "Night" || ModSettings.GetString("Dawn Skybox") == "Night" || ModSettings.GetString("Dusk Skybox") == "Night")) || ModSettings.GetString("Default Skybox") == "Night" || ModSettings.GetString("Night Skybox") == "Night" || ModSettings.GetString("Apocalypse Skybox") == "Night");
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000024 RID: 36 RVA: 0x000037D4 File Offset: 0x000019D4
		public ModSettings.ColorPickerSetting DawnShaderColorNight
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Dawn Shader Color (Night)";
				colorPickerSetting.Description = "The shader color applied when using the Dawn skybox, during the in-game Night phase";
				colorPickerSetting.DefaultValue = "#FFCCC0";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = ((ModSettings.GetString("Default Skybox") == "None" && (ModSettings.GetString("Day Skybox") == "Dawn" || ModSettings.GetString("Night Skybox") == "Dawn" || ModSettings.GetString("Dawn Skybox") == "Dawn" || ModSettings.GetString("Dusk Skybox") == "Dawn")) || ModSettings.GetString("Default Skybox") == "Dawn" || ModSettings.GetString("Night Skybox") == "Dawn" || ModSettings.GetString("Apocalypse Skybox") == "Dawn");
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000025 RID: 37 RVA: 0x000038F4 File Offset: 0x00001AF4
		public ModSettings.ColorPickerSetting DuskShaderColorNight
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Dusk Shader Color (Night)";
				colorPickerSetting.Description = "The shader color applied when using the Dusk skybox, during the in-game Night phase";
				colorPickerSetting.DefaultValue = "#FFCCC0";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = ((ModSettings.GetString("Default Skybox") == "None" && (ModSettings.GetString("Day Skybox") == "Dusk" || ModSettings.GetString("Night Skybox") == "Dusk" || ModSettings.GetString("Dawn Skybox") == "Dusk" || ModSettings.GetString("Dusk Skybox") == "Dusk")) || ModSettings.GetString("Default Skybox") == "Dusk" || ModSettings.GetString("Night Skybox") == "Dusk" || ModSettings.GetString("Apocalypse Skybox") == "Dusk");
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00003A14 File Offset: 0x00001C14
		public ModSettings.ColorPickerSetting BloodMoonShaderColorNight
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Blood Moon Shader Color (Night)";
				colorPickerSetting.Description = "The shader color applied when using the Blood Moon skybox, during the in-game Night phase";
				colorPickerSetting.DefaultValue = "#FF7F7F";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = ((ModSettings.GetString("Default Skybox") == "None" && (ModSettings.GetString("Day Skybox") == "Blood Moon" || ModSettings.GetString("Night Skybox") == "Blood Moon" || ModSettings.GetString("Dawn Skybox") == "Blood Moon" || ModSettings.GetString("Dusk Skybox") == "Blood Moon")) || ModSettings.GetString("Default Skybox") == "Blood Moon" || ModSettings.GetString("Night Skybox") == "Blood Moon" || ModSettings.GetString("Apocalypse Skybox") == "Blood Moon");
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000027 RID: 39 RVA: 0x00003B34 File Offset: 0x00001D34
		public ModSettings.ColorPickerSetting StormShaderColorNight
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Storm Shader Color (Night)";
				colorPickerSetting.Description = "The shader color applied when using the Storm skybox, during the in-game Night phase";
				colorPickerSetting.DefaultValue = "#707070";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = ((ModSettings.GetString("Default Skybox") == "None" && (ModSettings.GetString("Day Skybox") == "Storm" || ModSettings.GetString("Night Skybox") == "Storm" || ModSettings.GetString("Dawn Skybox") == "Storm" || ModSettings.GetString("Dusk Skybox") == "Storm")) || ModSettings.GetString("Default Skybox") == "Storm" || ModSettings.GetString("Night Skybox") == "Storm" || ModSettings.GetString("Apocalypse Skybox") == "Storm");
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00003C54 File Offset: 0x00001E54
		public ModSettings.ColorPickerSetting EclipseShaderColorNight
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Eclipse Shader Color (Night)";
				colorPickerSetting.Description = "The shader color applied when using the Eclipse skybox, during the in-game Night phase";
				colorPickerSetting.DefaultValue = "#8855FF";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = ((ModSettings.GetString("Default Skybox") == "None" && (ModSettings.GetString("Day Skybox") == "Eclipse" || ModSettings.GetString("Night Skybox") == "Eclipse" || ModSettings.GetString("Dawn Skybox") == "Eclipse" || ModSettings.GetString("Dusk Skybox") == "Eclipse")) || ModSettings.GetString("Default Skybox") == "Eclipse" || ModSettings.GetString("Night Skybox") == "Eclipse" || ModSettings.GetString("Apocalypse Skybox") == "Eclipse");
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00003D74 File Offset: 0x00001F74
		public ModSettings.ColorPickerSetting WinterShaderColorNight
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Winter Shader Color (Night)";
				colorPickerSetting.Description = "The shader color applied when using the Winter skybox, during the in-game Night phase";
				colorPickerSetting.DefaultValue = "#99B3FF";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = ((ModSettings.GetString("Default Skybox") == "None" && (ModSettings.GetString("Day Skybox") == "Winter" || ModSettings.GetString("Night Skybox") == "Winter" || ModSettings.GetString("Dawn Skybox") == "Winter" || ModSettings.GetString("Dusk Skybox") == "Winter")) || ModSettings.GetString("Default Skybox") == "Winter" || ModSettings.GetString("Night Skybox") == "Winter" || ModSettings.GetString("Apocalypse Skybox") == "Winter");
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00003E94 File Offset: 0x00002094
		public ModSettings.DropdownSetting SetTribunalSky
		{
			get
			{
				ModSettings.DropdownSetting dropdownSetting = new ModSettings.DropdownSetting();
				dropdownSetting.Name = "Tribunal Skybox";
				dropdownSetting.Description = "The selected skybox will be used in-game during a Marshal's Tribunal. Set to None to use your day skybox (or the default skybox if that is set to None).";
				dropdownSetting.Options = this.AvailableSkyboxes;
				dropdownSetting.AvailableInGame = true;
				dropdownSetting.Available = true;
				dropdownSetting.OnChanged = delegate(string s)
				{
					Settings.UpdateSky();
				};
				return dropdownSetting;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00003F04 File Offset: 0x00002104
		public ModSettings.DropdownSetting SetCourtSky
		{
			get
			{
				ModSettings.DropdownSetting dropdownSetting = new ModSettings.DropdownSetting();
				dropdownSetting.Name = "Court Skybox";
				dropdownSetting.Description = "The selected skybox will be used in-game during a Judge's Court. Set to None to use your day skybox (or the default skybox if that is set to None).";
				dropdownSetting.Options = this.AvailableSkyboxes;
				dropdownSetting.AvailableInGame = true;
				dropdownSetting.Available = Settings.IsBTOS2();
				dropdownSetting.OnChanged = delegate(string s)
				{
					Settings.UpdateSky();
				};
				return dropdownSetting;
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00003F78 File Offset: 0x00002178
		public static bool IsBTOS2()
		{
			return ModStates.IsEnabled("curtis.tuba.better.tos2");
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600002D RID: 45 RVA: 0x00003F94 File Offset: 0x00002194
		public ModSettings.DropdownSetting SetDaybreakSky
		{
			get
			{
				ModSettings.DropdownSetting dropdownSetting = new ModSettings.DropdownSetting();
				dropdownSetting.Name = "Daybreak Skybox";
				dropdownSetting.Description = "The selected skybox will be used in-game during Starspawn's Daybreak. Set to None to use your day skybox (or the default skybox if that is set to None).";
				dropdownSetting.Options = this.AvailableSkyboxes;
				dropdownSetting.AvailableInGame = true;
				dropdownSetting.Available = Settings.IsBTOS2();
				dropdownSetting.OnChanged = delegate(string s)
				{
					Settings.UpdateSky();
				};
				return dropdownSetting;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600002E RID: 46 RVA: 0x00004008 File Offset: 0x00002208
		public ModSettings.DropdownSetting SetDawnSky
		{
			get
			{
				ModSettings.DropdownSetting dropdownSetting = new ModSettings.DropdownSetting();
				dropdownSetting.Name = "Dawn Skybox";
				dropdownSetting.Description = "The selected skybox will be used during your set real-time sync dawn time.";
				dropdownSetting.Options = this.AvailableSkyboxes;
				dropdownSetting.AvailableInGame = true;
				dropdownSetting.Available = (ModSettings.GetString("Default Skybox") == "None");
				dropdownSetting.OnChanged = delegate(string s)
				{
					Settings.UpdateSky();
				};
				return dropdownSetting;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600002F RID: 47 RVA: 0x0000408C File Offset: 0x0000228C
		public ModSettings.DropdownSetting SetDuskSky
		{
			get
			{
				ModSettings.DropdownSetting dropdownSetting = new ModSettings.DropdownSetting();
				dropdownSetting.Name = "Dusk Skybox";
				dropdownSetting.Description = "The selected skybox will be used during your set real-time sync dusk time.";
				dropdownSetting.Options = this.AvailableSkyboxes;
				dropdownSetting.AvailableInGame = true;
				dropdownSetting.Available = (ModSettings.GetString("Default Skybox") == "None");
				dropdownSetting.OnChanged = delegate(string s)
				{
					Settings.UpdateSky();
				};
				return dropdownSetting;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00004110 File Offset: 0x00002310
		public ModSettings.CheckboxSetting ColorSnowflakes
		{
			get
			{
				ModSettings.CheckboxSetting checkboxSetting = new ModSettings.CheckboxSetting();
				checkboxSetting.Name = "Color Snowflakes to Shader Color (Winter Map)";
				checkboxSetting.Description = "Toggles if the snowflakes in the Winter map should be recolored to your shader color";
				checkboxSetting.DefaultValue = true;
				checkboxSetting.OnChanged = delegate(bool v)
				{
					Settings.UpdateSky();
				};
				return checkboxSetting;
			}
		}

		// Token: 0x04000007 RID: 7
		private readonly List<string> AvailableSkyboxes = new List<string>(10)
		{
			"None",
			"Day",
			"Night",
			"Dawn",
			"Dusk",
			"Blood Moon",
			"Storm",
			"Eclipse",
			"Winter"
		};
	}
}
