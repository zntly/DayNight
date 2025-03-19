using System;
using System.Collections.Generic;
using Server.Shared.Extensions;
using Services;
using SML;
using UnityEngine;

namespace SkyControllerPP
{
	// Token: 0x0200000D RID: 13
	[DynamicSettings]
	public class Settings
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000016 RID: 22
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
				textInputSetting.Available = ((string)Settings.SettingsCache.GetValue("Default Skybox", null) == "None");
				textInputSetting.OnChanged = delegate(string s)
				{
					Settings.UpdateSky();
				};
				return textInputSetting;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000017 RID: 23
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
				textInputSetting.Available = ((string)Settings.SettingsCache.GetValue("Default Skybox", null) == "None");
				textInputSetting.OnChanged = delegate(string s)
				{
					Settings.UpdateSky();
				};
				return textInputSetting;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000018 RID: 24
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
				integerInputSetting.Available = ((string)Settings.SettingsCache.GetValue("Default Skybox", null) == "None");
				integerInputSetting.OnChanged = delegate(int s)
				{
					Settings.UpdateSky();
				};
				return integerInputSetting;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000019 RID: 25
		public ModSettings.ColorPickerSetting DayShaderColor
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Day Shader Color";
				colorPickerSetting.Description = "The shader color applied when using the Day skybox";
				colorPickerSetting.DefaultValue = "#FFFFFF";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = (((string)Settings.SettingsCache.GetValue("Default Skybox", null) == "None" && ((string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Day" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Day" || (string)Settings.SettingsCache.GetValue("Dawn Skybox", null) == "Day" || (string)Settings.SettingsCache.GetValue("Dusk Skybox", null) == "Day")) || (string)Settings.SettingsCache.GetValue("Default Skybox", null) == "Day" || (string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Day" || (string)Settings.SettingsCache.GetValue("Apocalypse Skybox", null) == "Day" || (string)Settings.SettingsCache.GetValue("Tribunal Skybox", null) == "Day" || (ModStates.IsEnabled("curtis.tuba.better.tos2") && ((string)Settings.SettingsCache.GetValue("Court Skybox", null) == "Day" || (string)Settings.SettingsCache.GetValue("Daybreak Skybox", null) == "Day")));
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600001A RID: 26
		public ModSettings.ColorPickerSetting NightShaderColor
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Night Shader Color";
				colorPickerSetting.Description = "The shader color applied when using the Night skybox";
				colorPickerSetting.DefaultValue = "#7A86F3";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = (((string)Settings.SettingsCache.GetValue("Default Skybox", null) == "None" && ((string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Night" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Night" || (string)Settings.SettingsCache.GetValue("Dawn Skybox", null) == "Night" || (string)Settings.SettingsCache.GetValue("Dusk Skybox", null) == "Night")) || (string)Settings.SettingsCache.GetValue("Default Skybox", null) == "Night" || (string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Night" || (string)Settings.SettingsCache.GetValue("Apocalypse Skybox", null) == "Night" || (string)Settings.SettingsCache.GetValue("Tribunal Skybox", null) == "Night" || (ModStates.IsEnabled("curtis.tuba.better.tos2") && ((string)Settings.SettingsCache.GetValue("Court Skybox", null) == "Night" || (string)Settings.SettingsCache.GetValue("Daybreak Skybox", null) == "Night")));
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600001B RID: 27
		public ModSettings.ColorPickerSetting DawnShaderColor
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Dawn Shader Color";
				colorPickerSetting.Description = "The shader color applied when using the Dawn skybox";
				colorPickerSetting.DefaultValue = "#FFCCC0";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = (((string)Settings.SettingsCache.GetValue("Default Skybox", null) == "None" && ((string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Dawn" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Dawn" || (string)Settings.SettingsCache.GetValue("Dawn Skybox", null) == "Dawn" || (string)Settings.SettingsCache.GetValue("Dusk Skybox", null) == "Dawn")) || (string)Settings.SettingsCache.GetValue("Default Skybox", null) == "Dawn" || (string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Dawn" || (string)Settings.SettingsCache.GetValue("Apocalypse Skybox", null) == "Dawn" || (string)Settings.SettingsCache.GetValue("Tribunal Skybox", null) == "Dawn" || (ModStates.IsEnabled("curtis.tuba.better.tos2") && ((string)Settings.SettingsCache.GetValue("Court Skybox", null) == "Dawn" || (string)Settings.SettingsCache.GetValue("Daybreak Skybox", null) == "Dawn")));
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600001C RID: 28
		public ModSettings.ColorPickerSetting DuskShaderColor
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Dusk Shader Color";
				colorPickerSetting.Description = "The shader color applied when using the Dusk skybox";
				colorPickerSetting.DefaultValue = "#FFCCC0";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = (((string)Settings.SettingsCache.GetValue("Default Skybox", null) == "None" && ((string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Dusk" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Dusk" || (string)Settings.SettingsCache.GetValue("Dawn Skybox", null) == "Dusk" || (string)Settings.SettingsCache.GetValue("Dusk Skybox", null) == "Dusk")) || (string)Settings.SettingsCache.GetValue("Default Skybox", null) == "Dusk" || (string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Dusk" || (string)Settings.SettingsCache.GetValue("Apocalypse Skybox", null) == "Dusk" || (string)Settings.SettingsCache.GetValue("Tribunal Skybox", null) == "Dusk" || (ModStates.IsEnabled("curtis.tuba.better.tos2") && ((string)Settings.SettingsCache.GetValue("Court Skybox", null) == "Dusk" || (string)Settings.SettingsCache.GetValue("Daybreak Skybox", null) == "Dusk")));
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600001D RID: 29
		public ModSettings.ColorPickerSetting BloodMoonShaderColor
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Blood Moon Shader Color";
				colorPickerSetting.Description = "The shader color applied when using the Blood Moon skybox";
				colorPickerSetting.DefaultValue = "#FF7F7F";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = (((string)Settings.SettingsCache.GetValue("Default Skybox", null) == "None" && ((string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Blood Moon" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Blood Moon" || (string)Settings.SettingsCache.GetValue("Dawn Skybox", null) == "Blood Moon" || (string)Settings.SettingsCache.GetValue("Dusk Skybox", null) == "Blood Moon")) || (string)Settings.SettingsCache.GetValue("Default Skybox", null) == "Blood Moon" || (string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Blood Moon" || (string)Settings.SettingsCache.GetValue("Apocalypse Skybox", null) == "Blood Moon" || (string)Settings.SettingsCache.GetValue("Tribunal Skybox", null) == "Blood Moon" || (ModStates.IsEnabled("curtis.tuba.better.tos2") && ((string)Settings.SettingsCache.GetValue("Court Skybox", null) == "Blood Moon" || (string)Settings.SettingsCache.GetValue("Daybreak Skybox", null) == "Blood Moon")));
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600001E RID: 30
		public ModSettings.ColorPickerSetting StormShaderColor
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Storm Shader Color";
				colorPickerSetting.Description = "The shader color applied when using the Storm skybox";
				colorPickerSetting.DefaultValue = "#707070";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = (((string)Settings.SettingsCache.GetValue("Default Skybox", null) == "None" && ((string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Storm" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Storm" || (string)Settings.SettingsCache.GetValue("Dawn Skybox", null) == "Storm" || (string)Settings.SettingsCache.GetValue("Dusk Skybox", null) == "Storm")) || (string)Settings.SettingsCache.GetValue("Default Skybox", null) == "Storm" || (string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Storm" || (string)Settings.SettingsCache.GetValue("Apocalypse Skybox", null) == "Storm" || (string)Settings.SettingsCache.GetValue("Tribunal Skybox", null) == "Storm" || (ModStates.IsEnabled("curtis.tuba.better.tos2") && ((string)Settings.SettingsCache.GetValue("Court Skybox", null) == "Storm" || (string)Settings.SettingsCache.GetValue("Daybreak Skybox", null) == "Storm")));
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600001F RID: 31
		public ModSettings.ColorPickerSetting EclipseShaderColor
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Eclipse Shader Color";
				colorPickerSetting.Description = "The shader color applied when using the Eclipse skybox";
				colorPickerSetting.DefaultValue = "#8855FF";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = (((string)Settings.SettingsCache.GetValue("Default Skybox", null) == "None" && ((string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Eclipse" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Eclipse" || (string)Settings.SettingsCache.GetValue("Dawn Skybox", null) == "Eclipse" || (string)Settings.SettingsCache.GetValue("Dusk Skybox", null) == "Eclipse")) || (string)Settings.SettingsCache.GetValue("Default Skybox", null) == "Eclipse" || (string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Eclipse" || (string)Settings.SettingsCache.GetValue("Apocalypse Skybox", null) == "Eclipse" || (string)Settings.SettingsCache.GetValue("Tribunal Skybox", null) == "Eclipse" || (ModStates.IsEnabled("curtis.tuba.better.tos2") && ((string)Settings.SettingsCache.GetValue("Court Skybox", null) == "Eclipse" || (string)Settings.SettingsCache.GetValue("Daybreak Skybox", null) == "Eclipse")));
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000020 RID: 32
		public ModSettings.ColorPickerSetting WinterShaderColor
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Winter Shader Color";
				colorPickerSetting.Description = "The shader color applied when using the Winter skybox";
				colorPickerSetting.DefaultValue = "#99B3FF";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = (((string)Settings.SettingsCache.GetValue("Default Skybox", null) == "None" && ((string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Winter" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Winter" || (string)Settings.SettingsCache.GetValue("Dawn Skybox", null) == "Winter" || (string)Settings.SettingsCache.GetValue("Dusk Skybox", null) == "Winter")) || (string)Settings.SettingsCache.GetValue("Default Skybox", null) == "Winter" || (string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Winter" || (string)Settings.SettingsCache.GetValue("Apocalypse Skybox", null) == "Winter" || (string)Settings.SettingsCache.GetValue("Tribunal Skybox", null) == "Winter" || (ModStates.IsEnabled("curtis.tuba.better.tos2") && ((string)Settings.SettingsCache.GetValue("Court Skybox", null) == "Winter" || (string)Settings.SettingsCache.GetValue("Daybreak Skybox", null) == "Winter")));
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000021 RID: 33
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
					Settings.SettingsCache.SetValue("Default Skybox", s);
					Settings.UpdateSky();
				};
				return dropdownSetting;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000022 RID: 34
		public ModSettings.DropdownSetting SetDaySky
		{
			get
			{
				ModSettings.DropdownSetting dropdownSetting = new ModSettings.DropdownSetting();
				dropdownSetting.Name = "Day Skybox";
				dropdownSetting.Description = "The selected skybox will be used in-game during the day phase.\nSet to None to use your default skybox.\nIf the default skybox is set to None, this will be the skybox used during your set real-time sync day time.";
				dropdownSetting.Options = this.AvailableSkyboxes;
				dropdownSetting.AvailableInGame = true;
				dropdownSetting.Available = true;
				dropdownSetting.OnChanged = delegate(string s)
				{
					Settings.SettingsCache.SetValue("Day Skybox", s);
					Settings.UpdateSky();
				};
				return dropdownSetting;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000023 RID: 35
		public ModSettings.DropdownSetting SetNightSky
		{
			get
			{
				ModSettings.DropdownSetting dropdownSetting = new ModSettings.DropdownSetting();
				dropdownSetting.Name = "Night Skybox";
				dropdownSetting.Description = "The selected skybox will be used in-game during the night phase.\nSet to None to use your default skybox.\nIf the default skybox is set to None, this will be the skybox used during your set real-time sync night time.";
				dropdownSetting.Options = this.AvailableSkyboxes;
				dropdownSetting.AvailableInGame = true;
				dropdownSetting.Available = true;
				dropdownSetting.OnChanged = delegate(string s)
				{
					Settings.SettingsCache.SetValue("Night Skybox", s);
					Settings.UpdateSky();
				};
				return dropdownSetting;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000024 RID: 36
		public ModSettings.DropdownSetting SetApocSky
		{
			get
			{
				ModSettings.DropdownSetting dropdownSetting = new ModSettings.DropdownSetting();
				dropdownSetting.Name = "Apocalypse Skybox";
				dropdownSetting.Description = "The selected skybox will be used in-game when a Horseman of the Apocalypse emerges.\nSet to None to use your day/night skyboxes (or the default skybox if those are set to None)";
				dropdownSetting.Options = this.AvailableSkyboxes;
				dropdownSetting.AvailableInGame = true;
				dropdownSetting.Available = true;
				dropdownSetting.OnChanged = delegate(string s)
				{
					Settings.SettingsCache.SetValue("Apocalypse Skybox", s);
					Settings.UpdateSky();
				};
				return dropdownSetting;
			}
		}

		// Token: 0x06000025 RID: 37
		public static void UpdateSky()
		{
			if (!(SkyInfo.Instance == null))
			{
				SkyInfo.Instance.UpdateSky();
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000026 RID: 38
		public ModSettings.ColorPickerSetting DayShaderColorNight
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Day Shader Color (Night)";
				colorPickerSetting.Description = "The shader color applied when using the Day skybox, during the in-game Night phase";
				colorPickerSetting.DefaultValue = "#808080";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = (((string)Settings.SettingsCache.GetValue("Default Skybox", null) == "None" && ((string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Day" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Day" || (string)Settings.SettingsCache.GetValue("Dawn Skybox", null) == "Day" || (string)Settings.SettingsCache.GetValue("Dusk Skybox", null) == "Day")) || (string)Settings.SettingsCache.GetValue("Default Skybox", null) == "Day" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Day" || (string)Settings.SettingsCache.GetValue("Apocalypse Skybox", null) == "Day");
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000027 RID: 39
		public ModSettings.ColorPickerSetting NightShaderColorNight
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Night Shader Color (Night)";
				colorPickerSetting.Description = "The shader color applied when using the Night skybox, during the in-game Night phase";
				colorPickerSetting.DefaultValue = "#4455EE";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = (((string)Settings.SettingsCache.GetValue("Default Skybox", null) == "None" && ((string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Night" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Night" || (string)Settings.SettingsCache.GetValue("Dawn Skybox", null) == "Night" || (string)Settings.SettingsCache.GetValue("Dusk Skybox", null) == "Night")) || (string)Settings.SettingsCache.GetValue("Default Skybox", null) == "Night" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Night" || (string)Settings.SettingsCache.GetValue("Apocalypse Skybox", null) == "Night");
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000028 RID: 40
		public ModSettings.ColorPickerSetting DawnShaderColorNight
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Dawn Shader Color (Night)";
				colorPickerSetting.Description = "The shader color applied when using the Dawn skybox, during the in-game Night phase";
				colorPickerSetting.DefaultValue = "#7D4A3E";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = (((string)Settings.SettingsCache.GetValue("Default Skybox", null) == "None" && ((string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Dawn" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Dawn" || (string)Settings.SettingsCache.GetValue("Dawn Skybox", null) == "Dawn" || (string)Settings.SettingsCache.GetValue("Dusk Skybox", null) == "Dawn")) || (string)Settings.SettingsCache.GetValue("Default Skybox", null) == "Dawn" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Dawn" || (string)Settings.SettingsCache.GetValue("Apocalypse Skybox", null) == "Dawn");
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000029 RID: 41
		public ModSettings.ColorPickerSetting DuskShaderColorNight
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Dusk Shader Color (Night)";
				colorPickerSetting.Description = "The shader color applied when using the Dusk skybox, during the in-game Night phase";
				colorPickerSetting.DefaultValue = "#7D4A3E";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = (((string)Settings.SettingsCache.GetValue("Default Skybox", null) == "None" && ((string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Dusk" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Dusk" || (string)Settings.SettingsCache.GetValue("Dawn Skybox", null) == "Dusk" || (string)Settings.SettingsCache.GetValue("Dusk Skybox", null) == "Dusk")) || (string)Settings.SettingsCache.GetValue("Default Skybox", null) == "Dusk" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Dusk" || (string)Settings.SettingsCache.GetValue("Apocalypse Skybox", null) == "Dusk");
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600002A RID: 42
		public ModSettings.ColorPickerSetting BloodMoonShaderColorNight
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Blood Moon Shader Color (Night)";
				colorPickerSetting.Description = "The shader color applied when using the Blood Moon skybox, during the in-game Night phase";
				colorPickerSetting.DefaultValue = "#5C001C";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = (((string)Settings.SettingsCache.GetValue("Default Skybox", null) == "None" && ((string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Blood Moon" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Blood Moon" || (string)Settings.SettingsCache.GetValue("Dawn Skybox", null) == "Blood Moon" || (string)Settings.SettingsCache.GetValue("Dusk Skybox", null) == "Blood Moon")) || (string)Settings.SettingsCache.GetValue("Default Skybox", null) == "Blood Moon" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Blood Moon" || (string)Settings.SettingsCache.GetValue("Apocalypse Skybox", null) == "Blood Moon");
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600002B RID: 43
		public ModSettings.ColorPickerSetting StormShaderColorNight
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Storm Shader Color (Night)";
				colorPickerSetting.Description = "The shader color applied when using the Storm skybox, during the in-game Night phase";
				colorPickerSetting.DefaultValue = "#505050";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = (((string)Settings.SettingsCache.GetValue("Default Skybox", null) == "None" && ((string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Storm" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Storm" || (string)Settings.SettingsCache.GetValue("Dawn Skybox", null) == "Storm" || (string)Settings.SettingsCache.GetValue("Dusk Skybox", null) == "Storm")) || (string)Settings.SettingsCache.GetValue("Default Skybox", null) == "Storm" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Storm" || (string)Settings.SettingsCache.GetValue("Apocalypse Skybox", null) == "Storm");
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600002C RID: 44
		public ModSettings.ColorPickerSetting EclipseShaderColorNight
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Eclipse Shader Color (Night)";
				colorPickerSetting.Description = "The shader color applied when using the Eclipse skybox, during the in-game Night phase";
				colorPickerSetting.DefaultValue = "#4A2E8A";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = (((string)Settings.SettingsCache.GetValue("Default Skybox", null) == "None" && ((string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Eclipse" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Eclipse" || (string)Settings.SettingsCache.GetValue("Dawn Skybox", null) == "Eclipse" || (string)Settings.SettingsCache.GetValue("Dusk Skybox", null) == "Eclipse")) || (string)Settings.SettingsCache.GetValue("Default Skybox", null) == "Eclipse" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Eclipse" || (string)Settings.SettingsCache.GetValue("Apocalypse Skybox", null) == "Eclipse");
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600002D RID: 45
		public ModSettings.ColorPickerSetting WinterShaderColorNight
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Winter Shader Color (Night)";
				colorPickerSetting.Description = "The shader color applied when using the Winter skybox, during the in-game Night phase";
				colorPickerSetting.DefaultValue = "#232C45";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = (((string)Settings.SettingsCache.GetValue("Default Skybox", null) == "None" && ((string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Winter" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Winter" || (string)Settings.SettingsCache.GetValue("Dawn Skybox", null) == "Winter" || (string)Settings.SettingsCache.GetValue("Dusk Skybox", null) == "Winter")) || (string)Settings.SettingsCache.GetValue("Default Skybox", null) == "Winter" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Winter" || (string)Settings.SettingsCache.GetValue("Apocalypse Skybox", null) == "Winter");
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600002E RID: 46
		public ModSettings.DropdownSetting SetTribunalSky
		{
			get
			{
				ModSettings.DropdownSetting dropdownSetting = new ModSettings.DropdownSetting();
				dropdownSetting.Name = "Tribunal Skybox";
				dropdownSetting.Description = "The selected skybox will be used in-game during a Marshal's Tribunal.\nSet to None to use your day skybox (or the default skybox if that is set to None).";
				dropdownSetting.Options = this.AvailableSkyboxes;
				dropdownSetting.AvailableInGame = true;
				dropdownSetting.Available = true;
				dropdownSetting.OnChanged = delegate(string s)
				{
					Settings.SettingsCache.SetValue("Tribunal Skybox", s);
					Settings.UpdateSky();
				};
				return dropdownSetting;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600002F RID: 47
		public ModSettings.DropdownSetting SetCourtSky
		{
			get
			{
				ModSettings.DropdownSetting dropdownSetting = new ModSettings.DropdownSetting();
				dropdownSetting.Name = "Court Skybox";
				dropdownSetting.Description = "The selected skybox will be used in-game during a Judge's Court.\nSet to None to use your day skybox (or the default skybox if that is set to None).";
				dropdownSetting.Options = this.AvailableSkyboxes;
				dropdownSetting.AvailableInGame = true;
				dropdownSetting.Available = ModStates.IsEnabled("curtis.tuba.better.tos2");
				dropdownSetting.OnChanged = delegate(string s)
				{
					Settings.SettingsCache.SetValue("Court Skybox", s);
					Settings.UpdateSky();
				};
				return dropdownSetting;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000030 RID: 48
		public ModSettings.DropdownSetting SetDaybreakSky
		{
			get
			{
				ModSettings.DropdownSetting dropdownSetting = new ModSettings.DropdownSetting();
				dropdownSetting.Name = "Daybreak Skybox";
				dropdownSetting.Description = "The selected skybox will be used in-game during Starspawn's Daybreak.\nSet to None to use your day skybox (or the default skybox if that is set to None).";
				dropdownSetting.Options = this.AvailableSkyboxes;
				dropdownSetting.AvailableInGame = true;
				dropdownSetting.Available = ModStates.IsEnabled("curtis.tuba.better.tos2");
				dropdownSetting.OnChanged = delegate(string s)
				{
					Settings.SettingsCache.SetValue("Daybreak Skybox", s);
					Settings.UpdateSky();
				};
				return dropdownSetting;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000031 RID: 49
		public ModSettings.DropdownSetting SetDawnSky
		{
			get
			{
				ModSettings.DropdownSetting dropdownSetting = new ModSettings.DropdownSetting();
				dropdownSetting.Name = "Dawn Skybox";
				dropdownSetting.Description = "(For real-time sync) The selected skybox will be used during your set real-time sync dawn time.";
				dropdownSetting.Options = this.AvailableSkyboxes;
				dropdownSetting.AvailableInGame = true;
				dropdownSetting.Available = ((string)Settings.SettingsCache.GetValue("Default Skybox", null) == "None");
				dropdownSetting.OnChanged = delegate(string s)
				{
					Settings.SettingsCache.SetValue("Dawn Skybox", s);
					Settings.UpdateSky();
				};
				return dropdownSetting;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000032 RID: 50
		public ModSettings.DropdownSetting SetDuskSky
		{
			get
			{
				ModSettings.DropdownSetting dropdownSetting = new ModSettings.DropdownSetting();
				dropdownSetting.Name = "Dusk Skybox";
				dropdownSetting.Description = "(For real-time sync) The selected skybox will be used during your set real-time sync dusk time.";
				dropdownSetting.Options = this.AvailableSkyboxes;
				dropdownSetting.AvailableInGame = true;
				dropdownSetting.Available = ((string)Settings.SettingsCache.GetValue("Default Skybox", null) == "None");
				dropdownSetting.OnChanged = delegate(string s)
				{
					Settings.SettingsCache.SetValue("Dusk Skybox", s);
					Settings.UpdateSky();
				};
				return dropdownSetting;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000033 RID: 51
		public ModSettings.CheckboxSetting ColorSnowflakes
		{
			get
			{
				ModSettings.CheckboxSetting checkboxSetting = new ModSettings.CheckboxSetting();
				checkboxSetting.Name = "Color Snowflakes to Shader Color";
				checkboxSetting.Description = "Toggles if the snowflakes should be recolored to your shader color";
				checkboxSetting.DefaultValue = true;
				checkboxSetting.Available = (Service.Home.Customizations.myCustomizationSelections.Data.mapId == 2);
				checkboxSetting.AvailableInGame = true;
				checkboxSetting.OnChanged = delegate(bool v)
				{
					Settings.SettingsCache.SetValue("Color Snowflakes to Shader Color", v);
					Settings.UpdateSky();
				};
				return checkboxSetting;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000035 RID: 53
		public ModSettings.DropdownSetting JailCellShadingMode
		{
			get
			{
				ModSettings.DropdownSetting dropdownSetting = new ModSettings.DropdownSetting();
				dropdownSetting.Name = "Jail Cell Shading Mode";
				dropdownSetting.Description = "Choose how the jail cell will be shaded\nNormal - Remains unshaded\nNight - Shades the jail cell to the nighttime color\nCustom - Use a custom shader color for the jail cell";
				dropdownSetting.Options = this.JailCellShadingModes;
				dropdownSetting.AvailableInGame = true;
				dropdownSetting.Available = true;
				dropdownSetting.OnChanged = delegate(string s)
				{
					Settings.SettingsCache.SetValue("Jail Cell Shading Mode", s);
					Settings.UpdateSky();
				};
				return dropdownSetting;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000036 RID: 54
		public ModSettings.ColorPickerSetting GreekShaderColor
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Greek Shader Color";
				colorPickerSetting.Description = "The shader color applied when using the Greek skybox";
				colorPickerSetting.DefaultValue = "#A5B0BD";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = (((string)Settings.SettingsCache.GetValue("Default Skybox", null) == "None" && ((string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Greek" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Greek" || (string)Settings.SettingsCache.GetValue("Dawn Skybox", null) == "Greek" || (string)Settings.SettingsCache.GetValue("Dusk Skybox", null) == "Greek")) || (string)Settings.SettingsCache.GetValue("Default Skybox", null) == "Greek" || (string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Greek" || (string)Settings.SettingsCache.GetValue("Apocalypse Skybox", null) == "Greek" || (string)Settings.SettingsCache.GetValue("Tribunal Skybox", null) == "Greek" || (ModStates.IsEnabled("curtis.tuba.better.tos2") && ((string)Settings.SettingsCache.GetValue("Court Skybox", null) == "Greek" || (string)Settings.SettingsCache.GetValue("Daybreak Skybox", null) == "Greek")));
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000037 RID: 55
		public ModSettings.ColorPickerSetting GreekShaderColorNight
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Greek Shader Color (Night)";
				colorPickerSetting.Description = "The shader color applied when using the Greek skybox, during the in-game Night phase";
				colorPickerSetting.DefaultValue = "#546A7B";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = (((string)Settings.SettingsCache.GetValue("Default Skybox", null) == "None" && ((string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Greek" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Greek" || (string)Settings.SettingsCache.GetValue("Dawn Skybox", null) == "Greek" || (string)Settings.SettingsCache.GetValue("Dusk Skybox", null) == "Greek")) || (string)Settings.SettingsCache.GetValue("Default Skybox", null) == "Greek" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Greek" || (string)Settings.SettingsCache.GetValue("Apocalypse Skybox", null) == "Greek");
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000038 RID: 56
		public ModSettings.ColorPickerSetting VoidShaderColor
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Void Shader Color";
				colorPickerSetting.Description = "The shader color applied when using the Void skybox";
				colorPickerSetting.DefaultValue = "#0F0F0F";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = (((string)Settings.SettingsCache.GetValue("Default Skybox", null) == "None" && ((string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Void" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Void" || (string)Settings.SettingsCache.GetValue("Dawn Skybox", null) == "Void" || (string)Settings.SettingsCache.GetValue("Dusk Skybox", null) == "Void")) || (string)Settings.SettingsCache.GetValue("Default Skybox", null) == "Void" || (string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Void" || (string)Settings.SettingsCache.GetValue("Apocalypse Skybox", null) == "Void" || (string)Settings.SettingsCache.GetValue("Tribunal Skybox", null) == "Void" || (ModStates.IsEnabled("curtis.tuba.better.tos2") && ((string)Settings.SettingsCache.GetValue("Court Skybox", null) == "Void" || (string)Settings.SettingsCache.GetValue("Daybreak Skybox", null) == "Void")));
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000039 RID: 57
		public ModSettings.ColorPickerSetting VoidShaderColorNight
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Void Shader Color (Night)";
				colorPickerSetting.Description = "The shader color applied when using the Void skybox, during the in-game Night phase";
				colorPickerSetting.DefaultValue = "#000000";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = (((string)Settings.SettingsCache.GetValue("Default Skybox", null) == "None" && ((string)Settings.SettingsCache.GetValue("Day Skybox", null) == "Void" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Void" || (string)Settings.SettingsCache.GetValue("Dawn Skybox", null) == "Void" || (string)Settings.SettingsCache.GetValue("Dusk Skybox", null) == "Void")) || (string)Settings.SettingsCache.GetValue("Default Skybox", null) == "Void" || (string)Settings.SettingsCache.GetValue("Night Skybox", null) == "Void" || (string)Settings.SettingsCache.GetValue("Apocalypse Skybox", null) == "Void");
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600003A RID: 58
		public ModSettings.ColorPickerSetting JailCellShaderColor
		{
			get
			{
				ModSettings.ColorPickerSetting colorPickerSetting = new ModSettings.ColorPickerSetting();
				colorPickerSetting.Name = "Jail Cell Shader Color";
				colorPickerSetting.Description = "(For Custom jail cell shading mode) The shader color applied inside of the jail cell";
				colorPickerSetting.DefaultValue = "#FFFFFF";
				colorPickerSetting.AvailableInGame = true;
				colorPickerSetting.Available = ((string)Settings.SettingsCache.GetValue("Jail Cell Shading Mode", null) == "Custom");
				colorPickerSetting.OnChanged = delegate(Color s)
				{
					Settings.UpdateSky();
				};
				return colorPickerSetting;
			}
		}

		// Token: 0x0400000A RID: 10
		private readonly List<string> AvailableSkyboxes = new List<string>(11)
		{
			"None",
			"Day",
			"Night",
			"Dawn",
			"Dusk",
			"Blood Moon",
			"Storm",
			"Eclipse",
			"Winter",
			"Greek",
			"Void"
		};

		// Token: 0x0400000B RID: 11
		private readonly List<string> JailCellShadingModes = new List<string>(3)
		{
			"Normal",
			"Night",
			"Custom"
		};

		// Token: 0x04000070 RID: 112
		public static Dictionary<string, object> SettingsCache = new Dictionary<string, object>
		{
			{
				"Default Skybox",
				"None"
			},
			{
				"Day Skybox",
				"None"
			},
			{
				"Night Skybox",
				"None"
			},
			{
				"Dawn Skybox",
				"None"
			},
			{
				"Dusk Skybox",
				"None"
			},
			{
				"Apocalypse Skybox",
				"None"
			},
			{
				"Tribunal Skybox",
				"None"
			},
			{
				"Court Skybox",
				"None"
			},
			{
				"Daybreak Skybox",
				"None"
			},
			{
				"Color Snowflakes to Shader Color",
				false
			},
			{
				"Jail Cell Shading Mode",
				"Normal"
			}
		};
	}
}
