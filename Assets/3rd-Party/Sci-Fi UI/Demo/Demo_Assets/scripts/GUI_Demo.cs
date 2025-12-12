using UnityEngine;


public class GUI_Demo : MonoBehaviour
{
	public GUISkin guiSkin;

	private float   hSliderValue   = 0f;
	private float   vSliderValue   = 0f;
    private Vector2 scrollPosition = Vector2.zero;
	private string  stringToEdit   = "Text Label";	
	private string  textToEdit     = "TextBox:\nHello World\nI've got few lines...";
	private bool    toggleTxt      = false;
	private Rect    windowRect     = new(0f, 0f, 400f, 380f);
	private float   hSbarValue;
	private float   vSbarValue;


    private void DoMyWindow (int windowID) 
	{
		GUI.Box   (new Rect(10f,  50f, 120f, 250f), "Box title");
		GUI.Button(new Rect(20f,  80f, 100f,  20f), "BUTTON");
		GUI.Label (new Rect(20f, 115f, 100f,  20f), "LABEL: Hello!");

		stringToEdit = GUI.TextField       (new Rect( 15f, 140f, 110f,  20f), stringToEdit, 25);
		hSliderValue = GUI.HorizontalSlider(new Rect( 15f, 175f, 110f,  30f), hSliderValue,   0f, 10f);
		vSliderValue = GUI.VerticalSlider  (new Rect(140f,  50f,  20f, 200f), vSliderValue, 100f,  0f);

		toggleTxt  = GUI.Toggle  (new Rect(165f, 50f, 100f,  30f), toggleTxt, "A Toggle text");
		textToEdit = GUI.TextArea(new Rect(165f, 90f, 185f, 100f), textToEdit, 200);

		GUI.Label(new Rect(180f, 215f, 100f, 20f), "ScrollView");
		scrollPosition = GUI.BeginScrollView(new Rect(180f, 235f, 160f, 100f), scrollPosition, new Rect(0f, 0f, 220f, 200f));
			GUI.Button (new Rect(  0f,  10f, 100f, 20f), "Top-left"    );
			GUI.Button (new Rect(120f,  10f, 100f, 20f), "Top-right"   );
			GUI.Button (new Rect(  0f, 170f, 100f, 20f), "Bottom-left" );
			GUI.Button (new Rect(120f, 170f, 100f, 20f), "Bottom-right");
		GUI.EndScrollView();

		hSbarValue = GUI.HorizontalScrollbar(new Rect( 10f, 360f, 360f,  30f), hSbarValue, 5f,  0f, 10f);
		vSbarValue = GUI.VerticalScrollbar  (new Rect(380f,  25f,  30f, 300f), vSbarValue, 1f, 30f,  0f);

		GUI.DragWindow (new Rect(0f, 0f, 10000f, 10000f));

    }	// DoMyWindow()


    private void OnGUI () 
	{
		GUI.skin   = guiSkin;
		windowRect = GUI.Window(0, windowRect, DoMyWindow, "My Window");

	}	// OnGUI()


	private void Start () 
	{
		windowRect.x = (Screen.width  - windowRect.width ) / 2.0f;
		windowRect.y = (Screen.height - windowRect.height) / 2.0f;

	}	// Start()


}	// class GUI_Demo
