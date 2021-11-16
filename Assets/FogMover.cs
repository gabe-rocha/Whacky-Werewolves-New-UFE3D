using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogMover : MonoBehaviour
{
    [SerializeField] private GameObject fog1, fog2;
    [SerializeField] private float speed = 2f;

    private Vector3 fog1InitialPosition, fog2InitialPosition;
    private void Awake()
    {
        fog1InitialPosition = fog1.transform.position;
        fog2InitialPosition = fog2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        fog1.transform.position += Vector3.left * speed * Time.deltaTime;
        fog2.transform.position += Vector3.left * speed * Time.deltaTime;
    
        if(fog1.transform.position.x <= (fog1InitialPosition.x - fog2InitialPosition.x)){
            fog1.transform.position = fog2InitialPosition;
            fog2.transform.position = fog1InitialPosition;
        }
        if(fog2.transform.position.x <= (fog1InitialPosition.x - fog2InitialPosition.x)){
            fog2.transform.position = fog2InitialPosition;
            fog1.transform.position = fog1InitialPosition;
        }
    }
}
