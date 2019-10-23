using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fix : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject teset;
    public Text a;
    

    // Update is called once per frame
    void Update()
    {
        if(teset.gameObject.transform.position.x >0){
            a.text = "yumumu";
        }
        else if(teset.gameObject.transform.position.x <=0){
            a.text = "San";
        }
        
    }
}
