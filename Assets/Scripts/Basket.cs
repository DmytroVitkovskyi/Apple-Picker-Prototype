using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public TextMeshProUGUI scoreGT;
    // Start is called before the first frame update
    void Start()
    {
        // Получить ссылку на игровой объект ScoreCounter
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Получить компонент TextMesh этого игрового объекта
        scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
        // Установить начальное число очков равным 0
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        // Получить текущие координаты указателя мыши на экране из Input
        Vector3 mousePos2D = Input.mousePosition;

        // Координата Z камеры определяет, как далеко в трёхмерном пространстве
        // находится указатель мыши
        mousePos2D.z = -Camera.main.transform.position.z;

        // Преобразовать точку на двумерной плоскости экрана в трёхмерные
        // координаты игры
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Переместить корзину вдоль оси X в координату X указателя мыши
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Отыскать яблоко, попавшее в эту корзину
        GameObject collidedWidth = collision.gameObject;
        if (collidedWidth.tag == "Apple")
        {
            Destroy(collidedWidth);

            // Преобразовать текст в scoreGT в целое число
            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();
            // Запомнить высшее значение
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
