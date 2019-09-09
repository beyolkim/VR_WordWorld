using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IBM.Cloud.SDK.Utilities;

public class InputController : MonoBehaviour
{
    //애니 락 -> 애니메이션 효과를 위해 만들었는데 아직 작동하지 않는다.
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

    //녹음버튼
    public GameObject test_Record_Image;

    public Text test_Record_Image_child_Text;

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

        // InputController의 하위에 있는 CenterEyeAnchor(카메라의 중앙)의 위치값을 가져온다.
        cam = tr.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor").GetComponent<Transform>();

        //IBM 왓슨에 가져온 텍스트를 담은 3D_Text(Prefabs)를 넣어준다(특정 이벤트 발생시 인스턴스화하기 위해)
        Birth_Text = Resources.Load<GameObject>("3D_TEXT");

        // 도형을 깨기위해 레이저의 스크립트를 불러올 그릇 만들기
        break_laser = GameObject.FindGameObjectWithTag("RController").GetComponent<LaserCaster>();



    }

    void Update()
    {


        // 터치패드 부분을 클릭으로 한번 눌렀을 경우
        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad) || Input.GetMouseButtonDown(0)) // InputGetMouseButtonDown은 컴퓨터에서 테스트를 위한 임시입력값
        {
            Debug.Log("Button Cliked !!!");
            RecoringOnOff();
        }

        //트랙패드 터치 좌표값
        if (OVRInput.Get(OVRInput.Touch.PrimaryTouchpad))
        {
            Vector2 pos = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
        }

        //보이스 레코드 갱신화
        if (check_text == true)
        {
            voice_text.GetComponent<TextMesh>().text = voice.ResultsField.text;
        }

        //if (Input.GetMouseButtonDown(1))  // 컴퓨터 테스트용 브릭함수 빌드시 주석처리
        //{
        //    Break_Word();
        //}


        //트리거 버튼을 이용하 글자 블록 부시기
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && breaking == true)
        {

            break_laser.P_ray = new Ray(break_laser.tr.position, break_laser.tr.forward); // LaserCaster 스크립트에서 가져옴
            if (Physics.Raycast(break_laser.P_ray, out break_laser.hit, break_laser.range))
            {
                if (break_laser.hit.collider.CompareTag("RecordingText"))
                {
                    Debug.Log("breakbreakbreak");
                    Break_Word();
                }

            }
        }


        MovePlayer();
    }

    private void RecoringOnOff()
    {
        if (isWastssonEnable == false) // 버튼이 off일 경우
        {
            Debug.Log("OnOnOn!!!");
            breaking = false; // 녹화할 경우 글씨가 분리되지 않기 위한 bool 함수(Recording시 flase, Breaking시 True) 
            Vector3 _dir = new Vector3(0, 2.8f, 20); // Recording UI의 위치값(바라보는 카메라 기준)
            Vector3 voice_dir = new Vector3(0, 0, 19); // Recoridng 되는 3D_Text의 위치값(바라보는 카메라 기준)
            particle_01.SetActive(false); // 한글 자음모음 분리시 파티클 발생을 위해 우선적으로 파티클 오브젝트를 비활성화

            if (check_text == false)
            {
                check_text = !check_text; // 글씨가 분리되기전까지는 true로 활성화 해서 3D_Text가 계속 안생기게 해준다. 
                Debug.Log("3dtext가 만들어지고 있니?");
                voice_text = Instantiate(Birth_Text); // 3D_Text 인스턴스화

                voice_text.transform.SetParent(cam); // 3D_Text 위치를 중앙카메라의 밑에 자식화 한다
                voice_text.transform.localPosition = voice_dir; // 자식화 후, 3D_Text의 로컬위치를 Voice_dir(z축으로 19떨어진 위치)로 이동시킨다.
                voice_text.transform.localRotation = Quaternion.identity; // 3D_Text의 로컬각도는 기본 값을 가지게 한다.

                voice_text.GetComponent<TextMesh>().text = voice.ResultsField.text; // **왓슨에서 나오는 텍스트를 인스턴스한 3D_Text의 textmesh 텍스트에 넣어준다.**
            }

            test_Record_Image.SetActive(true);    // test_Record_Image 활성화
            test_Record_Image_child_Text.text = "Recording"; // UI 글씨를 Recording으로 활성화
            test_Record_Image.transform.SetParent(cam);  //test_Record_Image 위치 카메라 위치로 수정
            test_Record_Image.transform.localPosition = _dir;
            test_Record_Image.transform.localRotation = Quaternion.identity;

            voice_text.GetComponent<TextMesh>().color = Color.white; // 녹화할 경우 3D_Text 기본값은 흰색 

            isWastssonEnable = !isWastssonEnable; // 버튼의 On 기능 활성화
            voice.Active = true; // 왓슨 기능 활성화
        }

        else if (isWastssonEnable == true) // 버튼이 On일 경우
        {
            Debug.Log("OffOffOff!!!");
            isWastssonEnable = !isWastssonEnable; // 버튼 off;
            breaking = true; // 분리 함수 할수있게 활성화 
            voice.Active = false; // 왓슨 기능 비활성화
            test_Record_Image_child_Text.text = "Break!!"; // Recording 글씨를 Break!!으로 변경
            voice_text.GetComponent<TextMesh>().color = Color.red; // 색깔은 Red로 변경
        }
    }


    private void Break_Word()
    {
        break_word = voice_text.gameObject.AddComponent<Hangle>(); // 3D_text에 한글 스크립트 추가(모음 자음 분리 스크립트)
        Vector3 particle_dir = new Vector3(0, 0, 19);
        voice.ResultsField.text = "말을해주세요"; // 기본 글씨로 다시 바꿔준다

        particle_01.SetActive(true); // 파티클 활성화
        particle_01.transform.SetParent(cam); //파티클 위치 카메라 위치로 Parent화
        particle_01.transform.localPosition = particle_dir; // 파티클 로컬위치를 세부조정
        test_Record_Image.SetActive(false); // Recoring UI이미지를 비활성화

        break_word.check_break = false; // 한글 모음자음 분리 및 3D오브젝트로 매칭

        check_text = !check_text; // 다시 3D_text를 녹음할 수 있게 bool 함수 변경
        Destroy(voice_text, 0.15f); // 기존 생성된 3D_text오브젝트를 파괴한다(시간을 준 이유는 시간을 안주면 이상하게 파괴가 잘 안됨)


    }

    private void MovePlayer()
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
        }
    }

}
