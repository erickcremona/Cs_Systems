   M S B A M L   `   `   `  ����  Cs_Gerencial,    &Cs_Gerencial.Windows.CadastroServentia   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  	Serventia��5   	   $��631.2��6   $	��394��6*    � ShowInTaskbar .   � 
ResizeMode$ NoResize=�6L    � WindowStartupLocation$ CenterOwner=�6c    � Icon$3 -/Cs_Gerencial;component/Imagens/Gerencial.ico��6�    � ShowActivated .   J� OpacityMask
 �   � � WindowStyle$ 
ToolWindow=�6�   ��5      �� 5   
    �� EndPoint$ 0.5,1&�6   	 �� 
StartPoint$	 0.5,0&�6/   .��5      � 
 � Color$
 	#FFFFD5A3��6    � Offset$ 0Q�6-   � 5      $
 White��6   $ 1Q�6)   5	      .��5      � $��0,0,0,1q�6   .+�5   
   �� $��Dados da Serventia��6   $��
21,10,20,0q�6/   $	��538��6C   $	��Top=�6P   .��5      � -   5        $��0,0,-2,1q�5      .+�5      �� $��Código��6   $
��Left=�6)   $��	10,10,0,0q�6D   $	��Top=�6W   �� 5      -   5        $��	txtCodigo��5       �� 	MaxLength$ 4��6+   $��23��69   $��10,36,264,0q�6E    �� TextWrapping$
 Wrap=�6Z   $	��Top=�6o   6�   �� 5      $��Descrição��6   $
��Left=�6-   $��	10,60,0,0q�6H   $	��Top=�6[   �� 5      -   5        $��txtDescricao��5      $��23��6.   $��
10,86,12,0q�6:   $
 Wrap=�6N   $	��Top=�6c   �� 5      $��	Endereço��6   $
��Left=�6,   $��
10,109,0,0q�6G   $	��Top=�6[   �� 5      -   5        $��txtEndereco��5      $��23��6-   $��10,135,12,0q�69   $
 Wrap=�6N   $	��Top=�6c   �� 5      $��Bairro��6   $
��Left=�6*   $��
10,160,0,0q�6E   $	��Top=�6Y   �� 5      -   5        $��	txtBairro��5      $��23��6+   $��10,186,12,0q�67   $
 Wrap=�6L   $	��Top=�6`   �� 5      $��Cidade��6   $
��Left=�6*   $��
10,210,0,0q�6E   $	��Top=�6Y   �� 5      -   5        $��	txtCidade��5      $��23��6+   $��10,236,80,0q�67   $
 Wrap=�6L   $	��Top=�6a   �� 5      $��UF��6   $
��Left=�6%   $��262,210,0,0q�6@   $	��Top=�6U   �� 5      -   5        $��txtUf��5      $ 2��6'   $��23��65   $��262,236,12,0q�6A   $
 Wrap=�6W    �� CharacterCasing$ Upper=�6k   $	��Top=�6�   �� 5      -	   5         ��Name$ 	txtEstado��5      $��23��6-   $��10,280,12,0q�69   $
 Wrap=�6N   $	��Top=�6b   �� 5      $	��CEP��6   $
