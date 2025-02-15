using System;
using BetterTOS2;
using BetterTOS2.Observations;
using SML;

namespace SkyControllerPP
{
	// Token: 0x02000014 RID: 20
	public static class Utils
	{
		// Token: 0x0600005F RID: 95 RVA: 0x0000680C File Offset: 0x00004A0C
		public static bool BTOS2Exists()
		{
			return ModStates.IsEnabled("curtis.tuba.better.tos2");
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00006828 File Offset: 0x00004A28
		public static bool IsBTOS2()
		{
			bool result;
			try
			{
				result = Utils.IsBTOS2Bypass();
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x0000685C File Offset: 0x00004A5C
		private static bool IsBTOS2Bypass()
		{
			return Utils.BTOS2Exists() && BTOSInfo.IS_MODDED;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00006880 File Offset: 0x00004A80
		public static bool CourtCheck()
		{
			return GameObservationsPatch.musicOverrideObservation.Data.court;
		}
	}
}
