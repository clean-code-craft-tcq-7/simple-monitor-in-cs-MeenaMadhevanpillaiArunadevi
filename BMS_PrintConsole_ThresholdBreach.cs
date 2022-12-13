using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

partial class BMS
{
    //Segregate IO if Threshold breached
    static void printBMS_ThresholdBreach(string bmsCriteria)
    {
        Console.WriteLine(string.Concat(bmsCriteria, " is out of range"));
    }

}