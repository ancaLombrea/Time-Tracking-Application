package edu.utcn.timetracking.server.employee;

import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Date;
import java.util.List;

public interface EmployeeRepository extends JpaRepository<Employee, Integer> {
    List<Employee> findByName(String name);
    Employee findById(int id);
    List<Employee> findByHourlyRate(int hour);  // findsBy<Classname>Id
    List<Employee> findByEnrollDate(Date date);

    List<Employee> findByEnrollDateBetween(Date StartDate, Date EndDate);
}
