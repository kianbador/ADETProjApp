   M S B A M L   `   `   `  ����F  BADETProjApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ADETProjAppADETProjApp  5   	       ADETProjApp.OrderWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   P LCompiledBindings.WPF, Version=1.0.17.5, Culture=neutral, PublicKeyToken=nullR NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089<x,http://schemas.microsoft.com/winfx/2006/xaml      5   	   Bd2http://schemas.microsoft.com/expression/blend/2008      5   	   Lmc;http://schemas.openxmlformats.org/markup-compatibility/2006      5   	   -localclr-namespace:ADETProjApp      5   	     � Title$  OrderWindow��5   	   $	��800��6   $
��1200��6*    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � Topmost .   � WindowStyle$ SingleBorderWindow=�5   	   .��5      � .+�5   
   �  � ColumnDefinitions 5      �� 5      $	��250 �6#   �� 5      $��* �6#   .+�5      � $��0��6   ���#d11717.+�5      �� $��	0, 40,0,0q�6   $	��Top=�60   $��Center=�6H    �� Orientation$ 
Horizontal=�6e   .+�5      ��  �� CornerRadius$ 20��6   $��70��6/   $��70��6;   
�������._�5      �� $��Center=�6    $��Center=�6;   $��UniformToFill=�6X   $��\img\logos\app-logo.png��6p   $��90��6�   $��90��6�   5      �� 5      $��
mealMaster��6   $��23(�61   $
��Bold"�6?   
�������$��Center=�6d   $��Center=�6�   5      �� 5      $��10,170,10,50q�6   .+�5      d� -   5         d�Name$ 
profileBtn��5   .   $��5q�6#   $��50��6B   $��21(�6N   ���#d11717
�������.��5      �� $ 
Horizontal=�6%   .+�5      �� $<��6D:\source\repos\ADETProjApp\img\ToggleButtons\user.png��6$   $��30��6d   $��30��6p   $��0,0,10,0q�6{   �� 5       $��Profile��6(   $��Center=�67   $��21(�6R   5!      5"      d� 5#      -   5        $ foodBtn��5#   4   $��0,5,5,5q�6#   $��50��6E   $��21(�6Q   ���#d11717
�������.��5%      �� $ 
Horizontal=�6%   .+�5&      �� $=��7D:\source\repos\ADETProjApp\img\ToggleButtons\dish1.png��6$   $��40��6e   $��40��6q   $��0,0,10,0q�6|   �� 5'      $
��Food��6(   $��Center=�64   $��21(�6O   5(      5)      d� 5*      -   5        $ cartBtn��5*   .   $��5q�6#   $��50��6?   $��21(�6K   ���#d11717
�������.��5,      �� $ 
Horizontal=�6%   .+�5-      �� $<��6D:\source\repos\ADETProjApp\img\ToggleButtons\cart.png��6$   $��35��6d   $��35��6p   $��	10,0,10,0q�6{   �� 5.      $��My Cart��6(   $��Center=�67   $��21(�6R   5/      50      d� 51      -   5        $ orderBtn��51   .   $��5q�6#   $��50��6@   $��21(�6L   ���#d11717
�������.��53      �� $ 
Horizontal=�6%   .+�54      �� $=��7D:\source\repos\ADETProjApp\img\ToggleButtons\order.png��6$   $��30��6e   $��30��6q   $��	10,0,10,0q�6|   �� 55      $��Orders��6(   $��Center=�66   $��21(�6Q   56      57      d� 58      -   5        $ 
historyBtn��58   .   $��5q�6#   $��50��6B   $��21(�6N   ���#d11717
�������.��5:      �� $ 
Horizontal=�6%   .+�5;      �� $?��9D:\source\repos\ADETProjApp\img\ToggleButtons\history.png��6$   $��30��6g   $��30��6s   $��	10,0,10,0q�6~   �� 5<      $��History��6(   $��Center=�67   $��21(�6R   5=      5>      d� 5?      -   5        $ gamesBtn��5?   .   $��5q�6#   $��50��6@   $��21(�6L   ���#d11717
�������.��5A      �� $ 
Horizontal=�6%   .+�5B      �� $=��7D:\source\repos\ADETProjApp\img\ToggleButtons\games.png��6$   $��40��6e   $��40��6q   $��	10,0,10,0q�6|   �� 5C      $��
Mini Games��6(   $��Center=�6:   $��21(�6U   5D      5E      d� 5F      -   5        $ 	pointsBtn��5F   .   $��5q�6#   $��50��6A   $��19(�6M   ���#d11717
�������.��5H      �� $ 
Horizontal=�6%   .+�5I      �� $=��7D:\source\repos\ADETProjApp\img\ToggleButtons\point.png��6$   $��30��6e   $��30��6q   $��	10,0,10,0q�6|   �� 5J      $��Points and Rewards��6(   $��Center=�6B   $��19(�6]   5K      5L      �� 5N      -   5        	 ��Name$	 outBtn��5N   q   $��40q�6   $��18(�6)   $
��Bold"�67   
����������#ffbc26
������ $��Log Out��6�   $	��150��6�   $��40��6�   ��5O      �� 5P      
 �� 
TargetType"
 ��6$   .�5Q   "   ��  �� Property � �� �� Value 5R   &   �� 5S   *    �� 
TargetType" ��6:   .R�5T   .   ��  ��Name$ border��65   #��z��6E   #��z��5U   -   #��z��5V   -   $ 12��5W   -   ._�5X   2   �� $ 
Horizontal=�6=   $��Center=�6V   $��Center=�6s   .+�5Y   6   �� $��Center=�6G   $��Center=�6d   5Z   3   5[   /    �� Triggers 5\   .   P� 5]   2    P� Property �@J�IsMouseOver P� Value . . �5^   6   ��  �� 
TargetName$ border��6=    � �� �#DBA01C6g   5`   3   P� 5a   2    � �� . . �5b   6   �� $ border��6=    � �� �#B483156g   5d   3   5f   +   5h   #   5i      5k      5l      5n      � 5p      $��1��6   .+�5q      �� -	   5         ��Name$ ContentArea��5q   !   �� 5r      $��Center=�6   $
��Wrap=�69   ���#ffbc26$	��Top=�6b   $��50��6z   $	��950��6�   5s      5t      5u      5v      