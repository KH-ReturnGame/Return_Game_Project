using UnityEngine;

namespace PlayerOwnedStates
{
    public class IsGround : State<Player>
    {
        public override void Enter(Player entity)
        {
            Debug.Log("Enter IsGround");
        }
        public override void Execute(Player entity)
        {
            
        }
        public override void Exit(Player entity)
        {
            Debug.Log("Exit IsGround");
        }
    }
    public class CanDash : State<Player>
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
    public class IsDashing : State<Player>
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
    public class IsAir : State<Player>
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
    public class IsJump : State<Player>
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
    public class IsWall : State<Player>
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
    public class IsSlope : State<Player>
    {
        public override void Enter(Player entity)
        {
            Debug.Log("Enter IsSlope");
        }
        public override void Execute(Player entity)
        {
            
        }
        public override void Exit(Player entity)
        {
            Debug.Log("Exit IsSlope");
        }
    }
    public class IsMove : State<Player>
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
    public class IsStun : State<Player>
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
    public class IsAttacked : State<Player>
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
    public class IsAttacking : State<Player>
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
    public class IsWallSliding : State<Player>
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

