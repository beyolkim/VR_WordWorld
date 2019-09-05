using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IBM.Cloud.SDK.Utilities;

public class InputController : MonoBehaviour
{
    //애니 락

    private int hashIsLook;
    private Animator anim;
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
    private GameObject Text_3d_child;
    public Text test_Record_Image_child;
    private Color colortext;
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
        Birth_Text = Resources.Load<GameObject>("3D_TEXT");
        
        break_laser = GameObject.FindGameObjectWithTag("RController").GetComponent<LaserCaster>();


    }

    void Update()
    {

        //녹화버튼 On/Off
        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad) /*|| Input.GetMouseButtonDown(0)*/)
        {
            Debug.Log("Button Cliked !!!");
            if (isWastssonEnable == false)
            {
                Debug.Log("OnOnOn!!!");
                breaking = false;
                Vector3 _dir = new Vector3(0, 2.8f, 20); // vec를 vec3값으로 변환(_dir은 로컬 좌표) 
                Vector3 voice_dir = new Vector3(0, 0, 19);
                particle_01.SetActive(false);

                if (check_text == false)
                {
                    check_text = !check_text;
                    Debug.Log("3dtext가 만들어지고 있니?");
                    voice_text = Instantiate(Birth_Text);

                    voice_text.transform.SetParent(cam);
                    voice_text.transform.localPosition = voice_dir;
                    voice_text.transform.localRotation = Quaternion.identity;
               
                    voice_text.GetComponent<TextMesh>().text = voice.ResultsField.text;
                    colortext = voice_text.GetComponent<TextMesh>().color;
                    colortext = Color.white;

                }
                test_Record_Image_child.text = "Recording";

                test_Record_Image.SetActive(true);    // test_Record_Image 활성화

                test_Record_Image.transform.SetParent(cam);  //test_Record_Image 위치 카메라 위치로 수정
                test_Record_Image.transform.localPosition = _dir;
                test_Record_Image.transform.localRotation = Quaternion.identity;
                
                isWastssonEnable = !isWastssonEnable;
                voice.Active = true;


            }
            else if (isWastssonEnable == true)
            {
                Debug.Log("OffOffOff!!!");
                isWastssonEnable = !isWastssonEnable;
                breaking = true;
                voice.Active = false;
                //test_Record_Image.SetActive(false);
                test_Record_Image_child.text = "Break!!";
                colortext = Color.red;
            }

        }

        //트랙패드 터치 좌표값

        if (OVRInput.Get(OVRInput.Touch.PrimaryTouchpad))
        {
            Vector2 pos = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
            // Debug.LogFormat("Touch Postion x={0}, y={1}", pos.x, pos.y);

        }

        //보이스 레코드 갱신화
        if (check_text == true)

        {
            voice_text.GetComponent<TextMesh>().text = voice.ResultsField.text;

        }




        //if (Input.GetMouseButtonDown(1))
        //{
        //    Break_Word();
        //}






        // 트리거 버튼을 이용하 글자 블록 부시기
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && breaking == true )
        { 

            Debug.Log("1st_breakbreakbreak");
            Debug.Log(tr.position);
            break_laser.P_ray = new Ray(break_laser.tr.position, break_laser.tr.forward);
            Debug.Log("2st_breakbreakbreak");
            if (Physics.Raycast(break_laser.P_ray, out break_laser.hit, break_laser.range))
            {
                anim = voice_text.GetComponent<Animator>();
                hashIsLook = Animator.StringToHash("IsLook");
                anim.SetBool(hashIsLook, true);
                if (break_laser.hit.collider.CompareTag("RecordingText"))
                {
                    Debug.Log("breakbreakbreak");
                    Break_Word();
                }

            }
        }

        MovePlayer();
    }

    void Break_Word()
    {
        break_word = voice_text.gameObject.AddComponent<Hangle>();
        Vector3 particle_dir = new Vector3(0, 0, 19);
        voice.ResultsField.text = "말을해주세요";
        particle_01.SetActive(true);
        particle_01.transform.SetParent(cam);
        particle_01.transform.localPosition = particle_dir;
        test_Record_Image.SetActive(false);

        break_word.check_break = false;
        check_text = !check_text;

        Destroy(voice_text, 0.15f);
        



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