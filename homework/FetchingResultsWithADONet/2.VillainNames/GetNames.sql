use MinionsDB

SELECT v.Name, COUNT(vm.MinionId) as [MinionsCount]
FROM Villains as v
INNER JOIN VillainsMinions as vm
ON v.Id = vm.VillainId
GROUP BY v.Name
HAVING COUNT(vm.MinionId) > 3
ORDER BY [MinionsCount] DESC