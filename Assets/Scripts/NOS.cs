using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NOS : MonoBehaviour
{
    public static int steps = 0;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public static void StepsCount()
    {
        steps++;
    }
    public static void StepsReset()
    {
        steps = 0;
    }
}
