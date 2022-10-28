using System.Collections;
using UnityEngine;

public class ObjectText : MonoBehaviour
{
    [SerializeField] private GameObject excMark;
    private bool isPlayerInRange;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            excMark.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            excMark.SetActive(false);
        }
    }
}
