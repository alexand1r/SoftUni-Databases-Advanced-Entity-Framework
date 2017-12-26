use MinionsDB

SELECT TownName FROM towns
WHERE TownName = UPPER(TownName)
AND CountryName = @country;