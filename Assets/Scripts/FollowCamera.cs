using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform target;
    public float cameraSpeed = 1;
    [SerializeField] float smoothing = 0.2f;
    [SerializeField] Vector2 minCameraBoundary;
    [SerializeField] Vector2 maxCameraBoundary;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (target == null) return;

        Vector3 pos = new Vector3(target.position.x, target.position.y, this.transform.position.z);
        transform.position = pos;

        //pos.x = Mathf.Clamp(pos.x, minCameraBoundary.x, maxCameraBoundary.x);
        //pos.y = Mathf.Clamp(pos.y, minCameraBoundary.y, maxCameraBoundary.y);

        //transform.position = Vector3.Lerp(transform.position, pos, smoothing);
    }
}
