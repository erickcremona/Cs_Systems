   M S B A M L   `   `   `  ����  Cs_Gerencial4    .Cs_Gerencial.Windows.CadastroIndisponibilidade   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Indisponibilidade��5   	   $��562.745��6#   $��819.757��64    � Icon$3 -/Cs_Gerencial;component/Imagens/Gerencial.ico��6D    � WindowStartupLocation$ CenterOwner=�6y    � 
ResizeMode$ NoResize=�6�    � ShowInTaskbar .  ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FFFFDEB6��6    � Offset$ 0Q�6-   � 5      $ 	#FFFBFBFB��6   $ 1Q�6-   5	      .��5      � .+�5   
   �� $��76��6   $	��Top=�6!   ���	#FF4F4F4F	 �� Orientation$	 
Horizontal=�6P   $
��Left=�6i   $	��814��6�   .+�5      �� $	��599��6   $	 
Horizontal=�6%   .+�5      �� $��68��6   .+�5      �� -   5        
 ��Name$
 btnAdicionar��5      $��0q�63   $��0q�6?    � Cursor$
 Hand��6S    � ToolTip$ Adicionar Registro��6a   $��55��6~   $
��Left=�6�   $��66��6�   ��5      �� 5      ��5      �� 5      .R�5   "   �� 
���   �$��Center=�6@   $��Center=�6]   $��0q�6y    �� Padding$ 0q�6�   $��45��6�   $��62��6�   ��5   &   �� 5   *    �� ImageSource$: 4/Cs_Gerencial;component/Imagens/AdicionarUsuario.png��65   ��5   &   �� 5   *    �� 
TargetType" ��60    �� Triggers 5   .   P� 5   2    P� Property �@J�IsMouseOver P� Value . . �5   6   ��  �� Property � �� �� Value
 ���� 6T   5   3   5    +   5"   #   5#      5%      �� 5&      $��	Adicionar��6   ���	#FFF1BF77$��Stretch=�6G   $��30��6c   $��Center=�6o   $��65��6�   $��1,0,2,0q�6�   5'      �� 5(      $��68��6   .+�5)      �� -   5        $
 
btnAlterar��5)      $��0q�61   $��0q�6=   $
 Hand��6Q   $ Alterar Registro��6_   $��55��6z   $
��Left=�6�   $��66��6�   ��5*      �� 5+      ��5-      �� 5.      .R�5/   "   �� 
���   �$��Center=�6@   $��Center=�6]   $��0q�6y   $ 0q�6�   $��45��6�   $��62��6�   ��50   &   �� 51   *   $8 2/Cs_Gerencial;component/Imagens/AlterarUsuario.png��65   ��53   &   �� 54   *   " ��60    55   .   P� 56   2    �@J�IsMouseOver . . �57   6   ��  � ��
 ���� 6T   58   3   5:   +   5<   #   5=      5?      �� 5@      $��
   Alterar��6   ���	#FFF1BF77$��Center=�6H   $��30��6c   $��Center=�6o   $��65��6�   $��1,0,2,0q�6�   5A      �� 5B      $��68��6   .+�5C      �� -   5        $
 
btnExcluir��5C      $��0q�61   $��0q�6=   $
 Hand��6Q   $ Excluir Registro��6_   $��55��6z   $
��Left=�6�   $��66��6�   ��5D      �� 5E      ��5G      �� 5H      .R�5I   "   �� 
���   �$��Center=�6@   $��Center=�6]   $��0q�6y   $ 0q�6�   $��45��6�   $��62��6�   ��5J   &   �� 5K   *   $8 2/Cs_Gerencial;component/Imagens/ExcluirUsuario.png��65   ��5M   &   �� 5N   *   " ��60    5O   .   P� 5P   2    �@J�IsMouseOver . . �5Q   6   ��  � ��
 ���� 6T   5R   3   5T   +   5V   #   5W      5Y      �� 5Z      $��
   Excluir��6   ���	#FFF1BF77$��Center=�6H   $��30��6c   $��Center=�6o   $��65��6�   $��1,0,2,0q�6�   5[      �� 5\      $��12��6   �� 5]      $	��113��6   .+�5^      �� $��27��6!   �� 5_      -   5        $��cmbTipoConsulta��5_   1   $��0,0,10,0q�6   
�������5`      5a      �� 5b      $	��267��6   .+�5d      �� -   5        $��txtConsulta��5d      $��23��61    �� TextWrapping$
 Wrap=�6=   $�� ��6Q   $��
