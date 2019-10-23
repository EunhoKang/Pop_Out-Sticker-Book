using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{
    public void exit(){
        Application.Quit();
    }
    public void GotoNexyScene(){
        SceneManager.LoadScene(1);
    }
    public void BacktoLobby(){
        SceneManager.LoadScene(0);
    }
    public void Howto(){
        //
    }
}
