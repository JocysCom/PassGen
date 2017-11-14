{
	"PresetName": "Hex: GUID - Access",
	"PresetDescription": "Used by developers to fill GUID type cells with values inside Microsoft Access.",
	"CharsExtra": "abcdef",
	"RatioNumbers": 1,
	"RatioExtra": 1,
	"UseNumbers": true,
	"UseExtra": true,
	"PasswordLength": 32,
	"RegexEnabled": true,
	"RegexPatternFind": "(\\S{8})(\\S{4})(\\S{4})(\\S{4})(\\S{12})",
	"RegexPatternReplace": "{$1-$2-$3-$4-$5}"
}