   M S B A M L   `   `   `  ����A  =Puzzle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PuzzlePuzzle  5   	       Puzzle.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Puzzle     5   	     � Title$  Puzzle��5   	   $	��500��6   $	��800��6%    � 
ResizeMode$ NoResize=�5	   	   ��5      �� 5   
    �� ImageSource$ /Images/Background.png��6   .��5      �  � 	Resources 5   
    �� 
TargetType �� Property �� Value��%Z   '��       �� 5      " ��6   .�5      ��  �@��Padding$ 26q�6,   5      5       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   6.   �� 5      $��* �6   6+   .+�5   
   �� $��0��6   $��Center=�6!      BorderBoard#��[  6<   ._�5      � -   5         �Name$ board��5      $	��400��6'   $	��400��63   6B   5      �� 5   
   $��1��6   ._�5       �� .+�5!      �� 	 �� Padding$	 2q�6   
�������$��Center=�68   ._�5"      �� $ ��Images/Puzzles/Preview.jpg��6   $	��120��6@   $	��120��6M   5#      �� 5%      -   5        
 ��Name$
 start��5%        ButtonStyle#��[ 6(   .��6^   
ROZPOCZNIJ6j   �� 5&      -   5         ��Name$	 win��5&        TextBlockWin#��[ 6)   6Q   5'      5(      5)      5+      