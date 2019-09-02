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
    private GameObject Birth_Text;
    bool check_text=false;
    //녹화 버튼 활성화 변수들
    public IBM.Watsson.Examples.ExampleStreaming voice;
    bool isWastssonEnable = false;
    //임시 녹음버튼
    public GameObject test_Record_Image;

    void Start()
    {
        tr = GetComponent<Transform>();
        cam = tr.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor").GetComponent<Transform>();
        Birth_Text = Resources.Load<GameObject>("3D_TEXT");

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
                
                Vector3 _dir = new Vector3(0, 0, 15); // vec를 vec3값으로 변환(_dir은 로컬 좌표) 
                Vector3 voice_dir = new Vector3(0, 0, 14); 

                if (check_text == false)
                {
                    check_text = !check_text;
                    Debug.Log("3dtext가 만들어지고 있니?");
        
                    GameObject voice_text = Instantiate(Birth_Text);
                    voice_text.transform.SetParent(cam);
                    voice_text.transform.localPosition = voice_dir;
                    // voice_text.transform.LookAt(cam);
                    voice_text.transform.localRotation = Quaternion.identity;

                    //voice.text_3D.text = voice_text.GetComponent<TextMesh>().text;
                }

                test_Record_Image.SetActive(true);    // test_Record_Image 활성화
                
                test_Record_Image.transform.SetParent(cam);  //test_Record_Image 위치 카메라 위치로 수정
                test_Record_Image.transform.localPosition = _dir;
                test_Record_Image.transform.localRotation = Quaternion.identity;

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

            if (dir.y < 0 && transform.position.y < 0)
            {

                dir.y = 0f;
            }

            transform.Translate(dir * Speed * Time.deltaTime); // player 이동
        }
    }

}