using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


namespace CUI.Actions {
    public class CuiScaleActionOld : CUIActionOLD {
        
        [SerializeField] private RectTransform targetRect;

        [Header("Settings")] [SerializeField]
        private bool useGlobalAnimTime = true;

        
        
        [SerializeField] private float animTime = 0.3f;


        [SerializeField] private float triggeredScale = 1.05f;

        [SerializeField] private float untriggeredScale = 1f;
        
        
        


        private void Awake() {
            if (!targetRect) targetRect = GetComponent<RectTransform>();
        }

        private void Reset() {
            if (!targetRect) targetRect = GetComponent<RectTransform>();
        }


        public override bool Trigger(bool instant = false) {
            if (!base.Trigger()) return false;

            if (targetRect) {
                Tweener tween;

                if (instant) tween = targetRect.DOScale(triggeredScale, 0f);
                else tween = targetRect.DOScale(triggeredScale, animTime).SetEase(easing);
                
                AddActiveTween(tween);
            }

            return true;
        }

        public override bool Untrigger(bool instant = false) {
            if (!base.Untrigger()) return false;

            if (targetRect) {
                Tweener tween;
                
                if (instant) tween = targetRect.DOScale(untriggeredScale, 0f);
                else tween = targetRect.DOScale(untriggeredScale, animTime).SetEase(easing);

                AddActiveTween(tween);
            }

           
            return true;
        }
    }
}