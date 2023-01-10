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
        // �������� ������ �� ������� ������ ScoreCounter
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // �������� ��������� TextMesh ����� �������� �������
        scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
        // ���������� ��������� ����� ����� ������ 0
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        // �������� ������� ���������� ��������� ���� �� ������ �� Input
        Vector3 mousePos2D = Input.mousePosition;

        // ���������� Z ������ ����������, ��� ������ � ��������� ������������
        // ��������� ��������� ����
        mousePos2D.z = -Camera.main.transform.position.z;

        // ������������� ����� �� ��������� ��������� ������ � ���������
        // ���������� ����
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // ����������� ������� ����� ��� X � ���������� X ��������� ����
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    private void OnCollisionEnter(Collision collision)
    {
        // �������� ������, �������� � ��� �������
        GameObject collidedWidth = collision.gameObject;
        if (collidedWidth.tag == "Apple")
        {
            Destroy(collidedWidth);

            // ������������� ����� � scoreGT � ����� �����
            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();
            // ��������� ������ ��������
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
