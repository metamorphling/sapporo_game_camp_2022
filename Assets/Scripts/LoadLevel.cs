using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string SceneName;
    public AudioClip start;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnClickLoadScene()
    {
        audioSource.PlayOneShot(start);
        SceneManager.LoadScene("Tutorial");
        Game.StartGame();
    }
}
