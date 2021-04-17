using System.Collections.Generic;
using UnityEngine;
using System;

public class FireworkSystem
{
    public static FireworkSystem Instance { get; } = new FireworkSystem();

    private int minWorldPosX = -15;
    private int maxWorldPosX = 15;
    private int maxCount = 4;
    private static List<int> LastLaunchWorldPosList = new List<int>();


    public void ShowVFX(VFXDataBase vfxData, Transform parent, Vector3 localPos, bool startNow = true, Action<VFXBase> cb = null)
    {
        ShowVFX(vfxData, parent, localPos, Quaternion.identity, Vector3.one, startNow, cb);
    }

    public void ShowVFX(VFXDataBase vfxData, Transform parent, Vector3 localPos, Quaternion localRotation, Vector3 localScale, bool startNow = true, Action<VFXBase> cb = null)
    {
        GameObject prefab = Resources.Load<GameObject>(vfxData.PrefabKey);
        GameObject gO = GameObject.Instantiate(prefab, parent);
        gO.transform.localPosition = localPos;
        gO.transform.localRotation = localRotation;
        gO.transform.localScale = localScale;
        gO.SetActive(true);
        VFXBase vfx = gO.GetComponent<VFXBase>();
        if (vfx == null)
        {
            Debug.LogError("Faild to get vfx script! VfxKey:" + vfxData.PrefabKey);
        }
        else
        {
            if (!vfx.IsInit)
                vfx.InitVFX();
            vfx.SetVFX(vfxData);
            if (startNow)
                vfx.StartVFX();
            cb?.Invoke(vfx);
        }
    }

    public Vector3 GetRandomOriginalPos()
    {
        List<int> canUseList = new List<int>();
        if (LastLaunchWorldPosList.Count >= maxCount)
        {
            LastLaunchWorldPosList.RemoveAt(0);
        }

        for (int i = minWorldPosX; i <= maxWorldPosX; i++)
        {
            if (i % 5 != 0)
                continue;

            bool canUse = true;
            for (int j = 0; j < LastLaunchWorldPosList.Count; j++)
            {
                if (LastLaunchWorldPosList[j] == i)
                {
                    canUse = false;
                    break;
                }
            }
            if (canUse)
            {
                canUseList.Add(i);
            }
        }

        float posX;
        if (canUseList.Count > 0)
        {
            int index = canUseList.Count;
            int x = UnityEngine.Random.Range(0, index);
            LastLaunchWorldPosList.Add(canUseList[x]);
            posX = canUseList[x] + UnityEngine.Random.Range(-0.5f, 0.5f);
        }
        else
        {
            posX = 0;
            Debug.LogWarning("can use List count is zeor");
        }
        return new Vector3(posX, 0, 0);
    }


}

