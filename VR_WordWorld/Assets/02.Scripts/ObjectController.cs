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
        if (tr.position.y >= 8f) {
            laserCaster.Drop();
        }
        // Mission();
    }
    void Mission()
    {
        Vector3 pos = tr.position;
        if (pos.y > 8f && !tr.IsChildOf(rController.transform))
        {            
                Debug.Log("참 잘했어요!!");                 
                particle.GetComponent<ParticleSystem>().Play(); 
                //미션 성공 파티클
            
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
