   M S B A M L   `   `   `  ����F  BADETProjApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ADETProjApp.ViewADETProjApp.View  5      =#clr-namespace:ADETProjApp.ViewModelADETProjApp.ViewModel  5      %    ADETProjApp.View.ProfileContent   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      P LCompiledBindings.WPF, Version=1.0.17.5, Culture=neutral, PublicKeyToken=nullR NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089<x,http://schemas.microsoft.com/winfx/2006/xaml      5      Lmc;http://schemas.openxmlformats.org/markup-compatibility/2006      5      Bd2http://schemas.microsoft.com/expression/blend/2008      5      2localclr-namespace:ADETProjApp.View      5      4vm#clr-namespace:ADETProjApp.ViewModel      5        � 	Resources  5      %   ADETProjApp.ViewModel.ProfileVM   	ProfileVM��%   &	          5   
   6   5       � DataContext 5      �� 5   
    �� ResourceKey$ 	ProfileVM��6   .��5      � $��0,50,0,0q�6   .+�5   
   �  � RowDefinitions 5      �� 5      $	��150 �6    �� 5      $��* �6    �� 5      $	��220 �6    .+�5      � ���#D11717$��250,110,250,0q�6(   .+�5      �� $��15(�6   
�������$��Center=�6=   $
��bold"�6X   $��Center=�6j   $��
MY PROFILE��6�   5      � 5      ���#E7E9EC$��1��6(   $��250,20,250,20q�65   .+�5      �� $��Center=�6   $
��Left=�68   $��20, 10, 20, 10q�6S   .+�5       �� $��5q�6!    �� Orientation$ 
Horizontal=�6,   .+�5!      �� $��
USERNAME: ��6$   $
��Bold"�66   $��16(�6H   $	��0 5q�6V   �� 5"      $��16(�6Z   $	��5 5q�6h   ��6$   �� *User.username+ �� StringFormat$
 @{0}��6h   5#      �� 5$      $��5q�6!   $ 
Horizontal=�6,   .+�5%      �� $��NAME: ��6$   $
��Bold"�62   $��16(�6D   $	��0 5q�6R   �� 5&      $��16(�6?   $	��5 5q�6M   ��6$   �� *	User.name+6M   5'      �� 5(      $��5q�6!   $ 
Horizontal=�6,   .+�5)      �� $��FULL ADDRESS: ��6$   $
��Bold"�6:   $��16(�6L   $	��0 5q�6Z   �� 5*      $��16(�6B   $	��5 5q�6P   ��6$   �� *User.address+6P   5+      �� 5,      $��5q�6!   $ 
Horizontal=�6,   .+�5-      �� $��EMAIL: ��6$   $
��Bold"�63   $��16(�6E   $	��0 5q�6S   �� 5.      $��16(�6@   $	��5 5q�6N   ��6$   �� *
User.email+6N   5/      �� 50      $��5q�6!   $ 
Horizontal=�6,   .+�51      �� $��COTNACT NUMBER: ��6$   $
��Bold"�6<   $��16(�6N   $	��0 5q�6\   �� 52      $��16(�6E   $	��5 5q�6S   ��6$   �� *User.contact_no+6S   53      �� 54      $��5q�6!   $ 
Horizontal=�6,   .+�55      �� $��POINTS: ��6$   $
��Bold"�64   $��16(�6F   $	��0 5q�6T   �� 56      $��16(�6A   $	��5 5q�6O   ��6$   �� *User.points+6O   57      58      59      �� 5:      $��2��6   $
��Bold"�6"   ���#d11717
�������$	��Top=�6�   $��Center=�6�   $��30��6�   $��90��6�   ��64   �� *UpdateUserDetails+��5;      �� 5<       �� 
TargetType" ��6   .�5=      ��  �� Property � �� �� Value 5>      �� 5?   "   	 �� 
TargetType"	 ��62   .R�5@   &   �� 
 ��Name$
 border��6-   #��z��6=   #��z��5A   -   #��z��5B   -    �� CornerRadius$ 12��5C   -   ._�5D   *   �� $ 
Horizontal=�65   $��Center=�6N   $��Center=�6k   .+�5E   .   �� $<��6D:\source\repos\ADETProjApp\img\ToggleButtons\edit.png��64   $
��Fill=�6t   $��20��6�   $��20��6�   $��0,0,7,0q�6�   �� 5F   .   $��Center=�6?   $��Center=�6\   5G   +   5H   '    �� Triggers 5I   &   P� 5J   *    P� Property �@J�IsMouseOver P� Value . . �5K   .   ��  �� 
TargetName$ border��65    � �� �#a013136_   5M   +   P� 5N   *    � �� . . �5O   .   �� $ border��65    � �� �#850d0d6_   5Q   +   5S   #   5U      5V      ��5X      �� 5Y      $
��Edit��6    5[      5\      5]      5^      