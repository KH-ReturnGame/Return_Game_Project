using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFieldOfView : MonoBehaviour {

    [Header("View Config")]
    [Range(0f, 360f)]
    [SerializeField] private float m_horizontalViewAngle = 0f; // 시야각
    [SerializeField] private float m_viewRadius          = 1f; // 시야 범위
    [Range(-180f, 180f)]
    [SerializeField] private float m_viewRotateZ         = 0f; // 시야각의 회전값

    [SerializeField] private LayerMask m_viewTargetMask;       // 인식 가능한 타켓의 마스크(플레이어가 되겠죠 아마)
    [SerializeField] private LayerMask m_viewObstacleMask;     // 인식 방해물의 마스크 (플랫폼이되겠죠 아마)

    private List<Collider2D> hitedTargetContainer = new List<Collider2D>(); // 인식한 물체들을 보관할 컨테이너

    private float m_horizontalViewHalfAngle = 0f; // 시야각의 절반 값

    private Enemy testEnemy;
    public void Start()
    {
        testEnemy = this.GetComponent<Enemy>();
    }
    private void Awake()
    {
        m_horizontalViewHalfAngle = m_horizontalViewAngle * 0.5f;
    }

    private void OnDrawGizmos()
    {
        m_horizontalViewHalfAngle = m_horizontalViewAngle * 0.5f;

        Vector3 originPos = transform.position;

        Gizmos.DrawWireSphere(originPos, m_viewRadius);

        Vector3 horizontalRightDir = AngleToDirZ(m_horizontalViewHalfAngle + m_viewRotateZ);
        Vector3 horizontalLeftDir  = AngleToDirZ(-m_horizontalViewHalfAngle + m_viewRotateZ);
        Vector3 lookDir = AngleToDirZ(m_viewRotateZ);

        Debug.DrawRay(originPos, horizontalLeftDir * m_viewRadius, Color.cyan);
        Debug.DrawRay(originPos, lookDir * m_viewRadius, Color.green);
        Debug.DrawRay(originPos, horizontalRightDir * m_viewRadius, Color.cyan);

        FindViewTargets();
    }

    public Collider2D[] FindViewTargets()
    {
        hitedTargetContainer.Clear();

        Vector2      originPos    = transform.position;
        Collider2D[] hitedTargets = Physics2D.OverlapCircleAll(originPos, m_viewRadius, m_viewTargetMask);
        
        foreach (Collider2D hitedTarget in hitedTargets)
        {
            Vector2 targetPos = hitedTarget.transform.position;
            Vector2 dir       = (targetPos - originPos).normalized;
            Vector2 lookDir   = AngleToDirZ(m_viewRotateZ);

            // float angle = Vector3.Angle(lookDir, dir)
            // 아래 두 줄은 위의 코드와 동일하게 동작함. 내부 구현도 동일
            float dot   = Vector2.Dot(lookDir, dir);
            float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

            if (angle <= m_horizontalViewHalfAngle)
            {
                RaycastHit2D rayHitedTarget = Physics2D.Raycast(originPos, dir, m_viewRadius, m_viewObstacleMask);
                if (rayHitedTarget)
                {
                    Debug.Log("벽에 막힘");
                    Debug.DrawLine(originPos, rayHitedTarget.point, Color.yellow);
                }
                else
                {
                    Debug.Log("감지!");
                    hitedTargetContainer.Add(hitedTarget);
                    Debug.DrawLine(originPos, targetPos, Color.red);
                    // testEnemy.AddState(testEnemy._states[(int)EnemyStates.IsDetect]);
                }
            }
        }

        if (hitedTargetContainer.Count > 0)
        {
            testEnemy.AddState(EnemyStates.IsDetect);
            return hitedTargetContainer.ToArray();
        }
        else
        {
            testEnemy.RemoveState(EnemyStates.IsDetect);
            return null;
        }
    }

    // -180~180의 값을 Up Vector 기준 Local Direction으로 변환시켜줌.
    private Vector2 AngleToDirZ(float angleInDegree)
    {
        float radian = (angleInDegree - transform.eulerAngles.z) * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(radian), Mathf.Cos(radian));
    }
}