-- See the evidence history of the claim
USE Claims_Prod

--history of claim evidence
Select * from audit.Claim_Evidence ce 
where ce.ClaimID = 442
order by CreatedDate desc;

--Current and historical claim evidence
Select * from audit.Claim_Evidence ce 
inner join dbo.Claim_Evidence dce 
on ce.ClaimID = dce.ClaimID
where ce.ClaimID = 442
order by ce.CreatedDate desc;


--Current claim_evidence

select * from  dbo.Claim_Evidence dce 
where dce.ClaimID = 442
order by CreatedDate desc;
