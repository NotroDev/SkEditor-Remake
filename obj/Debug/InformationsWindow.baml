   M S B A M L   `   `   `  ����I  ESkEditorRemake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SkEditorRemakeSkEditorRemake  5   	   '    !SkEditorRemake.InformationsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:SkEditorRemake     5   	   ^ ZICSharpCode.AvalonEdit, Version=6.1.2.30, Culture=neutral, PublicKeyToken=9cc39be672370310?
avalonedit.http://icsharpcode.net/sharpdevelop/avalonedit  64   -   5          � Title$  SkEditor Remake��5	   	    � Icon$ Images/SkEditor.ico��5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	   
������  � AllowsTransparency .  � WindowStyle$
 None=�5   	   $��474.734��5   	   $	��288��5   	    � Triggers 5      :� 5   
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
 Hand��6   $��1��6R   $��Right=�6b   $	��Top=�6~   6�   �� 5R      -   5        $��	Open Sans)�5R      $��16(�6/     � UseLayoutRounding  .  $��0,10,0,0q�6W   $��SkEditor Remake��6i   ���	#FFDDDDDD$��Center=�6�   $	��Top=�6�   $��22��6�   $ 
0.78,0.447&�6�   6�   �� 5S      -   5        ! ��Name$! ContactText��5S      $
��Left=�6-   $��
10,181,0,0q�6H   $
��Wrap=�6\   $��Contact��6p   $	��Top=�6   
�������$0��*/SkEditorRemake;component/Fonts/#Open Sans)�6�   $��16(�6�   $	��377��6�   �� 5T      -   5        $! ContactSubText��5T      $
��Left=�60   $��
10,208,0,0q�6K   $
��Wrap=�6_   $	��Top=�6s   
�������$0��*/SkEditorRemake;component/Fonts/#Open Sans)�6�   $��40��6�   $	��377��6�   �� 6�   $�Subtext��6�   �� 6  5U      6'   �� 5V      -   5        $! GeneralInfoText��5V      $
��Left=�61   $��	10,59,0,0q�6L   $
��Wrap=�6_   $
��Info��6s   $	��Top=�6   
�������$0��*/SkEditorRemake;component/Fonts/#Open Sans)�6�   $��16(�6�   $	��377��6�   �� 5W      -   5        $! GeneralInfoSubText��5W      $
��Left=�64   $��	10,86,0,0q�6O   $
��Wrap=�6b   $��Subtext��6v   $	��Top=�6�   
�������$0��*/SkEditorRemake;component/Fonts/#Open Sans)�6�   $��95��6�   $	��422��6�   �� 5X      -   5        $! ChangelogText��5X      $
��Left=�6/   $��
10,256,0,0q�6J   $
��Wrap=�6^   $��	Changelog��6r   $	��Top=�6�   ���	#FF919BCD$0��*/SkEditorRemake;component/Fonts/#Open Sans)�6�   $��16(�6�   $	��168��6�   6b  5Y      5Z      5[      