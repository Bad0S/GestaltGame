using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScript : MonoBehaviour
{
    public Transform checkpointTrans;
    public GameObject whiteVeil;
    public GameObject blackVeil;
    public bool fadeIn;
    public bool fadeOut;
    public float timer;
    public Transform playerTrans;
    private Transform mainCamTrans;

    private void Start()
    {
        mainCamTrans = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    void OnTriggerEnter(Collider other)
    {
        playerTrans = other.GetComponent<Transform>();
        PlayerBehaviour.playerDead = true;
        StartCoroutine(FadeAndRespawn());
    }

    private void Update()
    {
        if (fadeIn)
        {
            timer += Time.deltaTime;
            if (!GestaltManager.mode)
            {
                whiteVeil.SetActive(true);
                whiteVeil.GetComponent<Image>().color = Color.Lerp(new Color(255, 255, 255, 0), Color.white, timer);
            }
            else
            {
                blackVeil.SetActive(true);
                blackVeil.GetComponent<Image>().color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, timer);
            }
        }
        if (fadeOut)
        {
            timer += Time.deltaTime;
            if (!GestaltManager.mode)
            {
                whiteVeil.GetComponent<Image>().color = Color.Lerp(Color.white, new Color(255, 255, 255, 0), timer);
            }
            else
            {
                blackVeil.GetComponent<Image>().color = Color.Lerp(Color.black, new Color(0, 0, 0, 0), timer);
            }
        }
    }

    private IEnumerator FadeAndRespawn()
    {
        fadeIn = true;
        yield return new WaitForSeconds(1f);
        fadeIn = false;
        timer = 0;
        playerTrans.position = checkpointTrans.position;
        mainCamTrans.position = new Vector3(checkpointTrans.position.x, checkpointTrans.position.y, mainCamTrans.position.z);
        yield return new WaitForSeconds(0.4f);
        PlayerBehaviour.playerDead = false;
        fadeOut = true;
        yield return new WaitForSeconds(1f);
        fadeOut = false;
        timer = 0;
        blackVeil.SetActive(false);
        whiteVeil.SetActive(false);
    }

}
