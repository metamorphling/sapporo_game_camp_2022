using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float _timer;

    private void Awake()
    {
        _timer = 0;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 1)
        {
            _timer = 0;
            Game.Players = (GameObject.FindGameObjectsWithTag("Player"));
            Game.Enemies = (GameObject.FindGameObjectsWithTag("Enemy"));
        }
    }
}
