using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet_ketchup : MonoBehaviour
{
    public GameObject Enemy1;//“G
    public float Speed = 5.0f;//ƒXƒs[ƒh 
    public float t = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 kaudou = Enemy1.transform.position - transform.position;//Šp“xŽæ“¾
        transform.rotation = Quaternion.FromToRotation(Vector3.up, kaudou);//Šp“x•ÏX        
    }
    // Update is called once per frame
    void Update()
    {
        if (t>=0.0f&&t<=0.5f)
        {
         t += Time.deltaTime;
        }
            else if (t >= 0.5f && t <= 1.0f)
            {
             t += Time.deltaTime * Speed;
                
            }
        float a = Easing.SineIn(t, 1, 0, 1);
        transform.Translate(new Vector3(0, a, 0) * Time.deltaTime*Speed);//ˆÚ“®
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Vector3 kaudou = Enemy1.transform.position - transform.position;//Šp“xŽæ“¾
            //transform.rotation = Quaternion.FromToRotation(Vector3.up, kaudou);//Šp“x•ÏX     
            return;
        }
    }
}
