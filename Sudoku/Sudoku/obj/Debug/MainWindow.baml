   M S B A M L   `   `   `  ����A  =Sudoku, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SudokuSudoku  5   	   5clr-namespace:Sudoku.PropertiesSudoku.Properties  5   	       Sudoku.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   &localclr-namespace:Sudoku     5   	   6
Propertiesclr-namespace:Sudoku.Properties     5   	     � Title$  Sudoku��5   	   $	��720��6   $	��900��6%    � 	Resources 5         windowBackground j� 
AlignmentY j� Stretch �� ImageSource��%h   &	        �� 5   
   $	 Top=�6.   $ UniformToFill=�6?   $" Images\Sudoku_background.png��6W   5	      .��5
      � -   5        $��grdMain��5
       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   o� -   5         o�Name$ mnuMain��5       o� 
IsMainMenu . #���   62   $��4��6b   .@�5      m� -   5         m�Name$ mnuFile��5   '   $��_Arkiv��6   
�������
���   �.@�5      m� -   5        $ mnuOpen��5      $��_Öppna��6,   	 m� Command$	 ApplicationCommands.Open��6<   
 m� Icon
 5      �� 5      $0��*Properties/Resources/Images/icons/Open.png��6    5      m� 5      -   5        $ mnuSave��5      $��_Spara��6,   $	 ApplicationCommands.Save��6<   
 5      �� 5      $0��*Properties/Resources/Images/icons/Save.png��6    5      m� 5!      -   5        $ mnuHighscore��5!      $��
_Highscore��61   6E   �� 5#      6   m� 5$      -   5        $ mnuExit��5$      $��A_vsluta��6,   $	 ApplicationCommands.Close��6>   
 5%      �� 5&      $0��*Properties/Resources/Images/icons/Exit.png��6    5(      5)      m� 5*      -   5        $ mnuHelp��5*   '   $��_Hjälp��6   
�������
���   �6K   5+         Sudoku.Meny  5-   
   -	   5          Name$ menuComponent��5-      $��4��6,   $y�Visible=�6@   6W      Sudoku.Highscore  5.   
   -
   5          Name$ highscoreComponent��5.      $��4��66   $y�	Collapsed=�6J   6c      Sudoku.Spelplan  5/   
   -   5          Name$ spelplanComponent��5/      $��3��64   $y�	Collapsed=�6D   6]      Sudoku.GridPrint  50   
   -   5          Name$ gridPrintComponent��50      $��3��66   $y�	Collapsed=�6J   6c   51      52      