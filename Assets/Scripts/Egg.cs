using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] GameObject player;

    void HideEggShowPlayer()
    {
        AudioManager.instance.PlayCrackEggClip();
        gameObject.SetActive(false);
        player.SetActive(true);
    }
}
