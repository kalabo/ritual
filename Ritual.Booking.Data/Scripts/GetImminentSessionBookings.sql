/****** Object:  StoredProcedure [dbo].[GetImminentSessionBookings]    Script Date: 30/01/2015 21:09:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mark Hirst
-- Create date: 30 Jan 2015
-- Description:	Gets the bookings starting in the next 30 minutes
-- =============================================
CREATE PROCEDURE [dbo].[GetImminentSessionBookings]

	@LocationId int, 
	@CurrentDateTime datetime

AS
BEGIN

	select 
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
END

GO

