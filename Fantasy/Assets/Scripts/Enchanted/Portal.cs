using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private SceneController scene;
    [SerializeField] private string sceneName;
    private bool canTeleport;

    private Collider2D col;
    private void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (canTeleport)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                scene.SceneLoader(sceneName);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canTeleport = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canTeleport = false;
        }
    }
}
