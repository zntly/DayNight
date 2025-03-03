using System;
using BetterTOS2;
using BetterTOS2.Observations;
using SML;

namespace SkyControllerPP
{
	// Token: 0x0200001A RID: 26
	public static class Utils
	{
		// Token: 0x06000094 RID: 148 RVA: 0x00006CF0 File Offset: 0x00004EF0
		public static bool BTOS2Exists()
		{
			return ModStates.IsEnabled("curtis.tuba.better.tos2");
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00006D0C File Offset: 0x00004F0C
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

		// Token: 0x06000096 RID: 150 RVA: 0x00006D40 File Offset: 0x00004F40
		private static bool IsBTOS2Bypass()
		{
			return Utils.BTOS2Exists() && BTOSInfo.IS_MODDED;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00006D64 File Offset: 0x00004F64
		public static bool CourtCheck()
		{
			return GameObservationsPatch.musicOverrideObservation.Data.court;
		}
	}
}
