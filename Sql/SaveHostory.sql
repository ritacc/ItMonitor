declare @ChannelNo int
declare @SubDeviceID int ,@ParentDevice int 

declare @MAXDATE int 

declare @mDTime datetime
declare @endTime datetime

set @mDTime ='2013-07-01 00:00:00'
set @endTime ='2013-07-31 23:59:59'


--����
--1026	��������ϵͳ
	set @ParentDevice=1026
	set @SubDeviceID=1026
	set @ChannelNo='14202'--�����ڴ�ʹ����	14202 
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='14203'--�����ڴ�ʹ����	14203 
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='14102'--CPUʹ����	14102
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	
	set @ChannelNo='13101'--ÿ���ӵ�Job��	13101
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='13102'--5���ӵ�Job��	13102 
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='13103'--15���ӵ�Job��	13103
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime








--2001	System1
	set @ParentDevice=2001
	set @SubDeviceID=2001
	set @ChannelNo='14202'--�����ڴ�ʹ����	14202 
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='14203'--�����ڴ�ʹ����	14203 
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='14102'--CPUʹ����	14102
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	
	set @ChannelNo='13101'--ÿ���ӵ�Job��	13101
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='13102'--5���ӵ�Job��	13102 
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='13103'--15���ӵ�Job��	13103
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
--2002	System2
	set @ParentDevice=2002
	set @SubDeviceID=2002
	set @ChannelNo='14202'--�����ڴ�ʹ����	14202 
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='14203'--�����ڴ�ʹ����	14203 
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='14102'--CPUʹ����	14102
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	
	set @ChannelNo='13101'--ÿ���ӵ�Job��	13101
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='13102'--5���ӵ�Job��	13102 
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='13103'--15���ӵ�Job��	13103
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
--2003	System3 
	set @ParentDevice=2003
	set @SubDeviceID=2003
	set @ChannelNo='14202'--�����ڴ�ʹ����	14202 
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='14203'--�����ڴ�ʹ����	14203 
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='14102'--CPUʹ����	14102
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	
	set @ChannelNo='13101'--ÿ���ӵ�Job��	13101
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='13102'--5���ӵ�Job��	13102 
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='13103'--15���ӵ�Job��	13103
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
--2004	system4
	set @ParentDevice=2004
	set @SubDeviceID=2004
	set @ChannelNo='14202'--�����ڴ�ʹ����	14202 
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='14203'--�����ڴ�ʹ����	14203 
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='14102'--CPUʹ����	14102
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	
	set @ChannelNo='13101'--ÿ���ӵ�Job��	13101
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='13102'--5���ӵ�Job��	13102 
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='13103'--15���ӵ�Job��	13103
	set @MAXDATE=300			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
/*
--�����
	set @ParentDevice=90101
	set @SubDeviceID=90101

	--��������ʹ�����
	set @ChannelNo='91303'--����ʹ����	91303
	set @MAXDATE=10			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='91403'--����ʹ����	91403
	set @MAXDATE=10			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	

	--�����豸
	set @ParentDevice=1704
	set @SubDeviceID=1705
	
	set @ChannelNo='33001'--�����������
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='33002'--�����������
	set @MAXDATE=100			
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	
	--���������	37001
	--����������	37002
	--���붪����	37003
	--����������	37004	
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
		

	--������������������		380**
	--	InBytes		38001
	--	OutBytes	38002
	set @ChannelNo='38001'
	set @MAXDATE=50
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
	set @ChannelNo='38002'
	set @MAXDATE=40
	exec dbo.SPInitData @SubDeviceID,@ParentDevice,@ChannelNo,@MAXDATE,@mDTime,@endTime
	
*/