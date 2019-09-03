using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public void ChangingGameScene()
    {
        SceneManager.LoadScene("WordWorld_Star");
    }
}