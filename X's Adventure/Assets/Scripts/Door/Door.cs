using UnityEngine;

public class Door : MonoBehaviour
{
    public GameManager gameManager;
    public Animator anim;
    public GameNavigations gameNavigations;
    public LevelStats levelStat;

    MyPrefs myPrefs;

    private void Awake()
    {
        myPrefs = FindObjectOfType<MyPrefs>();
    }

    private void Update()
    {
        if (gameManager.levelCompleted)
        {
            anim.SetBool("isOpened", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && gameManager.levelCompleted)
        {
            int level = levelStat.level + 1;
            myPrefs.SetLevel(level, true);
        }
    }
}
