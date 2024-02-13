using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform karakterTransform;
    void Update()
    {
        if (karakterTransform != null)
        {
            transform.position = new Vector3(karakterTransform.position.x + 7, transform.position.y, transform.position.z);
        }
    }
}
