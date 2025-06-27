using System;
using BetterTOS2;
using BetterTOS2.Observations;
using SML;

namespace DayNight
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
            if (!Utils.IsBTOS2())
            {
                return false;
            }
            return Utils.InternalCourtCheck();
        }

        public static bool ApocCheck()
        {
            if (!Utils.IsBTOS2())
            {
                if (SkyInfo.Instance)
                {
                    return SkyInfo.Instance.Pest + SkyInfo.Instance.Famine + SkyInfo.Instance.War + SkyInfo.Instance.Death > 0;
                }
                return false;
            }
            return Utils.InternalApocCheck();
        }

        private static bool InternalCourtCheck()
        {
            return GameObservationsPatch.musicOverrideObservation.Data.court;
        }

        private static bool InternalApocCheck()
        {
            return GameObservationsPatch.musicOverrideObservation.Data.apoc;

        }
    }
}
