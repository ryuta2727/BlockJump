using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardObj : MonoBehaviour
{
    Clear clear;
    private void Start()
    {
        clear = transform.parent.GetComponent<Clear>();
    }
    public void OnTriggerEnter(Collider other)
    {
        clear.ClearCount();
        this.gameObject.SetActive(false);
    }
}
