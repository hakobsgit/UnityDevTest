using Data.Models;

namespace Interfaces.Configs.Popups {
	public interface IPopupsConfig {
		PopupData GetPopupData<T>();
		PopupData GetPopupData(string popupName);
	}
}