   M S B A M L   `   `   `  ����I  ESkEditorRemake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SkEditorRemakeSkEditorRemake  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       SkEditorRemake.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:SkEditorRemake     5   	   ^ ZICSharpCode.AvalonEdit, Version=6.1.2.30, Culture=neutral, PublicKeyToken=9cc39be672370310?
avalonedit.http://icsharpcode.net/sharpdevelop/avalonedit  5   	   3System&clr-namespace:System;assembly=mscorlib  5   	   -   5          � Title$  SkEditor Remake��5   	   $	��450��5   	   #��Z��5   	   $	��450��5   	   $	��800��5   	   $	��800��5   	    � Icon$ Images/SkEditor.ico��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ 	CanResize=�5   	   
������  � WindowStyle$
 None=�5   	    � AllowsTransparency . '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      GlassFrameThickness$ 0q�6      CornerRadius$ 5��6/   	   CaptionHeight$	 0Q�6@   
   UseAeroCaptionButtons
 .     ResizeBorderThickness$ 7q�6p    � 	Resources 5         Roboto-Mono �� Property �� Value  ContextMenu �� 
TargetType �� CornerRadius J� SnapsToDevicePixels  MenuItem ��Name J� IsManipulationEnabled � ForceCursor � OverridesDefaultStyle � AllowsTransparency �� RelativeSource �� Triggers P� Property P� Value �� 
TargetName �� 
TargetType  ScrollBarThumb �� Triggers N� EnterActions �� TargetProperty	  W� To! g� Duration" N� ExitActions# � RowDefinitions$ ]�Name% ]� Thumb��%$  &	        &	 N     &	 �     &	 ~    '�� �    7  �� 5   
   .�5      ��  � ��$ Fonts/#Roboto Mono)�67   5      �� 5   
   " ��6.   .R�5      �� $ 5��6   ���	#FF2C2F33$��1q�6>   ���	#FF2C2F33 . ._�5       �� 5!      5"      �� 5#   
   " m�6+   .R�5$      �� $ Border��6   #��z��6%   #��z��6Q   #��z��6�    . ._�5%      � .+�5&      �� #��z��6'   #��z��6J    .   .  ��.   .  6�   � 5'       . #��� -�6�   ��66   �� *IsSubmenuOpen+ �� *TemplatedParent+.��5(      �� $ 5��6!   ���	#FF2C2F33$��1q�6J   ���	#FF2C2F33 .  .  ._�5)      �� 5*      5+      5,      5-       5.      P� 5/       �@m�IsHighlighted . . �50      �� $ Border��63    � �� �#2a4a5b6G   �� 51      $ Border��64    � �� �#26a0da6H   �� 52       �@�Cursor$
 Hand��6/   53      55      �� 57   
   " n�6   .�58      ��  � �� 59      �� 5:      " n�6&   .R�5;      �� $ 2��6!   ���#5959595<      5=      5?      �� 5@       �@J�Opacity$	 0.4Q�6(    5A      P� 5B       �@J�IsMouseOver .  5C      �� 5D      .��5E      �� .��5F   "   W� $ Opacity�62   $
  0.75X�5G      $! 0:0:0.2D�6   5H      5I      " 5K      �� 5L      .��5M      �� .��5N   "   W� $ Opacity�62   $	  0.4X�5O      $! 0:0:0.2D�6   5P      5Q      5S      5U      �� 5W   
   " ��6   .�5X      ��  � �� 5Y      �� 5Z      " ��6&   .R�5[      � # 5\      �� 5]   "   $��0.00001* �60   .+�5_      �� $��1��6%   ]� 5`      $$ 
PART_Track��6$   $��1��68   ��. % 5a   "   n� 5b   &   8��  $��1,0,1,0q�6T   5d      5e      5f      5h      5i      5j      & J� CommandBindings& 5k      )  #System.Windows.Input.CommandBinding  5l   
   -   5        '   Command$' ApplicationCommands.New��5l      6;     5m   
   -   5        $' ApplicationCommands.Open��5m      6<     5n   
   -   5        $' ApplicationCommands.Save��5n      6<     5o   
   -   5        $ ' ApplicationCommands.SaveAs��5o      6>     5p   
   -   5        $' ApplicationCommands.Close��5p      6=   ( J� InputBindings( 5r      �� 5s   
   ) �� 	Modifiers$
) Ctrlf�6   
* �� Key$* N��6&   + �� Command$+ ApplicationCommands.New��6.   �� 5t   
   $
) Ctrlf�6   $* O��6&   $+ ApplicationCommands.Open��6.   �� 5u   
   $
) Ctrlf�6   $* S��6&   $+ ApplicationCommands.Save��6.   �� 5v   
   $) 
Ctrl+Shiftf�6   $* S��6,   $ + ApplicationCommands.SaveAs��64   �� 5z   
   $
) Ctrlf�6   $* W��6&   $+ ApplicationCommands.Close��6.   .��5|      �� -   5        $ Border��5|      ���#2C2F33$ 10��62   ._�5}   
   � -   5        , �Name$, 
editorGrid��5}      - � ColumnDefinitions- 5~      �� 5      $
��587* �6#   �� 5�      $
��213* �6#   # 5�      �� 5�      $	��88* �6    �� 5�      $
��137* �6    .+�5�      �� -	   5        . ��Name$. SkEditorLogo��5�      $��Images/SkEditor.png��6*   $	��Top=�6G   $
��Left=�6_   / J� RenderTransformOrigin$/ 50.887,-0.097&�5�      $��27��64   $��10,7,0,0q�6@   $��27��6R   0 �� BitmapScalingMode$0 HighQuality=�5�      6<   o� 5�      -
   5        1 o�Name$1 	MenuStrip��5�      
