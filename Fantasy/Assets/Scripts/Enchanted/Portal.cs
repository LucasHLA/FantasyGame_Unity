using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private SceneController scene;
    [SerializeField] private string sceneName;
    [SerializeField] private GameObject fIndicator;
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

        fIndicator.transform.eulerAngles = new Vector3 (0, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canTeleport = true;
            fIndicator.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canTeleport = false;
            fIndicator.SetActive(false);
        }
    }
}
