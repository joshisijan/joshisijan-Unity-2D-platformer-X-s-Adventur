﻿using System;
using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public EnemyStats enemyStats;
    public GameManager gameManager;
    public AudioManager audioManager;
    public EnemyMovement enemyMovement;
    public GameObject bullet;
    public Transform hitPoint;

    [NonSerialized]
    public bool isDead = false;
    float reloadTime;
    bool canFire = true;
    bool onReload = false;

    private void Awake()
    {
        reloadTime = enemyStats.reloadingTime;
    }

    private void Update()
    {
        if (gameManager.playerDead) return;
        if (enemyMovement.isAttacking && !isDead)
        {
            if (canFire)
            {
                Fire();
                canFire = false;
            }
            if (!onReload && !canFire)
            {
                StartCoroutine("Reload");
            }
            onReload = true;
        }
    }

    void Fire()
    {
        audioManager.Play("EnemyFire");
        Instantiate(bullet, hitPoint.transform.position, hitPoint.rotation);
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        canFire = true;
        onReload = false;
    }
}