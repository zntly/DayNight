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
		// Token: 0x06000003 RID: 3 RVA: 0x0000206C File Offset: 0x0000026C
		[HarmonyPostfix]
		public static void Postfix(ChatLogMessage chatLogMessage)
		{
			bool flag = !(SkyInfo.Instance == null);
			if (flag)
			{
				ChatLogGameMessageEntry chatLogGameMessageEntry = (ChatLogGameMessageEntry)chatLogMessage.chatLogEntry;
				bool flag2 = chatLogGameMessageEntry != null;
				if (flag2)
				{
					GameFeedbackMessage messageId = chatLogGameMessageEntry.messageId;
					bool flag3 = messageId <= GameFeedbackMessage.PESTILENCE_HAS_EMERGED;
					if (flag3)
					{
						bool flag4 = messageId == GameFeedbackMessage.FAMINE_HAS_EMERGED;
						if (flag4)
						{
							SkyInfo.Instance.Famine = true;
						}
						else
						{
							bool flag5 = messageId == GameFeedbackMessage.PESTILENCE_HAS_EMERGED;
							if (flag5)
							{
								SkyInfo.Instance.Pest = true;
							}
						}
					}
					else
					{
						bool flag6 = messageId != GameFeedbackMessage.DEATH_HAS_EMERGED;
						if (flag6)
						{
							bool flag7 = messageId == GameFeedbackMessage.WAR_HAS_EMERGED;
							if (flag7)
							{
								SkyInfo.Instance.War = true;
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
}
