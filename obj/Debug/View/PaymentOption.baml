   M S B A M L   `   `   `  ����F  BADETProjApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ADETProjApp.ViewADETProjApp.View  5   	   $    ADETProjApp.View.PaymentOption   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   P LCompiledBindings.WPF, Version=1.0.17.5, Culture=neutral, PublicKeyToken=nullR NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089<x,http://schemas.microsoft.com/winfx/2006/xaml      5   	   Bd2http://schemas.microsoft.com/expression/blend/2008      5   	   Lmc;http://schemas.openxmlformats.org/markup-compatibility/2006      5   	   2localclr-namespace:ADETProjApp.View      5   	     � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � Topmost .   � WindowStyle$ SingleBorderWindow=�5
   	    � Title$ PaymentOption��5   	   $	��250��6   $	��275��6,   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   �� $��0��6   $��Center=�6"   $��Center=�6=    �� Orientation$ 
Horizontal=�6Z   .+�5      �� $��..\img\dollar.png��6   $��10q�6/   $��30��6;   �� 5      $��15(�6   $��Oblique$�6'   $��Center=�6;   $��Center=�6V   $��Select Payment Method:��6s   5      �� 5   
   $��	20,0,20,0q�6   $��1��6(   $��Center=�65   $
��Left=�6P   .+�5      	� -   5         	�Name$ codRB��5   -   $��	0,10,0,10q�6    	� 	GroupName$ Options��6<   	 d� 	IsChecked$
	 TrueY�6P   

 � Tag$
 1��6a   $��10(�6i   ��5      �� 5      $��Pay in Cash��6     � LayoutTransform 5      �� 5        �� ScaleX$	 1.5Q�6%    �� ScaleY$	 1.5Q�62   5"      	� 5$      -   5        $ onlineRB��5$      $��	0,10,0,10q�6,   $ Options��6?   $
 2��6S   $��10(�6[   ��5%      �� 5&      $ ��E-Wallets/Cards and others��6     5(      �� 5)      $	 1.5Q�6%   $	 1.5Q�62   5+      5,      �� 5.   
   -   5         ��Name$ 
proceedBtn��5.      $��2��6%   $	��Top=�62   $��Proceed��6J   ���#d11717
�������$��30��6�   $��80��6�   ��5/      �� 50       �� 
TargetType" ��6   .�51      ��  �� Property � �� �� Value 52      �� 53       �� 
TargetType" ��6.   .R�54   "   ��  ��Name$ border��6)   #��z��69   #��z��55   )   #��z��56   )    �� CornerRadius$ 12��57   )   ._�58   &   �� $��Center=�67   $��Center=�6T   59   #    �� Triggers 5:   "   P� 5;   &    P� Property �@J�IsMouseOver P� Value . . �5<   *   ��  �� 
TargetName$ border��61    � �� �#a013136[   5>   '   P� 5?   &    � �� . . �5@   *   �� $ border��61    � �� �#850d0d6[   5B   '   5D      5F      5G      5I      5J      5K      