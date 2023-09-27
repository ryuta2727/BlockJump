using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapReverse : MonoBehaviour
{
    [SerializeField]
    GameObject BlueField;
    [SerializeField]
    GameObject RedField;

    private bool mapRe = false;  //ÉuÉãÅ[Ç™ê≥èÌ
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Reverse()
    {
        if(mapRe)
        {
            BlueField.SetActive(true);
            RedField.SetActive(false);
            mapRe = false;
        }
        else if(!mapRe)
        {
            RedField.SetActive(true);
            BlueField.SetActive(false);
            mapRe = true;
        }
    }
}
