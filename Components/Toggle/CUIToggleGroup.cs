using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;


namespace CUI.Components {


	[Serializable]
	public class UnityIntEvent : UnityEvent<int> {
	};
	
	
	[DisallowMultipleComponent]
	public class CUIToggleGroup : MonoBehaviour {

		[Tooltip("Can more than one toggle be selected?")]
		[SerializeField] private bool allowMultiSelect = false;
		
		[Tooltip("Can a toggle be deselected by clicking on it?")]
		[SerializeField] private bool allowDeselection = false;


		public UnityEvent onSelectedTogglesUpdated;

		public UnityIntEvent onIndexSelected;
		
	
		[HideInInspector] public List<CUIToggle> toggles = new List<CUIToggle>();


		[HideInInspector] public int selectedIndex = 0;

		[HideInInspector] public List<CUIToggle> selectedToggles;


		private void Start() {
			FindChildrenToggles();
		}


		public void OnChildToggled(CUIToggle toggle) {

			if (!allowDeselection && selectedToggles.Contains(toggle)) return;

			//If we allow deselection, disable the toggle that was clicked on
			if (allowDeselection && toggle.isSelected) {
				toggle.Deselect();
				return;
			}

			if (!allowMultiSelect) {
				
				//Deselect others:
				foreach (CUIToggle other in selectedToggles) {
					if (other == null) continue;
					if (!other.isSelected) continue;
					other.Deselect();
				}
				
				selectedToggles.Clear();
			}
			
			//Select the right one:

			toggle.Select();
			
			selectedToggles.Add(toggle);
			
			onSelectedTogglesUpdated.Invoke();

			selectedIndex = toggle.transform.GetSiblingIndex();
			onIndexSelected.Invoke(selectedIndex);


		}
		



		[Button]
		public void FindChildrenToggles() {
			
			toggles.Clear();

			CUIToggle[] found = GetComponentsInChildren<CUIToggle>();

			foreach (CUIToggle child in found) {
				//CUIToggle found = child.GetComponent<CUIToggle>();
				
				if (child != null) toggles.Add(child);
			}

			if (!Application.isPlaying) Debug.Log(gameObject.name + " found " + toggles.Count +  " CUIToggles!");
			
			
			
		}
	
	
	
	
	
	
	
	}
}