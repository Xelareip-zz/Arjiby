using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextColorDisplay : MonoBehaviour
{
	public RawImage image;
	public Text countText;
	
	void Update ()
	{
		countText.text = "" + WeaponManager.Instance.munitions;
		image.color = WeaponManager.Instance.nextColor;
	}
}
