DECLARE @table as TABLE([Key] varchar(2), [Value] varchar(1))

INSERT INTO @table
SELECT DISTINCT * FROM (
	SELECT LOWER(SUBSTRING([Name], 1, 2)) as FnL, LOWER(SUBSTRING([Name], 3, 1)) as FnBegin 
	FROM [Test].[Anonymous].[FirstName]
	WHERE LEN([Name]) >= 3
	UNION
	SELECT LOWER(SUBSTRING([Name], 1, 2)) as FnL, LOWER(SUBSTRING([Name], 3, 1)) as FnBegin 
	FROM [Test].[Anonymous].[LastName]
	WHERE LEN([Name]) >= 3
) t1
ORDER BY FnL, FnBegin

--SELECT * FROM @table ORDER BY [Key], [Value]

SELECT DISTINCT t.[Key], (
		SELECT ',' + cm.[Value]
		FROM @table AS CM
		WHERE t.[Key] = cm.[Key]
		ORDER BY cm.[Value]
		FOR XML PATH(''), TYPE
	-- Case sensitive.
	).value('substring(text()[1], 2)', 'VARCHAR(MAX)') AS [Values]
FROM @TABLE AS T
ORDER BY [Key], [Values]
