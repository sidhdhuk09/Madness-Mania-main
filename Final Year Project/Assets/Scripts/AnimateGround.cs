using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace EndlessCarChase
{
	
	public class AnimateGround : MonoBehaviour
	{
		//script to animate the ground to give it different colors
		public Color[] colorList;

		public int colorIndex = 0;

		public float changeTime = 1;
		public float changeTimeCount = 0;

		public float changeSpeed = 1;

		public bool isPaused = false;

		public bool isLooping = true;

		public bool randomColor = false;

		
		void Start()
		{
						
			SetColor();
		}

		// Update is called once per frame
		void Update()
		{
			if (isPaused == false)
			{
				if (changeTime > 0)
				{
					if (changeTimeCount > 0)
					{
						changeTimeCount -= Time.deltaTime;
					}
					else
					{
						changeTimeCount = changeTime;

						if (colorIndex < colorList.Length - 1)
						{
							colorIndex++;
						}
						else
						{
							if (isLooping == true) colorIndex = 0;
						}
					}
				}

				if (GetComponent<Renderer>())
				{
					GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, colorList[colorIndex], changeSpeed * Time.deltaTime);
				}

				if (GetComponent<TextMesh>())
				{
					GetComponent<TextMesh>().color = Color.Lerp(GetComponent<TextMesh>().color, colorList[colorIndex], changeSpeed * Time.deltaTime);
				}

				if (GetComponent<SpriteRenderer>())
				{
					GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, colorList[colorIndex], changeSpeed * Time.deltaTime);
				}

				if (GetComponent<Image>())
				{
					GetComponent<Image>().color = Color.Lerp(GetComponent<Image>().color, colorList[colorIndex], changeSpeed * Time.deltaTime); ;
				}
			}
			else
			{
				SetColor();
			}
		}

		
		void SetColor()
		{
			int tempColor = 0;

			//Set the color randomly
			if (randomColor == true) tempColor = Mathf.FloorToInt(Random.value * colorList.Length);

			if (GetComponent<Renderer>())
			{
				GetComponent<Renderer>().material.color = colorList[tempColor];
			}

			if (GetComponent<TextMesh>())
			{
				GetComponent<TextMesh>().color = colorList[tempColor];
			}

			if (GetComponent<SpriteRenderer>())
			{
				GetComponent<SpriteRenderer>().color = colorList[tempColor];
			}

			if (GetComponent<Image>())
			{
				GetComponent<Image>().color = colorList[tempColor];
			}
		}

		
		void Pause(bool pauseState)
		{
			isPaused = pauseState;
		}

	}
}
