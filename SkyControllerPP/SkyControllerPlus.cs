using System;
using Server.Shared.Extensions;
using SML;
using UnityEngine;

namespace SkyControllerPP
{
	// Token: 0x02000011 RID: 17
	public class SkyControllerPlus : MonoBehaviour
	{
		// Token: 0x0600003B RID: 59 RVA: 0x00004704 File Offset: 0x00002904
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

		// Token: 0x0600003C RID: 60 RVA: 0x000048E8 File Offset: 0x00002AE8
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

		// Token: 0x0600003D RID: 61 RVA: 0x00004CD8 File Offset: 0x00002ED8
		private void BuildDaySky()
		{
			this.dayDecor = base.transform.Find("Day").gameObject;
			this.dayDecor.SetAllChildrenActive();
			this.dayDecor.transform.GetComponentsInChildren<SpriteRenderer>().ForEach(delegate(SpriteRenderer s)
			{
				this.SetCloudType(s, "Day");
			});
			Transform transform = this.dayDecor.transform.Find("Sun");
			bool flag = transform.localPosition.y < 0f;
			if (flag)
			{
				transform.localPosition = new Vector3(277f, 215f, 463f);
				transform.localScale = new Vector3(13f, 13f, 13f);
			}
			this.UpdateIntroClouds("Day");
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00004DA0 File Offset: 0x00002FA0
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

		// Token: 0x0600003F RID: 63 RVA: 0x00004E0C File Offset: 0x0000300C
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

		// Token: 0x06000040 RID: 64 RVA: 0x00004EC4 File Offset: 0x000030C4
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
			bool flag = transform.localPosition.y > 0f;
			if (flag)
			{
				transform.localPosition = new Vector3(-3f, -70f, 742f);
				transform.localScale = new Vector3(34f, 34f, 34f);
			}
			this.UpdateIntroClouds("Dawn");
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00004FC0 File Offset: 0x000031C0
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

		// Token: 0x06000042 RID: 66 RVA: 0x00005060 File Offset: 0x00003260
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

		// Token: 0x06000043 RID: 67 RVA: 0x000051D0 File Offset: 0x000033D0
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
			bool flag2 = flag;
			if (flag2)
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

		// Token: 0x06000044 RID: 68 RVA: 0x00005328 File Offset: 0x00003528
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

		// Token: 0x06000045 RID: 69 RVA: 0x000053E0 File Offset: 0x000035E0
		private void SetCloudType(SpriteRenderer s, string type)
		{
			bool flag = s != null;
			bool flag2 = flag;
			if (flag2)
			{
				Transform parent = s.transform.parent;
				bool flag3 = parent.name.Contains("Cloud_");
				bool flag4 = flag3;
				if (flag4)
				{
					bool flag5 = type == "Invis";
					bool flag6 = flag5;
					if (flag6)
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
							bool flag7 = s.color.a == 0f;
							bool flag8 = flag7;
							if (flag8)
							{
								s.color = new Color(1f, 1f, 1f, 1f);
							}
							bool flag9 = parent.parent.name.Contains("Transparent");
							bool flag10 = flag9;
							if (flag10)
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

		// Token: 0x06000046 RID: 70 RVA: 0x000055CC File Offset: 0x000037CC
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
			SkyInfo.CurrentActive = skyType;
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

		// Token: 0x06000047 RID: 71 RVA: 0x000057CC File Offset: 0x000039CC
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
			bool flag2 = Main.Snowflakes != null;
			if (flag2)
			{
				bool @bool = ModSettings.GetBool("Color Snowflakes to Shader Color (Winter Map)");
				if (@bool)
				{
					bool flag3 = Main.Snowflakes.startColor != SkyInfo.GetSkyColor(skyType);
					Main.Snowflakes.startColor = SkyInfo.GetSkyColor(skyType);
					bool flag4 = flag3;
					if (flag4)
					{
						Main.Snowflakes.Clear();
						Main.Snowflakes.Emit(250);
					}
				}
				else
				{
					bool flag5 = Main.Snowflakes.startColor != new Color(1f, 1f, 1f, 1f);
					Main.Snowflakes.startColor = new Color(1f, 1f, 1f, 1f);
					bool flag6 = flag5;
					if (flag6)
					{
						Main.Snowflakes.Clear();
						Main.Snowflakes.Emit(250);
					}
				}
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00005928 File Offset: 0x00003B28
		public SkyInfo.SkyType RandomSkyType()
		{
			System.Random random = new System.Random();
			return (SkyInfo.SkyType)random.Next(2, 10);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x0000594C File Offset: 0x00003B4C
		private void SetMoon(SkyInfo.SkyType skyType)
		{
			bool flag = skyType != SkyInfo.SkyType.Night;
			if (flag)
			{
				bool flag2 = skyType != SkyInfo.SkyType.BloodMoon;
				if (flag2)
				{
					bool flag3 = skyType == SkyInfo.SkyType.Eclipse;
					if (flag3)
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

		// Token: 0x0600004A RID: 74 RVA: 0x00005B64 File Offset: 0x00003D64
		public SkyInfo.SkyType GetCurrentSkyType()
		{
			SkyInfo.SkyType skyType = SkyInfo.GetCurrentPermSkyType();
			bool flag = skyType == SkyInfo.SkyType.None;
			if (flag)
			{
				int @int = ModSettings.GetInt("Dawn/Dusk Length");
				TimeSpan t = TimeSpan.Parse(ModSettings.GetString("Night Start"));
				TimeSpan t2 = TimeSpan.Parse(ModSettings.GetString("Night End"));
				TimeSpan timeOfDay = DateTime.Now.TimeOfDay;
				TimeSpan t3 = t2.Add(new TimeSpan(0, -@int / 2, 0));
				TimeSpan t4 = t2.Add(new TimeSpan(0, @int / 2, 0));
				TimeSpan t5 = t.Add(new TimeSpan(0, -@int / 2, 0));
				TimeSpan t6 = t.Add(new TimeSpan(0, @int / 2, 0));
				bool flag2 = t > t2;
				if (flag2)
				{
					bool flag3 = timeOfDay >= t6 || timeOfDay <= t3;
					if (flag3)
					{
						SkyInfo.TOD = "Night";
					}
					else
					{
						bool flag4 = timeOfDay > t3 && timeOfDay < t4;
						if (flag4)
						{
							SkyInfo.TOD = "Dawn";
						}
						else
						{
							bool flag5 = timeOfDay > t5 && timeOfDay < t6;
							if (flag5)
							{
								SkyInfo.TOD = "Dusk";
							}
							else
							{
								SkyInfo.TOD = "Day";
							}
						}
					}
				}
				else
				{
					bool flag6 = timeOfDay >= t6 && timeOfDay <= t3;
					if (flag6)
					{
						SkyInfo.TOD = "Night";
					}
					else
					{
						bool flag7 = timeOfDay > t3 && timeOfDay < t4;
						if (flag7)
						{
							SkyInfo.TOD = "Dawn";
						}
						else
						{
							bool flag8 = timeOfDay > t5 && timeOfDay < t6;
							if (flag8)
							{
								SkyInfo.TOD = "Dusk";
							}
							else
							{
								SkyInfo.TOD = "Day";
							}
						}
					}
				}
				skyType = SkyInfo.GetSyncedSkyType();
			}
			bool flag9 = this.Pest || this.Famine || this.Death || this.War;
			if (flag9)
			{
				SkyInfo.SkyType currentApocSkyType = SkyInfo.GetCurrentApocSkyType();
				bool flag10 = currentApocSkyType > SkyInfo.SkyType.None;
				if (flag10)
				{
					skyType = currentApocSkyType;
				}
			}
			bool flag11 = skyType == SkyInfo.SkyType.Random;
			if (flag11)
			{
				skyType = this.RandomSkyType();
			}
			return skyType;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00005DA4 File Offset: 0x00003FA4
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

		// Token: 0x0600004C RID: 76 RVA: 0x00005E08 File Offset: 0x00004008
		public void UpdateSky()
		{
			SkyInfo.SkyType currentSkyType = this.GetCurrentSkyType();
			this.SetCurrentSkyType(currentSkyType);
			this.SetSkyShader(currentSkyType);
		}

		// Token: 0x0400000A RID: 10
		private GameObject daySkybox;

		// Token: 0x0400000B RID: 11
		private GameObject dayDecor;

		// Token: 0x0400000C RID: 12
		private GameObject nightSkybox;

		// Token: 0x0400000D RID: 13
		private GameObject nightDecor;

		// Token: 0x0400000E RID: 14
		private GameObject dawnSkybox;

		// Token: 0x0400000F RID: 15
		private GameObject dawnDecor;

		// Token: 0x04000010 RID: 16
		private GameObject duskSkybox;

		// Token: 0x04000011 RID: 17
		private GameObject duskDecor;

		// Token: 0x04000012 RID: 18
		private GameObject bloodSkybox;

		// Token: 0x04000013 RID: 19
		private GameObject bloodDecor;

		// Token: 0x04000014 RID: 20
		private GameObject stormSkybox;

		// Token: 0x04000015 RID: 21
		private GameObject stormDecor;

		// Token: 0x04000016 RID: 22
		private GameObject eclipseSkybox;

		// Token: 0x04000017 RID: 23
		private GameObject eclipseDecor;

		// Token: 0x04000018 RID: 24
		private GameObject winterSkybox;

		// Token: 0x04000019 RID: 25
		private GameObject winterDecor;

		// Token: 0x0400001A RID: 26
		public bool Pest = false;

		// Token: 0x0400001B RID: 27
		public bool Famine = false;

		// Token: 0x0400001C RID: 28
		public bool Death = false;

		// Token: 0x0400001D RID: 29
		public bool War = false;
	}
}
