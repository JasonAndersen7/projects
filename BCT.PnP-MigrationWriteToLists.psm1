<#
BCT.PnP-MigrationWriteToLists.psm1

The functions are leveraged while scanning the existing SharePoint 2013 prior to running migration jobs.

Dependencies
	-	PnP PowerShell https://msdn.microsoft.com/en-us/pnp_powershell/pnp-powershell-overview

Table of Contents
    1. Report-SiteOwners
    2. Report-LargeLists
    3. Report-InfoPath
    4. Report-ComplexColumns
    5. Report-SiteOwnerBySiteCollection
#>


function global:Report-SiteOwners
{
	param (
        [parameter(Mandatory=$true, Position=0, ValueFromPipeline=$true)]
        [String]$SPOUrl,
        
        [parameter(Mandatory=$true, Position=0, ValueFromPipeline=$true)]
        [System.Management.Automation.PSCredential]$SPOCred,

		[parameter(Mandatory=$true, Position=0, ValueFromPipeline=$true)]
        [String]$Site,

        [parameter(Mandatory=$false, Position=0, ValueFromPipeline=$true)]
        [String]$SubSite,
        
		[parameter(Mandatory=$false, Position=0, ValueFromPipeline=$true)]
		[String]$WebUrl,

		[parameter(Mandatory=$false, Position=0, ValueFromPipeline=$true)]
		[String]$User,

		[parameter(Mandatory=$false, Position=0, ValueFromPipeline=$true)]
		[String]$Login,

		[parameter(Mandatory=$true, Position=0, ValueFromPipeline=$true)]
		[Object]$SiteOwners,
        
        [parameter(Mandatory=$true, Position=0, ValueFromPipeline=$true)]
		[Object]$ListUrl
    )
    $Owners = $SiteOwners -join ";"
    Connect-PnPOnline -Url $SPOUrl -Credentials $SPOCred
    
    Add-PnPListItem -List "Upgrade - Site Owners" -ContentType "Upgrade Site Owners" -Values @{"SubsiteName" = $SubSite; 
                                                                                               "URL"=$WebUrl;
                                                                                               "Login"=$Login;
                                                                                               "User1"=$User;
                                                                                               "SiteName"=$Site;
                                                                                               "Title"=$Site;
                                                                                               "SiteOwners"=$Owners;
                                                                                               }
}

function global:Report-LargeLists
{
	param (
        [parameter(Mandatory=$true, Position=0, ValueFromPipeline=$true)]
        [String]$SPOUrl,
        
        [parameter(Mandatory=$true, Position=0, ValueFromPipeline=$true)]
        [System.Management.Automation.PSCredential]$SPOCred,

		[parameter(Mandatory=$true, Position=0, ValueFromPipeline=$true)]
        [String]$Site,

        [parameter(Mandatory=$false, Position=0, ValueFromPipeline=$true)]
        [String]$SubSite,
        
		[parameter(Mandatory=$false, Position=0, ValueFromPipeline=$true)]
		[String]$WebUrl,

		[parameter(Mandatory=$false, Position=0, ValueFromPipeline=$true)]
		[String]$ListName,

        [parameter(Mandatory=$false, Position=0, ValueFromPipeline=$true)]
		[String]$ItemCount,

		[parameter(Mandatory=$true, Position=0, ValueFromPipeline=$true)]
		[Object]$SiteOwners,
        
        [parameter(Mandatory=$true, Position=0, ValueFromPipeline=$true)]
		[Object]$ListUrl
    )
    $Owners = $SiteOwners -join "; "
    
    [uri]$URI = $SPOUrl
    $ListUrl = "https://" + $URI.Host + $List.RootFolder.ServerRelativeUrl
    $ListUrl = $ListUrl  -ireplace [regex]::Escape("SiteDirectory"), "sites"
    
    Connect-PnPOnline -Url $SPOUrl -Credentials $SPOCred    
    Add-PnPListItem -List "Upgrade - Large Lists" -ContentType "Upgrade Site Owners" -Values @{"SubsiteName" = $SubSite; 
                                                                                               "URL"=$WebUrl;
                                                                                               "ListName"=$ListName;
                                                                                               "SiteName"=$Site;
                                                                                               "Title"=$Site;
                                                                                               "ItemCount"=$ItemCount;
                                                                                               "SiteOwners"=$Owners;
                                                                                               "ListUrl" = $ListUrl;
                                                                                               }
}

