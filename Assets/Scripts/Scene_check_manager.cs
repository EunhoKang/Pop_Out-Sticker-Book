using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Scene_check_manager : MonoBehaviour
{
    public int check_num = 0;

    public bool SceneStart = false;
    public static Scene_check_manager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<Scene_check_manager>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }

    private static Scene_check_manager m_instance;

    private void Awake()
    {
        // 씬에 싱글톤 오브젝트가 된 다른 GameManager 오브젝트가 있다면
        if (instance != this)
        {
            // 자신을 파괴
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    public void check_track(string name)
    {
        //책을 어떻게 인식했는지 확인해주는 코드
        //이 이후론 AR관련 내용없음
        Debug.Log(name);
        if ((name == "frog") && (SceneStart == false))
        {
            check_num = 1;
            SceneStart = true;
        }
        else if (name == "newclear" && (SceneStart == false) )
        {
            check_num = 2;
            SceneStart = true;

        }
        else if(name =="color_fire" && (SceneStart == false) )
        {
            check_num = 3;
            SceneStart = true;

        }
        else if(name=="PH" && (SceneStart == false))
        {
            check_num = 4;
            SceneStart = true;

        }

        Ui_Manager.instance.SceneName_control(check_num);

        //여기부턴 토큰 인식 부분 

        //3페이지 인식 - 시연

        if (Ui_Manager.instance.page_num == 2)
        {
            if ((Ui_Manager.instance.events[Ui_Manager.instance.page_num][Ui_Manager.instance.index] == "-1"))
            {
                //0:나트륨 1:리튬  2:구리 3:바륨 4:칼슘 5:스트론튬

                //불꼿 싹다 꺼주기
                foreach (GameObject a in Object_Manager.instance.page_3)
                {
                    Debug.Log("sd");
                    a.SetActive(false);
                    
                }

                if (name == "Na")
                {
                    //오브젝트 매니저에서 특정 온
                    //텍스트 온해야함
                    Object_Manager.instance.page_3[0].SetActive(true);
                    Ui_Manager.instance.Main_text.text = Ui_Manager.instance.values[2][9];
                    //Ui_Manager.instance.Test_token(9);
                    

                }
                else if (name == "Li")
                {
                    Object_Manager.instance.page_3[1].SetActive(true);
                    Ui_Manager.instance.Main_text.text = Ui_Manager.instance.values[2][10];
                    //Ui_Manager.instance.Test_token(10);

                }
                else if (name == "Cu")
                {
                    Object_Manager.instance.page_3[2].SetActive(true);
                    Ui_Manager.instance.Main_text.text = Ui_Manager.instance.values[2][12];
                    //Ui_Manager.instance.Test_token(11);

                }
                else if (name == "Ba")
                {
                    Object_Manager.instance.page_3[3].SetActive(true);
                    Ui_Manager.instance.Main_text.text = Ui_Manager.instance.values[2][13];
                    //.instance.Test_token(12);

                }
                else if (name == "Ca")
                {
                    Object_Manager.instance.page_3[4].SetActive(true);
                    Ui_Manager.instance.Main_text.text = Ui_Manager.instance.values[2][14];
                    //Ui_Manager.instance.Test_token(13);

                }
                else if (name == "Sr")
                {
                    Object_Manager.instance.page_3[5].SetActive(true);
                    Ui_Manager.instance.Main_text.text = Ui_Manager.instance.values[2][15];
                    //Ui_Manager.instance.Test_token(14);

                }




            }
            Debug.Log(Ui_Manager.instance.events[Ui_Manager.instance.page_num][Ui_Manager.instance.index]);
            Debug.Log(Ui_Manager.instance.trackpoint);
            Debug.Log(Ui_Manager.instance.index);



            //3페이지 인식 - 미션의 경우1
            if ((Ui_Manager.instance.events[Ui_Manager.instance.page_num][Ui_Manager.instance.index] == "2") && ((Ui_Manager.instance.trackpoint) + 1 == Ui_Manager.instance.index))
            {
                Debug.Log("Sdsdsds");

                foreach (GameObject a in Object_Manager.instance.page_3)
                {
                    a.SetActive(false);

                }

                foreach (GameObject a in Object_Manager.instance.page_3_te)
                {
                    a.SetActive(false);

                }

                //0:나트륨 1:리튬 2:칼륨 3:구리 4:바륨 5:칼슘 6:스트론튬
                if (name == "Sr")
                {
                    //오브젝트 매니저에서 특정 온
                    Object_Manager.instance.page_3[5].SetActive(true);
                    Object_Manager.instance.page_3_te[0].SetActive(true);
                    Ui_Manager.instance.Quiz_token(true);
                    MyAudioManager.instance.Clear_bgm.Play();

                }
                else
                {
                    Object_Manager.instance.page_3_te[1].SetActive(true);
                    MyAudioManager.instance.false_bgm.Play();

                }




            }

            else if ((Ui_Manager.instance.events[Ui_Manager.instance.page_num][Ui_Manager.instance.index] == "2") && ((Ui_Manager.instance.trackpoint) + 2 == Ui_Manager.instance.index))
            {

                foreach (GameObject a in Object_Manager.instance.page_3)
                {
                    a.SetActive(false);

                }

                foreach (GameObject a in Object_Manager.instance.page_3_te)
                {
                    a.SetActive(false);

                }

                //0:나트륨 1:리튬 2:칼륨 3:구리 4:바륨 5:칼슘 6:스트론튬

                if (name == "Ca")
                {
                    Object_Manager.instance.page_3[4].SetActive(true);
                    Object_Manager.instance.page_3_te[0].SetActive(true);
                    Ui_Manager.instance.Quiz_token(true);
                    MyAudioManager.instance.Clear_bgm.Play();

                }
                else
                {
                    Object_Manager.instance.page_3_te[1].SetActive(true);
                    MyAudioManager.instance.false_bgm.Play();

                }




            }


        }

        //2페이지의 경우

        else if (Ui_Manager.instance.page_num == 1)
        {
            if ((Ui_Manager.instance.events[Ui_Manager.instance.page_num][Ui_Manager.instance.index] == "-1"))
            {
                //0: 중성자 1:우라늄

                //불꼿 싹다 꺼주기
                foreach (GameObject a in Object_Manager.instance.page_2)
                {
                    a.SetActive(false);
                }

                if (name == "U")
                {
                    //오브젝트 매니저에서 특정 온
                    //텍스트 온해야함
                    Object_Manager.instance.page_2[0].SetActive(true);

                }
                else if (name == "Nu")
                {
                    Object_Manager.instance.page_2[1].SetActive(true);

                }





            }

            if ((Ui_Manager.instance.events[Ui_Manager.instance.page_num][Ui_Manager.instance.index] == "1") && ((Ui_Manager.instance.trackpoint) + 1 == Ui_Manager.instance.index))
            {
                Debug.Log("Mission!!");

            }
        }

        

        


        


    }

    

    

    // Update is called once per frame
    
}
