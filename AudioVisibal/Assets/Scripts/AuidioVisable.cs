//本项目，学习自该视频
//https://www.bilibili.com/video/av90691909?t=369


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//添加音频组件
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
