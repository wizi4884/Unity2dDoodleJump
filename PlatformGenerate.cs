using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerate : MonoBehaviour
{
    public GameObject platformPrefab;//Переменная для префаба
   
    void Start()
    {
        Vector3 SpawnerPosition = new Vector3(); //Создаем новый вектор

        for (int i = 0; i < 10; i++)//проходим 10 раз
        {
            SpawnerPosition.x = Random.Range(-1.7f, 1.7f);//по х
            SpawnerPosition.y += Random.Range(2f, 4f);//по у

            Instantiate(platformPrefab, SpawnerPosition, Quaternion.identity);//Создаем новые платформы
        }

    }

}