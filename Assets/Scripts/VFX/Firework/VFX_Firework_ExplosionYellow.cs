using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX_Firework_ExplosionYellow : VFXBase_Firework
{
    private float minLiftTime = 2;
    private float maxLiftTime = 3;

    public override void SetVFX(VFXDataBase vfxData)
    {
        this.VFXData = vfxData;
        _visualEffect.SetFloat("MinLifeTime", minLiftTime);
        _visualEffect.SetFloat("MaxLifeTime", maxLiftTime);
        timer = 0;
    }

    public override void StartVFX()
    {
        base.StartVFX();
    }


    private float timer = 0;
    private void Update()
    {
        if (!IsInit || IsEnd)
            return;

        timer += Time.deltaTime;
        if (timer >= maxLiftTime)
        {
            EndVFX();
        }
    }

}
