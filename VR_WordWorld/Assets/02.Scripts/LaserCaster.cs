using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCaster : MonoBehaviour
{
    //동적으로 생성할 라인렌더러 컴포넌트 저장할 변수
    private LineRenderer lineRenderer;
    private Transform tr;


    // 레이저의 거리
    public float range = 10.0f;

    public Color defaultColor = Color.white;
    //머티리얼 로드
    private Material mt;
    //포인터 프리맵 로드
    private GameObject pointerPrefab;
    //동적으로 생성해서 라인렌더러 끝에 위치시킬 객체
    private GameObject pointer;
    //Raycast  충돌한 지점의 정보를 반환할 구조체(Structure)
    private RaycastHit hit;

    private Ray ray;

    private GameObject gg;
    public GameObject test_text;

    void Start()
    {
        tr = GetComponent<Transform>();
        //프로젝트 뷰의 Resources 폴더에 있는 Line 에셋을 로드
        mt = Resources.Load<Material>("Line");
        //pointerPrefab = Resources.Load<GameObject>("Pointer");
        CreateLine();
        InvokeRepeating("make_testText", 3.0f, 2f);

    }

    private void Update()
    {
        //(광선의 발사원점, 발사방향, 결과값, 거리)
        if (Physics.Raycast(tr.position, tr.forward, out hit, range))
        {
            //라인렌더러 끝좌표 보정
           // lineRenderer.SetPosition(1, new Vector3(0, 0, hit.distance));
            //포인터의 끝좌표를 보정
            //pointer.transform.localPosition = tr.localPositionn - Vector3.forward * (0.01f) + new Vector3(0, 0, hit.distance);
            //포인터의 각도 수정
           // pointer.transform.rotation = Quaternion.LookRotation(hit.normal);
        }
        else
        {
            //pointer.transform.localPosition = tr.localPosition + new Vector3(0, 0, range);
            //pointer.transform.LookAt(tr.position - pointer.transform.position);
        }

        Grab();
    }


    void make_testText()
    {
        Instantiate(test_text);

    }
    //라인렌더러를 생성하는 함수


    void Grab()
    {
        ray = new Ray(tr.position, tr.forward);
        if (Physics.Raycast(ray, out hit, range))
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                if (hit.collider.gameObject.layer == 8)
                {
                    gg = hit.collider.gameObject;
                }
                gg.transform.SetParent(tr);
                gg.GetComponent<Rigidbody>().isKinematic = true;
            }
            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
            {
                Vector3 pos_now = gg.transform.position;
                gg.transform.SetParent(null);
                gg.transform.position = pos_now;
                gg.GetComponent<Rigidbody>().isKinematic = false;

            }
        }
    }

    void CreateLine()
    {
        lineRenderer = this.gameObject.AddComponent<LineRenderer>();
        //속성을 설정
        lineRenderer.useWorldSpace = false;
        lineRenderer.widthMultiplier = 0.05f;
        lineRenderer.SetPosition(1, new Vector3(0, 0, range));
        //머티리얼 생성 및 대입
        //Material mt = new Material(Shader.Find("Unlit/Color"));
        //mt.color = defaultColor;
        lineRenderer.sharedMaterial = mt;

        //pointer 생성

        //pointer = Instantiate(pointerPrefab, transform.position + lineRenderer.GetPosition(1), Quaternion.identity, this.transform);

    }




}
