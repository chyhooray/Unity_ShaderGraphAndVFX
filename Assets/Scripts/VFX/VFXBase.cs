using System.Threading.Tasks;
using UnityEngine;
using System;
using System.Collections;

public abstract class VFXBase : MonoBehaviour
{
    public VFXDataBase VFXData { get; protected set; }

    public bool IsInit { get; protected set; } = false;
    public bool IsEnd { get; protected set; } = false;

    /// <summary>
    /// 初始化，只会在创建时调用一次
    /// </summary>
    public virtual void InitVFX()
    {
        IsInit = true;
    }

    /// <summary>
    /// 设置信息，每次重置时调用
    /// </summary>
    /// <param name="vfxData"></param>
    public virtual void SetVFX(VFXDataBase vfxData)
    {
        this.VFXData = vfxData;
    }

    public virtual void StartVFX()
    { }

    public virtual void EndVFX()
    { }

    protected void CycleVFX()
    {
        Destroy(gameObject);
    }

    protected void OnDestroy()
    {
        StopAllCoroutines();
    }

}
