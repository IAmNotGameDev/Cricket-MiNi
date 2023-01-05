using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private float maxJoystickDistance = 100f;
    private float minJoystickDistance = 0f;

    private float horizontal;
    private float vertical;

    public float Horizontal { get { return horizontal; } }
    public float Vertical { get { return vertical; } }

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

            horizontal = position.x;
            vertical = position.y;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        horizontal = 0f;
        vertical = 0f;
    }
}
