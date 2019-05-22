Some assumptions:
1.	CSV file has ‘,’ as delimiter.
2.	Column CAD is a flag column which can have 0 or 1
3.	Column name 2 in file no 1 is RSSP column in target
4.	Class clsTarget is define to provide main field Map and Write to file function
5.	Used AbsFile Class to make system extendable (An abstract class)
6.	Used FlagHeader in abstract class to manage has or has not header on each file
7.	Child Class FileOne and FileTwo
8.	Each Child class has its own Field Mapping
9.	Child Class FileOne has override function to read and ExecFile 
10.	Child Class FileTwo has only its field mapping
11.	Using ThreashHold (50K rows) value in Abstract Class to avoid memory issues while reading files

i.e. Map:-
            MyMap["AccountCode"]=1;
            MyMap["Name"]=2;
            MyMap["Type"]=3;
            MyMap["Open Date"]=4;
            MyMap["Currency"]=5;
            MyMap["AbcCode"]=6;
            MyMap["My Account"]=7;
            MyMap["RRSP"]=8;
            MyMap["2018-01-01"]=9;
            MyMap["CAD"]=10;


 
