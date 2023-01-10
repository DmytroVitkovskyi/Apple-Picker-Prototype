using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleDestroyed()
    {
        // Удалить все упавшие яблоки
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (var item in tAppleArray)
        {
            Destroy(item);
        }
        // Удалить одну корзину
        // Получить индекс последней корзины в basketList
        Destroy(basketList[basketList.Count - 1]);
        basketList.RemoveAt(basketList.Count - 1);

        // Если корзин не осталось, перезапустить игру
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("_Scene_Title");
            //Application.Quit();
        }
    }
    
}
