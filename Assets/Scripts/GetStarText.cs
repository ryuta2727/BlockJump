using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
public class GetStarText : MonoBehaviour
{
    Text text;
    private int getStar = 0;
    [SerializeField]
    GameObject star1;
    [SerializeField]
    GameObject star2;
    [SerializeField]
    GameObject text2;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "0/2";
    }
    public void UpdateText()
    {
        getStar++;
        text.text = getStar + "/" + 2;
        if (getStar == 1)
        {
            star1.SetActive(true);
        }
        else if(getStar == 2)
        {
            star2.SetActive(true);
            text2.SetActive(true);
        }
    }
}
