using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    public float xBorder;
    private PlayerController _playerController;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < xBorder)
        {
            Destroy(gameObject);
        }
        if (_playerController.isGameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
}
