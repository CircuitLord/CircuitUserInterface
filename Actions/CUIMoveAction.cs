using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;


namespace CUI.Actions {
    public class CUIMoveAction : CUIAction {
        
        [SerializeField] private RectTransform targetRect;

        [Header("Settings")] [SerializeField]
        private bool useGlobalAnimTime = true;

        
        
        [SerializeField] private float animTime = 0.3f;


        [SerializeField] private Vector3 triggeredPos = Vector3.zero;

        [SerializeField] private Vector3 untriggeredPos = Vector3.zero;
        
        
        


        private void Awake() {
            if (!targetRect) targetRect = GetComponent<RectTransform>();
        }


        private void Reset() {
            triggeredPos = transform.localPosition;
            untriggeredPos = transform.localPosition;
        }

        [Button]
        private void SetTriggeredPos() {
            triggeredPos = transform.localPosition;
        }


        public override bool Trigger(bool instant = false) {
            if (!base.Trigger()) return false;

            if (targetRect) {
                Tweener tween;

                if (instant) tween = targetRect.DOLocalMove(triggeredPos, 0f);
                else tween = targetRect.DOLocalMove(triggeredPos, animTime).SetEase(easing);
                
                AddActiveTween(tween);
            }

            return true;
        }

        public override bool Untrigger(bool instant = false) {
            if (!base.Untrigger()) return false;

            if (targetRect) {
                Tweener tween;
                
                if (instant) tween = targetRect.DOLocalMove(untriggeredPos, 0f);
                else tween = targetRect.DOLocalMove(untriggeredPos, animTime).SetEase(easing);

                AddActiveTween(tween);
            }

           
            return true;
        }
        
    }
}