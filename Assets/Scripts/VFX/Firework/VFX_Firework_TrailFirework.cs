using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXData_Firework_TrailFirework : VFXDataBase
{
    public Vector3 originalWorldPos;
    public Vector3 worldDirection;

    public VFXData_Firework_TrailFirework(Vector3 originalWorldPos, Vector3 worldDirection) : base(MyConstant.VFX_Firework_TrailFirework)
    {
        this.originalWorldPos = originalWorldPos;
        this.worldDirection = worldDirection;
    }
}

public class VFX_Firework_TrailFirework : VFXBase_Firework
{
    private Rigidbody rb;

    private float trailLifeTime = 2;
    private float explosionDelayTime = 0.5f;

    public override void InitVFX()
    {
        base.InitVFX();
        rb = transform.GetComponent<Rigidbody>();
    }


    public override void SetVFX(VFXDataBase vfxData)
    {
        base.SetVFX(vfxData);
        VFXData_Firework_TrailFirework data = vfxData as VFXData_Firework_TrailFirework;

        _visualEffect.SetVector3("OriginalWorldPos", data.originalWorldPos);
        _visualEffect.SetVector3("WorldDirection", data.worldDirection);
        transform.position = data.originalWorldPos;
        rb.velocity = data.worldDirection * 20;
        timer = 0;
    }

    private float timer = 0;
    private void Update()
    {
        if (!IsInit || IsEnd)
            return;

        timer += Time.deltaTime;
        if (timer >= trailLifeTime + explosionDelayTime)
        {
            EndVFX();
        }
    }
}
