# Flashcards
Mobile flashcard prototype for GIMM 400

Flashcards README

Equipment needed:
- Raspberry Pi or device that can run SQL
- Devices that have internet connection, for this prototype,
  specifically Android devices
  
Setup:
There is almost no set up needed to run the app itself. Install the app on two
Android devices. One device will show the instructor's options and the other will
be the students which will be a blank green screen until an option is chosen on the
instructor's side. A SQL server should be running on a device or server with the 
relevant data points.

Instructions:
The instructor selects an animal by tapping on it. An image of that animal is then
displayed on the student's device.

Technical Background:
The app runs using a SQL server. When the instructor makes a selection, the app calls
a PHP script that sets the value of that option on the SQL database to 1. The student's
app calls the server and when it sees a 1, it activates the correct image. The calls and
value changes are done using PHP scripts that the C# code in the app calls. This is for
security and ease of use and organization when the app expands beyond a small prototype.
The entire app uses standard libraries from Unity and standard PHP and SQL code.

Original Plan:
The assignment called for an external device to gather information and then output information
based on that data. Originally I wanted to create a random number generator and have that data
output and displayed in an augmented reality application. However, after some thought, I wanted
to develop something more practical and that catered to my interest in development for the education
field and my two younger children. In that, the flashcards app was born. It uses two devices to 
simulate flashcards as they would be used to educate children in math, colors, animals, etc. The
app uses a Raspberry Pi running a SQL server to handle the data between the devices so that it is
scalable, mobile, and can be done over a large distance and with multiple people.

Problems:
The only two problems I faced were getting the firewall settings correct to allow the flow of data
between the devices and the Raspberry Pi which I solved through networking tutorials and my own
knowledge of networking, and getting the SQL command POST to work. I wanted to use POST to change
the values on the server based on the cotnext of the C# code but after many hours I just could not
get it to work so I developed a workaround which isn't a good plan for larger apps but work for my
little prototype. I create a separate script for both on and off for each animal. The C# code would
call the correct script based on what needed to happen.

Future Development:
I would like to simplify the PHP scripts and get POSt working so I only need one script that handles
all of the value changes. I would also like to add buttons or voice recognition on the student's side
so that meaningful input from them could be collected and analyzed. An A.I. could then be implemented
into the server that analyzes the information from the student and could either recommend areas of 
improvement to the teacher, or take over and begin showing the student things they need to work on.

