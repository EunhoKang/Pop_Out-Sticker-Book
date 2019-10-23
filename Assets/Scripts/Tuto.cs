using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Tuto_scene;
   
    public void Go_tuto()
    {
        Tuto_scene.SetActive(true);
        
    }

    public void Off_Tuto(){
        Tuto_scene.SetActive(false);

    }

    // Update is called once per frame
    
}
