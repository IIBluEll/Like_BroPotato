
public class AssultGun : WeaponStatus
{
    public WeaponData assult_Data;
    
    protected override void Start()
    {
        base.Start();
        Init(assult_Data);
    }
}
