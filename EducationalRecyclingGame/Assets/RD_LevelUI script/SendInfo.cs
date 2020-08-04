using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class SendInfo {
    public static int levelNumber = 1;
    public static bool audioToggleState { get; set; }
    public static bool seeAllLevels = false;
    public static Font myFont { get; set; }
    public static int points { get; set; }
    public static int[] pointArray = new int[9];
    public const int NUMSECONDS =60;
    public static ArrayList binArray = new ArrayList();
}
