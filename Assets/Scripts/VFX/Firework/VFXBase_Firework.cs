using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public abstract class VFXBase_Firework : VFXBase
{
    protected VisualEffect _visualEffect;

    public override void InitVFX()
    {
        _visualEffect = transform.GetComponent<VisualEffect>();
        _visualEffect.enabled = false;
        IsInit = true;
        IsEnd = false;
    }

    public override void SetVFX(VFXDataBase vfxData)
    {
        this.VFXData = vfxData;
        IsEnd = false;
    }

    public override void StartVFX()
    {
        _visualEffect.enabled = true;
        _visualEffect.Play();
    }

    public override void EndVFX()
    {
        IsEnd = true;
        CycleVFX();
    }


}
