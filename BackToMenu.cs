﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackToMenu : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }
}
