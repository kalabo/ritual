/****** Object:  StoredProcedure [dbo].[GetImminentSessionBookings]    Script Date: 04/02/2015 20:07:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetImminentSessionBookings]

	@LocationId int, 
	@CurrentDateTime datetime

AS
BEGIN

	Declare @availableSlots int

	select @availableSlots = AvailableSlots from Location where Id = @LocationId;

	with Numbers_cte as (
    select 1 as Number
    union all
    select Number + 1
    from Numbers_cte
    where Number < @availableSlots)
,
 Session_CTE as (

	select 
		ROW_NUMBER() over (order by SessionBooking.id ) as RowNr,
		TimeSlot.Id as TimeSlotId,
		SessionBooking.id as SessionBookingId,
		MemberId,
		Member.FirstName,
		Member.LastName
	from 
		SessionBooking
	join 
		TimeSlot
	on 
		SessionBooking.TimeSlotId = TimeSlot.Id
	join 
		Member 
	on 
		SessionBooking.MemberId = Member.Id
	where 
		SessionBooking.Date = CONVERT(date, @CurrentDateTime) and 
		TimeSlot.StartTime between CONVERT(time, @CurrentDateTime) and DATEADD(mi, 300, CONVERT(time, @CurrentDateTime)) and
		SessionBooking.LocationId = @LocationId and 
		SessionBooking.BookingStateId = 1
		)

	select * from Session_CTE right join Numbers_cte on Numbers_cte.Number = Session_CTE.RowNr
END

GO

