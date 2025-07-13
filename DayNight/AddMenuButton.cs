using System;
using System.Diagnostics;
using System.IO;
using Services;
using SML;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace DayNight
{
    // Token: 0x02000005 RID: 5
    [Mod.SalemMenuItem]
    public class AddMenuButton
    {
        // Token: 0x06000005 RID: 5 RVA: 0x000020EC File Offset: 0x000002EC

        // Token: 0x06000006 RID: 6 RVA: 0x00002198 File Offset: 0x00000398
        public static void OpenDirectory()
        {
            bool flag = Environment.OSVersion.Platform == PlatformID.WinCE || Environment.OSVersion.Platform == PlatformID.Win32Windows || Environment.OSVersion.Platform == PlatformID.Win32S || Environment.OSVersion.Platform == PlatformID.Win32NT;
            bool flag2 = flag;
            if (flag2)
            {
                Console.WriteLine("Opening dir on windows");
                string text = "\"" + AddMenuButton.FolderPath + "\"";
                text = text.Replace("/", "\\");
                Process.Start("explorer.exe", text);
            }
            else
            {
                bool flag3 = Environment.OSVersion.Platform == PlatformID.MacOSX || Environment.OSVersion.Platform == PlatformID.Unix;
                if (flag3)
                {
                    Console.WriteLine("Opening dir on Mac");
                    Process.Start("open", "\"" + AddMenuButton.FolderPath + "\"");
                }
            }
        }

        // Token: 0x04000002 RID: 2
        public static Mod.SalemMenuButton button = new Mod.SalemMenuButton
        {
            Icon = FromResources.LoadSprite("DayNight.resources.images.thumbnail.png", 100f, SpriteMeshType.Tight),
            Label = "Open Custom Skybox",
            OnClick = delegate
            {
                AddMenuButton.OpenDirectory();
            }
        };

        // Token: 0x04000003 RID: 3
        private static readonly string FolderPath = Path.GetDirectoryName(Application.dataPath) + "/SalemModLoader/ModFolders/CustomSkybox/";
    }
}