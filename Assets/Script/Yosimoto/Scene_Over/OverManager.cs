using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Internal;


public class OverManager : MonoBehaviour
{
    public string LevelSccenenName;
    [SerializeField]
    [ExcludeFromDocs]
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveScenes();
    }
    void MoveScenes()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            SceneManager.LoadScene(LevelSccenenName);
        }
    }
}
