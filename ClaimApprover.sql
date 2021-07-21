USE Claims_Prod

GO
/********   Audit section **********************/
SELECT audit.Claim_Approvers.ClaimID
,audit.Claim_Approvers.DisplayName
	,ApproverStatus.NAME
	,audit.Claim_Approvers.ModifiedBy
	,audit.Claim_Approvers.ModifiedDate
	
FROM audit.Claim_Approvers
INNER JOIN ApproverStatus ON audit.Claim_Approvers.ApproverStatusID = ApproverStatus.Ordinal
WHERE (audit.Claim_Approvers.ClaimID = 367)
ORDER BY audit.Claim_Approvers.ModifiedDate
GO

/********  End Audit section **********************/

/********  Current Claim Approver section **********************/

SELECT dbo.Claim_Approvers.ClaimID
,dbo.Claim_Approvers.DisplayName
	,ApproverStatus.NAME
	,dbo.Claim_Approvers.ModifiedBy
	,dbo.Claim_Approvers.ModifiedDate
	
FROM dbo.Claim_Approvers
INNER JOIN ApproverStatus ON dbo.Claim_Approvers.ApproverStatusID = ApproverStatus.Ordinal
WHERE (dbo.Claim_Approvers.ClaimID = 367)
ORDER BY dbo.Claim_Approvers.ModifiedDate
GO


/********  End Current Claim Approver section **********************/


/*  match ordinal to ApprovalStates */

SELECT audit.Approvals.ClaimID
	,audit.Approvals.CreatedBy
	,audit.Approvals.IsActive
	,audit.Approvals.ModifiedBy
	,audit.Approvals.ModifiedDate
	,ApprovalStates.NAME AS ApprovalState
	,ClaimStates.NAME AS ClaimsState
	,audit.Approvals.CreatedDate
	,audit.Claims.ModifiedBy AS ModifiedByAudit
	,audit.Claims.ModifiedDate AS ModifiedDateAudit
FROM audit.Approvals
INNER JOIN ApprovalStates ON audit.Approvals.ApprovalStateID = ApprovalStates.ID
INNER JOIN audit.Claims ON audit.Approvals.ID = audit.Claims.ID
INNER JOIN ClaimStates ON audit.Claims.ClaimStateID = ClaimStates.ID
WHERE (audit.Approvals.ClaimID = 367)
ORDER BY audit.Approvals.ModifiedDate;

SELECT audit.Approvals.ClaimID
	,audit.Approvals.CreatedBy
	,audit.Approvals.IsActive
	,audit.Approvals.ModifiedBy
	,audit.Approvals.ModifiedDate
	,ApprovalStates.NAME AS ApprovalState
	,audit.Approvals.CreatedDate
	,audit.Approvals.ApprovalStateID
FROM audit.Approvals
INNER JOIN ApprovalStates ON audit.Approvals.ApprovalStateID = ApprovalStates.Ordinal
WHERE (audit.Approvals.ClaimID = 367)
ORDER BY audit.Approvals.ModifiedDate




SELECT ApprovalStates.NAME AS ApprovalState
	,Approvals.ClaimID
	,Approvals.CreatedBy
	,Approvals.CreatedDate
	,Approvals.ModifiedBy
	,Approvals.ModifiedDate
FROM ApprovalStates
INNER JOIN Approvals ON ApprovalStates.Ordinal = Approvals.ApprovalStateID
WHERE (Approvals.ClaimID = 367)
ORDER BY Approvals.ModifiedDate


SELECT        Claims.ID, Claims.Statement, ClaimStates.Name AS ClaimStateName, ClaimStates.Ordinal AS ClaimStateOrdinal, ApprovalStates.Name AS ApprovalName, ApprovalStates.Ordinal AS ApprovalOrdinal
FROM            ApprovalStates INNER JOIN
                         Approvals ON ApprovalStates.Ordinal = Approvals.ApprovalStateID INNER JOIN
                         Claims ON Approvals.ClaimID = Claims.ID INNER JOIN
                         ClaimStates ON Claims.ClaimStateID = ClaimStates.Ordinal
WHERE        (Approvals.ClaimID = 367)
ORDER BY Approvals.ModifiedDate