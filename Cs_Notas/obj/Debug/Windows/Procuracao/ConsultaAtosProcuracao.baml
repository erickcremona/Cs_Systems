   M S B A M L   `   `   `  ����  Cs_Notas8    2Cs_Notas.Windows.Procuracao.ConsultaAtosProcuracao   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Consultar Procuração��5   
   $��629.429��6'   $	��873��68    � ShowInTaskbar .   � 
ResizeMode$ NoResize=�6Z    � WindowStartupLocation$ CenterOwner=�6p    � Icon$+ %/Cs_Notas;component/Imagens/Notas.ico��6�    � WindowStyle$ ThreeDBorderWindow=�6�   .��5      � ���	#FFBACDE8.+�5   
   � $��74��6   $��
10,5,273,0q�6   $	��Top=�6/   ���	#FF008BFF.+�5      � $��5q�6   ���	#FFA2C8FF.+�5      �� -   5         ��Name$ cmbTipoConsulta��5   )   $��34��6   $��9,28,416,10q�6B   $��16(�6�   .@�5	      �� $
��DATA��6#   �� 5
      $��LIVRO��6#   �� 5      $	��ATO��6#   �� 5      $
��SELO��6#   �� 5      $��PARTICIPANTE��6#   5      �� 5      $��Tipo Consulta:��6   $
��Left=�61   $��9,1,0,0q�6L   $	��Top=�6]   $	��139��6u   $��27��6�   (  "System.Windows.Controls.DatePicker  5      -   5        $��dpInicio��5      $��179,28,275,0q�6-   $	��Top=�6C   $��26��6[     5      -   5        $��dpFim��5      $��345,28,111,0q�6*   $	��Top=�6@   $��26��6X   �� 5      -   5        $��	lblInicio��5      $��Início:��6)   $
��Left=�6;   $��	179,2,0,0q�6V   $	��Top=�6i   $	��102��6�   �� 5      -   5        $��lblFim��5      $
��Fim:��6&   $
��Left=�65   $��	345,2,0,0q�6P   $	��Top=�6c   $	��102��6{   �� 5      -   5         ��Name$ btnConsultarAto��5      $��0q�62   $��0q�6>    � Cursor$
 Hand��6R   	 � ToolTip$	 	Consultar��6`   $��490,10,10,0q�6t   $��44��6�   $	��Top=�6�   
 J� RenderTransformOrigin$
 0.5,0.5&�6�   ��5      �� 5      ��5      �� 5      .R�5      �� 
���   �$��Center=�6<   $��Center=�6Y   $��0q�6u    �� Padding$ 0q�6�   $��40��6�   $��57��6�   ��5   "   �� 5   &    �� ImageSource$1 +/Cs_Notas;component/Imagens/Lupa grande.png��61   ��5   "   �� 5   &    �� 
TargetType" ��6,    �� Triggers 5    *   P� 5!   .    P� Property �@J�IsMouseOver P� Value . . �5"   2   ��  �� Property � �� �� Value
 ���� 6P   5#   /   5%   '   5'      5(      5*      �� 5+      -   5        $��txtConsultar��5+      $
