using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform playerTrans;
    private Camera cam;
    private Vector2 smoothedVector;
    Vector2 reference;
    public float smoothTime;
    public float maxSpeed;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    void FixedUpdate ()
    {
        if (!PlayerBehaviour.playerDead)
        {
            smoothedVector = Vector2.SmoothDamp(transform.position, playerTrans.position, ref reference, smoothTime, maxSpeed);
            //if (cam.WorldToScreenPoint((playerTrans.position)).y > 285 || cam.WorldToScreenPoint(playerTrans.position).y < 120 || cam.WorldToScreenPoint(playerTrans.position).x > 477 || cam.WorldToScreenPoint(playerTrans.position).x < 277)
            //{
            transform.position = new Vector3(smoothedVector.x, smoothedVector.y, transform.position.z);
            //}
        }
        else
        { transform.position = new Vector3(playerTrans.position.x, playerTrans.position.y, transform.position.z); }
	}
}
