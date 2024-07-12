using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private new GameObject camera;

    private CinemachineVirtualCamera _cv;

    private void Update()
    {
        _cv = camera.GetComponent<CinemachineVirtualCamera>();
        Transform tr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _cv.Follow = tr;
    }
}
