use MinionsDB

SELECT m.Id, m.Name, m.Age FROM Villains as v
JOIN VillainsMinions as mv ON mv.VillainId = v.Id
JOIN Minions as m ON m.Id = mv.MinionId
WHERE v.Id=@villainId