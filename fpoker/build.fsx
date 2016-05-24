#r "packages/FAKE/tools/FakeLib.dll"
open Fake

let buildDir = "./build"

Target "Clean" (fun _ ->
    CleanDir buildDir
)

Target "BuildApp" (fun _ ->
    !! "*.fsproj"
        |> MSBuildRelease buildDir "Build"
        |> Log "AppBuild-Output: "
)

"Clean"
    ==> "BuildApp"

RunTargetOrDefault "BuildApp"