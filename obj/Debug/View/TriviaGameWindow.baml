   M S B A M L   `   `   `  ����F  BADETProjApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ADETProjApp.ViewADETProjApp.View  5   	   '    !ADETProjApp.View.TriviaGameWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   P LCompiledBindings.WPF, Version=1.0.17.5, Culture=neutral, PublicKeyToken=nullR NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089<x,http://schemas.microsoft.com/winfx/2006/xaml      5   	   Bd2http://schemas.microsoft.com/expression/blend/2008      5   	   Lmc;http://schemas.openxmlformats.org/markup-compatibility/2006      5   	   2localclr-namespace:ADETProjApp.View      5   	     � Title$  TriviaGameWindow��5   	   $	��700��6"   $	��700��6/    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � Topmost .   � WindowStyle$ SingleBorderWindow=�5   	   .��5      � .+�5   
   �  � ColumnDefinitions 5      �� 5      $��0 �6#   �� 5      $��* �6#   .+�5      �� -   5         ��Name$ 	lblPoints��5   9   $��1��6   $��	Points: 0��6(   ���#FFBC26$��	ExtraBold"�6a   $��15(�6x   ���#D11717$	��Top=�6�   $��Right=�6�    �� Padding$ 15q�6�   $
��1420��6�   $��50��6�    �� TextAlignment$ Right=�6�   �� 5      $��1��6   	 �� Orientation$	 Vertical=�6)   $��Center=�6@   $��Center=�6]   $��20q�6x   .+�5      �� $��TRIVIA TIME��6   $��32(�6/   $
��Bold"�6=   
����������#D11717$	��549��6w   $ Center=�6�   $��0,0,0,30q�6�   $��50��6�   �� 5      ���#1E88E5$	��549��62   $	��444��6>   $��0,20,0,0q�6K   .+�5      �� -   5        $ lblQuestion��5       $��Question��65   $��20(�6E   $
��Bold"�6S   
����������#720FA6$ Center=�6�   $��55��6�   $	��488��6�   $��30q�6�   �� 5      -   5        
 ��Name$
 
btnAnswer1��5      $��Answer 1��61   $��20(�6D   
����������#054BAD
 � Tag$ 0��6z   $��10q�6�   $	��488��6�   $��40��6�   ���#282722$��1q�6�   �� 5      -   5        $
 
btnAnswer2��5      $��Answer 2��61   $��20(�6D   
����������#054BAD$ 1��6z   $��0q�6�   $	��488��6�   $��40��6�   ���#282722$��1q�6�   �� 5      -   5        $
 
btnAnswer3��5      $��Answer 3��61   $��20(�6D   
����������#054BAD$ 2��6z   $��10q�6�   $	��488��6�   $��40��6�   ���#282722$��1q�6�   �� 5      -   5        $
 
btnAnswer4��5      $��Answer 4��61   $��20(�6D   
����������#054BAD$ 3��6z   $��0q�6�   $	��488��6�   $��40��6�   ���#282722$��1q�6�   �� 5       -   5        $
 btnNext��5       $��Next Question��6.   $��16(�6F   $
��Bold"�6T   ���#FFBC26���#D11717$	��140��6�   $��35��6�   $��50q�6�   {�.  6�   5!      5"      5#      5$      5%      