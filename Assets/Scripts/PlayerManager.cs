using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] players;
    public GameObject currentPlayer;

    [HideInInspector]
    public Animator playerAnima;

    private int playerIndex = 0;
    public static bool gameWon;
    float lookAngle = 0;

    public float moveSpeed;

    public AudioClip deathSound;

    public GameObject uiManager;





    void Start()
    {
        currentPlayer = players[playerIndex]; //CurrentPlayer gameObjectini players dizisinden playerindex indexli obje olarak ayarla
    }

    void Update()
    {
        CheckWin();
        CheckLose();
        SetWalkAnimations();

        if (Input.GetKeyDown(KeyCode.Tab))
            SwitchPlayer();

        if (Input.GetKeyDown(KeyCode.F) && currentPlayer.GetComponent<Player>().isPressible)
        {
            currentPlayer.GetComponent<Player>().interactedObject.GetComponent<Button>().OnButtonPressed();
        }

        if (Input.GetKeyDown(KeyCode.X) && currentPlayer.GetComponent<Player>().isMountable)
        {
            currentPlayer.GetComponent<Rigidbody>().velocity = Vector3.zero;
            currentPlayer.GetComponent<Player>().cantMove = true;

        }

        if (Input.GetKeyDown(KeyCode.C) && currentPlayer.GetComponent<Player>().cantMove)
        {
            currentPlayer.GetComponent<Player>().cantMove = false;
        }

    }

    private void FixedUpdate()
    {
        Move();
    }

    void SwitchPlayer()
    {
        playerIndex = (playerIndex < 3 ? playerIndex + 1 : 0); //Eğer playerIndex 4'den küçükse playerIndex'i (index + 1) olarak ayarla. Değilse 0 olarak ayarla
        currentPlayer = players[playerIndex];

        //Işığı değiştir
        foreach (GameObject item in players)
        {
            item.GetComponentInChildren<Light>().enabled = false;
        }

        currentPlayer.GetComponentInChildren<Light>().enabled = true;
        //--------------
    }

    void CheckWin()
    {
        if (players[0].GetComponent<Player>().inFinishCollider == true &&
            players[1].GetComponent<Player>().inFinishCollider == true &&
            players[2].GetComponent<Player>().inFinishCollider == true &&
            players[3].GetComponent<Player>().inFinishCollider == true)
        {
            gameWon = true;
        }

        else
            gameWon = false;

        if (gameWon)
        {
            uiManager.GetComponent<InGameUiManager>().VictoryScreen();
        }
    }

    void CheckLose()
    {
        foreach (var player in players)
        {
            if (player.GetComponent<Player>().isKilled == true)
            {
                Debug.Log("Karakterlerinden bir öldü");
                gameObject.GetComponent<AudioSource>().clip = deathSound;
                gameObject.GetComponent<AudioSource>().Play();
                player.GetComponent<Player>().cantMove = true;
                Die();
            }
        }
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void SetWalkAnimations()
    {
        playerAnima = currentPlayer.GetComponent<Animator>();

        if (currentPlayer.GetComponent<Rigidbody>().velocity != Vector3.zero)
        {
            playerAnima.SetBool("isWalking", true);

            if (Input.GetKeyDown(KeyCode.Tab))
                playerAnima.SetBool("isWalking", false);
        }

        else
            playerAnima.SetBool("isWalking", false);

        if (Input.GetKeyDown(KeyCode.F))
        {
            playerAnima.SetTrigger("interact");
        }
    }

    void Move()
    {
        if (!currentPlayer.GetComponent<Player>().cantMove)
        {
            Vector3 MoveAxis = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            currentPlayer.GetComponent<Rigidbody>().velocity = MoveAxis * Time.deltaTime * moveSpeed;


            if (MoveAxis.x > 0 && MoveAxis.z > 0)
                lookAngle = 45;

            else if (MoveAxis.x < 0 && MoveAxis.z < 0)
                lookAngle = -135;

            else if (MoveAxis.x < 0 && MoveAxis.z > 0)
                lookAngle = -45;

            else if (MoveAxis.x > 0 && MoveAxis.z < 0)
                lookAngle = 135;

            else if (MoveAxis.x < 0)
                lookAngle = -90;

            else if (MoveAxis.x > 0)
                lookAngle = 90;

            else if (MoveAxis.z < 0)
                lookAngle = 180;

            else if (MoveAxis.z > 0)
                lookAngle = 0;

            currentPlayer.transform.rotation = Quaternion.Lerp(currentPlayer.transform.rotation, Quaternion.Euler(new Vector3(0, lookAngle, 0)), 10 * Time.deltaTime);
        }
    }


}
