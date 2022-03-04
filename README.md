# UnityDevTest

<b>How to test the functionality? </b><br>
Open Scene.unity from Scenes folder and play the scene. There are two buttons
1. Start Button - starts the whole popups flow
2. Open popup from editor button - opens popup with animations, also it configurable you can just change the popup name from unity's button component

<br><b>Availble popups</b></br>
1. MessagePopup
2. DialogPopup
3. DynamicContentPopup
4. AnimationsPopup
5. PlayAnimationPopup
6. AddressablePopup

<br>
Popups have Config located at Configs/Popups which contains list of popups data
<br>
<br><b>PopupData</b><br>
_name - name of popup (commonly the name of class)<br>
_loadType - load type (Resources or Addressables)<br>
_popupOrder - order of popup (open on top or wait till all closed)<br>
_addressableAssetReference - reference of addressable<br>
_hasLoader - if yes it'll show loading animation during loading<br>

<br><b>What 3rd party assets are used? </b><br>
<b>Zenject (Extenject)</b> - for dependency injection<br>
<b>UniRX</b> - for reactive programming<br>
<b>DoTween</b> - for tweening animations<br>

<b> What packages are used? </b><br>
<b>Addressables</b> - asset bundles, dynamic content <br>
<b>2D Sprite</b> - for 9 slice images <br>
<b>Unity UI</b> - for UI <br>
<b>TextMeshPro</b> - for texts <br>
<b>Rider package</b> - for Rider Editor <br>

<br>
<b>For Memory and rendering optimization</b>
1. Atlases to reduce drawcall batches as well compressing in one atlas uses less memory
2. for static content used static canvas (to not recalculate canvas for unnecessary static objects)
3. compressed bg to nearest for Po2, also disabled mipmap because there is no need of that, without mipmaps textures use less memory


<br><br>
I thought to use Addressables system to have content separated from the game. Right now the system works on local paths but it is really easy to make it remote. When content delivery server is ready, it's just about changing some paths. With adressables would be really easy to update any content of popups.


<br><br>
If I had more time I would consider to add new Object Pool system to PopupsManager and for loading addressables. I would add Caching system for downloaded assets(images).


<br><br>
I hope you'll like the project's hierarchy and code's cleanity 
