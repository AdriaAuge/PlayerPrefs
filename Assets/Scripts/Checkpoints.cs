using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoints : MonoBehaviour
{
    private float CheckPointX;
    private float CheckPointY;
    private float CheckPointZ;

    public GameObject player;
    public Vector3 respawn;
    private Vector3 playerRespawn;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Start()
    {
        float respawnX = PlayerPrefs.GetFloat("CheckPointX", 0);
        float respawnY = PlayerPrefs.GetFloat("CheckPointY", 0);
        float respawnZ = PlayerPrefs.GetFloat("CheckPointZ", 0);

        playerRespawn = new Vector3(respawnX, respawnY, respawnZ);

        player.transform.position = new Vector3(playerRespawn.x, playerRespawn.y, playerRespawn.z);
    }

    private void OnTriggerEnter(Collider checkPoint)
    {
        if (checkPoint.gameObject.tag == "Player")
        {
            playerRespawn = new Vector3(respawn.x, respawn.y, respawn.z);
            Debug.Log(playerRespawn);

            PlayerPrefs.SetFloat("CheckPointX", respawn.x);
            PlayerPrefs.SetFloat("CheckPointY", respawn.y);
            PlayerPrefs.SetFloat("CheckPointZ", respawn.z);
        }
    }
}
