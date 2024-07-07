using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Dead : MonoBehaviour
{
   
    Rigidbody2D rigid;

    private Enemy testEnemy;
    void Awake()
    {

        testEnemy = GetComponent<Enemy>();
        rigid = GetComponent<Rigidbody2D>();

        testEnemy.Setup(testEnemy.MaxHp);

    }



    // Update is called once per frame
    void FixedUpdate()
    {
       

        if(testEnemy.GetHp() <= 0)
        {
            testEnemy.AddState(testEnemy._states[(int)EnemyStates.IsDie]);
        }
        else
        {
            testEnemy.RemoveState(testEnemy._states[(int)EnemyStates.IsDie]);
            rigid.velocity = new Vector2(-3, rigid.velocity.y);
            // 여기다가 에너미 다른 함수 실행 시켜야 되지 않을까
        }
    }


    //함수 작동하는지 보기 위해 잠깐 넣은것. 나중엔 지울 것
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Triangle")
        {
            Debug.Log("Collison");
            testEnemy.TakeDamage(10);
            rigid.AddForce(new Vector2(10,5), ForceMode2D.Impulse);

        }
    }

   
}
