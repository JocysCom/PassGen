DECLARE @table as TABLE([Key] varchar(2), [Value] varchar(1))
DECLARE @table2 as TABLE([Key] varchar(2), [Value] varchar(1))

DECLARE @i int = 1

-- Set to 1 if start of the name, 0 - if middle or end. 
DECLARE @isFbBegin bit = 1

WHILE 1=1 
BEGIN
	INSERT INTO @table
	SELECT DISTINCT * FROM (
		-- Select two letters.
		SELECT TOP (1) LOWER(SUBSTRING([Name], @i, 2)) as FnL, LOWER(SUBSTRING([Name], @i + 2, 1)) as FnBegin 
		FROM [Test].[Anonymous].[FirstName]
		-- Select only if left.
		WHERE LEN([Name]) - @i >= 2
		AND LOWER(SUBSTRING([Name], @i, 1)) <> LOWER(SUBSTRING([Name], @i + 1, 1))
		AND LOWER(SUBSTRING([Name], @i + 1, 1)) <> LOWER(SUBSTRING([Name], @i + 2, 1))
		UNION
		SELECT LOWER(SUBSTRING([Name], @i, 2)) as FnL, LOWER(SUBSTRING([Name], @i + 2, 1)) as FnBegin 
		FROM [Test].[Anonymous].[LastName]
		WHERE LEN([Name]) - @i >= 2
		AND LOWER(SUBSTRING([Name], @i, 1)) <> LOWER(SUBSTRING([Name], @i + 1, 1))
		AND LOWER(SUBSTRING([Name], @i + 1, 1)) <> LOWER(SUBSTRING([Name], @i + 2, 1))
	) t1
	ORDER BY FnL, FnBegin
	IF @@ROWCOUNT = 0 OR @isFbBegin = 1
		BREAK
	SET @i = @i + 1
END

	INSERT INTO @table2
	SELECT DISTINCT [Key], [Value] FROM @TABLE
	ORDER BY [Key], [Value]

SELECT DISTINCT t.[Key], (
		SELECT ',' + cm.[Value]
		FROM @table2 AS CM
		WHERE t.[Key] = cm.[Key]
		ORDER BY cm.[Value]
		FOR XML PATH(''), TYPE
	-- Case sensitive.
	).value('substring(text()[1], 2)', 'VARCHAR(MAX)') AS [Values]
FROM @table2 AS T
ORDER BY [Key], [Values]
