SELECT        ID, Name AS ApprovalState, Ordinal
FROM            ApprovalStates
order by Ordinal



SELECT ApprovalStates.NAME AS ApprovalState
	,Approvals.ClaimID
	,Approvals.CreatedBy
	,Approvals.CreatedDate
	,Approvals.ModifiedBy
	,Approvals.ModifiedDate
FROM ApprovalStates
INNER JOIN Approvals ON ApprovalStates.Ordinal = Approvals.ApprovalStateID