   M S B A M L   `   `   `  ���� A  =Sudoku, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SudokuSudoku  5clr-namespace:Sudoku.PropertiesSudoku.Properties      Sudoku.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     &localclr-namespace:Sudoku     6
Propertiesclr-namespace:Sudoku.Properties       � Title$  Sudoku��$	��720��$	��900�� � 	Resources    windowBackground j� 
AlignmentY j� Stretch �� ImageSource��%P   &	        �� $	 Top=�$ UniformToFill=�$" Images\Sudoku_background.png��.��� -   $��grdMain�� � ColumnDefinitions �� �� �� �� .+�o� -    o�Name$ mnuMain�� o� 
IsMainMenu . #���   $��4��.@�m� -    m�Name$ mnuFile��$��_Arkiv��
�������
���   �.@�m� -   $ mnuOpen��$��_Öppna��	 m� Command$	 ApplicationCommands.Open��
 m� Icon
 �� $0��*Properties/Resources/Images/icons/Open.png��m� -   $ mnuSave��$��_Spara��$	 ApplicationCommands.Save��
 �� $0��*Properties/Resources/Images/icons/Save.png��m� -   $ mnuHighscore��$��
_Highscore���� m� -   $ mnuExit��$��A_vsluta��$	 ApplicationCommands.Close��
 �� $0��*Properties/Resources/Images/icons/Exit.png��m� -   $ mnuHelp��$��_Hjälp��
�������
���   �   Sudoku.Meny  -	     Name$ menuComponent��$��4��$y�Visible=�   Sudoku.Highscore  -
     Name$ highscoreComponent��$��4��$y�	Collapsed=�   Sudoku.Spelplan  -     Name$ spelplanComponent��$��3��$y�	Collapsed=�   Sudoku.GridPrint  -     Name$ gridPrintComponent��$��3��$y�	Collapsed=