0,26,10,26q�6Y    �� CharacterCasing$ Upper=�6�   6�   5e      5g      �� 5h      $	��218��6   $	 
Horizontal=�6%   .+�5i      �� $��Importar Arquivo:��6   $	��120��64   ���	#FFF1BF77$��14(�6W   $��Center=�6e   $
��0,24q�6�   �� 5j      -   5        $
 btnImportar��5j      $��0,0,0,1q�6.   $��0q�6?   $��0q�6K   $
 Hand��6_   $��85��6m   $4 .Localizar o arquivo do Cenib para Importação��6�   ��5k      �� 5l      ��5n      �� 5o      .R�5p      �� 
���   �$��Center=�6<   $��Center=�6Y   $��0q�6u   $ 0q�6�   $��64��6�   $��75��6�   ��5q   "   �� 5r   &   $A ;/Cs_Gerencial;component/Imagens/UpdateIndisponibilidade.png��61   ��5t   "   �� 5u   &   " ��6,    5v   *   P� 5w   .    �@J�IsMouseOver . . �5x   2   ��  � ��
 ���� 6P   5y   /   5{   '   5}      5~      5�      5�      5�      �� 5�   
   $��	0,507,0,0q�6   ���	#FF4F4F4F6(   &   System.Windows.Controls.DataGrid  5�   
   -   5          Name$ 	dataGrid1��5�   �      AutoGenerateColumns .   �� AlternationCount$ 2��6/      RowBackground
 �����   AlternatingRowBackground �	#FF8DE1FF   
IsReadOnly .    SelectionMode$ Single=�6�    J� 	AllowDrop .     HeadersVisibility$	 All=�6�       CanUserResizeRows  .  !   SelectionUnit$! FullRow=�6�   "   GridLinesVisibility$
" None=�6  #   ClipboardCopyMode$# ExcludeHeader=�62  $$   HorizontalScrollBarVisibility$
$ Auto=�6T  % � UseLayoutRounding% . $	��404��6�  $	��Top=�6�  ��. $��	0,103,0,0q�6�  ��6�  Z� &   RowStyle& 5�      �� 5�      )  #System.Windows.Controls.DataGridRow"  6   .�5�      -	   5        5�      '   	CellStyle' 5�      �� 5�      *  $System.Windows.Controls.DataGridCell"  6    5�      P� 5�       �@ 
IsSelected . . �5�      ��  � �� �	#FF0086FF6;   5�      5�      ( � ContextMenu( 5�      �� 5�      -
   5        $
��menu��5�   L   ) �� 
IsSelected) . * � ForceCursor* . .@�5�      m� -   5        $��MenuItemNovo��5�   2   $��	Adicionar��6   $
 Hand��6F   ���	#FF4F4F4F
����������	#FFF1BF77+ m� Icon+ 5�      �� 5�      $A��;/Cs_Gerencial;component/Imagens/AdicionarUsuarioPequeno.png��6$   5�      m� 5�      -   5        $��MenuItemAlterar��5�   0   $��Alterar��6   $
 Hand��6G   ���	#FF4F4F4F
����������	#FFF1BF77+ 5�      �� 5�      $?��9/Cs_Gerencial;component/Imagens/UsuarioAlterarPequeno.png��6$   5�      m� 5�      -   5        $��MenuItemExcluir��5�   0   $��Excluir��6   $
 Hand��6G   ���	#FF4F4F4F
����������	#FFF1BF77+ 5�      �� 5�      $?��9/Cs_Gerencial;component/Imagens/UsuarioExcluirPequeno.png��6$   5�      5�      ,   Columns, 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn-   Header$	- Ato��6%   .   Width5  /System.Windows.Controls.DataGridLengthConverter$. 50 62   /   CanUserResize/ .  0   
Visibility$0 Hidden=�6{   1  +System.Windows.Controls.DataGridBoundColumn1   Binding1 6=   �� *IndisponibilidadeId+6{     5�      $
- NOME��6%   $	. 280 63   / .  1 6?   �� *NomeIndividuo+6a     5�      $- CPF/CNPJ��6%   $	. 150 67   / .  -   5        
colCpfCnpj��1 5�   C   �� *	CpfCnpj+6u     5�      $- Cancel.��6%   $. 50 66   / .  2   
Foreground2 �	#FFB400001 6A   �� *	Cancelado+6u     5�      $- 	PROTOCOLO��6%   $	. 200 68   / .  -   5        colProtocolo��1 5�   D   �� *	Protocolo+6x     5�      $- DATA PEDIDO��6%   $	. 115 6:   / .  1 6F   �� *
DataPedido+3 �� StringFormat$3 
dd/MM/yyyy��6~   5�      �� 5�   
   -   5        $��lblQtdRegistros��5�      $��Label��6'   $
��Left=�67   $��0,77,0,0q�6R   $	��Top=�6d   $	��367��6|   5�      5�      