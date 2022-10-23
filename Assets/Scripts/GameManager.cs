using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI ResourceTreeText;
    public TextMeshProUGUI ResourceStoneText;
    [SerializeField] GameObject PlayerCastle;
    [SerializeField] GameObject EnemyCastle;

    public static GameManager Instance;
    private float _timer;

    private int ResourceTree;
    private int ResourceStone;

    public void AddTree(int amount)
    {
        ResourceTree += amount;
        UpdateView();
    }
    public void RemoveTree(int amount)
    {
        ResourceTree -= amount;
        UpdateView();
    }
    public void AddStone(int amount)
    {
        ResourceStone += amount;
        UpdateView();
    }
    public void RemoveStone(int amount)
    {
        ResourceStone -= amount;
        UpdateView();
    }

    private void Awake()
    {
        _timer = 0;
        Instance = this;
        UpdateView();
    }

    private void UpdateView()
    {
        ResourceTreeText.text = $"木：{ResourceTree}";
        ResourceStoneText.text = $"石：{ResourceStone}";
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
