using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip intro;
    public AudioClip loop;
    private AudioSource source;
    public float beatEvery;
    public float accuracy = 0.01f;
    public float offset;

    public delegate void OnBeat();

    public OnBeat onBeat;

    public static AudioController instance;

    private void Awake()
    {
        if (instance != this && instance != null)
            Destroy(instance);
        instance = this;
    }

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = intro;
        source.loop = false;

        source.Play();
        StartCoroutine("WaitForLoop");
        StartCoroutine(Vibe());
    }

    private IEnumerator WaitForLoop()
    {
        yield return new WaitForSecondsRealtime(intro.length);

        source.clip = loop;
        source.loop = true;

        source.Play();
    }

    private IEnumerator Vibe()
    {
        yield return new WaitForSeconds(offset);
        while (true)
        {
            yield return new WaitForSeconds(beatEvery);
            if (onBeat != null)
                onBeat.Invoke();
        }
    }




}
