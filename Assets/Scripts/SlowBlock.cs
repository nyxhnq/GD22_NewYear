//using UnityEngine;

//public class SlowBlock : MonoBehaviour
//{
//    [SerializeField] private float multiplier = 0.5f; 
//    private float originalSpeed;
//    private bool isSlowed;

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (!collision.gameObject.CompareTag("Player")) return;
//        if (collision.contacts == null || collision.contacts.Length == 0) return;
//        if (collision.contacts[0].normal.y <= 0.5f) return; // только при наступании сверху

//        var pc = collision.gameObject.GetComponent<Penguincontroller>();
//        if (pc == null || isSlowed) return;

//        originalSpeed = pc.moveSpeed;
//        pc.moveSpeed = originalSpeed * multiplier;
//        isSlowed = true;
//    }

//    private void OnCollisionExit2D(Collision2D collision)
//    {
//        if (!collision.gameObject.CompareTag("Player")) return;

//        var pc = collision.gameObject.GetComponent<Penguincontroller>();
//        if (pc == null || !isSlowed) return;

//        pc.moveSpeed = originalSpeed;
//        isSlowed = false;
//    }
//}