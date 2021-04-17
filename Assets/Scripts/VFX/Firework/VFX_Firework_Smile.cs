using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VFXData_Firework_Smile : VFXDataBase
{
    public VFXData_Firework_Smile() : base(MyConstant.VFX_Firework_SmileSDF)
    {

    }
}

public class VFX_Firework_Smile : VFXBase_Firework
{
    private float trailLifeTime = 5;
    private float trailDelay = 0.3f;

    public override void StartVFX()
    {
        transform.DOKill();
        transform.localScale = Vector3.one * 0.3f;
        transform.DOScale(1, 2).SetEase(Ease.OutQuad);
        base.StartVFX();
    }


    private float timer = 0;
    private void Update()
    {
        if (!IsInit || IsEnd)
            return;

        timer += Time.deltaTime;
        if (timer > trailLifeTime + trailDelay)
        {
            EndVFX();
        }
    }

}
