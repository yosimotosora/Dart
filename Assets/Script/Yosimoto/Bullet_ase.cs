using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_ase : MonoBehaviour
{
    public float Speed = 2.0f;//スピード
    public float Life_Time = 0.0f;
    public float Life_Interval = 2.0f;
    public GameObject Explosion;
    private bool SEFlag=true;
    public float t = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bullet();
    }
    void bullet()
    {
        if (t >= 0.0f && t <= 0.5f)
        {
            t += Time.deltaTime;
        }
        else if (t >= 0.5f && t < 1.0f)
        {
            t += Time.deltaTime;
        }
        else if (t >= 1.0f)
        {
            t = 1.0f;
        }
        float a = Easing.SineIn(t, 1, 0, 1)* Speed;
        //transform.Translate(new Vector3(0, a, 0) * Time.deltaTime*Speed);//移動
        transform.Translate(new Vector3(a, 0, 0) * Time.deltaTime);
        Life_Time+= Time.deltaTime;
        if (Life_Time >= Life_Interval)
        {
            Instantiate(Explosion,transform.position,transform.rotation);
            SoundManager.instance.OnePlaySE(SEFlag,0);
            Destroy(gameObject);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "a")
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            SoundManager.instance.OnePlaySE(SEFlag, 0);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            SoundManager.instance.OnePlaySE(SEFlag, 0);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Boss")
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            SoundManager.instance.OnePlaySE(SEFlag, 0);
            Destroy(gameObject);
        }
    }

}
