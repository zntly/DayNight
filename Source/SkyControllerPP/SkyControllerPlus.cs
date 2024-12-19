using System;
using Server.Shared.Extensions;
using SML;
using UnityEngine;

namespace SkyControllerPP
{
	// Token: 0x0200000F RID: 15
	public class SkyControllerPlus : MonoBehaviour
	{
		// Token: 0x06000061 RID: 97 RVA: 0x00004CC0 File Offset: 0x00002EC0
		private void Start()
		{
			SkyInfo.SkyType currentSkyType = this.GetCurrentSkyType();
			base.transform.GetComponent<Animator>().enabled = false;
			switch (currentSkyType)
			{
			case SkyInfo.SkyType.Day:
				this.UpdateIntroClouds("Day");
				break;
			case SkyInfo.SkyType.Night:
				this.UpdateIntroClouds("Night");
				break;
			case SkyInfo.SkyType.Dawn:
				this.UpdateIntroClouds("Dawn");
				break;
			case SkyInfo.SkyType.Dusk:
				this.UpdateIntroClouds("Dawn");
				break;
			case SkyInfo.SkyType.BloodMoon:
				this.UpdateIntroClouds("BloodMoon");
				break;
			case SkyInfo.SkyType.Storm:
				this.UpdateIntroClouds("Storm");
				break;
			case SkyInfo.SkyType.Eclipse:
				this.UpdateIntroClouds("Invis");
				break;
			case SkyInfo.SkyType.Winter:
				this.UpdateIntroClouds("Invis");
				break;
			}
			this.SetSkyShader(currentSkyType);
			this.Setup();
			this.BuildDaySky();
			this.BuildNightSky();
			this.BuildBloodMoonSky();
			this.BuildDuskSky();
			this.BuildDawnSky();
			this.BuildStormSky();
			this.BuildEclipseSky();
			this.BuildWinterSky();
			this.daySkybox.SetActive(false);
			this.nightSkybox.SetActive(false);
			this.dawnSkybox.SetActive(false);
			this.duskSkybox.SetActive(false);
			this.bloodSkybox.SetActive(false);
			this.stormSkybox.SetActive(false);
			this.eclipseSkybox.SetActive(false);
			this.winterSkybox.SetActive(false);
			this.dayDecor.SetActive(false);
			this.nightDecor.SetActive(false);
			this.dawnDecor.SetActive(false);
			this.duskDecor.SetActive(false);
			this.bloodDecor.SetActive(false);
			this.stormDecor.SetActive(false);
			this.eclipseDecor.SetActive(false);
			this.winterDecor.SetActive(false);
			this.SetCurrentSkyType(currentSkyType);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00004EA4 File Offset: 0x000030A4
		private void Setup()
		{
			this.daySkybox = base.gameObject.transform.Find("Skybox_D").gameObject;
			this.nightSkybox = UnityEngine.Object.Instantiate<GameObject>(this.daySkybox, this.daySkybox.transform.parent);
			this.dawnSkybox = UnityEngine.Object.Instantiate<GameObject>(this.daySkybox, this.daySkybox.transform.parent);
			this.duskSkybox = UnityEngine.Object.Instantiate<GameObject>(this.daySkybox, this.daySkybox.transform.parent);
			this.bloodSkybox = UnityEngine.Object.Instantiate<GameObject>(this.daySkybox, this.daySkybox.transform.parent);
			this.stormSkybox = UnityEngine.Object.Instantiate<GameObject>(this.daySkybox, this.daySkybox.transform.parent);
			this.eclipseSkybox = UnityEngine.Object.Instantiate<GameObject>(this.daySkybox, this.daySkybox.transform.parent);
			this.winterSkybox = UnityEngine.Object.Instantiate<GameObject>(this.daySkybox, this.daySkybox.transform.parent);
			this.daySkybox.name = "Skybox_Day";
			this.nightSkybox.name = "Skybox_Night";
			this.dawnSkybox.name = "Skybox_Dawn";
			this.duskSkybox.name = "Skybox_Dusk";
			this.bloodSkybox.name = "Skybox_BloodMoon";
			this.stormSkybox.name = "Skybox_Storm";
			this.eclipseSkybox.name = "Skybox_Eclipse";
			this.winterSkybox.name = "Skybox_Winter";
			this.winterSkybox.transform.SetAsFirstSibling();
			this.eclipseSkybox.transform.SetAsFirstSibling();
			this.stormSkybox.transform.SetAsFirstSibling();
			this.bloodSkybox.transform.SetAsFirstSibling();
			this.duskSkybox.transform.SetAsFirstSibling();
			this.dawnSkybox.transform.SetAsFirstSibling();
			this.nightSkybox.transform.SetAsFirstSibling();
			this.daySkybox.transform.SetAsFirstSibling();
			this.daySkybox.GetComponentInChildren<MeshRenderer>().materials.ForEach(delegate(Material m)
			{
				m.SetTexture("Texture2D_ADE76F9A", Main.Textures["Skybox_Gradient_Day"]);
			});
			this.nightSkybox.GetComponentInChildren<MeshRenderer>().materials.ForEach(delegate(Material m)
			{
				m.SetTexture("Texture2D_ADE76F9A", Main.Textures["Skybox_Gradient_Night"]);
			});
			this.dawnSkybox.GetComponentInChildren<MeshRenderer>().materials.ForEach(delegate(Material m)
			{
				m.SetTexture("Texture2D_ADE76F9A", Main.Textures["Skybox_Gradient_Dawn"]);
			});
			this.duskSkybox.GetComponentInChildren<MeshRenderer>().materials.ForEach(delegate(Material m)
			{
				m.SetTexture("Texture2D_ADE76F9A", Main.Textures["Skybox_Gradient_Dawn"]);
			});
			this.bloodSkybox.GetComponentInChildren<MeshRenderer>().materials.ForEach(delegate(Material m)
			{
				m.SetTexture("Texture2D_ADE76F9A", Main.Textures["Skybox_Gradient_BloodMoon"]);
			});
			this.stormSkybox.GetComponentInChildren<MeshRenderer>().materials.ForEach(delegate(Material m)
			{
				m.SetTexture("Texture2D_ADE76F9A", Main.Textures["Skybox_Gradient_Storm"]);
			});
			this.eclipseSkybox.GetComponentInChildren<MeshRenderer>().materials.ForEach(delegate(Material m)
			{
				m.SetTexture("Texture2D_ADE76F9A", Main.Textures["Skybox_Gradient_Eclipse"]);
			});
			this.winterSkybox.GetComponentInChildren<MeshRenderer>().materials.ForEach(delegate(Material m)
			{
				m.SetTexture("Texture2D_ADE76F9A", Main.Textures["Skybox_Gradient_Winter"]);
			});
			UnityEngine.Object.Destroy(base.gameObject.transform.Find("Skybox_N").gameObject);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00005294 File Offset: 0x00003494
		private void BuildDaySky()
		{
			this.dayDecor = base.transform.Find("Day").gameObject;
			this.dayDecor.SetAllChildrenActive();
			this.dayDecor.transform.GetComponentsInChildren<SpriteRenderer>().ForEach(delegate(SpriteRenderer s)
			{
				this.SetCloudType(s, "Day");
			});
			Transform transform = this.dayDecor.transform.Find("Sun");
			if (transform.localPosition.y < 0f)
			{
				transform.localPosition = new Vector3(277f, 215f, 463f);
				transform.localScale = new Vector3(13f, 13f, 13f);
			}
			this.UpdateIntroClouds("Day");
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00005354 File Offset: 0x00003554
		private void BuildNightSky()
		{
			this.nightDecor = base.transform.Find("Night").gameObject;
			this.nightDecor.SetAllChildrenActive();
			this.nightDecor.transform.GetComponentsInChildren<SpriteRenderer>().ForEach(delegate(SpriteRenderer s)
			{
				this.SetCloudType(s, "Night");
			});
			this.SetMoon(SkyInfo.SkyType.Night);
			this.UpdateIntroClouds("Night");
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000053BC File Offset: 0x000035BC
		private void BuildDuskSky()
		{
			this.duskDecor = UnityEngine.Object.Instantiate<GameObject>(base.transform.Find("Day").gameObject, base.transform);
			this.duskDecor.SetAllChildrenActive();
			this.duskDecor.name = "Dusk";
			this.duskDecor.transform.SetParent(base.transform);
			this.duskDecor.transform.GetComponentsInChildren<SpriteRenderer>().ForEach(delegate(SpriteRenderer s)
			{
				this.SetCloudType(s, "Dawn");
			});
			this.duskDecor.transform.Find("Sun").gameObject.SetActive(false);
			this.UpdateIntroClouds("Dawn");
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000546C File Offset: 0x0000366C
		private void BuildDawnSky()
		{
			this.dawnDecor = UnityEngine.Object.Instantiate<GameObject>(base.transform.Find("Day").gameObject, base.transform);
			this.dawnDecor.SetAllChildrenActive();
			this.dawnDecor.name = "Dawn";
			this.dawnDecor.transform.SetParent(base.transform);
			this.dawnDecor.transform.GetComponentsInChildren<SpriteRenderer>().ForEach(delegate(SpriteRenderer s)
			{
				this.SetCloudType(s, "Dawn");
			});
			Transform transform = this.dawnDecor.transform.Find("Sun");
			if (transform.localPosition.y > 0f)
			{
				transform.localPosition = new Vector3(-3f, -70f, 742f);
				transform.localScale = new Vector3(34f, 34f, 34f);
			}
			this.UpdateIntroClouds("Dawn");
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000555C File Offset: 0x0000375C
		private void BuildBloodMoonSky()
		{
			this.bloodDecor = UnityEngine.Object.Instantiate<GameObject>(base.transform.Find("Night").gameObject, base.transform);
			this.bloodDecor.SetAllChildrenActive();
			this.bloodDecor.name = "BloodMoon";
			this.bloodDecor.transform.SetParent(base.transform);
			this.bloodDecor.transform.GetComponentsInChildren<SpriteRenderer>().ForEach(delegate(SpriteRenderer s)
			{
				this.SetCloudType(s, "BloodMoon");
			});
			this.SetMoon(SkyInfo.SkyType.BloodMoon);
			this.UpdateIntroClouds("BloodMoon");
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000055F4 File Offset: 0x000037F4
		private void BuildStormSky()
		{
			this.stormDecor = UnityEngine.Object.Instantiate<GameObject>(base.transform.Find("Day").gameObject, base.transform);
			this.stormDecor.SetAllChildrenActive();
			this.stormDecor.name = "Storm";
			this.stormDecor.transform.SetParent(base.transform);
			this.stormDecor.transform.GetComponentsInChildren<SpriteRenderer>().ForEach(delegate(SpriteRenderer s)
			{
				this.SetCloudType(s, "Storm");
			});
			this.stormDecor.transform.Find("Sun").gameObject.SetActive(false);
			this.stormDecor.transform.Find("Godrays_D").gameObject.SetActive(false);
			this.stormDecor.transform.Find("CloudGroup").GetComponent<Animator>().speed = 10f;
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.stormDecor.transform.Find("CloudGroup").gameObject, this.stormDecor.transform.Find("CloudGroup").transform.parent);
			gameObject.transform.localScale = new Vector3(-0.9f, 0.9f, 0.9f);
			gameObject.GetComponent<Animator>().speed = 15f;
			this.UpdateIntroClouds("Storm");
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00005754 File Offset: 0x00003954
		private void BuildEclipseSky()
		{
			this.eclipseDecor = UnityEngine.Object.Instantiate<GameObject>(base.transform.Find("Night").gameObject, base.transform);
			this.eclipseDecor.SetAllChildrenActive();
			this.eclipseDecor.name = "Eclipse";
			this.eclipseDecor.transform.SetParent(base.transform);
			this.eclipseDecor.transform.GetComponentsInChildren<SpriteRenderer>().ForEach(delegate(SpriteRenderer s)
			{
				this.SetCloudType(s, "Invis");
			});
			this.SetMoon(SkyInfo.SkyType.Eclipse);
			Transform transform = this.eclipseDecor.transform.Find("Moon");
			transform.SetParent(this.eclipseDecor.transform);
			bool flag = Leo.IsGameScene();
			if (flag)
			{
				transform.localPosition = new Vector3(250f, 200f, 750f);
				transform.localScale = new Vector3(50f, 50f, 1f);
			}
			else
			{
				transform.localPosition = new Vector3(0f, 70f, 750f);
				transform.localScale = new Vector3(45f, 45f, 1f);
			}
			UnityEngine.Object.Destroy(this.eclipseDecor.transform.Find("MoonCloud").gameObject);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000058AC File Offset: 0x00003AAC
		private void BuildWinterSky()
		{
			this.winterDecor = UnityEngine.Object.Instantiate<GameObject>(base.transform.Find("Day").gameObject, base.transform);
			this.winterDecor.SetAllChildrenActive();
			this.winterDecor.name = "Winter";
			this.winterDecor.transform.SetParent(base.transform);
			this.winterDecor.transform.GetComponentsInChildren<SpriteRenderer>().ForEach(delegate(SpriteRenderer s)
			{
				this.SetCloudType(s, "Invis");
			});
			this.winterDecor.transform.Find("Sun").gameObject.SetActive(false);
			this.UpdateIntroClouds("Invis");
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000595C File Offset: 0x00003B5C
		private void SetCloudType(SpriteRenderer s, string type)
		{
			bool flag = s != null;
			if (flag)
			{
				Transform parent = s.transform.parent;
				bool flag2 = parent.name.Contains("Cloud_");
				if (flag2)
				{
					bool flag3 = type == "Invis";
					if (flag3)
					{
						s.color = new Color(1f, 1f, 1f, 0f);
					}
					else
					{
						try
						{
							string key = type + "_Cloud_" + parent.name.Substring(parent.name.IndexOf("Cloud_") + 6, 1);
							Texture2D texture2D = Main.Textures[key];
							s.sprite = Sprite.Create(texture2D, new Rect(0f, 0f, (float)texture2D.width, (float)texture2D.height), new Vector2(s.sprite.pivot.x / (float)texture2D.width, s.sprite.pivot.y / (float)texture2D.height), s.sprite.pixelsPerUnit, 0U, SpriteMeshType.Tight, s.sprite.border);
							bool flag4 = s.color.a == 0f;
							if (flag4)
							{
								s.color = new Color(1f, 1f, 1f, 1f);
							}
							bool flag5 = parent.parent.name.Contains("Transparent");
							if (flag5)
							{
								s.color = new Color(1f, 1f, 1f, 0.25f);
							}
						}
						catch (Exception exception)
						{
							Debug.LogException(exception);
						}
					}
				}
			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00005B2C File Offset: 0x00003D2C
		public void SetCurrentSkyType(SkyInfo.SkyType skyType)
		{
			this.daySkybox.SetActive(false);
			this.dayDecor.SetActive(false);
			this.nightSkybox.SetActive(false);
			this.nightDecor.SetActive(false);
			this.dawnSkybox.SetActive(false);
			this.dawnDecor.SetActive(false);
			this.duskSkybox.SetActive(false);
			this.duskDecor.SetActive(false);
			this.bloodSkybox.SetActive(false);
			this.bloodDecor.SetActive(false);
			this.stormSkybox.SetActive(false);
			this.stormDecor.SetActive(false);
			this.eclipseSkybox.SetActive(false);
			this.eclipseDecor.SetActive(false);
			this.winterSkybox.SetActive(false);
			this.winterDecor.SetActive(false);
			switch (skyType)
			{
			case SkyInfo.SkyType.Day:
				this.daySkybox.SetActive(true);
				this.dayDecor.SetActive(true);
				break;
			case SkyInfo.SkyType.Night:
				this.nightSkybox.SetActive(true);
				this.nightDecor.SetActive(true);
				break;
			case SkyInfo.SkyType.Dawn:
				this.dawnSkybox.SetActive(true);
				this.dawnDecor.SetActive(true);
				break;
			case SkyInfo.SkyType.Dusk:
				this.duskSkybox.SetActive(true);
				this.duskDecor.SetActive(true);
				break;
			case SkyInfo.SkyType.BloodMoon:
				this.bloodSkybox.SetActive(true);
				this.bloodDecor.SetActive(true);
				break;
			case SkyInfo.SkyType.Storm:
				this.stormSkybox.SetActive(true);
				this.stormDecor.SetActive(true);
				break;
			case SkyInfo.SkyType.Eclipse:
				this.eclipseSkybox.SetActive(true);
				this.eclipseDecor.SetActive(true);
				break;
			case SkyInfo.SkyType.Winter:
				this.winterSkybox.SetActive(true);
				this.winterDecor.SetActive(true);
				break;
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00005D24 File Offset: 0x00003F24
		public void SetSkyShader(SkyInfo.SkyType skyType)
		{
			GameObject gameObject = GameObject.Find("ShaderColors");
			HomeShaderColors orAddComponent = gameObject.GetOrAddComponent<HomeShaderColors>();
			orAddComponent.homeColor = SkyInfo.GetSkyColor(skyType);
			orAddComponent.Start();
			bool flag = gameObject.transform.GetComponent<GlobalShaderColors>() != null;
			if (flag)
			{
				GlobalShaderColors component = gameObject.GetComponent<GlobalShaderColors>();
				component.dayColor = SkyInfo.GetSkyColor(skyType);
				component.nightColor = SkyInfo.GetSkyColor(skyType);
				component.Start();
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00005D94 File Offset: 0x00003F94
		public SkyInfo.SkyType RandomSkyType()
		{
			System.Random random = new System.Random();
			return (SkyInfo.SkyType)random.Next(2, 10);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00005DB8 File Offset: 0x00003FB8
		private void SetMoon(SkyInfo.SkyType skyType)
		{
			if (skyType != SkyInfo.SkyType.Night)
			{
				if (skyType != SkyInfo.SkyType.BloodMoon)
				{
					if (skyType == SkyInfo.SkyType.Eclipse)
					{
						SpriteRenderer componentInChildren = this.eclipseDecor.transform.Find("Moon").GetComponentInChildren<SpriteRenderer>();
						Texture2D texture2D = Main.Textures["Eclipse"];
						componentInChildren.sprite = Sprite.Create(texture2D, new Rect(0f, 0f, (float)texture2D.width, (float)texture2D.height), new Vector2(componentInChildren.sprite.pivot.x / (float)texture2D.width, componentInChildren.sprite.pivot.y / (float)texture2D.height), componentInChildren.sprite.pixelsPerUnit, 0U, SpriteMeshType.Tight, componentInChildren.sprite.border);
						componentInChildren.color = new Color(1f, 1f, 1f, 1f);
					}
				}
				else
				{
					SpriteRenderer componentInChildren2 = this.bloodDecor.transform.Find("Moon").GetComponentInChildren<SpriteRenderer>();
					Texture2D texture2D2 = Main.Textures["BloodMoon"];
					componentInChildren2.sprite = Sprite.Create(texture2D2, new Rect(0f, 0f, (float)texture2D2.width, (float)texture2D2.height), new Vector2(componentInChildren2.sprite.pivot.x / (float)texture2D2.width, componentInChildren2.sprite.pivot.y / (float)texture2D2.height), componentInChildren2.sprite.pixelsPerUnit, 0U, SpriteMeshType.Tight, componentInChildren2.sprite.border);
					componentInChildren2.color = new Color(1f, 1f, 1f, 1f);
				}
			}
			else
			{
				this.nightDecor.transform.Find("Moon").GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00005FB4 File Offset: 0x000041B4
		public SkyInfo.SkyType GetCurrentSkyType()
		{
			SkyInfo.SkyType skyType = SkyInfo.GetCurrentPermSkyType();
			if (skyType == SkyInfo.SkyType.None)
			{
				int @int = ModSettings.GetInt("Dawn/Dusk Length");
				TimeSpan t = TimeSpan.Parse(ModSettings.GetString("Night Start"));
				TimeSpan t2 = TimeSpan.Parse(ModSettings.GetString("Night End"));
				TimeSpan timeOfDay = DateTime.Now.TimeOfDay;
				TimeSpan t3 = t2.Add(new TimeSpan(0, -@int / 2, 0));
				TimeSpan t4 = t2.Add(new TimeSpan(0, @int / 2, 0));
				TimeSpan t5 = t.Add(new TimeSpan(0, -@int / 2, 0));
				TimeSpan t6 = t.Add(new TimeSpan(0, @int / 2, 0));
				if (t > t2)
				{
					if (timeOfDay >= t6 || timeOfDay <= t3)
					{
						SkyInfo.TOD = "Night";
					}
					else if (timeOfDay > t3 && timeOfDay < t4)
					{
						SkyInfo.TOD = "Dawn";
					}
					else if (timeOfDay > t5 && timeOfDay < t6)
					{
						SkyInfo.TOD = "Dusk";
					}
					else
					{
						SkyInfo.TOD = "Day";
					}
				}
				else if (timeOfDay >= t6 && timeOfDay <= t3)
				{
					SkyInfo.TOD = "Night";
				}
				else if (timeOfDay > t3 && timeOfDay < t4)
				{
					SkyInfo.TOD = "Dawn";
				}
				else if (timeOfDay > t5 && timeOfDay < t6)
				{
					SkyInfo.TOD = "Dusk";
				}
				else
				{
					SkyInfo.TOD = "Day";
				}
				skyType = SkyInfo.GetSyncedSkyType();
			}
			if (this.Pest || this.Famine || this.Death || this.War)
			{
				SkyInfo.SkyType currentApocSkyType = SkyInfo.GetCurrentApocSkyType();
				if (currentApocSkyType > SkyInfo.SkyType.None)
				{
					skyType = currentApocSkyType;
				}
			}
			if (skyType == SkyInfo.SkyType.Random)
			{
				skyType = this.RandomSkyType();
			}
			return skyType;
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00006194 File Offset: 0x00004394
		public void UpdateIntroClouds(string type)
		{
			try
			{
				GameObject.Find("❖Timeline/IntroVCam/").transform.GetComponentsInChildren<SpriteRenderer>().ForEach(delegate(SpriteRenderer s)
				{
					this.SetCloudType(s, type);
				});
			}
			catch
			{
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x000061F0 File Offset: 0x000043F0
		public void UpdateSky()
		{
			SkyInfo.SkyType currentSkyType = this.GetCurrentSkyType();
			this.SetCurrentSkyType(currentSkyType);
			this.SetSkyShader(currentSkyType);
		}

		// Token: 0x04000039 RID: 57
		private GameObject daySkybox;

		// Token: 0x0400003A RID: 58
		private GameObject dayDecor;

		// Token: 0x0400003B RID: 59
		private GameObject nightSkybox;

		// Token: 0x0400003C RID: 60
		private GameObject nightDecor;

		// Token: 0x0400003D RID: 61
		private GameObject dawnSkybox;

		// Token: 0x0400003E RID: 62
		private GameObject dawnDecor;

		// Token: 0x0400003F RID: 63
		private GameObject duskSkybox;

		// Token: 0x04000040 RID: 64
		private GameObject duskDecor;

		// Token: 0x04000041 RID: 65
		private GameObject bloodSkybox;

		// Token: 0x04000042 RID: 66
		private GameObject bloodDecor;

		// Token: 0x04000043 RID: 67
		private GameObject stormSkybox;

		// Token: 0x04000044 RID: 68
		private GameObject stormDecor;

		// Token: 0x04000045 RID: 69
		private GameObject eclipseSkybox;

		// Token: 0x04000046 RID: 70
		private GameObject eclipseDecor;

		// Token: 0x04000047 RID: 71
		private GameObject winterSkybox;

		// Token: 0x04000048 RID: 72
		private GameObject winterDecor;

		// Token: 0x04000049 RID: 73
		public bool Pest = false;

		// Token: 0x0400004A RID: 74
		public bool Famine = false;

		// Token: 0x0400004B RID: 75
		public bool Death = false;

		// Token: 0x0400004C RID: 76
		public bool War = false;
	}
}
