   M S B A M L   `   `   `  ���� 
  Sudoku    Sudoku.Meny   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -   $��MenyControl��.��(�   (� Stretch$  Uniform=�.���� 
���   �$��2q�$��30q�
������� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Opacity$	 0.5Q�   ShadowDepth$
 10.0Q�._��� $��Center=�.+��� $��Impact)�$��75(�$��
15,10,15,0q�$��Center=�.��SUDOKU�� $��20(�$
��Thin"�$��Center=�.��Välj svårighetsnivå:A� -   $��rbGrid�� A� Columns$ 3��$��Center=�$��70,0,70,160q�.+�	� -   $	��rbL��$
��Left=�$��14(�$
��Thin"�$��5q�.��Lätt	� -   $	��rbM��$��14(�$
��Thin"�$��5q�.��Medium	� -   $	��rbS��$��Right=�$��14(�$
��Thin"�$��5q�.��Svår�� -   $	��gbL��$
��10,0q�$%��Alternativ på spelplan : Lätt��$
��Thin"�$y�	Collapsed=�.���  � RowDefinitions �� �� $��30 � � ColumnDefinitions �� �� �� .+��� $��3q�$	��100��$��Images\easy1.png���� $��3q�$	��100��$��Images\easy2.png��$��0��$��1���� $��3q�$	��100��$��Images\easy3.png��$��0��$��2��	� -   $��rbL_1��$��Center=�$��1��$��0��$��0,10,0,0q�	� -   $��rbL_2��$��Center=�$��1��$��1��$��0,10,0,0q�	� -	   $��rbL_3��$��Center=�$��1��$��2��$��0,10,0,0q��� -
   $	��gbM��$
��10,0q�$&�� Alternativ på spelplan : Medium��$
��Thin"�$y�	Collapsed=�.���  �� �� $��30 � �� �� �� .+��� $��3q�$	��100��$��Images\medium1.png���� $��3q�$	��100��$��Images\medium2.png��$��0��$��1���� $��3q�$	��100��$��Images\medium3.png��$��0��$��2��	� -   $��rbM_1��$��Center=�$��1��$��0��$��0,10,0,0q�	� -   $��rbM_2��$��Center=�$��1��$��1��$��0,10,0,0q�	� -   $��rbM_3��$��Center=�$��1��$��2��$��0,10,0,0q��� -   $	��gbS��$
��10,0q�$%��Alternativ på spelplan : Svår��$
��Thin"�$y�	Collapsed=�.���  �� �� $��30 � �� �� �� .+��� $��3q�$	��100��$��Images\hard1.png���� $��3q�$	��100��$��Images\hard2.png��$��0��$��1���� $��3q�$	��100��$��Images\hard3.png��$��0��$��2��	� -   $��rbS_1��$��Center=�$��1��$��0��$��0,10,0,0q�	� -   $��rbS_2��$��Center=�$��1��$��1��$��0,10,0,0q�	� -   $��rbS_3��$��Center=�$��1��$��2��$��0,10,0,0q��� -   $��btnSpela��{�.  $��30q�$
��Thin"�$��15(�.��Spela!