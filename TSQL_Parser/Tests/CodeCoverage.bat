"..\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe" -target:"..\packages\NUnit.ConsoleRunner.3.8.0\tools\nunit3-console.exe" -targetargs:"bin\Debug\Tests.dll"  -filter:"+[TSQL*]*" -excludebyattribute:"System.CodeDom.Compiler.GeneratedCodeAttribute" -register:user -output:"bin\Debug\CodeCoverageResult.xml"
"..\packages\ReportGenerator.3.1.2\tools\ReportGenerator.exe" "-reports:bin\Debug\CodeCoverageResult.xml" "-targetdir:bin\Debug\CodeCoverageReport"
"..\packages\coveralls.io.1.4.2\tools\coveralls.net.exe" --opencover "bin\Debug\CodeCoverageResult.xml" -r %COVERALLS_REPO_TOKEN%
pause