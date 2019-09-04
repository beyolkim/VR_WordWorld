using UnityEngine;
using System.Collections;
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public Canvas Canvas_Intro;
    public Canvas Canvas_Setting;
    public CanvasGroup screen1;
    public CanvasGroup screen2;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        screen1.alpha = 1;
        Canvas_Intro.enabled = true;
        screen2.alpha = 0;
        Canvas_Setting.enabled = false;
    }
    public void Screen1_Active()
    {
        screen1.alpha = 1;
        screen1.interactable = true;
        Canvas_Intro.enabled = true;
        Canvas_Setting.enabled = false;
    }
    public void Screen2_Active()
    {
        screen2.alpha = 1;
        screen2.interactable = true;
        Canvas_Intro.enabled = false;
        Canvas_Setting.enabled = true;
    }
}
