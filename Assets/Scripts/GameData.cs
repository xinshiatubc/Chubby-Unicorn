using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int bestScore;
    public GameData(GameController gc)
    {
        bestScore = gc.bestScore;
    }
}
