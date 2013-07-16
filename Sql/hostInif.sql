declare @ChannelNo int
declare @dDeviceID int 
declare @itemDeviceID int
declare @MAXDATE int 

declare @mDTime datetime
declare @endTime datetime

set @mDTime ='2013-02-01 00:00:00'
set @endTime ='2013-02-28 23:59:59'

DECLARE curItems CURSOR FOR   select  d.DeviceID from t_Bussiness bus
inner join t_Device d  on bus.id= d.DeviceID
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID where bus.ParentId=1032 and (dt.typeid=1 or dt.typeid=9 )

open curItems
FETCH curItems into @dDeviceID
while @@FETCH_STATUS=0 
BEGIN
		
	set @ChannelNo='25201'
	set @MAXDATE=100			
	exec dbo.SPInitData @dDeviceID,@dDeviceID,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='25202'
	set @MAXDATE=100			
	exec dbo.SPInitData @dDeviceID,@dDeviceID,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='25203'
	set @MAXDATE=100
	exec dbo.SPInitData @dDeviceID,@dDeviceID,@ChannelNo,@MAXDATE,@mDTime,@endTime
		
	FETCH curItems into @dDeviceID
END
CLOSE curItems
DEALLOCATE curItems
	 
set @mDTime ='2013-01-01 00:00:00'
set @endTime ='2013-01-30 23:59:59'

DECLARE curItems2 CURSOR FOR   select  d.DeviceID from t_Bussiness bus
inner join t_Device d  on bus.id= d.DeviceID
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID where bus.ParentId=1032 and (dt.typeid=1 or dt.typeid=9 )

open curItems2
FETCH curItems2 into @dDeviceID
while @@FETCH_STATUS=0 
BEGIN
		
	set @ChannelNo='25201'
	set @MAXDATE=100			
	exec dbo.SPInitData @dDeviceID,@dDeviceID,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='25202'
	set @MAXDATE=100			
	exec dbo.SPInitData @dDeviceID,@dDeviceID,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='25203'
	set @MAXDATE=100
	exec dbo.SPInitData @dDeviceID,@dDeviceID,@ChannelNo,@MAXDATE,@mDTime,@endTime
		
	FETCH curItems2 into @dDeviceID
END
CLOSE curItems2
DEALLOCATE curItems2

set @mDTime ='2013-03-01 00:00:00'
set @endTime ='2013-03-30 23:59:59'

DECLARE curItems3 CURSOR FOR   select  d.DeviceID from t_Bussiness bus
inner join t_Device d  on bus.id= d.DeviceID
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID where bus.ParentId=1032 and (dt.typeid=1 or dt.typeid=9 )

open curItems3
FETCH curItems3 into @dDeviceID
while @@FETCH_STATUS=0 
BEGIN
		
	set @ChannelNo='25201'
	set @MAXDATE=100			
	exec dbo.SPInitData @dDeviceID,@dDeviceID,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='25202'
	set @MAXDATE=100			
	exec dbo.SPInitData @dDeviceID,@dDeviceID,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='25203'
	set @MAXDATE=100
	exec dbo.SPInitData @dDeviceID,@dDeviceID,@ChannelNo,@MAXDATE,@mDTime,@endTime
		
	FETCH curItems3 into @dDeviceID
END
CLOSE curItems3
DEALLOCATE curItems3


set @mDTime ='2013-04-01 00:00:00'
set @endTime ='2013-04-30 23:59:59'
DECLARE curItems4 CURSOR FOR   select  d.DeviceID from t_Bussiness bus
inner join t_Device d  on bus.id= d.DeviceID
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID where bus.ParentId=1032 and (dt.typeid=1 or dt.typeid=9 )

open curItems4
FETCH curItems4 into @dDeviceID
while @@FETCH_STATUS=0 
BEGIN
		
	set @ChannelNo='25201'
	set @MAXDATE=100			
	exec dbo.SPInitData @dDeviceID,@dDeviceID,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='25202'
	set @MAXDATE=100			
	exec dbo.SPInitData @dDeviceID,@dDeviceID,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='25203'
	set @MAXDATE=100
	exec dbo.SPInitData @dDeviceID,@dDeviceID,@ChannelNo,@MAXDATE,@mDTime,@endTime
		
	FETCH curItems4 into @dDeviceID
