use DVDRental;
select * from DVDCopy;

select  a.ActorNumber, dt.DVDNumber, a.ActorSurname, count(distinct(dc.CopyNumber)) as dvd_count, dt.title  from 
DVDTitle dt inner join CastMember cm 
on dt.DVDNumber = cm.DVDNumber inner join Actor a 
on a.ActorNumber = cm.ActorNumber  inner join DVDCopy dc 
on dt.DVDNumber = dc.DVDNumber where a.ActorSurname like '%Rai%'
and dc.CopyNumber not in (select CopyNumber from Loan where DateReturned = null) 
group by dt.DVDNumber, dt.title, a.ActorSurname, a.ActorNumber;

select * from Loan;

