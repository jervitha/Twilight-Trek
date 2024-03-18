using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private bool freezeVertical, freezeHorizontal;
    private Vector3 positionStore;
    [SerializeField] private bool clampPosition;
    [SerializeField] private Transform clampMin, clampMax;
    private float halfWidth, halfHeight;
    [SerializeField] private Camera theCam;
   
    void Start()
    {
        positionStore = transform.position;
        clampMin.SetParent(null);
        clampMax.SetParent(null);
        halfHeight = theCam.orthographicSize;
        halfWidth = theCam.orthographicSize * theCam.aspect;

    }

    
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x,target.position.y, transform.position.z);
        if(freezeVertical==true)
        {
            transform.position = new Vector3(transform.position.x, positionStore.y, transform.position.z);
        }
        if(freezeHorizontal==true)
        {
            transform.position = new Vector3(positionStore.x, transform.position.y, transform.position.z);
        }
        if(clampPosition==true)
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, clampMin.position.x +halfWidth, clampMax.position.x - halfWidth),
                Mathf.Clamp(transform.position.y, clampMin.position.y+halfHeight, clampMax.position.y-halfHeight),
                transform.position.z);
        }
    }
}
