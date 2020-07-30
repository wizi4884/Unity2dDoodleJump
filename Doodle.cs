using System.Collections; //Содержить неуверсальные классы
using System.Collections.Generic; //Содержить универсальные классы для безопасности типов и производительность.
using System.Runtime.Hosting; //Содержит расширенные типы, которые используются при активации приложений в доменах приложений.
using System.Security.Policy;//Пространство имен System.Security.Policy содержит группы кода, условия членства и свидетельство.
using UnityEngine;//Добавляем доступ на UnityEngine библиотеку. Это набор различных классов/функций от Юнити3Д.
using UnityEngine.SceneManagement;//Работа со сценами

public class Doodle : MonoBehaviour //Скрипт взаимодействует с внутренними механизмами Unity за счет создания класса, наследованного от встроенного класса, называемого MonoBehaviour.
{
    public static Doodle instance; //Для использование переменных и в других скриптах

    float horizontal;//Переменная для акселерометра
    public Rigidbody2D DoodleRigid;//Переменная от движка RB
    
    void Start() //Функция выполняется только при старте один раз.
    {
        if (instance == null) //Для реализации переменных в других скриптах.
        {
            instance = this;
        }
        
    }

    // Update is called once per frame
    void FixedUpdate() //Функция для расчета движка
    {
        if (Application.platform == RuntimePlatform.Android)
            //Application Доступ к данным во времени выполнения приложения, platform содержит путь к папке игровых данных
            //После == подклюсения нужной платформы
        {
            horizontal = Input.acceleration.x;
            //Переменной горизонтале присваивается значение x по acceleration
        }

        if (Input.acceleration.x < 0) //Если х меньше нуля то спрайт не переворачивается
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            //gameObject базовый класс для всех сущностей в unity scenes
            //Использование gameObject.GetComponent вернет первый найденный компонент, а порядок не определен
            //flipX переыворачивает спрайт
        }

        if (Input.acceleration.x > 0)//Теперь переворачивает 
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        DoodleRigid.velocity = new Vector2(Input.acceleration.x * 10f, DoodleRigid.velocity.y);
        //Rigidbody.velocity вектор скорости твердого тела
        //Создается новый вектор, который берется из показаний acceleration и умножается на 10f, по y мы устанавливаем сами

    }

    public void OnCollisionEnter2D(Collision2D collision)//Отправляется, когда входящий коллайдер вступает в контакт с коллайдером этого объекта(только для 2D физики).
    {
        if (collision.collider.name == "DeadZone") //Если колайдер косается с дедзоной
        {
            SceneManager.LoadScene(0);//то сцена загружается заново
        }
    }
}
