   M S B A M L   `   `   `  ����C  ?Cs_Notas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Microsoft.Windows.ControlsMicrosoft.Windows.Controls  5   	   '    !Cs_Notas.Windows.DigitarEscritura   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   7dg(clr-namespace:Microsoft.Windows.Controls     5   	   -   5          � Title$  Digitar Escritura��5   	   $��645.175��6#   $	��873��64    � WindowState$ Normal=�6@    � ShowInTaskbar .   � 
ResizeMode$ NoResize=�6k    � WindowStartupLocation$ CenterOwner=�6�    � Icon$+ %/Cs_Notas;component/Imagens/Notas.ico��6�   ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ White��6   	 � Offset$	 1Q�6)   � 5	      $ 	#FFBDF9F9��6   5
      .��5      � .+�5   
   � $
��Left=�6   $	��156��6*   $��	10,10,0,0q�67   $	��Top=�6J   $	��836��6b   ��5      �� 5      $ 0.5,1&�6&   $ 0.5,0&�67   .��5      � $ 	#FFFBFBFB��6#   $	 0Q�65   � 5      $ 	#FF31B6CB��6#   $	 1Q�65   5      .+�5      �� $��	Natureza:��6   $
��Left=�6(   $��26,3,0,0q�6C   $	��Top=�6U   $	��100��6m   �� 5      -   5        $��cmbNaturezas��5      $
��Left=�6+   $��	26,29,0,0q�6F   $	��Top=�6Y   $	��379��6q   6}   �� 5      -   5        $��	txtOutros��5      
 �� CharacterCasing$
 Upper=�6'   $
��Left=�6?   {�.  $��23��6l   $��	26,77,0,0q�6x    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��379��6�   �� 5      $��Natureza (CENSEC):��6   $
��Left=�61   $��	437,3,0,0q�6L   $	��Top=�6_   $	��140��6w   �� 5      -   5        $��cmbNaturezaCensec��5      {�.  $
��Left=�6B   $��
437,29,0,0q�6]   $	��Top=�6q   $	��370��6�   �� 5      -   5        $��lblTabelaAtos��5   .   $��Tabela de Atos:��6   $
��Left=�6C   $��
437,52,0,0q�6^   $	��Top=�6r   $	��370��6�   �� 5      -   5        $��cmbTabelaAtos��5      $
��Left=�6,   $��
437,78,0,0q�6G   $	��Top=�6[   $	��370��6s   $��22��6   6�   �� 5      $��Outros:��6   $
��Left=�6&   $��	26,52,0,0q�6A   $	��Top=�6T   $	��100��6l   �� 5      $��Data:��6   $
��Left=�6$   $��
26,100,0,0q�6?   $	��Top=�6S   $	��100��6k   (  "System.Windows.Controls.DatePicker  5      -   5        $��	dtDataAto��5      $
��Left=�6*   $��
26,126,0,0q�6E   $	��Top=�6Y   $	��100��6q   �� 5      -   5        $��txtLivro��5      $
��Left=�6&   |�.  $��23��6S   $��147,126,0,0q�6_   $
 Wrap=�6t   $	��Top=�6�   $��60��6�   ���	#FF64DADA$��14(�6�   �� 5      $��Livro:��6   $
��Left=�6%   $��147,100,0,0q�6@   $	��Top=�6U   $��52��6m   �� 5       -	   5        $��	txtFlsIni��5       $
��Left=�6'   |�.  $��23��6T   $��213,126,0,0q�6`   $
 Wrap=�6u   $	��Top=�6�   $��60��6�   ���	#FF64DADA$��14(�6�   �� 5!      $��	Fls Ini.:��6   $
��Left=�6(   $��213,100,0,0q�6C   $	��Top=�6X   $��52��6p   �� 5"      -
   5        $��	txtFlsFim��5"      $
��Left=�6'   |�.  $��23��6T   $��279,126,0,0q�6`   $
 Wrap=�6u   $	��Top=�6�   $��60��6�   ���	#FF64DADA$��14(�6�   �� 5#      $��Fls Fim:��6   $
��Left=�6'   $��279,100,0,0q�6B   $	��Top=�6W   $��52��6o   �� 5$      -   5        $��txtAto��5$      $
��Left=�6$   $��23��6?   |�.  $��345,126,0,0q�6]   $
 Wrap=�6r   $	��Top=�6�   $��60��6�   ���	#FF64DADA$��14(�6�   �� 5%      $
