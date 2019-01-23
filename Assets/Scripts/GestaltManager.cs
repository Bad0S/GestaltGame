using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestaltManager : MonoBehaviour
{
    public static bool mode;

    public Material whiteMat;
    public Material blackMat;
    public List<GameObject> platformsList;
    public Renderer backgroundRend;
    public bool lerpBtW;
    public bool lerpWtB;
    public float timer;

    public List<GameObject> gestaltList;

    private void Start()
    {
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !lerpBtW && !lerpWtB)
        {
            if(mode == false)
            {
                mode = true;
                StartCoroutine(BlackToWhite());
                Gestalt();
            }
            else
            { 
                mode = false;
                StartCoroutine(WhiteToBlack());
                Gestalt();
            }
        }

        if (lerpBtW)
        {
            timer += Time.deltaTime;
            backgroundRend.material.Lerp(blackMat, whiteMat, timer);
            foreach (GameObject platform in platformsList)
            {
                platform.GetComponent<Renderer>().material.Lerp(whiteMat, blackMat, timer);
            }
        }

        if (lerpWtB)
        {
            timer += Time.deltaTime;
            backgroundRend.material.Lerp(whiteMat, blackMat, timer);
            foreach (GameObject platform in platformsList)
            {
                platform.GetComponent<Renderer>().material.Lerp(blackMat, whiteMat, timer);
            }
        }
    }

    IEnumerator BlackToWhite()
    {
        lerpBtW = true;
        yield return new WaitForSecondsRealtime(1);
        lerpBtW = false;
        timer = 0;
    }

    IEnumerator WhiteToBlack()
    {
        lerpWtB = true;
        yield return new WaitForSecondsRealtime(1);
        lerpWtB = false;
        timer = 0;
    }

    void Gestalt()
    {
        foreach (GameObject gestaltObject in gestaltList)
        {
            if (gestaltObject.GetComponent<Collider>().enabled == true)
            {
                gestaltObject.GetComponent<Collider>().enabled = false;
            }
            else
            {
                gestaltObject.GetComponent<Collider>().enabled = true;
            }
        }
    }
}
