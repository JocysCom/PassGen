{
	"PresetName": "Script: HMACMD5",
	"PasswordLength": 8,
	"RegexEnabled": true,
	"RegexPatternFind": "Enter Secret Key here",
	"RegexPatternReplace": "Enter URL Address here",
	"ScriptEnabled": true,
	"ScriptLanguage": "CSharp",
	"ScriptEntry": "Class1.Main",
	"ScriptCode": "using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Text;\r\nusing JocysCom.ClassLibrary.Security.Password;\r\n\r\nnamespace Scripts\r\n{\r\n\tpublic partial class Class1\r\n\t{\r\n\t\tpublic string Main(Generator generator, Word password)\r\n\t\t{\r\n\t\t\t// Use Regular Expression fields:\r\n\t\t\t// \"Find Pattern\" for HMACMD5 Key\r\n\t\t\t// \"Replace Pattern\" for HMACMD5 Value\r\n\t\t\tvar key = System.Text.Encoding.UTF8.GetBytes(generator.Preset.RegexPatternFind);\r\n\t\t\tvar bytes = System.Text.Encoding.UTF8.GetBytes(generator.Preset.RegexPatternReplace);\r\n\t\t\tvar hmac = new System.Security.Cryptography.HMACMD5(key);\r\n\t\t\tvar hashBytes = hmac.ComputeHash(bytes);\r\n\t\t\treturn new Guid(hashBytes).ToString();\r\n\t\t}\r\n\t}\r\n}"
}



