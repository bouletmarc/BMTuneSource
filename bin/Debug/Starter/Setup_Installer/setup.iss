[Setup]
AppId={{DB806A90-C18B-4E6A-8624-FD0671581AED}
AppName=BMTune
AppVersion=1.XX
AppCopyright=Copyright � 2019 Bouletmarc
;VersionInfoVersion=1.XX
;VersionInfoCompany=Bouletmarc
AppPublisher=Bouletmarc
AppPublisherURL=http://www.bmtune.com/
AppSupportURL=http://www.bmtune.com/
AppUpdatesURL=http://www.bmtune.com/
OutputBaseFilename=BMTune
DefaultDirName={pf}\BMTune
UninstallDisplayIcon={app}\BMTune.exe
DisableProgramGroupPage=yes
OutputDir=bin
SourceDir=.
;AllowNoIcons=yes
;SetupIconFile=MyProgramIcon
SolidCompression=yes
PrivilegesRequired=admin
ChangesAssociations=yes
MinVersion=0,5.1.2600
ArchitecturesAllowed=x86 x64 ia64
ArchitecturesInstallIn64BitMode=x64 ia64

; downloading and installing dependencies will only work if the memo/ready page is enabled (default and current behaviour)
;DisableReadyPage=no
;DisableReadyMemo=no

[Tasks]
;Name: "use_dotnetfx11"; Description: Install Microsoft .Net 1.1; Flags: unchecked  
;Name: "use_dotnetfx20"; Description: Install Microsoft .Net 2.0; Flags: unchecked   
;Name: "use_dotnetfx35"; Description: Install Microsoft .Net 3.5; Flags: unchecked
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: checkedonce
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: checkedonce; OnlyBelowVersion: 0,6.1

[Files]
Source: "C:\Users\boule\Documents\Visual Studio 2019\Projects\BMTune2\bin\Debug\Starter\BMTune.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\boule\Documents\Visual Studio 2019\Projects\BMTune2\bin\Debug\Starter\Version.txt"; DestDir: "{app}"; Flags: ignoreversion
;Source: "C:\Users\boule\Documents\Visual Studio 2019\Projects\BMTune2\bin\Debug\Starter\VersionBETA.txt"; DestDir: "{app}"; Flags: ignoreversion 
Source: "C:\Users\boule\Documents\Visual Studio 2019\Projects\BMTune2\bin\Debug\Starter\Help\*"; DestDir: "{app}\Help"; Flags: ignoreversion
Source: "C:\Users\boule\Documents\Visual Studio 2019\Projects\BMTune2\bin\Debug\Starter\Help\Img\*"; DestDir: "{app}\Help\Img"; Flags: ignoreversion
;Source: "C:\Users\boule\Documents\Visual Studio 2019\Projects\BMTune2\bin\Debug\Starter\Interop.MTSSDKLib.dll"; DestDir: "{app}"; Flags: ignoreversion
;Source: "dotNetFx35_Full_setup.exe"; DestDir: {tmp}; Flags: deleteafterinstall; Check: Framework35IsNotInstalled

[Icons]
Name: "{commonprograms}\BMTune"; Filename: "{app}\BMTune.exe"
Name: "{commonprograms}\{cm:UninstallProgram,BMTune}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\BMTune"; Filename: "{app}\BMTune.exe"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\BMTune"; Filename: "{app}\BMTune.exe"; Tasks: quicklaunchicon

[Registry]
Root: HKCR; Subkey: ".bmc";                       ValueData: "BMTune";                Flags: uninsdeletevalue;                      ValueType: string;  ValueName: ""
Root: HKCR; Subkey: ".bml";                       ValueData: "BMTune";                Flags: uninsdeletevalue;                      ValueType: string;  ValueName: ""   
Root: HKCR; Subkey: ".bmg";                       ValueData: "BMTune";                Flags: uninsdeletevalue;                      ValueType: string;  ValueName: ""
Root: HKCR; Subkey: "BMTune";                     ValueData: "BMTune Software";       Flags: uninsdeletekey;                        ValueType: string;  ValueName: ""
Root: HKCR; Subkey: "BMTune\DefaultIcon";         ValueData: "{app}\BMTune.exe,0";                                                  ValueType: string;  ValueName: ""
Root: HKCR; Subkey: "BMTune\shell\open\command";  ValueData: """{app}\BMTune.exe"" ""%1""";                                         ValueType: string;  ValueName: ""

Root: HKCU; SubKey: "SOFTWARE\BMTune";                                                Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKCU; Subkey: "SOFTWARE\BMTune";    ValueData: "98F3B67146F398BA3A885030872E1C41";                   Flags: uninsdeletevalue uninsdeletekeyifempty; ValueType: string; ValueName: "APIGUID"

[Run]
;Filename: "{tmp}\dotNetFx35_Full_setup.exe"; Check: Framework35IsNotInstalled
Filename: "{app}\BMTune.exe"; Description: "{cm:LaunchProgram,BMTune}"; Flags: nowait postinstall skipifsilent runascurrentuser

[Code]
//function Framework35IsNotInstalled: Boolean;
//begin
//  Result := not RegKeyExists(HKEY_LOCAL_MACHINE, 'SOFTWARE\Microsoft\.NETFramework\policy\v3.5');
//end;

Procedure URLLabelOnClick(Sender: TObject);
var
  ErrorCode: Integer;
begin
  ShellExec('open', 'https://www.facebook.com/groups/BMTune/', '', '', SW_SHOWNORMAL, ewNoWait, ErrorCode);
end;

Procedure URLLabel2OnClick(Sender: TObject);
var
  ErrorCode: Integer;
begin
  ShellExec('open', 'https://www.facebook.com/BMTuneSoftware/', '', '', SW_SHOWNORMAL, ewNoWait, ErrorCode);
end;

Procedure URLLabel3OnClick(Sender: TObject);
var
  ErrorCode: Integer;
begin
  ShellExec('open', 'http://www.bmtune.com/', '', '', SW_SHOWNORMAL, ewNoWait, ErrorCode);
end;

{*** INITIALISATION ***}
Procedure InitializeWizard;
var
  URLLabel: TNewStaticText;
  URLLabel2: TNewStaticText;
  URLLabel3: TNewStaticText;
begin
  URLLabel := TNewStaticText.Create(WizardForm);
  URLLabel.Caption := 'Visit BMTune Facebook Group';
  URLLabel.Cursor := crHand;
  URLLabel.OnClick := @URLLabelOnClick;
  URLLabel.Parent := WizardForm;
  { Alter Font *after* setting Parent so the correct defaults are inherited first }
  URLLabel.Font.Style := URLLabel.Font.Style + [fsUnderline];
  URLLabel.Font.Color := clBlue;
  URLLabel.Top := WizardForm.ClientHeight - URLLabel.Height - 25;
  URLLabel.Left := ScaleX(20);

  URLLabel2 := TNewStaticText.Create(WizardForm);
  URLLabel2.Caption := 'Visit BMTune Facebook Page';
  URLLabel2.Cursor := crHand;
  URLLabel2.OnClick := @URLLabel2OnClick;
  URLLabel2.Parent := WizardForm;
  { Alter Font *after* setting Parent so the correct defaults are inherited first }
  URLLabel2.Font.Style := URLLabel2.Font.Style + [fsUnderline];
  URLLabel2.Font.Color := clBlue;
  URLLabel2.Top := WizardForm.ClientHeight - URLLabel2.Height - 10;
  URLLabel2.Left := ScaleX(20);

  URLLabel3 := TNewStaticText.Create(WizardForm);
  URLLabel3.Caption := 'Visit BMTune Website';
  URLLabel3.Cursor := crHand;
  URLLabel3.OnClick := @URLLabelOnClick;
  URLLabel3.Parent := WizardForm;
  { Alter Font *after* setting Parent so the correct defaults are inherited first }
  URLLabel3.Font.Style := URLLabel.Font.Style + [fsUnderline];
  URLLabel3.Font.Color := clBlue;
  URLLabel3.Top := WizardForm.ClientHeight - URLLabel3.Height - 10;
  URLLabel3.Left := ScaleX(180);
end;










