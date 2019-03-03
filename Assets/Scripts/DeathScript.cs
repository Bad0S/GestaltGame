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
        PlayerBehaviour.playerDead = false;
        yield return new WaitForSeconds(0.2f);
        fadeOut = true;
        yield return new WaitForSeconds(1f);
        fadeOut = false;
        blackVeil.SetActive(false);
        whiteVeil.SetActive(false);
    }

}
