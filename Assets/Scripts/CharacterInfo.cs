using System;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

[Serializable]
public class CharacterInfo
{
    public Image Icon;
    public GameObject Mesh;
    public bool IsUnlocked;
    public CharacterType Type;
}