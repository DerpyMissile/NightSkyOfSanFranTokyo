using Cinemachine;
using Cinemachine.PostFX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera closeUpCam;

    Animator animator;
    CinemachinePostProcessing cinemachinePostProcessing;
    Vignette vignette;
    LensDistortion lensDistortion;
    Grain grain;
    ChromaticAberration chromaticAberration;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        cinemachinePostProcessing = GetComponent<CinemachinePostProcessing>();
        vignette = cinemachinePostProcessing.m_Profile.GetSetting<Vignette>();
        lensDistortion = cinemachinePostProcessing.m_Profile.GetSetting<LensDistortion>();
        grain = cinemachinePostProcessing.m_Profile.GetSetting<Grain>();
        chromaticAberration = cinemachinePostProcessing.m_Profile.GetSetting<ChromaticAberration>();
    }

    public void UseGameCamera()
    {
        animator.SetTrigger("Game");
    }

    public void UseChiChiCamera()
    {
        animator.SetTrigger("ChiChi");
    }

    public void UseCloseUpCamera(Transform focus)
    {
        closeUpCam.Follow = focus;
        animator.SetTrigger("CloseUp");
    }

    public void UseCloseUpCamera(GameObject focus)
    {
        UseCloseUpCamera(focus.transform);
    }
}
