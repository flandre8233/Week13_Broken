using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : SingletonMonoBehavior<GameModel>
{
    public Player player;
    [SerializeField]
    Boss boss;

    public Player GetPlayer()
    {
        return player;
    }
    public Boss GetBoss()
    {
        return boss;
    }
}
