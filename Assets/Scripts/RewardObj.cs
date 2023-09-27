using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardObj : MonoBehaviour
{
    [SerializeField]
    GetStarText getStarText;
    Clear clear;
    private void Start()
    {
        clear = transform.parent.GetComponent<Clear>();
    }
    public void OnTriggerEnter(Collider other)
    {
        clear.ClearCount();
        getStarText.UpdateText();
        this.gameObject.SetActive(false);
    }
}
