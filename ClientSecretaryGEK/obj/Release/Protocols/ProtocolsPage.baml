   M S B A M L   `   `   `  ���� M  IClientSecretaryGEK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:ClientSecretaryGEK.ProtocolsClientSecretaryGEK.Protocols  0    *ClientSecretaryGEK.Protocols.ProtocolsPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <local*clr-namespace:ClientSecretaryGEK.Protocols       N� Title$  ProtocolsPage��.���  � RowDefinitions �� $��70 ��� $��* �.+��  K� ZIndex$ -2�����#add3e6$��0��$��-1,0,1,0q�.+��� -    ��Name$ BtnAdd��$��Добавить��$
��Left=�$	��125��$��32��$��Bottom=�$��
141,0,0,13q�&   System.Windows.Controls.DataGrid  -   $	��dgv��$��1��$��10,69,10,10q�(  "System.Windows.Controls.DatePicker  -     Name$ 
DatePick_1��$
��Left=�$��	10,10,0,0q�$��1��$	��Top=�$��39��$	��271��   SelectedDate �� *Date+ �� Mode$ OneWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . �� -   	 ��Name$	 
ComboGroup��
 �� DisplayMemberPath$1
 +Название_Специальности��$
��Left=�$��
303,14,0,0q�$��1��$	��Top=�$	��271��$��30�� �� SelectedItem �� *StudentTableProtocols+