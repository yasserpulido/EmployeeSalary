import React, { Component } from 'react';
import Header from "./Header";
import Footer from "./Footer";

class Layout extends Component {
    render() {
        return (
            <React.Fragment>
                <Header />
                <main className="container p-3">
                    {this.props.children}
                </main>
                <Footer />
            </React.Fragment>
        );
    }
}

export default Layout;
