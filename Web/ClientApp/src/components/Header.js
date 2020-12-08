import * as React from 'react';
import { Component } from 'react';

class Header extends Component {
    render() {
        return (
            <nav className="navbar navbar-light bg-light">
                <div className="container-fluid">
                    <span className="navbar-brand mb-0 h1">Employee Salary</span>
                </div>
            </nav>
        );
    }
}

export default Header;