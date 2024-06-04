public class BaseWarrior : BaseRole
{
    public BaseWarrior()
    {
        Health = 10;
        Strength = 5;
        Intelligence = 2;
        Agility = 3;
        Damage = Strength * 5;
        CanShoot = false;
    }

    public void Hit()
    {
    }
}