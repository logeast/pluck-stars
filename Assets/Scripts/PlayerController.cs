using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("玩家基本属性")]

    [Tooltip("玩家移动速度")]
    [SerializeField] public float speed = 4f;

    [Tooltip("玩家最大生命值")]
    [SerializeField] public int maxHealth = 5;



    [Header("玩家方向属性")]

    [Tooltip("是否允许水平移动")]
    [SerializeField] public bool canHorizontalMove = true;

    [Tooltip("是否允许垂直移动")]
    [SerializeField] public bool canVerticalMove = true;


    [Header("玩家附加属性")]

    [Tooltip("玩家无敌时间")]
    [SerializeField] public float timeTnvincible = 2.0f;


    [Tooltip("导弹对象")]
    [SerializeField] public GameObject projectilePrefab;

    // 使用 rigidbody2D 获取角色属性
    private new Rigidbody2D rigidbody2D;

    // 水平、垂直位置
    private float horizontal;
    private float vertical;

    // 当前生命值
    private int currentHealth;

    // 是否无敌状态
    private bool isInvincible;
    // 无敌计时器
    private float invincibleTimer;

    // 目视方向
    private Vector2 lookDirection = new Vector2(1, 0);

    // 生命值，只读，给外部调用
    public int health { get { return currentHealth; } }


    // Start is called before the first frame update
    void Start()
    {
        // 不要使用 transform，而是使用 Rigidbody2D 避免碰撞抖动问题
        // https://learn.u3d.cn/tutorial/unity-ruby-adventure?chapterId=63562b27edca72001f21d0af#61f106c2c456840020d951f4
        rigidbody2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }

        // 发射飞弹
        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }
    }

    private void FixedUpdate()
    {
        ChangePosition();
    }

    /// <summary>
    /// 改变玩家位置
    /// </summary>
    private void ChangePosition()
    {
        Vector2 position = rigidbody2D.position;
        if (canHorizontalMove)
        {
            position.x += speed * horizontal * Time.deltaTime;
        }
        if (canVerticalMove)
        {
            position.y += speed * vertical * Time.deltaTime;
        }
        rigidbody2D.MovePosition(position);
    }

    /// <summary>
    /// 更新玩家生命值
    /// </summary>
    /// <param name="amount"></param>
    public void ChangeHealth(int amount)
    {
        // 生命值减少前判断是否时无敌状态
        if (amount < 0)
        {
            if (isInvincible)
            {
                return;
            }
            isInvincible = true;
            invincibleTimer = timeTnvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }

    public void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2D.position + Vector2.up * 0.5f, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);
    }

}
