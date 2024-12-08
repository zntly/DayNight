using System;
using UnityEngine;

namespace SkyControllerPP
{
	// Token: 0x02000012 RID: 18
	public static class GameObjectExtensions
	{
		// Token: 0x0600008A RID: 138 RVA: 0x000060B8 File Offset: 0x000042B8
		public static void SetAllChildrenActive(this GameObject gameObject)
		{
			int childCount = gameObject.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				gameObject.transform.GetChild(i).gameObject.SetActive(true);
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000060FC File Offset: 0x000042FC
		public static Sprite ConvertToSprite(this Texture2D tex)
		{
			return Sprite.Create(tex, new Rect(0f, 0f, (float)tex.width, (float)tex.height), new Vector2((float)(tex.width / 2), (float)(tex.height / 2)));
		}
	}
}
