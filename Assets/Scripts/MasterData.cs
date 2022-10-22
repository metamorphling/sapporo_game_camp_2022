using UnityEngine;

public class MasterData : MonoBehaviour
{
    public static MasterData Instance;

    public void Awake()
    {
        Instance = this;
    }

    public CharacterParameters.Data Player_Host;
    public CharacterParameters.Data Player_Woman;
    public CharacterParameters.Data Player_Sheep;
    public CharacterParameters.Data Player_Boss;

    public CharacterParameters.Data Enemy_Host_Lvl1;
    public CharacterParameters.Data Enemy_Woman_Lvl1;
    public CharacterParameters.Data Enemy_Sheep_Lvl1;
    public CharacterParameters.Data Enemy_Boss_Lvl1;

    public CharacterParameters.Data Enemy_Host_Lvl2;
    public CharacterParameters.Data Enemy_Woman_Lvl2;
    public CharacterParameters.Data Enemy_Sheep_Lvl2;
    public CharacterParameters.Data Enemy_Boss_Lvl2;

    public CharacterParameters.Data Enemy_Host_Lvl3;
    public CharacterParameters.Data Enemy_Woman_Lvl3;
    public CharacterParameters.Data Enemy_Sheep_Lvl3;
    public CharacterParameters.Data Enemy_Boss_Lvl3;

    public CastleParameters.Data Player_Castle_Lvl1;
    public CastleParameters.Data Player_Castle_Lvl2;
    public CastleParameters.Data Player_Castle_Lvl3;
    public CastleParameters.Data Player_Castle_Lvl4;
    public CastleParameters.Data Enemy_Castle_Lvl1;
    public CastleParameters.Data Enemy_Castle_Lvl2;
    public CastleParameters.Data Enemy_Castle_Lvl3;
    public CastleParameters.Data Enemy_Castle_Lvl4;
}