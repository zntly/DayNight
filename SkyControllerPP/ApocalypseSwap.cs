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
		// Token: 0x06000003 RID: 3 RVA: 0x000022E8 File Offset: 0x000004E8
		[HarmonyPostfix]
		public static void Postfix(ChatLogMessage chatLogMessage)
		{
			bool flag = !(SkyInfo.Instance == null);
			bool flag2 = flag;
			if (flag2)
			{
				ChatLogGameMessageEntry chatLogGameMessageEntry = (ChatLogGameMessageEntry)chatLogMessage.chatLogEntry;
				bool flag3 = chatLogGameMessageEntry != null;
				bool flag4 = flag3;
				if (flag4)
				{
					GameFeedbackMessage messageId = chatLogGameMessageEntry.messageId;
					bool flag5 = messageId <= GameFeedbackMessage.PESTILENCE_HAS_EMERGED;
					bool flag6 = flag5;
					if (flag6)
					{
						bool flag7 = messageId == GameFeedbackMessage.FAMINE_HAS_EMERGED;
						bool flag8 = flag7;
						if (flag8)
						{
							SkyInfo.Instance.Famine = true;
						}
						else
						{
							bool flag9 = messageId == GameFeedbackMessage.PESTILENCE_HAS_EMERGED;
							bool flag10 = flag9;
							if (flag10)
							{
								SkyInfo.Instance.Pest = true;
							}
						}
					}
					else
					{
						bool flag11 = messageId != GameFeedbackMessage.DEATH_HAS_EMERGED;
						bool flag12 = flag11;
						if (flag12)
						{
							bool flag13 = messageId == GameFeedbackMessage.WAR_HAS_EMERGED;
							bool flag14 = flag13;
							if (flag14)
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
