using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet_ketchup : MonoBehaviour
{
    public Transform Enemy1;//敵
    public float Speed = 5.0f;//スピード 
    public float RotationSpeed = 100;//回転スピード
    public float t = 0.0f;
    public float SlerpFactor=1.0f;
    public bool inversion=true;
    public bool pictyer=false;
    public bool move=false;
    public Vector2 Enemy;


    // Start is called before the first frame update
    void Start()
    {
        //Vector3 kaudou = Enemy1.transform.position - transform.position;//角度取得
        //transform.rotation = Quaternion.FromToRotation(Vector3.up, kaudou);//角度変更        
    }
    // Update is called once per frame
    void Update()
    {
        Enemy = Enemy1.transform.position;
        LookAt2D(Enemy, inversion, pictyer, move, Speed, RotationSpeed, SlerpFactor);
        //if (t>=0.0f&&t<=0.5f)
        //{
        // t += Time.deltaTime;
        //}
        //    else if (t >= 0.5f && t <= 1.0f)
        //    {
        //     t += Time.deltaTime * Speed;

        //    }
        //float a = Easing.SineIn(t, 1, 0, 1);
        //transform.Translate(new Vector3(0, a, 0) * Time.deltaTime*Speed);//移動
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

    }
    void LookAt2D(Vector2 targetPosition, bool inversion = true, bool pictyer = false, bool move = false, float speed = 1f, float rotationSpeed = 100f, float slerpFactor = 1f)
    {
        int a = 0;
        if (pictyer == true)
        {
            a = 180;
        }
        Vector2 myPosition = (Vector2)transform.position;
        Vector2 direction = targetPosition - myPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion currentRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(180, a, angle * -1); ;
        transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, slerpFactor * Time.deltaTime * rotationSpeed);
        if (inversion)
        {
            if (angle >= 90 || angle <= -90) { transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y), transform.localScale.z); }
            else { transform.localScale = new Vector3(transform.localScale.x, -Mathf.Abs(transform.localScale.y), transform.localScale.z); }
        }
        if (move)
        {
            Vector2 moveDirection = direction.normalized;
            Vector2 newPosition = myPosition + moveDirection * speed * Time.deltaTime;
            transform.position = newPosition;
        }

    }

}
