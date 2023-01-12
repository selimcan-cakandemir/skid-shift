using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _cameraOffset;

    void Update()
    {
        Vector3 targetPos= _target.position;
        Vector3 cameraPos= transform.position;
        cameraPos = _target.position + _cameraOffset;
        transform.position = cameraPos;
    }
}
