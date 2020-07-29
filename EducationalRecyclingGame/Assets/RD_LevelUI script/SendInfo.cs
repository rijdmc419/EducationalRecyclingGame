using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class SendInfo {
    public static int levelNumber { get; set; }
    public static bool audioToggleState { get; set; }
    public static Font myFont { get; set; }
    public static int[] points = new int[9];
    public const int NUMSECONDS = 10;
}
