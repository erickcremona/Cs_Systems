   M S B A M L   `   `   `  ����  Cs_Gerencial.    (Cs_Gerencial.Windows.CadastroPlanoContas   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$2  ,Livro Auxiliar - Cadastro de Plano de Contas��5   	   $	��376��6>   $	��426��6K    � 
ResizeMode$ NoResize=�6n    � WindowStartupLocation$ CenterOwner=�6�    � ShowInTaskbar .   � Icon$3 -/Cs_Gerencial;component/Imagens/Gerencial.ico��6�   ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FFE8BE83��6    � Offset$ 0Q�6-   � 5      $ White��6   $ 1Q�6)   5	      .��5      � .+�5   
   �� $��Plano de Contas��6   $��55��6,   $��10,1,0,0q�68   $	��Top=�6J   $
��Left=�6b   $	��391��6}   .��5      � $��-6,-6,-2,-4q�6   .+�5      �� -   5        $��txtPlano��5      $��1��6*   	 �� CharacterCasing$	 Upper=�67   
 �� 	MaxLength$	
 100��6O   $��23��6_   $��	11,10,9,0q�6k    �� TextWrapping$
 Wrap=�6~   $	��Top=�6�   6�   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5   �      AutoGenerateColumns .   �� AlternationCount$ 2��6/      RowBackground
 �����   AlternatingRowBackground �	#FF8DE1FF   
IsReadOnly .    SelectionMode$ Single=�6�    J� 	AllowDrop .     HeadersVisibility$	 All=�6�      CanUserResizeRows .     SelectionUnit$ FullRow=�6�      GridLinesVisibility$
 None=�6     ClipboardCopyMode$ ExcludeHeader=�61  $   HorizontalScrollBarVisibility$
 Auto=�6S   � UseLayoutRounding . ��. $��	0,167,0,0q�6�  ��6�  Z�    	CellStyle 5      �� 5       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6    �� Triggers 5      P� 5       P� Property �@ 
IsSelected P� Value . . �5      ��   �� Property  � ��! �� Value! �	#FF0086FF6;   5      5      "   Columns" 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn#   Header$	# Ato��6%   $   Width5  /System.Windows.Controls.DataGridLengthConverter$$ 50 62   %   CanUserResize% .  &   
Visibility$& Hidden=�6o   1  +System.Windows.Controls.DataGridBoundColumn'   Binding' 6=   �� *	PlanoId+6o     5      $# Plano de Contas��6%   $	$ 402 6>   % .  ' 6J   �� *	Descricao+6h   ( � ContextMenu( 5       �� 5!      -   5        ) ��Name$
) menu��5!   L   * �� 
IsSelected* . + � ForceCursor+ . .@�5"      m� -   5        , m�Name$, MenuItemAlterar��5"   0   $��Alterar��6   - � Cursor$
- Hand��6I   ���	#FF4F4F4F
����������	#FFF1BF77. m� Icon. 5#      �� 5$      $7��1/Cs_Gerencial;component/Imagens/modifyPequeno.png��6$   5&      m� 5'      -   5        $, MenuItemExcluir��5'   0   $��Excluir��6   $
- Hand��6I   ���	#FF4F4F4F
����������	#FFF1BF77. 5(      �� 5)      $8��2/Cs_Gerencial;component/Imagens/ExcluirPequeno.png��6$   5+      5,      5.      �� 5/   
   ���	#FFF4F4F5$��55��6%   $��	0,111,0,0q�61   
���   �$	��Top=�6S   �� 50   
   -   5        / ��Name$/ btnAdicionar��50      $��0q�6'   $��0q�63   $
- Hand��6G   0 � ToolTip$0 	Adicionar��6U   $��50��6i   $	��Top=�6u   1 J� RenderTransformOrigin$1 -0.357,0.569&�6�   $��	10,58,0,0q�6�   $
��Left=�6�   $��53��6�   ��51      �� 52      ��54      �� 55      .R�56      �� 
���   �$��Center=�63   $��Center=�6P   $��0q�6l   2 �� Padding$2 0q�6w   $��27��6�   $��31��6�   ��57      �� 58      3 �� ImageSource$;3 5/Cs_Gerencial;component/Imagens/AdicionarRegistro.png��6)   ��5:      �� 5;      " ��6$    5<   "   P� 5=   &    �@J�IsMouseOver . . �5>   *   ��   � ��
! ���� 6H   5?   '   5A      5C      5D      5F      �� 5G   
   -   5        $/ btnCancelar��5G      $��0q�6&   $��0q�62   $
- Hand��6F   $0 Cancelar��6T   $��50��6g   $	��Top=�6s   $1 -0.357,0.569&�6�   $��
290,58,0,0q�6�   $
��Left=�6�   $��53��6�   ��5H      �� 5I      ��5K      �� 5L      .R�5M      �� 
���   �$��Center=�63   $��Center=�6P   $��0q�6l   $2 0q�6w   $��27��6�   $��31��6�   ��5N      �� 5O      $23 ,/Cs_Gerencial;component/Imagens/Cancelar.png��6)   ��5Q      �� 5R      " ��6$    5S   "   P� 5T   &    �@J�IsMouseOver . . �5U   *   ��   � ��
! ���� 6H   5V   '   5X      5Z      5[      5]      �� 5^   
   -	   5        $/ 	btnSalvar��5^      $��6��6$   $��0q�61   $��0q�6=   $
- Hand��6Q   $0 Salvar��6_   $��50��6p   $	��Top=�6|   $1 -0.357,0.569&�6�   $��
348,58,0,0q�6�   $
��Left=�6�   $��53��6�   ��5_      �� 5`      ��5b      �� 5c      .R�5d      �� 
���   �$��Center=�63   $��Center=�6P   $��0q�6l   $2 0q�6w   $��27��6�   $��31��6�   ��5e      �� 5f      $/3 )/Cs_Gerencial;component/Imagens/Check.png��6)   ��5h      �� 5i      " ��6$    5j   "   P� 5k   &    �@J�IsMouseOver . . �5l   *   ��   � ��
! ���� 6H   5m   '   5o      5q      5r      5t      �� 5u   
   -
   5        $��txtPlanoConsulta��5u      $	 Upper=�6*   $	
 100��6B   $
��Left=�6R   $��23��6m   $��
18,131,0,0q�6y   $
 Wrap=�6�   $	��Top=�6�   $	��376��6�   6�   �� 5v   
   $ ��Consultar Plano de Contas:��6   $
��Left=�65   $��
18,107,0,0q�6P   $	��Top=�6d   5x      5y      