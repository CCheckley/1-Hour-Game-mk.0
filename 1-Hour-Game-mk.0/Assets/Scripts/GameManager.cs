using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void ResetLevel(PlayerController2D player)
    {
        player.transform.position = Vector3.zero;
    }
}
