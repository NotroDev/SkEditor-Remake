   M S B A M L   `   `   `  ����I  ESkEditorRemake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SkEditorRemakeSkEditorRemake  5   	   $    SkEditorRemake.ChangelogWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Ixamanimation0crl-namespace:Xamanimation;assembly=Xamanimation     5   	   .localclr-namespace:SkEditorRemake     5   	   ^ ZICSharpCode.AvalonEdit, Version=6.1.2.30, Culture=neutral, PublicKeyToken=9cc39be672370310?
avalonedit.http://icsharpcode.net/sharpdevelop/avalonedit  64   -   5          �Name$  changelogThisWindow��5   	    � Title$ SkEditor Remake��5
   	    � Icon$ Images/SkEditor.ico��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	   
������  � AllowsTransparency .  � WindowStyle$
 None=�5   	   $��550.734��5   	   $	��338��5   	    � Triggers 5      :� 5   
    :� RoutedEvent$ Window.Loaded��6   .[�5      �� .��5      �� .��5      W� 	 �� TargetProperty$	 Opacity�6&   
 W� From$
 0X�6J   	 W� To$ 1X�6S    g� Duration$ 0:0:0.2D�6Z    g� FillBehavior$ HoldEnd=�6m   5      5      5       � 	Resources 5         Button1 �� 
TargetType ��Name �� CornerRadius J� SnapsToDevicePixels �� Triggers P� Property P� Value �� 
TargetName �� Property �� Value  Buttons �� 
TargetType �� Triggers N� EnterActions N� ExitActions  ScrollBarThumb � RowDefinitions ]�Name ]� Thumb��%�  &	        &	 �    &	 H    '�� l    7  �� 5   
   " ��6*   .R�5      �� $ Border��6   $ 5��6%   ���#23272A���#23272A$��1q�6a    . ._�5      �� $��Center=�6#   $��Center=�6@   5        5!      P� 5"       �@J�IsMouseOver . . �5#      �� $ Border��63    � �� �#2a4a5b6G   �� 5$      $ Border��64    � �� �#26a0da6H   �� 5%       �@�Cursor$
 Hand��6/   5&      5(      �� 5)   
   " A�6    .�5*      ��  �@J�Opacity$
 0.25Q�6(    5+      P� 5,       �@J�IsMouseOver .  5-      �� 5.      .��5/      �� .��50   "   W� $	 Opacity�62   $ 1X�51      $ 0:0:0.2D�6   52      53       55      �� 56      .��57      �� .��58   "   W� $	 Opacity�62   $
 0.25X�59      $ 0:0:0.2D�6   5:      5;      5=      5?      �� 5@   
   " n�6   .�5A      ��  � �� 5B      �� 5C      " n�6&   .R�5D      �� $ 2��6!   ���#5959595E      5F      5H      �� 5I       �@J�Opacity$	 0.4Q�6(    5J      P� 5K       �@J�IsMouseOver .  5L      �� 5M      .��5N      �� .��5O   "   W� $	 Opacity�62   $
 0.75X�5P      $ 0:0:0.2D�6   5Q      5R       5T      �� 5U      .��5V      �� .��5W   "   W� $	 Opacity�62   $	 0.4X�5X      $ 0:0:0.2D�6   5Y      5Z      5\      5^      �� 5`   
   " ��6   .�5a      ��  � �� 5b      �� 5c      " ��6&   .R�5d      �  5e      �� 5f   "   $��0.00001* �60   .+�5h      �� $��1��6%   ]� 5i      $ 
PART_Track��6$   $��1��68   ��.  5j   "   n� 5k   &   8��  $��1,0,1,0q�6T   5m      5n      5o      5q      5r      5s      .��5t      �� ���#2C2F33$ 10��6"   ._�5u   
   � .+�5v      �� $��Images/SkEditor.png��5w        �� BitmapScalingMode$  HighQuality=�5x      $	��Top=�5y      $
��Left=�5z      ! J� RenderTransformOrigin$! 28.887,-0.097&�5{      $��26��5|      $��	10,10,0,0q�5}      $��23��5~      $��2��6   �� 5      -   5        " ��Name$" closeButton��5      $��Images/close2.png��5�      $  HighQuality=�5�      $! 28.887,-0.097&�5�      $��20��5�      $��0,7,10,0q�5�      $��20��5�      # � Cursor$
# Hand��6   $��1��6R   $��Right=�6b   $	��Top=�6~   6�   �� 5�      ��. $��10,53,10,21q�63   .��5�      �� -   5        $ ��Name$$ changelogTextblock��5�      $0��*/SkEditorRemake;component/Fonts/#Open Sans)�68   $
��Left=�6p   $
��Wrap=�6�   $��No internet connection��6�   $	��Top=�6�   
�������$��15(�6�   $
��Auto=�6  5�      �� 5�      -   5        $$ loadText��5�      $
��Left=�6*   $��
10,317,0,0q�6E   $
��Wrap=�6Y   $
��Load��6m   $	��Top=�6y   ���	#FF919BCD$0��*/SkEditorRemake;component/Fonts/#Open Sans)�6�   $��12(�6�   $	��168��6�   6~  5�      5�      5�      