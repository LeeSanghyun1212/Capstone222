using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // ������ ���� ���� 4
    public GameObject[] prefabs;
    // Ǯ����� �ϴ� list���� �ʿ� 4
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
        // ��ȿ�� �ε������� Ȯ��
        if (index >= 0 && index < pools.Length)
        {
            GameObject selectedObject = null;

            foreach (GameObject obj in pools[index])
            {
                // GameObject�� �ı����� �ʾ��� ��쿡�� ���
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
                // �ش� �ε����� �������� �ν��Ͻ�ȭ�Ͽ� ��������
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
