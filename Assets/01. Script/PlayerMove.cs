using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float playerMoveSpeed;

    public Vector3 playerPositon;
    public Rigidbody rb;

    void Start()
    {
        playerPositon = Vector3.zero;
        playerMoveSpeed = 3.5f;

        StartCoroutine(PlayerRun());
        StartCoroutine(CPlayerMove());
    }

    void Update()
    {
        transform.position = playerPositon;
    }

    public IEnumerator CPlayerMove()
    {
        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();

        while (true)
        {
            if (Input.GetKey(KeyCode.A)) //왼쪽
            {
                playerPositon += new Vector3(-1f, 0, 0) * Time.deltaTime * playerMoveSpeed;
            }

            if (Input.GetKey(KeyCode.D)) //오른쪽
            {
                playerPositon += new Vector3(1f, 0, 0) * Time.deltaTime * playerMoveSpeed;
            }

            if (Input.GetKey(KeyCode.W)) //위
            {
                playerPositon += new Vector3(0, 0, 1f) * Time.deltaTime * playerMoveSpeed;
            }

            if (Input.GetKey(KeyCode.S)) // 아래
            {
                playerPositon += new Vector3(0, 0, -1f) * Time.deltaTime * playerMoveSpeed;
            }

            yield return waitForEndOfFrame;
        }
    }

    public IEnumerator PlayerRun()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.5f);

        while (true)
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                playerMoveSpeed = Mathf.Lerp(playerMoveSpeed, 5f, 0.5f);
            }
            else
            {
                playerMoveSpeed = Mathf.Lerp(playerMoveSpeed, 3.5f, 0.5f);
            }

            yield return waitForSeconds;
        }
    }
}