END
CLOSE curItems4
DEALLOCATE curItems4
  
  
  
set @mDTime ='2013-05-01 00:00:00'
set @endTime ='2013-05-30 23:59:59'
DECLARE curItems5 CURSOR FOR   select  d.DeviceID from t_Bussiness bus
inner join t_Device d  on bus.id= d.DeviceID
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID where bus.ParentId=1032 and (dt.typeid=1 or dt.typeid=9 )

open curItems5
FETCH curItems5 into @dDeviceID
while @@FETCH_STATUS=0 
BEGIN
		
	set @ChannelNo='25201'
	set @MAXDATE=100			
	exec dbo.SPInitData @dDeviceID,@dDeviceID,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='25202'
	set @MAXDATE=100			
	exec dbo.SPInitData @dDeviceID,@dDeviceID,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='25203'
	set @MAXDATE=100
	exec dbo.SPInitData @dDeviceID,@dDeviceID,@ChannelNo,@MAXDATE,@mDTime,@endTime
		
	FETCH curItems5 into @dDeviceID
END
CLOSE curItems5
DEALLOCATE curItems5


set @mDTime ='2013-06-01 00:00:00'
set @endTime ='2013-06-30 23:59:59'
DECLARE curItems6 CURSOR FOR   select  d.DeviceID from t_Bussiness bus
inner join t_Device d  on bus.id= d.DeviceID
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID where bus.ParentId=1032 and (dt.typeid=1 or dt.typeid=9 )

open curItems6
FETCH curItems6 into @dDeviceID
while @@FETCH_STATUS=0 
BEGIN
		
	set @ChannelNo='25201'
	set @MAXDATE=100			
	exec dbo.SPInitData @dDeviceID,@dDeviceID,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='25202'
	set @MAXDATE=100			
	exec dbo.SPInitData @dDeviceID,@dDeviceID,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='25203'
	set @MAXDATE=100
	exec dbo.SPInitData @dDeviceID,@dDeviceID,@ChannelNo,@MAXDATE,@mDTime,@endTime
		
	FETCH curItems6 into @dDeviceID
END
CLOSE curItems6
DEALLOCATE curItems6


set @mDTime ='2013-07-01 00:00:00'
set @endTime ='2013-07-30 23:59:59'
DECLARE curItems7 CURSOR FOR   select  d.DeviceID from t_Bussiness bus
inner join t_Device d  on bus.id= d.DeviceID
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID where bus.ParentId=1032 and (dt.typeid=1 or dt.typeid=9 )

open curItems7
FETCH curItems7 into @dDeviceID
while @@FETCH_STATUS=0 
BEGIN
		
	set @ChannelNo='25201'
	set @MAXDATE=100			
	exec dbo.SPInitData @dDeviceID,@dDeviceID,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='25202'
	set @MAXDATE=100			
	exec dbo.SPInitData @dDeviceID,@dDeviceID,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='25203'
	set @MAXDATE=100
	exec dbo.SPInitData @dDeviceID,@dDeviceID,@ChannelNo,@MAXDATE,@mDTime,@endTime
		
	FETCH curItems7 into @dDeviceID
END
CLOSE curItems7
DEALLOCATE curItems7


set @mDTime ='2013-08-01 00:00:00'
set @endTime ='2013-08-30 23:59:59'
DECLARE curItems8 CURSOR FOR   select  d.DeviceID from t_Bussiness bus
inner join t_Device d  on bus.id= d.DeviceID
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID where bus.ParentId=1032 and (dt.typeid=1 or dt.typeid=9 )

open curItems8
FETCH curItems8 into @dDeviceID
while @@FETCH_STATUS=0 
BEGIN
		
	set @ChannelNo='25201'
	set @MAXDATE=100			
	exec dbo.SPInitData @dDeviceID,@dDeviceID,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='25202'
	set @MAXDATE=100			
	exec dbo.SPInitData @dDeviceID,@dDeviceID,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='25203'
	set @MAXDATE=100
	exec dbo.SPInitData @dDeviceID,@dDeviceID,@ChannelNo,@MAXDATE,@mDTime,@endTime
		
	FETCH curItems8 into @dDeviceID
END
CLOSE curItems8
DEALLOCATE curItems8