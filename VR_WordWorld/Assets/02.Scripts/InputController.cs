using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using IBM.Cloud.SDK.Utilities;

public class InputController : MonoBehaviour
{

    //Move 변수들
    public float Speed = 12;
    Transform tr;
    private Transform cam;


    //녹화 버튼 활성화 변수들
    public IBM.Watsson.Examples.ExampleStreaming voice;
    bool isWastssonEnable = false;
    //임시 녹음버튼
    public GameObject test_Record_Image;
   
    void Start()
    {
        tr = GetComponent<Transform>();
        cam = tr.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor").GetComponent<Transform>();

    }

    void Update()
    {
  
        //녹화버튼 On/Off
        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))
        {
            Debug.Log("Button Cliked !!!");
            if (isWastssonEnable == false)
            {
                Debug.Log("OnOnOn!!!");
                isWastssonEnable = !isWastssonEnable;
                voice.Active = true;
                test_Record_Image.SetActive(true);
            }
            else if (isWastssonEnable == true)
            {
                Debug.Log("OffOffOff!!!");
                isWastssonEnable = !isWastssonEnable;
                voice.Active = false;
                test_Record_Image.SetActive(false);
            }

        }
        if (OVRInput.Get(OVRInput.Touch.PrimaryTouchpad))
        {
            //트랙패드 터치 좌표값
            Vector2 pos = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
            Debug.LogFormat("Touch Postion x={0}, y={1}", pos.x, pos.y);

        }

        MovePlayer();
    }
    void MovePlayer()
    {

        if (OVRInput.Get(OVRInput.Touch.PrimaryTouchpad))
        {
            Vector2 vec = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
            Vector3 _dir = new Vector3(vec.x, 0, vec.y); // vec를 vec3값으로 변환(_dir은 로컬 좌표) 
            Vector3 dir = cam.transform.TransformDirection(_dir); // 카메라의 vector, _dir을 월드좌표로

            if (dir.y < 0)
            {
                if (transform.position.y < 0)
                {
                    dir.y = 0f;
                }
            }
            transform.Translate(dir * Speed * Time.deltaTime); // player 이동
        }
    }

}