using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public List<CharacterInfo> Characters = new List<CharacterInfo>();
    public GameObject IconContainer;
    public GameObject CharacterIconBox;

    public static CharacterManager Instance => _instance;

    private static CharacterManager _instance;

    private void Awake()
    {
#if DEBUG
        Init();
#endif
    }

    private void Start()
    {
        _instance = this;
    }

    public void Init()
    {
        foreach (var item in Characters)
        {
            if (item.IsUnlocked)
            {
                GameObject.Instantiate(CharacterIconBox, IconContainer.transform);
            }
        }
    }
}
