using System;
using Game.Chat.Decoders;
using HarmonyLib;
using Server.Shared.Messages;
using Server.Shared.State;
using Server.Shared.State.Chat;

namespace SkyControllerPP
{
	// Token: 0x0200000C RID: 12
	[HarmonyPatch(typeof(WhoDiedRoleDecoder), "Encode")]
	public class RevertApocalypse
	{
		// Token: 0x06000014 RID: 20 RVA: 0x000029C8 File Offset: 0x00000BC8
		[HarmonyPostfix]
		public static void Postfix(ChatLogMessage chatLogMessage)
		{
			bool flag = !(SkyInfo.Instance == null);
			bool flag2 = flag;
			if (flag2)
			{
				KillRecord killRecord = ((ChatLogWhoDiedEntry)chatLogMessage.chatLogEntry).killRecord;
				bool flag3 = killRecord != null;
				bool flag4 = flag3;
				if (flag4)
				{
					switch (killRecord.playerRole)
					{
					case Role.FAMINE:
						SkyInfo.Instance.Famine = false;
						break;
					case Role.WAR:
						SkyInfo.Instance.War = false;
						break;
					case Role.PESTILENCE:
						SkyInfo.Instance.Pest = false;
						break;
					case Role.DEATH:
						SkyInfo.Instance.Death = false;
						break;
					}
				}
			}
		}
	}
}
