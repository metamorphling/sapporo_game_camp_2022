using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string SceneName;

    public void OnClickLoadScene()
    {
        SceneManager.LoadScene("Level1");
        Game.StartGame();
    }
}
