using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public float SpeedForward = 12;
    public float SpeedSide = 6;
    Transform tr;
    private float dirX = 0;
    private float dirZ = 0;

    private Transform cam;


    void Start()
    {
        tr = GetComponent<Transform>();
        cam = tr.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor").GetComponent<Transform>();
        //cam = transform.Find("OVRCameraRig");

    }

    void Update()
    {
        //트리거 버튼 클릭
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            Debug.Log("Trigger Cliked !!!");
        }
        //트랙패드 터치
        if (OVRInput.Get(OVRInput.Touch.PrimaryTouchpad))
        {
            //트랙패드 터치 좌표값
            Vector2 pos = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
            Debug.LogFormat("Touch Postion x={0}, y={1}", pos.x, pos.y);
        }
        //트랙패드 클릭
        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))
        {

        }

        MovePlayer();
    }
    void MovePlayer()
    {
        // dirX = 0;
        // dirZ = 0;
        if (OVRInput.Get(OVRInput.Touch.PrimaryTouchpad))
        {
            Vector2 vec = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
            Vector3 _dir = new Vector3(vec.x, 0, vec.y);
            Vector3 dir = cam.transform.TransformDirection(_dir);

            transform.Translate(dir * SpeedForward * Time.deltaTime);
        }
    }
    // void MoveLookAt() {
    //     //Vector3 heading = cam.forward;
    //     //heading.y = 0f;
    //     // cam.transform.rotation

    //     // pointer.transform.localPosition = tr.localPosition + new Vector3(0, 0, range);
    //     // pointer.transform.LookAt(tr.position - pointer.transform.position);
    //     // pointer.transform.rotation = Quaternion.LookRotation(hit.normal);

    //     //Quaternion newRotation = Quaternion.LookRotation(heading);

    // }
}