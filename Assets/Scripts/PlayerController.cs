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


    private new Rigidbody2D rigidbody2D;
    private float horizontal;
    private float vertical;
    private int currentHealth;

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

    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        if (canHorizontalMove)
        {
            position.x = position.x + speed * horizontal * Time.deltaTime;
        }
        if (canVerticalMove)
        {
            position.y = position.y + speed * vertical * Time.deltaTime;
        }
        rigidbody2D.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
