/****** Object:  StoredProcedure [dbo].[GetNextBookingSlotsWindow]    Script Date: 30/01/2015 21:11:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mark Hirst
-- Create date: 30 Jan 2015
-- Description:	Get the booking slots over a period of days that are within opening hours
-- =============================================
CREATE PROCEDURE [dbo].[GetNextBookingSlotsWindow] 

	@LocationId int, 
	@CurrentDateTime datetime
AS
BEGIN

	declare @DayOne Date
	declare @DayTwo Date
	declare @DayThree Date

	select @DayOne = CONVERT(date, @CurrentDateTime)
	select @DayTwo = DATEADD(DAY, 1, @DayOne)
	select @DayThree = DATEADD(DAY, 2, @DayOne)

	set datefirst 1

	select 
		TimeSlot.Id as TimeSlotId,
		@LocationId as LocationId,
		BookingDays.BookingDay,
		BookingDays.WeekDay,
		TimeSlot.StartTime, 
		TimeSlot.EndTime,
		(select count(id) from SessionBooking where LocationId = @LocationId and TimeSlotId = TimeSlot.Id and [Date] = BookingDays.BookingDay) as BookingCount,
		(select AvailableSlots from Location where Id = @LocationId) as AvailableSlots, Status = 
		CASE   
			WHEN OpeningHourOverride.LocationId is not null and 
			TimeSlot.StartTime between OpeningHourOverride.AltOpenTime and OpeningHourOverride.AltCloseTme and 
			TimeSlot.EndTime between OpeningHourOverride.AltOpenTime and OpeningHourOverride.AltCloseTme THEN 'Closed'
			ELSE 'Available'
		END 
	from 
		TimeSlot, 
		(select @DayOne as BookingDay, DATEPART(dw, @DayOne) as WeekDay UNION ALL SELECT @DayTwo as BookingDay, DATEPART(dw, @DayTwo) as WeekDay UNION ALL SELECT @DayThree as BookingDay, DATEPART(dw, @DayThree) as WeekDay) as BookingDays

	join 
		OpeningHour 
	on 
		OpeningHour.[DateOfWeek] = BookingDays.WeekDay and
		OpeningHour.LocationId = @LocationId   
	left join 
		OpeningHourOverride 
	on 
		OpeningHourOverride.LocationId = @LocationId and
		BookingDays.BookingDay between OpeningHourOverride.OverrideStartDate and OpeningHourOverride.OverrideEndDate  
	where 
		TimeSlot.StartTime between OpeningHour.OpenTime and OpeningHour.CloseTime and 
		TimeSlot.EndTime between OpeningHour.OpenTime and OpeningHour.CloseTime 
	order by 
		BookingDays.BookingDay,
		TimeSlot.StartTime

END

GO