function global:Report-InfoPath
{
	param (
        [parameter(Mandatory=$true, Position=0, ValueFromPipeline=$true)]
        [String]$SPOUrl,
        
        [parameter(Mandatory=$true, Position=0, ValueFromPipeline=$true)]
        [System.Management.Automation.PSCredential]$SPOCred,

		[parameter(Mandatory=$true, Position=0, ValueFromPipeline=$true)]
        [String]$Site,

        [parameter(Mandatory=$false, Position=0, ValueFromPipeline=$true)]
        [String]$SubSite,
        
		[parameter(Mandatory=$false, Position=0, ValueFromPipeline=$true)]
		[String]$WebUrl,

		[parameter(Mandatory=$false, Position=0, ValueFromPipeline=$true)]
		[String]$ListName,

		[parameter(Mandatory=$true, Position=0, ValueFromPipeline=$true)]
		[Object]$SiteOwners,
        
        [parameter(Mandatory=$true, Position=0, ValueFromPipeline=$true)]
		[Object]$ListUrl
    )
    $Owners = $SiteOwners -join "; "
    
    [uri]$URI = $SPOUrl
    $ListUrl = "https://" + $URI.Host + $List.RootFolder.ServerRelativeUrl
    $ListUrl = $ListUrl  -ireplace [regex]::Escape("SiteDirectory"), "sites"
    
    Connect-PnPOnline -Url $SPOUrl -Credentials $SPOCred    
    Add-PnPListItem -List "Upgrade - InfoPath" -ContentType "Upgrade Site Owners" -Values @{"SubsiteName" = $SubSite; 
                                                                                               "URL"=$WebUrl;
                                                                                               "ListName"=$ListName;
                                                                                               "SiteName"=$Site;
                                                                                               "Title"=$Site;
                                                                                               "SiteOwners"=$Owners;
                                                                                               "ListUrl" = $ListUrl;
                                                                                               }
}

function global:Report-ComplexColumns
{
	param (
        [parameter(Mandatory=$true, Position=0, ValueFromPipeline=$true)]
        [String]$SPOUrl,
        
        [parameter(Mandatory=$true, Position=0, ValueFromPipeline=$true)]
        [System.Management.Automation.PSCredential]$SPOCred,

		[parameter(Mandatory=$true, Position=0, ValueFromPipeline=$true)]
        [String]$Site,

        [parameter(Mandatory=$false, Position=0, ValueFromPipeline=$true)]
        [String]$SubSite,
        
		[parameter(Mandatory=$false, Position=0, ValueFromPipeline=$true)]
		[String]$WebUrl,

		[parameter(Mandatory=$false, Position=0, ValueFromPipeline=$true)]
		[String]$ListName,

        [parameter(Mandatory=$false, Position=0, ValueFromPipeline=$true)]
		[String]$BCTColumnName,

        [parameter(Mandatory=$false, Position=0, ValueFromPipeline=$true)]
		[String]$BCTColumnType,

		[parameter(Mandatory=$true, Position=0, ValueFromPipeline=$true)]
		[Object]$SiteOwners,
        
        [parameter(Mandatory=$true, Position=0, ValueFromPipeline=$true)]
		[string]$ListUrl
    )
    $Owners = $SiteOwners -join "; "
    
    [uri]$URI = $SPOUrl
    $ListUrl = "https://" + $URI.Host + $List.RootFolder.ServerRelativeUrl
    $ListUrl = $ListUrl  -ireplace [regex]::Escape("SiteDirectory"), "sites"
    
    Connect-PnPOnline -Url $SPOUrl -Credentials $SPOCred    
    Add-PnPListItem -List "Upgrade - Complex Columns" -ContentType "Upgrade Complex Columns" -Values @{"SubsiteName" = $SubSite; 
                                                                                               "URL"=$WebUrl;
                                                                                               "ListName"=$ListName;
                                                                                               "SiteName"=$Site;
                                                                                               "Title"=$Site;
                                                                                               "BCTColumnName"=$BCTColumnName;
                                                                                               "BCTColumnType"=$BCTColumnType;
                                                                                               "SiteOwners"=$Owners;
                                                                                               "ListUrl" = $ListUrl;
                                                                                               }
}

function global:Report-SiteOwnerBySiteCollection
{
	param (
        [parameter(Mandatory=$true, Position=0, ValueFromPipeline=$true)]
        [String]$SiteName,

		[parameter(Mandatory=$true, Position=0, ValueFromPipeline=$true)]
		[Object]$SiteOwners
    )
    $TargetListName = "Site Owners By Site Collection"
    $Owners = $SiteOwners -join ";"
    
    Add-PnPListItem -List  $TargetListName -Values @{   "SiteName"=$SiteName;
                                                        "Title"=$SiteName;
                                                        "SiteOwners"=$Owners;
                                                         }
}