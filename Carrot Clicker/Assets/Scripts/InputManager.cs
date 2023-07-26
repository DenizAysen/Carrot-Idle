using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InputManager : MonoBehaviour
{
    [Header("Action")]
    public static Action onCarrotClicked;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ThrowRaycast();
    }
    private void ThrowRaycast()
    {
        RaycastHit2D hit =  Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

        if (hit.collider == null)
            return;

        onCarrotClicked?.Invoke();
    }
}
