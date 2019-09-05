using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    private LaserCaster break_laser;    
    public Canvas_IntroFade Intro_Button;
    public Canvas_SettingFade Set_Button;

    public AudioClip Backgroundsfx;
    public AudioClip Entersfx;
    public AudioClip Clicksfx;
    private AudioSource audioSource;

    void Start()
    {
        break_laser = GameObject.FindGameObjectWithTag("RController").GetComponent<LaserCaster>();
        
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Backgroundsfx;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // void Click()
    // {

    //     break_laser.P_ray = new Ray(break_laser.tr.position, break_laser.tr.forward);

    //     if (Physics.Raycast(break_laser.P_ray, out break_laser.hit, break_laser.range))
    //     {
    //         if (break_laser.hit.collider.CompareTag("Button_Start"))
    //         {
    //             Debug.Log("스타트버튼");
    //             SceneManager.LoadScene("WordWorld_Yun");
    //             //Debug.Log("스타트버튼");
    //         }
    //         if (break_laser.hit.collider.CompareTag("Button_Settings"))
    //         {
    //             Debug.Log("세팅버튼");
    //             Set_Button.Fade();
    //         }
    //         if (break_laser.hit.collider.CompareTag("Button_Quit"))
    //         {
    //             Debug.Log("종료버튼");
    //             Application.Quit();

    //         }
    //         if (break_laser.hit.collider.CompareTag("Button_Back"))
    //         {
    //             Debug.Log("백버튼");
    //             Intro_Button.Fade();
    //         }

    //     }

    // }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (break_laser.hit.collider)
        {
            audioSource.PlayOneShot(Entersfx);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //if (break_laser.hit.collider.gameObject.layer == 9)
        //{
        //    Debug.Log("스타트버튼");
        //    SceneManager.LoadScene("WordWorld_Yun");
        //    audioSource.PlayOneShot(Clicksfx);
        //}
        //if (break_laser.hit.collider.gameObject.layer == 9)
        //{
        //    Debug.Log("세팅버튼");
        //    Set_Button.Fade();
        //    audioSource.PlayOneShot(Clicksfx);
        //}
        //if (break_laser.hit.collider.gameObject.layer == 9)
        //{
        //    Debug.Log("종료버튼");
        //    Application.Quit();
        //    audioSource.PlayOneShot(Clicksfx);

        //}
        //if (break_laser.hit.collider.gameObject.layer == 9)
        //{
        //    Debug.Log("백버튼");
        //    Intro_Button.Fade();
        //    audioSource.PlayOneShot(Clicksfx);
        //}
    }
}