using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick2 : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private float maxJoystickDistance = 100f;
    private float minJoystickDistance = 0f;

    public float h;
    public float v;

    public float Horizontal { get { return h; } }
    public float Vertical { get { return v; } }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(transform as RectTransform, eventData.position, eventData.pressEventCamera, out position))
        {
            position.x = (position.x / (transform as RectTransform).sizeDelta.x);
            position.y = (position.y / (transform as RectTransform).sizeDelta.y);

            float distance = Vector2.Distance(Vector2.zero, position);
            if (distance > maxJoystickDistance)
            {
                position = position.normalized * maxJoystickDistance;
            }
            else if (distance < minJoystickDistance)
            {
                position = Vector2.zero;
            }

            h = position.x;
            v = position.y;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        h = 0f;
        v = 0f;
    }
}
