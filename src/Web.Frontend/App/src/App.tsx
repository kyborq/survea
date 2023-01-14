import React from 'react';
import {createBrowserRouter, RouterProvider} from 'react-router-dom';
import {Layout} from './components/Layout';
import {Error} from './pages/Error';
import {Home} from './pages/Home';

const router = createBrowserRouter([
  {
    path: '/',
    element: <Layout />,
    errorElement: <Error />,
    children: [
      {
        path: 'home',
        element: <Home />,
      },
      // {
      //   path: '/user',
      //   element: <User />,
      // },
    ],
  },
]);

const App = () => {
  return (
    <React.StrictMode>
      <RouterProvider router={router} />
    </React.StrictMode>
  );
};

export default App;
