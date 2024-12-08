using System;
using Game.Chat.Decoders;
using HarmonyLib;
using Server.Shared.Messages;
using Server.Shared.State;
using Server.Shared.State.Chat;

namespace SkyControllerPP
{
	// Token: 0x02000004 RID: 4
	[HarmonyPatch(typeof(TransformGameMessageDecoder), "Encode")]
	public class ApocalypseSwap
	{
		// Token: 0x06000003 RID: 3 RVA: 0x000023B8 File Offset: 0x000005B8
		[HarmonyPostfix]
		public static void Postfix(ChatLogMessage chatLogMessage)
		{
			if (!(SkyInfo.Instance == null))
			{
				ChatLogGameMessageEntry chatLogGameMessageEntry = (ChatLogGameMessageEntry)chatLogMessage.chatLogEntry;
				if (chatLogGameMessageEntry != null)
				{
					GameFeedbackMessage messageId = chatLogGameMessageEntry.messageId;
					if (messageId <= GameFeedbackMessage.PESTILENCE_HAS_EMERGED)
					{
						if (messageId == GameFeedbackMessage.FAMINE_HAS_EMERGED)
						{
							SkyInfo.Instance.Famine = true;
							return;
						}
						if (messageId == GameFeedbackMessage.PESTILENCE_HAS_EMERGED)
						{
							SkyInfo.Instance.Pest = true;
							return;
						}
					}
					else if (messageId != GameFeedbackMessage.DEATH_HAS_EMERGED)
					{
						if (messageId == GameFeedbackMessage.WAR_HAS_EMERGED)
						{
							SkyInfo.Instance.War = true;
							return;
						}
					}
					else
					{
						SkyInfo.Instance.Death = true;
					}
				}
			}
		}
	}
}
