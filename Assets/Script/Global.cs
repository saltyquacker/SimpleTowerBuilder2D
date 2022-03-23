using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVar
{
    public static bool move = true;
    public static float ypos = -3.5f;

    public static float squareCount = 0.0f;

    public static float targetMin;
    public static float targetMax;

    public static int score;

    public static bool gameOver = false;

    public static string currentUser;

    public static string currentHighscore;

    public static string previousEntry;

    public static float squareSpeed = 0.0f;
    public static int modulo = 0;
}