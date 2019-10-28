pipeline {
agent any
environment {
dotnet = 'D:\\work\\Dell\\aspnetcore-runtime-2.2.7-win-x64'
}
stages
{
stage ('build') {
steps {
bat label: '', script: 'D:\\work\\Dell\\aspnetcore-runtime-2.2.7-win-x64\\dotnet.exe clean ./HelloWorldSolution.sln'
bat label: '', script: 'D:\\work\\Dell\\aspnetcore-runtime-2.2.7-win-x64\\dotnet.exe publish -o ./releases/%JOB_NAME%_%BUILD_ID%/linux-x64 -c Release --self-contained=false -r linux-x64 ./HelloWorldSolution.sln' 
bat label: '', script: 'D:\\work\\Dell\\aspnetcore-runtime-2.2.7-win-x64\\dotnet.exe publish -o ./releases/%JOB_NAME%_%BUILD_ID%/win-x64 -c Release --self-contained=false -r win-x64 ./HelloWorldSolution.sln' 
}
}
stage('unit.tests') {
steps {
bat label: '', script: 'D:\\work\\Dell\\aspnetcore-runtime-2.2.7-win-x64\\dotnet.exe test  -r linux-x64 ./HelloWorldTest/HelloWorldSolution.Tests.csproj'
bat label: '', script: 'D:\\work\\Dell\\aspnetcore-runtime-2.2.7-win-x64\\dotnet.exe test  -r win-x64 ./HelloWorldTest/HelloWorldSolution.Tests.csproj'

}
}
stage('integration.tests') {
steps {
bat label: '', script: 'D:\\work\\Dell\\aspnetcore-runtime-2.2.7-win-x64\\dotnet.exe test  -r linux-x64 ./HelloWorldSolutions.Tests/HelloWorldSolutions.Integration.Tests.csproj'
bat label: '', script: 'D:\\work\\Dell\\aspnetcore-runtime-2.2.7-win-x64\\dotnet.exe test  -r win-x64 ./HelloWorldSolutions.Tests/HelloWorldSolutions.Integration.Tests.csproj'
}
}

stage('getlog') {
        steps {
bat label: '', script: 'cp -f \'%JENKINS_HOME%\\jobs\\%JOB_BASE_NAME%\\branches\\%BRANCH_NAME%\\%BUILD_ID%\\log\' \'.\\releases\\%JOB_NAME%_%BUILD_ID%\\log\''
}
}
 stage('archive') {
         steps {    
 node ('MyWindowsSlave') {
  powershell(returnStdout: true, script: '''
                    $version = '1.0-beta'
                    $product = 'TestAssignment'
                    $toPack = '.\\releases\\%JOB_NAME%_%BUILD_ID%'
                    $output = '.\\releases\\archived-versioned'
                    $fileName = "{0}.{1}" -f $product,$version
                    $zipFile = ("{0}\\{1}.zip" -f $output,$fileName)
                    Compress-Archive -Path $toPack -DestinationPath $zipFile
                    '''
                    )
        }
 }
 }
 }
}
