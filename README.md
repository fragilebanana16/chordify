# CHORDIFY
#### DESCRIPTION
winform in csharp
#### PREVIEW
![Image text](https://github.com/fragilebanana16/chordify/blob/master/preview.png)
#### LOG
[FEATURE]Play and Stop misc with "winmm.dll"
[FEATURE]XCoolForm as base form

##### 2021/03/08
[PLAN]Trying to draw chord with GDI+ 
here is the tutorial:
A glance(https://www.c-sharpcorner.com/article/gdi-tutorial-for-beginners/)
MSDN(https://docs.microsoft.com/en-us/dotnet/api/system.drawing?redirectedfrom=MSDN&view=net-5.0)

[TIPS]using System.Drawing; and add reference under REFERENCE-ASSEMBLY(not SOLUTION or COM)

##### 2021/03/09
[FIXEDWTF]In "protected override void OnPaint()", will print multiple times, like Writeln("A"), in debug mode it outputs A\nA\nA, thats because form updates each time u open it. So dont output data in updating forms, it confuses u.

[FEATURE]A complete chord grid and points are accomplished, addition chord with offset is done.

[TODO]Add more chords patterns(like Cmajor "1","9","16")

##### 2021/03/10
[PLAN]MCI play music
[FEATURE] track bar maximum 10000, trackBar1.Value = (int)(trackBarPos * 10000)

##### 2021/03/11
[FEATURE]store chords positions in app.config
[WOW]use string.Join(",", chordsList.ElementAt(0)) to output string array, not just chordsList.ElementAt(0)

[FEATURE]add XCoolForm.dll  reference and inherent it 'Form1:XCoolForm.XCoolForm', no 'Form', dont override onPaint
to the back form, if u do, this will clear the XCoolForm pattern, so add a panel, double click to 'panel_paint()' override it instead.

##### 2021/03/17

[UNKNOWN]Panel1 backcolor as long as set to transparent, exception would occur. 

##### 2021/03/20
[FEATURE] Add reference "using System.Data.SQLite;"(D:\2013\bin)(download first, not sqlite3.exe version but a setup bundle on official website), note this dll is 32bit(however my platform is 64, but it will work),

see
https://www.sqlite.org/lang.html
https://www.jb51.net/article/87908.htm
https://www.codeproject.com/Articles/746191/SQLite-Helper-Csharp
for more
