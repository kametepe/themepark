

function Update-SourceVersion
{
  Param
  (  
	[string]$sourceDir,
	[string]$assemblyVersion, 
	[string]$fileAssemblyVersion
  )         
 
	if ($fileAssemblyVersion -eq "")
	{
		$fileAssemblyVersion = $assemblyVersion
	}
	 
	Write-Host "Executing Update-SourceVersion in path $SrcPath, Version is $assemblyVersion and File Version is $fileAssemblyVersion"
  
	
	$AllVersionFiles = Get-ChildItem $sourceDir AssemblyInfo.cs -recurse 
	 
	$jdate = Get-Date   
	$assemblyVersion = $assemblyVersion.Replace("D", $jdate.ToString("dd")).Replace('M',$jdate.ToString("MM")).Replace("Y", $jdate.ToString("yy")).Replace("J", $jdate.ToString("yyMMdd")).Replace("B", $buildIncrementalNumber)
	$fileassemblyVersion = $fileassemblyVersion.Replace("D", $jdate.ToString("dd")).Replace('M',$jdate.ToString("MM")).Replace("Y", $jdate.ToString("yy")).Replace("J", $jdate.ToString("yyMMdd")).Replace("B", $buildIncrementalNumber)
	 
	Write-Host "Transformed Version is $assemblyVersion and Transformed File Version is $fileAssemblyVersion"
  
 
	foreach ($file in $AllVersionFiles) 
	{         
		#save the file for restore        
		$tempFile = $file.FullName + ".tmp"                
		Get-Content $file.FullName | 
				%{$_ -replace 'AssemblyVersion\("\d+(\.(\d+|\*))*"\)', "AssemblyVersion(""$assemblyVersion"")" } |
				%{$_ -replace 'AssemblyFileVersion\("\d+(\.(\d+|\*))*"\)', "AssemblyFileVersion(""$fileAssemblyVersion"")" }  > $tempFile
		Move-Item $tempFile $file.FullName -force
		Write-Host $file.FullName " version $assemblyVersion applied"
	}
  
}

Update-SourceVersion $args[0] $args[1]

 



