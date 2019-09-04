using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    Transform tr;
    private LaserCaster laserCaster;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        laserCaster = GameObject.FindGameObjectWithTag("RController").GetComponent<LaserCaster>();
    }

    void FixedUpdate()
    {
        if (tr.position.y <= 0.1f)
        {
            laserCaster.Drop();
        }
<<<<<<< HEAD
    } 
=======
        Mission();
    }
    void Mission()
    {
        Vector3 pos = tr.position;
        if (tr.IsChildOf(rController.transform))
        {
            if (pos.y > 10f)
            {
                Debug.Log("참 잘했어요!!"); //파티클 자리
                particle.GetComponent<ParticleSystem>().Play();
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _audio.PlayOneShot(enterSfx);
        rend.material.color = HighlightColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _audio.PlayOneShot(clickSfx);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rend.material.color = NormalColor;
    }
>>>>>>> parent of f6a9409... 9_04 몰아주기 끝
}
