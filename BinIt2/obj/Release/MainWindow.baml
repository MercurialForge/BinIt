   M S B A M L   `   `   `  ���� @  <BinIt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:BinIt2.PropertiesBinIt2.Properties  clr-namespace:BinIt2BinIt2      BinIt2.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -pclr-namespace:BinIt2.Properties     %selfclr-namespace:BinIt2     -     �Name$  	TheWindow�� � Title$) #BinIt - Desktop CleanUp Application�� � Icon$ Resources/favicon.ico��$	��310��$	��755�� � 
ResizeMode$ NoResize=� � 	Resources $   BinIt2.InverseBooleanConverter   InverseBooleanConverter��%   &	          .��� .+��� $��Options��$��	0,22,10,0q�$��Right=�$	��145��$	��165��$	��Top=�.��� $��0,0,-2,0q�.+��� -    ��Name$ m_ignoreShortcuts��$��Ignore Shortcuts��$
��Left=�$��	10,10,0,0q�$	��Top=� d� 	IsChecked ��    BinIt2.Properties.Settings   Default �� Source# Z 	 �� Path$	 IgnoreShortcuts�
 �� Mode$
 TwoWay=��� -   $ m_ignoreFolders��$��Ignore Folders��$
��Left=�$��	10,31,0,0q�$	��Top=� �� # Z $	 IgnoreFolders�$
 TwoWay=��� -   $ m_useDotIgnore��$��Use .ignore��$
��Left=�$��	10,52,0,0q�$	��Top=� �� # Z $	 UseDotIgnore�$
 TwoWay=��� $
��Left=�$	��177��$��	10,10,0,0q�$	��Top=�$	��570�� � DataContext �� *Tabs+.@��� $��
Output Log��.��� ���	#FFFFFFFF.+��� -    ��Name$ m_scrollViewer��.���� -    ��Name$ m_outputLog������ *	OutputLog+�� $��Item Log��.��� ���	#FFFFFFFF.+��� -   $ m_scrollViewer_ItemLog��.���� -   $ 	m_itemLog��$
��Wrap=�$	��557������ *	ItemLog+�� -	    ��Name$ m_dotIgnoreTab��$��.ignore��.��� ���	#FFFFFFFF.+��� -
   $ m_scrollViewer_DotIgnore��.���� -    ��Name$ m_ignoreLog�� �� AcceptsReturn .  �� TextWrapping$
 Wrap=�$��0q����� # Z $	 	DotIgnore�$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�� $
��Left=�$��72��$��
10,192,0,0q�$	��Top=�$	��729��.+��� $��Merge Settings��$��499,12,10,6q�$��53��.��� $
��Left=�$��43��$��
0,0,-2,-12q�$	��Top=�$	��220��.+�	� $��	Keep Both��$
��Left=�$��	10,10,0,0q�$	��Top=� 	� 	GroupName$ MergeSettings�� �� # Z $	 KeepBoth�$
 TwoWay=�	� $��	Overwrite��$
��Left=�$��
105,10,0,0q�$	��Top=�$ MergeSettings�� �� # Z $	 	Overwrite�$
 TwoWay=�� $
��Left=�$��63��$��0,1,0,0q�$	��Top=�$	��494��.+��� -   $ m_useSnapshots��$��Use Snapshot��$��	10,10,0,0q�$	��Top=�$
��Left=�$��98�� �� # Z $	 UseSnapshot�$
 TwoWay=��� -   $��Snapshot��$
��Left=�$��	10,31,0,0q�$	��Top=�$��98���� -   $��BinIt��$
��Left=�$��
123,31,0,0q�$	��Top=�$��75��{��� *	IsChecked+ �� ElementName$ m_useSnapshots�� �� 	Converter# [  