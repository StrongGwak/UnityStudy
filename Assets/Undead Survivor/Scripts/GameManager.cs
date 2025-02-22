using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // �ν����Ϳ��� ī�װ��� �ִ� ȿ��
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
        // �ӽ� ��ũ��Ʈ (�ӽ� ���� ����)
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
        // ����Ƽ �ð� ����
        // ����� ���� ���� ���� ���� ��� �ش� ��ġ�� �ø��� ��.
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1;
    }
}
