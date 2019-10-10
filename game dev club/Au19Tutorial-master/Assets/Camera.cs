using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform myPlayer;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        Vector3 playerPosition = myPlayer.position;

        // Start simple camera movement
        //newPosition = playerPosition;
        // End simple camera movement

        // Start advanced camera movement
        float moveEdge = 4;

        if (playerPosition.x - moveEdge > newPosition.x)
            newPosition.x = playerPosition.x - moveEdge;
        else if (playerPosition.x + moveEdge < newPosition.x)
            newPosition.x = playerPosition.x + moveEdge;

        if (playerPosition.y - moveEdge > newPosition.y)
            newPosition.y = playerPosition.y - moveEdge;
        else if (playerPosition.y < newPosition.y)
            newPosition.y = playerPosition.y;
        // End advanced camera movement

        newPosition.z = -10;
        transform.position = newPosition;
    }
}
