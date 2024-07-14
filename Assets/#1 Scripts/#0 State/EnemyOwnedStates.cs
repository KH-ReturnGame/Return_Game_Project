using UnityEngine;

namespace EnemyOwnedStates
{
    public class IsGround : State<Enemy>
    {
        public override void Enter(Enemy entity)
        {
            Debug.Log("isground enter");
        }
        public override void Execute(Enemy entity)
        {
            Debug.Log("isground Execute");
        }
        public override void Exit(Enemy entity)
        {
            Debug.Log("isground Exit");
        }
    }
    public class IsAir : State<Enemy>
    {
        public override void Enter(Enemy entity)
        {
            Debug.Log("IsAir enter");
        }
        public override void Execute(Enemy entity)
        {
            Debug.Log("IsAir Execute");
        }
        public override void Exit(Enemy entity)
        {
            Debug.Log("IsAir Exit");
        }
    }
    public class IsJump : State<Enemy>
    {
        public override void Enter(Enemy entity)
        {
            
        }
        public override void Execute(Enemy entity)
        {
            
        }
        public override void Exit(Enemy entity)
        {
            
        }
    }
    public class IsWall : State<Enemy>
    {
        public override void Enter(Enemy entity)
        {
            
        }
        public override void Execute(Enemy entity)
        {
            
        }
        public override void Exit(Enemy entity)
        {
            
        }
    }
    public class IsMove : State<Enemy>
    {
        public override void Enter(Enemy entity)
        {
            
        }
        public override void Execute(Enemy entity)
        {
            
        }
        public override void Exit(Enemy entity)
        {
            
        }
    }
    public class IsStun : State<Enemy>
    {
        public override void Enter(Enemy entity)
        {
            
        }
        public override void Execute(Enemy entity)
        {
            
        }
        public override void Exit(Enemy entity)
        {
            
        }
    }
    public class IsAttacked : State<Enemy>
    {
        public override void Enter(Enemy entity)
        {
            
        }
        public override void Execute(Enemy entity)
        {
            
        }
        public override void Exit(Enemy entity)
        {
            
        }
    }
    public class IsAttacking : State<Enemy>
    {
        public override void Enter(Enemy entity)
        {
            
        }
        public override void Execute(Enemy entity)
        {
            
        }
        public override void Exit(Enemy entity)
        {
            
        }
    }
    public class IsDetect : State<Enemy>
    {
        public override void Enter(Enemy entity)
        {
            Debug.Log("isdetect enter");
        }
        public override void Execute(Enemy entity)
        {
            Debug.Log("isdetect execute");
        }
        public override void Exit(Enemy entity)
        {
            Debug.Log("isdetect exit");
        }
    }
    public class IsDie : State<Enemy>
    {
        public override void Enter(Enemy entity)
        {
            Debug.Log("IsDie Enter");
            //시체 상호작용 넣을거면 여기다 넣어야 될 듯

        }
        public override void Execute(Enemy entity)
        {
            Debug.Log("IsDie Execute");
        }
        public override void Exit(Enemy entity)
        {
            Debug.Log("Is Die Exit???");
        }
    }
    public class IsCool : State<Enemy>
    {
        public override void Enter(Enemy entity)
        {
            
        }
        public override void Execute(Enemy entity)
        {
            
        }
        public override void Exit(Enemy entity)
        {
            
        }
    }
}