using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    private void OnTriggerEnter(Collider other) {
        if(other.name =="teset1"){
            Debug.Log("plplplpl");
        }
        
    }
    
}
