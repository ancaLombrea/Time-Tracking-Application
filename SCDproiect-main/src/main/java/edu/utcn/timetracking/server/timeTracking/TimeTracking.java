package edu.utcn.timetracking.server.timeTracking;

import edu.utcn.timetracking.server.employee.Employee;
import io.swagger.annotations.ApiModelProperty;
import lombok.Data;
import org.hibernate.annotations.CreationTimestamp;

import javax.persistence.*;
import java.util.Date;

@Entity
@Data
public class TimeTracking {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @ApiModelProperty(hidden = true)
    private Integer idTime;
    private Float minutes;
    private Date date;

    @ManyToOne()
    @JoinColumn(name = "employee_id", nullable = false, foreignKey = @ForeignKey(name="employee_id"))
    private Employee employee;
}
