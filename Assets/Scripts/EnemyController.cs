using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("敌人基本属性")]

    [Tooltip("敌人移动速度")]
    [SerializeField] public float speed = 3f;

    [Tooltip("是否是水平移动")]
    [SerializeField] public bool vertical = true;

    [Tooltip("多少时间后改变移动方向")]
    [SerializeField] public float timeChangeDirection = 2.0f;


    private new Rigidbody2D rigidbody2D;

    // 敌人当前方向
    private int direction = 1;
    // 改变方向计时器
    private float changeDirectionTimer;

    // Start is called before the first frame update
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        changeDirectionTimer = timeChangeDirection;
    }

    // Update is called once per frame
    private void Update()
    {
        changeDirectionTimer -= Time.deltaTime;
        if (changeDirectionTimer < 0)
        {
            direction = -direction;
            changeDirectionTimer = timeChangeDirection;
        }
    }

    private void FixedUpdate()
    {
        ChangePosition();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // collision 类型是 Collision2D，而不是 Collider2D。
        // Collision2D 没有 GetComponent 函数，但是它包含大量有关碰撞的数据，例如与敌人碰撞的游戏对象。
        // 因此，在这个游戏对象上调用 GetComponent。
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    private void ChangePosition()
    {
        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.x += speed * Time.deltaTime * direction;
        }
        else
        {
            position.y += speed * Time.deltaTime * direction;
        }

        rigidbody2D.MovePosition(position);
    }
}
