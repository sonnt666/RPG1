using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineCameraShake : MonoBehaviour
{
    public static CinemachineCameraShake instance { get; private set; }
    private CinemachineVirtualCamera cvc;
    private float shakeTime;
    private CinemachineBasicMultiChannelPerlin channelPerlin;

    private void Awake()
    {
        instance = this;
        cvc = GetComponent<CinemachineVirtualCamera>();
        channelPerlin = cvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Start()
    {
        StopShakeCamera();
    }

    public void ShakeCamera(float intensity, float time)
    {
        channelPerlin.m_AmplitudeGain = intensity;
        shakeTime = time;
    }

    public void StopShakeCamera()
    {
        channelPerlin.m_AmplitudeGain = 0;
        shakeTime = 0;
    }

    private void Update()
    {
        if (shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;
        }
        else
        {
            StopShakeCamera();
        }
    }
}