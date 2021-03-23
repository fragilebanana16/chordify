# CHORDIFY
#### DESCRIPTION
winform in csharp
#### PREVIEW
![Image text](https://github.com/fragilebanana16/chordify/blob/master/preview.png)
#### LOG
[FEATURE]Play and Stop misc with "winmm.dll"
[FEATURE]Movable without tiltle bar

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
[WTF]Minimize the window and reopen it, exception occurs:
异常:已引发: "矩形“{X=1,Y=-29,Width=0,Height=22}”的宽度或高度不能等于零。" (System.ArgumentException)
引发了一个 System.ArgumentException: "矩形“{X=1,Y=-29,Width=0,Height=22}”的宽度或高度不能等于零。"
时间: 2021/3/17 10:36:27
线程: <无名称>[5748]

*** CALL STACK ***
 	System.Drawing.dll!System.Drawing.Drawing2D.LinearGradientBrush..ctor(System.Drawing.Rectangle rect = {未知}, System.Drawing.Color color1 = {未知}, System.Drawing.Color color2 = {未知}, System.Drawing.Drawing2D.LinearGradientMode linearGradientMode = {未知})	C#
 	XCoolForm.dll!XCoolForm.XStatusBar.RenderStatusBar(System.Drawing.Graphics g = {未知}, int x = {未知}, int y = {未知}, int lWidth = {未知}, int lHeight = {未知})	C#
 	XCoolForm.dll!XCoolForm.XCoolForm.DrawStatusBar(System.Drawing.Graphics g = {未知})	C#
 	XCoolForm.dll!XCoolForm.XCoolForm.OnPaint(System.Windows.Forms.PaintEventArgs e = {未知})	C#
 	System.Windows.Forms.dll!System.Windows.Forms.Control.PaintTransparentBackground(System.Windows.Forms.PaintEventArgs e = {未知}, System.Drawing.Rectangle rectangle = {未知}, System.Drawing.Region transparentRegion = {未知})	C#
 	System.Windows.Forms.dll!System.Windows.Forms.Control.PaintBackground(System.Windows.Forms.PaintEventArgs e = {未知}, System.Drawing.Rectangle rectangle = {未知}, System.Drawing.Color backColor = {未知}, System.Drawing.Point scrollOffset = {未知})	C#
 	System.Windows.Forms.dll!System.Windows.Forms.Control.PaintBackground(System.Windows.Forms.PaintEventArgs e = {未知}, System.Drawing.Rectangle rectangle = {未知})	C#
 	System.Windows.Forms.dll!System.Windows.Forms.Control.OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent = {未知})	C#
 	System.Windows.Forms.dll!System.Windows.Forms.ScrollableControl.OnPaintBackground(System.Windows.Forms.PaintEventArgs e = {未知})	C#
 	System.Windows.Forms.dll!System.Windows.Forms.Control.PaintWithErrorHandling(System.Windows.Forms.PaintEventArgs e = {未知}, short layer = {未知})	C#
 	System.Windows.Forms.dll!System.Windows.Forms.Control.WmEraseBkgnd(ref System.Windows.Forms.Message m = {未知})	C#
 	System.Windows.Forms.dll!System.Windows.Forms.Control.WndProc(ref System.Windows.Forms.Message m = {未知})	C#
 	System.Windows.Forms.dll!System.Windows.Forms.NativeWindow.DebuggableCallback(System.IntPtr hWnd = {未知}, int msg = {未知}, System.IntPtr wparam = {未知}, System.IntPtr lparam = {未知})	C#
 	System.Windows.Forms.dll!System.Windows.Forms.NativeWindow.DefWndProc(ref System.Windows.Forms.Message m = {未知})	C#
 	System.Windows.Forms.dll!System.Windows.Forms.Form.DefWndProc(ref System.Windows.Forms.Message m = {未知})	C#
 	System.Windows.Forms.dll!System.Windows.Forms.Control.WndProc(ref System.Windows.Forms.Message m = {未知})	C#
 	System.Windows.Forms.dll!System.Windows.Forms.Form.WmSysCommand(ref System.Windows.Forms.Message m = {未知})	C#
 	System.Windows.Forms.dll!System.Windows.Forms.NativeWindow.DebuggableCallback(System.IntPtr hWnd = {未知}, int msg = {未知}, System.IntPtr wparam = {未知}, System.IntPtr lparam = {未知})	C#
 	System.Windows.Forms.dll!ComponentManager.System.Windows.Forms.UnsafeNativeMethods.IMsoComponentManager.FPushMessageLoop(System.IntPtr dwComponentID = {未知}, int reason = {未知}, int pvLoopData = {未知})	C#
 	System.Windows.Forms.dll!ThreadContext.RunMessageLoopInner(int reason = {未知}, System.Windows.Forms.ApplicationContext context = {未知})	C#
 	System.Windows.Forms.dll!ThreadContext.RunMessageLoop(int reason = {未知}, System.Windows.Forms.ApplicationContext context = {未知})	C#
>	XCoolFormTest.exe!XCoolFormTest.Program.Main()	C#
 	[外部代码]	
no idea whats going on, in Dll i cant find the RenderStatusBar funtion(no def in meta data) and cant provide the arg x,y etc.then i replicate the project, and found that panel1 backcolor as long as set to transparent, this exception would occur. 

##### 2021/03/20
[FEATURE] Add reference "using System.Data.SQLite;"(D:\2013\bin)(download first, not sqlite3.exe version but a setup bundle on official website), note this dll is 32bit(however my platform is 64, but it`ll work), 
see
https://www.sqlite.org/lang.html
https://www.jb51.net/article/87908.htm
https://www.codeproject.com/Articles/746191/SQLite-Helper-Csharp
for more
