using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CamChangeCheck : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public CinemachineFreeLook freeLookCamera;

    // Start is called before the first frame update


    private void Awake()
    {

    }

 /*   private void OnEnable()
    {
        if (virtualCamera != null)
        {
           // CinemachineCore.Instance.GetRig(virtualCamera).GetCinemachineComponent<CinemachineComposer>().m_OnTargetObjectWarped.AddListener(OnCameraChanged);
        }

        if (freeLookCamera != null)
        {
            //freeLookCamera.m_OnCameraCut.AddListener(OnCameraChanged);
        }
    }

    private void OnDisable()
    {
        if (virtualCamera != null)
        {
           // CinemachineCore.Instance.GetRig(virtualCamera).GetCinemachineComponent<CinemachineComposer>().m_OnTargetObjectWarped.RemoveListener(OnCameraChanged);
        }

        if (freeLookCamera != null)
        {
           // freeLookCamera.m_OnCameraCut.RemoveListener(OnCameraChanged);
        }
    }

    private void OnCameraChanged(CinemachineVirtualCameraBase virtualCameraBase)
    {
        // Camera has changed
        Debug.Log("Camera changed!");
        // Perform your desired actions here
    }*/
}