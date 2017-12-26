use MinionsDB

SELECT t.Id, t.TownName FROM Towns as t
WHERE t.TownName=@name