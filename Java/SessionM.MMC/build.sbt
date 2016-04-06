name := "SessionM.MMC"

version := "1.0"

scalaVersion := "2.11.7"

libraryDependencies ++= Seq(
  "com.typesafe" % "config" % "1.2.1",
  "junit" % "junit" % "4.12",
  "com.fasterxml.jackson.core" % "jackson-core" % "2.6.0",
  "com.fasterxml.jackson.core" % "jackson-annotations" % "2.6.0",
  "com.fasterxml.jackson.core" % "jackson-databind" % "2.6.0",
  "commons-lang" % "commons-lang" % "2.2",
  "org.apache.httpcomponents" % "httpasyncclient" % "4.1"
)

fork in Test := true
testOptions += Tests.Argument(TestFrameworks.JUnit, "-v", "-a")
compileOrder := CompileOrder.JavaThenScala