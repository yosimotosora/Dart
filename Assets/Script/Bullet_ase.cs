using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_ase : MonoBehaviour
{
    public float Speed = 5.0f;//スピード
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Speed, 0, 0) * Time.deltaTime);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "a")
        {
            Destroy(gameObject);
        }
    }
}
