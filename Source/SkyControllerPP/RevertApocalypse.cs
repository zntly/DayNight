using System;
using Game.Chat.Decoders;
using HarmonyLib;
using Server.Shared.Messages;
using Server.Shared.State;
using Server.Shared.State.Chat;

namespace SkyControllerPP
{
	// Token: 0x02000005 RID: 5
	[HarmonyPatch(typeof(WhoDiedRoleDecoder), "Encode")]
	public class RevertApocalypse
	{
		// Token: 0x06000005 RID: 5 RVA: 0x00002440 File Offset: 0x00000640
		[HarmonyPostfix]
		public static void Postfix(ChatLogMessage chatLogMessage)
		{
			if (!(SkyInfo.Instance == null))
			{
				KillRecord killRecord = ((ChatLogWhoDiedEntry)chatLogMessage.chatLogEntry).killRecord;
				if (killRecord != null)
				{
					switch (killRecord.playerRole)
					{
					case Role.FAMINE:
						SkyInfo.Instance.Famine = false;
						return;
					case Role.WAR:
						SkyInfo.Instance.War = false;
						return;
					case Role.PESTILENCE:
						SkyInfo.Instance.Pest = false;
						return;
					case Role.DEATH:
						SkyInfo.Instance.Death = false;
						break;
					default:
						return;
					}
				}
			}
		}
	}
}
