   M S B A M L   `   `   `  ����  Cs_Notas$    Cs_Notas.Windows.ConsultarAtos   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Consultar Escrituras��5      $��629.429��6"   $	��873��63    � ShowInTaskbar .   � 
ResizeMode$ NoResize=�6U    � WindowStartupLocation$ CenterOwner=�6k    � Icon$+ %/Cs_Notas;component/Imagens/Notas.ico��6�    � WindowStyle$ ThreeDBorderWindow=�6�   .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF81F1F1��6   	 � Offset$	 0Q�61   � 5	      $ 	#FFBCC0C3��6   $	 1Q�61   5
      .+�5   
   � $��74��6   $��
10,5,273,0q�6   $	��Top=�6/   ���	#FF008BFF.+�5      � $��5q�6   ���	#FFA2C8FF.+�5      �� -   5        
 ��Name$
 cmbTipoConsulta��5   )   $��34��6   $��9,28,416,10q�6B   $��16(�6�   .@�5      �� $
��DATA��6#   �� 5      $��LIVRO��6#   �� 5      $	��ATO��6#   �� 5      $
��SELO��6#   �� 5      $��PARTICIPANTE��6#   5      �� 5      $��Tipo Consulta:��6   $
��Left=�61   $��9,1,0,0q�6L   $	��Top=�6]   $	��139��6u   $��27��6�   (  "System.Windows.Controls.DatePicker  5      -   5        $��dpInicio��5      $��179,28,275,0q�6-   $	��Top=�6C   $��26��6[     5      -   5        $��dpFim��5      $��345,28,111,0q�6*   $	��Top=�6@   $��26��6X   �� 5      -   5        $��	lblInicio��5      $��Início:��6)   $
��Left=�6;   $��	179,2,0,0q�6V   $	��Top=�6i   $	��102��6�   �� 5      -   5        $��lblFim��5      $
��Fim:��6&   $
��Left=�65   $��	345,2,0,0q�6P   $	��Top=�6c   $	��102��6{   �� 5      -   5         ��Name$ btnConsultarAto��5      $��0q�62   $��0q�6>    � Cursor$
 Hand��6R    � ToolTip$ 	Consultar��6`   $��490,10,10,0q�6t   $��44��6�   $	��Top=�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   ��5      �� 5      ��5      �� 5      .R�5       �� 
���   �$��Center=�6<   $��Center=�6Y   $��0q�6u    �� Padding$ 0q�6�   $��40��6�   $��57��6�   ��5!   "   �� 5"   &    �� ImageSource$1 +/Cs_Notas;component/Imagens/Lupa grande.png��61   ��5$   "   �� 5%   &    �� 
TargetType" ��6,    �� Triggers 5&   *   P� 5'   .    P� Property �@J�IsMouseOver P� Value . . �5(   2   ��  �� Property � �� �� Value
 ���� 6P   5)   /   5+   '   5-      5.      50      �� 51      -   5        $��txtConsultar��51      $
��Left=�6.   $��26��6I   $��
175,28,0,0q�6U    �� CharacterCasing$ Upper=�6i    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��310��6�   $��14(�6�   6�   52      53      � 54   
   $	��249��6   $��
10,84,10,0q�6   $	��Top=�60   ���	#FF573A89.+�55      � $��5q�6   ���	#FFA2C8FF.+�56      &   System.Windows.Controls.DataGrid  -	   5          Name$ dataGridConsultarAtos��56   �      AutoGenerateColumns .  $
 Hand��67    �� AlternationCount$ 2��6E      RowBackground
 �����   AlternatingRowBackground �	#FFC1A0F1   
IsReadOnly .    SelectionMode$ Single=�6�     J� 	AllowDrop  .  !   CanUserResizeRows! .  "   SelectionUnit$" FullRow=�6	  #   ClipboardCopyMode$
# None=�6!  $$   HorizontalScrollBarVisibility$
$ Auto=�6:  % � UseLayoutRounding% . ��. &   GridLinesVisibility$
& None=�6  $' �� IsSynchronizedWithCurrentItem$' FalseY�6*  ��6x  Z� (   RowStyle( 57      �� 58      )  #System.Windows.Controls.DataGridRow"  6    .�59      -
   5        5:      )   	CellStyle) 5<      �� 5=      *  $System.Windows.Controls.DataGridCell"  6     5>      P� 5?   "    �@ 
