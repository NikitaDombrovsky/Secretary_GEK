   M S B A M L   `   `   `  ����M  IClientSecretaryGEK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:ClientSecretaryGEK.Diploma.Theme ClientSecretaryGEK.Diploma.Theme  5      3    -ClientSecretaryGEK.Diploma.Theme.ThemeAddPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:ClientSecretaryGEK.Diploma.Theme     5        N� Title$  ThemeAddPage��5	      .��5
      � 
������� � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��* �6   .+�5   
   �� $��Название темы��6   $��30��6)   $	��100��65   �� 5   
   $
��ПМ��6   $��1��6   $��30��6+   $	��100��67   �� 5   
   $ ��Преподователь��6   $��2��6)   $��30��66   $	��100��6B   �� 5   
   -   5         ��Name$ Name_PM��5      $��1��6#   $��30��63   $��0,0,10,0q�6?   �� 5   
   -   5        $��BtnAdd��5   o   $��Сохранить��6   $��2��6%   $��9��69   $��0��6F   $	��200��6W   $��25��6c   6}   �� 5   
   -   5         ��Name$ ComboPM��5   ]   $��1��64   $��1��6D   $��30��6Q   $��0,0,10,0q�6o    �� DisplayMemberPath$ Название_ПМ��6�    �� SelectedItem 6   �� *	PDTable+6�   �� 5   
   -   5        $ ComboTeacher��5   e   $��1��6<   $��2��6L   $��30��6Y   $��0,0,10,0q�6|   $ Фамилия��6�    6   �� *TeacherTableALL+6�   � 5    
    K� ZIndex$ -2��6   ���#add3e6$��9��66   $��2��6C   5!      5"      