using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // 인스펙터에서 카테고리를 넣는 효과
    [Header("# Game Control")]
    public bool isLive;
    public float gameTime;
    public float maxGameTime = 2 * 10f;
    [Header("# Player Info")]
    public int health;
    public int maxHealth = 100;
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 3, 5, 10, 100, 150, 210, 280, 360, 450, 600 };
    [Header("# Game Object")]
    public Player player;
    public PoolManager pool;
    public LevelUp uiLevelUp;

    void Awake()
    {
        instance = this;    
    }

    void Start()
    {
        health = maxHealth;
        // 임시 스크립트 (임시 무기 생성)
        uiLevelUp.Select(0);
    }

    private void Update()
    {
        if (!isLive)
        {
            return;
        }

        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }

    public void GetExp()
    {
        exp++;
        
        if (exp == nextExp[Mathf.Min(level, nextExp.Length - 1)])
        {
            uiLevelUp.Show();
            level++;
            exp = 0;
        }
    }

    public void Stop()
    {
        isLive = false;
        // 유니티 시간 배율
        // 모바일 게임 빠른 전투 같은 경우 해당 수치를 올리는 것.
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1;
    }
}
