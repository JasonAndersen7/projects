/****** Script for SelectTopNRows command from SSMS  ******/
-- See the approvals of the claim
USE Claims_Prod

--SELECT *
--FROM ApprovalStates

--SELECT *
--FROM ApproverStatus

SELECT audit.Approvals.ClaimID
	,audit.Approvals.CreatedBy
	,audit.Approvals.IsActive
	,audit.Approvals.ModifiedBy
	,audit.Approvals.ModifiedDate
	,ApprovalStates.NAME
FROM audit.Approvals
INNER JOIN ApprovalStates ON audit.Approvals.ApprovalStateID = ApprovalStates.id
WHERE (audit.Approvals.ClaimID = 389)
ORDER BY audit.Approvals.ModifiedDate;

SELECT Approvals.ClaimID
	,Approvals.IsActive
	,Approvals.ModifiedBy
	,Approvals.ModifiedDate
	,ApprovalStates.NAME
FROM Approvals
INNER JOIN ApprovalStates ON Approvals.ApprovalStateID = ApprovalStates.ID
WHERE (Approvals.ClaimID = 389)

SELECT audit.Claim_Approvers.ClaimID
	,audit.Claim_Approvers.Comments
	,audit.Claim_Approvers.DisplayName
	,audit.Claim_Approvers.ModifiedBy
	,audit.Claim_Approvers.ModifiedDate
	,audit.Claim_Approvers.ApproverStatusID
	,audit.Claim_Approvers.ApprovedDate
	,ApproverStatus.NAME
FROM audit.Claim_Approvers
INNER JOIN ApproverStatus ON audit.Claim_Approvers.ApproverStatusID = ApproverStatus.Ordinal
WHERE (audit.Claim_Approvers.ClaimID = 389)
order by audit.Claim_Approvers.ModifiedDate

SELECT Claim_Approvers.ClaimID
	,Claim_Approvers.EmployeeID
	,Claim_Approvers.Comments
	,Claim_Approvers.DisplayName
	,Claim_Approvers.ModifiedBy 
	,Claim_Approvers.ModifiedDate 
	,Claim_Approvers.ApprovedDate
	,ApprovalStates.NAME
FROM Claim_Approvers
INNER JOIN ApprovalStates ON Claim_Approvers.ApproverStatusID = ApprovalStates.Ordinal
WHERE (Claim_Approvers.ClaimID = 389)




SELECT        audit.Claims.ClaimStateID, audit.Claims.ClaimID, audit.Claims.ModifiedBy, audit.Claims.ModifiedDate, audit.Claims.Statement, audit.Claims.ApprovedDate, ClaimStates.Name, Claims_1.ClaimStateID AS Expr1
FROM            audit.Claims INNER JOIN
                         ClaimStates ON audit.Claims.ClaimStateID = ClaimStates.ID INNER JOIN
                         Claims AS Claims_1 ON audit.Claims.ClaimID = Claims_1.ID
WHERE        (audit.Claims.ClaimID in (398, 397, 388, 375) )
ORDER BY audit.Claims.ModifiedDate




SELECT Claims.ID
	,Claims.ClaimOwner
	,Claims.ClaimStateID
	,Claims.ClaimTypeID
	,Claims.CreatedBy
	,Claims.CreatedDate
	,Claims.ModifiedBy
	,Claims.ModifiedDate
	,Claims.Statement
	,Claims.ClaimOwnerID
	,Claims.ApprovedDate
	,ClaimStates.NAME
FROM Claims
INNER JOIN ClaimStates ON Claims.ClaimStateID = ClaimStates.ID
WHERE (Claims.ID = 389)
ORDER BY Claims.ModifiedDate DESC
	--figure out history of a claim