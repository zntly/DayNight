﻿using System;
using UnityEngine;

namespace DayNight
{
    // Token: 0x02000006 RID: 6
    public static class GameObjectExtensions
    {
        // Token: 0x06000007 RID: 7 RVA: 0x000023EC File Offset: 0x000005EC
        public static void SetAllChildrenActive(this GameObject gameObject)
        {
            int childCount = gameObject.transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        // Token: 0x06000008 RID: 8 RVA: 0x00002430 File Offset: 0x00000630
        public static Sprite ConvertToSprite(this Texture2D tex)
        {
            return Sprite.Create(tex, new Rect(0f, 0f, (float)tex.width, (float)tex.height), new Vector2((float)(tex.width / 2), (float)(tex.height / 2)));
        }
    }
}
