using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    public Transform plane;

    void LateUpdate() {
        Vector3 newPosition = plane.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}
