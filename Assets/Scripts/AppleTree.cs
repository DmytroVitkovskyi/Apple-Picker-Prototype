using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePrefab; // Шаблон для создания яблок
    public float speed = 1f; // Скорость движения яблони
    public float leftAndRightEdge = 10f; // Расстояние, на котором должно изменяться направление движения яблони
    public float chanceToChangeDirections = 0.1f; // Вероятность случайного изменения напрвления движения
    public float secondsBetweenAppleDrops = 1f; // Частота создания экземпляров яблок

    // Start is called before the first frame update
    void Start()
    {
        // Сбросывать яблоки раз в секунду
        Invoke("DropApple", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        // Простое перемещение
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Изменение направления
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // Начать движение вправо
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // Начать движение влево
        }        
    }
    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1; // Смена направления
        }
    }
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }
}
