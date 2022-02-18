using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetpackFuelBar : MonoBehaviour
{

	public Slider JetpackBar;

	public void UpdateFuelBar(float amount)
	{
		JetpackBar.value = amount;
	}

}
