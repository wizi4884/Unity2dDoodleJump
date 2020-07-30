using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform doodlesPos; //Позиция дудлика

    void Update()
    {
        if (doodlesPos.position.y > transform.position.y)// если позиция дудлика больше позициии камеры
        {
            // то позиция камеры приравнивается к позиции дудлика
            transform.position = new Vector3(transform.position.x, doodlesPos.position.y, transform.position.z);
        }
        
    }
}
