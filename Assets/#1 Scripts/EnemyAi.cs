using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    Rigidbody2D rigid;
    public float time;
    public int Direction;
    public int rage = 0;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Invoke("Think", 3);
    }
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(Direction, rigid.velocity.y);

        Vector2 frontVec = new Vector2(rigid.position.x + Direction, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("platform"));
        if (rayHit.collider == null) {
            Direction *= -1;
            CancelInvoke();
            Invoke("Think", 3);
            Debug.Log(Direction);
        }
        
    }
     void Update()
    {
        if (rage > 150)
        {
            rage = 150;
        }
    }

    void Think()
    {
        Direction = Random.Range(-1, 2);
        time = Random.Range(0f, 3f);
        Invoke("Think", time);
    }
}
