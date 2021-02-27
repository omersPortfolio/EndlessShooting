using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    Camera cam;

    float shakeAmount = 0;

    public static CameraShake instance;

    Vector3 camPosition;

    private void Awake()
    {
        instance = this;

        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    private void Start()
    {
        camPosition = cam.transform.position;
    }

    public void Shake(float amount, float length)
    {
        shakeAmount = amount;
        InvokeRepeating("BeginShake", 0, 0.01f);
        Invoke("StopShake", length);
    }

    void BeginShake()
    {
        if (shakeAmount > 0)
        {
            Vector3 camPos = cam.transform.position;

            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
            camPos.x += offsetX;
            camPos.y += offsetY;

            cam.transform.position = camPos;
        }
    }

    void StopShake()
    {
        CancelInvoke("BeginShake");
        cam.transform.localPosition = camPosition;
    }
}
