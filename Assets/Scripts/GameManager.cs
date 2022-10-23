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

    public int ResourceTree;
    public int ResourceStone;

    public void AddTree(int amount)
    {
        ResourceTree += amount;
        UpdateView();
        var controller = PlayerCastle.GetComponent<CastleController>();
        controller.UpdateUpgradeView();
    }
    public void RemoveTree(int amount)
    {
        ResourceTree -= amount;
        UpdateView();
        var controller = PlayerCastle.GetComponent<CastleController>();
        controller.UpdateUpgradeView();
    }
    public void AddStone(int amount)
    {
        ResourceStone += amount;
        UpdateView();
        var controller = PlayerCastle.GetComponent<CastleController>();
        controller.UpdateUpgradeView();
    }
    public void RemoveStone(int amount)
    {
        ResourceStone -= amount;
        UpdateView();
        var controller = PlayerCastle.GetComponent<CastleController>();
        controller.UpdateUpgradeView();
    }

    private void Awake()
    {
        _timer = 0;
        Instance = this;
        UpdateView();
    }

    private void UpdateView()
    {
        ResourceTreeText.text = $"x{ResourceTree}";
        ResourceStoneText.text = $"x{ResourceStone}";
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
