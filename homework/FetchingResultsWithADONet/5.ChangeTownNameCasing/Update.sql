use MinionsDB

UPDATE Towns
SET TownName = UPPER(TownName)
WHERE TownName <> UPPER(TownName)
AND CountryName = @country