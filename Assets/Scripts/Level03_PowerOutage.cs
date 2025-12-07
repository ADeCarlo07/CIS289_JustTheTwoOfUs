using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class Level03_PowerOutage : MonoBehaviour
{
    public float maxTime = 5f;
    public GameObject blackOut;
    public GameObject backgroundMusic;

    public float minVolume = 0.08f;
    public float maxVolume = 0.78f;

    private AudioSource audioSource;

    bool displayed = false;

    void Start()
    {
        audioSource = backgroundMusic.GetComponent<AudioSource>();
        StartCoroutine(outageCycle());
    }

    void Update()
    {
        if (displayed)
        {
            StartCoroutine(endOutage());
        }
    }

    IEnumerator endOutage()
    {
        yield return new WaitForSeconds(maxTime);
        blackOut.SetActive(false);
        audioSource.volume = maxVolume;
        displayed = false;

    }
   

    IEnumerator outageCycle()
    {
        while (true)
        {

            yield return new WaitForSeconds(maxTime);

            blackOut.SetActive(true);
            displayed = true;

            yield return StartCoroutine(bufferAudio());

            
        }
    }

    IEnumerator bufferAudio()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return StartCoroutine(fadeVolume(maxVolume, minVolume, 0.2f));
            yield return StartCoroutine(fadeVolume(minVolume, maxVolume, 0.2f));
        }
    }

    IEnumerator fadeVolume(float start, float end, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            audioSource.volume = Mathf.Lerp(start, end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        audioSource.volume = end;
    }
}
