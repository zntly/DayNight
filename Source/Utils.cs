using System;
using BetterTOS2;
using BetterTOS2.Observations;
using SML;

namespace SkyControllerPP
{
	// Token: 0x0200001B RID: 27
	public static class Utils
	{
		// Token: 0x0600009D RID: 157 RVA: 0x0000208A File Offset: 0x0000028A
		public static bool BTOS2Exists()
		{
			return ModStates.IsEnabled("curtis.tuba.better.tos2");
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00005B58 File Offset: 0x00003D58
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

		// Token: 0x0600009F RID: 159 RVA: 0x000023C9 File Offset: 0x000005C9
		private static bool IsBTOS2Bypass()
		{
			return Utils.BTOS2Exists() && BTOSInfo.IS_MODDED;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x000023D9 File Offset: 0x000005D9
		public static bool CourtCheck()
		{
			return GameObservationsPatch.musicOverrideObservation.Data.court;
		}
	}
}
