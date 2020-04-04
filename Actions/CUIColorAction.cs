using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;


namespace CUI.Actions {
    public class CUIColorAction : CUIAction {

        [SerializeField] private bool autoFetchTargetGraphic = true;
        
        [HideIf("autoFetchTargetGraphic")]
        [SerializeField] private Graphic targetGraphic;

        [Header("Fade Settings")] [SerializeField]
        private bool useGlobalAnimTime = true;

        
        [HideIf("useGlobalAnimTime")]
        [SerializeField] private float animTime = 0.3f;


        [SerializeField] private Color triggeredColor = Color.white;

        [SerializeField] private Color untriggeredColor = Color.gray;
        
        
        


        private void Awake() {
            if (autoFetchTargetGraphic) {
                targetGraphic = GetComponent<Graphic>();
            }
        }


        public override bool Trigger(bool instant = false) {

            if (!base.Trigger()) return false;

            if (targetGraphic) {
                Tweener tween;
                
                if (instant) tween = targetGraphic.DOColor(triggeredColor, 0f);
                else tween = targetGraphic.DOColor(triggeredColor, animTime).SetEase(easing);
                
                AddActiveTween(tween);
            }

            return true;
        }

        public override bool Untrigger(bool instant = false) {
            if (!base.Untrigger()) return false;

            if (targetGraphic) {
                Tweener tween;
                
                if (instant) tween = targetGraphic.DOColor(untriggeredColor, 0f);
                else tween = targetGraphic.DOColor(untriggeredColor, animTime).SetEase(easing);

                AddActiveTween(tween);
            }

           
            return true;
        }
    }
}