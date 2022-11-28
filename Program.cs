using static System.Console;
WriteLine("MAX Student Interview Scheduler");

List<string> students = new();
var student = "x";
while(!student.Equals(string.Empty)) {
    student = Ask("Enter student name [empty to quit]");
    if(!student.Equals(string.Empty))
        students.Add(student);
}
var nbrStudents = students.Count();

var answer = Ask("What time will interviews start? [h:mm]");
var hhmmArr = answer.Split(":");
var hh = int.Parse(hhmmArr[0]);
var mm = int.Parse(hhmmArr[1]);
var now = DateTime.Now;
var hhmm = new TimeOnly(hh, mm);

//answer = Ask("How many rooms will be used for interviews? [1-5]");
//var nbrRooms = int.Parse(answer);

answer = Ask("How many minutes for interviews? [30-120]");
var nbrMinutes = int.Parse(answer);

var minutesForInterview = nbrMinutes / nbrStudents;

List<Session> sessions = new();
for(var idx = 0; idx < nbrStudents; idx++) {
    var a = idx;
    var b = a + 2;
    if(b >= nbrStudents)
        b -= nbrStudents;
    var time = hhmm.AddMinutes(minutesForInterview * idx);
    sessions.Add(new Session(time, students[a], students[b]));
}

WriteLine($"| TIME     | R1         | R2         |");
WriteLine($"| -------- | ---------- | ---------- |");
foreach(var s in sessions) {
    WriteLine($"| {s.tmo,-8} | {s.student1,-10} | {s.student2,-10} |");
}

/*****************************/

string? Ask(string prompt) {
    Write($"{prompt}: ");
    return ReadLine();
}

record Session(TimeOnly tmo, string student1, string student2);