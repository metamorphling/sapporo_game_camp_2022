using UnityEngine;

public static class FightManager
{
    public static void Fight(CharacterParameters.Data source, CharacterParameters.Data target)
    {
        target.Health = target.Health - source.Damage;
    }
    public static void Fight(CharacterParameters.Data source, CastleParameters.Data target)
    {
        target.Health = target.Health - source.Damage;
    }
}
