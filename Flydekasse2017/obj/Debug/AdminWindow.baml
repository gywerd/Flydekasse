   M S B A M L   `   `   `  ����I  EFlydekasse2017, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Flydekasse2017Flydekasse2017  5   	        Flydekasse2017.AdminWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Flydekasse2017     5   	   -   5          � Title$$  Material Data - Administration��5   	   $	��300��5	   	   $	��600��5
   	    � 
ResizeMode$ CanMinimize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   �� -   5         ��Name$ buttonUpdateMaterial��5      $��Update Material��5      $
��Left=�5      $��
20,105,0,0q�5      $	��Top=�5      $	��280��5      $y�Hidden=�5      �� 5   
   -   5        $ buttonRemoveMaterial��5      $��Remove Material��5      $
��Left=�5      $��
20,170,0,0q�5      $	��Top=�5      $	��280��5      $y�Hidden=�5      �� 5   
   -   5        $ buttonUpdateFile��5      $��Update File��5       $
��Left=�5!      $��
20,105,0,0q�5"      $	��Top=�5#      $	��280��5$      $y�Hidden=�5&      �� 5'   
   -   5        $ buttonAddMaterial��5'      $��Add Material��5(      $
��Left=�5)      $��
20,235,0,0q�5*      $	��Top=�5+      $	��280��5,      5-      �� 5.   
   -   5         ��Name$ labelMaterial��5.      $��	Material:��5/      $
��Left=�50      $��	20,15,0,0q�51      $��27��52      $	��115��53      $	��Top=�54      �� 55   
   -   5         ��Name$ textBoxMaterial��55      $
��Left=�56      $��23��57      $��
145,20,0,0q�58       �� TextWrapping$
 Wrap=�59      $	��Top=�5;      $	��155��5<      ��5:      �� *strMaterialName+5<      �� 5=   
   -   5        $ labelWeightPerM3��5=      $��Weight per m3 (Kg):��5>      $
��Left=�5?      $��	20,55,0,0q�5@      $��27��5A      $	��115��5B      $	��Top=�5C      �� 5D   
   -	   5        $ textBoxWeightPerM3��5D      $
��Left=�5E      $��23��5F      $��
145,60,0,0q�5G      $
 Wrap=�5H      $	��Top=�5J      $	��155��5K      ��5I      �� *strMaterialWeight+5K      �� 5L   
   -
   5         ��Name$ groupBox��5L      $��Material Data��5M      $
��Left=�5N      $��
320,10,0,0q�5O      $	��250��5P      $	��250��5Q      $	��Top=�5R      .��5S      � .+�5T      �� -   5         ��Name$ listMaterialData��5T      $
��Left=�5V      $	��Top=�5W      ��5U      �� *MaterialData+	 �� View	 5Y      �� 5Z      -   5        grdMaterialData��.P�5[      �� $��Material��6-   
 �� Width$	
 100��5\   -    �� DisplayMemberBinding 5]   -   �� *strMaterialName+�� 5^      $��Weight per m3 (Kg)��6-   $	
 130��5_   -    5`   -   �� *strMaterialWeight+5a      5c      5d      5f      5h      5i      