using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletDown : BossBullet1
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.Rotate(0, 0, -48.0f);
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }
}
