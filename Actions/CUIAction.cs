using System;
using System.Collections;
using System.Collections.Generic;
using CUI.DOTweenUtil;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace CUI.Actions {
	public abstract class CUIAction : MonoBehaviour {


		public string actionName = "Action Name";

		[SerializeField] protected Ease easing = Ease.InOutCubic;

		[SerializeField] protected float duration = 0.3f;
		

		
		protected List<Tween> tweens = new List<Tween>();


		protected float dur = 0.3f;

		[OnValueChanged("@Toggle(false, true)")]
		[SerializeField] protected bool isActivated = false;

		private bool isActivatedPrevious = false;

		/*[PropertyOrder(0)]
		[LabelText("@states.Count > 0 ? states[0].name : \"\"")]
		[ShowIf("@states.Count > 0")]
		[HorizontalGroup("States")]
		[Button]
		public void State0() {
			ActivateIndex(0, false, true);
		}
		
		[LabelText("@states.Count > 1 ? states[1].name : \"\"")]
		[ShowIf("@states.Count > 1")]
		[HorizontalGroup("States")]
		[Button]
		public void State1() {
			ActivateIndex(1, false, true);
		}
		
		[LabelText("@states.Count > 2 ? states[2].name : \"\"")]
		[ShowIf("@states.Count > 2")]
		[HorizontalGroup("States")]
		[Button]
		public void State2() {
			ActivateIndex(2, false, true);
		}
		
		[LabelText("@states.Count > 3 ? states[3].name : \"\"")]
		[ShowIf("@states.Count > 3")]
		[HorizontalGroup("States")]
		[Button]
		public void State3() {
			ActivateIndex(3, false, true);
		}
		
		[LabelText("@states.Count > 4 ? states[4].name : \"\"")]
		[ShowIf("@states.Count > 4")]
		[HorizontalGroup("States")]
		[Button]
		public void State4() {
			ActivateIndex(4, false, true);
		}*/

		/*[PropertyOrder(1)]
		[OnCollectionChanged("SetupStates")]
		[TableList]*/
		/*[SerializeField]
		[HideInInspector]
		public List<CUIActionState> basicStates = new List<CUIActionState>();*/



		/*
		[ReadOnly]
		public int currentIndex = 0;*/




		/*
		protected void SetupStates() {
			foreach (CUIActionState state in basicStates) {
				state.GetReferences(gameObject);
			}
		}
		*/



		/*public virtual bool ActivateIndex(int index, bool instant = false, bool force = false) {

			if (basicStates.Count <= index) return false;

			if (currentIndex == index && !force) return false;

			currentIndex = index;
			
			KillTweens();
			
			dur = instant ? 0f : duration;

			return true;
		}*/

		public void Toggle(bool instant = false, bool force = false) {
			if (isActivatedPrevious) Deactivate(instant, force);
			else Activate(instant, force);

			isActivatedPrevious = isActivated;
		}
		


		public void ActivateNormal() {
			Activate(false, false);
		}
		
		public virtual bool Activate(bool instant = false, bool force = false) {

			if (isActivated && !force) return false;
			
			isActivated = true;
			
			KillTweens();

			dur = duration;
			
			return true;
		}
		
		public void DeactivateNormal() {
			Deactivate(false, false);
		}
		
		public virtual bool Deactivate(bool instant = false, bool force = false) {

			if (!isActivated && !force) return false;
			
			isActivated = false;
			
			KillTweens();
			
			dur = duration;
			
			return true;
		}



		protected void AddActiveTween(Tweener tween) {
			//if (tweens.Contains(tween)) return;
			
			tweens.Add(tween);

			tween.onComplete += () => {
				RemoveActiveTween(tween);
			};


		}

		private void RemoveActiveTween(Tweener tween) {
			if (!tweens.Contains(tween)) return;
			tweens.Remove(tween);
		}

		public void KillTweens() {
			foreach (Tweener tween in tweens) {
				tween?.Kill();
			}
			
			tweens.Clear();

		}

		protected void StartEditorTweens() {
			if (!Application.isPlaying) {
				CUITweenPreview.PrepareTweens(tweens);
				CUITweenPreview.StartTweens();
			}
		}
		

	}


	/*
	[Serializable]
	public class CUIActionState {
		
		//public int index = 0;
		
		public string name;
		
		[HideInInspector] public bool isActive = false;

		[Button]
		[LabelText("Set")]
		[TableColumnWidth(30, Resizable = false)]
		public virtual void Set() {
			
		}

		/// <summary>
		/// Should assign any references to components the state needs.
		/// </summary>
		/// <param name="go"></param>
		public virtual void GetReferences(GameObject go) {
			
		}

		/*[Button]
		[DisableIf(@"isActive")]
		private void Activate() {
			
		}#1#

	}
	
	
	[Serializable]
	public class CUIActionRef {

		public CUIAction action;
		
		
		[LabelText("@action != null ? \"State: \" + action.basicStates[index].name : \"State: None\"")]
		[PropertyRange(0, "@action != null ? action.basicStates.Count - 1 : 0")]
		public int index;
		
		
		
		

	}
	*/
	
	
}