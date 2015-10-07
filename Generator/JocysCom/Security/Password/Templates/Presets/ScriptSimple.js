{
	"PresetName": "Script: Simple",
	"PasswordLength": 6,
	"UseUppercase": true,
	"RatioUppercase": 1,
	"FilterRemember": true,
	"ScriptEnabled": true,
	"ScriptLanguage": "CSharp",
	"ScriptEntry": "Class1.Main",
	"ScriptCode": "using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Text;\r\nusing JocysCom.ClassLibrary.Security.Password;\r\n\r\nnamespace Scripts\r\n{\r\n    public partial class Class1\r\n    {\r\n        public string Main(Generator generator, Word password)\r\n        {\r\n            var prefix = DateTime.Now.ToString(\"yyMMdd_\");\r\n            return prefix+password.Text;\r\n        }\r\n    }\r\n}\r\n"
}