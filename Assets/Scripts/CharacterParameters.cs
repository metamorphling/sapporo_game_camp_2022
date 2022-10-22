using System;
using UnityEngine;

public class CharacterParameters : MonoBehaviour
{
    public Data Parameters;

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
}
