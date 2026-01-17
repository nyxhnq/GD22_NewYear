
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 1;
    [SerializeField] UIManager uiManager;

    public void DecreaseHealth()
    {
        health--; //health = health - 1;
        //Обновить UI здесь, если нужно
        if (health <= 0)
        {
            uiManager.ShowGameOverScreen();
        }
    }
}