using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LaserCaster : MonoBehaviour
{
    //동적으로 생성할 라인렌더러 컴포넌트 저장할 변수
    private LineRenderer lineRenderer;
    public Transform tr;
    // 레이저의 거리

    public float range = 10.0f;
    public Color defaultColor = Color.white;
    private GameObject pointer;
    //Raycast  충돌한 지점의 정보를 반환할 구조체(Structure)
    private RaycastHit hit;
    private Ray ray;

    private GameObject gg;
    public GameObject test_text;
    private bool grabbing = false;


    private GameObject prevText;
    private GameObject currText;
    public AudioClip deleteSfx;
    private AudioSource audioSource;

    //break 함수!!

    public Ray P_ray
    {
        get { return ray; }
        set { ray = value; }
    }


    void Start()
    {
        tr = GetComponent<Transform>();
        //프로젝트 뷰의 Resources 폴더에 있는 Pointer을 로드
        GameObject _pointer = Resources.Load<GameObject>("Pointer");
        pointer = Instantiate(_pointer);

        audioSource = GetComponent<AudioSource>();

        CreateLine();
        // InvokeRepeating("make_testText", 3.0f, 2f);


    }

    private void Update()
    {
        Pointer();

        if (!grabbing && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            Grab();
        }
        if (grabbing && OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            Drop();
        }
        if (OVRInput.GetDown(OVRInput.Button.Back))
        {
            Delete();
        }
        EnterObject();


    }
    void make_testText()
    {
        //Instantiate(test_text);
    }

    void Grab()
    {
        grabbing = true;
        ray = new Ray(tr.position, tr.forward);
        if (Physics.Raycast(ray, out hit, range))
        {
            if (hit.collider.CompareTag("TEXT"))
            {
                gg = hit.collider.gameObject;
                ExecuteEvents.Execute(gg, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);

            }
            gg.transform.SetParent(tr);
            gg.GetComponent<Rigidbody>().isKinematic = true;
        }

    }
    public void Drop()
    {
        grabbing = false;
        if (gg != null)
        {
            //  Vector3 pos_now = gg.transform.position;
            gg.transform.SetParent(null);
            // gg.transform.position = pos_now;
            gg.GetComponent<Rigidbody>().isKinematic = false;
            gg.GetComponent<Rigidbody>().velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTrackedRemote);
            gg.GetComponent<Rigidbody>().angularVelocity = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTrackedRemote);

            gg = null;
        }

    }

   

    void Delete()
    {
        // ray = new Ray(tr.position, tr.forward);
        if (Physics.Raycast(tr.position, tr.forward, out hit, range))
        {
            if (hit.collider.CompareTag("TEXT"))
            {
                audioSource.PlayOneShot(deleteSfx);
                Destroy(hit.collider.gameObject);
            }
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

        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.005f;
        // lineRenderer.widthMultiplier = 0.05f;
        lineRenderer.material.color = defaultColor;


    }
    void Pointer()
    {
        //(광선의 발사원점, 발사방향, 결과값, 거리)
        if (Physics.Raycast(tr.position, tr.forward, out hit, range))
        {
            lineRenderer.SetPosition(1, new Vector3(0, 0, hit.distance)); //라인이 물체에 맞으면 그 위치를 끝점으로

            pointer.transform.position = hit.point - Vector3.forward * (0.01f); //라인이 물체에 맞으면 그 위치에 포인터 생성
            pointer.transform.rotation = Quaternion.LookRotation(hit.normal); //포인터가 항상 카메라를 바라보도록
        }
        else
        {
            pointer.transform.position = tr.position + (tr.forward * range); //물체에 맞지 않았을 때 포인터의 위치는 라인 끝점에
            pointer.transform.rotation = Quaternion.LookRotation(tr.forward);
        }
    }
    void EnterObject()
    {
        PointerEventData data = new PointerEventData(EventSystem.current);
        if (Physics.Raycast(tr.position, tr.forward, out hit, range) && hit.collider.CompareTag("TEXT"))
        {
            currText = hit.collider.gameObject;
            if (currText != prevText)
            {
                ExecuteEvents.Execute(currText, data, ExecuteEvents.pointerEnterHandler);
                ExecuteEvents.Execute(prevText, data, ExecuteEvents.pointerExitHandler);
                prevText = currText;
            }
        }
        else
        {
            ExitObject();
        }
    }
    void ExitObject()
    {
        PointerEventData data = new PointerEventData(EventSystem.current);

        if (prevText != null)
        {
            ExecuteEvents.Execute(prevText, data, ExecuteEvents.pointerExitHandler);
            prevText = null;
        }
    }

}
