   M S B A M L   `   `   `  ����I  ESkEditorRemake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SkEditorRemakeSkEditorRemake  5   	   #    SkEditorRemake.SettingsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:SkEditorRemake     5   	   ^ ZICSharpCode.AvalonEdit, Version=6.1.2.30, Culture=neutral, PublicKeyToken=9cc39be672370310?
avalonedit.http://icsharpcode.net/sharpdevelop/avalonedit  64   -   5          � Title$  SkEditor Remake��5	   	    � Icon$ Images/SkEditor.ico��5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	   
������  � AllowsTransparency .  � WindowStyle$
 None=�5   	   $��397.074��5   	   $	��236��5   	    � Triggers 5      :� 5   
    :� RoutedEvent$ Window.Loaded��6   .[�5      �� .��5      �� .��5      W�  �� TargetProperty$ Opacity�6&   	 W� From$	 0X�6J   	
 W� To$
 1X�6S    g� Duration$ 0:0:0.2D�6Z    g� FillBehavior$ HoldEnd=�6m   5      5      5       � 	Resources 5         Button1 �� 
TargetType ��Name �� CornerRadius J� SnapsToDevicePixels �� Triggers P� Property P� Value �� 
TargetName �� Property �� Value  Buttons �� 
TargetType �� Triggers N� EnterActions N� ExitActions��%\  &	        &	 �    �� 5   
   " ��6*   .R�5      �� $ Border��6   $ 5��6%   ���#23272A���#23272A$��1q�6a    . ._�5      �� $��Center=�6#   $��Center=�6@   5       5       P� 5!       �@J�IsMouseOver . . �5"      �� $ Border��63    � �� �#2a4a5b6G   �� 5#      $ Border��64    � �� �#26a0da6H   �� 5$       �@�Cursor$
 Hand��6/   5%      5'      �� 5(   
   " A�6    .�5)      ��  �@J�Opacity$
 0.25Q�6(    5*      P� 5+       �@J�IsMouseOver .  5,      �� 5-      .��5.      �� .��5/   "   W� $ Opacity�62   $
 1X�50      $ 0:0:0.2D�6   51      52       54      �� 55      .��56      �� .��57   "   W� $ Opacity�62   $

 0.25X�58      $ 0:0:0.2D�6   59      5:      5<      5>      5?      .��5@      �� ���#2C2F33$ 10��6"   ._�5A   
   � .+�5B      �� $��Images/SkEditor.png��5C       �� BitmapScalingMode$ HighQuality=�5D      $	��Top=�5E      $
��Left=�5F       J� RenderTransformOrigin$ 28.887,-0.097&�5G      $��26��5H      $��	10,10,0,0q�5I      $��23��5J      $��2��6   �� 5K      -   5         ��Name$ closeButton��5K      $��Images/close2.png��5L      $ HighQuality=�5M      $ 28.887,-0.097&�5N      $��20��5O      $��0,7,10,0q�5P      $��20��5Q       � Cursor$
 Hand��6   $��1��6R   $��Right=�6b   $	��Top=�6~   6�   �� 5R      -   5          ��Name$  languageComboBox��5R      $
��Left=�61   $��138,113,0,0q�6L   $	��Top=�6a   $	��120��6y   .@�5S      �� $��English��6   �� 5T      $��Polski��6   5U      �� 5V      -   5        ! ��Name$! languageText��5V      $
��Left=�6.   $��
140,92,0,0q�6I   $
��Wrap=�6]   $��Language��6q   $	��Top=�6�   
�������6�   �� 5W      -   5        $! versionText��5W      $
��Left=�6-   $��366,210,0,0q�6H   $
��Wrap=�6]   $
��v1.0��6q   $	��Top=�6}   ���	#3FFFFFFF6�   5X      5Y      5Z      