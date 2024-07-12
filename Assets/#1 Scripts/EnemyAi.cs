using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviours
{
    Rigidbody2D rigid;
    public int NextMove;
    public int rage = 0;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Invoke("Think", 3);
    }
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(NextMove, rigid.velocity.y);

        Vector2 frontVec = new Vector2(rigid.position.x + NextMove, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("platform"));
        if (rayHit.collider == null) {
            NextMove *= -1;
            CancelInvoke();
            Invoke("Think", 3);
        }
        
    }
     

    void Think()
    {
        NextMove = Random.Range(-1, 2);
        Invoke("Think", 3);
    }
}
