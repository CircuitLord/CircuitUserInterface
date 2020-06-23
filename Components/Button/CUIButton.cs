/*using System.Collections;
using System.Collections.Generic;
using CUI.Actions;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace CUI.Components {
	[RequireComponent(typeof(Button))]
	public class CUIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler {
		// [SerializeField] private List<CUIAction> actions;


		[OnValueChanged("OnPreview")] [SerializeField]
		[PropertyRange(0, 3)]
		private int previewState = 0;


		public void OnPreview() {
			switch (previewState) {
				case 0: 
					CUIActionHandler.Activate(actionsOnHoverStart);
					break;
				case 1: 
					CUIActionHandler.Activate(actionsOnHoverEnd);
					break;
				case 2: 
					CUIActionHandler.Activate(actionsOnDown);
					break;
				case 3: 
					CUIActionHandler.Activate(actionsOnUp);
					break;
			}
		}

		[SerializeField] private List<CUIActionRef> actionsOnHoverStart;

		[SerializeField] private List<CUIActionRef> actionsOnHoverEnd;

		[SerializeField] private List<CUIActionRef> actionsOnDown;

		[SerializeField] private List<CUIActionRef> actionsOnUp;


		[SerializeField] [HideInInspector] private Button button;


		private bool isHovered = false;

		private void Awake() {
			button = GetComponent<Button>();
		}

		public void OnPointerEnter(PointerEventData eventData) {
			if (isHovered) return;
			isHovered = true;

			CUIActionHandler.Activate(actionsOnHoverStart);
		}

		public void OnPointerExit(PointerEventData eventData) {
			if (!isHovered) return;
			isHovered = false;

			CUIActionHandler.Activate(actionsOnHoverEnd);
		}

		public void OnPointerDown(PointerEventData eventData) {
			CUIActionHandler.Activate(actionsOnDown);
		}

		public void OnPointerUp(PointerEventData eventData) {
			CUIActionHandler.Activate(actionsOnUp);
		}
	}
}*/