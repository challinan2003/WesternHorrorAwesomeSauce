using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler

{
    [Tooltip("Use -1 for no sound")]
    public int hoverSFXIndex = 0;
    [Tooltip("Use -1 for no sound")]
    public int clickSFXIndex = 0;
    [SerializeField] private float hoverScale = 4.07f;
    [SerializeField] private float returnScale = 4f;
    [SerializeField] private float clickScale = 3.98f;
    private float hoverTweenDuration = 0.15f;
    private float clickTweenDuration = 0.05f;
    private float returnToDuration = 0.05f;
    private bool ran = false;
    private Ease hoverEase = Ease.OutExpo;
    private Ease clickEase = Ease.OutBack;


    // hover
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!ran && gameObject.GetComponent<Button>().interactable == true)
        {
            
            gameObject.transform.DOScale(hoverScale, hoverTweenDuration).SetEase(hoverEase);
            //play UI hover sfx
            if (hoverSFXIndex != -1)
            {
                //SoundManager.instance.PlaySFX(hoverSFXIndex);
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.transform.DOKill();
        gameObject.transform.DOScale(returnScale, returnToDuration);
    }


    // click
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!ran && gameObject.GetComponent<Button>().interactable == true)
        {
            gameObject.transform.DOScale(clickScale, clickTweenDuration).SetEase(clickEase);

            if (clickSFXIndex != -1)
            {
                //SoundManager.instance.PlaySFX(clickSFXIndex);
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        this.transform.DOKill();
        this.transform.DOScale(returnScale, returnToDuration);
        ran = false;
    }
}