using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private CinemachineComposer composer;

    [SerializeField]
    private float sensitivity = 1f;

    // Use this for initialization
    void Start()
    {
        composer = GetComponent<Cinemachine.CinemachineVirtualCamera>().GetCinemachineComponent<Cinemachine.CinemachineComposer>();

    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Mouse Y") * sensitivity;
        composer.m_TrackedObjectOffset.y += vertical;
        composer.m_TrackedObjectOffset.y = Mathf.Clamp(composer.m_TrackedObjectOffset.y, -10, 10);
    }
}