using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private bool freezeVertical, freezeHorizontal;
    [SerializeField] private bool clampPosition;
    [SerializeField] private Transform clampMin, clampMax;
    [SerializeField] private Camera theCam;

    private Vector3 pos;
    private Vector3 positionStore;
    private float halfWidth, halfHeight;

    private void Start()
    {
        positionStore = transform.position;
        clampMin.SetParent(null);
        clampMax.SetParent(null);
        halfHeight = theCam.orthographicSize;
        halfWidth = theCam.orthographicSize * theCam.aspect;

    }

    private void LateUpdate()
    {
        pos = transform.position; 
        pos.x = target.position.x; 
        pos.y = target.position.y; 

        if (freezeVertical)
        {
            pos.y = positionStore.y; 
        }

        if (freezeHorizontal)
        {
            pos.x = positionStore.x; 
        }

        if (clampPosition)
        {
           
            pos.x = Mathf.Clamp(pos.x, clampMin.position.x + halfWidth, clampMax.position.x - halfWidth);
            pos.y = Mathf.Clamp(pos.y, clampMin.position.y + halfHeight, clampMax.position.y - halfHeight);
        }

        transform.position = pos; 
    }

}
