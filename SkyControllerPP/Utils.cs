using System;
using BetterTOS2;
using BetterTOS2.Observations;
using SML;

namespace SkyControllerPP
{
	// Token: 0x0200001B RID: 27
	public static class Utils
	{
		// Token: 0x060000A8 RID: 168 RVA: 0x00006258 File Offset: 0x00004458
		public static bool BTOS2Exists()
		{
			return ModStates.IsEnabled("curtis.tuba.better.tos2");
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00006274 File Offset: 0x00004474
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

		// Token: 0x060000AA RID: 170 RVA: 0x000062A8 File Offset: 0x000044A8
		private static bool IsBTOS2Bypass()
		{
			return Utils.BTOS2Exists() && BTOSInfo.IS_MODDED;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x000062CC File Offset: 0x000044CC
		public static bool CourtCheck()
		{
			return GameObservationsPatch.musicOverrideObservation.Data.court;
		}
	}
}
