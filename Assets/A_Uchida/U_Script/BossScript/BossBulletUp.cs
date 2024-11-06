using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletUp : BossBullet1
{
    void Start()
    {

        this.transform.Rotate(0, 0, 48.0f);

    }

    // Update is called once per frame
    new void Update()
    {

        base.Update();

    }
}
