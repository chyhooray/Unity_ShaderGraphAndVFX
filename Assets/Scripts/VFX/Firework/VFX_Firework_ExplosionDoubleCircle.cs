using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX_Firework_ExplosionDoubleCircle : VFXBase_Firework
{
    private float trailLifeTime = 2;
    private float explosionDelayTime = 0.3f;


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
