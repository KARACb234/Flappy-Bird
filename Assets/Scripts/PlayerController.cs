using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float tabbForce;
    public float minRotationZ;
    public float maxRotationZ;
    public float rotationSpeed;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;
    public float minBorder;
    public float maxBorder;
    public bool isGameOver;
    private Collider2D _birdCollider;
    private GameManager _gameManager;
    public bool isIdle;
    public float idleTime;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _minRotation = Quaternion.Euler(0, 0, minRotationZ);
        _maxRotation = Quaternion.Euler(0, 0, maxRotationZ);
        _birdCollider = GetComponent<Collider2D>();
        GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        _gameManager = gameManagerObject.GetComponent<GameManager>();
        StartCoroutine(IdelAnimation());
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && isGameOver == false)
        {
            Jump();
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, rotationSpeed * Time.deltaTime);
        if (isGameOver == false)
        {
            if (transform.position.y < minBorder)
            {
                transform.position = new Vector3(transform.position.x, minBorder, transform.position.z);
                _rigidbody.velocity = Vector2.zero;
            }

            if (transform.position.y > maxBorder)
            {
                transform.position = new Vector3(transform.position.x, maxBorder, transform.position.z);
                _rigidbody.velocity = Vector2.zero;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            isGameOver = true;
            _gameManager.GameOver();
            _birdCollider.enabled = false;
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(Vector2.up * 350, ForceMode2D.Force);
            transform.rotation = _maxRotation;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Senser"))
        {
            _gameManager.AddScore();
        }
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * tabbForce, ForceMode2D.Force);
        transform.rotation = _maxRotation;
    }

    public IEnumerator IdelAnimation()
    {
        while (isIdle == true)
        {
            Jump();
            yield return new WaitForSeconds(idleTime);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

}
