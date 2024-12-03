using System;
using UnityEngine;

namespace SkyControllerPP
{
	// Token: 0x02000012 RID: 18
	public static class GameObjectExtensions
	{
		// Token: 0x06000087 RID: 135 RVA: 0x0000554C File Offset: 0x0000374C
		public static void SetAllChildrenActive(this GameObject gameObject)
		{
			int childCount = gameObject.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				gameObject.transform.GetChild(i).gameObject.SetActive(true);
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00005590 File Offset: 0x00003790
		public static Sprite ConvertToSprite(this Texture2D tex)
		{
			return Sprite.Create(tex, new Rect(0f, 0f, (float)tex.width, (float)tex.height), new Vector2((float)(tex.width / 2), (float)(tex.height / 2)));
		}
	}
}
