SELECT Car.Name, CarType.CarTypeName FROM CarType
JOIN Car ON Car.TypeId=CarType.Id 
WHERE CarType.CarTypeName LIKE 'Tesla'
WHERE CarType.CarTypeName LIKE 'BMW'
WHERE CarType.CarTypeName LIKE 'Toyota'
WHERE CarType.CarTypeName LIKE 'Skoda'