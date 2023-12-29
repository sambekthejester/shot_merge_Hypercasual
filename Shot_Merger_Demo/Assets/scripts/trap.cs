using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    [SerializeField] float angle;

    // Update is called once per frame
    void Update()
    {
        TrapRotate();
    }

    void TrapRotate()
    {
        transform.Rotate(Vector3.right, angle);
    }
}
