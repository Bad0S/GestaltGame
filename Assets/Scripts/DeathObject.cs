using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathObject : MonoBehaviour
{
    public Transform checkpoint;
    public Transform cameraCheckpoint;
    public DeathScript deathScript;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !PlayerBehaviour.playerDead)
        {
            StartCoroutine(deathScript.FadeAndRespawn(checkpoint.position, cameraCheckpoint.position));
        }
    }
}
