declare @ChannelNo int
declare @SubDeviceID int ,@ParentDevice int 

declare @MAXDATE int 

declare @mDTime datetime
declare @endTime datetime

set @mDTime ='2013-07-01 00:00:00'
set @endTime ='2013-07-31 23:59:59'


--主机
--1026	动环主机系统
	set @ParentDevice=1026
	set @SubDeviceID=1026
	set @ChannelNo='14202'--交换内存使用率	14202 
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='14203'--物理内存使用率	14203 
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='14102'--CPU使用率	14102
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	
	set @ChannelNo='13101'--每分钟的Job数	13101
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='13102'--5分钟的Job数	13102 
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='13103'--15分钟的Job数	13103
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime








--2001	System1
	set @ParentDevice=2001
	set @SubDeviceID=2001
	set @ChannelNo='14202'--交换内存使用率	14202 
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='14203'--物理内存使用率	14203 
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='14102'--CPU使用率	14102
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	
	set @ChannelNo='13101'--每分钟的Job数	13101
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='13102'--5分钟的Job数	13102 
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='13103'--15分钟的Job数	13103
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
--2002	System2
	set @ParentDevice=2002
	set @SubDeviceID=2002
	set @ChannelNo='14202'--交换内存使用率	14202 
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='14203'--物理内存使用率	14203 
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='14102'--CPU使用率	14102
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	
	set @ChannelNo='13101'--每分钟的Job数	13101
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='13102'--5分钟的Job数	13102 
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='13103'--15分钟的Job数	13103
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
--2003	System3 
	set @ParentDevice=2003
	set @SubDeviceID=2003
	set @ChannelNo='14202'--交换内存使用率	14202 
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='14203'--物理内存使用率	14203 
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='14102'--CPU使用率	14102
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	
	set @ChannelNo='13101'--每分钟的Job数	13101
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='13102'--5分钟的Job数	13102 
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='13103'--15分钟的Job数	13103
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
--2004	system4
	set @ParentDevice=2004
	set @SubDeviceID=2004
	set @ChannelNo='14202'--交换内存使用率	14202 
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='14203'--物理内存使用率	14203 
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='14102'--CPU使用率	14102
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	
	set @ChannelNo='13101'--每分钟的Job数	13101
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='13102'--5分钟的Job数	13102 
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='13103'--15分钟的Job数	13103
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
/*
--虚拟机
	set @ParentDevice=90101
	set @SubDeviceID=90101

	--磁盘网络使用情况
	set @ChannelNo='91303'--磁盘使用率	91303
	set @MAXDATE=10			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='91403'--网络使用率	91403
	set @MAXDATE=10			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	

	--网络设备
	set @ParentDevice=1704
	set @SubDeviceID=1705
	
	set @ChannelNo='33001'--流量宽带接收
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='33002'--流量宽带发送
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	
	--流入错误数	37001
	--流出错误数	37002
	--流入丢包数	37003
	--流出丢包数	37004	
	set @ChannelNo='37001'
	set @MAXDATE=10
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='37002'
	set @MAXDATE=10
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='37003'
	set @MAXDATE=10
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='37004'
	set @MAXDATE=10
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
		

	--发送字数总量—今天		380**
	--	InBytes		38001
	--	OutBytes	38002
	set @ChannelNo='38001'
	set @MAXDATE=50
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='38002'
	set @MAXDATE=40
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
*/