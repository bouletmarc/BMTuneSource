; http://www.microsoft.com/downloads/details.aspx?FamilyID=1cc39ffe-a2aa-4548-91b3-855a2de99304

[CustomMessages]
en.dotnetfx20sp1lp_title=.NET Framework 2.0 SP1 Sprachpaket: English

dotnetfx20sp1lp_size=3.4 MB

dotnetfx20sp1lp_url=
en.dotnetfx20sp1lp_url=http://download.microsoft.com/download/8/a/a/8aab7e6a-5e58-4e83-be99-f5fb49fe811e/NetFx20SP1_x86de.exe
en.dotnetfx20sp1lp_url_x64=http://download.microsoft.com/download/1/4/2/1425872f-c564-4ab2-8c9e-344afdaecd44/NetFx20SP1_x64de.exe
en.dotnetfx20sp1lp_url_ia64=http://download.microsoft.com/download/a/0/b/a0bef431-19d8-433c-9f42-6e2824a8cb90/NetFx20SP1_ia64de.exe

[Code]
procedure dotnetfx20sp1lp();
begin
	if (CustomMessage('dotnetfx20sp1lp_url') <> '') then begin
		if (netfxspversion(NetFx20, CustomMessage('lcid')) < 1) then
			AddProduct('dotnetfx20sp1' + GetArchitectureString() + '_' + ActiveLanguage() + '.exe',
				'/passive /norestart /lang:ENU',
				CustomMessage('dotnetfx20sp1lp_title'),
				CustomMessage('dotnetfx20sp1lp_size'),
				CustomMessage('dotnetfx20sp1lp_url' + GetArchitectureString()),
				false, false, false);
	end;
end;

[Setup]
