CREATE PROCEDURE delete_car
@Id_cars int
AS
BEGIN
DELETE FROM Cars WHERE Id = @Id_cars
END