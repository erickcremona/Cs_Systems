   M S B A M L   `   `   `  ����  Cs_Gerencial-    'Cs_Gerencial.Windows.CadastroFornecedor   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$-  'Livro Auxiliar - Cadastro de Fornecedor��5   	   $	��450��69   $	��651��6F    � ShowInTaskbar .   � 
ResizeMode$ NoResize=�6h    � Icon$3 -/Cs_Gerencial;component/Imagens/Gerencial.ico��6~    � WindowStartupLocation$ CenterOwner=�6�   ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FFE8BE83��6    � Offset$ 0Q�6-   � 5      $ White��6   $
 0.71Q�6)   5	      .��5      � .+�5   
   �� $��Cadastro��6   $	��143��6%   $��
31,14,32,0q�62   $	��Top=�6F   .��5      � -   5        $��gridCadastro��5      $��	0,0,-2,-1q�6'   .+�5      �� $��Razão Social:��6   $��0,10,0,0q�60   $	��Top=�6B   $
��Left=�6Z   $��83��6u   �� 5      -   5        $��txtRazaoSocial��5      	 �� CharacterCasing$	 Upper=�60   $��23��6H   
 �� 	MaxLength$	
 120��6T   $��1��6d   $��105,12,10,0q�6q    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   �� 5      $��Nome Fantasia:��6   $��0,48,0,0q�61   $	��Top=�6C   $
��Left=�6[   $	��100��6v   �� 5      -   5        $��txtNomeFantasia��5      $	 Upper=�61   $��23��6I   $	
 100��6U   $��2��6e   $��105,50,10,0q�6r   $
 Wrap=�6�   $	��Top=�6�   �� 5      $��Cpf / Cnpj:��6   $
��Left=�6.   $��
328,87,0,0q�6I   $	��Top=�6]   $��72��6u    J� RenderTransformOrigin$ 
0.48,0.538&�6�   �� 5      -   5        $��
txtCpfCnpj��5      $
 14��6,   {�.  $��23��6M   $��5��6Y   $��408,89,10,0q�6f   $
 Wrap=�6{   $	��Top=�6�   6�   	� 5      -   5        $��rbCpj��5       � Cursor$
 Hand��6+   $	��CPF��69   $��3��6G   $��130,92,361,0q�6T   $	��Top=�6j   6�   	� 5      -   5        $��rbCnpj��5      $
 Hand��6,   $
��CNPJ��6:   $��4��6I   $��244,92,247,0q�6V   $	��Top=�6l   6�   �� 5      $��Tipo Documento:��6   $��0,87,0,0q�62   $	��Top=�6D   $
��Left=�6\   $	��100��6w   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGridFornecedor��5   �      AutoGenerateColumns .   �� AlternationCount$ 2��6/      RowBackground
 �����   AlternatingRowBackground �	#FF8DE1FF   
IsReadOnly .    SelectionMode$ Single=�6�    J� 	AllowDrop .     HeadersVisibility$	 All=�6�      CanUserResizeRows .     SelectionUnit$ FullRow=�6     GridLinesVisibility$
 None=�6      ClipboardCopyMode$ ExcludeHeader=�6;  $   HorizontalScrollBarVisibility$
 Auto=�6]   � UseLayoutRounding . ��. $��	0,226,0,0q�6�  ��6�  Z�    	CellStyle 5      �� 5       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6    �� Triggers 5      P� 5        P� Property  �@ 
IsSelected! P� Value! . . �5      �� " �� Property" � ��# �� Value# �	#FF0086FF6;   5      5!      $   Columns$ 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn%   Header$	% Ato��6%   &   Width5  /System.Windows.Controls.DataGridLengthConverter$& 50 62   '   CanUserResize' .  (   
Visibility$( Hidden=�6t   1  +System.Windows.Controls.DataGridBoundColumn)   Binding) 6=   �� *FornecedorId+6t     5&      $% Razão Social��6%   $	& 350 6;   ' .  ) 6G   �� *RazaoSocial+6g     5'      $% Nome Fantasia��6%   $	& 300 6<   ' .  ) 6H   �� *NomeFantasia+6i   * � ContextMenu* 5)      �� 5*      -	   5        $
��menu��5*   P   + �� 
IsSelected+ . , � ForceCursor, . .@�5+      m� -
   5        $��MenuItemAlterar��5+   4   $��Alterar��6#   $
 Hand��6K   ���	#FF4F4F4F
����������	#FFF1BF77- m� Icon- 5,      �� 5-   "   $7��1/Cs_Gerencial;component/Imagens/modifyPequeno.png��6(   5/      m� 50      -   5        $��MenuItemExcluir��50   4   $��Excluir��6#   $
 Hand��6K   ���	#FF4F4F4F
����������	#FFF1BF77- 51      �� 52   "   $8��2/Cs_Gerencial;component/Imagens/ExcluirPequeno.png��6(   54      55      57      �� 58   
   $��Consulta��6   $
��Left=�6%   $��
31,166,0,0q�6@   $	��Top=�6T   $	��354��6l   $��55��6x   .��59      � -   5        $��gridConsulta��59      $��43��6'   $��
0,-9,-2,-1q�63   $	��Top=�6G   .+�5:      �� -   5        $��cmbTipoConsulta��5:      $
��Left=�62   $��0,13,0,0q�6M   $	��Top=�6_   $	��118��6w   ��6�   Z� 6�   �� 5;      -   5        $��txtConsulta��5;      $	 Upper=�6-   $��23��6E   $��123,13,10,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   6�   5<      5=      �� 5>   
   -   5        . ��Name$. btnAdicionar��5>      $��0q�6'   $��0q�63   $
 Hand��6G   / � ToolTip$/ Adicionar Fornecedor��6U   $��46��6t   $	��Top=�6�   $ -0.357,0.569&�6�   $��390,175,0,0q�6�   $
��Left=�6�   $��53��6�   ��5?      �� 5@      ��5B      �� 5C      .R�5D      �� 
���   �$��Center=�63   $��Center=�6P   $��0q�6l   0 �� Padding$0 0q�6w   $��27��6�   $��31��6�   ��5E      �� 5F      1 �� ImageSource$;1 5/Cs_Gerencial;component/Imagens/AdicionarRegistro.png��6)   ��5H      �� 5I      " ��6$    5J   "   P� 5K   &     �@J�IsMouseOver! . . �5L   *   �� " � ��
# ���� 6H   5M   '   5O      5Q      5R      5T      �� 5U   
   -   5        $. btnCancelar��5U      $��0q�6&   $��0q�62   $
 Hand��6F   $/ Cancelar��6T   $��46��6g   $	��Top=�6s   $ -0.357,0.569&�6�   $��502,175,0,0q�6�   $
��Left=�6�   $��53��6�   ��5V      �� 5W      ��5Y      �� 5Z      .R�5[      �� 
���   �$��Center=�63   $��Center=�6P   $��0q�6l   $0 0q�6w   $��27��6�   $��31��6�   ��5\      �� 5]      $21 ,/Cs_Gerencial;component/Imagens/Cancelar.png��6)   ��5_      �� 5`      " ��6$    5a   "   P� 5b   &     �@J�IsMouseOver! . . �5c   *   �� " � ��
# ���� 6H   5d   '   5f      5h      5i      5k      �� 5l   
   -   5        $. 	btnSalvar��5l      $��6��6$   $��0q�61   $��0q�6=   $
 Hand��6Q   $/ Salvar Fornecedor��6_   $��46��6{   $	��Top=�6�   $ -0.357,0.569&�6�   $��560,175,0,0q�6�   $
��Left=�6�   $��53��6�   ��5m      �� 5n      ��5p      �� 5q      .R�5r      �� 
���   �$��Center=�63   $��Center=�6P   $��0q�6l   $0 0q�6w   $��27��6�   $��31��6�   ��5s      �� 5t      $/1 )/Cs_Gerencial;component/Imagens/Check.png��6)   ��5v      �� 5w      " ��6$    5x   "   P� 5y   &     �@J�IsMouseOver! . . �5z   *   �� " � ��
# ���� 6H   5{   '   5}      5      5�      5�      5�      5�      