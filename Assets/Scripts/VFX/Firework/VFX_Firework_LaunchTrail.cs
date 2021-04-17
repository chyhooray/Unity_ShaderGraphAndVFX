using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXData_Firework_LaunchTrail : VFXDataBase
{
    public float delayTime;
    public Action<Vector3> endCB;

    public VFXData_Firework_LaunchTrail(float delayTime, Action<Vector3> endCB) : base(MyConstant.VFX_Firework_LaunchTrail)
    {
        this.delayTime = delayTime;
        this.endCB = endCB;
    }
}

public class VFX_Firework_LaunchTrail : VFXBase_Firework
{
    private Rigidbody rb;

    private float lifeTime = 2;
    private float MinSpeedFactor = 20;
    private float MaxSpeedFactor = 23;

    public override void InitVFX()
    {
        base.InitVFX();
        rb = GetComponent<Rigidbody>();
    }

    public override void SetVFX(VFXDataBase vfxData)
    {
        base.SetVFX(vfxData);
        timer = 0;
    }

    public override void StartVFX()
    {
        base.StartVFX();
        rb.velocity = Vector3.up * UnityEngine.Random.Range(MinSpeedFactor, MaxSpeedFactor);
    }

    public override void EndVFX()
    {
        IsEnd = true;
        VFXData_Firework_LaunchTrail vfxData = VFXData as VFXData_Firework_LaunchTrail;
        StartCoroutine(EndCall(vfxData));
    }

    private IEnumerator EndCall(VFXData_Firework_LaunchTrail vfxData)
    {
        yield return new WaitForSeconds(vfxData.delayTime);
        vfxData.endCB?.Invoke(transform.position);
        CycleVFX();
    }

    private float timer = 0;
    private void Update()
    {
        if (!IsInit || IsEnd)
            return;

        timer += Time.deltaTime;
        if (timer > lifeTime)
        {
            EndVFX();
        }
    }

}
