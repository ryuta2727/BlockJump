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
    CinemachineVirtualCamera whileCamera;
    [SerializeField]
    CinemachineVirtualCamera gameMainCamera;
    [SerializeField]
    GameObject title;
    [SerializeField]
    GameObject uiGetStar;
    [SerializeField]
    PlayerInput playerInput;

    CinemachineFramingTransposer gameMainCameraFT;

    private bool onfire = false;
    private float time = 0;  //åoâﬂéûä‘
    private float maxTime = 2f;  //ç≈ëÂÉYÅ[ÉÄéûä‘

    //
    private bool onceTime = true;
    public bool onSwipe = false;
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
            time += Time.deltaTime;
            gameMainCameraFT.m_CameraDistance = Mathf.Lerp(8, 2, time / maxTime);
        }
        
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        if(context.performed && !onSwipe)
        {
            ToZoomCamera();
        }
        else if(context.canceled)
        {
            ToMainCamera();
            onSwipe = false;
        }
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        if (context.ReadValue<Vector2>().magnitude > 0.5f || context.ReadValue<Vector2>().magnitude < -0.5f)
        {
            onSwipe = true;
        }
    }
    public void OnRight(InputAction.CallbackContext context)
    {
        if(onceTime && context.performed)
        {
            onceTime = false;
            title.SetActive(false);
            uiGetStar.SetActive(true);
            titleCamera.Priority = 0;
            whileCamera.Priority = 10;
            StartCoroutine(CameraChangeTime());
        }
    }
    IEnumerator CameraChangeTime()
    {
        yield return new WaitForSeconds(2f);
        gameMainCamera.Priority = 15;
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
