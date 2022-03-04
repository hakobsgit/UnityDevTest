using System.Linq;
using Data.Models;
using Interfaces.Configs.Popups;
using UnityEngine;

namespace Configs.Popups {
	[CreateAssetMenu(menuName = "Configs/Popups/PopupsConfig")]
	public class PopupsConfig : ScriptableObject, IPopupsConfig {
		[SerializeField] private PopupData[] _popups;
		
		public PopupData GetPopupData<T>() {
			return GetPopupData(typeof(T).Name);
		}

		public PopupData GetPopupData(string popupName) {
			return _popups.FirstOrDefault(p => p.Name.Equals(popupName));
		}
	}
}