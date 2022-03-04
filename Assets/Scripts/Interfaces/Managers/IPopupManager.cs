using System;
using Data.Enums;
using Data.Models;
using Popups.Core;

namespace Interfaces.Managers {
	public interface IPopupManager {
		void ShowPopup(string name);
		void ShowPopup<T>(Action<T> onReady = null, PopupOrder? order = null) where T : BasePopup;
		void ShowPopupByData<T>(PopupData popupData, Action<T> onReady = null, PopupOrder? order = null)
			where T : BasePopup;
		void ShowReadyPopup(BasePopup popup, PopupOrder popupOrder = PopupOrder.OnTopOfOpenPopup);
		BasePopup GetPopup<T>();
		void HidePopup<T>();
		void HidePopup();
	}
}