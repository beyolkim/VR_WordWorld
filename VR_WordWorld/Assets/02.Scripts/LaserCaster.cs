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
    public float power = 5f;
    public Color defaultColor = Color.white;
    private GameObject pointer;
    //Raycast  충돌한 지점의 정보를 반환할 구조체(Structure)
    private RaycastHit hit;

    private Ray ray;

    private GameObject gg;
    public GameObject test_text;

    void Start()
    {
        tr = GetComponent<Transform>();
        //프로젝트 뷰의 Resources 폴더에 있는 Pointer을 로드
        GameObject _pointer = Resources.Load<GameObject>("Pointer");
        pointer = Instantiate(_pointer);


        CreateLine();
        InvokeRepeating("make_testText", 3.0f, 2f);

    }

    private void Update()
    {
        //(광선의 발사원점, 발사방향, 결과값, 거리)

        if (Physics.Raycast(tr.position, tr.forward, out hit, range))
        {
            lineRenderer.SetPosition(1, new Vector3(0, 0, hit.distance));

            pointer.transform.position = hit.point - Vector3.forward * (0.01f);
            pointer.transform.rotation = Quaternion.LookRotation(hit.normal);

        }
        else
        {
            pointer.transform.position = tr.position + (tr.forward * range);
            pointer.transform.rotation = Quaternion.LookRotation(tr.forward);

        }
        Grab();
    }


    void make_testText()
    {
        Instantiate(test_text);

    }

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

        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            Vector3 pos_now = gg.transform.position;
            gg.transform.SetParent(null);
            // gg.transform.position = pos_now;
            gg.GetComponent<Rigidbody>().isKinematic = false;
            // gg.GetComponent<Rigidbody>().velocity = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTrackedRemote);
            gg.GetComponent<Rigidbody>().angularVelocity = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTrackedRemote);

            gg = null;


        }
    }

    void CreateLine()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.useWorldSpace = false;
        lineRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, Vector3.zero);
        lineRenderer.SetPosition(1, new Vector3(0, 0, range));

        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.005f;
        // lineRenderer.widthMultiplier = 0.05f;
        lineRenderer.material.color = defaultColor;


    }

}
