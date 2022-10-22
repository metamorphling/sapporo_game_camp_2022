using System;
using UnityEngine;

public class CastleParameters : MonoBehaviour
{
    public Data Parameters;
    public bool IsPlayer;
    public bool IsInitialized { get; set; }

    [Serializable]
    public class Data
    {
        public float Health;
        public float CostWood;
        public float CostStone;
    }

    public void Init(int level)
    {
        if (IsPlayer)
        {
            if (level == 1)
            {
                Parameters = MasterData.Instance.Player_Castle_Lvl1;
            }
            else if (level == 2)
            {
                Parameters = MasterData.Instance.Player_Castle_Lvl2;
            }
            else if (level == 3)
            {
                Parameters = MasterData.Instance.Player_Castle_Lvl3;
            }
            else if (level == 4)
            {
                Parameters = MasterData.Instance.Player_Castle_Lvl4;
            }
        }
        else
        {
            if (level == 1)
            {
                Parameters = MasterData.Instance.Enemy_Castle_Lvl1;
            }
            else if (level == 2)
            {
                Parameters = MasterData.Instance.Enemy_Castle_Lvl2;
            }
            else if (level == 3)
            {
                Parameters = MasterData.Instance.Enemy_Castle_Lvl3;
            }
            else if (level == 4)
            {
                Parameters = MasterData.Instance.Enemy_Castle_Lvl4;
            }
        }
        IsInitialized = true;
    }
}
