using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseObj : MonoBehaviour
{
    [SerializeField]
    MapReverse mapReverse;
    public void OnTriggerEnter(Collider other)
    {
        mapReverse.Reverse();
        gameObject.SetActive(false);
    }
}
