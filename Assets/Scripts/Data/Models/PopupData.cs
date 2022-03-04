using System;
using Data.Enums;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Data.Models {
	[Serializable]
	public class PopupData {
		[Tooltip("Prefer using name of the class to get it by generic method")] [SerializeField] private string _name;
		[SerializeField] private PopupLoadType _loadType;
		[SerializeField] private PopupOrder _popupOrder;
		[SerializeField] private AssetReference _addressableAssetReference;
		[SerializeField] private bool _hasLoader;

		public string Name => _name;

		public PopupLoadType LoadType => _loadType;

		public PopupOrder PopupOrder => _popupOrder;

		public AssetReference AddressableAssetReference => _addressableAssetReference;

		public bool HasLoader => _hasLoader;
	}
}