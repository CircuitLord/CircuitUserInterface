using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


namespace CUI.Actions {
    public class CUIFadeInAction : CUIAction {

        [SerializeField] private bool autoFetchTargetGraphic = true;
        
        [SerializeField] private Graphic targetGraphic;

        [Header("Fade Settings")] [SerializeField]
        private bool useGlobalAnimTime = true;

        
        
        [SerializeField] private float animTime = 0.3f;


        [SerializeField] private float triggeredOpacity = 1f;

        [SerializeField] private float untriggeredOpacity = 0f;
        
        
        


        private void Awake() {
            if (autoFetchTargetGraphic) {
                targetGraphic = GetComponent<Image>();
            }
        }


        public override bool Trigger(bool instant = false) {
            if (!base.Trigger()) return false;

            if (targetGraphic) {
                Tweener tween;
                
                if (instant) tween = targetGraphic.DOFade(triggeredOpacity, 0f);
                else tween = targetGraphic.DOFade(triggeredOpacity, animTime).SetEase(easing);
                
                AddActiveTween(tween);
            }

            return true;
        }

        public override bool Untrigger(bool instant = false) {
            if (!base.Untrigger()) return false;

            if (targetGraphic) {
                Tweener tween;
                
                if (instant) tween = targetGraphic.DOFade(untriggeredOpacity, 0f);
                else tween = targetGraphic.DOFade(untriggeredOpacity, animTime).SetEase(easing);

                AddActiveTween(tween);
            }

           
            return true;
        }
    }
}