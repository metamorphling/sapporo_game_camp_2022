using System;
using UnityEngine;

public class CharacterParameters : MonoBehaviour
{
    public Data Parameters;
    public CharacterType Type;

    [Serializable]
    public struct Data
    {
        public float Health;
        public float Damage;
        public float MoveSpeed;
        public float AttackSpeed;

        public ResourceType DropResource;
        public float DropRate;
    }

    public void Init(bool isPlayer, int level)
    {
        if (isPlayer)
        {
            switch (Type)
            {
                case CharacterType.Host:
                    Parameters = MasterData.Instance.Player_Host;
                    break;
                case CharacterType.Woman:
                    Parameters = MasterData.Instance.Player_Woman;
                    break;
                case CharacterType.Sheep:
                    Parameters = MasterData.Instance.Player_Sheep;
                    break;
                case CharacterType.Boss:
                    Parameters = MasterData.Instance.Player_Boss;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(Type), Type, null);
            }
        }
        else
        {
            if (level == 1)
            {
                switch (Type)
                {
                    case CharacterType.Host:
                        Parameters = MasterData.Instance.Enemy_Host_Lvl1;
                        break;
                    case CharacterType.Woman:
                        Parameters = MasterData.Instance.Enemy_Woman_Lvl1;
                        break;
                    case CharacterType.Sheep:
                        Parameters = MasterData.Instance.Enemy_Sheep_Lvl1;
                        break;
                    case CharacterType.Boss:
                        Parameters = MasterData.Instance.Enemy_Boss_Lvl1;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(Type), Type, null);
                }
            }
            else if (level == 2)
            {
                switch (Type)
                {
                    case CharacterType.Host:
                        Parameters = MasterData.Instance.Enemy_Host_Lvl2;
                        break;
                    case CharacterType.Woman:
                        Parameters = MasterData.Instance.Enemy_Woman_Lvl2;
                        break;
                    case CharacterType.Sheep:
                        Parameters = MasterData.Instance.Enemy_Sheep_Lvl2;
                        break;
                    case CharacterType.Boss:
                        Parameters = MasterData.Instance.Enemy_Boss_Lvl2;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(Type), Type, null);
                }
            }
            else if (level == 3)
            {
                switch (Type)
                {
                    case CharacterType.Host:
                        Parameters = MasterData.Instance.Enemy_Host_Lvl3;
                        break;
                    case CharacterType.Woman:
                        Parameters = MasterData.Instance.Enemy_Woman_Lvl3;
                        break;
                    case CharacterType.Sheep:
                        Parameters = MasterData.Instance.Enemy_Sheep_Lvl3;
                        break;
                    case CharacterType.Boss:
                        Parameters = MasterData.Instance.Enemy_Boss_Lvl3;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(Type), Type, null);
                }
            }
        }
    }
}
