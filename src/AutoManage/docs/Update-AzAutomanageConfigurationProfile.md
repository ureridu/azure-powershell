---
external help file:
Module Name: Az.Automanage
online version: https://docs.microsoft.com/powershell/module/az.automanage/update-azautomanageconfigurationprofile
schema: 2.0.0
---

# Update-AzAutomanageConfigurationProfile

## SYNOPSIS
Updates a configuration profile

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzAutomanageConfigurationProfile -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Configuration <IAny>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Update
```
Update-AzAutomanageConfigurationProfile -Name <String> -ResourceGroupName <String>
 -Parameter <IConfigurationProfileUpdate> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzAutomanageConfigurationProfile -InputObject <IAutomanageIdentity>
 -Parameter <IConfigurationProfileUpdate> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzAutomanageConfigurationProfile -InputObject <IAutomanageIdentity> [-Configuration <IAny>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates a configuration profile

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Configuration
configuration dictionary of the configuration profile.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Automanage.Models.IAny
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Automanage.Models.IAutomanageIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the configuration profile.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases: ConfigurationProfileName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Definition of the configuration profile.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Automanage.Models.Api20220504.IConfigurationProfileUpdate
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
The tags of the resource.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Automanage.Models.Api20220504.IConfigurationProfileUpdate

### Microsoft.Azure.PowerShell.Cmdlets.Automanage.Models.IAutomanageIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Automanage.Models.Api20220504.IConfigurationProfile

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IAutomanageIdentity>`: Identity Parameter
  - `[BestPracticeName <String>]`: The Automanage best practice name.
  - `[ClusterName <String>]`: The name of the Arc machine.
  - `[ConfigurationProfileAssignmentName <String>]`: Name of the configuration profile assignment. Only default is supported.
  - `[ConfigurationProfileName <String>]`: Name of the configuration profile.
  - `[Id <String>]`: Resource identity path
  - `[MachineName <String>]`: The name of the Arc machine.
  - `[ReportName <String>]`: The report name.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[VMName <String>]`: The name of the virtual machine.
  - `[VersionName <String>]`: The Automanage best practice version name.

`PARAMETER <IConfigurationProfileUpdate>`: Definition of the configuration profile.
  - `[Tag <IUpdateResourceTags>]`: The tags of the resource.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[Configuration <IAny>]`: configuration dictionary of the configuration profile.

## RELATED LINKS

