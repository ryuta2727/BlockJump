using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Cinemachine;
public class BlockMoving : MonoBehaviour
{
    [SerializeField]
    GameObject explosionPrefab;
    [SerializeField]
    Text text;
    private PlayerInput playerInput;
    private InputAction fire;
    private Rigidbody rbody;
    private BoxCollider boxCollider;

    private float clickTimer = 0;
    private bool onClick = false;
    private bool onExplosion = false;
    private bool onSwipe = false;
    private bool onJump = false;

    private float m = 2;
    private float a = 8;
    // Start is called before the first frame update
    void Start()
    {
        NOS.StepsReset();
        Cursor.visible = false;
        playerInput = GetComponent<PlayerInput>();
        fire = playerInput.actions["Fire"];
        rbody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(onClick)
        {
            clickTimer += Time.deltaTime;
        }
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            onJump = true;
            Debug.Log("aaa");
            onClick = true;
            NOS.StepsCount();
        }
        else if(context.canceled)
        {
            if (!onSwipe && onJump)
            {
                Debug.Log(clickTimer);
                var y = 0f;
                if (clickTimer <= 2)
                {
                    y = clickTimer;
                }
                else if (clickTimer > 2)
                {
                    y = Random.Range(2.5f, 3);
                }
                Debug.Log(y);
                var force = m * a * VectorCalculation(y);
                Debug.Log(force);
                rbody.AddForce(force, ForceMode.Impulse);
            }
            onJump = false;
            onClick = false;
            clickTimer = 0;
            onSwipe = false;
        }
    }
    //スワイプ処理
    public void OnLook(InputAction.CallbackContext context)
    {
            text.text = context.ReadValue<Vector2>().magnitude.ToString();
            if (context.ReadValue<Vector2>().magnitude > 0.5f || context.ReadValue<Vector2>().magnitude < -0.5f)
            {
                if (!onJump)
                {
                    clickTimer = 0;
                    onClick = false;
                    onSwipe = true;
                }
            }
    }
    //移動ベクトルを求める
    public Vector3 VectorCalculation(float y)
    {
        //y>2の時は暴発
        if (y > 2)
        {
            //チャージしすぎの場合
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            return new Vector3(0, y, 0);
        }
        //カメラ方向を求める
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        if(cameraForward.x == 0)
        {
            return Vector3.right;
        }
        else if(cameraForward.z == 0)
        {
            return Vector3.forward;
        }
        //---垂直ベクトルを求める----
        var z = Mathf.Sqrt(1f / (Mathf.Pow((cameraForward.z /cameraForward.x),2) + 1f));
        if(cameraForward.x > 0)
        {
            z = -z;
        }
        var x = -((cameraForward.z * z) / cameraForward.x);
        Vector3 verticalVector = new Vector3(x, y, z);
        
        return verticalVector;
    }
    //ゲームオーバー(落下)時のエフェクト
    public void Explosion()
    {
        if (!onExplosion)
        {
            onExplosion = true;
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
        }
    }
}
