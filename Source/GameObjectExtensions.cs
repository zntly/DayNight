using System;
using UnityEngine;

namespace SkyControllerPP
{
	// Token: 0x02000013 RID: 19
	public static class GameObjectExtensions
	{
		// Token: 0x06000093 RID: 147 RVA: 0x00006310 File Offset: 0x00004510
		public static void SetAllChildrenActive(this GameObject gameObject)
		{
			int childCount = gameObject.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				gameObject.transform.GetChild(i).gameObject.SetActive(true);
			}
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00006354 File Offset: 0x00004554
		public static Sprite ConvertToSprite(this Texture2D tex)
		{
			return Sprite.Create(tex, new Rect(0f, 0f, (float)tex.width, (float)tex.height), new Vector2((float)(tex.width / 2), (float)(tex.height / 2)));
		}
	}
}
