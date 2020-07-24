using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // Start is called before the first frame update
    public delegate void BorderCrossed();
    public static event BorderCrossed borderCrossed;

    public delegate void BatteryYellow();
    public static event BatteryYellow batteryYellow;

    public delegate void BatteryRed();
    public static event BatteryRed batteryRed;

    public delegate void BatteryFlashing();
    public static event BatteryFlashing batteryFlashing;

    public delegate void EnableGPS();
    public static event EnableGPS enableGPS;

    public delegate void GainPower();
    public static event GainPower gainPower;

    public static void CallCrossing()
    {
        borderCrossed?.Invoke();
    }

    public static void CallYellow()
    {
        batteryYellow?.Invoke();
    }

    public static void CallRed()
    {
        batteryRed?.Invoke();
    }

    public static void CallFlashing()
    {
        batteryFlashing?.Invoke();
    }

    public static void CallEnableGPS()
    {
        enableGPS?.Invoke();
    }

    public static void CallGainPower()
    {
        gainPower?.Invoke();
    }
}
