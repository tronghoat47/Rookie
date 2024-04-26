// See https://aka.ms/new-console-template for more information
using Assignment_2_LinQ;

List<Member> members = new List<Member>{
            new Member("Hoa", "Trong", "Male", new DateOnly(1990, 1, 1), "1234567890", "Hanoi", false),
            new Member("Alice", "Johnson", "Female", new DateOnly(1988, 5, 10), "2345678901", "New York", true),
            new Member("Michael", "Williams", "Male", new DateOnly(1985, 9, 15), "3456789012", "Los Angeles", false),
            new Member("Emily", "Brown", "Female", new DateOnly(1992, 3, 20), "4567890123", "Chicago", true),
            new Member("David", "Jones", "Male", new DateOnly(1987, 7, 25), "5678901234", "Houston", false),
            new Member("John", "Smith", "Male", new DateOnly(1995, 2, 12), "6789012345", "Phoenix", true),
            new Member("Sarah", "Martinez", "Female", new DateOnly(1993, 6, 5), "7890123456", "Philadelphia", false),
            new Member("Christopher", "Taylor", "Male", new DateOnly(1989, 10, 8), "8901234567", "San Antonio", true),
            new Member("Emma", "Anderson", "Female", new DateOnly(1991, 4, 17), "9012345678", "San Diego", false),
            new Member("Matthew", "Garcia", "Male", new DateOnly(1986, 8, 29), "0123456789", "Dallas", true),
            new Member("Olivia", "Rodriguez", "Female", new DateOnly(1994, 12, 3), "1234567890", "San Jose", false),
            new Member("James", "Lopez", "Male", new DateOnly(1984, 11, 14), "2345678901", "Austin", true),
            new Member("Sophia", "Wilson", "Female", new DateOnly(1996, 7, 21), "3456789012", "Jacksonville", false),
            new Member("William", "Miller", "Male", new DateOnly(1988, 3, 26), "4567890123", "San Francisco", true),
            new Member("Ava", "Davis", "Female", new DateOnly(1984, 11, 14), "5678901234", "Indianapolis", false),
            new Member("Daniel", "Hernandez", "Male", new DateOnly(1993, 5, 13), "6789012345", "Columbus", true),
            new Member("Charlotte", "White", "Female", new DateOnly(1987, 1, 22), "7890123456", "Fort Worth", false),
            new Member("Alexander", "Gonzalez", "Male", new DateOnly(1985, 6, 18), "8901234567", "Charlotte", true),
            new Member("Isabella", "Moore", "Female", new DateOnly(1992, 8, 9), "9012345678", "Seattle", false),
            new Member("Joseph", "Jackson", "Male", new DateOnly(1989, 4, 5), "0123456789", "Denver", true),
            new Member("Mia", "Thomas", "Female", new DateOnly(1991, 11, 30), "1234567890", "Washington", false)
        };

Print.Menu(members);
