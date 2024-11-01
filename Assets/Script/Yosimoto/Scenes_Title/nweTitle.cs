using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Internal;


public class nweTitle : MonoBehaviour
{

    [SerializeField]
    [ExcludeFromDocs]
    public bool StartFag;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Display");
    }

    // Update is called once per frame
    void Update()
    {
        if (StartFag == true)
        {
            MoveScenes();
        }
    }
    void MoveScenes()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Game();
        }
    }
    IEnumerator Display()
    {

        yield return new WaitForSeconds(4);
        StartFag = true;

    }
}
