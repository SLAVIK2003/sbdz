CREATE PROCEDURE add_cars
	@Id_cars INT,
	@Brand NCHAR (40),
	@Model NCHAR (40),
	@Trim NCHAR (40),
	@Year INT,
	@Price INT,
	@Photo IMAGE,
	@ret INT OUTPUT
	AS
	IF @Id_cars = (SELECT Id FROM Cars WHERE Id = @Id_cars )
	BEGIN
	SET @ret=0
	RETURN
	END
	ELSE
	BEGIN
	INSERT INTO Cars( Id, Brand, Model, Trim, Year, Price, Photo) VALUES(@Id_cars, @Brand, @Model, @Trim, @Year, @Price, @Photo)
	SET @ret=1
	END
	RETURN