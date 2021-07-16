using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFallow : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private Rigidbody rb;
    private bool isPlayerInRange= false;
    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Player is in the scope");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("Player is out of the scope");
        }
    }
    private void FixedUpdate()
    {
        if(isPlayerInRange)
        {
            Vector3 targetDirection = player.transform.position - transform.position;
            rb.AddForce(targetDirection * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

            Vector3 newVelocity = rb.velocity;
            newVelocity.y = 0;
            rb.velocity = newVelocity;
        }
    }
}
