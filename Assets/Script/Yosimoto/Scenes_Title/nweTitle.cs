using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Internal;


public class nweTitle : MonoBehaviour
{

    [SerializeField]
    [ExcludeFromDocs]
    public bool StartFag=true;
    public TitleScript titleScript;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        StartFag = titleScript.MoveFlag;
        if (StartFag == false)
        {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Game();
        }
            MoveScenes();
        }
    }
    void MoveScenes()
    {
    }
    IEnumerator Display()
    {

        yield return new WaitForSeconds(4);
        StartFag = true;

    }
}
