using UnityEngine.EventSystems;
using UnityEngine;

public class FireButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public bool firePressed = false;

    public void OnPointerUp(PointerEventData eventData)
    {
        firePressed = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        firePressed = true;
    }
}
