/****** Script for SelectTopNRows command from SSMS  ******/
-- See the approvals of the claim
USE Claims_Dev

/*
SELECT *
FROM ApprovalStates

SELECT *
FROM ApproverStatus

*/
SELECT audit.Approvals.ClaimID
	,audit.Approvals.CreatedBy
	,audit.Approvals.IsActive
	,audit.Approvals.ModifiedBy
	,audit.Approvals.ModifiedDate
	,ApprovalStates.NAME
FROM audit.Approvals
INNER JOIN ApprovalStates ON audit.Approvals.ApprovalStateID = ApprovalStates.ID
WHERE (audit.Approvals.ClaimID = 58)
ORDER BY audit.Approvals.ModifiedDate;

SELECT Approvals.ClaimID
	,Approvals.IsActive
	,Approvals.ModifiedBy
	,Approvals.ModifiedDate
	,ApprovalStates.NAME
FROM Approvals
INNER JOIN ApprovalStates ON Approvals.ApprovalStateID = ApprovalStates.ID
WHERE (Approvals.ClaimID = 152)

SELECT audit.Claim_Approvers.ClaimID
	,audit.Claim_Approvers.Comments
	,audit.Claim_Approvers.DisplayName
	,audit.Claim_Approvers.ModifiedBy
	,audit.Claim_Approvers.ModifiedDate
	,audit.Claim_Approvers.ApproverStatusID
	,audit.Claim_Approvers.ApprovedDate
	,ApproverStatus.NAME
	,audit.Claim_Approvers.EmployeeID
	,audit.Claim_Approvers.CreatedDate
FROM audit.Claim_Approvers
INNER JOIN ApproverStatus ON audit.Claim_Approvers.ApproverStatusID = ApproverStatus.Ordinal
WHERE (audit.Claim_Approvers.ClaimID = 152)
ORDER BY audit.Claim_Approvers.ModifiedDate

SELECT Claim_Approvers.ClaimID
	,Claim_Approvers.EmployeeID
	,Claim_Approvers.Comments
	,Claim_Approvers.DisplayName
	,Claim_Approvers.CreatedDate
	,Claim_Approvers.ApprovedDate
	,Claim_Approvers.ApproverStatusID
	,ApproverStatus.NAME
FROM Claim_Approvers
INNER JOIN ApproverStatus ON Claim_Approvers.ApproverStatusID = ApproverStatus.Ordinal
WHERE (Claim_Approvers.ClaimID = 152)

SELECT audit.Claims.ClaimStateID
	,audit.Claims.ClaimID
	,audit.Claims.ModifiedBy
	,audit.Claims.ModifiedDate
	,audit.Claims.Statement
	,audit.Claims.ApprovedDate
	,ClaimStates.NAME
FROM audit.Claims
INNER JOIN ClaimStates ON audit.Claims.ClaimStateID = ClaimStates.ID
WHERE audit.Claims.ClaimID = 152
ORDER BY ModifiedDate

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
WHERE (Claims.ID = 58)
ORDER BY Claims.ModifiedDate DESC
	--figure out hitory of a claim


	Select * from ClaimStates

	USE [Claims_Dev]
GO

UPDATE [dbo].[Claims]
   --SET [ClaimStateID] = 1 -- Approved
     SET [ClaimStateID] = 4 -- Submitted for Approval

 WHERE [dbo].[Claims].ID = 58

GO

