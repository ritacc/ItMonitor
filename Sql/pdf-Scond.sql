/*
select COUNT(*) from ReportTemp 

select monitordate,round(AVG(monitorvalue),2) monitorvalue from ReportTemp
where channelno=42105
group by monitordate
order by monitordate
*/

/*
--��ռ���ϸ
select d.DeviceName,db.DeviceName DBName, ditem.DeviceName tableSpaceName,gro.*
	,sy.monitorvalue as syValue ,ROUND( (gro.monitorvalue- sy.monitorvalue)/sy.monitorvalue,2)*100 tb
from (
	select deviceno,channelno,round(AVG(monitorvalue),2) monitorvalue from ReportTemp	
	where channelno=42105 and MonitorTime >='2013-07-01 00:00:00' and MonitorTime <='2013-07-31 23:59:59'
	group by deviceno,channelno	
) as gro
inner join t_DevItemList ditem on ditem.DeviceID= gro.deviceno
inner join t_Bussiness bus on ditem.ParentDevID=bus.Id
inner join t_Device db on db.DeviceID= bus.Id
inner join t_Device  d on  d.DeviceID= bus.ParentId 
left join 
(
		select deviceno,channelno,round(AVG(monitorvalue),2) monitorvalue from ReportTemp
		where channelno=42105 and MonitorTime >='2013-06-01 00:00:00' and MonitorTime <='2013-06-30 23:59:59'
		group by deviceno,channelno
) as sy on sy.deviceno= gro.deviceno and sy.channelno= gro.channelno
order by deviceno,channelno
*/
--41601		--������
select  monitordate,max(monitorvalue) maxval,MIN(monitorvalue) minval,round(AVG(monitorvalue),2) avgval
from ReportTemp	
where channelno=41601 
group by monitordate
order by monitordate

--41602		--�����ֵ�
select  
	monitordate,max(monitorvalue) maxval,MIN(monitorvalue) minval,round(AVG(monitorvalue),2) avgval
from ReportTemp	where channelno=41602
group by monitordate
order by monitordate

--41603		--��
select  
	monitordate,max(monitorvalue) maxval,MIN(monitorvalue) minval,round(AVG(monitorvalue),2) avgval
from ReportTemp	where channelno=41603 group by monitordate 
order by monitordate

--��� ������
select d.DeviceName, hcq.deviceno,hcq.maxval hcqmax,hcq.minval hcqmin,hcq.avgval hcqavg
,sjzd.maxval sjzdmax,sjzd.minval sjzdmin,sjzd.avgval sjzdavg
,k.maxval	kmax,	k.minval	kmin,k.avgval kavg
from (
	select  deviceno,max(monitorvalue) maxval,MIN(monitorvalue) minval,
	round(AVG(monitorvalue),2) avgval from ReportTemp	 
	where channelno=41601 and MonitorTime >='2013-06-01 00:00:00' and MonitorTime <='2013-06-30 23:59:59'
	group by deviceno
) as hcq
left join (
	select  deviceno,max(monitorvalue) maxval,MIN(monitorvalue) minval,
	round(AVG(monitorvalue),2) avgval from ReportTemp	 
	where channelno=41602 and MonitorTime >='2013-06-01 00:00:00' and MonitorTime <='2013-06-30 23:59:59'
	group by deviceno
) as sjzd   on hcq.deviceno= sjzd.deviceno
left join (
	select  deviceno,max(monitorvalue) maxval,MIN(monitorvalue) minval,
	round(AVG(monitorvalue),2) avgval from ReportTemp	 
	where channelno=41603 and MonitorTime >='2013-06-01 00:00:00' and MonitorTime <='2013-06-30 23:59:59'
	group by deviceno
) as k on k.deviceno= hcq.deviceno
left join t_Device d on hcq.deviceno= d.DeviceID


--����ʱ�䣬ͼ
select  
	monitordate,max(monitorvalue) maxval,MIN(monitorvalue) minval,round(AVG(monitorvalue),2) avgval
from ReportTemp	where channelno=41101 group by monitordate 
order by monitordate

--���
select d.DeviceName,db.DeviceName DBName,ditem.* from 
(
	select  
		deviceno,max(monitorvalue) maxval,MIN(monitorvalue) minval,round(AVG(monitorvalue),2) avgval
	from ReportTemp	
	where channelno=41101 and MonitorTime >='2013-06-01 00:00:00' and MonitorTime <='2013-06-30 23:59:59'
	group by deviceno 
) as ditem
inner join t_Bussiness bus on ditem.deviceno=bus.Id
inner join t_Device db on db.DeviceID= bus.Id
inner join t_Device  d on  d.DeviceID= bus.ParentId
order by DBName

--������
select d.DeviceName,db.DeviceName DBName, ditem.DeviceName tableSpaceName,gro.*	
from (
	select deviceno,channelno,round(AVG(monitorvalue),2) monitorvalue from ReportTemp	
	where channelno=42109 and MonitorTime >='2013-07-01 00:00:00' and MonitorTime <='2013-07-31 23:59:59'
	group by deviceno,channelno	
) as gro
inner join t_DevItemList ditem on ditem.DeviceID= gro.deviceno
inner join t_Bussiness bus on ditem.ParentDevID=bus.Id
inner join t_Device db on db.DeviceID= bus.Id
inner join t_Device  d on  d.DeviceID= bus.ParentId 
order by deviceno,channelno

--��ռ�	421
--������	42109
--%����		42105

--ֱ�����ݿ�
--������
--41601		--������
--41602		--�����ֵ�
--41603		--��
--41101		����ʱ��