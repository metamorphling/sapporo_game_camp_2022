using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    private void Update()
    {
       
    }

    public void retryScene()
    {
        SceneManager.LoadScene("Level1");
    }
    public void TitleScene()
    {
        SceneManager.LoadScene("TitleMenu");
    }
}
