   M S B A M L   `   `   `  ����  Cs_Gerencial)    #Cs_Gerencial.Windows.CadastroBancos   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$)  #Livro Auxiliar - Cadastro de Bancos��5   	   $	��362��65   $	��418��6B    � Icon$3 -/Cs_Gerencial;component/Imagens/Gerencial.ico��6N    � 
ResizeMode$ NoResize=�6�    � ShowInTaskbar .   � WindowStartupLocation$ CenterOwner=�6�   ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FFE8BE83��6    � Offset$ 0Q�6-   � 5      $ White��6   $ 1Q�6)   5	      .��5      � .+�5   
   �� $��Dados do Banco��6   $	��112��6+   $��	10,10,0,0q�68   $	��Top=�6K   $
��Left=�6c   $	��382��6~   .��5      � -   5        $��	gridBanco��5      $��	0,0,-3,-1q�6$   $
��Left=�67   $	��373��6R   .+�5      �� -   5        $��	txtCodigo��5      	 �� 	MaxLength$	 7��6+   
 �� CharacterCasing$
 Upper=�69   $��1��6Q   $
��Left=�6^   $��23��6y   $��9,20,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��100��6�   �� 5      $��Código:��6   $
��Left=�6*   $��9,-3,0,0q�6E   $	��Top=�6W   �� 5      -   5        $��
txtAgencia��5      $	 20��6,   $��2��6;   $
 Upper=�6H   $
��Left=�6`   $��23��6{   $��
135,20,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��100��6�   �� 5      $��	Agência:��6   $
��Left=�6+   $��
135,-3,0,0q�6F   $	��Top=�6Z   �� 5      -   5        $��txtConta��5      $	 20��6*   $��3��69   $
 Upper=�6F   $
��Left=�6^   $��23��6y   $��
262,20,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��100��6�   �� 5      $��
Nº Conta:��6   $
��Left=�6,   $��
262,-3,0,0q�6G   $	��Top=�6[   �� 5      -   5        $��txtNomeBanco��5      $	 60��6.   $
 Upper=�6=   $��4��6U   $
��Left=�6b   $��23��6}   $��9,61,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��353��6�   �� 5      $��Nome do Banco:��6   $
��Left=�61   $��9,40,0,0q�6L   $	��Top=�6^   5      5      �� 5   
   -   5         ��Name$ btnAdicionar��5      $��0q�6'   $��0q�63    � Cursor$
 Hand��6G    � ToolTip$ 	Adicionar��6U   $��50��6i   $	��Top=�6u    J� RenderTransformOrigin$ -0.357,0.569&�6�   $��
10,127,0,0q�6�   $
��Left=�6�   $��53��6�   ��5      �� 5      ��5      �� 5      .R�5      �� 
���   �$��Center=�63   $��Center=�6P   $��0q�6l    �� Padding$ 0q�6w   $��27��6�   $��31��6�   ��5      �� 5        �� ImageSource$; 5/Cs_Gerencial;component/Imagens/AdicionarRegistro.png��6)   ��5"      �� 5#       �� 
TargetType" ��6$    �� Triggers 5$   "   P� 5%   &    P� Property �@J�IsMouseOver P� Value . . �5&   *   ��  �� Property � �� �� Value
 ���� 6H   5'   '   5)      5+      5,      5.      �� 5/   
   -   5        $ btnCancelar��5/      $��0q�6&   $��0q�62   $
 Hand��6F   $ Cancelar��6T   $��50��6g   $	��Top=�6s   $ -0.357,0.569&�6�   $��281,127,0,0q�6�   $
��Left=�6�   $��53��6�   ��50      �� 51      ��53      �� 54      .R�55      �� 
���   �$��Center=�63   $��Center=�6P   $��0q�6l   $ 0q�6w   $��27��6�   $��31��6�   ��56      �� 57      $2 ,/Cs_Gerencial;component/Imagens/Cancelar.png��6)   ��59      �� 5:      " ��6$    5;   "   P� 5<   &    �@J�IsMouseOver . . �5=   *   ��  � ��
 ���� 6H   5>   '   5@      5B      5C      5E      �� 5F   
   -	   5        $ 	btnSalvar��5F      $��6��6$   $��0q�61   $��0q�6=   $
 Hand��6Q   $ Salvar��6_   $��50��6p   $	��Top=�6|   $ -0.357,0.569&�6�   $��339,127,0,0q�6�   $
��Left=�6�   $��53��6�   ��5G      �� 5H      ��5J      �� 5K      .R�5L      �� 
���   �$��Center=�63   $��Center=�6P   $��0q�6l   $ 0q�6w   $��27��6�   $��31��6�   ��5M      �� 5N      $/ )/Cs_Gerencial;component/Imagens/Check.png��6)   ��5P      �� 5Q      " ��6$    5R   "   P� 5S   &    �@J�IsMouseOver . . �5T   *   ��  � ��
 ���� 6H   5U   '   5W      5Y      5Z      5\      &   System.Windows.Controls.DataGrid  5]   
   -
   5          Name$ dataGridBancos��5]   �      AutoGenerateColumns .   �� AlternationCount$ 2��6/      RowBackground
 �����   AlternatingRowBackground �	#FF8DE1FF   
IsReadOnly .    SelectionMode$ Single=�6�    J� 	AllowDrop .      HeadersVisibility$	  All=�6�   !   CanUserResizeRows! .  "   SelectionUnit$" FullRow=�6  #   GridLinesVisibility$
# None=�6  $   ClipboardCopyMode$$ ExcludeHeader=�67  $%   HorizontalScrollBarVisibility$
% Auto=�6Y  & � UseLayoutRounding& . ��. $��	0,182,0,0q�6�  ��6�  Z� '   	CellStyle' 5^      �� 5_      *  $System.Windows.Controls.DataGridCell"  6    5`      P� 5a       �@ 
IsSelected . . �5b      ��  � �� �	#FF0086FF6;   5c      5e      (   Columns( 5h      0  *System.Windows.Controls.DataGridTextColumn  5i      ,  &System.Windows.Controls.DataGridColumn)   Header$	) Ato��6%   *   Width5  /System.Windows.Controls.DataGridLengthConverter$* 50 62   +   CanUserResize+ .  ,   
Visibility$, Hidden=�6p   1  +System.Windows.Controls.DataGridBoundColumn-   Binding- 6=   �� *
BancosId+6p     5j      $) Código��6%   $* 95 65   + .  - 6@   �� *Codigo+6[     5k      $) Nome do Banco��6%   $	* 300 6<   + .  - 6H   �� *Nome+6a   . � ContextMenu. 5m      �� 5n      -   5        / ��Name$
/ menu��5n   L   0 �� 
IsSelected0 . 1 � ForceCursor1 . .@�5o      m� -   5        2 m�Name$2 MenuItemAlterar��5o   0   $��Alterar��6   $
 Hand��6I   ���	#FF4F4F4F
����������	#FFF1BF773 m� Icon3 5p      �� 5q      $7��1/Cs_Gerencial;component/Imagens/modifyPequeno.png��6$   5s      m� 5t      -   5        $2 MenuItemExcluir��5t   0   $��Excluir��6   $
 Hand��6I   ���	#FF4F4F4F
����������	#FFF1BF773 5u      �� 5v      $8��2/Cs_Gerencial;component/Imagens/ExcluirPequeno.png��6$   5x      5y      5{      5|      5}      