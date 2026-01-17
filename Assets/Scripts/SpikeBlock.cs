using UnityEngine;

public class SpikeBlock : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, столкнулся ли игрок с этим блоком
        if (collision.gameObject.CompareTag("Player"))
        {
            // Уничтожаем объект игрока
            Destroy(collision.gameObject);

            // Дополнительно можно добавить логику, например, перезапуск уровня
            Debug.Log("Player has died!");
        }
    }
}