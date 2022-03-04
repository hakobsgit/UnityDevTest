using System;
using Data.Enums;
using Popups.Core;

namespace Interfaces.Managers {
	public interface IPopupManager {
		void ShowPopup<T>(Action<T> onReady = null, PopupOrder? order = null) where T : BasePopup;
		BasePopup GetPopup<T>();
		void HidePopup<T>();
		void HidePopup();
	}
}