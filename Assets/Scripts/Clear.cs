using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    private int clearCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        clearCount = 0;
    }
    public void ClearCount()
    {
        clearCount++;
    }
    public void Goal()
    {
        if(clearCount >= 2)
        {
            //クリアの処理
            SceneManager.LoadScene("EndScene");
        }
    }
}
