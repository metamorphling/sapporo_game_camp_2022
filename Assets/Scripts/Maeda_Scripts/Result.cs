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

    private void retryScene()
    {
        SceneManager.LoadScene("Level1");
    }
    private void TitleScene()
    {
        SceneManager.LoadScene("TitleMenu");
    }
}
