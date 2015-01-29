declare @Location int
declare @Now datetime
declare @DayOne Date
declare @DayTwo Date
declare @DayThree Date

select @Now = CONVERT(date, GetDate())
select @DayOne = CONVERT(date, @Now)
select @DayTwo = DATEADD(DAY, 1, @DayOne)
select @DayThree = DATEADD(DAY, 2, @DayOne)

select @Location = 2

set datefirst 1

select 
	TimeSlot.Id as TimeSlotId,
	@Location as LocationId,
	BookingDays.BookingDay,
	BookingDays.WeekDay,
	TimeSlot.StartTime, 
	TimeSlot.EndTime,
	(select count(id) from SessionBooking where LocationId = @Location and TimeSlotId = TimeSlot.Id and [Date] = BookingDays.BookingDay) as BookingCount,
	(select AvailableSlots from Location where Id = @Location) as AvailableSlots, Status = 
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
	OpeningHour.LocationId = @Location   
left join 
	OpeningHourOverride 
on 
	OpeningHourOverride.LocationId = @Location and
	BookingDays.BookingDay between OpeningHourOverride.OverrideStartDate and OpeningHourOverride.OverrideEndDate  
where 
	TimeSlot.StartTime between OpeningHour.OpenTime and OpeningHour.CloseTime and 
	TimeSlot.EndTime between OpeningHour.OpenTime and OpeningHour.CloseTime 
	/*
	and 
	not (
		OpeningHourOverride.LocationId is not null and 
		TimeSlot.StartTime between OpeningHourOverride.AltOpenTime and OpeningHourOverride.AltCloseTme and 
		TimeSlot.EndTime between OpeningHourOverride.AltOpenTime and OpeningHourOverride.AltCloseTme)
	*/
order by 
	BookingDays.BookingDay,
	TimeSlot.StartTime
