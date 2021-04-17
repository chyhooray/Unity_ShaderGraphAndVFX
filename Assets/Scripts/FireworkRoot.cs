using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkRoot : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ShowFirework());
    }

    private IEnumerator ShowFirework()
    {
        yield return new WaitForSeconds(1);

        //黄色烟花
        for (int i = 0; i < 10; i++)
        {
            FireworkSystem.Instance.ShowVFX(new VFXData_Firework_LaunchTrail(0.3f, (localPos) =>
            {
                FireworkSystem.Instance.ShowVFX(new VFXDataBase(MyConstant.VFX_Firework_ExpolsionYellow), null, localPos);
            }), null, FireworkSystem.Instance.GetRandomOriginalPos());
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.3f, 0.8f));
        }

        //彩色烟花
        for (int i = 0; i < 10; i++)
        {
            FireworkSystem.Instance.ShowVFX(new VFXData_Firework_LaunchTrail(0.3f, (localPos) =>
            {
                FireworkSystem.Instance.ShowVFX(new VFXDataBase(MyConstant.VFX_Firework_ExpolsionColorful), null, localPos);
            }), null, FireworkSystem.Instance.GetRandomOriginalPos());
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.3f, 0.8f));
        }
        yield return new WaitForSeconds(5);

        //双层圆圈烟花
        for (int i = 0; i < 10; i++)
        {
            FireworkSystem.Instance.ShowVFX(new VFXData_Firework_LaunchTrail(0.3f, (localPos) =>
            {
                FireworkSystem.Instance.ShowVFX(new VFXDataBase(MyConstant.VFX_Firework_ExplosionDoubleCircle), null, localPos);
            }), null, FireworkSystem.Instance.GetRandomOriginalPos());
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.3f, 0.8f));
        }
        yield return new WaitForSeconds(5);

        //圆圈+拖尾烟花
        for (int i = 0; i < 16; i++)
        {
            FireworkSystem.Instance.ShowVFX(new VFXData_Firework_LaunchTrail(0.3f, (localPos) =>
            {
                FireworkSystem.Instance.ShowVFX(new VFXDataBase(MyConstant.VFX_Firework_ExplosionWithCircleTrail), null, localPos);
            }), null, FireworkSystem.Instance.GetRandomOriginalPos());
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.3f, 0.8f));
        }
        yield return new WaitForSeconds(5);


        //爆炸拖尾烟花
        for (int i = 0; i < 16; i++)
        {
            FireworkSystem.Instance.ShowVFX(new VFXData_Firework_LaunchTrail(0.3f, (localPos) =>
            {
                FireworkSystem.Instance.ShowVFX(new VFXDataBase(MyConstant.VFX_Firework_ExplosionWithTrail), null, localPos);
            }), null, FireworkSystem.Instance.GetRandomOriginalPos());
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.3f, 0.8f));
        }
        yield return new WaitForSeconds(5);

        //笑脸烟花
        for (int i = 0; i < 1; i++)
        {
            FireworkSystem.Instance.ShowVFX(new VFXData_Firework_Smile(), transform, Vector3.zero);
            yield return new WaitForSeconds(1);
        }
        yield return new WaitForSeconds(3);


    }
}
