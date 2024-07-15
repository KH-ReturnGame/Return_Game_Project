namespace WeaponOwnedStates
{
    public class CanDecrease : State<Weapon_Manager>
    {
        public override void Enter(Weapon_Manager weapon)
        {
            
        }

        public override void Execute(Weapon_Manager weapon)
        {
            
        }
        public override void Exit(Weapon_Manager weapon)
        {
            
        }
    }
    public class CanIncrease : State<Weapon_Manager>
    {
        public override void Enter(Weapon_Manager weapon)
        {
            
        }

        public override void Execute(Weapon_Manager weapon)
        {
            
        }
        public override void Exit(Weapon_Manager weapon)
        {
            
        }
    }
    public class IsReloadingRifle : State<Weapon_Manager>
    {
        public override void Enter(Weapon_Manager weapon)
        {
            //장전을 하는 동안에는 과열 감소 가능하게
            weapon.AddState(WeaponStates.CanDecrease);
        }

        public override void Execute(Weapon_Manager weapon)
        {
            
        }
        public override void Exit(Weapon_Manager weapon)
        {
            
        }
    }
    public class IsShootingRifle : State<Weapon_Manager>
    {
        public override void Enter(Weapon_Manager weapon)
        {
            //소총 발사하는 동안에는 감소 못하게
            weapon.RemoveState(WeaponStates.CanDecrease);
            weapon.AddState(WeaponStates.CanIncrease);
        }

        public override void Execute(Weapon_Manager weapon)
        {
            
        }
        public override void Exit(Weapon_Manager weapon)
        {
            //소총 발사 끝나면 감소 가능하게
            weapon.AddState(WeaponStates.CanDecrease);
            weapon.RemoveState(WeaponStates.CanIncrease);
        }
    }
}