using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepidBacGraund : MonoBehaviour
{
    private float _center;
    private Vector3 _startPosition;
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        _center = boxCollider2D.bounds.extents.x;
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < _startPosition.x - _center)
        {
            transform.position = _startPosition;
        }
    }
}
