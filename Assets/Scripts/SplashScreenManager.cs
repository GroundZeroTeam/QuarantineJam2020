using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenManager : MonoBehaviour
{

    public int DelaySeconds = 5;
    public float FadeSeconds = 0.25f;
    public float LogoFadeSeconds = 0.25f;
    public float MoveSeconds = 0.25f;

    public SpriteRenderer BGSPrite;
    public SpriteRenderer LogoSprite;
    public GameObject CameraObject;

    public Color StartColor;
    public Color EndColor;

    bool startFade = false;
    bool startLogoFade = false;
    bool startMove = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForSplash());

        //Camera.backgroundColor = StartColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (startFade == true)
        {
            BGSPrite.color = Color.Lerp(StartColor, EndColor, Mathf.MoveTowards(0, 1, (Time.time - DelaySeconds) * FadeSeconds));
            //LogoSprite.color = Color.Lerp(Color.white, Color.clear, 0.001f);
        }

        if (startLogoFade == true)
        {
            LogoSprite.color = Color.Lerp(Color.white, Color.clear, Mathf.MoveTowards(0, 1, (Time.time - (DelaySeconds*2)) * FadeSeconds));
        }

        if (startMove == true)
        {
            BGSPrite.color = Color.Lerp(Color.white, Color.clear, Mathf.MoveTowards(0, 1, (Time.time - DelaySeconds*3) * FadeSeconds));
        }
    }

    IEnumerator WaitForSplash()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(DelaySeconds);

        if (startFade == false)
        {
            startFade = true;
            StartCoroutine(WaitForSplash());
        } else if (startLogoFade == false)
        {
            startLogoFade = true;
            StartCoroutine(WaitForSplash());
        } else if (startMove == false)
        {
            startMove = true;
        }

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
