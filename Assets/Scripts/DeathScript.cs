using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScript : MonoBehaviour
{
    public Transform checkpointTrans;
    public GameObject whiteVeil;
    public GameObject blackVeil;
    public bool lerp;
    public float timer;
    public float alpha;

    void OnTriggerEnter (Collider other)
    {
        StartCoroutine(FadeAndRespawn());
        lerp = true;
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

    private void Update()
    {
        if (lerp)
        {
            timer += Time.deltaTime;
        }
    }

    private IEnumerator FadeAndRespawn()
    {
        yield return new WaitForSeconds(1f);
        lerp = false;
        timer = 0;
        blackVeil.SetActive(false);
        whiteVeil.SetActive(false);
    }

}
