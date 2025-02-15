using System;
using Game.Chat.Decoders;
using HarmonyLib;
using Server.Shared.Messages;
using Server.Shared.State;
using Server.Shared.State.Chat;

namespace SkyControllerPP
{
	// Token: 0x0200000B RID: 11
	[HarmonyPatch(typeof(WhoDiedRoleDecoder), "Encode")]
	public class RevertApocalypse
	{
		// Token: 0x06000010 RID: 16 RVA: 0x000025CC File Offset: 0x000007CC
		[HarmonyPostfix]
		public static void Postfix(ChatLogMessage chatLogMessage)
		{
			bool flag = !(SkyInfo.Instance == null);
			if (flag)
			{
				KillRecord killRecord = ((ChatLogWhoDiedEntry)chatLogMessage.chatLogEntry).killRecord;
				bool flag2 = killRecord != null;
				if (flag2)
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
