using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate;
    public float minHeight;
    public float maxHeight;
    private PlayerController _playerController;
    
    // Start is  called before the first frame update
    public void StartGame()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _playerController = player.GetComponent<PlayerController>();
        StartCoroutine(CreatePipe());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator CreatePipe()
    {
        while (_playerController.isGameOver == false)
        {
            yield return new WaitForSeconds(spawnRate);
            if (_playerController.isGameOver == true) break;

            float randomHeight = Random.Range(minHeight, maxHeight);
            Vector3 spawnPosition = new Vector3(8, randomHeight, 0);
            Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
        }


    }
}
