using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed;

    private bool can_move = true;

    private bool is_shooting = false;

    [SerializeField] private Animator animator;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private Transform spawnPosition;

    // Start is called before the first frame update


    void Start()
    {
        Debug.Log(can_move);
    }

    // Обновление позиции персонажа
    void Update()
    {
        // Получение направления движения от клавиатуры
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Создание вектора движения
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        if (Input.GetMouseButtonDown(0) && !is_shooting)
        {
            if (!is_shooting)
            {
                is_shooting = true;
                animator.SetBool("is_shooting", true);
                Instantiate(bulletPrefab, spawnPosition, );
                StartCoroutine(ShootTime());
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
        }

        if (movement.magnitude > 0f && can_move)
        {
            animator.SetBool("horizontal_move", true);
            movement.Normalize();
            transform.position += new Vector3(movement.x * speed * Time.deltaTime, movement.y * speed * Time.deltaTime, 0f);

            if (horizontalInput < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (horizontalInput > 0)
            {
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            animator.SetBool("horizontal_move", false);
        }

    }

    IEnumerator ShootTime()
    {
        can_move = false;
        Debug.Log(can_move);
        for (float i = 0; i < 0.44f; i += Time.deltaTime)
        {
            yield return null;
        }
        can_move = true;
        is_shooting = false;
        animator.SetBool("is_shooting", false);
        Debug.Log(can_move);
    }
}
