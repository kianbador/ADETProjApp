   M S B A M L   `   `   `  ����F  BADETProjApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ADETProjApp.ViewADETProjApp.View  5      #    ADETProjApp.View.GamesContent   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      P LCompiledBindings.WPF, Version=1.0.17.5, Culture=neutral, PublicKeyToken=nullR NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089<x,http://schemas.microsoft.com/winfx/2006/xaml      5      Lmc;http://schemas.openxmlformats.org/markup-compatibility/2006      5      Bd2http://schemas.microsoft.com/expression/blend/2008      5      2localclr-namespace:ADETProjApp.View      5      .��5	      �   � RowDefinitions  5
   
   �� 5      $	��150 �6   �� 5      $��* �6   �� 5      $	��150 �6   .+�5   
   � $��0��6   ���#D11717$��225,100,225,0q�61   .+�5      �� $��18(�6   
�������$��Center=�69   $
��bold"�6T   $��Center=�6f   $��
MINI GAMES��6�   5      �� 5   
   $��1��6   ���#F1F1F1$��225,20,225,0q�67   .+�5      �� $��0,20,0,0q�6    �� Orientation$ 
Horizontal=�6+   $��Center=�6D   $	��Top=�6a   .+�5      �� $��30,20,30,20q�6   $
��Left=�6-   $��Center=�6H   $3��-D:\source\repos\ADETProjApp\img\word-game.png��6c   $	��150��6�   $	��150��6�   �� 5      $��Center=�6   $��Center=�6:   .+�5      �� $��	Word Game��6   $��10q�60   $��30(�6=   ���#F5AA01$
��Bold"�6`   �� 5      -   5         ��Name$ wordBtn��5      $��START��6.   $	��100��6>   
������ 
����������#054BAD$��30��6�   ��5      �� 5       �� 
TargetType" ��6$   .�5   "   ��  �� Property � �� �� Value 5   &   �� 5   *    �� 
TargetType" ��6:   .R�5    .   ��  ��Name$ border��65   #��z��6E   #��z��5!   -   #��z��5"   -    �� CornerRadius$ 12��5#   -   ._�5$   2   �� $��Center=�6C   $��Center=�6`   5%   /   	 �� Triggers	 5&   .   P� 5'   2   
 P� Property
 �@J�IsMouseOver P� Value . . �5(   6   ��  �� 
TargetName$ border��6=    � �� �#246ACB6g   5*   3   P� 5+   2   
 � �� . . �5,   6   �� $ border��6=    � �� �#4887DF6g   5.   3   50   +   52   #   53      55      56      58      �� 5:      $��	0,30,0,20q�6   $ 
Horizontal=�6,   $��Center=�6E   .+�5<      �� $��Center=�6   $��Center=�6:   .+�5=      �� $��Trivia Time��6   $��10q�62   $��30(�6?   ���#F5AA01$
��Bold"�6b   �� 5>      -   5        $ 	triviaBtn��5>      $��START��60   $	��100��6@   
������ 
����������#054BAD$��30��6�   ��5?      �� 5@      " ��6$   .�5A   "   ��  � �� 5B   &   �� 5C   *   " ��6:   .R�5D   .   �� $ border��65   #��z��6E   #��z��5E   !   #��z��5F   !   $ 12��5G   !   ._�5H   2   �� $��Center=�6C   $��Center=�6`   5I   /   	 5J   .   P� 5K   2   
 �@J�IsMouseOver . . �5L   6   �� $ border��6=    � �� �#246ACB6g   5N   3   P� 5O   2   
 � �� . . �5P   6   �� $ border��6=    � �� �#4887DF6g   5R   3   5T   +   5V   #   5W      5Y      5Z      �� 5[      $��30,20,30,20q�6   $
��Left=�6-   $��Center=�6H   $.��(D:\source\repos\ADETProjApp\img\quiz.png��6c   $	��150��6�   $	��150��6�   5\      5]      5^      5_      