��Left=�6&   $��
10,303,0,0q�6A   $	��Top=�6V   �� 5      -
   5        $��txtCep��5      $ 8��6(   $��23��66   $��10,329,234,0q�6B   $
 Wrap=�6X   $	��Top=�6l   6�   �� 5      $��1º Telefone��6   $
��Left=�6.   $��108,303,0,0q�6I   $	��Top=�6^    J� RenderTransformOrigin$ 	0.6,0.269&�6v   �� 5      -   5        $��txtTelefone1��5      $ 10��6.   $��23��6=   $��108,329,122,0q�6I   $
 Wrap=�6`   $	��Top=�6t   6�   �� 5      $��2º Telefone��6   $
��Left=�6.   $��220,303,0,0q�6I   $	��Top=�6^   �� 5       -   5        $��txtTelefone2��5       $ 10��6.   $��23��6=   $��220,329,12,0q�6I   $
 Wrap=�6_   $	��Top=�6t   6�   �� 5!      $��Responsável��6   $
��Left=�6.   $��
12,354,0,0q�6I   $	��Top=�6]   �� 5"      -   5        $��txtResponsavel��5"      $��23��60   $��12,380,10,0q�6<   $
 Wrap=�6Q   $	��Top=�6e   �� 5#      $��Substituto(a)��6   $
��Left=�60   $��
12,403,0,0q�6K   $	��Top=�6_   �� 5$      -   5        $��txtSubstituto��5$      $��23��6/   $��12,429,10,0q�6;   $
 Wrap=�6P   $	��Top=�6d   �� 5%      $��E-Mail��6   $
��Left=�6)   $��
12,457,0,0q�6D   $	��Top=�6X   �� 5&      -   5        $��txtEmail��5&      $��23��6*   $��12,483,10,0q�66   $
 Wrap=�6K   $ Lower=�6_   $	��Top=�6w   �� 5'      ���	#FFF4F4F5$
��Left=�6-   $��64��6H   $��74,4,0,0q�6T   
���   �$	��Top=�6u   $	��249��6�   �� 5(      -   5        $��ckbDistribuicao��5(      $��DISTRIBUIÇÃO��62   $
��Left=�6I   $��79,5,0,0q�6d   $	��Top=�6v   $	��102��6�   6�   �� 5)      -   5        $��ckbProtesto��5)      $��PROTESTO��6.   $
��Left=�6A   $��	79,52,0,0q�6\   $	��Top=�6o   $	��102��6�   6�   �� 5*      -   5        $��ckbNotas��5*      $��NOTAS��6+   $
��Left=�6;   $	��Top=�6V   $	��102��6n   $��	79,20,0,0q�6z   6�   �� 5+      -   5        $��ckbRgi��5+      $	��RGI��6)   $
��Left=�67   $	��Top=�6R   $	��107��6j   $��	186,5,0,0q�6v   6�   �� 5,      -   5        $��ckbRcpn��5,      $
��RCPN��6*   $
��Left=�69   $	��Top=�6T   $	��102��6l   $��	79,36,0,0q�6x   6�   �� 5-      -   5        $��ckbTitulosDocumentos��5-      $	��RTD��67   $
��Left=�6E   $	��Top=�6`   $	��131��6x   $��
186,20,0,0q�6�   6�   �� 5.      -   5        $��ckbRcpj��5.      $
��RCPJ��6*   $
��Left=�69   $	��Top=�6T   $	��131��6l   $��
186,36,0,0q�6x   6�   �� 5/      -   5        $��ckbInterdicoesTutelas��5/      $��INT. E TUTELAS��68   $
��Left=�6Q   $	��Top=�6l   $	��131��6�   $��
186,52,0,0q�6�   6�   �� 50      $��Estado��6   $
��Left=�6*   $��
10,254,0,0q�6E   $	��Top=�6Y   52      54      �� 55   
   -   5        $��	btnSalvar��55      $��273,553,20,10q�6"   $��0q�69   $��0q�6E    � Cursor$
 Hand��6Y    � ToolTip$ Salvar��6g   ��56      �� 57      ��59      �� 5:      .R�5;      �� 
���   �$��Center=�64   $��Center=�6Q   $��0q�6m    �� Padding$ 0q�6x   $��21��6�   $��37��6�   ��5<      �� 5=       �� ImageSource$/ )/Cs_Gerencial;component/Imagens/Check.png��6)   ��5?      �� 5@       �� 
TargetType" ��6$    �� Triggers 5A   "   P� 5B   &    P� Property �@J�IsMouseOver P� Value . . �5C   *   ��  �� Property � �� �� Value
 ���� 6H   5D   '   5F      5H      5I      5K      �� 5L   
   -   5        $��btnCancelar��5L      $��173,553,120,10q�6$   $��0q�6<   $��0q�6H   $
 Hand��6\   $ Cancelar��6j   ��5M      �� 5N      ��5P      �� 5Q      .R�5R      �� 
���   �$��Center=�64   $��Center=�6Q   $��0q�6m   $ 0q�6x   $��21��6�   $��37��6�   ��5S      �� 5T      $2 ,/Cs_Gerencial;component/Imagens/Cancelar.png��6)   ��5V      �� 5W      " ��6$    5X   "   P� 5Y   &    �@J�IsMouseOver . . �5Z   *   ��  � ��
 ���� 6H   5[   '   5]      5_      5`      5b      5c      5d      