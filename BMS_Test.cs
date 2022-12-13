using System.Diagnostics;

partial class BMS
{
    public static void BMS_Test()
    {
        //Fail when Temp <0 >45 ; SOC <20 >80 ; CR > 0.8
        //Battery condition test
        Debug.Assert(batteryIsOk(25, 70, 0.7f) == true); //Battery okay
        Debug.Assert(batteryIsOk(100, 60, 0.5f) == false);//Battery not okay - MaxTemp breached
        Debug.Assert(batteryIsOk(-1, 60, 0.5f) == false);//Battery not okay - MinTemp breached
        Debug.Assert(batteryIsOk(45, 85, 0.1f) == false);//Battery not okay - MaxSOC breached
        Debug.Assert(batteryIsOk(30, 5, 0.1f) == false);//Battery not okay - MinSOC breached
        Debug.Assert(batteryIsOk(0, 60, 0.9f) == false);//Battery not okay - MaxCharge rate breached
        Debug.Assert(batteryIsOk(90, 90, 0.9f) == false);//Battery not okay - Temp, SOC, Charge rate breached

        //Temperature test
        Debug.Assert(TempCheck(BMS_Threshold.TemperatureMin) == true);//Temp = minthreshold
        Debug.Assert(TempCheck(BMS_Threshold.TemperatureMax) == true);//Temp = maxthreshold
        Debug.Assert(TempCheck(BMS_Threshold.TemperatureMin - 0.1f) == false);//Temp < minthreshold
        Debug.Assert(TempCheck(BMS_Threshold.TemperatureMax + 5f) == false);//Temp > maxthreshold

        //SOC test
        Debug.Assert(SOCCheck(BMS_Threshold.SocMin) == true);     //SOC = minthreshold
        Debug.Assert(SOCCheck(BMS_Threshold.SocMax) == true);    //SOC = maxthreshold
        Debug.Assert(SOCCheck(BMS_Threshold.SocMin - 5f) == false); //SOC < minthreshold
        Debug.Assert(SOCCheck(BMS_Threshold.SocMax + 5f) == false);//SOC > maxthreshold

        //Charge Rate test
        Debug.Assert(ChargeRateCheck(BMS_Threshold.ChargeRateMax) == true);     //ChargeRate = minthreshold
        Debug.Assert(ChargeRateCheck(BMS_Threshold.ChargeRateMax - 5f) == true); //ChargeRate < minthreshold
        Debug.Assert(ChargeRateCheck(BMS_Threshold.ChargeRateMax + 5f) == false);//ChargeRate > maxthreshold

    }
}
