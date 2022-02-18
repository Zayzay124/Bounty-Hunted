using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StamBar : MonoBehaviour
{
    private float MaxStam = 10.0f;
    private float CurrentStam = 10.0f;
    void Update()
    {
        if (Input.GetMouseButtonDown(1) == true)
        {
            CurrentStam -= 1.0f;
            transform.localScale = new Vector3(CurrentStam / MaxStam, 1.0f, 1.0f);
        }
    }
}
