﻿using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextScene: MonoBehaviour {


public void NextScene (string lvl) {

        UnityEngine.SceneManagement.SceneManager.LoadScene(lvl);
}

}