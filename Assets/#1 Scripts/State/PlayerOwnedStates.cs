using UnityEngine;

namespace PlayerOwnedStates
{
    public class IsGround : State
    {
        public override void Enter(Player entity)
        {
            Debug.Log("isground enter");
        }
        public override void Execute(Player entity)
        {
            Debug.Log("isground execute");
        }
        public override void Exit(Player entity)
        {
            Debug.Log("isground exit");
        }
    }
    public class IsAir : State
    {
        public override void Enter(Player entity)
        {
            Debug.Log("IsAir enter");
        }
        public override void Execute(Player entity)
        {
            Debug.Log("IsAir excute");
        }
        public override void Exit(Player entity)
        {
            Debug.Log("IsAir exit");
        }
    }
    public class IsJump : State
    {
        public override void Enter(Player entity)
        {
            
        }
        public override void Execute(Player entity)
        {
            
        }
        public override void Exit(Player entity)
        {
            
        }
    }
    public class IsWall : State
    {
        public override void Enter(Player entity)
        {
            
        }
        public override void Execute(Player entity)
        {
            
        }
        public override void Exit(Player entity)
        {
            
        }
    }
    public class IsDash : State
    {
        public override void Enter(Player entity)
        {
            
        }
        public override void Execute(Player entity)
        {
            
        }
        public override void Exit(Player entity)
        {
            
        }
    }
    public class IsMove : State
    {
        public override void Enter(Player entity)
        {
            
        }
        public override void Execute(Player entity)
        {
            
        }
        public override void Exit(Player entity)
        {
            
        }
    }
    public class IsStun : State
    {
        public override void Enter(Player entity)
        {
            
        }
        public override void Execute(Player entity)
        {
            
        }
        public override void Exit(Player entity)
        {
            
        }
    }
    public class IsAttacked : State
    {
        public override void Enter(Player entity)
        {
            
        }
        public override void Execute(Player entity)
        {
            
        }
        public override void Exit(Player entity)
        {
            
        }
    }
    public class IsAttacking : State
    {
        public override void Enter(Player entity)
        {
            
        }
        public override void Execute(Player entity)
        {
            
        }
        public override void Exit(Player entity)
        {
            
        }
    }
}
