using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour, IPointerClickHandler
{
    void Start() {
        Cursor.lockState = CursorLockMode.None;
    }
    public void OnPointerClick(PointerEventData eventData) {
        SceneManager.LoadScene("Title");
    }
}
