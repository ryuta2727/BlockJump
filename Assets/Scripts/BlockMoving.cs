using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
public class BlockMoving : MonoBehaviour
{
    [SerializeField]
    GameObject explosionPrefab;

    private PlayerInput playerInput;
    private InputAction fire;
    private Rigidbody rbody;
    private BoxCollider boxCollider;

    private float clickTimer = 0;
    private bool onClick = false;
    private bool onExplosion = false;

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
            onClick = true;
            NOS.StepsCount();
        }
        else if(context.canceled)
        {
            Debug.Log(clickTimer);
            var y = 0f;
            if (clickTimer <= 2)
            {
                y = clickTimer;
            }
            else if (clickTimer > 2)
            {
                y = Random.Range(3, 4);
            }
            onClick = false;
            //Debug.Log(clickTimer);
            var force = m * a * VectorCalculation(y);
            Debug.Log(force);
            rbody.AddForce(force, ForceMode.Impulse);
            clickTimer = 0;

        }
    }
    public Vector3 VectorCalculation(float y)
    {
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        if(cameraForward.x == 0)
        {
            return Vector3.right;
        }
        else if(cameraForward.z == 0)
        {
            return Vector3.forward;
        }
        //Debug.Log(cameraForward);
        var z = Mathf.Sqrt(1f / (Mathf.Pow((cameraForward.z /cameraForward.x),2) + 1f));
        if(cameraForward.x > 0)
        {
            z = -z;
        }
        //Debug.Log(z);
        var x = -((cameraForward.z * z) / cameraForward.x);
        //y‚Ì’l‰Â•ÏŽ®‚·‚é—\’è
        Vector3 verticalVector = new Vector3(x, y, z);
        if(y > 2)
        {
            verticalVector = new Vector3(0, y, 0);
        }
        return verticalVector;
    }
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
