using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptKari : MonoBehaviour
{

    public GameObject Beam;
    public GameObject ShotPoint;

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(Beam, ShotPoint.transform.position, ShotPoint.transform.rotation);
            Beam.transform.parent = this.transform;
        }
    }
}
