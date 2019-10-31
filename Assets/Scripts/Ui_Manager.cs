using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.IO;
//using System.Text;

public class Ui_Manager : MonoBehaviour
{

    public static Ui_Manager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<Ui_Manager>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }

    private static Ui_Manager m_instance;

    private void Awake()
    {
        // 씬에 싱글톤 오브젝트가 된 다른 GameManager 오브젝트가 있다면
        if (instance != this)
        {
            // 자신을 파괴
            Destroy(gameObject);
        }
    }
    //책 내용 정리
    public Text SceneName;

    public Text Main_text;
    public int page_num = 0;

    private int pagenum_text;

    public string pages_name;
    public bool DataRead = false;
    public int index=0;

    public GameObject MenuCanvas;
    public GameObject OX;
    public GameObject quiz_corret;
    public GameObject quiz_fail;

    public Text state;

    List<string> lines = new List<string>();
    public List<string> values1 = new List<string>();
    public List<string> events1 = new List<string>();
    public List<string> values2 = new List<string>();
    public List<string> events2 = new List<string>();
    public List<string> values3 = new List<string>();
    public List<string> events3 = new List<string>();
    public List<string> values4 = new List<string>();
    public List<string> events4 = new List<string>();
    [HideInInspector]public List<List<string>> values = new List<List<string>>();
    [HideInInspector]public List<List<string>> events = new List<List<string>>();

    //퀴즈 답
    public List<int> answer1 = new List<int>(); //
    public List<int> answer2 = new List<int>();
    public List<int> answer3 = new List<int>();
    public List<int> answer4 = new List<int>();
    [HideInInspector]public List<List<int>> answers = new List<List<int>>();

    //시연 시 문장이 있는 위치
    public List<int> test1 = new List<int>(); // 
    public List<int> test2 = new List<int>(); //
    public List<int> test3 = new List<int>(); //0:나트륨 1:리튬 2:칼륨 3:구리 4:바륨 5:칼슘 6:스트론튬
    public List<int> test4 = new List<int>(); //
    [HideInInspector]public List<List<int>> tests = new List<List<int>>();

    //시연 시 생성되는 아이템들
    public List<GameObject> prefab1 = new List<GameObject>();
    public List<GameObject> prefab2 = new List<GameObject>();
    public List<GameObject> prefab3 = new List<GameObject>();
    public List<GameObject> prefab4 = new List<GameObject>();

    List<GameObject> object1 = new List<GameObject>();
    List<GameObject> object2 = new List<GameObject>();
    List<GameObject> object3 = new List<GameObject>();
    List<GameObject> object4 = new List<GameObject>();
    [HideInInspector]public List<List<GameObject>> objects = new List<List<GameObject>>();

    [HideInInspector]public int trackpoint = 0;
    [HideInInspector]public bool isTrackPhase = false;

    [HideInInspector]public bool isQuizPhase = false;

    public void Start()
    {
        values.Add(values1);
        values.Add(values2);
        values.Add(values3);
        values.Add(values4);
        events.Add(events1);
        events.Add(events2);
        events.Add(events3);
        events.Add(events4);
        answers.Add(answer1);
        answers.Add(answer2);
        answers.Add(answer3);
        answers.Add(answer4);
        tests.Add(test1);
        tests.Add(test2);
        tests.Add(test3);
        tests.Add(test4);
        for(int i=0; i < prefab1.Count; i++)
        {
            object1.Add(Instantiate(prefab1[i]));
        }
        for (int i = 0; i < prefab2.Count; i++)
        {
            object2.Add(Instantiate(prefab2[i]));
        }
        for (int i = 0; i < prefab3.Count; i++)
        {
            object3.Add(Instantiate(prefab3[i]));
        }
        for (int i = 0; i < prefab4.Count; i++)
        {
            object4.Add(Instantiate(prefab4[i]));
        }
        objects.Add(object1);
        objects.Add(object2);
        objects.Add(object3);
        objects.Add(object4);
        
    }

    public void SceneName_control(int pagenum) {
        SceneName.gameObject.SetActive(true);
        pagenum_text = pagenum;
        page_num = pagenum-1;

        if (pagenum == 1)
        {
            SceneName.text = "1교시 해부학 실험";
            
        }
        else if (pagenum == 2)
        {
            SceneName.text = "2교시 핵분열 실험";
        }
        else if (pagenum == 3)
        {
            SceneName.text = "3교시 불꽃색 실험";
        }
        else if (pagenum == 4)
        {
            SceneName.text = "4교시 산과 염기 실험";
        }

        //책내용 업데이트
        DataRead = true;
        

        //ReadData(pagenum);
        //ParseData();
        Main_text_Update();
    }

    //public void ReadData(int scenenum) //Resource 안의 Page1.txt, Page2.txt, Page3.txt, Page4.txt를 읽어온다. 이름 반드시 같게 할 것
    //{
    //    using (FileStream file = File.Open(Application.dataPath + "/Resources/Page"+scenenum.ToString()+".txt", FileMode.Open))
    //    {
    //        StreamReader sr = new StreamReader(file, Encoding.Default);
    //        string line;
    //        line = sr.ReadLine();

    //        while (line != null)
    //        {
    //            line = sr.ReadLine();
    //            lines.Add(line);
    //        }
    //        sr.Close();
    //    }
    //}

    //public void ParseData()
    //{
    //    for(int i = 0; i < lines.Count; i++)
    //    {
    //        string[] splited = lines[i].Split(new char[] { '\t' });
    //        values.Add(splited[0]);
    //        events.Add(splited[1]);
    //    }
    //}

    public void Main_text_Update()
    {
        //Debug.Log(index);
        Main_text.text = values[page_num][index];
        if (DataRead)
        {
            
            state.text = "이론";
            if (events[page_num][index]=="-1")
            {
                trackpoint = index;
                //Scene_check_manager.instance.SceneStart = false;//토큰 인식을 위해
                isTrackPhase = true;
                state.text="시연";
            }
            else if(events[page_num][index] == "1")
            {
                Main_text.text = values[page_num][index];
                index = trackpoint-1;
            }
            else if(events[page_num][index] == "2") //토큰 퀴즈
            {
                isQuizPhase=true;
                state.text="미션";
                //
            }
            else if(events[page_num][index] == "3") //ox 퀴즈
            {
                //
            }
            else if (events[page_num][index] == "4") //끝
            {
                Scene_check_manager.instance.SceneStart = false;
                //
            }
            else //평소
            {
                Scene_check_manager.instance.SceneStart = true;

            }

            
        }

    }

    public void next_text_go()
    {
        if (DataRead && !isQuizPhase)
        {
            if (index < values[page_num].Count-1)
            {
                index++;
            }
            Main_text_Update();
        }
    }

    public void prev_text_go()
    {
        if (DataRead && !isTrackPhase)
        {
            if (index > 0)
            {
                index--;
            }
            Main_text_Update();
        }
    }
    public void Test_token(int testnum) //토큰 인식은 다른 매니저에서
    {
        //시연 단계에서 토큰 인식이 된 순간 작동
        objects[page_num][testnum].SetActive(true); 
        
        index += tests[page_num][testnum];
        Main_text_Update();
    }

    public void Quiz_token(bool answer) //토큰 인식과 퀴즈 판별은 다른 매니저에서
    {
        index++;
        Main_text_Update();
        //퀴즈 단계에서 토큰 인식이 된 순간 작동
    }

    public void Quiz_ox(int quiznum)
    {

    }
}
