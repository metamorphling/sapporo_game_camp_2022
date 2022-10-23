using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float _timer;

    [SerializeField] GameObject PlayerCastle;
    [SerializeField] GameObject EnemyCastle;

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

        if (PlayerCastle == null)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (EnemyCastle == null)
        {
            SceneManager.LoadScene("GameClear");
        }
    }
}
