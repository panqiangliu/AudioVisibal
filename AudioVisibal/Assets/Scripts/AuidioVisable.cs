using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AuidioVisable : MonoBehaviour
{
    public static AuidioVisable Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    AudioSource audioSource;
    public float[] sample = new float[512];

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        GetSpectrumData();
    }

    void GetSpectrumData()
    {
        audioSource.GetSpectrumData(sample, 0, FFTWindow.Blackman);
    }
}
