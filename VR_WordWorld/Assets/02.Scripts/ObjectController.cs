using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectController : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    Transform tr;
    private LaserCaster laserCaster;
    private GameObject rController;
    private GameObject particle;
    private AudioSource _audio;
    public AudioClip enterSfx;
    public AudioClip clickSfx;

    private Renderer rend;
    private Color NormalColor;
    public Color HighlightColor;


    // Start is called before the first frame update
    void Start()
    {
        _audio = this.gameObject.AddComponent<AudioSource>();
        tr = GetComponent<Transform>();
        rend = GetComponent<Renderer>();
        NormalColor = GetComponent<Renderer>().material.color;

        laserCaster = GameObject.FindGameObjectWithTag("RController").GetComponent<LaserCaster>();
        rController = GameObject.FindGameObjectWithTag("RController");
        particle = GameObject.FindGameObjectWithTag("Particles");
    }

    void FixedUpdate()
    {
        if (tr.position.y <= 0.1f)
        {
            laserCaster.Drop();
        }
        Mission();
    }
    void Mission()
    {
        Vector3 pos = tr.position;
        if (!tr.IsChildOf(rController.transform))
        {
            if (pos.y > 8f)
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
}
