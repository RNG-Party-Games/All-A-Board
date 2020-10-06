using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Animator anim;
    void Start() {
        anim = GetComponent<Animator>();
    }
    public void OnPointerEnter(PointerEventData eventData) {
        anim.Play("Play");
    }

    public void OnPointerExit(PointerEventData eventData) {
        anim.Play("Idle");
    }

    public void OnPointerClick(PointerEventData eventData) {
        SceneManager.LoadScene("Game");
    }
}
