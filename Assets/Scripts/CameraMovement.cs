using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float smoothTime = 0.3f;
    public Vector3 offset;
    public Transform player;
    private Vector3 velocity = Vector3.zero;


    Vector3 GetTargetPosition()
    {
        return player.position + offset;
    }

    private void Awake()
    {
        transform.position = GetTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = GetTargetPosition();
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothTime);
        transform.LookAt(player);
    }
}