��Left=�6.   $��26��6I   $��
175,28,0,0q�6U    �� CharacterCasing$ Upper=�6i    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��310��6�   $��14(�6�   6�   5,      5-      � 5.   
   $	��249��6   $��
10,84,10,0q�6   $	��Top=�60   ���	#FF573A89.+�5/      � $��5q�6   ���	#FFA2C8FF.+�50      &   System.Windows.Controls.DataGrid  -	   5          Name$ dataGridConsultarAtos��50   �      AutoGenerateColumns .  $
 Hand��67    �� AlternationCount$ 2��6E      RowBackground
 �����   AlternatingRowBackground �	#FFC1A0F1   
IsReadOnly .    SelectionMode$ Single=�6�    J� 	AllowDrop .     CanUserResizeRows .     SelectionUnit$ FullRow=�6	     ClipboardCopyMode$
 None=�6!  $    HorizontalScrollBarVisibility$
  Auto=�6:  ! � UseLayoutRounding! . ��. "   GridLinesVisibility$
" None=�6  $# �� IsSynchronizedWithCurrentItem$# FalseY�6*  ��6x  Z� $   RowStyle$ 51      �� 52      )  #System.Windows.Controls.DataGridRow"  6    .�53      -
   5        54      %   	CellStyle% 56      �� 57      *  $System.Windows.Controls.DataGridCell"  6     58      P� 59   "    �@ 
IsSelected . . �5:   &   ��  � �� �	#FF0086FF6C   5;   #   5=      & � ContextMenu& 5?      �� 5@      -   5        $��menuAtos��5@   T   ' �� 
IsSelected' . ( � ForceCursor( . .@�5A      m� -   5        $��MenuItemRemoverSelo��5A   �   $��Remover Selos��6'   $��Center=�6>   $��Center=�6[   $��Center=�6   $��Center=�6�   ) m� Icon) 5B   "   �� 5C   &   $2��,/Cs_Notas;component/Imagens/RemoverSelos.png��6,   $��21��6b   $��21��6n   5E      5K      *   Columns* 5M      0  *System.Windows.Controls.DataGridTextColumn  5N      ,  &System.Windows.Controls.DataGridColumn+   Header$
+ Data��6-   ,   Width5  /System.Windows.Controls.DataGridLengthConverter$, 70 6;   -   CanUserResize- .  1  +System.Windows.Controls.DataGridBoundColumn.   Binding. 6F   �� *DataLavratura+/ �� StringFormat$/ 
dd/MM/yyyy��6�     5O      $+ Descrição��6-   $	, 270 6@   - .  0   
Visibility$0 Visible=�6�   . 6L   �� *	Descricao+1 �� FallbackValue$1 PROCURAÇÃO��2 �� TargetNullValue$2 PROCURAÇÃO��6�     5P      $+ Livro��6-   $, 90 6<   - .  $0 Visible=�6w   . 6G   �� *Livro+6w     5Q      $+ Fls. Início��6-   $, 80 6B   - .  $0 Visible=�6�   . 6M   �� *FolhaInicio+6�     5R      $+ Fls. Fim��6-   $, 80 6?   - .  $0 Visible=�6~   . 6J   �� *
FolhaFim+6~     5S      $	+ Ato��6-   $, 80 6:   - .  $0 Visible=�6z   . 6E   �� *	NumeroAto+6z     5T      $
+ Selo��6-   $, 90 6;   - .  $0 Visible=�6u   . 6F   �� *Selo+6u     5U      $+ 
Aleatório��6-   $, 60 6@   - .  . 6K   �� *	Aleatorio+6i   5X      � 5Y      $	��148��6   $��-5,275,-5,-184q�6$   $	��Top=�6<   ���	#FF89503A.+�5Z      � $��5q�6   ���	#FFA2C8FF.+�5[        -   5        $ dataGridParticipantes��5[   �    .  $
 Hand��6?   $ 2��6M   
 ����� �	#FFFFB68D . $ Single=�6�    .  3   HeadersVisibility$	3 All=�6�    .  $ FullRow=�6)  $
