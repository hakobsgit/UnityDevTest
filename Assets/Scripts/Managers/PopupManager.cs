using System;
using System.Collections.Generic;
using System.Linq;
using Data.Enums;
using Data.Models;
using Factories;
using Interfaces.Configs.Popups;
using Interfaces.Factories;
using Interfaces.Managers;
using Interfaces.Views;
using Popups.Core;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Views;
using Zenject;

namespace Managers {
	public class PopupManager : IInitializable, IPopupManager {
		[Inject] private DiContainer _diContainer;
		[Inject] private IPopupsConfig _popupsConfig;

		private readonly LinkedList<BasePopup> _pendingPopups = new LinkedList<BasePopup>();

		private IPrefabFactory _prefabFactory;
		private IPopupView _view;

		public void Initialize() {
			_prefabFactory = new PrefabFactory(_diContainer);
			_view = _prefabFactory.Create<PopupView>("Views/PopupView");
		}

		public void ShowPopup<T>(Action<T> onReady = null, PopupOrder? order = null) where T : BasePopup {
			PopupData popupData = _popupsConfig.GetPopupData<T>();
			var popupOrder = order ?? popupData.PopupOrder;
			onReady += popup => { ShowPopup(popup, popupOrder); };
			CreatePopup(popupData, onReady);
		}

		public BasePopup GetPopup<T>() {
			return _pendingPopups.FirstOrDefault(p => p.GetType() == typeof(T));
		}

		public void HidePopup<T>() {
			var popup = GetPopup<T>();
			if (popup != null) {
				popup.Hide();
			}
		}

		public void HidePopup() {
			if (_pendingPopups.Count <= 0) {
				return;
			}

			BasePopup popupToHide = _pendingPopups.First();
			popupToHide.Hide();
		}

		private void ShowPopup(BasePopup popup, PopupOrder order = PopupOrder.BehindOfOpenPopup) {
			switch (order) {
				case PopupOrder.BehindOfOpenPopup:
					_pendingPopups.AddLast(popup);
					break;
				case PopupOrder.OnTopOfOpenPopup:
					_pendingPopups.AddFirst(popup);
					break;
			}

			popup.OnHide.Subscribe(_ => OnPopupHid(popup));

			if (_pendingPopups.Count > 1 && order == PopupOrder.BehindOfOpenPopup) {
				popup.transform.SetParent(_view.Container, false);
				popup.gameObject.SetActive(false);
				return;
			}

			_view.Dimmer.enabled = popup.HasDimmer;
			popup.transform.SetParent(_view.Container, false);
			popup.Show();
		}

		private void OnPopupHid(BasePopup popup) {
			_pendingPopups.Remove(popup);
			
			BasePopup nextPopup = null;
			if (_pendingPopups.Count > 0) {
				nextPopup = _pendingPopups.First();
			}

			if (nextPopup) {
				if (!nextPopup.gameObject.activeInHierarchy) {
					nextPopup.gameObject.SetActive(true);
					_view.Dimmer.enabled = nextPopup.HasDimmer;
					nextPopup.Show();
				}
				else {
					_view.Dimmer.enabled = nextPopup.HasDimmer;
				}
			}
			else {
				_view.Dimmer.enabled = false;
			}
		}

		private void CreatePopup<T>(PopupData popupData, Action<T> onLoaded) where T : BasePopup {
			switch (popupData.LoadType) {
				case PopupLoadType.Resources:
					onLoaded?.Invoke(_prefabFactory.Create<T>("Popups/" + popupData.Name));
					break;
				case PopupLoadType.Addressables:
					Addressables.LoadAssetAsync<GameObject>(popupData.AddressableAssetReference).Completed += handle => {
						onLoaded?.Invoke(_prefabFactory.Create(handle.Result).GetComponent<T>());
					};
					break;
			}
		}
	}
}