��Ato:��6   $
��Left=�6#   $��345,100,0,0q�6>   $	��Top=�6S   $��52��6k   �� 5&      -   5        $��	txtRecibo��5&      $
��Left=�6'   $��23��6B   |�.  $��437,126,0,0q�6`   $
 Wrap=�6u   $	��Top=�6�   $��71��6�   ���	#FF64DADA$��14(�6�   �� 5'      $��Recibo:��6   $
��Left=�6&   $��437,101,0,0q�6A   $	��Top=�6V   $��52��6n   �� 5(      -   5        $��txtSelo��5(      $
��Left=�6&   $��23��6A   |�.  $��513,126,0,0q�6_   $
 Wrap=�6t   $	��Top=�6�   $	��104��6�   ���	#FF93CEFF �� 	UndoLimit$ 98��6�   $��14(�6�   �� 5)      $��Selo:��6   $
��Left=�6$   $��513,101,0,0q�6?   $	��Top=�6T   $��52��6l   �� 5*      -   5        $��txtAleatorio��5*      $
��Left=�6*   $��23��6E   |�.  $��622,126,0,0q�6c   $
 Wrap=�6x   $	��Top=�6�   $��49��6�   ���	#FF93CEFF$��14(�6�   �� 5+      -   5        $��txtBaseCalculo��5+      $
��Left=�6,   $��23��6G   $��676,126,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $	��131��6�   $��14(�6�   $
��Bold"�6�   �� 5,      $��Base de Cálculo:��6   $
��Left=�6/   $��676,101,0,0q�6J   $	��Top=�6_   $��96��6w   �� 5-      -   5        $��ckbDoi��5-   %   $	��Doi��6   $
��Left=�63   $��	293,9,0,0q�6N   $	��Top=�6a   6�   �� 5.      -   5        $��	ckbCensec��5.   (   $��Censec��6   $
��Left=�69   $��	348,9,0,0q�6T   $	��Top=�6g   6�   �� 5/      $��Alvará Judicial��6   $
��Left=�61   $��	712,9,0,0q�6L   $	��Top=�6_   50      � 51   
   $
��Left=�6   $	��340��6*   $��
10,180,0,0q�67   $	��Top=�6K   $	��836��6c   ��52      �� 53      $ 0.5,1&�6&   $ 0.5,0&�67   .��54      � $ 	#FF7DC7C7��6#   $	 0Q�65   � 55      $ White��6#   $	 1Q�61   56      .+�58      �� $��	0,0,0,-19q�6   .@�59      �� $	��Ato��6   .��5:      �  � ColumnDefinitions 5;      ��5=      �� 5>      $ 0.5,1&�62   $ 0.5,0&�6C   .��5?   "   � $ 	#FF476E74��6/   $	 0Q�6A   � 5@   "   $ 	#FF2FBAD1��6/   $	 1Q�6A   5A      .+�5C      �� $��Participantes��6#   $	��107��6:   $��10,0,6,0q�6G   $	��Top=�6Y   
�������$��2��6�   .��5D      � $��
10,0,-2,-2q�6#   .+�5E   "   �� -   5         ��Name$ btnExcluirParte��5E   )   $��0q�6B   $��0q�6N    � Cursor$
 Hand��6b    � ToolTip$ Excluir Participante��6p   $��
726,58,0,0q�6�   $
��Left=�6�   $��68��6�   $��27��6�   $	��Top=�6�   ��5F   &   �� 5G   *   ��5I   &   �� 5J   *   .R�5K   .   �� 
���   �$��Center=�6L   $��Center=�6i   $��0q�6�    �� Padding$ 0q�6�   $��26��6�   $��27��6�   ��5L   2   �� 5M   6    �� ImageSource$= 7/Cs_Notas;component/Imagens/usuarioAzul_delete-user.png��6A   ��5O   2   �� 5P   6    �� 
TargetType" ��6<    �� Triggers 5Q   :   P� 5R   >    P� Property �@J�IsMouseOver P� Value . . �5S   B   ��  �� Property � �� �� Value
 ���� 6`   5T   ?   5V   7   5X   /   5Y   +   5[   #   �� 5\   "   -   5        $ btnAlterarParte��5\   )   $��0q�6B   $��0q�6N   $
 Hand��6b   $ Alterar Participante��6p   $��
726,30,0,0q�6�   $
��Left=�6�   $��68��6�   $��26��6�   $	��Top=�6�   ��5]   &   �� 5^   *   ��5`   &   �� 5a   *   .R�5b   .   �� 
���   �$��Center=�6L   $��Center=�6i   $��0q�6�   $ 0q�6�   $��26��6�   $��27��6�   ��5c   2   �� 5d   6   $; 5/Cs_Notas;component/Imagens/usuarioAzul_edit-user.png��6A   ��5f   2   �� 5g   6   " ��6<    5h   :   P� 5i   >    �@J�IsMouseOver . . �5j   B   ��  � ��
 ���� 6`   5k   ?   5m   7   5o   /   5p   +   5r   #   �� 5s   "   -   5        $ btnAdicionarParte��5s   )   $��0q�6D   $��0q�6P   $
 Hand��6d   $ Adicionar Participante��6r   $��	726,1,0,0q�6�   $
��Left=�6�   $��68��6�   $��27��6�   $	��Top=�6�   ��5t   &   �� 5u   *   ��5w   &   �� 5x   *   .R�5y   .   �� 
���   �$��Center=�6L   $��Center=�6i   $��0q�6�   $ 0q�6�   $��26��6�   $��27��6�   ��5z   2   �� 5{   6   $: 4/Cs_Notas;component/Imagens/usuarioAzul_add-user.png��6A   ��5}   2   �� 5~   6   " ��6<    5   :   P� 5�   >    �@J�IsMouseOver . . �5�   B   ��  � ��
 ���� 6`   5�   ?   5�   7   5�   /   5�   +   5�   #   &   System.Windows.Controls.DataGrid  5�   "   -   5          Name$ dataGridSeriesDisponiveis��5�   �      AutoGenerateColumns .  $
 Hand��6G    �� AlternationCount$ 2��6U      RowBackground
 �����   AlternatingRowBackground �	#FF8DE1FF   
IsReadOnly .    SelectionMode$ Single=�6�     J� 	AllowDrop  .  !   HeadersVisibility$	! All=�6  "   CanUserResizeRows" .  #   SelectionUnit$# FullRow=�65  $   GridLinesVisibility$
$ None=�6M  %   ClipboardCopyMode$% ExcludeHeader=�6h  $&   HorizontalScrollBarVisibility$
& Auto=�6�  ' � UseLayoutRounding' . ��. $��
-11,1,73,2q�6�  ��6�  Z� (   	CellStyle( 5�   &   �� 5�   *   *  $System.Windows.Controls.DataGridCell"  60    5�   .   P� 5�   2    �@ 
IsSelected . . �5�   6   ��  � �� �	#FF0086FF6S   5�   3   5�   +   )   Columns) 5�   &   0  *System.Windows.Controls.DataGridTextColumn  5�   *   ,  &System.Windows.Controls.DataGridColumn*   Header$* 	Id Série��6=   +   Width5  /System.Windows.Controls.DataGridLengthConverter$+ 70 6O   ,   CanUserResize, .  -   
Visibility$- Hidden=�6�   1  +System.Windows.Controls.DataGridBoundColumn.   Binding. 6Z   �� *	PessoasId+6�     5�   *   $
* Nome��6=   $	+ 400 6K   , .  . 6W   �� *Nome+6p     5�   *   $* Qualificação��6=   $	+ 150 6S   , .  . 6_   �� *	Inicial+/ �� StringFormat$/ 	{0:00000}��6�     5�   *   $* CPf/CGC��6=   $	+ 200 6N   , .  . 6Z   �� *Final+$/ 	{0:00000}��6�   5�   #   5�      5�      �� 5�      $ ��Bens Móveis/Bens Imóveis��6#   $	��107��6E   $��
10,107,6,0q�6R   $	��Top=�6f   
�������$��2��6�   .��5�      � $��
10,0,-2,-2q�6#   .+�5�   "   �� -   5        $ btnExcluirParte1��5�   )   $��0q�6C   $��0q�6O   $
 Hand��6c   $  Excluir Bem Móvel/Imóvel��6q   $��
726,58,0,0q�6�   $
��Left=�6�   $��68��6�   $��27��6�   $	��Top=�6�   ��5�   &   �� 5�   *   ��5�   &   �� 5�   *   .R�5�   .   �� 
���   �$��Center=�6L   $��Center=�6i   $��0q�6�   $ 0q�6�   $��26��6�   $��27��6�   ��5�   2   �� 5�   6   $3 -/Cs_Notas;component/Imagens/ImovelExcluir.png��6A   ��5�   2   �� 5�   6   " ��6<    5�   :   P� 5�   >    �@J�IsMouseOver . . �5�   B   ��  � ��
 ���� 6`   5�   ?   5�   7   5�   /   5�   +   5�   #   �� 5�   "   -   5        $ btnAlterarParte1��5�   )   $��0q�6C   $��0q�6O   $
 Hand��6c   $  Alterar Bem Móvel/Imóvel��6q   $��
726,30,0,0q�6�   $
��Left=�6�   $��68��6�   $��26��6�   $	��Top=�6�   ��5�   &   �� 5�   *   ��5�   &   �� 5�   *   .R�5�   .   �� 
���   �$��Center=�6L   $��Center=�6i   $��0q�6�   $ 0q�6�   $��26��6�   $��27��6�   ��5�   2   �� 5�   6   $3 -/Cs_Notas;component/Imagens/ImovelAlterar.png��6A   ��5�   2   �� 5�   6   " ��6<    5�   :   P� 5�   >    �@J�IsMouseOver . . �5�   B   ��  � ��
 ���� 6`   5�   ?   5�   7   5�   /   5�   +   5�   #   �� 5�   "   -   5        $ btnAdicionarParte1��5�   )   $��0q�6E   $��0q�6Q   $
 Hand��6e   $" Adicionar Bem Móvel/Imóvel��6s   $��	726,1,0,0q�6�   $
��Left=�6�   $��68��6�   $��27��6�   $	��Top=�6�   ��5�   &   �� 5�   *   ��5�   &   �� 5�   *   .R�5�   .   �� 
���   �$��Center=�6L   $��Center=�6i   $��0q�6�   $ 0q�6�   $��26��6�   $��27��6�   ��5�   2   �� 5�   6   $/ )/Cs_Notas;component/Imagens/ImovelAdd.png��6A   ��5�   2   �� 5�   6   " ��6<    5�   :   P� 5�   >    �@J�IsMouseOver . . �5�   B   ��  � ��
 ���� 6`   5�   ?   5�   7   5�   /   5�   +   5�   #     5�   "   -   5        $ 	dataGrid1��5�   +    . $ 2��6Y   
 �����
 ��ح�$
��Left=�6�   $	��736��6�   
�������$��	-10,1,0,0q�6�   $��84��6�   $	��Top=�6  5�      5�      �� 5�      $��Atos Conjuntos��6#   $	��107��6;   $��
10,214,6,0q�6H   $	��Top=�6\   
�������$��2��6�   .��5�      � $��
10,0,-2,-2q�6#   .+�5�   "   �� -   5        $ btnExcluirParte2��5�   )   $��0q�6C   $��0q�6O   $
 Hand��6c   $ Excluir Ato Conjunto��6q   $��
726,58,0,0q�6�   $
��Left=�6�   $��68��6�   $��27��6�   $	��Top=�6�   ��5�   &   �� 5�   *   ��5�   &   �� 5�   *   .R�5�   .   �� 
���   �$��Center=�6L   $��Center=�6i   $��0q�6�   $ 0q�6�   $��26��6�   $��22��6�   ��5�   2   �� 5�   6   $8 2/Cs_Notas;component/Imagens/ExcluirAtoConjunto.png��6A   ��5�   2   �� 5�   6   " ��6<    5�   :   P� 5�   >    �@J�IsMouseOver . . �5�   B   ��  � ��
 ���� 6`   5�   ?   5�   7   5�   /   5�   +   5�   #   �� 5   "   -   5        $ btnAlterarParte2��5   )   $��0q�6C   $��0q�6O   $
 Hand��6c   $ Alterar Ato Conjunto��6q   $��
726,30,0,0q�6�   $
��Left=�6�   $��68��6�   $��26��6�   $	��Top=�6�   ��5  &   �� 5  *   ��5  &   �� 5  *   .R�5  .   �� 
���   �$��Center=�6L   $��Center=�6i   $��0q�6�   $ 0q�6�   $��26��6�   $��27��6�   ��5  2   �� 5  6   $9 3/Cs_Notas;component/Imagens/oie_transparent (1).png��6A   ��5
  2   �� 5  6   " ��6<    5  :   P� 5  >    �@J�IsMouseOver . . �5  B   ��  � ��
 ���� 6`   5  ?   5  7   5  /   5  +   5  #   �� 5  "   -   5        $ btnAdicionarParte2��5  )   $��0q�6E   $��0q�6Q   $
 Hand��6e   $ Adicionar Ato Conjunto��6s   $��	726,1,0,0q�6�   $
��Left=�6�   $��68��6�   $��27��6�   $	��Top=�6�   ��5  &   �� 5  *   ��5  &   �� 5  *   .R�5  .   �� 
���   �$��Center=�6L   $��Center=�6i   $��0q�6�   $ 0q�6�   $��26��6�   $��27��6�   ��5  2   �� 5  6   $4 ./Cs_Notas;component/Imagens/AddAtoConjunto.png��6A   ��5!  2   �� 5"  6   " ��6<    5#  :   P� 5$  >    �@J�IsMouseOver . . �5%  B   ��  � ��
 ���� 6`   5&  ?   5(  7   5*  /   5+  +   5-  #     5.  "   -   5        $ 	dataGrid2��5.  +    . $ 2��6Y   
 �����
 ��ح�$
��Left=�6�   $	��736��6�   
�������$��	-10,1,0,0q�6�   $��84��6�   $	��Top=�6  5/     50     51     52     �� 53     $��Procuração��6   .��54     � ��55     �� 56     $ 0.5,1&�62   $ 0.5,0&�6C   .��57  "   � $ 	#FF476E74��6/   $	 0Q�6A   � 58  "   $ 	#FF2FBAD1��6/   $	 1Q�6A   59     .+�5;     �� $��Procuração��6#   $
��Left=�67   $	��242��6R   $��10,0,0,0q�6_   $	��Top=�6q   $	��810��6�   
�������.��5<     � $
��Left=�6#   $	��221��6>   $��	0,0,-2,-1q�6K   $	��Top=�6^   $	��800��6v   .+�5=  "   �� $��Lavrado no RJ?��6+   $
��Left=�6C   $��	10,15,0,0q�6^   $	��Top=�6q   $��44��6�   $	��134��6�   .��5>  &   � $��	0,0,-2,-2q�6+   .+�5?  *   	� -   5        $��rbSimProcuracao��5?  6   $
��Sim
��6M   0 d� 	IsChecked$
0 TrueY�6`   $
��Left=�6q   $��10,3,0,0q�6�   $	��Top=�6�   $��19��6�   
�������6�   	� 5@  *   -   5        $��rbNaoProcuracao��5@  6   $��Não
��6M   $
��Left=�6`   $��72,3,0,0q�6{   $	��Top=�6�   $��19��6�   
�������6�   5A  '   5B  #   �� 5C  "   $��Serventia: ��6(   $
��Left=�6>   $	��Top=�6Y   $��	173,5,0,0q�6q   
�������6�   �� 5D  "   -    5        $��txtServentiaProcuracao��5D  *   1 �� 	MaxLength$	1 150��6H   $
��Left=�6X   $
 Upper=�6s   $��23��6�   $
 Wrap=�6�   $	��Top=�6�   $	��485��6�   $��
173,31,0,0q�6�   $��14(�6�     5E  "   $
��Left=�6-   $	��Top=�6H   $��
677,31,0,0q�6`   $��23��6t   $	��113��6�   �� 5F  "   -!   5        $��dtDataProcuracao��5F  (   $��Data:��6@   $
��Left=�6P   $	��Top=�6k   $��	677,5,0,0q�6�   
�������6�   �� 5G  "   -"   5        $��txtLivroProcuracao��5G  *   $1 20��6D   $
 Upper=�6S   $
��Left=�6k   $��23��6�   $
 Wrap=�6�   $	��Top=�6�   $	��167��6�   $��	10,88,0,0q�6�   $��14(�6�   �� 5H  "   $��Livro:��6(   $
��Left=�69   $	��Top=�6T   $��	10,64,0,0q�6l   
�������6   �� 5I  "   -#   5        $��txtFolhasProcuracao��5I  *   $1 10��6E   $
 Upper=�6T   $
��Left=�6l   $��23��6�   $
 Wrap=�6�   $	��Top=�6�   $	��167��6�   $��
213,88,0,0q�6�   $��14(�6�   �� 5J  "   $��Folhas:��6(   $
��Left=�6:   $	��Top=�6U   $��
213,64,0,0q�6m   
�������6�   �� 5K  "   -$   5        $��txtAtoProcuracao��5K  *   $1 10��6B   $
 Upper=�6Q   $
��Left=�6i   $��23��6�   $
 Wrap=�6�   $	��Top=�6�   $	��167��6�   $��
419,88,0,0q�6�   $��14(�6�   �� 5L  "   $
��Ato:��6(   $
��Left=�67   $	��Top=�6R   $��
419,64,0,0q�6j   
�������6~   �� 5M  "   -%   5        $��txtSeloProcuracao��5M  *   $1 9��6C   $
 Upper=�6Q   $
��Left=�6i   $��23��6�   $
 Wrap=�6�   $	��Top=�6�   $	��167��6�   $��
623,88,0,0q�6�   $��14(�6�   �� 5N  "   $��Selo:��6(   $
��Left=�68   $	��Top=�6S   $��
623,64,0,0q�6k   
�������6   �� 5O  "   $��Outorgantes: ��6(   $
��Left=�6@   $	��Top=�6[   $��
10,113,0,0q�6s   
�������6�   �� 5P  "   -&   5        $��txtOutorgantesProcuracao��5P  *   $
 Upper=�6J   $
��Left=�6b   $��72��6}   $	1 600��6�   $
 Wrap=�6�   $	��Top=�6�   $	��370��6�   $��
10,139,0,0q�6�   $��14(�6�   �� 5Q  "   $��Outorgados: ��6(   $
��Left=�6?   $	��Top=�6Z   $��419,113,0,0q�6r   
�������6�   �� 5R  "   -'   5        $��txtOutorgadosProcuracao��5R  *   $
 Upper=�6I   $
��Left=�6a   $��72��6|   $	1 600��6�   $
 Wrap=�6�   $	��Top=�6�   $	��370��6�   $��419,139,0,0q�6�   $��14(�6�   5S     5U       5V     -(   5        $ dataGridProcuracao��5V  #    . $ 2��6Z   
 �����
 ��ح�$
��Left=�6�   $	��560��6�   
�������$��
10,247,0,0q�6�   $��80��6�   $	��Top=�6  �� 5W     -)   5        $ btnExcluirProcuracao��5W  !   $��0q�6?   $��0q�6K   $
 Hand��6_   $ Excluir Procuração��6m   $��575,300,0,0q�6�   $
��Left=�6�   $��51��6�   $��27��6�   $	��Top=�6�   ��5X     �� 5Y  "   ��5[     �� 5\  "   .R�5]  &   �� 
���   �$��Center=�6D   $��Center=�6a   $��0q�6}   $ 0q�6�   $��26��6�   $��27��6�   ��5^  *   �� 5_  .   $8 2/Cs_Notas;component/Imagens/ExcluirAtoConjunto.png��69   ��5a  *   �� 5b  .   " ��64    5c  2   P� 5d  6    �@J�IsMouseOver . . �5e  :   ��  � ��
 ���� 6X   5f  7   5h  /   5j  '   5k  #   5m     �� 5n     -*   5        $ btnAlterarProcuracaao��5n  !   $��0q�6@   $��0q�6L   $
 Hand��6`   $ Alterar Procuração��6n   $��575,274,0,0q�6�   $
��Left=�6�   $��51��6�   $��26��6�   $	��Top=�6�   ��5o     �� 5p  "   ��5r     �� 5s  "   .R�5t  &   �� 
���   �$��Center=�6D   $��Center=�6a   $��0q�6}   $ 0q�6�   $��26��6�   $��27��6�   ��5u  *   �� 5v  .   $8 2/Cs_Notas;component/Imagens/AlterarAtoConjunto.png��69   ��5x  *   �� 5y  .   " ��64    5z  2   P� 5{  6    �@J�IsMouseOver . . �5|  :   ��  � ��
 ���� 6X   5}  7   5  /   5�  '   5�  #   5�     �� 5�     -+   5        $ btnAdicionarProcuracao��5�  !   $��0q�6A   $��0q�6M   $
 Hand��6a   $ Adicionar Procuração��6o   $��575,248,0,0q�6�   $
��Left=�6�   $��51��6�   $��26��6�   $	��Top=�6�   ��5�     �� 5�  "   ��5�     �� 5�  "   .R�5�  &   �� 
���   �$��Center=�6D   $��Center=�6a   $��0q�6}   $ 0q�6�   $��26��6�   $��39��6�   ��5�  *   �� 5�  .   $4 ./Cs_Notas;component/Imagens/AddAtoConjunto.png��69   ��5�  *   �� 5�  .   " ��64    5�  2   P� 5�  6    �@J�IsMouseOver . . �5�  :   ��  � ��
 ���� 6X   5�  7   5�  /   5�  '   5�  #   5�     �� 5�     ���	#FFF4F4F5$
��Left=�65   $��53��6P   $��648,248,0,0q�6\   
���   �$	��Top=�6�   $	��172��6�   �� 5�     -,   5        $ btnCancelarProcuracao��5�  !   $��0q�6@   $��0q�6L   $
 Hand��6`   $ Cancelar��6n   $��666,257,0,0q�6�   $
��Left=�6�   $��65��6�   $��38��6�   $	��Top=�6�   ��5�     �� 5�  "   ��5�     �� 5�  "   .R�5�  &   �� 
���   �$��Center=�6D   $��Center=�6a   $��0q�6}   $ 0q�6�   $��30��6�   $��38��6�   ��5�  *   �� 5�  .   $/ )/Cs_Notas;component/Imagens/Cancelar2.png��69   ��5�  *   �� 5�  .   " ��64    5�  2   P� 5�  6    �@J�IsMouseOver . . �5�  :   ��  � ��
 ���� 6X   5�  7   5�  /   5�  '   5�  #   5�     �� 5�     --   5        $ btnSalvarProcuracao��5�  !   $��0q�6>   $��0q�6J   $
 Hand��6^   $ Salvar��6l   $��737,257,0,0q�6}   $
��Left=�6�   $��65��6�   $��38��6�   $	��Top=�6�   2 J� RenderTransformOrigin$2 0.495,0.118&�6�   ��5�     �� 5�  "   ��5�     �� 5�  "   .R�5�  &   �� 
���   �$��Center=�6D   $��Center=�6a   $��0q�6}   $ 0q�6�   $��36��6�   $��53��6�   ��5�  *   �� 5�  .   $- '/Cs_Notas;component/Imagens/Salvar2.png��69   ��5�  *   �� 5�  .   " ��64    5�  2   P� 5�  6    �@J�IsMouseOver . . �5�  :   ��  � ��
 ���� 6X   5�  7   5�  /   5�  '   5�  #   5�     5�     5�     �� 5�     $��Custas��6   .��5�     � ��5�     �� 5�     $ 0.5,1&�62   $ 0.5,0&�6C   .��5�  "   � $ 	#FF476E74��6/   $	 0Q�6A   � 5�  "   $ 	#FF2FBAD1��6/   $	 1Q�6A   5�     5�     5�     �� 5�     $��Observação��6   .��5�     � ��5�     �� 5�     $ 0.5,1&�62   $ 0.5,0&�6C   .��5�  "   � $ 	#FF476E74��6/   $	 0Q�6A   � 5�  "   $ 	#FF2FBAD1��6/   $	 1Q�6A   5�     5�     5�     �� 5�     $��Minuta��6   .��5�     � ��5�     �� 5�     $ 0.5,1&�62   $ 0.5,0&�6C   .��5�  "   � $ 	#FF476E74��6/   $	 0Q�6A   � 5�  "   $ 	#FF2FBAD1��6/   $	 1Q�6A   5�     5�     5�     5�     5�     � 5�  
   $
��Left=�6   $��52��6*   $��
10,544,0,0q�66   $	��Top=�6J   $	��836��6b   ��5�     �� 5�     $ 0.5,1&�6&   $ 0.5,0&�67   .��5�     � $ 	#FFF6F6F7��6#   $	 0Q�65   � 5�     $ 	#FF44779B��6#   $	 0.993Q�65   5�     .+�5�     �� $��Escrevente:��6   $
��Left=�6*   $��	10,-6,0,0q�6E   $	��Top=�6X   $	��100��6p   �� 5�     -.   5        $��cmbEscreventes��5�     $
��Left=�6-   $��	10,20,0,0q�6H   $	��Top=�6[   $	��209��6s   �� 5�     -/   5        $ 	btnSalvar��5�     $��0q�6(   $��0q�64   $
 Hand��6H   $ Cancelar��6V   $��	620,0,0,0q�6i   $
��Left=�6|   $	��103��6�   $��48��6�   $	��Top=�6�   ��5�     �� 5�     ��5�     �� 5�     .R�5�     �� 
���   �$��Center=�68   $��Center=�6U   $��0q�6q   $ 0q�6|   $��48��6�   $��48��6�   ��5�     �� 5�  "   $. (/Cs_Notas;component/Imagens/Cancelar.png��6-   ��5      �� 5  "   " ��6(    5  &   P� 5  *    �@J�IsMouseOver . . �5  .   ��  � ��
 ���� 6L   5  +   5  #   5	     5
     5     �� 5     -0   5        $ btnSalvar_Copy��5     $��0q�6-   $��0q�69   $
 Hand��6M   $ Salvar Escritura��6[   $��	733,0,0,0q�6v   $
��Left=�6�   $	��103��6�   $��48��6�   $	��Top=�6�   $2 0.495,0.118&�6�   ��5     �� 5     ��5     �� 5     .R�5     �� 
���   �$��Center=�68   $��Center=�6U   $��0q�6q   $ 0q�6|   $��48��6�   $��48��6�   ��5     �� 5  "   $+ %/Cs_Notas;component/Imagens/Check.png��6-   ��5     �� 5  "   " ��6(    5  &   P� 5  *    �@J�IsMouseOver . . �5  .   ��  � ��
 ���� 6L   5  +   5  #   5      5!     5#     �� 5$     -1   5        3 ��Name$!3 cmbResponsavelFilhosMenores��5$     $��364,20,313,10q�6<   �� 5%     $!��Responsável Filhos Menores��6   $
��Left=�69   $��
364,-6,0,0q�6T   $	��Top=�6h   �� 5&     -2   5        4 ��Name$4 txtQtdFilhosMenores��5&     $1 2��63   $
��Left=�6A   $��25��6\   $��
238,18,0,0q�6h   $
 Wrap=�6|   $	��Top=�6�   $	��114��6�   $��14(�6�   �� 5'     $��Qtd. Filhos Menores��6   $
��Left=�62   $��
238,-6,0,0q�6M   $	��Top=�6a   $	��126��6y   5(     5*     5 � 	Resources5 5+        columnHeaderStyle=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%%  &	        �� 5,  
   "  5-     .�5.     ��  � �� 5/     �� 50     $ 0.5,0&�6*   $ 0.5,1&�51     ��53     � $ 	#FF3AEAEA��6+   $	 0Q�6=   � 54     $ 	#FF515151��6+   $	 1Q�6=   56     58     �� 59      � ��
 �����6+   5:     5;     5=     