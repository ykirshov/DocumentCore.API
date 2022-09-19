<h1>DocumentCore.API</h1>
<h4>DocumentCore includes:</h4>
<ul>
    <li>Convert Rtf, Doc, Html and other formats of file to PDF.</li>
    <li>Convert PDF to Jpeg</li>
    <li>Create Excel file .xls of data that you send</li>
</ul>
All this stuff is implementedd by using DevExpress library. You don't need to install it manualy, it is in the projeect as class libraries .dll.<br>
To see swagger run your web api and type <code>https://localhost:44374/swagger/ui/index#/</code> in your browser.

<h4>For developers:</h4>
    <ul>
	<li>You should have DocumentCore.API in your IIS Server folder. It's important if you want to test local rtf file.<br>
	    You can find it in current project in folder <code>Examples</code>. It contains RtfTest.rtf file.<br>
	    Copy this folder to new folder <code>DocumentCore.API</code> in your IIS Server.</li>
    <li>If you have an error while downloading and running api, you should restore all Nuget packages.<br>
    Then type in Nuget console :<br>
            <code>Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r</code><br>
    This will help you.<br></li>
	</ul>
