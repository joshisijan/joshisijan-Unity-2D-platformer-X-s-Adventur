using UnityEngine.EventSystems;

public class JumpButton : UnityEngine.MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public bool JumpPressed = false;

    public void OnPointerUp(PointerEventData eventData)
    {
        JumpPressed = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        JumpPressed = true;
    }
}
