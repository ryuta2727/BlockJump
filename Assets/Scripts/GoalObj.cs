using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalObj : MonoBehaviour
{
    Clear clear;
    private void Start()
    {
        clear = transform.parent.GetComponent<Clear>();
    }
    public void OnTriggerEnter(Collider other)
    {
        clear.Goal();
    }
}
