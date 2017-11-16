﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger4Button : MonoBehaviour
{
    //どんな名前でもいいのでstring型のフィールドに付ける
    [SerializeField, SceneChangerAttribute]
    string _NextScene;

    void OnClick()
    {
        SceneManager.LoadScene(_NextScene);
    }
}