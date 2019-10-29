using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Manager : MonoBehaviour
{

    public static Object_Manager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<Object_Manager>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }

    private static Object_Manager m_instance;

    private void Awake()
    {
        // 씬에 싱글톤 오브젝트가 된 다른 GameManager 오브젝트가 있다면
        if (instance != this)
        {
            // 자신을 파괴
            Destroy(gameObject);
        }
    }


    public GameObject[] page_3;
    public GameObject[] page_3_te;

    public GameObject[] page_2;
    public GameObject[] page_2_te;

    
    // Start is called before the first frame update

    // Update is called once per frame
    
}