������ 
�������2 o� 
IsMainMenu2 . $��42,11,327,142q�6d   $��OpenSans)�6{   $��23��6�   .@�5�      m� -   5        3 m�Name$3 fileMenuStripItem��5�      
�������$
��File��6I   #��[ 6W   .@�5�      m� -   5        $3 newFileMenuItem��5�      4 � Cursor$
4 Hand��68   
�������$	��New��6Y   ���#2C2F33���#2C2F335 m� InputGestureText$5 Ctrl+N��6�   m� 5�      -   5        $3 openFileMenuItem��5�      $
4 Hand��69   
�������$
��Open��6Z   ���#2C2F33���#2C2F33$5 Ctrl+O��6�   m� 5�      -   5        $3 saveMenuItem��5�      $
4 Hand��65   
�������$
��Save��6V   ���#2C2F33���#2C2F33$5 Ctrl+S��6�   m� 5�      -   5        $3 saveAsMenuItem��5�      $
4 Hand��67   
�������$��Save As��6X   ���#2C2F33���#2C2F33$5 Ctrl+Shift+S��6�   �� 5�      m� 5�      -   5        $3 publishMenuItem��5�      $
4 Hand��68   
�������$��Publish Code��6Y   ���#2C2F33���#2C2F336�   �� 5�      m� 5�      -   5        $3 closeMenuItem��5�      $
4 Hand��66   
�������$��Close��6W   ���#2C2F33���#2C2F33$5 Ctrl+W��6�   m� 5�      -   5        $3 exitMenuItem��5�      $
4 Hand��65   
�������$
��Exit��6V   ���#2C2F33���#2C2F33$5 Alt+F4��6�   5�      m� 5�      -   5        $3 editMenuStripItem��5�      
�������$
��Edit��6I   #��[ 6W   .@�5�      m� -   5        $3 undoMenuItem��5�      $
4 Hand��65   
�������$
��Undo��6V   ���	#FF2C2F33���	#FF2C2F33$5 Ctrl+Z��6�   m� 5�      -   5        $3 redoMenuItem��5�      $
4 Hand��65   
�������$
��Redo��6V   ���	#FF2C2F33���	#FF2C2F33$5 Ctrl+Y��6�   �� 5�      m� 5�      -   5        $3 cutMenuItem��5�      $
4 Hand��64   
�������$	��Cut��6U   ���	#FF2C2F33���	#FF2C2F33$5 Ctrl+X��6�   m� 5�      -   5        $3 copyMenuItem��5�      $
4 Hand��65   
�������$
��Copy��6V   ���	#FF2C2F33���	#FF2C2F33$5 Ctrl+C��6�   m� 5�      -   5        $3 pasteMenuItem��5�      $
4 Hand��66   
�������$��Paste��6W   ���	#FF2C2F33���	#FF2C2F33$5 Ctrl+V��6�   �� 5�      m� 5�      -   5        $3 selectAllMenuItem��5�      $
4 Hand��6:   $��
Select all��6H   ���	#FF2C2F33���	#FF2C2F33$5 Ctrl+A��6�   5�      m� 5�      -   5        $3 otherMenuStripItem��5�      
�������$��Other��6J   #��[ 6Y   .@�5�      m� -   5        $3 settingsMenuItem��5�      $��Settings��69   6K   m� 5�      -   5        $3 informationsMenuItem��5�      $��About��6=   6L   5�      5�      �� 5�      -   5        $. closeAppButton��5�      $��Images/close2.png��5�      $0 HighQuality=�5�      $/ 28.887,-0.097&�5�      $��20��5�      $��0,7,10,0q�5�      $��20��5�      $
4 Hand��6   $��1��6U   $��Right=�6e   $	��Top=�6�   6�   �� 5�      -   5        $. minimizeButton��5�      $��Images/minimize2.png��5�      $0 HighQuality=�5�      $/ 28.887,-0.097&�5�      $��20��5�      $��0,7,60,0q�5�      $��20��5�      $
4 Hand��6   $��1��6U   $��Right=�6e   $	��Top=�6�   6�   �� 5�      -   5        $. maximizeButton��5�      $��Images/maximize2.png��5�      $0 HighQuality=�5�      $/ 28.887,-0.097&�5�      $��20��5�      $��0,7,35,0q�5�      $��20��5�      $
4 Hand��6   $��1��6U   6 J� Opacity$
6 0.98Q�6e   $��Right=�6t   $	��Top=�6�   6�   �� 5�      -    5        7 ��Name$7 tabControl1��5�      $��10,38,10,10q�6.   ���#1F1F1F$��2��6X   $��2��6l   $��0q�6�   ��6�   Z�  5�      8 ��Name��%�  '��       �� 5�      " ��6   .�5�      ��  � �� 5�      �� 5�   "   " ��62   .R�5�   &   � $��Panel��6+   .+�5�   *   �� $��Border��61   
�������$ 4,4,0,0��6W   $	��2,0q�6n   ._�5�   .   �� $8 ContentSite��6?   $��Center=�5�   )   $��Center=�5�   )   $��Header��5�   )   $
��10,2q�5�   )   5�   +   5�   '    5�   &   P� 5�   *    �@��
IsSelected .  . �5�   .   �� $ Panel��65    � �� �#1F1F1F6^   �� 5�   .   $ Panel��65    � ��
 �����6x   5�   +   P� 5�   *    �@��
IsSelected . . �5�   .   �� $ Panel��65    � �� �	#FF4C74E06^   �� 5�   .   $ Panel��65    � ��
 �����6x   5�   +   5�   #   5�      5�      5�      5�      5�      5�      5�      