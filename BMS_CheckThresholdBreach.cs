using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

partial class BMS
{
    //Temp, SOC and Charge rate checks whether the value is under limit (same functionality for different criteria)
    //Avoid duplication - functions that do nearly the same thing by segregating the generic approach
    static bool isUnderLimit(string bmsCriteria, float value, float maxThreshold, float minThreshold = float.NegativeInfinity)
    {
        if (value < minThreshold || value > maxThreshold)
        {
            printBMS_ThresholdBreach(bmsCriteria);
            return false;
        }
        else
            return true;
    }
    //Check whether Temperature is under limit
    static bool TempCheck(float value)
    {
        return isUnderLimit("Temperature", value, BMS_Threshold.TemperatureMax, BMS_Threshold.TemperatureMin);
    }
    //Check whether SOC is under limit
    static bool SOCCheck(float value)
    {
        return isUnderLimit("State of Charge", value, BMS_Threshold.SocMax, BMS_Threshold.SocMin);
    }
    //Check whether Charge Rate is under limit
    static bool ChargeRateCheck(float value)
    {
        return isUnderLimit("Charge Rate", value, BMS_Threshold.ChargeRateMax);
    }
    //Check whether Battery condition is safe
    static bool batteryIsOk(float tempValue, float socValue, float chargerateValue)
    {
        return TempCheck(tempValue) && SOCCheck(socValue) && ChargeRateCheck(chargerateValue);
    }

}