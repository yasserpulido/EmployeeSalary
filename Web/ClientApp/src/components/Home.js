import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/Employee';

class Home extends Component {
    constructor(props) {
        super(props);
        this.state = {
            employeeId: ''
        };
    }

    onChangeSearchEmployee = (e) => {
        this.setState({
            employeeId: e.currentTarget.value
        });
    }

    onClickSearchEmployee = (e) => {
        e.preventDefault();
        const employeeId = this.state.employeeId;
        this.props.requestEmployees(employeeId);
    }

    handleTable = () => {
        if (this.props.employees.length > 0) {
            return (<table className="table table-bordered">
                <thead>
                    <tr>
                        <th className="item-center">Id</th>
                        <th className="item-center">Name</th>
                        <th className="item-center">Role</th>
                        <th className="item-center">Hourly Salary</th>
                        <th className="item-center">Monthly Salary</th>
                        <th className="item-center">Annual Salary</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        this.props.employees.map(employee =>
                            <tr key={employee.id}>
                                <td className="item-center">{employee.id}</td>
                                <td>{employee.name}</td>
                                <td>{employee.roleName}</td>
                                <td className="item-right">{this.handleCurrency(employee.hourlySalary)}</td>
                                <td className="item-right">{this.handleCurrency(employee.monthlySalary)}</td>
                                <td className="item-right">{this.handleCurrency(employee.annualSalary)}</td>
                            </tr>)
                    }
                </tbody>
            </table>);
        }
    }

    handleCurrency = (currency) => {
        const value = currency.toFixed(2).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,");
        return '$ ' + value;
    }

    render() {
        return (
            <React.Fragment>
                <div className="jumbotron">
                    <h1 className="display-6">Welcome to <strong>Employee Salary</strong> App</h1>
                    <p className="lead">This app allow you know the Annual Salary of each Employee dependig of their contract.</p>
                </div>
                <form>
                    <div class="mb-3 row align-items-end">
                        <div class="col-3">
                            <label for="searchEmployee" class="form-label">Employee ID:</label>
                            <input type="text" class="form-control" id="searchEmployee" onChange={(e) => this.onChangeSearchEmployee(e)} value={this.state.employeeId} />
                        </div>
                        <div class="col-2">
                            <button class="btn btn-primary" onClick={this.onClickSearchEmployee}>Get Employees</button>
                        </div>
                    </div>
                </form>
                {this.handleTable()}

            </React.Fragment>
        )
    }
}

export default connect(
    state => state.employee,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Home);