" None=�6A  $ ExcludeHeader=�6\  $
  Auto=�6~  ! . ��. ��6�  Z� $ 5\      �� 5]   "   "  6(   .�5^   &   -   5        5_   #   % 5a      �� 5b   "   "  6(    5c   &   P� 5d   *    �@ 
IsSelected . . �5e   .   ��  � �� �	#FF0086FF6K   5f   +   5h   #   * 5j        5k   "   $+ 	Id Série��65   $, 70 6G   - .  $0 Hidden=�6�   . 6R   �� *NomeId+6�     5l   "   $
+ Nome��65   $	, 350 6C   - .  . 6O   �� *Nome+6h     5m   "   $+ Qualificação��65   $	, 170 6K   - .  . 6W   �� *	Descricao+6u     5n   "   $	+ CPF��65   $	, 120 6B   - .  . 6N   �� *	Documento+6l     5o   "   $+ RG��65   $	, 170 6A   - .  . 6M   �� *Rg+6d   5q      5r      5s      5t      5u      � 5v   
   
�������$��70��6"   $��Bottom=�6.   .+�5w      �� -   5        $ 	btnMinuta��5w      $��0q�6(   $��0q�64   $
 Hand��6H   $	 Minuta��6V   $��	599,5,0,0q�6g   $
��Left=�6z   $��51��6�   $��38��6�   $	��Top=�6�   $
 0.524,0.468&�6�   ��5x      �� 5y      ��5{      �� 5|      .R�5}      �� 
���   �$��Center=�68   $��Center=�6U   $��0q�6q   $ 0q�6|   $��35��6�   $��47��6�   ��5~      �� 5   "   $, &/Cs_Notas;component/Imagens/Minuta.png��6-   ��5�      �� 5�   "   " ��6(    5�   &   P� 5�   *    �@J�IsMouseOver . . �5�   .   ��  � ��
 ���� 6L   5�   +   5�   #   5�      5�      5�      �� 5�      $��Minuta��6   $
��Left=�6%   $��Center=�6@   $��
599,43,0,0q�6d   $	��Top=�6x   $��51��6�   $��27��6�   �� 5�      -   5        $ btnComplemento��5�      $��0q�6-   $��0q�69   $
 Hand��6M   $ 	 Complemento de Emolumentos��6[   $��	693,5,0,0q�6�   $
��Left=�6�   $��51��6�   $��38��6�   $	��Top=�6�   $
 0.524,0.468&�6�   ��5�      �� 5�      ��5�      �� 5�      .R�5�      �� 
���   �$��Center=�68   $��Center=�6U   $��0q�6q   $ 0q�6|   $��35��6�   $��47��6�   ��5�      �� 5�   "   $1 +/Cs_Notas;component/Imagens/Complemento.png��6-   ��5�      �� 5�   "   " ��6(    5�   &   P� 5�   *    �@J�IsMouseOver . . �5�   .   ��  � ��
 ���� 6L   5�   +   5�   #   5�      5�      5�      �� 5�      $��Complemento��6   $
��Left=�6*   $��Center=�6E   $��
674,43,0,0q�6i   $	��Top=�6}   $��89��6�   $��27��6�   �� 5�      -   5        $ btnSelarAto��5�      $��0q�6*   $��0q�66   $
 Hand��6J   $	 Selar ato selecionado��6X   $��	787,5,0,0q�6x   $
��Left=�6�   $��51��6�   $��38��6�   $	��Top=�6�   $
 0.524,0.468&�6�   ��5�      �� 5�      ��5�      �� 5�      .R�5�      �� 
���   �$��Center=�68   $��Center=�6U   $��0q�6q   $ 0q�6|   $��35��6�   $��47��6�   ��5�      �� 5�   "   $+ %/Cs_Notas;component/Imagens/Selar.png��6-   ��5�      �� 5�   "   " ��6(    5�   &   P� 5�   *    �@J�IsMouseOver . . �5�   .   ��  � ��
 ���� 6L   5�   +   5�   #   5�      5�      5�      �� 5�      $��	Selar Ato��6   $
��Left=�6(   $��Center=�6C   $��
768,43,0,0q�6g   $	��Top=�6{   $��89��6�   $��27��6�   �� 5�      -   5        $ btnAlterarAto��5�      $��14��6,   $��0q�6:   $��0q�6F   $
 Hand��6Z   $	 Alterar Ato��6h   $��23,5,0,0q�6~   $
��Left=�6�   $��51��6�   $��38��6�   $	��Top=�6�   ��5�      �� 5�      ��5�      �� 5�      .R�5�      �� 
���   �$��Center=�68   $��Center=�6U   $��0q�6q   $ 0q�6|   $��38��6�   $��55��6�   ��5�      �� 5�   "   $/ )/Cs_Notas;component/Imagens/EditarAto.png��6-   ��5�      �� 5�   "   " ��6(    5�   &   P� 5�   *    �@J�IsMouseOver . . �5�   .   ��  � ��
 ���� 6L   5�   +   5�   #   5�      5�      5�      �� 5�      -   5        4 ��Name$4 lblFim_Copy��5�      $��Alterar Ato��6)   $��Center=�6?   $
��Left=�6c   $��	10,43,0,0q�6~   $	��Top=�6�   $��76��6�   �� 5�      -   5        $ btnExcluirAto��5�      $��0q�6,   $��15��68   $��0q�6F   $
 Hand��6Z   $	 Excluir Ato��6h   $��	118,5,0,0q�6~   $
��Left=�6�   $��51��6�   $��38��6�   $	��Top=�6�   $
 	0.5,0.459&�6�   ��5�      �� 5�      ��5�      �� 5�      .R�5�      �� 
���   �$��Center=�68   $��Center=�6U   $��0q�6q   $ 0q�6|   $��38��6�   $��55��6�   ��5�      �� 5�   "   $0 */Cs_Notas;component/Imagens/ExcluirAto.png��6-   ��5�      �� 5�   "   " ��6(    5�   &   P� 5�   *    �@J�IsMouseOver . . �5�   .   ��  � ��
 ���� 6L   5�   +   5�   #   5�      5�      5�      �� 5�      -   5        $4 lblFim_Copy1��5�      $��Excluir Ato��6*   $��Center=�6@   $
��Left=�6d   $��
105,43,0,0q�6   $	��Top=�6�   $��76��6�   5�      �� 5�   
   $��PARTICIPANTES��6   $��Center=�6(   $	��Top=�6L   $	��Top=�6d   $
��Left=�6�   $��
10,337,0,0q�6�   $��28��6�   $	��847��6�   $��18(�6�   ���	#FF89503A$
��Bold"�6�   $��Italic$�6  $��Cooper Black)�6  5�      5 � 	Resources5 5�         Flat_ComboBox  ComboBoxToggleButton6 �� 
TargetType7 � ColumnDefinitions8 ��Name9 �� CornerRadius: F�Name; �� Triggers< �� 
TargetName  ComboBoxTextBox= �� 	ClickMode> d� 	IsChecked? �� Path@ �� ModeA �� RelativeSourceB J� IsHitTestVisibleC �� SelectionBoxItemD �� SelectionBoxItemTemplateE ��NameF �� 
IsReadOnlyG �� 
IsReadOnlyH �� IsDropDownOpenI � AllowsTransparencyJ J� SnapsToDevicePixelsK � ActualWidthL �� MaxDropDownHeightM K� IsItemsHost-	  'System.Windows.Input.KeyboardNavigationN 	  DirectionalNavigationO P� 
SourceNameP �� Padding��%?  &	        &	 J    &	 I    '�� �    7  7  '�� �    �� 5�   
   " ��6   .�5�      ��  � ��$ Stretch=�64   �� 5�       � ��$	 Top=�62   �� 5�       � ��$ 30��6)   �� 5�       �@J�SnapsToDevicePixels . 6>   �� 5�       � ��$ Disabled=�6K   �� 5�       � ��$
 Auto=�6I   �� 5�       � �� . 6>   �� 5�       � ��
 �   �67   �� 5�       �@�FocusVisualStyle 6B   Z� �� 5�       � ��$ 0q�60   �� 5�       � ��
 �����6+    5     P� 5      �@J�IsMouseOver . . �5     ��  � ��
 ��·�63   5     5     �� 5
  
   "6 d�67   .R�5     � 7 5     �� 5     �� 5     $��20 �6'   .+�5     �� $8 Border��5     $��2��5     $9 2��5     ���	#FF72A8A3���#404040$��1q�5     �� 5     $��0��5     $9 2,0,0,2��5     $��1q�5     ���#FFFFFF���#404040$��0,0,1,0q�5     F� 5     $: Arrow��5     $��1��5      ���#404040$��Center=�5"     $��Center=�5#     "����        � 	=  	= � z     	5$     5%     ; 5&     P� 5'      �@J�IsMouseOver . . �5(     �� $< Border��6    � �� �#8080806G   5)     P� 5*      �@d�	IsChecked$
 trueY�6<   . �5+     �� $< Border��6    � �� �#E0E0E06G   5,     P� 5-      � {� .  . �5.     �� $< Border��6    � �� �#EEEEEE6G   �� 5/     $< Border��6    � �� �#AAAAAA6H   �� 50      � �� �#88888863   �� 51     $< Arrow��6    � �� �#8888886@   52     54     �� 56  
   "6 ��62   .R�57     �� $8 PART_ContentHost��6   |�.  #��z��6A   58     �� 5:  
   " ��6*   .�5;     ��  �@J�SnapsToDevicePixels . 64   �� 5<      �@�OverridesDefaultStyle . 66   �� 5=      � ��$
 Auto=�6K   �� 5>      � ��$
 Auto=�6I   �� 5?      � �� . 6>   �� 5@      � ��$ 30��6)   �� 5A      � ��$ 20��6*   �� 5B      � �� 5C     �� 5D     "6 ��6&   .R�5E     � .+�5F     d� $��ToggleButton��5G  	   8��  $��2��5I  	   |�.  $= Press=�5L  	   > 5K  	   �� $? IsDropDownOpen�$@ TwoWay=�A �� *TemplatedParent+5M     �� 5N     $��ContentSite��5O  	   B .  #��zC 5Q  	   #��zD 5R  	   #��z��5S  	   $��3,3,23,3q�5T  	   $��Center=�5U  	   $
��Left=�5V  	   �� 5W     $E PART_EditableTextBox��6&   8�� $
��Left=�5Z  	   $��Center=�5[  	   $��3,3,23,3q�5\  	   |�. 
������ $y�Hidden=�5_  	   #G zF 5`  	   ��5X  	   Z� 5`  	   � 5a     $��Popup��5b  	   $��Bottom=�5c  	   #��zH 5d  	   I . |�.  $��Slide=�5g  	   .��5h  "   � $��DropDown��5i     J . #��zK 5k     #��zL 5l     .+�5m  &   �� $8 DropDownBorder��5n     ���#FFFFFF$��1q�5p     ���#8888885q     �� 5r  &   $��4,6,4,6q�63   J . .��5s  *   �� M . $N 	Contained=�6H   5t  '   5u  #   5v     5w     ; 5x     P� 5y      �@��HasItems .  . �5z  "   �� $< DropDownBorder��6)    � ��$ 95��6Z   5{     P� 5|      � {� .  . �5}  "   ��  � �� �#8888886?   5~     P� 5      �@��
IsGrouping . . �5�  "   ��  � �� .  6R   5�     P� 5�     $O Popup��6&    �@�AllowsTransparency . . �5�  "   �� $< DropDownBorder��6)    �@��CornerRadius$ 4��6]   �� 5�  "   $< DropDownBorder��6)    � ��$ 0,2,0,0q�6W   5�     P� 5�      �@��
IsEditable . . �5�  "   ��  � �� .  6>   �� 5�  "   $< PART_EditableTextBox��6)    � y�$ Visible=�6a   �� 5�  "   $< ContentSite��6)    � y�$ Hidden=�6X   5�     5�     5�      5�     5�     �� 5�  
   " ��6.   .�5�     ��  �@J�SnapsToDevicePixels . 64   �� 5�      �@�OverridesDefaultStyle . 66   �� 5�      � �� 5�     �� 5�     "6 ��6&   .R�5�     �� $��Border��5�     $P 2q�5�     J . ._�5�     �� 5�     ; 5�     P� 5�      �@��IsHighlighted . . �5�  "   �� $< Border��6)    � �� �#DDDDDD6S   5�     P� 5�      � {� .  . �5�  "   ��  � �� �#8888886?   5�     5�     5�     5�     5�     5�     