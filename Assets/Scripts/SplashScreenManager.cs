using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreenManager : MonoBehaviour
{

    public int DelaySeconds = 5;
    public float FadeSeconds = 0.25f;
    public float LogoFadeSeconds = 0.25f;
    public float MoveSeconds = 0.25f;

    public Sprite[] introSprites;

    public SpriteRenderer BGSPrite;
    public SpriteRenderer LogoSprite;
    public GameObject CameraObject;

    public Color StartColor;
    public Color EndColor;

    int section = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForSplash());

        //Camera.backgroundColor = StartColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (section == 1)
        {
            BGSPrite.color = Color.Lerp(StartColor, EndColor, Mathf.MoveTowards(0, 1, (Time.time - DelaySeconds) * FadeSeconds));
            //LogoSprite.color = Color.Lerp(Color.white, Color.clear, 0.001f);
        }

        if (section == 2)
        {
            LogoSprite.color = Color.Lerp(Color.white, Color.clear, Mathf.MoveTowards(0, 1, (Time.time - (DelaySeconds*2)) * FadeSeconds));
        }

        if (section == 3)
        {
            LogoSprite.sprite = introSprites[0];
            LogoSprite.color = Color.Lerp(Color.clear, Color.black, Mathf.MoveTowards(0, 1, (Time.time - (DelaySeconds * section)) * FadeSeconds));
        }

        if (section == 4)
        {
            LogoSprite.color = Color.Lerp(Color.black, Color.clear, Mathf.MoveTowards(0, 1, (Time.time - (DelaySeconds * section)) * FadeSeconds));
        }

        if (section == 5)
        {
            LogoSprite.sprite = introSprites[1];
            LogoSprite.color = Color.Lerp(Color.clear, Color.white, Mathf.MoveTowards(0, 1, (Time.time - (DelaySeconds * section)) * FadeSeconds));
        }

        if (section == 6)
        {
            LogoSprite.color = Color.Lerp(Color.white, Color.clear, Mathf.MoveTowards(0, 1, (Time.time - (DelaySeconds * section)) * FadeSeconds));
        }

        if (section == 7)
        {
            LogoSprite.sprite = introSprites[2];
            LogoSprite.color = Color.Lerp(Color.clear, Color.white, Mathf.MoveTowards(0, 1, (Time.time - (DelaySeconds * section)) * FadeSeconds));
        }

        if (section == 8)
        {
            LogoSprite.color = Color.Lerp(Color.white, Color.clear, Mathf.MoveTowards(0, 1, (Time.time - (DelaySeconds * section)) * FadeSeconds));
        }

        if (section == 9)
        {
            LogoSprite.sprite = introSprites[3];
            LogoSprite.color = Color.Lerp(Color.clear, Color.white, Mathf.MoveTowards(0, 1, (Time.time - (DelaySeconds * section)) * FadeSeconds));
        }

        if (section == 10)
        {
            LogoSprite.color = Color.Lerp(Color.white, Color.clear, Mathf.MoveTowards(0, 1, (Time.time - (DelaySeconds * section)) * FadeSeconds));
        }

        if (section == 11)
        {
            LogoSprite.sprite = introSprites[4];
            LogoSprite.color = Color.Lerp(Color.clear, Color.white, Mathf.MoveTowards(0, 1, (Time.time - (DelaySeconds * section)) * FadeSeconds));
        }

        if (section == 12)
        {
            LogoSprite.color = Color.Lerp(Color.white, Color.clear, Mathf.MoveTowards(0, 1, (Time.time - (DelaySeconds * section)) * FadeSeconds));
        }

        if (section == 13)
        {
            LogoSprite.sprite = introSprites[5];
            LogoSprite.color = Color.Lerp(Color.clear, Color.white, Mathf.MoveTowards(0, 1, (Time.time - (DelaySeconds * section)) * FadeSeconds));
        }

        if (section == 14)
        {
            LogoSprite.color = Color.Lerp(Color.white, Color.clear, Mathf.MoveTowards(0, 1, (Time.time - (DelaySeconds * section)) * FadeSeconds));
        }

        if (section == 15)
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

        section++;
        StartCoroutine(WaitForSplash());

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
