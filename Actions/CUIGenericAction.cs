/*using System;
using System.Collections.Generic;
using CUI.DOTweenUtil;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;


namespace CUI.Actions {
	
	public class CUIGenericAction : CUIAction {
		
		
		[OnValueChanged("OnStatesChanged")]
		[TableList]
		public List<State> states = new List<State>();


		public void OnStatesChanged() {
			basicStates.Clear();
			
			foreach (State state in states) {
				basicStates.Add(state);
			}

			SetupStates();
		}
		
		
		//[HideInInspector]
		//public RectTransform rectTransform;


		protected override void Reset() {
			base.Reset();

		}

		public override bool ActivateIndex(int index, bool instant = false, bool force = false) {
			if (!base.ActivateIndex(index, instant, force)) return false;
			
			State state = states[index];
			
			//Prepare tweensC


			
			StartEditorTweens();



			return true;
		}


		[Serializable]
		public class State : CUIActionState {
			[HideInInspector] public RectTransform rect;

			public Vector2 pos = Vector2.zero;
			public Vector2 size = Vector2.one;
			public Vector2 scale = Vector3.one;
			public float rot = 0f;


			public override void Set() {
				pos = rect.anchoredPosition;
				size = rect.rect.size;
				scale = rect.localScale;
				rot = rect.localEulerAngles.z;
			}

			public override void GetReferences(GameObject go) {
				rect = go.GetComponent<RectTransform>();
			}
		}
	}
}*/