   M S B A M L   `   `   `  ����I  EChattingClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ChattingClientChattingClient  5   	       ChattingClient.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ChattingClient     5   	   -   5          � Title$  Whatsapp Messenger��5   	   $��413.7��6$   $	��323��63   .��5	      � $��0,0,0,-3q�6   $
��Left=�6   $	��315��68   ���	#FFE6E6E6 � ColumnDefinitions 5
   
   �� 5      $
��184* �6   �� 5      $
��333* �6   .+�5   
   �� -   5         ��Name$ UserNameTextBox��5      $
��Left=�6+   $��26��6F   $��	45,57,0,0q�6R    �� TextWrapping$
 Wrap=�6e   $	��Top=�6y   $	��107��6�    J� RenderTransformOrigin$ 0.455,-0.826&�6�   $��1��6�   �� 5   
   -   5         ��Name$ LoginButton��5      $��Login��6&   $��152,57,10,0q�66   $	��Top=�6K   $��1��6}   $��Microsoft NeoGothic)�6�   $��26��6�   $��14(�6�   �� 5   
   -   5        $ ChatDisplayTextBox��5      $��10,112,123,49q�6.   $ 	0.18,0.05&�6E   $��2��6h   �� 5   
   -   5        $ ChatTextBox��5      $��23��6'   $��10,0,123,10q�63   $
 Wrap=�6H   $��Bottom=�6\   $��2��6w   �� 5   
   -   5        $ 
SendButton��5      $
��Send��6%   $��	0,0,22,10q�64   $��Bottom=�6G   $ 2.813,0.601&�6b   $��Right=�6�   $��86��6�    �� 	IsDefault . $��1��6�   $��Microsoft NeoGothic)�6�   $��23��6  $��14(�6  �� 5   
   -   5         ��Name$ WelcomeUserLbl��5      $�� ��6(   $��Right=�63   $��
0,57,163,0q�6O   $	��Top=�6c   $	��152��6{   $
��Bold"�6�   $��2��6�   �� 5   
   -   5         ��Name$ OnlineUserListBox��5      $��0,139,22,49q�6-   $��1��6B   $��Right=�6R   $��86��6n   �� 5   
   -	   5        $ label��5      $��Online:��6   $��Right=�61   $��
0,112,22,0q�6M   $	��Top=�6a   $��86��6y   $��1��6�   $��Microsoft NeoGothic)�6�   $��27��6�   $��14(�6�   $ 0.663,0.556&�6�   �� 5   
   -
   5        $ label1��5      $��2��6    $��WhatsApp��64   $
��Left=�6G   $��49��6b   $	��Top=�6n   $	��315��6�   ���	#FF3B8134$��20(�6�   $
��Bold"�6�   
�������&   System.Windows.Media.TextOptions	   TextHintingMode$	 Fixed=�6�   $��Microsoft NeoGothic)�6   5      5      