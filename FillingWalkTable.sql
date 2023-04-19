DECLARE @i INT
DECLARE @imei varchar(50)
DECLARE @latitude decimal(12,9)
DECLARE @longitude decimal(12,9)
DECLARE @date datetime
DECLARE @row_id int

SET @i = 1
WHILE @i <= (SELECT COUNT(*) FROM TrackLocation) 
BEGIN 

SELECT @imei = IMEI, @longitude = longitude, @latitude = latitude, @date = date_track, @row_id = row_id
FROM (SELECT *,  ROW_NUMBER() OVER(ORDER BY IMEI, date_track) AS row_id FROM TrackLocation) AS TMP
WHERE row_id = @i

    IF DATEDIFF(MINUTE, (SELECT date_track FROM (SELECT date_track,  ROW_NUMBER() OVER(ORDER BY IMEI, date_track) AS row_id FROM TrackLocation) AS TMP WHERE row_id = @row_id - 1),
	(SELECT date_track FROM (SELECT date_track,  ROW_NUMBER() OVER(ORDER BY IMEI, date_track) AS row_id FROM TrackLocation) AS TMP WHERE row_id = @row_id)) < 30 
	AND (SELECT IMEI FROM Walk WHERE id = (SELECT COUNT(*) FROM Walk)) = @imei
		BEGIN
			UPDATE Walk
			SET end_time = @date, distance = distance + SQRT(POWER(longitude - @longitude, 2) + POWER(latitude - @latitude, 2)), longitude = @longitude, latitude = @latitude
			WHERE id = (SELECT COUNT(*) FROM Walk)
		END

	ELSE 
	BEGIN
		INSERT INTO Walk(IMEI, start_time, end_time, longitude, latitude, distance)
		VALUES(@imei, @date, @date, @longitude, @latitude, 0)
	END
		SET @i = @i + 1; 
END