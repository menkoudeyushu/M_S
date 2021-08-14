using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class UIBasePanel : MonoBehaviour
    {
        private CanvasGroup canvasGroup;
        public void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = gameObject.AddComponent<CanvasGroup>();
            }
        }
        public void OnEnter()
        {

            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;

        }
        public void OnPause()
        {
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = false;
        }
        public void OnResume()
        {
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
        }
        public void OnExit()
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;

        }


        // ´ý¶¨ 
        private Button FindCloseButton(string childName)
        {
            Button closeButton = null;
            foreach (var item in GetComponentsInChildren<Button>())
            {
                if (item.name == childName)
                    closeButton = item.GetComponent<Button>();
            }
            return closeButton;
        }

    }
