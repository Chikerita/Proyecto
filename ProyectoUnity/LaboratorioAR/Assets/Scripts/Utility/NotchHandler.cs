using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotchHandler : MonoBehaviour {

    enum resScreen {PORTRAIT = 0, LANDSCAPE = 1};

    resScreen resolu;
    RectTransform panel;
    // Start is called before the first frame update
    IEnumerator Start() {
        panel = GetComponent<RectTransform>();
        yield return new WaitForSecondsRealtime(0.3f);
        DefineResponsive();
    }

    void DefineResponsive() {
        int totalC = Screen.cutouts.Length;
        if (totalC > 0) {
            Vector2 anchorMin;
            Vector2 anchorMax;
            Rect[] rc = Screen.cutouts;
            if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight) {
                resolu = resScreen.LANDSCAPE;
            } else if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown) {
                resolu = resScreen.PORTRAIT;
            }

            for (int i = 0; i < totalC; i++) {
                anchorMin = rc[i].position;
                anchorMax = rc[i].position + rc[i].size;
                anchorMin.x /= Screen.width;
                anchorMin.y /= Screen.height;
                anchorMax.x /= Screen.width;
                anchorMax.y /= Screen.height;

                if (resolu == resScreen.PORTRAIT) {
                    if (i == 0){
                        anchorMin.x = panel.anchorMax.x;
                        panel.anchorMax = anchorMin;
                    } else if (i == 1) {
                        anchorMax.x = panel.anchorMin.x;
                        panel.anchorMin = anchorMax;
                    }
                } else if (resolu == resScreen.LANDSCAPE) {
                    if (i == 0){
                        anchorMax.y = panel.anchorMin.y;
                        panel.anchorMin = anchorMax;
                    } else if (i == 1) {
                        anchorMin.y = panel.anchorMax.y;
                        panel.anchorMax = anchorMin;
                    }
                }
            }
        }
    }

}
