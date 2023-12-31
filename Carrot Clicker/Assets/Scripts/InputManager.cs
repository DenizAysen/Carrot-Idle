using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InputManager : MonoBehaviour
{
    [Header("Action")]
    public static Action onCarrotClicked;
    public static Action<Vector2> onCarrotClickedPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            ManageTouches();
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
                ThrowRaycast();
        }        
    }
    private void ManageTouches()
    {
        Touch touch;
        for (int i = 0; i < Input.touchCount; i++)
        {
            touch = Input.GetTouch(i);

            if (touch.phase == TouchPhase.Began)
                ThrowRaycastInMobile(touch.position);
        }
    }
    private void ThrowRaycast()
    {
        RaycastHit2D hit =  Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

        if (hit.collider == null)
            return;

        onCarrotClicked?.Invoke();
        onCarrotClickedPosition?.Invoke(hit.point);
    }
    private void ThrowRaycastInMobile(Vector2 touchPosition)
    {
        RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(touchPosition));

        if (hit.collider == null)
            return;

        onCarrotClicked?.Invoke();
        onCarrotClickedPosition?.Invoke(hit.point);
    }
}
