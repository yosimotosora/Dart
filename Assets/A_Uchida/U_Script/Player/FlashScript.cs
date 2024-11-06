using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float FlashTimer = 0;
    private float FlashTimerUpdate;
    public float FlashTime = 0.3f;
    public Renderer FlashTarget;

   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Flash()
    {
        var RepeatValue = Mathf.Repeat(FlashTimerUpdate, FlashTime);
        FlashTarget.enabled = RepeatValue >= FlashTime * 0.5f;
        FlashTimer += Time.deltaTime;

        if (FlashTimer > 1.0f)
        {
            FlashTarget.enabled = true;
        }
    }//END Flash
}