IsSelected . . �5@   &   ��  � �� �	#FF0086FF6C   5A   #   5C      * � ContextMenu* 5E      �� 5F      -   5        $��menuAtos��5F   T   + �� 
IsSelected+ . , � ForceCursor, . .@�5G      m� -   5        $��MenuItemRemoverSelo��5G   �   $��Remover Selos��6'   $��Center=�6>   $��Center=�6[   $��Center=�6   $��Center=�6�   - m� Icon- 5H   "   �� 5I   &   $2��,/Cs_Notas;component/Imagens/RemoverSelos.png��6,   $��21��6b   $��21��6n   5K      5Q      .   Columns. 5S      0  *System.Windows.Controls.DataGridTextColumn  5T      ,  &System.Windows.Controls.DataGridColumn/   Header$
/ Data��6-   0   Width5  /System.Windows.Controls.DataGridLengthConverter$0 70 6;   1   CanUserResize1 .  1  +System.Windows.Controls.DataGridBoundColumn2   Binding2 6F   �� *DataAtoRegistro+3 �� StringFormat$3 
dd/MM/yyyy��6�     5U      $/ Natureza��6-   $	0 250 6?   1 .  4   
Visibility$4 Visible=�6   2 6K   �� *	Descricao+6     5V      $/ Livro��6-   $0 90 6<   1 .  $4 Visible=�6�   2 6G   �� *LivroEscritura+6�     5W      $/ Fls. Início��6-   $0 80 6B   1 .  $4 Visible=�6�   2 6M   �� *FolhasInicio+6�     5X      $/ Fls. Fim��6-   $0 80 6?   1 .  $4 Visible=�6   2 6J   �� *	FolhasFim+6     5Y      $	/ Ato��6-   $0 80 6:   1 .  $4 Visible=�6z   2 6E   �� *	NumeroAto+6z     5Z      $
/ Selo��6-   $0 90 6;   1 .  $4 Visible=�6~   2 6F   �� *SeloEscritura+6~     5[      $/ 
Aleatório��6-   $0 60 6@   1 .  2 6K   �� *	Aleatorio+6i   5^      � 5_      $	��148��6   $��-5,275,-5,-184q�6$   $	��Top=�6<   ���	#FF89503A.+�5`      � $��5q�6   ���	#FFA2C8FF.+�5a        -   5        $ dataGridParticipantes��5a   �    .  $
 Hand��6?   $ 2��6M   
 ����� �	#FFFFB68D . $ Single=�6�     .  5   HeadersVisibility$	5 All=�6�   ! .  $" FullRow=�6)  $
& None=�6A  $# ExcludeHeader=�6\  $
$ Auto=�6~  % . ��. ��6�  Z� ( 5b      �� 5c   "   "  6(   .�5d   &   -   5        5e   #   ) 5g      �� 5h   "   "  6(    5i   &   P� 5j   *    �@ 
IsSelected . . �5k   .   ��  � �� �	#FF0086FF6K   5l   +   5n   #   . 5p        5q   "   $/ 	Id Série��65   $0 70 6G   1 .  $4 Hidden=�6�   2 6R   �� *NomeId+6�     5r   "   $
/ Nome��65   $	0 350 6C   1 .  2 6O   �� *Nome+6h     5s   "   $/ Qualificação��65   $	0 170 6K   1 .  2 6W   �� *	Descricao+6u     5t   "   $	/ CPF��65   $	0 120 6B   1 .  2 6N   �� *	Documento+6l     5u   "   $/ RG��65   $	0 170 6A   1 .  2 6M   �� *Rg+6d   5w      5x      5y      5z      5{      � 5|   
   ���	#FF81F1F1$��70��6&   $��Bottom=�62   .+�5}      �� -   5        $ 	btnMinuta��5}      $��0q�6(   $��0q�64   $
 Hand��6H   $ Minuta��6V   $��	599,5,0,0q�6g   $
��Left=�6z   $��51��6�   $��38��6�   $	��Top=�6�   $ 0.524,0.468&�6�   ��5~      �� 5      ��5�      �� 5�      .R�5�      �� 
���   �$��Center=�68   $��Center=�6U   $��0q�6q   $ 0q�6|   $��35��6�   $��47��6�   ��5�      �� 5�   "   $, &/Cs_Notas;component/Imagens/Minuta.png��6-   ��5�      �� 5�   "   " ��6(    5�   &   P� 5�   *    �@J�IsMouseOver . . �5�   .   ��  � ��
 ���� 6L   5�   +   5�   #   5�      5�      5�      �� 5�      $��Minuta��6   $
��Left=�6%   $��Center=�6@   $��
599,43,0,0q�6d   $	��Top=�6x   $��51��6�   $��27��6�   �� 5�      -   5        $ btnComplemento��5�      $��0q�6-   $��0q�69   $
 Hand��6M   $  Complemento de Emolumentos��6[   $��	693,5,0,0q�6�   $
��Left=�6�   $��51��6�   $��38��6�   $	��Top=�6�   $ 0.524,0.468&�6�   ��5�      �� 5�      ��5�      �� 5�      .R�5�      �� 
���   �$��Center=�68   $��Center=�6U   $��0q�6q   $ 0q�6|   $��35��6�   $��47��6�   ��5�      �� 5�   "   $1 +/Cs_Notas;component/Imagens/Complemento.png��6-   ��5�      �� 5�   "   " ��6(    5�   &   P� 5�   *    �@J�IsMouseOver . . �5�   .   ��  � ��
 ���� 6L   5�   +   5�   #   5�      5�      5�      �� 5�      $��Complemento��6   $
��Left=�6*   $��Center=�6E   $��
674,43,0,0q�6i   $	��Top=�6}   $��89��6�   $��27��6�   �� 5�      -   5        $ btnSelarAto��5�      $��0q�6*   $��0q�66   $
 Hand��6J   $ Selar ato selecionado��6X   $��	787,5,0,0q�6x   $
��Left=�6�   $��51��6�   $��38��6�   $	��Top=�6�   $ 0.524,0.468&�6�   ��5�      �� 5�      ��5�      �� 5�      .R�5�      �� 
���   �$��Center=�68   $��Center=�6U   $��0q�6q   $ 0q�6|   $��35��6�   $��47��6�   ��5�      �� 5�   "   $+ %/Cs_Notas;component/Imagens/Selar.png��6-   ��5�      �� 5�   "   " ��6(    5�   &   P� 5�   *    �@J�IsMouseOver . . �5�   .   ��  � ��
 ���� 6L   5�   +   5�   #   5�      5�      5�      �� 5�      $��	Selar Ato��6   $
��Left=�6(   $��Center=�6C   $��
768,43,0,0q�6g   $	��Top=�6{   $��89��6�   $��27��6�   5�      �� 5�   
   $��PARTICIPANTES��6   $��Center=�6(   $	��Top=�6L   $	��Top=�6d   $
��Left=�6�   $��
10,337,0,0q�6�   $��28��6�   $	��847��6�   $��18(�6�   ���	#FF89503A$
��Bold"�6�   $��Italic$�6  $��Cooper Black)�6  �� 5�   
   -   5        $ btnExcluirAto��5�      $��0q�6(   $��15��64   $��0q�6B   $
 Hand��6V   $ Excluir Ato��6d   $��	750,5,0,0q�6z   $
��Left=�6�   $��76��6�   $��48��6�   $	��Top=�6�   $ 	0.5,0.459&�6�   ��5�      �� 5�      ��5�      �� 5�      .R�5�      �� 
���   �$��Center=�64   $��Center=�6Q   $��0q�6m   $ 0q�6x   $��38��6�   $��55��6�   ��5�      �� 5�      $0 */Cs_Notas;component/Imagens/ExcluirAto.png��6)   ��5�      �� 5�      " ��6$    5�   "   P� 5�   &    �@J�IsMouseOver . . �5�   *   ��  � ��
 ���� 6H   5�   '   5�      5�      5�      5�      �� 5�   
   -   5        $ btnAlterarAto��5�      $��14��6(   $��0q�66   $��0q�6B   $
 Hand��6V   $ Alterar Ato��6d   $��	652,5,0,0q�6z   $
��Left=�6�   $��76��6�   $��48��6�   $	��Top=�6�   ��5�      �� 5�      ��5�      �� 5�      .R�5�      �� 
���   �$��Center=�64   $��Center=�6Q   $��0q�6m   $ 0q�6x   $��38��6�   $��55��6�   ��5�      �� 5�      $/ )/Cs_Notas;component/Imagens/EditarAto.png��6)   ��5�      �� 5�      " ��6$    5�   "   P� 5�   &    �@J�IsMouseOver . . �5�   *   ��  � ��
 ���� 6H   5�   '   5�      5�      5�      5�      �� 5�   
   -   5        6 ��Name$6 lblFim_Copy��5�      $��Alterar Ato��6%   $��Center=�6;   $
��Left=�6_   $��
652,53,0,0q�6z   $	��Top=�6�   $��76��6�   �� 5�   
   -   5        $6 lblFim_Copy1��5�      $��Excluir Ato��6&   $��Center=�6<   $
��Left=�6`   $��
750,53,0,0q�6{   $	��Top=�6�   $��76��6�   5�      7 � 	Resources7 5�         Flat_ComboBox  ComboBoxToggleButton8 �� 
TargetType9 � ColumnDefinitions: ��Name; �� CornerRadius< F�Name= �� Triggers> �� 
TargetName  ComboBoxTextBox? �� 	ClickMode@ d� 	IsCheckedA �� PathB �� ModeC �� RelativeSourceD J� IsHitTestVisibleE �� SelectionBoxItemF �� SelectionBoxItemTemplateG ��NameH �� 
IsReadOnlyI �� 
IsReadOnlyJ �� IsDropDownOpenK � AllowsTransparencyL J� SnapsToDevicePixelsM � ActualWidthN �� MaxDropDownHeightO K� IsItemsHost-	  'System.Windows.Input.KeyboardNavigationP 	  DirectionalNavigationQ P� 
SourceNameR �� Padding��%?  &	        &	 J    &	 I    '�� �    7  7  '�� �    �� 5�   
   " ��6   .�5�      ��  � ��$ Stretch=�64   �� 5�       � ��$	 Top=�62   �� 5�       � ��$ 30��6)   �� 5�       �@J�SnapsToDevicePixels . 6>   �� 5�       � ��$ Disabled=�6K   �� 5       � ��$
 Auto=�6I   �� 5      � �� . 6>   �� 5      � ��
 �   �67   �� 5      �@�FocusVisualStyle 6B   Z� �� 5      � ��$ 0q�60   �� 5      � ��
 �����6+    5     P� 5      �@J�IsMouseOver . . �5	     ��  � ��
 ��·�63   5
     5     �� 5  
   "8 d�67   .R�5     � 9 5     �� 5     �� 5     $��20 �6'   .+�5     �� $: Border��5     $��2��5     $; 2��5     ���	#FF72A8A3���#404040$��1q�5     �� 5     $��0��5     $; 2,0,0,2��5     $��1q�5      ���#FFFFFF���#404040$��0,0,1,0q�5#     F� 5$     $< Arrow��5%     $��1��5&     ���#404040$��Center=�5(     $��Center=�5)     "����        � 	=  	= � z     	5*     5+     = 5,     P� 5-      �@J�IsMouseOver . . �5.     �� $> Border��6    � �� �#8080806G   5/     P� 50      �@d�	IsChecked$
 trueY�6<   . �51     �� $> Border��6    � �� �#E0E0E06G   52     P� 53      � {� .  . �54     �� $> Border��6    � �� �#EEEEEE6G   �� 55     $> Border��6    � �� �#AAAAAA6H   �� 56      � �� �#88888863   �� 57     $> Arrow��6    � �� �#8888886@   58     5:     �� 5<  
   "8 ��62   .R�5=     �� $: PART_ContentHost��6   |�.  #��z��6A   5>     �� 5@  
   " ��6*   .�5A     ��  �@J�SnapsToDevicePixels . 64   �� 5B      �@�OverridesDefaultStyle . 66   �� 5C      � ��$
 Auto=�6K   �� 5D      � ��$
 Auto=�6I   �� 5E      � �� . 6>   �� 5F      � ��$ 30��6)   �� 5G      � ��$ 20��6*   �� 5H      � �� 5I     �� 5J     "8 ��6&   .R�5K     � .+�5L     d� $��ToggleButton��5M  	   8��  $��2��5O  	   |�.  $? Press=�5R  	   @ 5Q  	   �� $A IsDropDownOpen�$B TwoWay=�C �� *TemplatedParent+5S     �� 5T     $��ContentSite��5U  	   D .  #��zE 5W  	   #��zF 5X  	   #��z��5Y  	   $��3,3,23,3q�5Z  	   $��Center=�5[  	   $
��Left=�5\  	   �� 5]     $G PART_EditableTextBox��6&   8�� $
��Left=�5`  	   $��Center=�5a  	   $��3,3,23,3q�5b  	   |�. 
������ $y�Hidden=�5e  	   #I zH 5f  	   ��5^  	   Z� 5f  	   � 5g     $��Popup��5h  	   $��Bottom=�5i  	   #��zJ 5j  	   K . |�.  $��Slide=�5m  	   .��5n  "   � $��DropDown��5o     L . #��zM 5q     #��zN 5r     .+�5s  &   �� $: DropDownBorder��5t     ���#FFFFFF$��1q�5v     ���#8888885w     �� 5x  &   $��4,6,4,6q�63   L . .��5y  *   �� O . $P 	Contained=�6H   5z  '   5{  #   5|     5}     = 5~     P� 5      �@��HasItems .  . �5�  "   �� $> DropDownBorder��6)    � ��$ 95��6Z   5�     P� 5�      � {� .  . �5�  "   ��  � �� �#8888886?   5�     P� 5�      �@��
IsGrouping . . �5�  "   ��  � �� .  6R   5�     P� 5�     $Q Popup��6&    �@�AllowsTransparency . . �5�  "   �� $> DropDownBorder��6)    �@��CornerRadius$ 4��6]   �� 5�  "   $> DropDownBorder��6)    � ��$ 0,2,0,0q�6W   5�     P� 5�      �@��
IsEditable . . �5�  "   ��  � �� .  6>   �� 5�  "   $> PART_EditableTextBox��6)    � y�$ Visible=�6a   �� 5�  "   $> ContentSite��6)    � y�$ Hidden=�6X   5�     5�     5�      5�     5�     �� 5�  
   " ��6.   .�5�     ��  �@J�SnapsToDevicePixels . 64   �� 5�      �@�OverridesDefaultStyle . 66   �� 5�      � �� 5�     �� 5�     "8 ��6&   .R�5�     �� $��Border��5�     $R 2q�5�     L . ._�5�     �� 5�     = 5�     P� 5�      �@��IsHighlighted . . �5�  "   �� $> Border��6)    � �� �#DDDDDD6S   5�     P� 5�      � {� .  . �5�  "   ��  � �� �#8888886?   5�     5�     5�     5�     5�     5�     