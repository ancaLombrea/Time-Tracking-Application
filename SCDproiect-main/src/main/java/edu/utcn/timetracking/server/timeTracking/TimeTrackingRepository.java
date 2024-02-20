package edu.utcn.timetracking.server.timeTracking;

import edu.utcn.timetracking.server.employee.Employee;
import org.springframework.data.jpa.repository.JpaRepository;

import java.sql.Time;
import java.util.Date;
import java.util.List;

public interface TimeTrackingRepository extends JpaRepository<TimeTracking, Integer> {

    List<TimeTracking> findByDateBetween (Date from, Date to);
    List<TimeTracking> findByEmployeeId(int id);
}
