using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class CameraContoroller : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera titleCamera;
    [SerializeField]
    CinemachineVirtualCamera gameMainCamera;
    [SerializeField]
    GameObject titleCanvas;
    [SerializeField]
    PlayerInput playerInput;

    CinemachineFramingTransposer gameMainCameraFT;

    private bool onfire = false;
    private float time = 0;  //åoâﬂéûä‘
    private float maxTime = 2f;  //ç≈ëÂÉYÅ[ÉÄéûä‘

    //
    private bool onceTime = true;
    // Start is called before the first frame update
    void Start()
    {
        gameMainCameraFT = gameMainCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(onfire)
        {
            Debug.Log("aaa");
            time += Time.deltaTime;
            gameMainCameraFT.m_CameraDistance = Mathf.Lerp(8, 2, time / maxTime);
        }
        
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            ToZoomCamera();
        }
        else if(context.canceled)
        {
            ToMainCamera();
        }
    }
    public void OnRight(InputAction.CallbackContext context)
    {
        if(onceTime && context.performed)
        {
            onceTime = false;
            titleCanvas.SetActive(false);
            titleCamera.Priority = 0;
            gameMainCamera.Priority = 10;
            StartCoroutine(CameraChangeTime());
        }
    }
    IEnumerator CameraChangeTime()
    {
        yield return new WaitForSeconds(2f);
        playerInput.currentActionMap = playerInput.actions.actionMaps[0];
    }
    public void ToMainCamera()
    {
        onfire = false;
        time = 0;
        gameMainCameraFT.m_CameraDistance = 8;
    }
    public void ToTitleCamera()
    {
        titleCamera.Priority = 10;
        gameMainCamera.Priority = 0;
    }
    public void ToZoomCamera()
    {
        onfire = true;
    }
}
