const requestEmployeesType = 'REQUEST_EMPLOYEES';
const receiveEmployeesType = 'RECEIVE_EMPLOYEES';

const initialState = { employees: [], isLoading: false };

export const actionCreators = {
    requestEmployees: employeeId => async (dispatch, getState) => {

        if (employeeId === getState().employee.employeeId) {
            return;
        }

        dispatch({ type: requestEmployeesType, employeeId });

        const url = `Employee/GetEmployeeAsync?employeeId=${employeeId}`;
        const response = await fetch(url);
        const employees = await response.json();

        dispatch({ type: receiveEmployeesType, employeeId, employees });
    }
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === requestEmployeesType) {
        return {
            ...state,
            employeeId: action.employeeId,
            isLoading: true
        };
    }

    if (action.type === receiveEmployeesType) {
        return {
            ...state,
            employeeId: action.employeeId,
            employees: action.employees,
            isLoading: false
        };
    }

    return state;
};
