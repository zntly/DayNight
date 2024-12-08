using System;
using BetterTOS2;
using BetterTOS2.Observations;
using SML;

namespace SkyControllerPP
{
	// Token: 0x0200001A RID: 26
	public static class Utils
	{
		// Token: 0x06000098 RID: 152 RVA: 0x0000208A File Offset: 0x0000028A
		public static bool BTOS2Exists()
		{
			return ModStates.IsEnabled("curtis.tuba.better.tos2");
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0000633C File Offset: 0x0000453C
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

		// Token: 0x0600009A RID: 154 RVA: 0x00002395 File Offset: 0x00000595
		private static bool IsBTOS2Bypass()
		{
			return Utils.BTOS2Exists() && BTOSInfo.IS_MODDED;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000023A5 File Offset: 0x000005A5
		public static bool CourtCheck()
		{
			return GameObservationsPatch.musicOverrideObservation.Data.court;
		}
	}
}
