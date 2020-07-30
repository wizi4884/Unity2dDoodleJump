using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float forceJump; //Переменная силы прыжка

    public void OnCollisionEnter2D(Collision2D collision) //Столкновение без возврата
    {
        if (collision.relativeVelocity.y < 0) //относительная скорость плтформы от дудлика
        {
            Doodle.instance.DoodleRigid.velocity = Vector2.up * forceJump; //Вектор из скрипта дудлика умножаем на прыжок, если коснулись 
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name == "DeadZone")//Если платформа встретилась с дед зоной
        {
            float RandX = Random.Range(-1.7f, 1.7f); //задается новая позиция
            float RandY = Random.Range(transform.position.y + 20f, transform.position.y + 22f);

            transform.position = new Vector3(RandX, RandY, 0); //перемещаем объект по заданным координатам
        }
    }
}
   
