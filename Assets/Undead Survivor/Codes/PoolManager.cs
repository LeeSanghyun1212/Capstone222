using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 프리펩 보관 변수 4
    public GameObject[] prefabs;
    // 풀담당을 하는 list들이 필요 4
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
        
        for(int i=0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
        
    }
    
    public GameObject Get(int index)
    {
        // 유효한 인덱스인지 확인
        if (index >= 0 && index < pools.Length)
        {
            GameObject selectedObject = null;

            foreach (GameObject obj in pools[index])
            {
                // GameObject가 파괴되지 않았을 경우에만 사용
                if (obj != null)
                {
                    if (!obj.activeSelf)
                    {
                        selectedObject = obj;
                        selectedObject.SetActive(true);
                        
                        break;
                    }
                }
            }

            if (selectedObject == null)
            {
                // 해당 인덱스의 프리팹을 인스턴스화하여 가져오기
                selectedObject = Instantiate(prefabs[index], transform);
                pools[index].Add(selectedObject);
            }

            return selectedObject;
        }
        else
        {
            Debug.LogError("Invalid index for Get method in PoolManager.");
            
            return null;

        }
    }

}
