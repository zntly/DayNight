using System;
using UnityEngine;

namespace SkyControllerPP
{
	// Token: 0x02000013 RID: 19
	public static class GameObjectExtensions
	{
		// Token: 0x0600008E RID: 142 RVA: 0x000056AC File Offset: 0x000038AC
		public static void SetAllChildrenActive(this GameObject gameObject)
		{
			int childCount = gameObject.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				gameObject.transform.GetChild(i).gameObject.SetActive(true);
			}
		}

		// Token: 0x0600008F RID: 143 RVA: 0x000056F0 File Offset: 0x000038F0
		public static Sprite ConvertToSprite(this Texture2D tex)
		{
			return Sprite.Create(tex, new Rect(0f, 0f, (float)tex.width, (float)tex.height), new Vector2((float)(tex.width / 2), (float)(tex.height / 2)));
		}
	}
}
