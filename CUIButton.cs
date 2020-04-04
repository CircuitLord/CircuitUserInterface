using System.Collections;
using System.Collections.Generic;
using CUI.Actions;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace CUI {
    
    
    [RequireComponent(typeof(Button))]
    public class CUIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler {
        

        private Button button;


        [SceneObjectsOnly]
        [ChildGameObjectsOnly(IncludeSelf = true)]
        [SerializeField] private List<CUIAction> actionsOnHover;

        [SceneObjectsOnly]
        [ChildGameObjectsOnly(IncludeSelf = true)]
        [SerializeField] private List<CUIAction> actionsOnClick;
        
        private bool isHovered = false;

        private void Awake() {
            button = GetComponent<Button>();
        }

        public void OnPointerEnter(PointerEventData eventData) {
            if (isHovered) return;
            isHovered = true;
            
            CUIActionHandler.Trigger(actionsOnHover);

        }

        public void OnPointerExit(PointerEventData eventData) {
            if (!isHovered) return;
            isHovered = false;
            
            CUIActionHandler.Untrigger(actionsOnHover);
        }
        
        public void OnPointerDown(PointerEventData eventData) {
            CUIActionHandler.Trigger(actionsOnClick);
        }

        public void OnPointerUp(PointerEventData eventData) {
            CUIActionHandler.Untrigger(actionsOnClick);
        }
    }
}