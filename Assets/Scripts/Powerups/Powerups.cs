[System.Serializable]
public class Powerups
{
    //Variables to change
    public float speedMod;
    public float healthMod;
    public float maxHealthPermMod;
    public float fireRateMod;
    public float damageMod;
    public float damagePermMod;
    public int ammoMod;
    public int maxAmmoPermMod;
    public int fuelMod;
    public int maxFuelMod;

    public float duration;
    public bool isPerm;

    //Changing variables on active
    public void OnActivate(TankData target)
    {
        target.moveSpeedForward += speedMod;
        target.curHealth += healthMod;
        target.maxHealth += maxHealthPermMod;
        target.fireRate += fireRateMod;
        target.damageDone += damageMod;
        target.damageDone += damagePermMod;
        target.maxAmmo += maxAmmoPermMod;
        target.ammo += ammoMod;
        target.curFuel += fuelMod;
        target.maxFuel += maxFuelMod;

        if (target.curFuel > target.maxFuel)
            target.curFuel = target.maxFuel;
        if (target.curHealth > target.maxHealth)
            target.curHealth = target.maxHealth;
        if (target.ammo > target.maxAmmo)
            target.ammo = target.maxAmmo;
    }

    //Changing variables on deactive
    public void OnDeactivate(TankData target)
    {
        target.moveSpeedForward -= speedMod;
        target.fireRate -= fireRateMod;
        target.damageDone -= damageMod;
    }
}