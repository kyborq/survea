import React from 'react';
import {Link} from 'react-router-dom';
import {Outlet} from 'react-router-dom';

export const Layout = () => {
  return (
    <div>
      {/* header here */}
      <h1>My website</h1>
      <Link to="home">Home</Link>
      <Link to="user">User</Link>
      <div>
        <Outlet />
      </div>
    </div>
  );
};
