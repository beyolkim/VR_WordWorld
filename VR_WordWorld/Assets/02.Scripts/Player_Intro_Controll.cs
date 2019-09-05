using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using IBM.Cloud.SDK.Utilities;

public class Player_Intro_Controll : MonoBehaviour
{

    //Move 변수들
    public float Speed = 6;
    Transform tr;
    private Transform cam;

    private Rigidbody rb;
    private CharacterController cc;
    private GameObject Birth_Text;
    private GameObject voice_text;
    bool check_text = false;

    //녹화 버튼 활성화 변수들
    public IBM.Watsson.Examples.ExampleStreaming voice;
    bool isWastssonEnable = false;

    //임시 녹음버튼
    public GameObject test_Record_Image;
    public GameObject introUI;


    private Hangle break_word;

    //LaserCaster 사용 스크립트 및 변수

    private bool breaking = false;
    private LaserCaster break_laser;
    public GameObject Laser_Script;

    public GameObject particle_01;
    //public static GameObject voice_text;
    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        cam = tr.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor").GetComponent<Transform>();


        break_laser = GameObject.FindGameObjectWithTag("RController").GetComponent<LaserCaster>();


    }

    void Update()
    {

        //녹화버튼 On/Off
        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))
        {
     

        }

        //트랙패드 터치 좌표값

        if (OVRInput.Get(OVRInput.Touch.PrimaryTouchpad))
        {
            Vector2 pos = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
            // Debug.LogFormat("Touch Postion x={0}, y={1}", pos.x, pos.y);
        }

           //MovePlayer();
    }


    void MovePlayer()
    {
        Vector2 vec = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
        Vector3 _dir = new Vector3(vec.x, 0, vec.y); // vec를 vec3값으로 변환(_dir은 로컬 좌표) 
        Vector3 dir = cam.transform.TransformDirection(_dir); // 카메라의 vector, _dir을 월드좌표로

        if (OVRInput.Get(OVRInput.Touch.PrimaryTouchpad))
        {
            if (dir.y < 0 && transform.position.y < 0f)
            {
                dir.y = 0f;
            }

            cc.Move(dir * Speed * Time.deltaTime);

            // transform.Translate(dir * Speed * Time.deltaTime); // player 이동
        }
    }

}