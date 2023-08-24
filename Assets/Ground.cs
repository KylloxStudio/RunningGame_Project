using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float scrollAmount;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Vector3 moveDir;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDir * Time.deltaTime * moveSpeed);

        if (transform.position.x <= -scrollAmount)
        {
            transform.position = target.position - moveDir * scrollAmount;
        }
    }
}
