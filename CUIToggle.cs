using System;
using System.Collections;
using System.Collections.Generic;
using CUI;
using CUI.Actions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;




[RequireComponent(typeof(Button))]
public class CUIToggle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {



	[SerializeField] private bool startSelected = false;
	
	[HideInInspector] public bool isSelected = false;
	
	[SerializeField] private List<CUIAction> actionsOnActivated = new List<CUIAction>();

	[SerializeField] private List<CUIAction> actionsOnHover;
	


	private CUIToggleGroup parent;

	private Button button;

	private bool isHovered = false;

	private void Awake() {
		button = GetComponent<Button>();
		parent = transform.parent.GetComponent<CUIToggleGroup>();
	}

	private void Start() {
		Deselect(true);
		
		if (startSelected) Toggle();
	}


	[Tooltip("Should be hooked up to whatever script you have to animate the activated state.")]
	public UnityEvent onShouldActivate;
	
	[Tooltip("Should be hooked up to whatever script you have to animate the disabled state.")]
	public UnityEvent onShouldDisable;



	public void Select(bool instant = false) {
		isSelected = true;

		CUIActionHandler.Trigger(actionsOnActivated, instant);
		
		onShouldActivate.Invoke();
	}


	public void Deselect(bool instant = false) {
		isSelected = false;
		
		CUIActionHandler.Untrigger(actionsOnActivated, instant);

		onShouldDisable.Invoke();
	}
	
	
	public void Toggle() {
		parent.OnChildToggled(this);
	}
	






	public void SetParentToggleGroup(CUIToggleGroup group) {
		parent = group;
	}


	private void Reset() {
		CUIToggleGroup group = transform.parent.GetComponent<CUIToggleGroup>();
		if (group != null) {
			group.FindChildrenToggles();
		}
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
}
