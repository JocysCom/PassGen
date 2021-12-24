DECLARE @table as TABLE([Key] varchar(1), [Value] varchar(2))

INSERT INTO @table
SELECT DISTINCT * FROM (
	SELECT LOWER(SUBSTRING([Name], LEN([NAME]) - 2, 1)) as FnL, SUBSTRING([Name], LEN([NAME]) - 1, 2) as FnEnd 
	FROM [Test].[Anonymous].[FirstName]
	WHERE LEN([Name]) >= 3
	UNION
	SELECT LOWER(SUBSTRING([Name], LEN([NAME]) - 2, 1)) as FnL, SUBSTRING([Name], LEN([NAME]) - 1, 2) as FnEnd 
	FROM [Test].[Anonymous].[LastName]
	WHERE LEN([Name]) >= 3
) t1
ORDER BY FnL, FnEnd

--SELECT * FROM @table ORDER BY [Key], [Value]

SELECT DISTINCT t.[Key], (
		SELECT ',' + cm.[Value]
		FROM @table AS CM
		WHERE t.[Key] = cm.[Key]
		ORDER BY cm.[Value]
		FOR XML PATH(''), TYPE
	-- Case sensitive.
	).value('substring(text()[1], 2)', 'VARCHAR(MAX)') AS [Values]
FROM @TABLE AS T;