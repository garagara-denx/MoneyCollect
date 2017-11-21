﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    PlayerWeaponModel playerWeaponModel;
    private float elapsedTime;

    private void Start()
    {
        playerWeaponModel = GetComponent<PlayerWeaponModel>();
        elapsedTime = 0f;
    }

    private void FixedUpdate()
    {
        // 攻撃処理
        if (Input.GetKey(KeyCode.Z))
        {
            ShotBullet(playerWeaponModel.AttackInterval,
                playerWeaponModel.BulletPrefab,
                playerWeaponModel.BulletPower,
                gameObject.tag,
                playerWeaponModel.BulletSpeed);
        }
        else
        {
            elapsedTime = 0f;
        }
    }

    private void ShotBullet(float attackInterval, GameObject bulletPrefab, float bulletPower, string myTagName, float bulletSpeed)
    {
        elapsedTime -= Time.fixedDeltaTime;
        if (elapsedTime <= 0.0f)
        {
            elapsedTime = attackInterval;

            // bulletを生成
            var bulletPos = new Vector3(transform.position.x, transform.position.y + transform.localScale.y, transform.position.z);
            var bulletRota = bulletPrefab.transform.rotation;
            GameObject bullet = Instantiate(bulletPrefab, bulletPos, bulletRota);

            // bulletのstatusを設定
            var model = bullet.GetComponent<BulletStatusModel>();
            model.BulletPower = bulletPower;
            model.ShootOwnerTagName = myTagName;

            // 射出
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity += Vector2.up * bulletSpeed;
        }
    }
}