﻿using UnityEngine;

public static class ExtentionMethod {
    public static void SetActiveRecursivelyExt(this GameObject obj, bool state) {
        obj.SetActive(state);
        foreach (Transform child in obj.transform){
            SetActiveRecursivelyExt(child.gameObject, state);
        }
    }
}