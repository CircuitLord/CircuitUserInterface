using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CUI.Actions {
	
	public static class CUIActionHandler {



		public static void Trigger(List<CUIAction> actions, bool instant = false) {
			foreach (CUIAction action in actions) {
				if (action == null) continue;
				action.Trigger(instant);
			}
		}
		
		public static void Untrigger(List<CUIAction> actions, bool instant = false) {
			foreach (CUIAction action in actions) {
				if (action == null) continue;
				action.Untrigger(instant);
			}
		}
		
	
	}

}
