using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    private static string player_name;

    public static string GET_PLAYER_NAME()
    {
        return player_name;
    }

    public static void SET_PLAYER_NAME(string name)
    {
        Debug.Log("SET PLAYER NAME TO: " + name);
        player_name = name;
    }
}
