[System.Serializable]
public class Powerups
{
    //Variables to change
    public float speedMod;
    public float healthMod;
    public float maxHealthMod;
    public float fireRateMod;
    public float damageMod;

    public float duration;
    public bool isPerm;

    //Changing variables on active
    public void OnActivate(TankData target)
    {
        target.moveSpeedForward += speedMod;
        target.curHealth += healthMod;
        target.maxHealth += maxHealthMod;
        target.fireRate += fireRateMod;
        target.damageDone += damageMod;
    }

    //Changing variables on deactive
    public void OnDeactivate(TankData target)
    {
        target.moveSpeedForward -= speedMod;
        target.fireRate -= fireRateMod;
        target.damageDone -= damageMod;
    }
}