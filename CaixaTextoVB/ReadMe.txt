Explanation for testing with the Text Box (inherited from textBox)


-> Method:

* Constructor:
-The constructor (.ctor) defines how the box boot even in "design time";


-> Events (overwritten and new ones):

* OnKeyPress, OnEnter, OnLeave, OnGotFocus, InitLayout
-Makes a few checks in accordance with the properties set;

* RetornaInteiro
-If possible, returns the integer part of the number rounded up;

* ENumerico
-Check if the last text is numeric;


-> Properties (only the changed):

* Blocked:
-The box stays open for typing;
-Do not let you type in the box;

* Background Color:
-Choose a color box will have after losing focus;

* Background Color For:
-Choose a color that the box will have to receive the focus;

* Letter Color:
-Choose a color that the letter will have after losing focus;

* Font Color For:
-Choose a color that the letter will have to receive the focus;

* Allow Space:
-Allows or prohibits entering space;

* Allow Negative Sign:
-Allows or prohibits entering negative sign (only valid is to Type numbers);

* Cursor Position (if the box is filled in to receive focus):
-Home-Put the cursor at the beginning of the box;
-End-put the cursor at the end of the box;
-Complete-paint all the text inside the box;

* Text:
-Save a text that can be used later;

* Type:
-Normal-Allows entering all-"Alphanumeric" and special characters;
-Number-only allows typing numbers;
Letter-only allows typing text;