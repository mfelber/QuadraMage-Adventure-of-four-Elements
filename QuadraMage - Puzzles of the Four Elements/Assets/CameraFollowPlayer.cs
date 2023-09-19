using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{

    public float followSpeed = 2f;
    public Transform Player;

    

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(Player.position.x, Player.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}
