using System;
using System.Collections;
using System.Collections.Generic;
using CUI;
using Sirenix.OdinInspector;
using UnityEngine;


namespace CUI.Utils {
	public class CUIGroupSwapper : MonoBehaviour {



		[HideInInspector] public List<CUIGroup> groups = new List<CUIGroup>();


		[HideInInspector] public CUIGroup activeGroup;


		private void Start() {
			FindChildrenGroups();
		}

		[Button]
		public void FindChildrenGroups() {
			groups.Clear();

			foreach (Transform child in transform) {
				CUIGroup found = child.GetComponent<CUIGroup>();
				
				if (found != null) groups.Add(found);
			}

			if (!Application.isPlaying) Debug.Log(gameObject.name + " found " + groups.Count +  " CUIGroups!");
		}


		public void Swap(int index) {
		
			Swap(groups[index]);
		
		}
	
		public void Swap(CUIGroup newGroup) {

			if (newGroup == activeGroup) return;
		
			if (activeGroup) {
				CUIManager.SwapAnimate(activeGroup, newGroup);
			}
			else {
				CUIManager.Animate(newGroup, true);
			}
		
			activeGroup = newGroup;


		}

	
	
	
	
	
	}
}