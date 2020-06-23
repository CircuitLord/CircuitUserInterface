using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


namespace CUI.Actions {
    public class CuiSpinActionOld : CUIActionOLD {
        
        [SerializeField] private RectTransform targetRect;

        [Header("Settings")] [SerializeField]
        private bool useGlobalAnimTime = true;

        
        
        [SerializeField] private float animTime = 0.3f;


        [SerializeField] private float triggeredRot = 90f;

        [SerializeField] private float untriggeredRot = 0f;
        
        
        


        private void Awake() {
            if (!targetRect) targetRect = GetComponent<RectTransform>();
        }


        public override bool Trigger(bool instant = false) {
            if (!base.Trigger()) return false;

            if (targetRect) {
                Tweener tween;

                if (instant) tween = targetRect.DOLocalRotate(new Vector3(0f, 0f, triggeredRot), 0f);
                else tween = targetRect.DOLocalRotate(new Vector3(0f, 0f, triggeredRot), animTime).SetEase(easing);
                
                AddActiveTween(tween);
            }

            return true;
        }

        public override bool Untrigger(bool instant = false) {
            if (!base.Untrigger()) return false;

            if (targetRect) {
                Tweener tween;
                
                if (instant) tween = targetRect.DOLocalRotate(new Vector3(0f, 0f, untriggeredRot), 0f);
                else tween = targetRect.DOLocalRotate(new Vector3(0f, 0f, untriggeredRot), animTime).SetEase(easing);

                AddActiveTween(tween);
            }

           
            return true;
        }
    }
}